using AppTesting.IO;
using AppTesting.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppTesting.ViewModels
{
    public class TestsViewModel : ViewModelBase
    {
        public TestsViewModel()
        {
            listTests = Reader.Read();// new ObservableCollection<BaseNode>();
            if (listTests == null || listTests.Count == 0)
            {
                TestRootModel model = new TestRootModel();
                TestModel testModel = new TestModel();
                QuestionModel questionModel = new QuestionModel();

                questionModel.Answers.Add(new AnswerModel());
                testModel.Children.Add(questionModel);
                model.Children.Add(testModel);
                listTests.Add(model);
            }
        }


        private ObservableCollection<BaseNode> listTests;
        public ObservableCollection<BaseNode> ListTests
        {
            get => listTests;
        }

        private BaseNode currentTest;
        public BaseNode CurrentTest
        {
            get => currentTest;
            set => this.RaiseAndSetIfChanged(ref currentTest, value);
        }

    }
}
