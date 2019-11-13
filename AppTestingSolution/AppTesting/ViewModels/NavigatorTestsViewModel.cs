﻿using AppTesting.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTesting.ViewModels
{
    public class NavigatorTestsViewModel : TestsViewModel
    {
        public NavigatorTestsViewModel()
        {
            CurrentTest = ListTests[0];
            OnClickSelectCommand = ReactiveCommand.Create<BaseNode>(ClickSelect);
            OnClickEndTestCommand = ReactiveCommand.Create(ClickEndTest);
            OnClickNextTestCommand = ReactiveCommand.Create(ClickNextTest);

        }

        public ReactiveCommand OnClickSelectCommand { get; }
        private void ClickSelect(BaseNode data)
        {
            CurrentTest = data;

            if(CurrentTest is TestModel)
            {
                CurrentItemTest = new TestItemViewModel((TestModel)CurrentTest);
                CurrentItemTest.Next();
            }
        }
        public ReactiveCommand OnClickNextTestCommand { get; }
        private void ClickNextTest()
        {
            CurrentItemTest?.Next();
        }

        public ReactiveCommand OnClickEndTestCommand { get; }
        private void ClickEndTest()
        {
            CurrentTest = ListTests[0];
        }

        private TestItemViewModel currentItemTest;
        public TestItemViewModel CurrentItemTest
        {
            get => currentItemTest;
            set => this.RaiseAndSetIfChanged(ref currentItemTest, value);
        }
    }
}
