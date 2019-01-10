using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Language
    {
        public int Id { get; set; }
        [StringLength(2, MinimumLength = 2, ErrorMessage = "2 Characters")]
        public string Symbol { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "2-50 Characters")]
        public string Name { get; set; }

        public bool IsDefault { get; set; }
    }
}