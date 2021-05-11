using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenRepo.Repository
{
    public interface _IAllRepository<T> where T : class //Generic complusery <T> where T :class decler
    {
        IEnumerable<T> GetAll(); // All Data Fetch
        T GetById(int id); // All Data Fetch ID Wise
        void Insert(T model); // Indert Data
        void Update(T model); // Update Data
        void Delete(int id); // Delete Data
        void Save(); // Saven Changes Data

    }
}
