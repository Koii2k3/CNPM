using DALL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLLL
{


    public class ProjectBLL
    {
        ProjectAccessDAL pj_access = new ProjectAccessDAL();

        public bool ValidateDeadline(DateTime start, DateTime end, DateTime exp)
        {

            TimeSpan s_e = end - start;
            TimeSpan ex_e = end - exp;
            TimeSpan ex_s = exp - start;

            int start_end = s_e.Days;
            int exp_end = ex_e.Days;
            int exp_start = ex_s.Days;

            if (start_end <= 0 || exp_end <= 0 || exp_start <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public DataTable SearchProject(string desc)
        {
            return pj_access.SearchProject(desc);
        }

        public DataTable SearchProjectU(string pk_u, string pj_desc)
        {
            return pj_access.SearchProjectU(pk_u, pj_desc);
        }

        public bool InsertPJ(string name, string desc, DateTime? exp, DateTime? start, DateTime? end, string ver, string isPublic, string pk)
        {
            if (isPublic == "Public")
            {
                isPublic = "1";
            }
            else
            {
                isPublic = "0";
            }
            return pj_access.InsertPJ(name, desc, exp, start, end, ver, isPublic, pk);
        }

        public bool DelMemberFromProject(string u_pk, string pj_id)
        {
            return pj_access.DelMemberFromProject(u_pk, pj_id);
        }

        public DataTable GetProjectInfoAllOfMan(string pk)
        {
            return pj_access.GetProjectInfoAllOfMan(pk);
        }

        public bool AddMember2Project(string u_id, string u_email, string pj_id)
        {
            return pj_access.AddMember2Project(u_id, u_email, pj_id);
        }

        public DataTable GetUserOfProject(string pj_id)
        {
            return pj_access.GetUserOfProject(pj_id);
        }

        public bool UpdateProject(string pj_id, string pj_name, string desc, DateTime? exp, DateTime? start, DateTime? end, string ver, string isPublic, string u_pk)
        {
            if (isPublic == "Public")
            {
                isPublic = "1";
            }
            else
            {
                isPublic = "0";
            }
            return pj_access.UpdateProject(pj_id, pj_name, desc, exp, start, end, ver, isPublic, u_pk);
        }

        // fuction to get all project of user 

        public DataTable getProjectOfUser(string pk)
        {
            return pj_access.getProjectOfUser(pk);
        }

    }
}
