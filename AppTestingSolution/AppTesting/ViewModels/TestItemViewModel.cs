using AppTesting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTesting.ViewModels
{
    public class TestItemViewModel : ViewModelBase
    {
        public TestItemViewModel()
        {

        }

        public TestItemViewModel(TestModel test)
        {
            this.test = test;
        }

        TestModel test;

        public string Name { get => test?.Name; }
    }
}
