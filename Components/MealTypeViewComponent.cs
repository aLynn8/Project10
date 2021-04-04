using Microsoft.AspNetCore.Mvc;
using SharpenTheSaw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Aubrey Farnbach (Wright) Section 2 Group 1
namespace SharpenTheSaw.Components
{
    public class MealTypeViewComponent : ViewComponent
    {
        private RecipesContext context;
        
        public MealTypeViewComponent(RecipesContext ctx)
        {
            context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            //Pull data from route at the top to get the selected meal type
            ViewBag.SelectedType = RouteData?.Values["mealtype"];
            
            return View(context.RecipeClasses
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
