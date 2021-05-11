using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GenRepo.Models;

namespace GenRepo.Repository
{
    public class AllRepository<T> : _IAllRepository<T> where T : class
    {
        //Connection String Add....
        private EmpModelEntities _db;
        private IDbSet<T> dbEntity;

        public AllRepository()
        {
            _db = new EmpModelEntities();
            dbEntity = _db.Set<T>();
        }

        void _IAllRepository<T>.Delete(int id)
        {
            T model = dbEntity.Find(id);
            dbEntity.Remove(model);
        }

        IEnumerable<T> _IAllRepository<T>.GetAll()
        {
            return dbEntity.ToList();
        }

        T _IAllRepository<T>.GetById(int id)
        {
            return dbEntity.Find(id);
        }

        void _IAllRepository<T>.Insert(T model)
        {
            dbEntity.Add(model);
        }

        void _IAllRepository<T>.Save()
        {
            _db.SaveChanges();
        }

        void _IAllRepository<T>.Update(T model)
        {
            _db.Entry(model).State = EntityState.Modified;
        }
    }
}
