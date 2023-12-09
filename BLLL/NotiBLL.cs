using DALL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLL
{
    public class NotiBLL
    {
        NotiAccessDAL notiAccess = new NotiAccessDAL();

        public bool AddNoti(string notiDesc, String fromID, List<String> toIDs)
        {
            String notiID = notiAccess.AddNoti(notiDesc, fromID);
            if (notiID != "-1")
            {
                foreach (String toID in toIDs)
                {
                    if (!notiAccess.AddReceiverToNoti(notiID, toID))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetNotiOfReceiver(String receiverID)
        {
            return notiAccess.GetNotiOfReceiver(receiverID);
        }

        public DataTable GetNotiOfSender(String senderID)
        {
            return notiAccess.GetNotiOfSender(senderID);
        }

        public bool UpdateNotiRead(string notiID, string receiverID)
        {
            return notiAccess.UpdateNotiRead(notiID, receiverID);
        }

        public string GetNumNewNoti(string receiverId)
        {
            return notiAccess.GetNumNewNoti(receiverId);
        }
        public DataTable GetReceiverOfNoti(string notiID)
        {
            return notiAccess.GetReceiverOfNoti(notiID);
        }
    }

}
