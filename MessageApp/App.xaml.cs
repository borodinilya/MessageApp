using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MessageApp.BusinessLogic;

namespace MessageApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static BusinessLogicPresenter _businessLogicPresenter;

        private static object obj = new object();
        public static BusinessLogicPresenter GetBusinessLogicPresenter()
        {
            lock(obj)
            {
                if (_businessLogicPresenter == null)
                    _businessLogicPresenter = new BusinessLogicPresenter();
            }

            return _businessLogicPresenter;
        }
        
    }
}
