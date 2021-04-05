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
        private BowlingLeagueContext context;
        
        public MealTypeViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            //Pull data from route at the top to get the selected meal type
            ViewBag.SelectedType = RouteData?.Values["teamid"];
            
            return View(context.Teams
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
