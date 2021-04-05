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

//Aubrey Farnbach (Wright) Section 2 Group 1
namespace SharpenTheSaw.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index(long? teamid, string team, int pageNum = 0)
        {
            int pageSize = 5;

            //Builds Title, with a dividing pipe and mealtype if mealtype is not null
            ViewData["Title"] = (team != null ? (" | " + team) : team);

            return View(new IndexViewModel
            {
                Bowlers = (context.Bowlers
                    .Where(m => m.TeamId == teamid || teamid == null)
                    .OrderBy(m => m.BowlerLastName)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    //If not meal has been selected then use count of all, else only cout those with the meal type selected
                    TotalNumItems = (teamid == null ? context.Bowlers.Count() : 
                    context.Bowlers.Where(x => x.TeamId == teamid).Count())
                },

                MealCategory = team
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
