using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class CAT_PRIORIDAD
    {
        #region Primitive Properties

        public  long IdPrioridad
        {
            get;
            set;
        }

        public  string PrioridadName
        {
            get;
            set;
        }

        public  string PathImagen
        {
            get;
            set;
        }

        public  bool IsActive
        {
            get;
            set;
        }

        public  long LastModifiedDate
        {
            get;
            set;
        }

        public  bool IsModified
        {
            get;
            set;
        }

        public  long ServerLastModifiedDate
        {
            get;
            set;
        }

        #endregion
    }
}
