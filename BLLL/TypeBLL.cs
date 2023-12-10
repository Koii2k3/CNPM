using DALL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLL
{
    public class TypeBLL
    {
        /*
         * BLL layer is to implement and manage the business rules and processes of the application.It focuses on
        the core functionality and operations that define the behavior and logic of the application
         - This is where the data manipulation requirements of the GUI layer are met, processing the data source from the
        Presentation Layer before transmitting it to the Data Access Layer (TypeDAL) and saving it to the database management system.
         - This is also the place to check constraints, data integrity and validity, perform calculations and process business 
        requirements, before returning results to the Presentation Layer.
        */


        TypeAccessDAL type_access = new TypeAccessDAL();
        public string[] getUserType()
        {
            return type_access.getUserType();
        }
    }
}
