using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_MVC_L55_VALIDN_EF_28523.Models;

namespace WebApp_MVC_L55_VALIDN_EF_28523.Controllers
{
    public class RegistrationController : Controller
    {

        DatabaseContext _db = new DatabaseContext();


        // [HttpGet]// route config// page load
        //public ActionResult Create(int empid = 0)
        //{
        //    //ViewBag.BT = "Save";
        //    tblEmployee obj = new tblEmployee();
        //    //if (empid > 0)
        //    //{
        //    //    var record = (from a in _db.tblEmployees where a.empid == empid select a).ToList();
        //    //    obj.empid = record[0].empid;
        //    //    obj.name = record[0].name;
        //    //    obj.city = record[0].city;
        //    //    obj.age = record[0].age;
        //    //    obj.country = record[0].country;
        //    //    obj.state = record[0].state;
        //    //    ViewBag.BT = "Update";
        //    //}
        //    //ViewBag.empdata = (from a in _db.tblEmployees select a).ToList();
        //    //ViewBag.ctr = _db.tblCountries.ToList();
        //    //ViewBag.stt = (from a in _db.tblStates where a.cid == obj.country select a).ToList();
        //    //ViewBag.empdata = _db.tblEmployees.ToList();


        //    //ViewBag.empdata = (from a in _db.tblEmployees
        //    //                   join b in _db.tblCountries on a.country equals b.cid
        //    //                   join c in _db.tblStates on a.state equals c.sid
        //    //                   select new { a.empid, a.name, a.city, a.age, b.cname, c.sname }).ToList();

        //    //obj.lstemp = (from a in _db.tblEmployees
        //    //              join b in _db.tblCountries on a.country equals b.cid
        //    //              join c in _db.tblStates on a.state equals c.sid
        //    //              select new Join
        //    //              {
        //    //                  empid = a.empid,
        //    //                  name = a.name,
        //    //                  city = a.city,
        //    //                  age = a.age,
        //    //                  cname = b.cname,
        //    //                  sname = c.sname
        //    //              }).ToList();
        //    //return View(obj);
        //}

        [HttpPost]// submit button
        public ActionResult Create(tblRegistration _reg)
        {

            if (ModelState.IsValid)
            {
                _db.tblRegistrations.Add(_reg);
                _db.SaveChanges();
                return RedirectToAction("Create"); 
            }
            else
            {
                return View();
            }
            if (_reg.rid > 0)// unreachable code
            {
                _db.Entry(_reg).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        [HttpGet]// page load
        public ActionResult Create(int rid=0)
        {
            tblRegistration _reg = new tblRegistration();
            ViewBag.TB = "Save";
            if (rid>0)
            {
                var data = (from a in _db.tblRegistrations where a.rid == rid select a).ToList();
                _reg.rid = data[0].rid;
                _reg.name = data[0].name;
                _reg.email = data[0].email;
                _reg.password = data[0].password;
                _reg.age = data[0].age;
                ViewBag.TB = "Update";
            }
            ViewBag.regdata = (from a in _db.tblRegistrations select a).ToList();
            return View(_reg);
        }

       
        public ActionResult Del(int rid=0)
        {
            var data = _db.tblRegistrations.Find(rid);
            _db.tblRegistrations.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("Create");
        }
    }
}