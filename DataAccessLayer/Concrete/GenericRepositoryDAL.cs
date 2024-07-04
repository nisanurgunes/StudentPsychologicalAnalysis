using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericRepositoryDAL<T> : IRepositoryDAL<T> where T : class
    {
          public Context db = new Context();
          public DbSet<T> _object; 

        public GenericRepositoryDAL() 
        {
            _object = db.Set<T>();
        }
        public void Delete(T t)
        {
            var deletedEntity = db.Entry(t); 
            deletedEntity.State = EntityState.Deleted;

          
            db.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T t)
        {
            var addedEntity = db.Entry(t); 
            addedEntity.State = EntityState.Added;

           
            db.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T t)
        {
            var updatedEntity = db.Entry(t); 
            updatedEntity.State = EntityState.Modified;
            
            db.SaveChanges(); 
        }
    }
}
