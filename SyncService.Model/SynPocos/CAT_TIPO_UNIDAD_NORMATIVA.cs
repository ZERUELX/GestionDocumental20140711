using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class CAT_TIPO_UNIDAD_NORMATIVA
    {
        #region Primitive Properties

        public  long IdTipoUnidadNormativa
        {
            get;
            set;
        }

        public  string TipoUnidadNormativaName
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

        public  Nullable<bool> ServerLastModifiedDate
        {
            get;
            set;
        }

        #endregion
    }
}
