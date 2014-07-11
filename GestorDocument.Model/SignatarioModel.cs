using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace GestorDocument.Model
{
    public class SignatarioModel : ModelBase
    {

        // **************************** **************************** ****************************

        public long IdSignatario
        {
            get { return _IdSignatario; }
            set
            {
                if (_IdSignatario != value)
                {
                    _IdSignatario = value;
                    OnPropertyChanged(IdSignatarioPropertyName);
                }
            }
        }
        private long _IdSignatario;
        public const string IdSignatarioPropertyName = "IdSignatario";

        // **************************** **************************** ****************************

        public long IdAsunto
        {
            get { return _IdAsunto; }
            set
            {
                if (_IdAsunto != value)
                {
                    _IdAsunto = value;
                    OnPropertyChanged(IdAsuntoPropertyName);
                }
            }
        }
        private long _IdAsunto;
        public const string IdAsuntoPropertyName = "IdAsunto";

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

        public Nullable<DateTime> Fecha
        {
            get { return _Fecha; }
            set
            {
                if (_Fecha != value)
                {
                    _Fecha = value;
                    OnPropertyChanged(FechaPropertyName);
                }
            }
        }
        private Nullable<DateTime> _Fecha;
        public const string FechaPropertyName = "Fecha";

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

        public Nullable<long> ServerLastModifiedDate
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
        private Nullable<long> _ServerLastModifiedDate;
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

        public AsuntoModel Asunto
        {
            get { return _Asunto; }
            set
            {
                if (_Asunto != value)
                {
                    _Asunto = value;
                    OnPropertyChanged(AsuntoPropertyName);
                }
            }
        }
        private AsuntoModel _Asunto;
        public const string AsuntoPropertyName = "Asunto";

        // **************************** **************************** ****************************

        public DeterminanteModel Determinante
        {
            get { return _Determinante; }
            set
            {
                if (_Determinante != value)
                {
                    _Determinante = value;
                    OnPropertyChanged(DeterminantePropertyName);
                }
            }
        }
        private DeterminanteModel _Determinante;
        public const string DeterminantePropertyName = "Determinante";

        // **************************** **************************** ****************************
    }
}
