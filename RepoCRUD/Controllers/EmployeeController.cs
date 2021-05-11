using RepoCRUD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoCRUD.Models;

namespace RepoCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployee _empRepository;
        private IDepartment _depRepository;

        public EmployeeController()
        {
            _empRepository = new EmployeeRepository(new EmpModelEntities());
            _depRepository = new DepartmentRepository(new EmpModelEntities());
        }
        public EmployeeController(IEmployee empRepository)
        {
            _empRepository = empRepository;
        }
        public EmployeeController(IDepartment depRepository)
        {
            _depRepository = depRepository;
        }

        // GET: Employee
        public ActionResult Index()
        {
            var list = _empRepository.GetAll();
            return View(list);
        }

        public ActionResult Create()
        { 
            var Result = _depRepository.GetDepartment();
            ViewBag.DepartmentIds = Result;
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeDetail emp)
        {
            if (ModelState.IsValid)
            {
                _empRepository.Insert(emp);
                _empRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var Result = _depRepository.GetDepartment();
            ViewBag.DepartmentIds = Result;
            EmployeeDetail model = _empRepository.GetByID(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeDetail emp)
        {
            if (ModelState.IsValid)
            {
                _empRepository.Update(emp);
                _empRepository.Save();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            EmployeeDetail del = _empRepository.GetByID(id);
            return View(del);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeDetail emp = _empRepository.GetByID(id);
            _empRepository.Delete(id);
            _empRepository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var list = _empRepository.GetByID(id);
            return View(list);
        }


    }
}