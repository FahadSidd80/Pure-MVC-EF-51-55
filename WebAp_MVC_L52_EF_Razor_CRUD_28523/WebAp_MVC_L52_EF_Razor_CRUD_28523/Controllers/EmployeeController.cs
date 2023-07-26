using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAp_MVC_L52_EF_Razor_CRUD_28523.Models;

namespace WebAp_MVC_L52_EF_Razor_CRUD_28523.Controllers
{
    public class EmployeeController : Controller
    {
        DatabaseContext _db = new DatabaseContext();
       

        [HttpPost]//but jab submit button press karenge to submit button kahega controller se aisa ction lao jo post pe call hota ho
        public ActionResult Create(tblEmployee obj)
        {
            if (obj.empid > 0)
            {
                _db.Entry(obj).State= System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _db.tblEmployees.Add(obj);
            }
            _db.SaveChanges();
            //return View();
            return RedirectToAction("Create");
        }

        //page load
        [HttpGet]// jab debug karenge to route.config kahega create naam ka aisa action lao jo get pe call hota ho
        public ActionResult Create(int empid=0)// page load kyo debug karte hi kya call hota hai ye create action to ye page load hai aur yahi pe get ka code kar denge
        {
            ViewBag.btn = "Save";
            tblEmployee _emp = new tblEmployee();
            if (empid > 0)
            {
                var record = (from a in _db.tblEmployees where a.empid == empid select a).ToList();
                _emp.empid = record[0].empid;
                _emp.name = record[0].name;
                _emp.city = record[0].city;
                _emp.age = record[0].age;
                ViewBag.btn = "Update";
            }
            // display code/action/view
            ViewBag.emptbldata = _db.tblEmployees.ToList();// ab tblEMployees ab view pe use karna hai aur usko ek MVC me predifine container hai ViewBag hai 
            return View(_emp);
        }

        public ActionResult Del(int empid=0)// Del action is by default call on httpget
        {
            var data = _db.tblEmployees.Find(empid);
            _db.tblEmployees.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("Create");
        }


        public ActionResult Edt(int empid)// Del action is by default call on httpget
        {
            _db.tblEmployees.Find(empid);
            _db.SaveChanges();
            return RedirectToAction("Create");
        }
        //public ActionResult Del(int empid)// Del action is by default call on httpget
        //{
        //    var data = (from a in _db.tblEmployees where a.empid == empid select a).ToList();
        //    _db.tblEmployees.Remove(data);
        //    _db.SaveChanges();
        //    return View();
        //}

        //public ActionResult Del(tblEmployee obj)
        //{
        //    var data = _db.tblEmployees.Find(obj.empidj);
        //    _db.tblEmployees.Remove(data);
        //    _db.SaveChanges();
        //    return RedirectToAction("Create");
        //}
    }
}