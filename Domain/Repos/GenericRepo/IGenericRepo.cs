using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repos.GenericRepo
{
    public interface IGenericRepo<entity> where entity:class
    {
        List<entity> GetAll();
        entity? GetByID(int id);
        entity Add(entity e);
        void update(entity e);
        void Delete(entity e);
        void DeleteByID(int id);
        void savechanges();

    }
}
