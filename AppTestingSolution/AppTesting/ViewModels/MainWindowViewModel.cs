using AppTesting.Views;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTesting.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        UserControl _ViewContent;
        public UserControl ViewContent
        {
            get
            {
                if(_ViewContent == null)
                {
                    if (App.IsAdmin)
                        _ViewContent = new EditorTests();
                    else
                        _ViewContent = new NavigatorTests();
                }
                return _ViewContent;

            }
        }

    }
}
