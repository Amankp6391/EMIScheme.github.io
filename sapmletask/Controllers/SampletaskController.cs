using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using sapmletask.Controllers;
using sapmletask.Models;

namespace sapmletask.Controllers
{
    public class SampletaskController : Controller
    {
        DBLayer db = new DBLayer();
        // GET: Sampletask
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public ActionResult sam1()
        //{
        //    return View();
        //}
        public ActionResult master1()
        {
            return View();
        }
        [HttpPost]
            public ActionResult master1(FormCollection form)
        {
            string query = "insert into master1(plane_name,tenure,ROI,datetime)VALUES('" + form["plan"] + "','" + form["tenure"] + "','" + form["roi"] + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            if (db.InsertUpdateDelete(query))
                return Content("<script>alert('Data Save');location.href='/Sampletask/emi1'</script>");
            else
            {
                return Content("<script>alert('Data Not Saved');location.href='/Sampletask/master1'</script>");
            }
        }      
        public ActionResult emi1()
        {
            return View();
        }
        public JsonResult FetchData(string plan)
        {
            string query = "select * from master1 where plane_name='" + plan + "'";
            DataTable dt = db.GetAllRecord(query);
            string res1 = JsonConvert.SerializeObject(dt, Formatting.None);
            return Json(res1, JsonRequestBehavior.AllowGet);
        }
    }
}