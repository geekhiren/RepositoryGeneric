using GenRepo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenRepo.Models;
using System.Data;

namespace GenRepo.Controllers
{
    public class EmployeeController : Controller
    {
        private _IAllRepository<EmployeeDetail> db;
        private _IAllRepository<Department> dep;

        public EmployeeController()
        {
	db = new AllRepository<EmployeeDetail>();
            dep = new AllRepository<Department>();
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View(db.GetAll());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            var Result = dep.GetAll();
            ViewBag.list = Result;           
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeDetail emp)
        {
            try
            {
                db.Insert(emp);
                db.Save();
                return RedirectToAction("Index");
            }
            catch(DataException)
            {
                return View("Error");
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var Result = dep.GetAll();
            ViewBag.list = Result;
            EmployeeDetail model = db.GetById(id);
            return View(model);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeDetail emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Update(emp);
                    db.Save();
                }
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes, Try again.");
            }
            return View(emp);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeDetail del = db.GetById(id);
            return View(del);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeDetail emp)
        {
            try
            {
                db.Delete(id);
                db.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
               Label1.Text = "Something Bad happened, Please contact Administrator!!!!";  
                }  
                finally  
                {  
                }  
            return View(emp);
        }
    }
}
