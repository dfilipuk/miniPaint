using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniPaint
{
    class CProjectInfo
    {
        public bool isOnDisk { get; set; }
        public bool isSaved { get; set; }
        public string filePath;
        public string fileName;

        const string CONTINUE_QUESTION = "Текущий рисунок не был сохранён. Желаете сохранить его перед тем как продолжить?";
        const string CONTINUE_QUESTION_CAPTION = "Сохранить и продолжить?";

        CViewer UI;

        public CProjectInfo(CViewer currUI)
        {
            resetProjectInfo();
            UI = currUI;
        }

        public void resetProjectInfo()
        {
            isOnDisk = false;
            isSaved = true;
            fileName = String.Empty;
            filePath = String.Empty;
        }

        private string getFileName(string path)
        {
            int start = path.LastIndexOf('\\');
            int end = path.LastIndexOf('.');
            if (end > start)
                return path.Substring(start + 1, end - start - 1);
            else
                return String.Empty;
        }

        public void saveProjectAs()
        {
            string newPath;

            if (UI.getPathForSave(out newPath))
            {
                if (UI.tryToSave(newPath))
                {
                    isOnDisk = true;
                    isSaved = true;
                    filePath = newPath;
                    fileName = getFileName(filePath);
                }
            }
        }

        public void saveProject()
        {
            if (!isOnDisk)
            {
                saveProjectAs();
            }
            else
            {
                if (!isSaved)
                    if (UI.tryToSave(filePath))
                        isSaved = true;
            }
        }

        public void loadProject()
        {
            string newPath;

            if (UI.getPathForLoad(out newPath))
            {
                if (UI.tryToLoad(newPath))
                {
                    isOnDisk = true;
                    isSaved = true;
                    filePath = newPath;
                    fileName = getFileName(filePath);
                }
            }
        }

        public bool canContinue()
        {
            if (!isSaved)
            {
                EResponse response = UI.askQuestion(CONTINUE_QUESTION, CONTINUE_QUESTION_CAPTION);
                bool res = false;
                switch (response)
                {
                    case EResponse.rYes:
                        saveProject();
                        res = true;
                        break;
                    case EResponse.rNo:
                        res = true;
                        break;
                    case EResponse.rCancel:
                        res = false;
                        break;
                }
                return res;
            }
            else
                return true;
        }
    }
}
