using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class GET_DOCUMENTOS
    {
        #region Primitive Properties

        public  long IdDocumento
        {
            get;
            set;
        }

        public  string DocumentoName
        {
            get;
            set;
        }

        public  string DocumentoPath
        {
            get;
            set;
        }

        public  string Extencion
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

        public  Nullable<long> IdTurno
        {
            get;
            set;
        }

        public  Nullable<System.DateTime> Fecha
        {
            get;
            set;
        }

        public  long IdExpediente
        {
            get;
            set;
        }

        public  long IdTipoDocumento
        {
            get;
            set;
        }

        public  Nullable<bool> IsDocumentoOriginal
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
