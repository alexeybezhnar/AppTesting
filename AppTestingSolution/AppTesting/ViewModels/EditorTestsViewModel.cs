using ReactiveUI;

namespace AppTesting.ViewModels
{
    public class EditorTestsViewModel : TestsViewModel
    {
        public EditorTestsViewModel()
        {
            OnClickPlusCommand = ReactiveCommand.Create(ClickPlus);
            OnClickMinusCommand = ReactiveCommand.Create(ClickMinus);
            OnClickEditCommand = ReactiveCommand.Create(ClickEdit);
        }

        public ReactiveCommand OnClickPlusCommand { get; }
        private void ClickPlus()
        {
            var mbx = new MessageBox.Avalonia.MessageBoxWindow("Click", "OnClickPlusCommand");
            mbx.Show();
        }
        public ReactiveCommand OnClickMinusCommand { get; }
        private void ClickMinus()
        {
            var mbx = new MessageBox.Avalonia.MessageBoxWindow("Click", "OnClickMinusCommand");
            mbx.Show();
        }
        public ReactiveCommand OnClickEditCommand { get; }
        private void ClickEdit()
        {
            var mbx = new MessageBox.Avalonia.MessageBoxWindow("Click", "OnClickEditCommand");
            mbx.Show();
        }
    }
}
