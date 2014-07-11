using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SyncService.Repository
{
    class SyncRepository
    {
        static BroadCastRepository _BroadCast = new BroadCastRepository();
        static ReciverRepository _Receiver = new ReciverRepository();
        public static bool DownUplo()
        {
            bool x = false;
            try
            {
                
                //_BroadCast.CallModifiedData(); //Descargas
                //_Receiver.CallService();//Subidas                                
                x = true;
                
            }
            catch (Exception ex)
            {

               // ex.Message;
            }
            return x;
        }
    }
}
