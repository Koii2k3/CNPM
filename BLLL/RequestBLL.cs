using DALL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLL
{
    public class RequestBLL
    {
        RequestAccessDAL req_access = new RequestAccessDAL();

        public bool AddRequest(string subject, string content, string pk_sender, string pk_receiver, List<string> filenames)
        {
            string id_req = req_access.AddRequestPhase1(subject, content, pk_sender, pk_receiver);
            if (id_req != "-1")
            {
                if (filenames.Count > 0) // Request without attaching any file
                {
                    foreach (var file in filenames)
                    {
                        FileStream fstream = File.OpenRead(file);
                        byte[] contents = new byte[fstream.Length];
                        fstream.Read(contents, 0, (int)fstream.Length);
                        fstream.Read(contents, 0, (int)fstream.Length);
                        fstream.Close();
                        string file_name = System.IO.Path.GetFileName(file);
                        req_access.AddRequestPhase2(id_req, file_name, contents);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable GetRequestReceiver(string pk_receiver)
        {
            return req_access.GetRequestReceiver(pk_receiver);
        }

        public DataTable GetFileFromRequest(string req_id)
        {
            return req_access.GetFileFromRequest(req_id);
        }

        public void UpdateRequestStatus(string pk_sender, string pk_receiver, string status)
        {
            req_access.UpdateRequestStatus(pk_sender, pk_receiver, status);
        }

        public DataTable GetMyRequest(string pk_sender)
        {
            return req_access.GetMyRequest(pk_sender);
        }
    }
}
