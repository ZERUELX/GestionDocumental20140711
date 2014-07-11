using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.IRepository
{
    public interface ISignatarioExterno
    {
        // Create.
        void InsertSignatarioExterno(IEnumerable<SignatarioExternoModel> signatariosExternos);

        // Read.
        IEnumerable<SignatarioExternoModel> GetSignatariosExterno();
        IEnumerable<SignatarioExternoModel> GetSignatariosExterno(long IdAsunto);
        SignatarioExternoModel GetSignatarioExternoID(SignatarioExternoModel signatariosExterno);
        SignatarioExternoModel GetSignatarioExternoAdd(SignatarioExternoModel signatariosExterno);
        SignatarioExternoModel GetSignatarioExternoMod(SignatarioExternoModel signatariosExterno);

        // Update.
        void UpdateSignatarioExterno(IEnumerable<SignatarioExternoModel> signatariosExternos);

        // Delete.
        void DeleteSignatarioExterno(IEnumerable<SignatarioExternoModel> signatariosExternos);
    }
}
