using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing;

namespace miniPaint
{
    class CParamsXML
    {
        const int TREE_LEVELS_AMO = 3;
        const int FIRST_TREE_LEVEL_NUM = 0;
        const string ROOT_ELEMENT_NAME = "params";
        const string ATTRIBUTE_NAME = "val";

        List<string[]>[] xmlTree;
        List<string> loadedParams;
        Stack<string> savingParams;
        int[] levelPos;

        public CParamsXML()
        {
            MakeTreeStructure();
            loadedParams = new List<string>();
            savingParams = new Stack<string>();
            levelPos = new int[TREE_LEVELS_AMO];
            ResetTreeInfo();
        }

        public bool SaveApplicationParametrsToFile(string path, CAppParams appParams)
        {
            try
            {
                MakeXMLfile(path);
                XmlDocument document = new XmlDocument();
                document.Load(path);

                ResetTreeInfo();
                MakeStackWithSavingParams(appParams);
                string[] children = xmlTree[FIRST_TREE_LEVEL_NUM][0];
                XmlNode childNode;
                for (int i = 0; i < children.Length; i++)
                {
                    childNode = GetTreeNode(children[i], FIRST_TREE_LEVEL_NUM, document);
                    document.DocumentElement.AppendChild(childNode);
                }
                
                document.Save(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CAppParams LoadApplicationParametrsFromFile(string path)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(path);

                XmlElement elRoot = document.DocumentElement;
                if (!elRoot.Name.Equals(ROOT_ELEMENT_NAME))
                {
                    return null;
                }

                ResetTreeInfo();
                if (!CheckTreeStructure(FIRST_TREE_LEVEL_NUM, elRoot.ChildNodes))
                {
                    return null;
                }

                return GetLoadedParams();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void MakeXMLfile(string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            XmlWriter writer = XmlWriter.Create(path, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement(ROOT_ELEMENT_NAME);
            writer.WriteEndElement();
            writer.Close();
        }

        private XmlNode GetTreeNode(string name, int curLevel, XmlDocument doc)
        {
            XmlNode node = doc.CreateElement(name);

            if (curLevel == TREE_LEVELS_AMO - 1)
            {
                XmlAttribute atrb = doc.CreateAttribute(ATTRIBUTE_NAME);
                atrb.Value = savingParams.Pop();
                node.Attributes.Append(atrb);
                return node;
            }

            string[] children = xmlTree[curLevel + 1][levelPos[curLevel + 1]];
            levelPos[curLevel + 1] += 1;

            if (children.Length == 0)
            {
                XmlAttribute atrb = doc.CreateAttribute(ATTRIBUTE_NAME);
                atrb.Value = savingParams.Pop();
                node.Attributes.Append(atrb);
            }
            else
            {
                XmlNode childNode;
                for (int i = 0; i < children.Length; i++)
                {
                    childNode = GetTreeNode(children[i], curLevel + 1, doc);
                    node.AppendChild(childNode);
                }
            }

            return node;
        }

        private bool CheckTreeStructure(int curLevel, XmlNodeList nodes)
        {
            int rightNodesAmo = xmlTree[curLevel][levelPos[curLevel]].Length;
            if (nodes.Count != rightNodesAmo)
            {
                return false;
            }
            string curRightName;
            for (int i = 0; i < nodes.Count; i++)
            {
                curRightName = xmlTree[curLevel][levelPos[curLevel]][i];
                if (!nodes[i].Name.Equals(curRightName))
                {
                    return false;
                }
            }

            XmlNode curNode;
            if (curLevel < TREE_LEVELS_AMO - 1)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    curNode = nodes[i];
                    if (curNode.HasChildNodes)
                    {
                        if (!CheckTreeStructure(curLevel + 1, nodes[i].ChildNodes))
                        {
                            return false;
                        }
                    }
                    else if (curNode.Attributes.Count == 1)
                    {
                        loadedParams.Add(curNode.Attributes[0].Value);
                    }
                    else
                    {
                        return false;
                    }
                    levelPos[curLevel + 1] += 1;
                }
            }
            else
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    curNode = nodes[i];
                    if ((!curNode.HasChildNodes) && (curNode.Attributes.Count == 1))
                    {
                        loadedParams.Add(curNode.Attributes[0].Value);
                    }
                }
            }

            return true;
        }

        private CAppParams GetLoadedParams()
        {
            if (CAppParams.ParamsAmo != loadedParams.Count)
            {
                return null;
            }

            CAppParams result = new CAppParams();
            result.WindowLocation = new Point(Int32.Parse(loadedParams[0]), Int32.Parse(loadedParams[1]));
            result.IsMaximized = Boolean.Parse(loadedParams[2]);
            result.WindowSize = new Size(Int32.Parse(loadedParams[4]), Int32.Parse(loadedParams[3]));
            result.PictureBackgroundColor = Color.FromArgb(Int32.Parse(loadedParams[5]));
            result.Colors[0] = Color.FromArgb(Int32.Parse(loadedParams[6]));
            result.Colors[1] = Color.FromArgb(Int32.Parse(loadedParams[7]));
            result.Colors[2] = Color.FromArgb(Int32.Parse(loadedParams[8]));
            result.Colors[3] = Color.FromArgb(Int32.Parse(loadedParams[9]));
            result.Colors[4] = Color.FromArgb(Int32.Parse(loadedParams[10]));
            result.Colors[5] = Color.FromArgb(Int32.Parse(loadedParams[11]));
            result.Colors[6] = Color.FromArgb(Int32.Parse(loadedParams[12]));
            result.Colors[7] = Color.FromArgb(Int32.Parse(loadedParams[13]));
            result.Colors[8] = Color.FromArgb(Int32.Parse(loadedParams[14]));
            result.Colors[9] = Color.FromArgb(Int32.Parse(loadedParams[15]));

            return result;
        }

        private void MakeStackWithSavingParams(CAppParams appParams)
        {
            for (int i = appParams.Colors.Length; i > 0; i--)
            {
                savingParams.Push(appParams.Colors[i - 1].ToArgb().ToString());
            }
            savingParams.Push(appParams.PictureBackgroundColor.ToArgb().ToString());
            savingParams.Push(appParams.WindowSize.Width.ToString());
            savingParams.Push(appParams.WindowSize.Height.ToString());
            savingParams.Push(appParams.IsMaximized.ToString());
            savingParams.Push(appParams.WindowLocation.Y.ToString());
            savingParams.Push(appParams.WindowLocation.X.ToString());
        }

        private void ResetTreeInfo()
        {
            for (int i = 0; i < levelPos.Length; i++)
            {
                levelPos[i] = 0;
            }
            loadedParams.Clear();
            savingParams.Clear();
        }

        private void MakeTreeStructure()
        {

            xmlTree = new List<string[]>[TREE_LEVELS_AMO];
            for (int i = 0; i < TREE_LEVELS_AMO; i++)
            {
                xmlTree[i] = new List<string[]>();
            }

            xmlTree[0].Add(new string[] { "window", "workspace" });

            xmlTree[1].Add(new string[] { "location", "ismax", "size" });
            xmlTree[1].Add(new string[] { "backgroundcolor", "palette" });

            xmlTree[2].Add(new string[] { "x", "y" });
            xmlTree[2].Add(new string[] {  });
            xmlTree[2].Add(new string[] { "height", "width" });
            xmlTree[2].Add(new string[] { });

            string[] colors = new string[10];
            for (int i = 0; i < 10; i++)
            {
                colors[i] = String.Format("color{0}", i);
            }
            xmlTree[2].Add(colors);
        }
    }
}
