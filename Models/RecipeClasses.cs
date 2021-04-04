using System;
using System.Collections.Generic;

//Aubrey Farnbach (Wright) Section 2 Group 1

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SharpenTheSaw.Models
{
    public partial class RecipeClasses
    {
        public RecipeClasses()
        {
            Recipes = new HashSet<Recipes>();
        }

        public long RecipeClassId { get; set; }
        public string RecipeClassDescription { get; set; }

        public virtual ICollection<Recipes> Recipes { get; set; }
    }
}
