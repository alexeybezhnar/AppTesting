using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppTesting.Models
{
    public class TestRootModel : BaseNode
    {
        private static Bitmap _icon;
        public TestRootModel()
        {
            Name = "Список тестов";
            if (_icon == null)
                _icon = new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>().Open(new Uri($"resm:AppTesting.Assets.png.root.png")));

            ImagePath = _icon;
        }
    }

    public class TestModel : BaseNode
    {
        private static Bitmap _icon;
        public TestModel()
        {
            Name = "Новый тест";
            if (_icon == null)
                _icon = new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>().Open(new Uri($"resm:AppTesting.Assets.png.test.png")));

            ImagePath = _icon;
        }

    }
}
