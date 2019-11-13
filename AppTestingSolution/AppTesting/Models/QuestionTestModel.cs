using System;
using System.Collections.Generic;
using ReactiveUI;

namespace AppTesting.Models
{
    public class QuestionTestModel : ReactiveObject
    {
        public QuestionTestModel(QuestionModel q)
        {
            Question = q;
            foreach (var a in q.Answers)
                Answers.Add(new AnswerTestModel(a));
        }

        public QuestionModel Question { get; private set; }

        public List<AnswerTestModel> Answers { get; private set; } = new List<AnswerTestModel>();
    }
}
