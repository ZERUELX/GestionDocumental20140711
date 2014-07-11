using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.IRepository
{
    public interface IListUnids
    {
        List<ListUnidsModel> GetDeserializeListUnids(string listUnids);
        string GetSerializeListUnids(List<ListUnidsModel> unids);
    }
}
