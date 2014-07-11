using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.v2
{
    public class AsuntosDataGridModel 
    {

        //public Nullable<DateTime> FechaCreacion
        //{
        //    get;
        //    set;
        //}
        //public Nullable<DateTime> FechaDocumento
        //{
        //    get;
        //    set;
        //}
        //public string Descripcion
        //{
        //    get;
        //    set;
        //}
        //public string Alcance
        //{
        //    get;
        //    set;
        //}
        //public Nullable<long> IdUbicacion
        //{
        //    get;
        //    set;
        //}
        //public Nullable<long> IdInstruccion
        //{
        //    get;
        //    set;
        //}
        //public string ReferenciaDocumento
        //{
        //    get;
        //    set;
        //}
        //public UbicacionModel Ubicacion
        //{
        //    get;
        //    set;
        //}
        //public InstruccionModel Instruccion
        //{
        //    get;
        //    set;
        //}
        //public PrioridadModel Prioridad
        //{
        //    get;
        //    set;
        //}
        //public Nullable<long> IdPrioridad
        //{
        //    get;
        //    set;
        //}
        //public Nullable<long> IdStatusAsunto
        //{
        //    get;
        //    set;
        //}
        //public StatusAsuntoModel StatusAsunto
        //{
        //    get;
        //    set;
        //}
        //public Nullable<DateTime> FechaAtendido
        //{
        //    get;
        //    set;
        //}
        //public string UbicacionText
        //{
        //    get;
        //    set;
        //}
        //public bool IsBorrador
        //{
        //    get;
        //    set;
        //}
        //public string Contacto
        //{
        //    get;
        //    set;
        //}
       
        //public string Anexos
        //{
        //    get;
        //    set;
        //}
        //public TurnoModel Turno
        //{
        //    get;
        //    set;
        //}
        //public bool IsActive
        //{
        //    get;
        //    set;
        //}
        //public ExpedienteModel Expediente
        //{
        //    get;
        //    set;
        //}
        //public IEnumerable<SignatarioModel> Signatario
        //{
        //    get;
        //    set;
        //}
        //public IEnumerable<SignatarioExternoModel> SignatarioExterno
        //{
        //    get;
        //    set;
        //}
      
        //public const string BusquedaPropertyName = "Busqueda";

        public long IdAsunto
        {
            get;
            set;
        }

        public string PrioridadName
        {
            get;
            set;
        }

        public string PathImagen
        {
            get;
            set;
        }

        public string Titulo
        {
            get;
            set;
        }

        public string Folio
        {
            get;
            set;
        }

        public string Signatarios
        {
            get;
            set;
        }

        public string Destinatarios
        {
            get;
            set;
        }

        public string Respuesta
        {
            get;
            set;
        }

        public Nullable<System.DateTime> FechaRecibido
        {
            get;
            set;
        }

        public System.DateTime FechaVencimiento
        {
            get;
            set;
        }


    }
}
