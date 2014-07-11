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

namespace SyncService.Server.DAL.POCOS
{
    public partial class REL_SIGNATARIO
    {
        #region Primitive Properties
    
        public virtual long IdAsunto
        {
            get { return _idAsunto; }
            set
            {
                if (_idAsunto != value)
                {
                    if (GET_ASUNTO != null && GET_ASUNTO.IdAsunto != value)
                    {
                        GET_ASUNTO = null;
                    }
                    _idAsunto = value;
                }
            }
        }
        private long _idAsunto;
    
        public virtual long IdDeterminante
        {
            get { return _idDeterminante; }
            set
            {
                if (_idDeterminante != value)
                {
                    if (CAT_DETERMINANTE != null && CAT_DETERMINANTE.IdDeterminante != value)
                    {
                        CAT_DETERMINANTE = null;
                    }
                    _idDeterminante = value;
                }
            }
        }
        private long _idDeterminante;
    
        public virtual long IdSignatario
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> Fecha
        {
            get;
            set;
        }
    
        public virtual bool IsActive
        {
            get;
            set;
        }
    
        public virtual bool IsModified
        {
            get;
            set;
        }
    
        public virtual long LastModifiedDate
        {
            get;
            set;
        }
    
        public virtual Nullable<long> ServerLastModifiedDate
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual CAT_DETERMINANTE CAT_DETERMINANTE
        {
            get { return _cAT_DETERMINANTE; }
            set
            {
                if (!ReferenceEquals(_cAT_DETERMINANTE, value))
                {
                    var previousValue = _cAT_DETERMINANTE;
                    _cAT_DETERMINANTE = value;
                    FixupCAT_DETERMINANTE(previousValue);
                }
            }
        }
        private CAT_DETERMINANTE _cAT_DETERMINANTE;
    
        public virtual GET_ASUNTO GET_ASUNTO
        {
            get { return _gET_ASUNTO; }
            set
            {
                if (!ReferenceEquals(_gET_ASUNTO, value))
                {
                    var previousValue = _gET_ASUNTO;
                    _gET_ASUNTO = value;
                    FixupGET_ASUNTO(previousValue);
                }
            }
        }
        private GET_ASUNTO _gET_ASUNTO;

        #endregion
        #region Association Fixup
    
        private void FixupCAT_DETERMINANTE(CAT_DETERMINANTE previousValue)
        {
            if (previousValue != null && previousValue.REL_SIGNATARIO.Contains(this))
            {
                previousValue.REL_SIGNATARIO.Remove(this);
            }
    
            if (CAT_DETERMINANTE != null)
            {
                if (!CAT_DETERMINANTE.REL_SIGNATARIO.Contains(this))
                {
                    CAT_DETERMINANTE.REL_SIGNATARIO.Add(this);
                }
                if (IdDeterminante != CAT_DETERMINANTE.IdDeterminante)
                {
                    IdDeterminante = CAT_DETERMINANTE.IdDeterminante;
                }
            }
        }
    
        private void FixupGET_ASUNTO(GET_ASUNTO previousValue)
        {
            if (previousValue != null && previousValue.REL_SIGNATARIO.Contains(this))
            {
                previousValue.REL_SIGNATARIO.Remove(this);
            }
    
            if (GET_ASUNTO != null)
            {
                if (!GET_ASUNTO.REL_SIGNATARIO.Contains(this))
                {
                    GET_ASUNTO.REL_SIGNATARIO.Add(this);
                }
                if (IdAsunto != GET_ASUNTO.IdAsunto)
                {
                    IdAsunto = GET_ASUNTO.IdAsunto;
                }
            }
        }

        #endregion
    }
}