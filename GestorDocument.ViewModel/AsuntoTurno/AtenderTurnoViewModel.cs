using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using GestorDocument.Model;

namespace GestorDocument.ViewModel.AsuntoTurno
{
    public class AtenderTurnoViewModel :ViewModelBase
    {
        // Repository.
        private ITurno _TurnoRepository;
        private TrancingAsuntoTurnoViewModel _TrancingAsuntoTurnoViewModel;

        public TurnoModel Turno
        {
            get { return _Turno; }
            set
            {
                if (_Turno != value)
                {
                    _Turno = value;
                    OnPropertyChanged(TurnoPropertyName);
                }
            }
        }
        private TurnoModel _Turno;
        public const string TurnoPropertyName = "Turno";

        //boton de Guardar y Turnar.
        public RelayCommand SaveAtenderCommand
        {
            get
            {
                if (_SaveAtenderCommand == null)
                {
                    _SaveAtenderCommand = new RelayCommand(p => this.AttemptAtender(), p => this.CanAtender());
                }
                return _SaveAtenderCommand;
            }
        }
        private RelayCommand _SaveAtenderCommand;
        public bool CanAtender()
        {
            bool _CanSave = false;

            if (!String.IsNullOrEmpty(this.Turno.Respuesta))
            {
                _CanSave = true;
            }
            return _CanSave;
        }
        public void AttemptAtender()
        {
            //si turna cambia la bandera BanderaAtender para regresar a la pantalla anterior
            this._TrancingAsuntoTurnoViewModel.BanderaAtender =true;
            //REFERESCAR EL GRID
            this.GetAtender();
            this._TrancingAsuntoTurnoViewModel._ParentAsunto._PantallaInicioViewModel.LoadInfoGrid();

        }

        public AtenderTurnoViewModel( TrancingAsuntoTurnoViewModel trancingAsuntoTurnoViewModel)
        {
            this._TrancingAsuntoTurnoViewModel = trancingAsuntoTurnoViewModel;
            this._TurnoRepository = new GestorDocument.DAL.Repository.TurnoRepository();
            this.LoadInfoGrid();

        }

        public void LoadInfoGrid()
        {
            this.GetTurno();
        }

        public void GetTurno()
        {
            this.Turno = new TurnoModel()
            {
                IdTurnoAnt = this._TrancingAsuntoTurnoViewModel.Turno.IdTurnoAnt
                ,
                IdTurno = this._TrancingAsuntoTurnoViewModel.Turno.IdTurno
                ,
                FechaCreacion = this._TrancingAsuntoTurnoViewModel.Turno.FechaCreacion
                ,
                FechaEnvio = this._TrancingAsuntoTurnoViewModel.Turno.FechaEnvio
                ,
                IsActive = this._TrancingAsuntoTurnoViewModel.Turno.IsActive
                ,
                IdAsunto = this._TrancingAsuntoTurnoViewModel.Turno.IdAsunto
                ,
                IdStatusTurno = this._TrancingAsuntoTurnoViewModel.Turno.IdStatusTurno
                ,
                IdRol = this._TrancingAsuntoTurnoViewModel.Turno.IdRol
                ,
                IdUsuario = this._TrancingAsuntoTurnoViewModel.Turno.IdUsuario
                ,
                IsAtendido = this._TrancingAsuntoTurnoViewModel.Turno.IsAtendido
                ,
                IsTurnado = this._TrancingAsuntoTurnoViewModel.Turno.IsTurnado
                ,
                Comentario = this._TrancingAsuntoTurnoViewModel.Turno.Comentario
                ,
                Respuesta = this._TrancingAsuntoTurnoViewModel.Turno.Respuesta
            };
        }

        public void GetAtender()
        {
            this._TrancingAsuntoTurnoViewModel.GetSave();

            //guardar en la tabla de  GET_TURNO y cambia la bandera de isTurnado a true
            this.Turno.IsAtendido = true;
            this.Turno.FechaEnvio = DateTime.Now;
            this.Turno.IsBorrador = false;
            this.Turno.IdStatusTurno = 3;
            this._TurnoRepository.UpdateTurno(this.Turno);
        }
    }
}
