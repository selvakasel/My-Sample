using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using robert.Models;
using System.Data;


namespace robert.Controllers
{
    public class HomeController : Controller
    {
        string connstr = "Data Source=WEB-SERVER\\SQLEXPRESS;Initial Catalog=Freshers;User ID=fresher;password=fresher";
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;


        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Welcome() 
        {
            return View();
}

        public ActionResult log(string USERNAME, string PASSWORD)
        {
            Class1 c = new Class1();
            c.Username = USERNAME;
            c.Password = PASSWORD;
            Service1 s3 = new Service1();

            if (s3.login(USERNAME, PASSWORD) == "success")
                return JavaScript("window.location.href='../Home/Welcome';");

            else
                return JavaScript("alert('Wrong username,password');");
        }        

     

        public string Save(string Name,DateTime DOB,string Gender,int Age,string City,string Username,string Password)
        {
            Class1 c = new Class1();
            c.Name = Convert.ToString(Name);
            c.Dob = Convert.ToDateTime(DOB);
            c.Gender = Convert.ToString(Gender);
            c.Age = Convert.ToInt16(Age);
            c.city = Convert.ToString(City);
            c.Username = Convert.ToString(Username);
            c.Password = Convert.ToString(Password);
            Service1 s = new Service1();
            return s.Save(c);         


        }

        public string Update(Int32 Id,string Name, DateTime DOB, string Gender, int Age, string City, string Username, string Password) 
        {
            Class1 c = new Class1();
            c.ID = Convert.ToInt32(Id);
            c.Name = Convert.ToString(Name);
            c.Dob = Convert.ToDateTime(DOB);
            c.Gender = Convert.ToString(Gender);
            c.Age = Convert.ToInt16(Age);
            c.city = Convert.ToString(City);
            c.Username = Convert.ToString(Username);
            c.Password = Convert.ToString(Password);
            Service1 s = new Service1();
            return s.Update(c);


        }
        public string Delete(Int32 Id)
        {
            Class1 c = new Class1();
            c.ID = Convert.ToInt32(Id);           
            Service1 s = new Service1();
            return s.Delete(c);


        }

        public ActionResult Table()
        {
            
            List<Class1> c2 = new List<Class1>();
            Class1 c;
            using (con = new SqlConnection(connstr))
            {
                con.Open();
                con.CreateCommand();
                using (cmd = new SqlCommand("Sp_roberttable", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Searchtext", ""));

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        c = new Class1();
                        c.ID = Convert.ToInt32(dr["Id"]);
                        c.Name = Convert.ToString(dr["Name"]);
                        c.Dob = Convert.ToDateTime(dr["Dob"]);
                        c.Gender = Convert.ToString(dr["Gender"]);
                        c.Age = Convert.ToInt16(dr["Age"]);
                        c.city = Convert.ToString(dr["city"]);
                        c.Username = Convert.ToString(dr["Username"]);
                        c.Password = Convert.ToString(dr["Password"]);
                        c2.Add(c);

                    }
                }

            }
            var rer = from jj in c2
                      select new[] {
                          jj.ID.ToString(),
              jj.Name.ToString(),
            jj.Dob.ToString(),
            jj.Gender.ToString(),
            jj.Age.ToString(),
            jj.city.ToString(),jj.Username,jj.Password
            
            };
            return Json(new
            {
                aaData = rer
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
