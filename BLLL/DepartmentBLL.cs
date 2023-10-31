using DALL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLL
{
    public class DepartmentBLL
    {
        DepartmentAccessDAL dp_access = new DepartmentAccessDAL();
        public string[] GetUserDP()
        {
            return dp_access.GetUserDP();
        }
    }
}
