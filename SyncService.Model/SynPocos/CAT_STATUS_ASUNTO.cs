using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class CAT_STATUS_ASUNTO
    {
        #region Primitive Properties

        public  long IdStatusAsunto
        {
            get;
            set;
        }

        public  string StatusName
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

        public  long ServerLastModifiedDate
        {
            get;
            set;
        }

        #endregion
    }
}
