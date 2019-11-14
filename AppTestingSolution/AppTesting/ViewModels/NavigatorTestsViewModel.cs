using AppTesting.Models;
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
                IsNext = ((TestItemViewModel)CurrentItemTest).Next();
            }
        }
        public ReactiveCommand OnClickNextTestCommand { get; }
        private void ClickNextTest()
        {
            if (CurrentItemTest is TestItemViewModel && ((TestItemViewModel)CurrentItemTest)?.IsSelectAnswer() == false)
            {
                var mbx = new MessageBox.Avalonia.MessageBoxWindow("Предупреждение", "Не выбран ни один ответ.");
                mbx.Show();
                return;
            }

            IsNext = (bool)((TestItemViewModel)CurrentItemTest)?.Next();
            if (IsNext == false)
                CurrentItemTest = new TestItemEndViewModel();
        }

        bool isNext = true;
        public bool IsNext {
            get => isNext;
            set => this.RaiseAndSetIfChanged(ref isNext, value);
        }
        public ReactiveCommand OnClickEndTestCommand { get; }
        private void ClickEndTest()
        {
            CurrentTest = ListTests[0];
        }

        private ViewModelBase currentItemTest;
        public ViewModelBase CurrentItemTest
        {
            get => currentItemTest;
            set => this.RaiseAndSetIfChanged(ref currentItemTest, value);
        }
    }
}
