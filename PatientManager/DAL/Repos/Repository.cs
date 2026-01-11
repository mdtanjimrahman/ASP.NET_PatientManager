using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> table;
        protected PMContext db;

        public Repository(PMContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public List<T> Get()
        {
            return table.ToList();
        }

        public T Get(int id)
        {
            return table.Find(id);
        }

        public bool Create(T obj)
        {
            table.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            if (ex == null) return false;

            table.Remove(ex);
            return db.SaveChanges() > 0;
        }
    }
}
