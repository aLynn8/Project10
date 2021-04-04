using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Aubrey Farnbach (Wright) Section 2 Group 1

namespace SharpenTheSaw.Models.ViewModels
{
    public class PageNumberingInfo
    {
        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }
        //calculate the number of pages
        public int NumPages => (int)Math.Ceiling((decimal)TotalNumItems / NumItemsPerPage);

    }
}
