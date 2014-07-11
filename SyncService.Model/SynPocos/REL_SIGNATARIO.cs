using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class REL_SIGNATARIO
    {
        #region Primitive Properties

        public  long IdAsunto
        {
            get;
            set;
        }

        public  long IdDeterminante
        {
            get;
            set;
        }

        public  long IdSignatario
        {
            get;
            set;
        }

        public  Nullable<System.DateTime> Fecha
        {
            get;
            set;
        }

        public  bool IsActive
        {
            get;
            set;
        }

        public  bool IsModified
        {
            get;
            set;
        }

        public  long LastModifiedDate
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
