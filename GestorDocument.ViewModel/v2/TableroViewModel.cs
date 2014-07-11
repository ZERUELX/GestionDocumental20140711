using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.DAL.Repository.v2;
using System.Collections.ObjectModel;
using GestorDocument.Model;

namespace GestorDocument.ViewModel.v2
{
    public class TableroViewModel:ViewModelBase
    {
        #region Constructor.
        public TableroViewModel()
        {
            Tablero = new List<TableroModel>();
        }

        public void Init(long IdRol)
        {
            this.IdRol = IdRol;
            GetTablero();
        }
        #endregion
        
        #region Propiedades.

        public long IdRol
        {
            get { return _IdRol; }
            set
            {
                if (_IdRol != value)
                {
                    _IdRol = value;
                    OnPropertyChanged(IdRolPropertyName);
                }
            }
        }
        private long _IdRol;
        public const string IdRolPropertyName = "IdRol";

        public List<TableroModel> Tablero
        {
            get { return _Tablero; }
            set
            {
                if (_Tablero != value)
                {
                    _Tablero = value;
                    OnPropertyChanged(TableroPropertyName);
                }
            }
        }
        private List<TableroModel> _Tablero;
        public const string TableroPropertyName = "Tablero";

        

        #region Categorias
       
        #endregion

        private void GetTablero()
        {
            using (var repository=new TableroRepository())
            {
                this.Tablero = repository.GetTablero(this.IdRol);              
            }
        }



        #endregion
    }
}
