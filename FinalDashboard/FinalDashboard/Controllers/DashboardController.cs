using FinalDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Collections;

namespace FinalDashboard.Controllers
{
    public class DashboardController : Controller
    {
        private TestDBEntities db = new TestDBEntities();
        private string connectionString;

        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Users = db.students.Count();
            return View();
        }


        public JsonResult DashBoardcount()
        {
            try
            {
                string[] DashBoardcount = new string[2];

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(gender) as male ,(select count(gender) from student where gender='female') as female from student where gender= 'male' ", con);
                DataTable dt = new DataTable();
                SqlDataAdapter cmd1 = new SqlDataAdapter(cmd);
                cmd1.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    DashBoardcount[0] = "0";
                    DashBoardcount[0] = "0";
                }
                else
                {
                    DashBoardcount[0] = dt.Rows[0]["male"].ToString();
                    DashBoardcount[1] = dt.Rows[0]["female"].ToString();
                }
                return Json(new { DashBoardcount }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}

   

   