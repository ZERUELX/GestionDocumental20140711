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
using GestorDocument.ViewModel;
using GestorDocument.Model;

namespace GestorDocument.UI.Buscar
{
    /// <summary>
    /// Lógica de interacción para CatResultado.xaml
    /// </summary>
    public partial class CatResultadoView : UserControl
    {
        public CatResultadoView()
        {
            InitializeComponent();
        }

        public void GetResultado(BusquedaViewModel _BusquedaViewModel)
        {
            DataContext = _BusquedaViewModel;
        }

        //public void GetResultado(
        //    PrioridadModel prioridad, 
        //    StatusAsuntoModel statusasunto,
        //    string destinatario, 
        //    string signatario, 
        //    DateTime? rangofechadesde,
        //    DateTime? rangofechahasta, 
        //    string referenciadocumento)
        //{
        //    this.DataContext = new ResultadoViewModel(prioridad, statusasunto, destinatario, signatario, rangofechadesde, rangofechahasta, referenciadocumento);
        //}

    }
}
