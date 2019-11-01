using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Xml;
using AppTesting.IO;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;

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
            Answers.CollectionChanged += new NotifyCollectionChangedEventHandler(Answers_CollectionChanged);
        }

        public ObservableCollection<AnswerModel> Answers { get; }

        private void Answers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.RaisePropertyChanged(nameof(AnswersCount));
            this.RaisePropertyChanged(nameof(AnswersTryCount));
        }

        public int AnswersCount
        {
            get => Answers == null ? 0 : Answers.Count;
        }
        public int AnswersTryCount
        {
            get => Answers == null ? 0 : Answers.Count(f => f.Right);
        }

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
