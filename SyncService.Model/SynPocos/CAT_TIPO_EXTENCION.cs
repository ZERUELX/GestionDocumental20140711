using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class CAT_TIPO_EXTENCION
    {
        #region Primitive Properties

        public  long IdTipoExtencion
        {
            get;
            set;
        }

        public  string Extencion
        {
            get;
            set;
        }

        public  string Path
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

        public Nullable<long> ServerLastModifiedDate
        {
            get;
            set;
        }

        #endregion
    }
}
