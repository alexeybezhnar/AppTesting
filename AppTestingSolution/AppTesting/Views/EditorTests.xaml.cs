using AppTesting.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AppTesting.Views
{
    public class EditorTests : UserControl
    {
        public EditorTests()
        {
            this.InitializeComponent();
            this.DataContext = new EditorTestsViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
