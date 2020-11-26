using OddToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryResturantsData : IResturantData
    {
        List<Resturant> resturants;
        public InMemoryResturantsData()
        {
            resturants = new List<Resturant>()
            {
                new Resturant { Id = 1, Name = "Scotts's Pizza", Location = "Meryland", Cuisine = CuisineType.Italian },
                new Resturant { Id = 2, Name = "Cinamon Club", Location = "London", Cuisine = CuisineType.Mexican },
                new Resturant { Id = 3, Name = "La Costa", Location = "Clifornia", Cuisine = CuisineType.India }
            };

         }

        public Resturant Add(Resturant newResturant)
        {
            resturants.Add(newResturant);
            newResturant.Id = resturants.Max(r => r.Id) + 1;
            return newResturant;
        }

        public int Commit()
        {
            return 0;
        }

        public Resturant Delete(int id)
        {
            var resturant = resturants.FirstOrDefault(r => r.Id == id);
            if (resturant != null)
            {
                resturants.Remove(resturant);
            }
            return resturant;
        }

        public Resturant GetById(int id)
        {
            return resturants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Resturant> GetResturantsByName(string name = null)
        {
            return from r in resturants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Resturant Update(Resturant updatedResturant)
        {
            var resturant = resturants.SingleOrDefault(r => r.Id == updatedResturant.Id);
            if (resturant != null) 
            {
                resturant.Name      = updatedResturant.Name;
                resturant.Location  = updatedResturant.Location;
                resturant.Cuisine   = updatedResturant.Cuisine;
            }
            return resturant;
        }
    }

}
