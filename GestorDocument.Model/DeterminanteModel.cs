using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace GestorDocument.Model
{
    public class DeterminanteModel : ModelBase
    {

        // **************************** **************************** ****************************

        public long IdDeterminante
        {
            get { return _IdDeterminante; }
            set
            {
                if (_IdDeterminante != value)
                {
                    _IdDeterminante = value;
                    OnPropertyChanged(IdDeterminantePropertyName);
                }
            }
        }
        private long _IdDeterminante;
        public const string IdDeterminantePropertyName = "IdDeterminante";

        // **************************** **************************** ****************************

        public int CveDeterminante
        {
            get { return _CveDeterminante; }
            set
            {
                if (_CveDeterminante != value)
                {
                    _CveDeterminante = value;
                    OnPropertyChanged(CveDeterminantePropertyName);
                }
            }
        }
        private int _CveDeterminante;
        public const string CveDeterminantePropertyName = "CveDeterminante";

        // **************************** **************************** ****************************

        public string Area
        {
            get { return _Area; }
            set
            {
                if (_Area != value)
                {
                    _Area = value;
                    OnPropertyChanged(AreaPropertyName);
                }
            }
        }
        private string _Area;
        public const string AreaPropertyName = "Area";

        // **************************** **************************** ****************************

        public string PrefijoFolio
        {
            get { return _PrefijoFolio; }
            set
            {
                if (_PrefijoFolio != value)
                {
                    _PrefijoFolio = value;
                    OnPropertyChanged(PrefijoFolioPropertyName);
                }
            }
        }
        private string _PrefijoFolio;
        public const string PrefijoFolioPropertyName = "PrefijoFolio";

        // **************************** **************************** ****************************

        public string DeterminanteName
        {
            get { return _DeterminanteName; }
            set
            {
                if (_DeterminanteName != value)
                {
                    _DeterminanteName = value;
                    OnPropertyChanged(DeterminanteNamePropertyName);
                }
            }
        }
        private string _DeterminanteName;
        public const string DeterminanteNamePropertyName = "DeterminanteName";

        // **************************** **************************** ****************************

        public bool IsActive
        {
            get { return _IsActive; }
            set
            {
                if (_IsActive != value)
                {
                    _IsActive = value;
                    OnPropertyChanged(IsActivePropertyName);
                }
            }
        }
        private bool _IsActive;
        public const string IsActivePropertyName = "IsActive";

        // **************************** **************************** ****************************

        public long LastModifiedDate
        {
            get { return _LastModifiedDate; }
            set
            {
                if (_LastModifiedDate != value)
                {
                    _LastModifiedDate = value;
                    OnPropertyChanged(LastModifiedDatePropertyName);
                }
            }
        }
        private long _LastModifiedDate;
        public const string LastModifiedDatePropertyName = "LastModifiedDate";

        // **************************** **************************** ****************************

        public bool IsModified
        {
            get { return _IsModified; }
            set
            {
                if (_IsModified != value)
                {
                    _IsModified = value;
                    OnPropertyChanged(IsModifiedPropertyName);
                }
            }
        }
        private bool _IsModified;
        public const string IsModifiedPropertyName = "IsModified";

        // **************************** **************************** ****************************

        public long IdTipoDeterminante
        {
            get { return _IdTipoDeterminante; }
            set
            {
                if (_IdTipoDeterminante != value)
                {
                    _IdTipoDeterminante = value;
                    OnPropertyChanged(IdTipoDeterminantePropertyName);
                }
            }
        }
        private long _IdTipoDeterminante;
        public const string IdTipoDeterminantePropertyName = "IdTipoDeterminante";

        // **************************** **************************** ****************************

        public long ServerLastModifiedDate
        {
            get { return _ServerLastModifiedDate; }
            set
            {
                if (_ServerLastModifiedDate != value)
                {
                    _ServerLastModifiedDate = value;
                    OnPropertyChanged(ServerLastModifiedDatePropertyName);
                }
            }
        }
        private long _ServerLastModifiedDate;
        public const string ServerLastModifiedDatePropertyName = "ServerLastModifiedDate";

        // **************************** **************************** ****************************

        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                if (_IsChecked != value)
                {
                    _IsChecked = value;
                    OnPropertyChanged(IsCheckedPropertyName);
                }
            }
        }
        private bool _IsChecked;
        public const string IsCheckedPropertyName = "IsChecked";

        // **************************** **************************** ****************************

        public bool IsCheckedDelete
        {
            get { return _IsCheckedDelete; }
            set
            {
                if (_IsCheckedDelete != value)
                {
                    _IsCheckedDelete = value;
                    OnPropertyChanged(IsCheckedDeletePropertyName);
                }
            }
        }
        private bool _IsCheckedDelete;
        public const string IsCheckedDeletePropertyName = "IsCheckedDelete";

        // **************************** **************************** ****************************

        public TipoDeterminanteModel TipoDeterminante
        {
            get { return _TipoDeterminante; }
            set
            {
                if (_TipoDeterminante != value)
                {
                    _TipoDeterminante = value;
                    OnPropertyChanged(TipoDeterminantePropertyName);
                }
            }
        }
        private TipoDeterminanteModel _TipoDeterminante;
        public const string TipoDeterminantePropertyName = "TipoDeterminante";

        // **************************** **************************** ****************************

    }
}
