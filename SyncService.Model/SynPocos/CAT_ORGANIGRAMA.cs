using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class CAT_ORGANIGRAMA
    {
        #region Primitive Properties

        public  long IdJerarquia
        {
            get;
            set;
        }

        public  Nullable<long> IdJerarquiaParent
        {
            get;
            set;
        }

        public  string JerarquiaName
        {
            get;
            set;
        }

        public  Nullable<bool> IsActive
        {
            get;
            set;
        }

        public  Nullable<long> LastModifiedDate
        {
            get;
            set;
        }

        public  Nullable<bool> IsModified
        {
            get;
            set;
        }

        public  long IdRol
        {
            get;
            set;
        }

        public  Nullable<long> ServerLastModifiedDate
        {
            get;
            set;
        }

        public  Nullable<long> IdTipoUnidadNormativa
        {
            get;
            set;
        }

        public  string JerarquiaTitular
        {
            get;
            set;
        }

        #endregion
    }
}
