using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using intselva.Models;

namespace intselva.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        string connstr = "Data Source=WEB-SERVER\\SQLEXPRESS;Initial Catalog=Freshers;User ID=fresher;password=fresher";
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public string sss(string Name, DateTime Dob,string City, string Gender, Int32 Rating, Int16 Status)
        {
            using (con = new SqlConnection(connstr))
            {
                con.Open();
                con.CreateCommand();
                using (cmd = new SqlCommand("sp_selint", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Name", Name));
                    cmd.Parameters.Add(new SqlParameter("Dob", Dob));
                    cmd.Parameters.Add(new SqlParameter("City", City));
                    cmd.Parameters.Add(new SqlParameter("Gender", Gender));
                    cmd.Parameters.Add(new SqlParameter("Rating", Rating));
                    cmd.Parameters.Add(new SqlParameter("Status", Status));
                    cmd.ExecuteNonQuery();
                }
            }
            return "";
        }

        public string Update(Int32 Upid, string Upname, DateTime Updob, string Upcity, string Upgender, Int32 Uprating, Int16 Upstatus)
        {
            using (con = new SqlConnection(connstr))
            {
                con.Open();
                con.CreateCommand();
                using (cmd = new SqlCommand("sp_selintupdate", con))
                {                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Upid", Upid));
                    cmd.Parameters.Add(new SqlParameter("Upname", Upname));
                    cmd.Parameters.Add(new SqlParameter("Updob", Updob));
                    cmd.Parameters.Add(new SqlParameter("Upcity", Upcity));
                    cmd.Parameters.Add(new SqlParameter("Upgender",Upgender ));
                    cmd.Parameters.Add(new SqlParameter("Uprating", Uprating));
                    cmd.Parameters.Add(new SqlParameter("Upstatus", Upstatus));
                    cmd.ExecuteNonQuery();

                }
            }
            return "";
        }
        //public string Delete(Int16 Deleteid)
        //{
        //    using (con = new SqlConnection(connstr))
        //    {
        //        con.Open();
        //        con.CreateCommand();
        //        using (cmd = new SqlCommand("sp_selintdelete", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("Deleteid", Deleteid));
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    return "";
        //}

        public string Delete(Int16 Deleteid)
        {

            using (con = new SqlConnection(connstr))
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = new SqlCommand("sp_selintdelete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("Deleteid", Deleteid));                   
                    cmd.ExecuteNonQuery();
                }
            }
            return "";
        }

        public ActionResult main() 
        {
            List<Class1> lc = new List<Class1>();
            Class1 c;
            using (con = new SqlConnection(connstr))
            {
                con.Open();
                using (cmd = new SqlCommand("sp_selintgrid", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Searchtext", ""));
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        c = new Class1();
                        c.Id = Convert.ToInt32(dr["Id"]);
                        c.Name = Convert.ToString(dr["Name"]);
                        c.Dob = Convert.ToDateTime(dr["Dob"]);
                        c.City = Convert.ToString(dr["City"]);
                        c.Gender = Convert.ToString(dr["Gender"]);
                        c.Rating=Convert.ToInt16(dr["Rating"]);
                        c.Status=Convert.ToInt16(dr["Status"]);
                        lc.Add(c);


                    }
                    
                }
            }
            var rer = from d in lc
                      select new[]                    
                      
                      {d.Id.ToString(),
                      d.Name,d.Dob.ToString(),d.City, d.Gender.ToString(),d.Rating.ToString(),d.Status.ToString(),"<img class='edit' src='../../Scripts/icons/edit.png' style='width: 28px;'/>",
                      "<img class='dele' src='../../Scripts/icons/cancel.png'  />"
                      };
            return Json ( new
            {
            aaData = rer    
        
        },JsonRequestBehavior.AllowGet);
        }









        //public ActionResult main()
        //{
        //    jQueryDataTableParamModel dm = new jQueryDataTableParamModel();
        //    var gr = grid();
        //    var result = from d in gr
        //                 select new[]
        //    {
        //        d.Name,
        //        d.Dob.ToString(),
        //        d.Gender,
        //        d.Rating.ToString(),
        //        d.Status.ToString(),""
        //    };
        //    return Json (new
        //    {
            
        //        sEcho = dm.sEcho,
        //        iTotalLength = result,
        //        iTotalDisplayRecords = result,
        //        aaData = result} ,
        //JsonRequestBehavior.AllowGet
        //        );
           
        //}
        //public List<Class1> grid()
        //{
        //    List<Class1> lc = new List<Class1>();
        //    Class1 c = new Class1();

        //    using (con = new SqlConnection(connstr))
        //    {
        //        con.Open();
        //        con.CreateCommand();

        //        using (cmd = new SqlCommand("sp_selintgrid", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                c = new Class1();
        //                c.Name = Convert.ToString(dr["Name"]);
        //                c.Dob = Convert.ToDateTime(dr["Dob"]);
        //                c.Gender = Convert.ToString(dr["Gender"]);
        //                c.Rating = Convert.ToInt32(dr["Rating"]);
        //                c.Status = Convert.ToInt16(dr["Status"]);
        //                lc.Add(c);
                         

        //            }
        //            dr.Close();
        //        }
        //        return lc; 

        //    }
        //}

       

    }
}
