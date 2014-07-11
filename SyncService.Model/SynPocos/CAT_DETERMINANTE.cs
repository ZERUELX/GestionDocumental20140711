using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Model.SynPocos
{
    public class CAT_DETERMINANTE
    {
        #region Primitive Properties

        public  long IdDeterminante
        {
            get;
            set;
        }

        public  int CveDeterminante
        {
            get;
            set;
        }

        public  string Area
        {
            get;
            set;
        }

        public  string PrefijoFolio
        {
            get;
            set;
        }

        public  string DeterminanteName
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

        public  long IdTipoDeterminante
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
