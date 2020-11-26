using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OddToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Resturants
{
    public class EditModel : PageModel
    {
        private IResturantData resturantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Resturant Resturant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IResturantData resturantData, IHtmlHelper htmlHelper) 
        {
            this.resturantData = resturantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? resturantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (resturantId.HasValue)
            {
                Resturant = resturantData.GetById(resturantId.Value);
            }
            else
            {
                Resturant = new Resturant();
            }
            if (Resturant == null) 
            {
                return RedirectToPage("./NotFounf");
            }
            return Page();
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Resturant.Id > 0)
            {
                resturantData.Update(Resturant);
            }
            else
            {
                resturantData.Add(Resturant);
            }
            resturantData.Commit();
            TempData["Message"] = "Resturant saved!";
            return RedirectToPage("./Detail", new { resturantId = Resturant.Id });
            
            
            
        }
    }
}
