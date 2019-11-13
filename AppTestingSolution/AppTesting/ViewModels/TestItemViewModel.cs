using System;
using System.Collections.Generic;
using ReactiveUI;
using AppTesting.Models;

namespace AppTesting.ViewModels
{
    public class TestItemViewModel : ViewModelBase
    {
        public TestItemViewModel()
        {

        }

        List<QuestionTestModel> questions;
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

        private QuestionTestModel _currentQuestion = null;
        public QuestionTestModel CurrentQuestion
        {
            get => _currentQuestion;
            set => this.RaiseAndSetIfChanged(ref _currentQuestion, value);
        }

        private int currentIndex = 0;

        public string Header
        {
            get => string.Concat("Вопрос №", currentIndex);
        }

        public void Next()
        {
            CurrentQuestion = questions[currentIndex];
            currentIndex++;
            this.RaisePropertyChanging(nameof(Header));
        }
    }
}
