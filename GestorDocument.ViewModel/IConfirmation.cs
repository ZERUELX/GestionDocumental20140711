using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.ViewModel
{
    public interface IConfirmation
    {
        string Msg
        {
            get;
            set;
        }

        bool Response
        {
            get;
            set;
        }

        void Show();

        void ShowOk();
    }
}
