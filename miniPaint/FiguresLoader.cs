using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance;
using System.Reflection;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace miniPaint
{
    class CFiguresLoader
    {
        public List<Type> LoadedTypes { get; set; }
        public List<MethodInfo> LoadedMethods { get; set; }
        public List<string> TypesNames { get; set; }
        public List<string> NamespacesNames { get; set; }
        public Type FiguresGroupType { get; set; }

        const string FIGURES_DIR = "figures";
        const string PICTURE_FILE_TEMPLATE = "pics/{0}.png";
        const string BUTTON_NAME_TEMPLATE = "btn_figure_{0}";

        private CViewer UI;

        public CFiguresLoader(CViewer curUI)
        {
            UI = curUI;
            FiguresGroupType = null;
            LoadedTypes = new List<Type>();
            LoadedMethods = new List<MethodInfo>();
            TypesNames = new List<string>();
            NamespacesNames = new List<string>();
        }

        public void LoadFigures()
        {
            if (Directory.Exists(FIGURES_DIR))
            {
                string[] files = Directory.GetFiles(FIGURES_DIR, "*.dll");
                int curFigureNum = 0;
                string path = String.Empty;
                string filename;
                for (int i = 0; i < files.Length; i++)
                {
                    filename = Path.GetFileName(files[i]);
                    path = String.Format("{0}/{1}", FIGURES_DIR, filename);
                    if (LoadFigureFromAssembly(path, curFigureNum))
                    {
                            curFigureNum++;
                    }
                }
            }
        }

        public int GetBtnNumber(string name)
        {
            string[] substrs = name.Split('_');
            return int.Parse(substrs[2]);
        }

        public CTwoDFigureFactory GetFactoryOfType(Type type)
        {
            for (int i = 0; i < LoadedTypes.Count; i++)
            {
                if (LoadedTypes[i].Equals(type))
                {
                    object obj = new object();
                    object[] objArr = new object[0];
                    return (CTwoDFigureFactory)LoadedMethods[i].Invoke(obj, objArr);
                }
            }
            return null;
        }

        private string GetAssemblyName(string name)
        {
            return name.Substring(0, name.Length - 4);
        }

        private bool LoadFigureFromAssembly(string path, int figureNum)
        {
            try
            {
                string asmName = GetAssemblyName(Path.GetFileName(path));
                Assembly asm = Assembly.LoadFrom(path);
                Type[] types = asm.GetTypes();
                Type figure = null;
                Type factory = null;

                foreach (Type t in types)
                {
                    if (t.BaseType.Equals(typeof(CTwoDFigureFactory)))
                    {
                        factory = t;
                    }
                    if (t.BaseType.Equals(typeof(CTwoDFigure)))
                    {
                        figure = t;
                    }
                }

                if ((factory == null) || (figure == null))
                {
                    return false;
                }

                MethodInfo[] methods = factory.GetMethods(BindingFlags.Public | BindingFlags.Static);
                if (methods.Length == 0)
                {
                    return false;
                }

                List<MethodInfo> goodMethods = new List<MethodInfo>();
                foreach (MethodInfo m in methods)
                {
                    ParameterInfo[] parameters = m.GetParameters();
                    if (parameters.Length == 0)
                    {
                        if (m.ReturnType.BaseType.Equals(typeof(CTwoDFigureFactory)))
                        {
                            goodMethods.Add(m);
                        }
                    }
                }

                if (goodMethods.Count != 1)
                {
                    return false;
                }

                LoadedTypes.Add(figure);
                LoadedMethods.Add(goodMethods[0]);

                if (FiguresGroupType == null)
                {
                    Type[] interfaces = figure.GetInterfaces();
                    foreach (Type t in interfaces)
                    {
                        if (t.Equals(typeof(IFiguresGroup)))
                        {
                            FiguresGroupType = figure;
                        }
                    }
                }

                bool isPictureLoaded;
                Image pic = null;
                try
                {
                    pic = Image.FromFile(String.Format(PICTURE_FILE_TEMPLATE, asmName));
                    isPictureLoaded = true;
                }
                catch (Exception)
                {
                    isPictureLoaded = false;
                }

                if (isPictureLoaded)
                {
                    UI.CreateButton(String.Format(BUTTON_NAME_TEMPLATE, figureNum), pic);
                }
                else
                {
                    UI.CreateButton(String.Format(BUTTON_NAME_TEMPLATE, figureNum), figure.Name);
                }

                string[] typeDeclar = figure.FullName.Split('.');
                NamespacesNames.Add(typeDeclar[0]);
                TypesNames.Add(typeDeclar[1]);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
