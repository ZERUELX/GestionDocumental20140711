using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Objects;

namespace GestorDocument.Model.IRepository
{
    public interface IUbicacion
    {
        // Create.
        void InsertUbicacion(UbicacionModel ubicacion);

        // Read.
        IEnumerable<UbicacionModel> GetUbicacions();
        UbicacionModel GetUbicacionID(UbicacionModel ubicacion);
        UbicacionModel GetUbicacionAdd(UbicacionModel ubicacion);
        UbicacionModel GetUbicacionMod(UbicacionModel ubicacion);

        // Update.
        void UpdateUbicacion(UbicacionModel ubicacion);

        // Delete.
        void DeleteUbicacion(IEnumerable<UbicacionModel> ubicacions);
    }
}
