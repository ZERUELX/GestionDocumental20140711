using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class APP_USUARIO_ROL
    {
        #region Primitive Properties

        public  long IdUsuario
        {
            get;
            set;
        }

        public  long IdRol
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

        public  long IdUsuarioRol
        {
            get;
            set;
        }

        #endregion
    }
}
