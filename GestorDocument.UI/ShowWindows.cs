using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.ViewModel;
using System.Windows;
using GestorDocument.UI.Login;

namespace GestorDocument.UI
{
    public class ShowWindows  :IShowWindows
    {
        public void ShowAplication()
        {
            UserLoginView login = new UserLoginView();
            login.Show();

            SplashView spla = this.GetParetWindows();

            if (spla != null)
                spla.Close();
        }

        public SplashView GetParetWindows()
        {
            SplashView res = null;
            try
            {
                object query = Application.Current.Windows[0];
                res = query as SplashView;
            }
            catch (Exception)
            {
                ;
            }
            return res;
        }
    }
}
