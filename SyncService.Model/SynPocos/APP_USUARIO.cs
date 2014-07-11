using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class APP_USUARIO
    {
        #region Primitive Properties

        public  long IdUsuario
        {
            get;
            set;
        }

        public  string UsuarioCorreo
        {
            get;
            set;
        }

        public  string UsuarioPwd
        {
            get;
            set;
        }

        public  string Nombre
        {
            get;
            set;
        }

        public  string Apellido
        {
            get;
            set;
        }

        public  string Area
        {
            get;
            set;
        }

        public  string Puesto
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

        public  bool IsNuevoUsuario
        {
            get;
            set;
        }

        public  bool IsActivado
        {
            get;
            set;
        }

        public  Nullable<bool> IsFlag
        {
            get;
            set;
        }

        public  Nullable<bool> IsFlagPass
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
