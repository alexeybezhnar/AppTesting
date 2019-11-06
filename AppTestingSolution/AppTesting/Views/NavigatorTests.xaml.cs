using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AppTesting.ViewModels;

namespace AppTesting.Views
{
    public class NavigatorTests : UserControl
    {
        public NavigatorTests()
        {
            this.InitializeComponent();
            this.DataContext = new NavigatorTestsViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
