using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class APP_ROL
    {
        #region Primitive Properties

        public  long IdRol
        {
            get;
            set;
        }

        public  string RolName
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
