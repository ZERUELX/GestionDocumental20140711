using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GestorDocument.ViewModel.AsuntoTurno;
using GestorDocument.Model;
using GestorDocument.UI.DlgModal;

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para ReadExpedienteView.xaml
    /// </summary>
    public partial class ReadExpedienteView : UserControl
    {
        public ReadExpedienteView()
        {
            InitializeComponent();
        }

        public ExpedienteModel GetDataContex()
        {
            ExpedienteModel _ExpedienteModel = this.DataContext as ExpedienteModel;

            return _ExpedienteModel;
        }

        /// <summary>
        /// Devuelve un Diccionario de recursos Style
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ResourceDictionary SetDictionaryStyle(string path)
        {
            ResourceDictionary rd = new ResourceDictionary();
            try
            {
                rd.Source = new Uri(path, UriKind.RelativeOrAbsolute);
            }
            catch (Exception ex)
            {

            }
            return rd;
        }

        public void SetSync()
        {
            ExpedienteModel _ExpedienteModel = GetDataContex();

            if (_ExpedienteModel != null && _ExpedienteModel.SyncDocs !=null)
            {
                ResourceDictionary rd = SetDictionaryStyle("GestorDocument.UI;component/Themes/DictionaryTheme.xaml");

                if (_ExpedienteModel.SyncDocs.BanderaStatus)
                {

                    if (rd.Count > 0)
                    {
                        Style stPass = rd["lblSyncGreen"] as Style;
                        lblSyn.Style = stPass;
                        lblSyn.ToolTip = "Fecha de carga : "+ _ExpedienteModel.SyncDocs.FechaCarga;

                    }

                }
                else
                {
                    if (rd.Count > 0)
                    {
                        Style stPass = rd["lblSyncRed"] as Style;
                        lblSyn.Style = stPass;
                        lblSyn.ToolTip = _ExpedienteModel.SyncDocs.Exception;
                    }
                }   
                
                
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.SetSync();
        }

        private void textBockOpenDoc_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ExpedienteModel _ExpedienteModel = GetDataContex();

            _ExpedienteModel.IsClick = true;

        }
    }
}
