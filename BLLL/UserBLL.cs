using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOO;
using DALL;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Security.Policy;

namespace BLL
{
    public class UserBLL
    {

        /*
         BLL layer is to implement and manage the business rules and processes of the application.It focuses on
        the core functionality and operations that define the behavior and logic of the application
         - This is where the data manipulation requirements of the GUI layer are met, processing the data source from the
        Presentation Layer before transmitting it to the Data Access Layer (UserDAL) and saving it to the database management system.
         - This is also the place to check constraints, data integrity and validity, perform calculations and process business 
        requirements, before returning results to the Presentation Layer.
        */

        UserAccessDAL user_access = new UserAccessDAL();

        public DataTable GetUserOutTask(String jID)
        {
            return user_access.GetUserOutTask(jID);
        }

        public DataTable GetUserOutProject(String pjID)
        {
            return user_access.GetUserOutProject(pjID);
        }

        public bool insertUser(string vt_name, string username, DateTime birthdate, string address, string cccd, byte[] image, string email, string gender, string dp, string lv, string phone)
        {
            if (user_access.insertUser(vt_name, username, birthdate, address, cccd, image, email, gender, dp, lv, phone))
            {
                string[] id_pass = user_access.GetAccountByEmail(email);
                string id = id_pass[0];
                string pass = id_pass[1];
                string message = String.Format("Your USER ID: {0}\nYour PASSWORD: {1}", id, pass);
                string title = "Your SK account have just been created";
                return user_access.verifyEmail(email, title, message);
            }
            else
            {
                return false;
            }
        }


        public DataRow getUserInfo(string id)
        {
            return user_access.getUserInfo(id);
        }

        public DataTable getUserInfoAll()
        {
            return user_access.getUserInfoAll();
        }

        public DataTable GetUserByLevel(int lv)
        {
            return user_access.GetUserByLevel(lv);
        }

        public bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9_%+-]+@[a-zA-Z0-9-]+\.[a-zA-Z]{2,}$";

            if (string.IsNullOrEmpty(email))
                return false;

            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }

        public bool loginCheck(string user_login, string password)
        {
            if (user_access.loginCheck(user_login, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateUserInfo(string pk, string u_name, DateTime bd, string cccd, string addr, string gd, string email, string vt_name, string u_pass, string lv_name, string dp_name, string u_phone, byte[] img)
        {
            return user_access.UpdateUserInfo(pk, u_name, bd, cccd, addr, gd, email, vt_name, u_pass, lv_name, dp_name, u_phone, img);
        }

        public string[] GetAccountByEmail(string email)
        {
            return user_access.GetAccountByEmail(email);
        }

        public bool verifyEmail(string to_email, string title, string m)
        {
            return user_access.verifyEmail(to_email, title, m);
        }

        public DataTable GetAllProjectOfUser(string u_id)
        {
            return user_access.GetAllProjectOfUser(u_id);
        }

        // function to add request
        public int addRequest(string req, string s_id, string r_id)
        {
            return user_access.addRequest(req, s_id, r_id);
        }

        // function to check exist request

        public DataRow checkRequest(string r_id)
        {
            return user_access.checkRequest(r_id);
        }

        // function to update status of req

        public int updateRequest(string s_id)
        {
            return user_access.updateRequest(s_id);
        }

        // function to update password

        public int updatePassword(string s_id, string s_password)
        {
            return user_access.updatePassword(s_id, s_password);
        }

        // function to check if user with the input cccd and email is existed

        public string checkForgot(string cccd, string email)
        {
            return user_access.checkForGot(cccd, email);
        }

        // function to add OTP when forgot password

        public int addOTP(string id, string OTP)
        {
            return user_access.addOTP(id, OTP);
        }

        // function to check if OTP is valid

        public int checkOTP(string id, string otp)
        {
            return user_access.checkOTP(id, otp);
        }

        // function to disable or enable user

        public int disableUser(string id, int flag)
        {
            return user_access.disableUser(id, flag);
        }


        // function to get the info of disable user
        public DataTable getUserInfoDis()
        {
            return user_access.getUserInfoDis();
        }

        // function to get user info from search

        public DataTable getUserFromSearch(string description)
        {
            return user_access.getUserFromSearch(description);
        }


    }
}
