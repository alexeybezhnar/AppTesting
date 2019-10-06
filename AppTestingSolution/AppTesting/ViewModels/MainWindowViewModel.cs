using AppTesting.Views;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTesting.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";

        UserControl _ViewContent;
        public UserControl ViewContent
        {
            get
            {
                if(_ViewContent == null)
                {
                    if (App.IsAdmin)
                        _ViewContent = new EditorTests();
                }
                return _ViewContent;

            }
        }
    }
}
