using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace AppTesting.Models
{
    public class AnswerTestModel : ReactiveObject
    {
        public AnswerTestModel(AnswerModel a)
        {
            Answer = a;
        }

        public AnswerModel Answer { get; private set; }
        private bool _selected;
        public bool Selected
        {
            get => _selected;
            set => this.RaiseAndSetIfChanged(ref _selected, value);
        }

    }
}
