using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class GET_EXPEDIENTE
    {
        #region Primitive Properties

        public  long IdExpediente
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

        public  Nullable<long> IdAsunto
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
