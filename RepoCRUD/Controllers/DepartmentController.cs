using RepoCRUD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoCRUD.Models;
using System.Data;
using System.Web.Routing;

namespace RepoCRUD.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartment _depRepository;

        public DepartmentController()
        {
            _depRepository = new DepartmentRepository(new EmpModelEntities());
        }
        public DepartmentController(IDepartment depRepository)
        {
            _depRepository = depRepository;
        }
        // GET: Department
        public ActionResult Index()
        {
            var list = _depRepository.GetDepartment();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department dep)
        {
            if (ModelState.IsValid)
            {
                _depRepository.InsertDepartment(dep);
                _depRepository.SaveDepartment();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Department edit = _depRepository.GetDepartmentByID(id);
            return View(edit);
        }
        [HttpPost]
        public ActionResult Edit(Department dep)
        {
                if (ModelState.IsValid)
                {
                    _depRepository.UpdateDepartment(dep);
                    _depRepository.SaveDepartment();
                    return RedirectToAction("Index");
                }
            return View(dep);
        }

        public ActionResult Details(int id)
        {
            var list = _depRepository.GetDepartmentByID(id);
            return View(list);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            Department del = _depRepository.GetDepartmentByID(id);
            return View(del);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
                Department del = _depRepository.GetDepartmentByID(id);
                _depRepository.DeleteDepartment(id);
                _depRepository.SaveDepartment();
            
            return RedirectToAction("Index");
        } 
    }   
}
