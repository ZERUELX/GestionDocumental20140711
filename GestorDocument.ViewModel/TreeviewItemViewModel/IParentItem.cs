using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace GestorDocument.ViewModel.TreeviewItemViewModel
{
    public interface IParentItem
    {
        bool HasChildrenCheck { get; set; }

        ObservableCollection<DestinatarioItemViewModel> Children { get; set; }
    }
}
