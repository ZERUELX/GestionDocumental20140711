using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model
{
    public class TableroModel:ModelBase
    {
        public long IdTablero
        {
            get { return _IdTablero; }
            set
            {
                if (_IdTablero != value)
                {
                    _IdTablero = value;
                    OnPropertyChanged(IdTableroPropertyName);
                }
            }
        }
        private long _IdTablero;
        public const string IdTableroPropertyName = "IdTablero";

        public string Categoria
        {
            get { return _Categoria; }
            set
            {
                if (_Categoria != value)
                {
                    _Categoria = value;
                    OnPropertyChanged(CategoriaPropertyName);
                }
            }
        }
        private string _Categoria;
        public const string CategoriaPropertyName = "Categoria";

        public int Total
        {
            get { return _Total; }
            set
            {
                if (_Total != value)
                {
                    _Total = value;
                    OnPropertyChanged(TotalPropertyName);
                }
            }
        }
        private int _Total;
        public const string TotalPropertyName = "Total";
    }
}
