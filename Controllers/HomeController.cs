using CameronKeetch_Assignment10.Models;
using CameronKeetch_Assignment10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CameronKeetch_Assignment10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //setting an attribute of context to bring in our data
        private BowlingLeagueContext context { get; set;}

        //remember to pass in the bowlingleaguecontext
        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext con)
        {
            _logger = logger;
            
            //assign the context attribute to the BowlingLeagueContext
            context = con;
        }

        public IActionResult Index(long? teamid, string teamname, int pageNum = 1)
        {
            //declaring desired page size
            int pageSize = 5;


            //creating an IndexViewModel that will help us pass the information we need to the Index view.
            return View(new IndexViewModel
            {
                //setting the bowlers information using linq.
                Bowlers = (context.Bowlers
                            .Where(x => x.TeamId == teamid || teamid == null)
                            .OrderBy(x => x.BowlerFirstName)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize)
                            .ToList()),
                
                //setting PageNumberInfo to things we have already made
                PageNumberingInfo = new PageNumberingInfo
                {
                    ItemsPerPage = pageSize,
                    CurrentPage = pageNum,

                    //this makes it so that if no teamid has been selected, it just counts all the bowlers. If a teamid is selected, it counts only the team members for that specific team.
                    TotalNumItems = (teamid == null ? context.Bowlers.Count() : context.Bowlers.Where(x => x.TeamId == teamid).Count())
                                     

                },

                //setting Team to the id
                Team = teamname
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
