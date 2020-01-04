using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class SearchResult
    {       
        public int Id { get; set; }
        [Display(Name = "Source", ResourceType = typeof(StaticResource.Resources))]
        public string NameTable { set; get; }
        [Display(Name = "IndexSource", ResourceType = typeof(StaticResource.Resources))]
        public int IdResult { set; get; }
        [Display(Name = "Summary", ResourceType = typeof(StaticResource.Resources))]
        public string Summary { set; get; }
    }
}