using MyProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult Lab()
        {
            /* var results = persons.Join(
             phones,
             person => person,
             phone => phone.Person,
             (person, phone) => new { name = person.Name, phoneNumber = phone.PhoneNumber });

             foreach (var result in results)
             {
                 Console.WriteLine($"{result.name}: {result.phoneNumber}");
             }





             LabDepEntities db = new LabDepEntities();

             foreach (var item in db.PAT_RESULTD)
             {
                 if (item.PRD_RESULT_VALUE > 10)
                 {
                      query.Add(item);
                 }
             }*/

            LabDepEntities db = new LabDepEntities();
            var result = (from c in db.PAT_BASIC
                          select new LabTables
                          {
                              HHISNUM = c.HHISNUM,
                              HNAME = c.HNAME,
                              HIDNO = c.HIDNO,
                              HSEX = c.HSEX,
                              HBIRTHDT = c.HBIRTHDT,
                              HBLDTYPE = c.HBLDTYPE,
                              HPATADR = c.HPATADR,
                              HPMOBIL = c.HPMOBIL,
                              WEIGHT = c.WEIGHT,
                              HEIGHT = c.HEIGHT,
                              CREATEDATETIME = c.CREATEDATETIME
                          }).ToList();
            return Json(result);
        }


    }
}
