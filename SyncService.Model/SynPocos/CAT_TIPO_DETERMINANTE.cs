using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class CAT_TIPO_DETERMINANTE
    {
        #region Primitive Properties

        public  long IdTipoDeterminante
        {
            get;
            set;
        }

        public  string TipoDeterminanteName
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

        #endregion
    }
}
