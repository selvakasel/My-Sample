using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace robert.Models
{   

    public class Dal
    {
        SqlConnection con =  new SqlConnection("Data Source=WEB-SERVER\\SQLEXPRESS;Initial Catalog=Freshers;User ID=fresher;password=fresher");
      //  SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        public string Save(Class1 c)
        {

           
                con.Open();
                con.CreateCommand();
                using (cmd = new SqlCommand("sp_robertsave", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Name", c.Name));
                    cmd.Parameters.Add(new SqlParameter("@DOB", c.Dob));
                    cmd.Parameters.Add(new SqlParameter("@Gender", c.Gender));
                    cmd.Parameters.Add(new SqlParameter("@Age", c.Age));
                    cmd.Parameters.Add(new SqlParameter("@City", c.city));
                    cmd.Parameters.Add(new SqlParameter("@Username", c.Username));
                    cmd.Parameters.Add(new SqlParameter("@Password", c.Password));
                    cmd.ExecuteNonQuery();
                    return "";
                }
            
        }

        public string Update(Class1 c) 
        {


            con.Open();
            con.CreateCommand();
            using (cmd = new SqlCommand("sp_robertupdate", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", c.ID));
                cmd.Parameters.Add(new SqlParameter("@Name", c.Name));
                cmd.Parameters.Add(new SqlParameter("@DOB", c.Dob));
                cmd.Parameters.Add(new SqlParameter("@Gender", c.Gender));
                cmd.Parameters.Add(new SqlParameter("@Age", c.Age));
                cmd.Parameters.Add(new SqlParameter("@City", c.city));
                cmd.Parameters.Add(new SqlParameter("@Username", c.Username));
                cmd.Parameters.Add(new SqlParameter("@Password", c.Password));
                cmd.ExecuteNonQuery();
                return "";
            }

        }

        public string Delete(Class1 c)
        {


            con.Open();
            con.CreateCommand();
            using (cmd = new SqlCommand("sp_robertdelete", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", c.ID));
                cmd.ExecuteNonQuery();
                return "";
            }

        }

        public string login(string USERNAME, string PASSWORD) 
        {
            string flag = "";
            Class1 re = new Class1();
           
            SqlDataReader dr;

            re.Username = USERNAME;
            re.Password = PASSWORD;

            con.Open();
            con.CreateCommand();
            {
                using (cmd = new SqlCommand("Sp_robertlog", con))

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("User", USERNAME));
                cmd.Parameters.Add(new SqlParameter("Pass", PASSWORD));
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if (Convert.ToString(dr["Username"]) == USERNAME && Convert.ToString(dr["Password"]) == PASSWORD)
                    {
                        flag = "success";
                        break;

                    }
                    else flag = "Failed";

                }
                return flag;
            }


        }

    }
}