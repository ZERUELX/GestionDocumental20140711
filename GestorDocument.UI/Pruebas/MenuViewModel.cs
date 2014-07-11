using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.UI.Pruebas
{
    public class MenuViewModel
    {
        public List<MenuMenuModel> GetDataMenu()
        {
            List<MenuMenuModel> listMenu = new List<MenuMenuModel>();
            listMenu.Add(new MenuMenuModel() { IdMenu = 1, MenuName = "Turnos", Path = "../Imagenes/Apps-Live-Messenger-alt-2-Metro-icon.png" });
            listMenu.Add(new MenuMenuModel() { IdMenu = 2, MenuName = "Nuevo Asunto", Path = "../Imagenes/Documents Folder.ico" });
            //listMenu.Add(new MenuMenuModel() { IdMenu = 2, MenuName = "Expedientes", Path="../Imagenes/Documents Folder.ico" });
            //listMenu.Add(new MenuMenuModel() { IdMenu = 3, MenuName = "Administración", Path = "../Imagenes/settings-icon.png" });
            //listMenu.Add(new MenuMenuModel() { IdMenu = 4, MenuName = "Reportes", Path = "../Imagenes/Folders-OS-Documents-Metro-icon.png" });
            if (listMenu.Count > 0)
                return listMenu;
            else
                return null;
        }
        public List<MenuModel> GetDataMenuCat()
        {
            List<MenuModel> listMenu = new List<MenuModel>();
            //listMenu.Add(new MenuModel() { ID = 11, Name = "ASUNTO" });
            listMenu.Add(new MenuModel() { ID = 22, Name = "DETERMINANTE" });
            listMenu.Add(new MenuModel() { ID = 33, Name = "DOCUMENTOS" });
            listMenu.Add(new MenuModel() { ID = 44, Name = "EXPEDIENTE" });
            listMenu.Add(new MenuModel() { ID = 55, Name = "FECHA VENCIMIENTO" });
            listMenu.Add(new MenuModel() { ID = 66, Name = "INSTRUCCION" });
            listMenu.Add(new MenuModel() { ID = 77, Name = "PRIORIDAD" });
            listMenu.Add(new MenuModel() { ID = 88, Name = "SIGNATARIO" });
            listMenu.Add(new MenuModel() { ID = 99, Name = "STATUS ASUNTO" });
            listMenu.Add(new MenuModel() { ID = 111, Name = "STATUS TURNO" });
            listMenu.Add(new MenuModel() { ID = 222, Name = "TIPO DETERMINANTE" });
            listMenu.Add(new MenuModel() { ID = 333, Name = "TIPO DOCUMENTO" });
            listMenu.Add(new MenuModel() { ID = 555, Name = "UBICACION" });
            listMenu.Add(new MenuModel() { ID = 444, Name = "TURNO" });
            
            if (listMenu.Count > 0)
                return listMenu;
            else
                return null;
        }
    }
}
