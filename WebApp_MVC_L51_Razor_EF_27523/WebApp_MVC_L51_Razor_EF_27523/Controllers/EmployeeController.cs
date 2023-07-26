using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_MVC_L51_Razor_EF_27523.Models;

namespace WebApp_MVC_L51_Razor_EF_27523.Controllers
{
    public class EmployeeController : Controller
    {
        DatabaseContext _db = new DatabaseContext();
        // koi bhi action 2 tarah se call hota hai.. ya httpget or httppost par but by default har action htttpget pe call hota hai.

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.emp = _db.tblEmployees.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblEmployee obj)
        {
            _db.tblEmployees.Add(obj);
            _db.SaveChanges();
            //return View();
            return RedirectToAction("Create");
        }

        //public void Insert(tblEmployee obj)
        //{
        //    _db.tblEmployees.Add(obj);
        //    _db.SaveChanges();
        //}
    }
}