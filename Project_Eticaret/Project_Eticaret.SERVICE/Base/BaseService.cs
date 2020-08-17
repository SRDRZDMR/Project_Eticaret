using Project_Eticaret.CORE.Entity;
using Project_Eticaret.CORE.Entity.Enum;
using Project_Eticaret.CORE.Service;
using Project_Eticaret.MODEL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project_Eticaret.SERVICE.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        // Singleton Design Pattern , context için bu şekilde tanımlıyoruz.
        private static ProjectContext _context;

        public ProjectContext Context
        {
            get 
            {
                if (_context == null)
                {
                    _context = new ProjectContext();
                    return _context;
                }
                return _context;
            }
            set { _context = value; }
        }

        public void Add(T item)
        {
            Context.Set<T>().Add(item);
            Save();
        }

        public void Add(List<T> items)
        {
            Context.Set<T>().AddRange(items);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp) => Context.Set<T>().Any(exp);


        public List<T> GetActive()
        {
            return Context.Set<T>().Where(x => x.Status == Status.Active).ToList();
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetById(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Where(exp).ToList();
        }

        public void Remove(T item)
        {
            item.Status = Status.Deleted; // Veri DB'den silinmiyor sadece DB'de Status durumu Deleted 'e çekiliyor.
            Update(item);
        }

        public void Remove(Guid id)
        {
            T item = GetById(id);
            item.Status = Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = Status.Deleted;
                Update(item);
            }
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public void Update(T item)
        {
            T updated = GetById(item.ID);
            DbEntityEntry entry = Context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();
        }

        // Singleton Pattern tarafı ile ilgili cache sorununu engellemek için DetachEntity() metodu mutlaka yazılmalıdır!
        public void DetactEntity(T item)
        {
            Context.Entry<T>(item).State = System.Data.Entity.EntityState.Detached;
        }
    }
}
