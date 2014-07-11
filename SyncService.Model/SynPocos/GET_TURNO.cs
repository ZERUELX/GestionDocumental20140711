using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class GET_TURNO
    {
        #region Primitive Properties

        public  long IdTurno
        {
            get;
            set;
        }

        public  Nullable<long> IdTurnoAnt
        {
            get;
            set;
        }

        public  System.DateTime FechaCreacion
        {
            get;
            set;
        }

        public  Nullable<System.DateTime> FechaEnvio
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

        public  long IdAsunto
        {
            get;
            set;
        }

        public  long IdStatusTurno
        {
            get;
            set;
        }

        public  Nullable<long> IdRol
        {
            get;
            set;
        }

        public  Nullable<long> IdUsuario
        {
            get;
            set;
        }

        public  string Comentario
        {
            get;
            set;
        }

        public  string Respuesta
        {
            get;
            set;
        }

        public  Nullable<long> ServerLastModifiedDate
        {
            get;
            set;
        }

        public  bool IsAtendido
        {
            get;
            set;
        }

        public  bool IsTurnado
        {
            get;
            set;
        }

        public  bool IsBorrador
        {
            get;
            set;
        }

        #endregion
    }
}
