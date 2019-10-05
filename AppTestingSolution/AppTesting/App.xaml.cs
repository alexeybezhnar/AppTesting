using Avalonia;
using Avalonia.Markup.Xaml;

namespace AppTesting
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
