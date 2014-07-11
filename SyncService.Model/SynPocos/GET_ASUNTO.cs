using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class GET_ASUNTO
    {
        #region Primitive Properties

        public  long IdAsunto
        {
            get;
            set;
        }

        public  Nullable<System.DateTime> FechaCreacion
        {
            get;
            set;
        }

        public  Nullable<System.DateTime> FechaRecibido
        {
            get;
            set;
        }

        public  Nullable<System.DateTime> FechaDocumento
        {
            get;
            set;
        }

        public  string ReferenciaDocumento
        {
            get;
            set;
        }

        public  string Titulo
        {
            get;
            set;
        }

        public  string Descripcion
        {
            get;
            set;
        }

        public  string Alcance
        {
            get;
            set;
        }

        public  Nullable<long> IdUbicacion
        {
            get;
            set;
        }

        public  Nullable<long> IdInstruccion
        {
            get;
            set;
        }

        public  Nullable<long> IdPrioridad
        {
            get;
            set;
        }

        public  Nullable<long> IdStatusAsunto
        {
            get;
            set;
        }

        public  System.DateTime FechaVencimiento
        {
            get;
            set;
        }

        public  string Folio
        {
            get;
            set;
        }

        public  Nullable<long> ServerLastModifiedDate
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

        public  Nullable<System.DateTime> FechaAtendido
        {
            get;
            set;
        }

        public  string Ubicacion
        {
            get;
            set;
        }

        public  bool IsBorrador
        {
            get;
            set;
        }

        public  string Contacto
        {
            get;
            set;
        }

        public  string Anexos
        {
            get;
            set;
        }

        #endregion
    }
}
