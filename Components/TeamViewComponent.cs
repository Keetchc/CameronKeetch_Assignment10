using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CameronKeetch_Assignment10.Models;
using Microsoft.AspNetCore.Mvc;

namespace CameronKeetch_Assignment10.Components
{
    //inherits from ViewComponent
    public class TeamViewComponent : ViewComponent
    {
        //context attribute
        private BowlingLeagueContext context;
       
        //constructor that brings in the context
        public TeamViewComponent(BowlingLeagueContext con)
        {
            context = con;
        }

        //what is displayed when this is called
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamname"];
            //using LINQ to return the team names
            return View(context.Teams
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
