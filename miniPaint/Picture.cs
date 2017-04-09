using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Inheritance;

namespace miniPaint
{
    enum PictureMode { pmDraw, pmEdit, pmGroup }
    class CPicture
    {
        List<CTwoDFigure> figures;
        List<Point> points;
        Graphics gCanvas;
        Bitmap buffer;
        PictureBox curPicture;
        CTwoDFigureFactory curFigure;
        Color curColor;
        Point prevSelectedPoint;
        ISelectable selectedFigure;
        CFiguresGroupManager figuresGroupManager;

        PictureMode mode;

        int pointsAmo;
        readonly Color canvasColor;

        public CPicture(PictureBox pb, CTwoDFigureFactory factory, PictureMode startMode, CFiguresGroupManager groupManager)
        {
            figures = new List<CTwoDFigure>();
            points = new List<Point>();
            figuresGroupManager = groupManager;

            currentColor = Color.Black;
            canvasColor = Color.White;
            currentFigure = factory;
            pointsAmo = 0;
            mode = startMode;

            curPicture = pb;
            buffer = new Bitmap(curPicture.Width, curPicture.Height);
            gCanvas = Graphics.FromImage(buffer);

            Redraw();
        }

        public CPicture(PictureBox pb, CTwoDFigureFactory factory, PictureMode startMode, CFiguresGroupManager groupManager, string filepath)
        {
            figures = new List<CTwoDFigure>(loadPicture(filepath));
            points = new List<Point>();
            figuresGroupManager = groupManager;

            currentColor = Color.Black;
            canvasColor = Color.White;
            currentFigure = factory;
            pointsAmo = 0;
            mode = startMode;

            curPicture = pb;
            buffer = new Bitmap(curPicture.Width, curPicture.Height);
            gCanvas = Graphics.FromImage(buffer);

            Redraw(gCanvas);
        }

        public void selectFigure(int x, int y)
        {
            unsetSelection();
            prevSelectedPoint = new Point(x, y);

            int i = figures.Count - 1;
            while ((selectedFigure == null) && (i >= 0))
            {
                ISelectable curFigure = figures[i] as ISelectable;
                if (curFigure != null)
                {
                    if (curFigure.isPointWithinFigure(x, y))
                    {
                        selectedFigure = curFigure;
                        selectedFigure.isSelected = true;
                    }
                }
                i--;
            }

            Redraw();
        }

        private void unsetSelection()
        {
            if (selectedFigure != null)
            {
                selectedFigure.isSelected = false;
                selectedFigure = null;
            }
            Redraw();
        }

        public void AddFigureToGroup(int x, int y)
        {
            selectFigure(x, y);
            if (selectedFigure != null)
            {
                if (selectedFigure is IGroupable)
                {
                    figuresGroupManager.AddFigure(selectedFigure as IGroupable);
                }
            }
            selectedFigure = null;
            Redraw();
        }

        public void addPoint(int x, int y)
        {
            points.Add(new Point(x, y));
            pointsAmo++;

            if (curFigure.isFigureFull(pointsAmo))
            {
                addFigure();
                Redraw();
            }
            else
                drawPoint(x, y, curColor);
        }

        public void deletePoints()
        {
            points.Clear();
            pointsAmo = 0;
            Redraw();
        }

        public void Clear()
        {
            deletePoints();
            figures.Clear();
            gCanvas.Clear(canvasColor);
        }

        public void deleteLastFigure()
        {
            unsetSelection();
            deletePoints();
            if (figures.Count > 0)
                figures.RemoveAt(figures.Count - 1);
            Redraw();
        }

        public void changeColorOfSelectedFigure(Color color)
        {
            if (selectedFigure != null)
            {
                IEditable editFigure = selectedFigure as IEditable;
                if (editFigure != null)
                {
                    editFigure.changeColor(color);
                    Redraw();
                }
            }
        }

        public void changePoitionOfSelectedFigure(int x, int y)
        {
            if (selectedFigure != null)
            {
                IEditable editFigure = selectedFigure as IEditable;
                if (editFigure != null)
                {
                    x = x < 0 ? 0 : x;
                    x = x > curPicture.Width ? curPicture.Width : x;
                    y = y < 0 ? 0 : y;
                    y = y > curPicture.Height ? curPicture.Height : y;

                    editFigure.changePosition(x - prevSelectedPoint.X, y - prevSelectedPoint.Y);
                    prevSelectedPoint.X = x;
                    prevSelectedPoint.Y = y;
                    Redraw();
                }
            }
        }

        public void Redraw()
        {
            if (gCanvas != null)
            {
                gCanvas.Clear(canvasColor);

                for (int i = 0; i < figures.Count; i++)
                    figures[i].Draw();

                switch (this.Mode)
                {
                    case PictureMode.pmEdit:
                        if (selectedFigure != null)
                        {
                            selectedFigure.drawEditFrame();
                        }
                        break;
                    case PictureMode.pmGroup:
                        figuresGroupManager.DrawGroup();
                        break;
                }

                curPicture.Image = buffer;
            }
        }

        private void Redraw(Graphics canv)
        {
            gCanvas.Clear(canvasColor);

            for (int i = 0; i < figures.Count; i++)
                figures[i].Draw(canv);

            switch (this.Mode)
            {
                case PictureMode.pmEdit:
                    if (selectedFigure != null)
                    {
                        selectedFigure.drawEditFrame();
                    }
                    break;
            }

            curPicture.Image = buffer;
        }

        public void savePictureToFile(string filepath)
        {
            CTwoDFigure[] figuresForSave = figures.ToArray();
            var jsonSerializer = new DataContractJsonSerializer(typeof(CTwoDFigure[]));

            using (var fs = new FileStream(filepath, FileMode.Create))
            {
                jsonSerializer.WriteObject(fs, figuresForSave);
            }
        }

        public void DeleteSelectedFigure()
        {
            if (selectedFigure != null)
            {
                CTwoDFigure fig = (CTwoDFigure)selectedFigure;
                figures.Remove(fig);
                selectedFigure = null;
                Redraw();
            }
        }

        private CTwoDFigure[] loadPicture(string content)
        {
            CTwoDFigure[] result;
            var jsonSerializer = new DataContractJsonSerializer(typeof(CTwoDFigure[]));

            byte[] buffer = Encoding.UTF8.GetBytes(content);
            using (var ms = new MemoryStream(buffer))
            {
                result = (CTwoDFigure[]) jsonSerializer.ReadObject(ms);
            }

            return result;
        }

        private void addFigure()
        {
            CTwoDFigure newFigure = currentFigure.CreateFigure(curColor, points.ToArray(), gCanvas);
            if (newFigure != null)
            {
                figures.Add(newFigure);
            }
            points.Clear();
            pointsAmo = 0;
        }

        private void drawPoint(int x, int y, Color color)
        {
            gCanvas.FillEllipse(new SolidBrush(color), x - 3, y - 3, 6, 6);
            curPicture.Image = buffer;
        }

        public CTwoDFigureFactory currentFigure
        {
            get
            {
                return curFigure;
            }
            set
            {
                curFigure = value;
                Mode = PictureMode.pmDraw;
                deletePoints();
            }
        }

        public Color currentColor
        {
            get
            {
                return curColor;
            }
            set
            {
                curColor = value;
                deletePoints();
            }
        }

        public PictureMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
                unsetSelection();
                figuresGroupManager.ClearGroup();
            }
        }

        public ISelectable SelectedFigure
        {
            get
            {
                return selectedFigure;
            }
        }
    }
}
