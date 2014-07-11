using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class CAT_INSTRUCCION
    {
        #region Primitive Properties

        public  long IdInstruccion
        {
            get;
            set;
        }

        public  int CveInstruccion
        {
            get;
            set;
        }

        public  string InstruccionName
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
