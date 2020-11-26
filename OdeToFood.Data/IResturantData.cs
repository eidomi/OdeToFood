using OddToFood.Core;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IResturantData
    {
        IEnumerable<Resturant> GetResturantsByName(string searchTerm);
        Resturant GetById(int id);
        Resturant Update(Resturant updatedResturant);
        Resturant Add(Resturant newResturant);
        Resturant Delete(int id);
        int Commit();
    }
}
