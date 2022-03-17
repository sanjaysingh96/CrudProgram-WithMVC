using CrudApp2.DB_Connect;
using CrudApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudApp2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            crud2Entities obj = new crud2Entities();
            List<EmpModel> empobj = new List<EmpModel>();
            var res = obj.clients.ToList();
            foreach (var item in res)
            {
                empobj.Add(new EmpModel
                {
                    id=item.id,
                    name=item.name,
                    email=item.email,
                    city=item.city,
                    salary=item.salary
                });
            }
            return View(empobj);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}