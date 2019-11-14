using System;
using System.Collections.Generic;
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
    }

    public class QuestionEndTestModel : QuestionTestBaseModel
    {
    }
}
