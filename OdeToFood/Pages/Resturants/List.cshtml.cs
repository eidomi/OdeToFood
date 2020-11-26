using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OddToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Resturants
{
    public class ListModel : PageModel
    {
        private IConfiguration config;
        private IResturantData resturantData;

        public string Message { get; set; }
        public IEnumerable<Resturant> Resturants { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config, IResturantData resturantData)
        {
            this.config = config;
            this.resturantData = resturantData;
        }
        public void OnGet()
        {
            Message = config["Message"];
            Resturants = resturantData.GetResturantsByName(SearchTerm);
        }
    }
}
