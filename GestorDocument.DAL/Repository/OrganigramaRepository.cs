using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class OrganigramaRepository : IOrganigrama
    {
        public void InsertOrganigrama(Model.OrganigramaModel organigrama)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene el organigrama.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.OrganigramaModel> GetOrganigrama()
        {
            ObservableCollection<Model.OrganigramaModel> organigrama = new ObservableCollection<Model.OrganigramaModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.CAT_ORGANIGRAMA
                     where o.IsActive
                     //where o.IdJerarquiaParent ==null && o.IsActive == true
                     select o).OrderBy(o => o.JerarquiaName).ToList().ForEach(p =>
                     {
                         organigrama.Add(new Model.OrganigramaModel()
                         {
                             IdJerarquia = p.IdJerarquia,
                             IdJerarquiaParent = p.IdJerarquiaParent,
                             IdRol = p.IdRol,
                             JerarquiaName = p.JerarquiaName,
                             IsActive = p.IsActive,
                             IsModified = p.IsModified,
                             LastModifiedDate = p.LastModifiedDate,
                             ServerLastModifiedDate = p.ServerLastModifiedDate,
                             JerarquiaTitular = p.JerarquiaTitular
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return organigrama;
        }

        public IEnumerable<Model.OrganigramaModel> GetOrganigrama(long IdTurno)
        {
            ObservableCollection<Model.OrganigramaModel> organigrama = new ObservableCollection<Model.OrganigramaModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from t in entity.GET_TURNO
                     join r in entity.REL_DESTINATARIO
                     on t.IdTurno equals r.IdTurno
                     join o in entity.CAT_ORGANIGRAMA
                     on r.IdRol equals o.IdRol
                     where t.IdTurno == IdTurno && o.IsActive == true
                     select o).ToList().ForEach(p =>
                     {
                         organigrama.Add(new Model.OrganigramaModel()
                         {
                             IdJerarquia = p.IdJerarquia,
                             IdJerarquiaParent = p.IdJerarquiaParent,
                             IdRol = p.IdRol,
                             JerarquiaName = p.JerarquiaName,
                             IsActive = p.IsActive,
                             IsModified = p.IsModified,
                             LastModifiedDate = p.LastModifiedDate,
                             ServerLastModifiedDate = p.ServerLastModifiedDate,
                             JerarquiaTitular = p.JerarquiaTitular
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return organigrama;
        }

        public IEnumerable<Model.OrganigramaModel> GetOrganigrama(Model.RolModel rol)
        {
            ObservableCollection<Model.OrganigramaModel> organigrama = new ObservableCollection<Model.OrganigramaModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.CAT_ORGANIGRAMA
                     where o.IsActive
                     where o.IdRol !=rol.IdRol
                     select o).ToList().ForEach(p =>
                     {
                         organigrama.Add(new Model.OrganigramaModel()
                         {
                             IdJerarquia = p.IdJerarquia,
                             IdJerarquiaParent = p.IdJerarquiaParent,
                             IdRol = p.IdRol,
                             JerarquiaName = p.JerarquiaName,
                             IsActive = p.IsActive,
                             IsModified = p.IsModified,
                             LastModifiedDate = p.LastModifiedDate,
                             ServerLastModifiedDate = p.ServerLastModifiedDate,
                             JerarquiaTitular = p.JerarquiaTitular
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return organigrama;
        }

        public IEnumerable<Model.OrganigramaModel> GetOrganigramaParent(Model.OrganigramaModel organigrama)
        {
            ObservableCollection<Model.OrganigramaModel> organigramaParent = new ObservableCollection<Model.OrganigramaModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.CAT_ORGANIGRAMA
                     where o.IdJerarquiaParent == organigrama.IdJerarquia &&
                           o.IsActive
                     select o).ToList().ForEach(p =>
                     {
                         organigramaParent.Add(new Model.OrganigramaModel()
                         {
                             IdJerarquia = p.IdJerarquia,
                             IdJerarquiaParent = p.IdJerarquiaParent,
                             IdRol = p.IdRol,
                             JerarquiaName = p.JerarquiaName,
                             IsActive = p.IsActive,
                             IsModified = p.IsModified,
                             LastModifiedDate = p.LastModifiedDate,
                             ServerLastModifiedDate = p.ServerLastModifiedDate,
                             JerarquiaTitular = p.JerarquiaTitular
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return organigramaParent;
        }

        public IEnumerable<Model.OrganigramaModel> GetOrganigramaFather(Model.OrganigramaModel organigrama)
        {
            ObservableCollection<Model.OrganigramaModel> organigramaParent = new ObservableCollection<Model.OrganigramaModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {   
                    (from o in entity.CAT_ORGANIGRAMA
                     where o.IdJerarquia == organigrama.IdJerarquia
                     select o).ToList().ForEach(p =>
                     {
                         organigramaParent.Add(new Model.OrganigramaModel()
                         {
                             IdJerarquia = p.IdJerarquia,
                             IdJerarquiaParent = p.IdJerarquiaParent,
                             IdRol = p.IdRol,
                             JerarquiaName = p.JerarquiaName,
                             IsActive = p.IsActive,
                             IsModified = p.IsModified,
                             LastModifiedDate = p.LastModifiedDate,
                             ServerLastModifiedDate = p.ServerLastModifiedDate,
                             JerarquiaTitular = p.JerarquiaTitular
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return organigramaParent;
        }

        public Model.OrganigramaModel GetOrganigramaID(Model.OrganigramaModel organigrama)
        {
            Model.OrganigramaModel org = new Model.OrganigramaModel();

            using (var entity = new GestorDocumentEntities())
            {
                CAT_ORGANIGRAMA result = null;
                try
                {
                    result = (from o in entity.CAT_ORGANIGRAMA
                              where o.IdJerarquia == organigrama.IdJerarquia && o.IsActive == true
                              select o).First();
                }
                catch (Exception)
                {
                    ;
                }
                if (result != null)
                {
                    org.IdJerarquia = result.IdJerarquia;
                    org.IdJerarquiaParent = result.IdJerarquiaParent;
                    org.IdRol = result.IdRol;
                    org.JerarquiaName = result.JerarquiaName;
                    org.IsActive = result.IsActive;
                    org.IsModified = result.IsModified;
                    org.LastModifiedDate = result.LastModifiedDate;
                    org.ServerLastModifiedDate = result.ServerLastModifiedDate;
                    org.JerarquiaTitular = result.JerarquiaTitular;
                }
            }
            return org;
        }

        public Model.OrganigramaModel GetOrganigramaID()
        {
            Model.OrganigramaModel organigrama = new Model.OrganigramaModel();

            using (var entity = new GestorDocumentEntities())
            {
                CAT_ORGANIGRAMA result = null;
                try
                {
                    result = (from o in entity.CAT_ORGANIGRAMA
                              where o.IdJerarquiaParent == null && o.IsActive == true
                              select o).First();
                }
                catch (Exception)
                {
                    ;
                }
                if (result != null)
                {
                    organigrama.IdJerarquia = result.IdJerarquia;
                    organigrama.IdJerarquiaParent = result.IdJerarquiaParent;
                    organigrama.IdRol = result.IdRol;
                    organigrama.JerarquiaName = result.JerarquiaName;
                    organigrama.IsActive = result.IsActive;
                    organigrama.IsModified = result.IsModified;
                    organigrama.LastModifiedDate = result.LastModifiedDate;
                    organigrama.ServerLastModifiedDate = result.ServerLastModifiedDate;
                    organigrama.JerarquiaTitular = result.JerarquiaTitular;
                }
            }
            return organigrama;
        }

        public Model.OrganigramaModel GetOrganigramaAdd(Model.OrganigramaModel organigrama)
        {
            throw new NotImplementedException();
        }

        public Model.OrganigramaModel GetOrganigramaMod(Model.OrganigramaModel organigrama)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrganigrama(Model.OrganigramaModel organigrama)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrganigrama(IEnumerable<Model.OrganigramaModel> organigrama)
        {
            throw new NotImplementedException();
        }

    }
}
