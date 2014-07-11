using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.IRepository
{
    public interface IMenu
    {
        // Read.
        IEnumerable<MenuModel> GetMenu();
        IEnumerable<MenuModel> GetMenu(long IdRol);
    }
}
