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

namespace GestorDocument.UI.AsuntoTurno
{
    /// <summary>
    /// Lógica de interacción para ConsultaHeaderAsuntoView.xaml
    /// </summary>
    public partial class ConsultaHeaderAsuntoView : UserControl
    {
        public ConsultaHeaderAsuntoView()
        {
            InitializeComponent();
        }

        private object GetViewModel()
        {
            return this.DataContext as object;
        }

        private void BtnInformacion_Click(object sender, RoutedEventArgs e)
        {
            TrancingAsuntoTurnoViewModel trancingAsuntoTurnoViewModel = GetViewModel() as TrancingAsuntoTurnoViewModel;

            if (trancingAsuntoTurnoViewModel !=null)
            {
                trancingAsuntoTurnoViewModel.GetReadAsunto();
                ConsultaAsuntoReadView read = new ConsultaAsuntoReadView();
                read.GetAsunto(trancingAsuntoTurnoViewModel);
                read.ShowDialog();
            }

            TrancingAsuntoViewModel trancingAsuntoViewModel = GetViewModel() as TrancingAsuntoViewModel;

            if (trancingAsuntoViewModel != null)
            {
                trancingAsuntoViewModel.GetReadAsunto();
                ConsultaAsuntoReadView read = new ConsultaAsuntoReadView();
                read.GetAsunto(trancingAsuntoViewModel);
                read.ShowDialog();
            }

            TrancingAsuntoTurnoReadViewModel trancingAsuntoTurnoReadViewModel = GetViewModel() as TrancingAsuntoTurnoReadViewModel;

            if (trancingAsuntoTurnoReadViewModel != null)
            {
                trancingAsuntoTurnoReadViewModel.GetReadAsunto();
                ConsultaAsuntoReadView read = new ConsultaAsuntoReadView();
                read.GetAsunto(trancingAsuntoTurnoReadViewModel);
                read.ShowDialog();
            }
            
            
        }
    }
}
