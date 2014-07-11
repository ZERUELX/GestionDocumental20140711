using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model.IRepository;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository
{
    public class MenuRepository : IMenu
    {
        public IEnumerable<Model.MenuModel> GetMenu()
        {
            ObservableCollection<Model.MenuModel> menu = new ObservableCollection<Model.MenuModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.APP_MENU
                     join rm in entity.APP_ROL_MENU
                     on o.IdMenu equals rm.IdMenu
                     join r in entity.APP_ROL
                     on rm.IdRol equals r.IdRol
                     where o.IsActive ==true
                     select o).ToList().ForEach(p =>
                     {
                         menu.Add(new Model.MenuModel()
                         {
                             IdMenu = p.IdMenu,
                             IdMenuParent = p.IdMenuParent,
                             MenuName = p.MenuName,
                             IsActive = p.IsActive,
                             IsModified = p.IsModified,
                             LastModifiedDate = p.LastModifiedDate,
                             ServerLastModifiedDate = p.ServerLastModifiedDate
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return menu;
        }

        public IEnumerable<Model.MenuModel> GetMenu(long IdRol)
        {
            ObservableCollection<Model.MenuModel> menu = new ObservableCollection<Model.MenuModel>();
            using (var entity = new GestorDocumentEntities())
            {
                try
                {
                    (from o in entity.APP_MENU
                     join rm in entity.APP_ROL_MENU
                     on o.IdMenu equals rm.IdMenu
                     join r in entity.APP_ROL
                     on rm.IdRol equals r.IdRol
                     where rm.IsActive == true && r.IdRol ==IdRol
                     select o).ToList().ForEach(p =>
                     {
                         menu.Add(new Model.MenuModel()
                         {
                             IdMenu = p.IdMenu,
                             IdMenuParent = p.IdMenuParent,
                             MenuName = p.MenuName,
                             IsActive = p.IsActive,
                             IsModified = p.IsModified,
                             LastModifiedDate = p.LastModifiedDate,
                             ServerLastModifiedDate = p.ServerLastModifiedDate,
                             PathMenu = p.PathMenu
                         });
                     });
                }
                catch (Exception)
                {
                    ;
                }
            }
            return menu;
        }
    }
}
