using System.Collections.ObjectModel;
using System.Xml;
using AppTesting.Models;

namespace AppTesting.IO
{
    public interface IWriter
    {
        void Write(XmlWriter writer);
    }

    public static class Writer
    {

        public static void Write(ObservableCollection<BaseNode> tests)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create("data.xml", settings))
            {
                writer.WriteStartDocument();
                foreach(BaseNode node in tests)
                {
                    node.Write(writer);
                }
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
              
            }
        }
    }
}
