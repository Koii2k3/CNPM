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

        /*
         * BLL layer is to implement and manage the business rules and processes of the application.It focuses on
        the core functionality and operations that define the behavior and logic of the application
         - This is where the data manipulation requirements of the GUI layer are met, processing the data source from the
        Presentation Layer before transmitting it to the Data Access Layer (RequestDAL) and saving it to the database management system.
         - This is also the place to check constraints, data integrity and validity, perform calculations and process business 
        requirements, before returning results to the Presentation Layer.
        */

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
