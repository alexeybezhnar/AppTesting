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
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
