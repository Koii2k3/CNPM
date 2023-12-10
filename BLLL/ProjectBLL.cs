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

        /*
         * BLL layer is to implement and manage the business rules and processes of the application.It focuses on
        the core functionality and operations that define the behavior and logic of the application
         - This is where the data manipulation requirements of the GUI layer are met, processing the data source from the
        Presentation Layer before transmitting it to the Data Access Layer (ProjectDAL) and saving it to the database management system.
         - This is also the place to check constraints, data integrity and validity, perform calculations and process business 
        requirements, before returning results to the Presentation Layer.
        */


        ProjectAccessDAL pj_access = new ProjectAccessDAL();

        public DataRow GetProject(string pjID)
        {
            return pj_access.GetProject(pjID);
        }

        public DataRow GetProjectProgress(string pjID)
        {
            return pj_access.GetProjectProgress(pjID);
        }


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

        public DataTable GetAllProject()
        {
            return pj_access.GetAllProject();
        }

        public DataTable GetTaskPerUser(String pjID)
        {
            return pj_access.GetTaskPerUser(pjID);
        }

        public DataTable GetStateJobsInProject(String pjID)
        {
            return pj_access.GetStateJobsInProject(pjID);
        }

        public int GetNumTaskOfProject(String pjID)
        {
            return pj_access.GetNumTaskOfProject(pjID);
        }

        public DataRow GetRemainTimePJ(string pjID)
        {
            return pj_access.GetRemainTimePJ(pjID);
        }

        public DataRow GetUpdatedProgressPJ(string pjID)
        {
            return pj_access.GetUpdatedProgressPJ(pjID);
        }
    }
}
