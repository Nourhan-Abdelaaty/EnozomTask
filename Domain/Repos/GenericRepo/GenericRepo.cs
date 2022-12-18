using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repos.GenericRepo
{
    public class GenericRepo<entity> : IGenericRepo<entity> where entity: class
    {
        private readonly DBContext context;
        public GenericRepo(DBContext _context)
        {
            context = _context;
        }



        public entity? GetByID(int id)
        {
            return context.Set<entity>().Find(id);
        }


        public List<entity> GetAll()
        {

            return context.Set<entity>().ToList();

        }


        public entity Add(entity e)
        {
            context.Set<entity>().Add(e);
            return e;
        }

        public void Delete(entity e)
        {
            context.Set<entity>().Remove(e);
        }
        public void DeleteByID(int id)
        {
            var e = GetByID(id);
            if (e != null)
            {
                context.Set<entity>().Remove(e);
            }
        }

        public void update(entity e)
        {
            context.Entry(e).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void savechanges()
        {
            context.SaveChanges();
        }





       
    }
}
