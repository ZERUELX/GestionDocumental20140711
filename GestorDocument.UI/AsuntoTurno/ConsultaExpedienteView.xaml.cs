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
using GestorDocument.UI.DlgModal;
using GestorDocument.ViewModel.AsuntoTurno;
using GestorDocument.Model;

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para ConsultaExpedienteView.xaml
    /// </summary>
    public partial class ConsultaExpedienteView : UserControl
    {
        TrancingAsuntoViewModel _TrancingAsuntoViewModel;
        TrancingAsuntoTurnoViewModel _TrancingAsuntoTurnoViewModel;
        TrancingAsuntoTurnoReadViewModel _TrancingAsuntoTurnoReadViewModel;
        public ConsultaExpedienteView()
        {
            InitializeComponent();
        }

        private TrancingAsuntoViewModel ConvertDataContext(object dataSource)
        {
            TrancingAsuntoViewModel viewModel = dataSource as TrancingAsuntoViewModel;
            return viewModel;
        }

        private TrancingAsuntoTurnoViewModel ConvertDataContext2(object dataSource)
        {
            TrancingAsuntoTurnoViewModel viewModel = dataSource as TrancingAsuntoTurnoViewModel;
            return viewModel;
        }

        private TrancingAsuntoTurnoReadViewModel ConvertDataContext3(object dataSource)
        {
            TrancingAsuntoTurnoReadViewModel viewModel = dataSource as TrancingAsuntoTurnoReadViewModel;
            return viewModel;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var li in this.ListExpediente.Items)
            {
                ExpedienteModel expediente = li as ExpedienteModel;
                expediente.PropertyChanged+=new System.ComponentModel.PropertyChangedEventHandler(expediente_PropertyChanged);   
            }
        }

        void  expediente_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsClick" && (sender as ExpedienteModel).IsClick )
            {
                //abrir docto
                DlgUpload dlg = new DlgUpload();

                _TrancingAsuntoViewModel = ConvertDataContext(this.DataContext);

                if (_TrancingAsuntoViewModel != null)
                {
                    _TrancingAsuntoViewModel.SelectedExpedienteDocumento = (sender as ExpedienteModel);
                    _TrancingAsuntoViewModel.SetOpenDoc();
                    dlg.DataContext = _TrancingAsuntoViewModel;
                    dlg.Owner = Application.Current.Windows[0];
                    _TrancingAsuntoViewModel.start();
                    dlg.ShowDialog();

                }
                _TrancingAsuntoTurnoViewModel = ConvertDataContext2(this.DataContext);

                if (_TrancingAsuntoTurnoViewModel != null)
                {
                    _TrancingAsuntoTurnoViewModel.SelectedExpedienteDocumento = (sender as ExpedienteModel);
                    _TrancingAsuntoTurnoViewModel.SetOpenDoc();
                    dlg.DataContext = _TrancingAsuntoTurnoViewModel;
                    dlg.Owner = Application.Current.Windows[0];
                    _TrancingAsuntoTurnoViewModel.start();
                    dlg.ShowDialog();

                }

                _TrancingAsuntoTurnoReadViewModel = ConvertDataContext3(this.DataContext);

                if (_TrancingAsuntoTurnoReadViewModel != null)
                {
                    _TrancingAsuntoTurnoReadViewModel.SelectedExpedienteDocumento = (sender as ExpedienteModel);
                    _TrancingAsuntoTurnoReadViewModel.SetOpenDoc();
                    dlg.DataContext = _TrancingAsuntoTurnoReadViewModel;
                    dlg.Owner = Application.Current.Windows[0];
                    _TrancingAsuntoTurnoReadViewModel.start();
                    dlg.ShowDialog();

                }


                (sender as ExpedienteModel).IsClick = false;
            }
        }

    }
}
