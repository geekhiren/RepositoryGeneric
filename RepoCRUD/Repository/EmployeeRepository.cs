using RepoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RepoCRUD.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private EmpModelEntities _db;
        public EmployeeRepository()
        {
            _db = new EmpModelEntities();
        }
        public EmployeeRepository(EmpModelEntities context)
        {
            _db = context;
        }

        void IEmployee.Delete(int EmployeeId)
        {
            EmployeeDetail employee =_db.EmployeeDetails.Find(EmployeeId);
            _db.EmployeeDetails.Remove(employee);
        }

        IEnumerable<EmployeeDetail> IEmployee.GetAll()
        {
            return _db.EmployeeDetails.ToList();
        }

        EmployeeDetail IEmployee.GetByID(int EmployeeId)
        {
            return _db.EmployeeDetails.Find(EmployeeId);
        }

        void IEmployee.Insert(EmployeeDetail Employee)
        {
            _db.EmployeeDetails.Add(Employee);
        }

        void IEmployee.Save()
        {
            _db.SaveChanges();
        }

        void IEmployee.Update(EmployeeDetail Employee)
        {
            _db.Entry(Employee).State = EntityState.Modified;
        }
    }
}