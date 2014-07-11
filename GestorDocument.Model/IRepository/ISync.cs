using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace GestorDocument.Model.IRepository
{
    public interface ISync
    {
        void UpdateSyncLocal(string nameTable, ObjectContext context);
    }
}
