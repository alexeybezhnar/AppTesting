using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using AppTesting.Models;

namespace AppTesting.IO
{
    public interface IReader
    {
        void Read(XmlReader reader);
    }

    public class Reader
    {
        public static ObservableCollection<BaseNode> Read()
        {
            ObservableCollection<BaseNode> result = new ObservableCollection<BaseNode>();
            string fileName = string.Concat(Environment.CurrentDirectory, @"\data.xml");

            if (!File.Exists(fileName))
                return result;

            using (XmlReader reader = XmlReader.Create(fileName))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Node")
                    {
                        BaseNode node = GetNodeFromClassName(reader);
                        result.Add(node);
                        node?.Read(reader);
                    }
                }
            }
            //using (XmlReader reader = XmlReader.Create(fileName))
            //{
            //    reader.MoveToContent();
            //    while (reader.Read())
            //    {
            //        if (reader.NodeType == XmlNodeType.Element)
            //        {
            //            if (reader.Name == elementName)
            //            {
            //                XElement el = XNode.ReadFrom(reader) as XElement;
            //                if (el != null)
            //                {
            //                    yield return el;
            //                }
            //            }
            //        }
            //    }

            return result;
        }

        public static BaseNode GetNodeFromClassName(XmlReader reader)
        {
            BaseNode result = null;
            string className = reader?.GetAttribute("Class");
            if (!string.IsNullOrEmpty(className))
                result = GetNodeFromClassName(className);
            return result;
        }

        public static BaseNode GetNodeFromClassName(string className)
        {
            BaseNode result = null;
            Type type = Type.GetType(className);
            if (type != null)
                result = Activator.CreateInstance(type) as BaseNode;
            return result;
        }
    }
}
