using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class REL_DESTINATARIO
    {
        #region Primitive Properties

        public  long IdRol
        {
            get;
            set;
        }

        public  long IdTurno
        {
            get;
            set;
        }

        public  long IdDestinatario
        {
            get;
            set;
        }

        public  bool IsPrincipal
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
