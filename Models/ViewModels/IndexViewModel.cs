using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameronKeetch_Assignment10.Models.ViewModels
{
    
    //acts as a "bag" or "container" to hold the information so it can be used in the next model.
    public class IndexViewModel
    {
        //makes a list of bowlers, so you can go through them using a foreach loop
        public List<Bowlers> Bowlers { get; set; }

        //pulls in the paging info view model.
        public PageNumberingInfo PageNumberingInfo { get; set; }

        public string Team { get; set; }

    }
}
