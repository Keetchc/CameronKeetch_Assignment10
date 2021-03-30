using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameronKeetch_Assignment10.Models.ViewModels
{
    //allows us to set the information for different pages.
    public class PageNumberingInfo
    {
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }

        //Calc num of pages, makes sure to return the ceiling of a decimal, ensuring there is enough pages.
        public int NumPages => (int) (Math.Ceiling((float) TotalNumItems / ItemsPerPage));
    }
}
