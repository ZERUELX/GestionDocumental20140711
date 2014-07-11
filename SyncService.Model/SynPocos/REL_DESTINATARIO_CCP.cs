using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class REL_DESTINATARIO_CCP
    {
        #region Primitive Properties

        public  long IdDestinatarioCcp
        {
            get;
            set;
        }

        public  long IdRol
        {
            get;
            set;
        }

        public  long IdAsunto
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

        public  Nullable<long> ServerLastModifiedDate
        {
            get;
            set;
        }

        #endregion
    }
}
