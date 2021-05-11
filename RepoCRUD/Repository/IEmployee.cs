using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoCRUD.Models;

namespace RepoCRUD.Repository
{
    public interface IEmployee
    {
        IEnumerable<EmployeeDetail> GetAll(); // Read
        EmployeeDetail GetByID(int EmployeeId); // Read only ID
        void Insert(EmployeeDetail Employee); // Create
        void Update(EmployeeDetail Employee); //Update
        void Delete(int EmployeeId); //Delete
        void Save();

    }
}
