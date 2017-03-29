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

        bool editMode;

        int pointsAmo;
        readonly Color canvasColor;

        public CPicture(PictureBox pb, CTwoDFigureFactory factory, bool edit)
        {
            figures = new List<CTwoDFigure>();
            points = new List<Point>();

            currentColor = Color.Black;
            canvasColor = Color.White;
            currentFigure = factory;
            pointsAmo = 0;
            editMode = edit;

            curPicture = pb;
            buffer = new Bitmap(curPicture.Width, curPicture.Height);
            gCanvas = Graphics.FromImage(buffer);

            Redraw();
        }

        public CPicture(PictureBox pb, CTwoDFigureFactory factory, bool edit, string filepath)
        {
            figures = new List<CTwoDFigure>(loadPictureFromFile(filepath));
            points = new List<Point>();

            currentColor = Color.Black;
            canvasColor = Color.White;
            currentFigure = factory;
            pointsAmo = 0;
            editMode = edit;

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
                if (selectedFigure != null)
                    selectedFigure.drawEditFrame();
                curPicture.Image = buffer;
            }
        }

        private void Redraw(Graphics canv)
        {
            gCanvas.Clear(canvasColor);
            for (int i = 0; i < figures.Count; i++)
                figures[i].Draw(canv);
            if (selectedFigure != null)
                selectedFigure.drawEditFrame();
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

        private CTwoDFigure[] loadPictureFromFile(string filepath)
        {
            CTwoDFigure[] result;
            var jsonSerializer = new DataContractJsonSerializer(typeof(CTwoDFigure[]));

            using (var fs = new FileStream(filepath, FileMode.Open))
            {
                result = (CTwoDFigure[]) jsonSerializer.ReadObject(fs);
            }

            return result;
        }

        private void addFigure()
        {
            figures.Add(currentFigure.CreateFigure(curColor, points.ToArray(), gCanvas));
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
                isEditMode = false;
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

        public bool isEditMode
        {
            get
            {
                return editMode;
            }
            set
            {
                editMode = value;
                unsetSelection();
            }
        }
    }
}
