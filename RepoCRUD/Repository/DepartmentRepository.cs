using RepoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RepoCRUD.Repository
{
    public class DepartmentRepository : IDepartment
    {
        private EmpModelEntities _db;
        public DepartmentRepository()
        {
            _db = new EmpModelEntities();
        }
        public DepartmentRepository(EmpModelEntities context)
        {
            _db = context;
        }

        IEnumerable<Department> IDepartment.GetDepartment()
        {
            return _db.Departments.ToList();
        }

        Department IDepartment.GetDepartmentByID(int DepartmentId)
        {
            return _db.Departments.Find(DepartmentId);
        }

        void IDepartment.InsertDepartment(Department department)
        {
            _db.Departments.Add(department);
        }
         
        void IDepartment.UpdateDepartment(Department department)
        {
            _db.Entry(department).State = EntityState.Modified;
        }

        void IDepartment.DeleteDepartment(int DepartmentId)
        {
            Department department = _db.Departments.Find(DepartmentId);
            _db.Departments.Remove(department);
        }

        void IDepartment.SaveDepartment()
        {
            _db.SaveChanges();
        }
    }
}