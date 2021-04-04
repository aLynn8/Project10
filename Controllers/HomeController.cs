using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpenTheSaw.Models;
using SharpenTheSaw.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SharpenTheSaw.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RecipesContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, RecipesContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index(long? mealtypeid, string mealtype, int pageNum = 0)
        {
            int pageSize = 5;

            //Builds Title, with a dividing pipe and mealtype if mealtype is not null
            ViewData["Title"] = (mealtype != null ? (" | " + mealtype) : mealtype);

            return View(new IndexViewModel
            {
                Recipes = (context.Recipes
                    .Where(m => m.RecipeClassId == mealtypeid || mealtypeid == null)
                    .OrderBy(m => m.RecipeTitle)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    //If not meal has been selected then use count of all, else only cout those with the meal type selected
                    TotalNumItems = (mealtypeid == null ? context.Recipes.Count() : 
                    context.Recipes.Where(x => x.RecipeClassId == mealtypeid).Count())
                },

                MealCategory = mealtype
            });
               
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
