using AppTesting.IO;
using ReactiveUI;

namespace AppTesting.ViewModels
{
    public class EditorTestsViewModel : TestsViewModel
    {
        public EditorTestsViewModel()
        {
            OnClickPlusCommand = ReactiveCommand.Create(ClickPlus);
            OnClickMinusCommand = ReactiveCommand.Create(ClickMinus);
            OnClickSaveCommand = ReactiveCommand.Create(ClickSave);
        }

        public ReactiveCommand OnClickPlusCommand { get; }
        private void ClickPlus()
        {

            if (CurrentTest == null)
                return;
            Models.BaseNode model = null;

            if (CurrentTest is Models.TestRootModel)
                model = new Models.TestModel() { Name = "Новый тест" };
            else if (CurrentTest is Models.TestModel)
                model = new Models.QuestionModel() { Name = "Новый вопрос" };
            else if (CurrentTest is Models.QuestionModel)
            {
                ((Models.QuestionModel)CurrentTest).Answers.Add(new Models.AnswerModel() { Name = "Новый ответ" });
            }

            if (model == null)
                return;
                
            CurrentTest.Children.Add(model);
            CurrentTest = model;
        }
        public ReactiveCommand OnClickMinusCommand { get; }
        private void ClickMinus()
        {
            Models.BaseNode model = CurrentTest;
            if (model != null)
                this.ListTests.Remove(model);
        }

        public ReactiveCommand OnClickSaveCommand { get; }
        private void ClickSave()
        {
            Writer.Write(ListTests);
            var mbx = new MessageBox.Avalonia.MessageBoxWindow("Сохранение", "Данные успешно сохранены.");
            mbx.Show();
        }
    }
}
