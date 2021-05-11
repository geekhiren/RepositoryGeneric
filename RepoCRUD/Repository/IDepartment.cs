using RepoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoCRUD.Repository
{
    public interface IDepartment
    {

        IEnumerable<Department> GetDepartment(); // Read
        Department GetDepartmentByID(int DepartmentId); // Read only ID
        void InsertDepartment(Department department); // Create
        void UpdateDepartment(Department department); //Update
        void DeleteDepartment(int DepartmentId); //Delete
        void SaveDepartment();
    }
}
