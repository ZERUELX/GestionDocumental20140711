using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Objects;

namespace GestorDocument.Model.IRepository
{
    public interface IDocumentos
    {
        // Create.
        void InsertDocumentos(DocumentosModel documento);
        // Create.
        void InsertDocumentos(IEnumerable<DocumentosModel> documentos);

        // Read.
        IEnumerable<DocumentosModel> GetDocumentos();
        IEnumerable<DocumentosModel> GetDocumentos(long IdTurno);
        DocumentosModel GetDocumentosID(DocumentosModel documento);
        DocumentosModel GetDocumentosAdd(DocumentosModel documento);
        DocumentosModel GetDocumentosMod(DocumentosModel documento);

        // Update.
        void UpdateDocumentos(DocumentosModel documento);
        void UpdateDocumentos(IEnumerable<DocumentosModel> documentos);

        // Delete.
        void DeleteDocumentos(IEnumerable<DocumentosModel> documentos);
    }
}
