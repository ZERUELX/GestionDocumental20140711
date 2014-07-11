using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class APP_MENU
    {
        #region Primitive Properties

        public  long IdMenu
        {
            get;
            set;
        }

        public  Nullable<long> IdMenuParent
        {
            get;
            set;
        }

        public  string MenuName
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

        public  string PathMenu
        {
            get;
            set;
        }

        #endregion
    }
}
