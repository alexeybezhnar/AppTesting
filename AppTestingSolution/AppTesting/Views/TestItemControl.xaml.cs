using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AppTesting.Views
{
    public class TestItemControl : UserControl
    {
        public TestItemControl()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
