using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Aubrey Farnbach (Wright) Section 2 Group 1

//Contains data we pass into Index since we can only pass in one model at a time
namespace SharpenTheSaw.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Bowlers> Bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string TeamCategory { get; set; }
    }
}
