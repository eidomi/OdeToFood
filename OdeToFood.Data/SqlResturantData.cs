using Microsoft.EntityFrameworkCore;
using OddToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlResturantData : IResturantData
    {
        private OdeToFoodDbContext db;
        public SqlResturantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public Resturant Add(Resturant newResturant)
        {
            db.Add(newResturant);
            return newResturant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Resturant Delete(int id)
        {
            var resturant = GetById(id);
            if (resturant != null)
            {
                db.Resturant.Remove(resturant);
            }
            return resturant;
        }

        public Resturant GetById(int id)
        {
            return db.Resturant.Find(id);
        }

        public IEnumerable<Resturant> GetResturantsByName(string name)
        {
            var query = from r in db.Resturant
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Resturant Update(Resturant updatedResturant)
        {
            var entity = db.Resturant.Attach(updatedResturant);
            entity.State = EntityState.Modified;
            return updatedResturant;
        }
    }
}
