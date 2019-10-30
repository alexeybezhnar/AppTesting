using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace AppTesting.Models
{
    public class AnswerModel : BaseNode
    {
        public AnswerModel()
        {
            Name = "Новый ответ";
        }
        public bool Right { get; set; }

        protected override void WriteAttr(XmlWriter writer)
        {
            base.WriteAttr(writer);
            if (writer != null)
            {
#pragma warning disable CA1305 // Укажите IFormatProvider
                writer.WriteAttributeString("Right", Right.ToString());
#pragma warning restore CA1305 // Укажите IFormatProvider
            }
        }

        protected override void ReadAttr(XmlReader reader)
        {
            base.ReadAttr(reader);
            if (reader != null)
            {
                string rString = reader.GetAttribute("Right");
#pragma warning disable CA1304 // Укажите CultureInfo
                Right = (!string.IsNullOrEmpty(rString) && rString.ToLower() == "true");
#pragma warning restore CA1304 // Укажите CultureInfo
            }
        }
    }
}
