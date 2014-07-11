using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel.TreeviewItemViewModel
{
    public interface ISeguimientoParentItem
    {
        bool HasChildrenCheck { get; set; }

        ObservableCollection<SeguimientoTurnoItemViewModel> Children { get; set; }
    }
}
