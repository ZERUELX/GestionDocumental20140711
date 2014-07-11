using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model
{
    public class TreeViewModel :ModelBase
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

        // ***************************** ***************************** *****************************

        public TreeViewModel()
        {
            this._IsExpanded = false;
        }

        public event EventHandler<EventArgs> SelectedItemChanged;
        public void OnSelectedItemChanged()
        {
            if (SelectedItemChanged != null && this._IsSelected)
            {
                SelectedItemChanged(this, new EventArgs());
            }
        }
    }
}
