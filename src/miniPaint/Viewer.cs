using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace miniPaint
{
    class CViewer
    {
        frmMain form;

        public CViewer(frmMain currForm)
        {
            form = currForm;
        }

        public void showError(string message)
        {
            form.showErrorMessageBox(message);
        }

        public bool getPathForSave(out string path)
        {
            return form.getPathFromSaveDialog(out path);
        }

        public bool getPathForLoad(out string path)
        {
            return form.getPathFromOpenDialog(out path);
        }

        public bool tryToSave(string path)
        {
            return form.saveToFile(path);
        }

        public bool tryToLoad(string path)
        {
            return form.loadFromFile(path);
        }

        public EResponse askQuestion(string question, string caption)
        {
            return form.showQuestionMessageBox(question, caption);
        }

        public void CreateButton(string name, Image picture)
        {
            form.CreateButton(name, picture);
        }

        public void CreateButton(string name, string text)
        {
            form.CreateButton(name, text);
        }
    }
}
