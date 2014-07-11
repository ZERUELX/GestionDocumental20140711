using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model.IRepository
{
    public interface ISyncDocs 
    {
        // Create.
        void InsertSyncDoc(SyncDocsModel syncDoc);
        void InsertSyncDocs(IEnumerable<SyncDocsModel> syncDocs);

        IEnumerable<SyncDocsModel> GetSyncDocs();

        // Update.
        void UpdateSyncDoc(SyncDocsModel syncDoc);
        void UpdateSyncDocs(IEnumerable<SyncDocsModel> syncDocs);
    }
}
