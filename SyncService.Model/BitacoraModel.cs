using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model
{
    public class BitacoraModel
    {
        //private string _clase = "";

        //public string Clase
        //{
        //    get { return _clase; }
        //    set { _clase = value; }
        //}
        private string _descripcion = "";

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private bool _estatus = false;

        public bool Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
    }
}
