using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.IRepository
{
    public interface IOrganigrama
    {
        // Create.
        void InsertOrganigrama(OrganigramaModel organigrama);

        // Read.
        IEnumerable<OrganigramaModel> GetOrganigrama();
        IEnumerable<OrganigramaModel> GetOrganigrama(long IdTurno);
        IEnumerable<OrganigramaModel> GetOrganigrama(RolModel rol);
        IEnumerable<OrganigramaModel> GetOrganigramaParent(OrganigramaModel organigrama);
        IEnumerable<OrganigramaModel> GetOrganigramaFather(OrganigramaModel organigrama);
        OrganigramaModel GetOrganigramaID(OrganigramaModel organigrama);
        OrganigramaModel GetOrganigramaID();
        OrganigramaModel GetOrganigramaAdd(OrganigramaModel organigrama);
        OrganigramaModel GetOrganigramaMod(OrganigramaModel organigrama);

        // Update.
        void UpdateOrganigrama(OrganigramaModel organigrama);

        // Delete.
        void DeleteOrganigrama(IEnumerable<OrganigramaModel> organigrama);
    }
}
