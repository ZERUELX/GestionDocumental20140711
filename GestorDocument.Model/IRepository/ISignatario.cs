using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.Objects;

namespace GestorDocument.Model.IRepository
{
    public interface ISignatario
    {
        // Create.
        void InsertSignatario(IEnumerable<SignatarioModel> signatarios);

        // Read.
        IEnumerable<SignatarioModel> GetSignatarios();
        IEnumerable<SignatarioModel> GetSignatarios(long IdAsunto);
        SignatarioModel GetSignatarioID(SignatarioModel signatario);
        SignatarioModel GetSignatarioAdd(SignatarioModel signatario);
        SignatarioModel GetSignatarioMod(SignatarioModel signatario);

        // Update.
        void UpdateSignatario(IEnumerable<SignatarioModel> signatarios);

        // Delete.
        void DeleteSignatario(IEnumerable<SignatarioModel> signatarios);
    }
}
