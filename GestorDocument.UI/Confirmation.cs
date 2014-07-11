using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.ViewModel;
using System.Windows;

namespace GestorDocument.UI
{
    public class Confirmation : IConfirmation
    {
        public string Msg
        {
            get
            {
                return _Msg;
            }
            set
            {
                _Msg = value;
            }
        }
        private string _Msg;

        public bool Response
        {
            get
            {
                return _Response;
            }
            set
            {
                _Response = value;
            }
        }
        private bool _Response;
        public void Show()
        {
            MessageBoxResult result = MessageBox.Show(Msg, "Mensaje de sistema", MessageBoxButton.YesNo, MessageBoxImage.Question);            
            if (result == MessageBoxResult.Yes)
                this.Response = true;
            else
                this.Response = false;
        }

        public void ShowOk()
        {
            MessageBox.Show(Msg, "Mensaje de sistema", MessageBoxButton.OK, MessageBoxImage.Question);
        }
    }
}
