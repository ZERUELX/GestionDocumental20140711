using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDocument.Model;
using System.Collections.ObjectModel;

namespace GestorDocument.DAL.Repository.v2
{
    public class MenuRepository:IDisposable
    {
        public ObservableCollection<MenuModel> GetMenu(long IdRol)
        {
            ObservableCollection<MenuModel> items = new ObservableCollection<MenuModel>();
            try
            {
                using (var entity=new GestorDocumentEntities())
                {
                    (from o in entity.spGetMenu(IdRol)
                     
                     select o).ToList().ForEach(p =>
                     {
                         items.Add(new Model.MenuModel()
                         {
                             IdMenu = p.IdMenu,
                             IdMenuParent = p.IdMenuParent,
                             MenuName = p.MenuName,                             
                             PathMenu = p.PathMenu,
                             CountBorrador=p.Count
                         });
                     });
                }
            }
            catch (Exception ex)
            {
                                
            }

            return items;
        }

        public void Dispose()
        {
            return;
        }
    }
}
