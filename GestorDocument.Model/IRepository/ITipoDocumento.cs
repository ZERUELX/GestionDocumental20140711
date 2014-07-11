using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Objects;

namespace GestorDocument.Model.IRepository
{
    public interface ITipoDocumento
    {
        // Create.
        void InsertTipoDocumento(TipoDocumentoModel tipodocumento);

        // Read.
        IEnumerable<TipoDocumentoModel> GetTipoDocumentos();
        TipoDocumentoModel GetTipoDocumentoID(TipoDocumentoModel tipodocumento);
        TipoDocumentoModel GetTipoDocumentoAdd(TipoDocumentoModel tipodocumento);
        TipoDocumentoModel GetTipoDocumentoMod(TipoDocumentoModel tipodocumento);

        // Update.
        void UpdateTipoDocumento(TipoDocumentoModel tipodocumento);

        // Delete.
        void DeleteTipoDocumento(IEnumerable<TipoDocumentoModel> tipodocumentos);
    }
}
