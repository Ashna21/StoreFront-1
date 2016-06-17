using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreFront.Models
{
    public class SearchViewModel : CustomerBaseViewModel
    {
        [Display(Description = "Type your search request here:")]
        public string SearchText { get; set; }

        public List<SearchResultViewModel> Results {get;set;}

        public SearchViewModel()
        {
            Results = new List<SearchResultViewModel>();
        }

    }

    public class SearchResultViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageFile { get; set; }
    }
}