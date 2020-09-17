using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADO_MVC_DEMO1.Models;
using System.Net;

namespace ADO_MVC_DEMO1.Controllers
{
    public class DepartmentController : Controller
    {
       
        [HttpGet]
        public ActionResult Index()
        {
            DeparmentDBHelper db = new DeparmentDBHelper();
            return View(db.GetDepartments().ToList());
        }

       [HttpGet]
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(string Name,string Location)
        {
            try
            {
                Department d = new Department()
                {
                    Name = Name,
                    Location = Location
                };

                DeparmentDBHelper db = new DeparmentDBHelper();
                db.InsertDeptDetails(d);

                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            DeparmentDBHelper db = new DeparmentDBHelper();
            Department department= db.GetDepartments().FirstOrDefault(d => d . Id == id);

            return View(department);
        }


        [HttpPost]
        public ActionResult Edit(string Id,string Name,string Location)
        {
            try
            {   
              Department d = new Department()
             {
                Id =Convert.ToInt32(Id), 
                Name = Name, 
                Location = Location
             };

             DeparmentDBHelper db = new DeparmentDBHelper();
             db.UpdateDeptDetails(d);
             return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Details(int? id)
        {
            DeparmentDBHelper db = new DeparmentDBHelper();
            Department dept = db.GetDepartments().FirstOrDefault(d => d.Id == id);
            return View(dept);
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            DeparmentDBHelper db = new DeparmentDBHelper();
            Department dept= db.GetDepartments().FirstOrDefault(d=>d.Id==id);
            return View(dept);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest,"Id Required");
            }
             
            DeparmentDBHelper db = new DeparmentDBHelper();
            db.DeleteDeptDetails(id);



            return RedirectToAction("Index");
        }

        public ActionResult Info()
        {

            return View();
        }


    }
}