using System;
using System.Collections.ObjectModel;
using System.Xml;
using AppTesting.IO;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace AppTesting.Models
{
    public class QuestionModel : BaseNode
    {
        private static Bitmap _icon;
        public QuestionModel()
        {
            Name = "Новый вопрос";
            if (_icon == null)
                _icon = new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>().Open(new Uri($"resm:AppTesting.Assets.png.quest.png")));

            ImagePath = _icon;
            Answers = new ObservableCollection<AnswerModel>();
        }

        public ObservableCollection<AnswerModel> Answers { get; }


        protected override void WriteData(XmlWriter writer)
        {
            base.WriteData(writer);
            if (writer != null)
            {
                writer.WriteStartElement("Answers");
                foreach (BaseNode answer in Answers)
                    answer.Write(writer);
                writer.WriteEndElement();
            }
        }

        protected override void ReadElement(XmlReader reader)
        {
            
            if (reader != null)
            {
                if (reader.Name == "Answers") ReadAnswers(reader);
                else base.ReadElement(reader);
            }
        }

        protected virtual void ReadAnswers(XmlReader reader)
        {
            if (reader != null)
            {
                while (reader.Read() && reader.NodeType != XmlNodeType.EndElement)
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Node")
                    {
                        AnswerModel node = Reader.GetNodeFromClassName(reader) as AnswerModel;
                        if (node != null)
                        {
                            Answers.Add(node);
                            node.Read(reader);
                        }
                    }
                }
            }
        }
    }
}
