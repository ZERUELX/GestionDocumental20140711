using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.ViewModel.AsuntoTurno
{
    public class TreeViewViewModel : ViewModelBase
    {
        // propiedades del treview
        public bool IsCollapsed
        {
            get { return _IsCollapsed; }
            set
            {
                if (_IsCollapsed != value)
                {
                    _IsCollapsed = value;
                    OnPropertyChanged(IsCollapsedPropertyName);
                }
            }
        }
        private bool _IsCollapsed;
        public const string IsCollapsedPropertyName = "IsCollapsed";

        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set
            {
                if (_IsExpanded != value)
                {
                    _IsExpanded = value;
                    OnPropertyChanged(IsExpandedPropertyName);
                }
            }
        }
        private bool _IsExpanded;
        public const string IsExpandedPropertyName = "IsExpanded";

        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                    OnPropertyChanged(IsSelectedPropertyName);
                }
            }
        }
        private bool _IsSelected;
        public const string IsSelectedPropertyName = "IsSelected";

        public TreeViewViewModel()
        {
            this._IsExpanded = false;
        }
    }
}
