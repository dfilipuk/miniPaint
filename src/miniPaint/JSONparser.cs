using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace miniPaint
{
    class CJSONparser
    {
        private List<string> loadedTypes;
        private List<string> loadedNamespaces;
        private string figuresGroupTypeName;

        public CJSONparser(List<string> types, List<string> namespaces, Type figuresGroupType)
        {
            loadedTypes = types;
            loadedNamespaces = namespaces;

            if (figuresGroupType != null)
            {
                string[] declar = figuresGroupType.FullName.Split('.');
                figuresGroupTypeName = declar[1];
            }
            else
            {
                figuresGroupTypeName = null;
            }
        }

        public string ParseFile(string path)
        {
            string content = String.Empty;
            using (var sr = new StreamReader(path, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    content = String.Concat(content, sr.ReadLine());
                }
            }

            return ParseString(content);
        }

        private string ParseString(string content)
        {
            string resContent = String.Empty;

            if (!CheckBrackets(content))
            {
                return null;
            }

            string[] elems = Split(content);
            if (elems.Length == 0)
            {
                return null;
            }

            elems = DeleteUnnecessaryElems(elems);

            resContent = MakeFinalContent(elems);

            return resContent;
        }

        private bool CheckBrackets(string content)
        {
            int val = 0;
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] == '{')
                {
                    val++;
                }
                if (content[i] == '}')
                {
                    val--;
                }
                if (val < 0)
                {
                    return false;
                }
            }
            if (val != 0)
            {
                return false;
            }
            return true;
        }

        private string[] Split(string content)
        {
            List<string> elems = new List<string>();

            int i = 0;
            int startInd, val;
            int length = content.Length;
            while (i < length)
            {
                while ((i < length) && (content[i] != '{'))
                {
                    i++;
                }
                if (i >= length)
                {
                    return elems.ToArray();
                }
                startInd = i;
                val = 1;
                i++;
                while ((i < length) && (val != 0))
                {
                    if (content[i] == '{')
                    {
                        val++;
                    }
                    if (content[i] == '}')
                    {
                        val--;
                    }
                    i++;
                }
                if (val == 0)
                {
                    elems.Add(content.Substring(startInd, i - startInd));
                }
            }

            return elems.ToArray();
        }

        private string[] DeleteUnnecessaryElems(string[] elems)
        {
            List<string> newElems = new List<string>();

            string newElem;
            for (int i = 0; i < elems.Length; i++)
            {
                newElem = CheckElement(elems[i]);
                if (newElem != null)
                {
                    newElems.Add(newElem);
                }
            }

            return newElems.ToArray();
        }

        private string CheckElement(string elem)
        {
            int startInd = elem.IndexOf('"');
            if (startInd == -1)
            {
                return null;
            }
            int endInd = elem.IndexOf('"', startInd + 1);
            if (endInd == -1)
            {
                return null;
            }
            string lexType = elem.Substring(startInd + 1, endInd - startInd - 1);
            lexType = lexType.Trim(' ', '\n', '\t');
            if (!lexType.Equals("__type"))
            {
                return null;
            }

            startInd = elem.IndexOf('"', endInd + 1);
            if (startInd == -1)
            {
                return null;
            }
            endInd = elem.IndexOf('"', startInd + 1);
            if (endInd == -1)
            {
                return null;
            }
            string typeDeclar = elem.Substring(startInd + 1, endInd - startInd - 1);
            bool isFiguresGroupType;
            typeDeclar = CheckTypeDeclaration(typeDeclar, out isFiguresGroupType);
            if (typeDeclar == null)
            {
                return null;
            }

            elem = elem.Remove(startInd + 1, endInd - startInd - 1);
            elem = elem.Insert(startInd + 1, typeDeclar);

            if (isFiguresGroupType)
            {
                if (IsFiguresGroupEmpty(ref elem))
                {
                    return null;
                }
            }

            return elem;
        }

        private bool IsFiguresGroupEmpty(ref string figuresGroup)
        {
            int coordinatesArrayStartInd = figuresGroup.IndexOf('[') + 1;
            if (coordinatesArrayStartInd == -1)
            {
                return true;
            }
            int figuresArrayStartInd = figuresGroup.IndexOf('[', coordinatesArrayStartInd + 1);
            if (figuresArrayStartInd == -1)
            {
                return true;
            }
            int figuresArrayEndInd = figuresGroup.LastIndexOf(']');
            if ((figuresArrayEndInd == -1) || (figuresArrayStartInd >= figuresArrayEndInd))
            {
                return true;
            }

            string figuresArray = figuresGroup.Substring(figuresArrayStartInd, figuresArrayEndInd - figuresArrayStartInd + 1);
            string newFiguresArray = ParseString(figuresArray);

            if (newFiguresArray == null)
            {
                return true;
            }

            if (newFiguresArray.Equals("[]"))
            {
                return true;
            }

            figuresGroup = figuresGroup.Remove(figuresArrayStartInd, figuresArrayEndInd - figuresArrayStartInd + 1);
            figuresGroup = figuresGroup.Insert(figuresArrayStartInd, newFiguresArray);

            return false;
        }

        private string CheckTypeDeclaration(string declar, out bool isFiguresGroupType)
        {
            isFiguresGroupType = false;
            int delim = declar.IndexOf(':');
            if (delim == -1)
            {
                return null;
            }
            string type = declar.Substring(0, delim);
            type = type.Trim(' ', '\n', '\t');

            string namespaceName;
            if (!IsTypeLoaded(type, out namespaceName))
            {
                return null;
            }

            if (figuresGroupTypeName != null)
            {
                if (figuresGroupTypeName.Equals(type))
                {
                    isFiguresGroupType = true;
                }
            }

            string res = String.Empty;
            res = String.Concat(type, ":#", namespaceName);
            return res;
        }

        private bool IsTypeLoaded(string type, out string namespaceName)
        {
            int ind = loadedTypes.IndexOf(type);
            if (ind == -1)
            {
                namespaceName = null;
                return false;
            }
            namespaceName = loadedNamespaces[ind];
            return true;
        }

        private string MakeFinalContent(string[] elems)
        {
            string res = "[";
            
            for (int i = 0; i < elems.Length; i++)
            {
                res = String.Concat(res, elems[i]);
                if (i != elems.Length - 1)
                {
                    res = String.Concat(res, ",");
                }
            }

            res = String.Concat(res, "]");
            return res;
        }
    }
}
