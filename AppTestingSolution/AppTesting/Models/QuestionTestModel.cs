using System;
using System.Collections.Generic;
using Avalonia.Media;
using ReactiveUI;

namespace AppTesting.Models
{
    public class QuestionTestBaseModel : ReactiveObject
    {
    }

    public class QuestionTestModel : QuestionTestBaseModel
    {
        public QuestionTestModel(QuestionModel q)
        {
            Question = q;
            if (Question == null)
                return;
            Random random = new Random();
            foreach (var a in Question.Answers)
            {

                if (random.NextDouble() > 0.5)
                    Answers.Add(new AnswerTestModel(a));
                else
                    Answers.Insert(0, new AnswerTestModel(a));
            }
        }

        public QuestionModel Question { get; private set; }

        public List<AnswerTestModel> Answers { get; private set; } = new List<AnswerTestModel>();

        public bool IsRigth
        {
            get
            {
                bool result = true;
                foreach(var a in Answers)
                {
                    if (a.Selected != a.Answer.Right)
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }
        }

       public Brush BackgroundBrush {  get
            {
                if (IsRigth)
                    return new SolidColorBrush(Color.FromArgb(127, 0, 255, 0));
                else
                    return new SolidColorBrush(Color.FromArgb(127, 255, 0, 0));
            }
        }
    }

    public class QuestionEndTestModel : QuestionTestBaseModel
    {

      
    }
}
