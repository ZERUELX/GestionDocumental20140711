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

namespace Protell.Server.DAL.Pocos
{
    public partial class APP_USUARIO
    {
        #region Primitive Properties
    
        public virtual long IdUsuario
        {
            get;
            set;
        }
    
        public virtual string UsuarioCorreo
        {
            get;
            set;
        }
    
        public virtual string UsuarioPwd
        {
            get;
            set;
        }
    
        public virtual string Nombre
        {
            get;
            set;
        }
    
        public virtual string Apellido
        {
            get;
            set;
        }
    
        public virtual string Area
        {
            get;
            set;
        }
    
        public virtual string Puesto
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
    
        public virtual bool IsNuevoUsuario
        {
            get;
            set;
        }
    
        public virtual bool IsActivado
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> IsFlag
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> IsFlagPass
        {
            get;
            set;
        }
    
        public virtual long ServerLastModifiedDate
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<APP_USUARIO_ROL> APP_USUARIO_ROL
        {
            get
            {
                if (_aPP_USUARIO_ROL == null)
                {
                    var newCollection = new FixupCollection<APP_USUARIO_ROL>();
                    newCollection.CollectionChanged += FixupAPP_USUARIO_ROL;
                    _aPP_USUARIO_ROL = newCollection;
                }
                return _aPP_USUARIO_ROL;
            }
            set
            {
                if (!ReferenceEquals(_aPP_USUARIO_ROL, value))
                {
                    var previousValue = _aPP_USUARIO_ROL as FixupCollection<APP_USUARIO_ROL>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAPP_USUARIO_ROL;
                    }
                    _aPP_USUARIO_ROL = value;
                    var newValue = value as FixupCollection<APP_USUARIO_ROL>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAPP_USUARIO_ROL;
                    }
                }
            }
        }
        private ICollection<APP_USUARIO_ROL> _aPP_USUARIO_ROL;
    
        public virtual ICollection<GET_TURNO> GET_TURNO
        {
            get
            {
                if (_gET_TURNO == null)
                {
                    var newCollection = new FixupCollection<GET_TURNO>();
                    newCollection.CollectionChanged += FixupGET_TURNO;
                    _gET_TURNO = newCollection;
                }
                return _gET_TURNO;
            }
            set
            {
                if (!ReferenceEquals(_gET_TURNO, value))
                {
                    var previousValue = _gET_TURNO as FixupCollection<GET_TURNO>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupGET_TURNO;
                    }
                    _gET_TURNO = value;
                    var newValue = value as FixupCollection<GET_TURNO>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupGET_TURNO;
                    }
                }
            }
        }
        private ICollection<GET_TURNO> _gET_TURNO;
    
        public virtual ICollection<INF_INFODOC> INF_INFODOC
        {
            get
            {
                if (_iNF_INFODOC == null)
                {
                    var newCollection = new FixupCollection<INF_INFODOC>();
                    newCollection.CollectionChanged += FixupINF_INFODOC;
                    _iNF_INFODOC = newCollection;
                }
                return _iNF_INFODOC;
            }
            set
            {
                if (!ReferenceEquals(_iNF_INFODOC, value))
                {
                    var previousValue = _iNF_INFODOC as FixupCollection<INF_INFODOC>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupINF_INFODOC;
                    }
                    _iNF_INFODOC = value;
                    var newValue = value as FixupCollection<INF_INFODOC>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupINF_INFODOC;
                    }
                }
            }
        }
        private ICollection<INF_INFODOC> _iNF_INFODOC;
    
        public virtual ICollection<CAT_UPLOAD_LOG> CAT_UPLOAD_LOG
        {
            get
            {
                if (_cAT_UPLOAD_LOG == null)
                {
                    var newCollection = new FixupCollection<CAT_UPLOAD_LOG>();
                    newCollection.CollectionChanged += FixupCAT_UPLOAD_LOG;
                    _cAT_UPLOAD_LOG = newCollection;
                }
                return _cAT_UPLOAD_LOG;
            }
            set
            {
                if (!ReferenceEquals(_cAT_UPLOAD_LOG, value))
                {
                    var previousValue = _cAT_UPLOAD_LOG as FixupCollection<CAT_UPLOAD_LOG>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupCAT_UPLOAD_LOG;
                    }
                    _cAT_UPLOAD_LOG = value;
                    var newValue = value as FixupCollection<CAT_UPLOAD_LOG>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupCAT_UPLOAD_LOG;
                    }
                }
            }
        }
        private ICollection<CAT_UPLOAD_LOG> _cAT_UPLOAD_LOG;

        #endregion
        #region Association Fixup
    
        private void FixupAPP_USUARIO_ROL(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (APP_USUARIO_ROL item in e.NewItems)
                {
                    item.APP_USUARIO = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (APP_USUARIO_ROL item in e.OldItems)
                {
                    if (ReferenceEquals(item.APP_USUARIO, this))
                    {
                        item.APP_USUARIO = null;
                    }
                }
            }
        }
    
        private void FixupGET_TURNO(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (GET_TURNO item in e.NewItems)
                {
                    item.APP_USUARIO = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (GET_TURNO item in e.OldItems)
                {
                    if (ReferenceEquals(item.APP_USUARIO, this))
                    {
                        item.APP_USUARIO = null;
                    }
                }
            }
        }
    
        private void FixupINF_INFODOC(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (INF_INFODOC item in e.NewItems)
                {
                    item.APP_USUARIO = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (INF_INFODOC item in e.OldItems)
                {
                    if (ReferenceEquals(item.APP_USUARIO, this))
                    {
                        item.APP_USUARIO = null;
                    }
                }
            }
        }
    
        private void FixupCAT_UPLOAD_LOG(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (CAT_UPLOAD_LOG item in e.NewItems)
                {
                    item.APP_USUARIO = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CAT_UPLOAD_LOG item in e.OldItems)
                {
                    if (ReferenceEquals(item.APP_USUARIO, this))
                    {
                        item.APP_USUARIO = null;
                    }
                }
            }
        }

        #endregion
    }
}
