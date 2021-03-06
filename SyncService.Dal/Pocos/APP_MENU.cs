//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace SyncService.Dal.Pocos
{
    public partial class APP_MENU
    {
        #region Primitive Properties
    
        public virtual long IdMenu
        {
            get;
            set;
        }
    
        public virtual Nullable<long> IdMenuParent
        {
            get { return _idMenuParent; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_idMenuParent != value)
                    {
                        if (APP_MENU2 != null && APP_MENU2.IdMenu != value)
                        {
                            APP_MENU2 = null;
                        }
                        _idMenuParent = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<long> _idMenuParent;
    
        public virtual string MenuName
        {
            get;
            set;
        }
    
        public virtual bool IsActive
        {
            get;
            set;
        }
    
        public virtual long LastModifiedDate
        {
            get;
            set;
        }
    
        public virtual bool IsModified
        {
            get;
            set;
        }
    
        public virtual Nullable<long> ServerLastModifiedDate
        {
            get;
            set;
        }
    
        public virtual string PathMenu
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<APP_MENU> APP_MENU1
        {
            get
            {
                if (_aPP_MENU1 == null)
                {
                    var newCollection = new FixupCollection<APP_MENU>();
                    newCollection.CollectionChanged += FixupAPP_MENU1;
                    _aPP_MENU1 = newCollection;
                }
                return _aPP_MENU1;
            }
            set
            {
                if (!ReferenceEquals(_aPP_MENU1, value))
                {
                    var previousValue = _aPP_MENU1 as FixupCollection<APP_MENU>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAPP_MENU1;
                    }
                    _aPP_MENU1 = value;
                    var newValue = value as FixupCollection<APP_MENU>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAPP_MENU1;
                    }
                }
            }
        }
        private ICollection<APP_MENU> _aPP_MENU1;
    
        public virtual APP_MENU APP_MENU2
        {
            get { return _aPP_MENU2; }
            set
            {
                if (!ReferenceEquals(_aPP_MENU2, value))
                {
                    var previousValue = _aPP_MENU2;
                    _aPP_MENU2 = value;
                    FixupAPP_MENU2(previousValue);
                }
            }
        }
        private APP_MENU _aPP_MENU2;
    
        public virtual ICollection<APP_ROL_MENU> APP_ROL_MENU
        {
            get
            {
                if (_aPP_ROL_MENU == null)
                {
                    var newCollection = new FixupCollection<APP_ROL_MENU>();
                    newCollection.CollectionChanged += FixupAPP_ROL_MENU;
                    _aPP_ROL_MENU = newCollection;
                }
                return _aPP_ROL_MENU;
            }
            set
            {
                if (!ReferenceEquals(_aPP_ROL_MENU, value))
                {
                    var previousValue = _aPP_ROL_MENU as FixupCollection<APP_ROL_MENU>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAPP_ROL_MENU;
                    }
                    _aPP_ROL_MENU = value;
                    var newValue = value as FixupCollection<APP_ROL_MENU>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAPP_ROL_MENU;
                    }
                }
            }
        }
        private ICollection<APP_ROL_MENU> _aPP_ROL_MENU;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupAPP_MENU2(APP_MENU previousValue)
        {
            if (previousValue != null && previousValue.APP_MENU1.Contains(this))
            {
                previousValue.APP_MENU1.Remove(this);
            }
    
            if (APP_MENU2 != null)
            {
                if (!APP_MENU2.APP_MENU1.Contains(this))
                {
                    APP_MENU2.APP_MENU1.Add(this);
                }
                if (IdMenuParent != APP_MENU2.IdMenu)
                {
                    IdMenuParent = APP_MENU2.IdMenu;
                }
            }
            else if (!_settingFK)
            {
                IdMenuParent = null;
            }
        }
    
        private void FixupAPP_MENU1(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (APP_MENU item in e.NewItems)
                {
                    item.APP_MENU2 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (APP_MENU item in e.OldItems)
                {
                    if (ReferenceEquals(item.APP_MENU2, this))
                    {
                        item.APP_MENU2 = null;
                    }
                }
            }
        }
    
        private void FixupAPP_ROL_MENU(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (APP_ROL_MENU item in e.NewItems)
                {
                    item.APP_MENU = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (APP_ROL_MENU item in e.OldItems)
                {
                    if (ReferenceEquals(item.APP_MENU, this))
                    {
                        item.APP_MENU = null;
                    }
                }
            }
        }

        #endregion
    }
}
