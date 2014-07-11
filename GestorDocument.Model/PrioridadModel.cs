using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace GestorDocument.Model
{
    public class PrioridadModel : ModelBase
    {

        // **************************** **************************** ****************************

        public long IdPrioridad
        {
            get { return _IdPrioridad; }
            set
            {
                if (_IdPrioridad != value)
                {
                    _IdPrioridad = value;
                    OnPropertyChanged(IdPrioridadPropertyName);
                }
            }
        }
        private long _IdPrioridad;
        public const string IdPrioridadPropertyName = "IdPrioridad";

        // **************************** **************************** ****************************

        public string PrioridadName
        {
            get { return _PrioridadName; }
            set
            {
                if (_PrioridadName != value)
                {
                    _PrioridadName = value;
                    OnPropertyChanged(PrioridadNamePropertyName);
                }
            }
        }
        private string _PrioridadName;
        public const string PrioridadNamePropertyName = "PrioridadName";

        // **************************** **************************** ****************************

        public string PathImagen
        {
            get { return _PathImagen; }
            set
            {
                if (_PathImagen != value)
                {
                    _PathImagen = value;
                    OnPropertyChanged(PathImagenPropertyName);
                }
            }
        }
        private string _PathImagen;
        public const string PathImagenPropertyName = "PathImagen";

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
    }
}
