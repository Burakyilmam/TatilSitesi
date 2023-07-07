using Microsoft.EntityFrameworkCore;
using TatilSitesi.Models;

namespace TatilSitesi.Repository
{
    public class GenericRepository<T> where T : class, new()
    {
        Context c = new Context();

        public List<T> List()
        {
            return c.Set<T>().ToList();
        }
        public List<T> List(string u)
        {
            return c.Set<T>().Include(u).ToList();
        }
        public List<T> List(string u,string d)
        {
            return c.Set<T>().Include(u).Include(d).ToList();
        }
        public List<T> List(string u, string d,string h)
        {
            return c.Set<T>().Include(u).Include(d).Include(h).ToList();
        }
        public List<T> List(string u, string d, string h,string b)
        {
            return c.Set<T>().Include(u).Include(d).Include(h).Include(b).ToList();
        }
        public List<T> List(string u, string d, string h, string b,string k)
        {
            return c.Set<T>().Include(u).Include(d).Include(h).Include(b).Include(b).ToList();
        }
        public void Add(T item)
        {
            c.Add(item);
            c.SaveChanges();
        }
        public void Update(T item)
        {
            c.Update(item);
            c.SaveChanges();
        }
        public void Delete(T item)
        {
            c.Remove(item);
            c.SaveChanges();
        }
        public T Get(int id)
        {
            return c.Set<T>().Find(id);
        }
    }
}
