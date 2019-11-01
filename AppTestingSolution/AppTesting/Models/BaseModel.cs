using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Xml;
using AppTesting.IO;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace AppTesting.Models
{
    public class BaseModel : ReactiveObject
    {
    }

    public class BaseNode : BaseModel, IWriter, IReader
    {
        public BaseNode()
        {
            Children = new ObservableCollection<BaseNode>();
            Children.CollectionChanged += new NotifyCollectionChangedEventHandler(Children_CollectionChanged);
        }

        private void Children_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.RaisePropertyChanged(nameof(ChildrenCount));
        }


        private string _name;
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public int ChildrenCount
        {
            get => Children == null ? 0 : Children.Count;
        }

        public ObservableCollection<BaseNode> Children { get; }

        public Bitmap ImagePath { get; protected set; }

        public virtual void Write(XmlWriter writer)
        {
            if (writer != null)
            {
                writer.WriteStartElement("Node");
                writer.WriteAttributeString("Class", this.GetType().FullName);
                WriteAttr(writer);
                WriteData(writer);
                writer.WriteEndElement();
            }
        }
        protected virtual void WriteAttr(XmlWriter writer)
        {
            if (writer != null)
            {
                writer.WriteAttributeString("Name", Name);
            }
        }

        protected virtual void WriteData(XmlWriter writer)
        {
            if (writer != null)
            {
                writer.WriteStartElement("Children");
                foreach (BaseNode node in Children)
                    node.Write(writer);
                writer.WriteEndElement();
            }
        }

        public virtual void Clear()
        {
            Children.Clear();
        }
        public void Read(XmlReader reader)
        {
            Clear();
            if (reader != null)
            {
                ReadAttr(reader);
                ReadData(reader);
            }
        }

        protected virtual void ReadAttr(XmlReader reader)
        {
            if (reader != null)
            {
                Name = reader.GetAttribute("Name");
            }
        }

        protected virtual void ReadData(XmlReader reader)
        {
            if (reader != null)
            {
                while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
                {
                    if (reader.NodeType == XmlNodeType.Element)
                        ReadElement(reader);
                }
            }
        }
        protected virtual void ReadElement(XmlReader reader)
        {
            if (reader != null)
            {
                if (reader.Name == "Children" && !reader.IsEmptyElement) ReadChildren(reader);
            }
        }

        protected virtual void ReadChildren(XmlReader reader)
        {
            if (reader != null)
            {
                while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Node")
                    {
                        BaseNode node = Reader.GetNodeFromClassName(reader);
                        if (node != null)
                        {
                            Children.Add(node);
                            node.Read(reader);
                        }
                    }
                }
            }
        }

       
    }


}
