using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class ReportesRepository:IReportes
    {

        #region Metodos.
        public IEnumerable<Model.RolModel> GetDestinatarios()
        {
            ObservableCollection<Model.RolModel> filtroDestinatarios = new ObservableCollection<Model.RolModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from r in entity.APP_ROL
                     where r.IdRol != 10
                     select r).OrderBy(o => o.RolName).ToList().ForEach(row =>
                         {
                             Model.RolModel r = new Model.RolModel()
                             {
                                 IdRol = row.IdRol,
                                 RolName = row.RolName,
                                 IsActive = false
                             };
                             filtroDestinatarios.Add(r);
                             
                         });
                }
                catch (Exception)
                {
                    filtroDestinatarios = null;
                }
                return filtroDestinatarios;
            }
        }

        public IEnumerable<Model.DeterminanteModel> GetSignatarios()
        {
            ObservableCollection<Model.DeterminanteModel> filtroSignatarios = new ObservableCollection<Model.DeterminanteModel>();
            try
            {
                using (var entity = new GestorDocumentEntities())
                {
                    (from d in entity.CAT_DETERMINANTE
                     select d).OrderBy(o=> o.DeterminanteName).ToList().ForEach(row =>
                     {
                         Model.DeterminanteModel d = new Model.DeterminanteModel()
                         {
                             IdDeterminante = row.IdDeterminante,
                             DeterminanteName = row.DeterminanteName,
                             IsActive = false
                         };
                         filtroSignatarios.Add(d);
                        
                     });
                }
            }
            catch (Exception)
            {

                filtroSignatarios = null;
            }
            return filtroSignatarios;
        }

        public IEnumerable<Model.StatusTurnoModel> GetTurnos()
        {
            ObservableCollection<Model.StatusTurnoModel> filtroTurnos = new ObservableCollection<Model.StatusTurnoModel>();
            try
            {
                Model.StatusTurnoModel t = null;                
                t = new Model.StatusTurnoModel() { StatusName = "Si", IsActive = true };
                filtroTurnos.Add(t);
                t = new Model.StatusTurnoModel() { StatusName = "No", IsActive = true };
                filtroTurnos.Add(t);
                
            }
            catch (Exception)
            {
                ;
            }
            return filtroTurnos;
        }

        public IEnumerable<Model.PrioridadModel> GetPrioridad()
        {
            ObservableCollection<Model.PrioridadModel> filtroPrioridad = new ObservableCollection<Model.PrioridadModel>(); 
            try
            {
                using (var entity = new GestorDocumentEntities())
                {
                    (from p in entity.CAT_PRIORIDAD
                     select p).OrderBy(o=> o.PrioridadName).ToList().ForEach(row =>
                         {
                             Model.PrioridadModel p = new Model.PrioridadModel()
                            {
                                IdPrioridad = row.IdPrioridad,
                                PrioridadName = row.PrioridadName,
                                IsActive = false
                            };
                             filtroPrioridad.Add(p);                             
                         });
                }
            }
            catch (Exception)
            {


            }
            return filtroPrioridad;
        } 
        #endregion

    }
}
