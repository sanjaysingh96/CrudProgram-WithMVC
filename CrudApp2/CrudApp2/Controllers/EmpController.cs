using CrudApp2.DB_Connect;
using CrudApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudApp2.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(EmpModel empobj)
        {
            crud2Entities obj = new crud2Entities();
            client tbl = new client();
            tbl.id = empobj.id;
            tbl.name = empobj.name;
            tbl.email = empobj.email;
            tbl.city = empobj.city;
            tbl.salary = empobj.salary;

            if (empobj.id == 0)
            {
                obj.clients.Add(tbl);
                obj.SaveChanges();
            }
            else
            {
                obj.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
                obj.SaveChanges();
            }
           
            return RedirectToAction("Index","Home");
           // return View();
        }

        public ActionResult Edit(int id)
        {
            EmpModel empobj = new EmpModel();
            crud2Entities obj = new crud2Entities();
            var Edititem = obj.clients.Where(b => b.id == id).First();
            empobj.id = Edititem.id;
            empobj.name = Edititem.name;
            empobj.email = Edititem.email;
            empobj.city = Edititem.city;
            empobj.salary = Edititem.salary;
            ViewBag.id = Edititem.id;

            return View("Index",empobj);
        }

        public ActionResult Delete(int id)
        {
            crud2Entities obj = new crud2Entities();
            var deleteitem = obj.clients.Where(b => b.id == id).First();
            obj.clients.Remove(deleteitem);
            obj.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}