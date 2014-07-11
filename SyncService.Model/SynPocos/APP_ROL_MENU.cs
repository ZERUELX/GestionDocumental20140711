using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class APP_ROL_MENU
    {
        #region Primitive Properties

        public  long IdRol
        {
            get;
            set;
        }

        public  long IdMenu
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

        public  long IdRolMenu
        {
            get;
            set;
        }

        #endregion
    }
}
