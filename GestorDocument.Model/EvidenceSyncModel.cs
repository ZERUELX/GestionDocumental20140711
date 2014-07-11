using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorDocument.Model
{
    public class EvidenceSyncModel
    {
        public List<ListUnidsModel> ListIds
        {
            get;
            set;
        }

        public UploadLogModel DataUser
        {
            get;
            set;
        }
    }
}
