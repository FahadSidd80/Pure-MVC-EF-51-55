using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_MVC_L55_VALIDN_EF_28523.Models;

namespace WebApp_MVC_L55_VALIDN_EF_28523.Controllers
{
    public class EmployeeController : Controller
    {


        DatabaseContext _db = new DatabaseContext();


        [HttpGet]// route config// page load
        public ActionResult Create(int empid = 0)
        {
            ViewBag.BT = "Save";
            tblEmployee obj = new tblEmployee();
            if (empid > 0)
            {
                var record = (from a in _db.tblEmployees where a.empid == empid select a).ToList();
                obj.empid = record[0].empid;
                obj.name = record[0].name;
                obj.city = record[0].city;
                obj.age = record[0].age;
                obj.country = record[0].country;
                obj.state = record[0].state;
                ViewBag.BT = "Update";
            }
            //ViewBag.empdata = (from a in _db.tblEmployees select a).ToList();
            ViewBag.ctr = _db.tblCountries.ToList();
            ViewBag.stt = (from a in _db.tblStates where a.cid == obj.country select a).ToList();
            //ViewBag.empdata = _db.tblEmployees.ToList();


            //ViewBag.empdata = (from a in _db.tblEmployees
            //                   join b in _db.tblCountries on a.country equals b.cid
            //                   join c in _db.tblStates on a.state equals c.sid
            //                   select new { a.empid, a.name, a.city, a.age, b.cname, c.sname }).ToList();

            obj.lstemp = (from a in _db.tblEmployees
                          join b in _db.tblCountries on a.country equals b.cid
                          join c in _db.tblStates on a.state equals c.sid
                          select new Join
                          {
                              empid = a.empid,
                              name = a.name,
                              city = a.city,
                              age = a.age,
                              cname = b.cname,
                              sname = c.sname
                          }).ToList();
            return View(obj);
        }

        [HttpPost]// submit button
        public ActionResult Create(tblEmployee obj)
        {
            if (obj.empid > 0)
            {
                _db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _db.tblEmployees.Add(obj);
            }
            _db.SaveChanges();
            //return View();
            return RedirectToAction("Create");
        }

        public ActionResult Del(tblEmployee obj)
        {
            var data = _db.tblEmployees.Find(obj.empid);
            _db.tblEmployees.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("Create");
        }

        public JsonResult GetStateByCountry(int cid)
        {
            var data = (from a in _db.tblStates where a.cid == cid select a).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}