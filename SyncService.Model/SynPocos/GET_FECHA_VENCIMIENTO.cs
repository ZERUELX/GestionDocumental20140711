using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class GET_FECHA_VENCIMIENTO
    {
        #region Primitive Properties

        public  long IdFechaVencimiento
        {
            get;
            set;
        }

        public  long IdAsunto
        {
            get;
            set;
        }

        public  System.DateTime FechaVencimiento
        {
            get;
            set;
        }

        public  System.DateTime FechaCreacion
        {
            get;
            set;
        }

        public  bool IsActual
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

        public  long ServerLastModifiedDate
        {
            get;
            set;
        }

        #endregion
    }
}
