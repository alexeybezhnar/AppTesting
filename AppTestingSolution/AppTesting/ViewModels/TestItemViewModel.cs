using System;
using System.Linq;
using System.Collections.Generic;
using ReactiveUI;
using AppTesting.Models;
using System.Diagnostics.CodeAnalysis;

namespace AppTesting.ViewModels
{

    public class TestItemViewModel : ViewModelBase
    {
        public TestItemViewModel()
        {

        }

        List<QuestionTestModel> questions;

        public List<QuestionTestModel> Questions { get => questions; }

        [SuppressMessage("Design", "CA1062:Проверить аргументы или открытые методы", Justification = "<Ожидание>")]
        public TestItemViewModel(TestModel test)
        {
            this.test = test;
            questions = new List<QuestionTestModel>(this.test.ChildrenCount);
            Random random = new Random();
            foreach (var item in test.Children)
            {
                if (random.NextDouble() > 0.5)
                    questions.Add(new QuestionTestModel((QuestionModel)item));
                else
                    questions.Insert(0, new QuestionTestModel((QuestionModel)item));
            }
        }

        TestModel test;

        public string Name { get => test?.Name; }

        private QuestionTestBaseModel _currentQuestion = null;
        public QuestionTestBaseModel CurrentQuestion
        {
            get => _currentQuestion;
            set => this.RaiseAndSetIfChanged(ref _currentQuestion, value);
        }

        private int currentIndex = 0;

        public string Header
        {
            get => string.Concat("Вопрос №", currentIndex);
        }

        [SuppressMessage("Performance", "CA1827:Do not use Count() or LongCount() when Any() can be used", Justification = "<Ожидание>")]
        public bool IsSelectAnswer()
        {
            if (CurrentQuestion is QuestionTestModel)
                return ((QuestionTestModel)CurrentQuestion).Answers.Where(f => f.Selected).Count() > 0;
            else
                return true;
        }
        public bool Next()
        {
            bool result = currentIndex < questions.Count;
            if (result)
            {
                CurrentQuestion = questions[currentIndex];
                currentIndex++;
                this.RaisePropertyChanged(nameof(Header));
            }
            else
            {
                CurrentQuestion = new QuestionEndTestModel();
            }
            return result;
        }
    }

    public class TestItemEndViewModel : ViewModelBase
    {
        public TestItemEndViewModel(List<QuestionTestModel> questions)
        {
            Questions = questions;
        }

        public List<QuestionTestModel> Questions { get; private set; }
    }
}
