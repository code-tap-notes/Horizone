using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace Horizone.Models
{
    public class Comment
    {
        public int Id { get; set; }
        
        [DataType(DataType.DateTime)]
        [Display(Name = "Date ")]
        public DateTime Date
        {
            get
            {
                return DateTime.Now;
            }
        }


        [Display(Name = "Content")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Content { get; set; }


        [Display(Name = "Nouvelles / News")]
        public int NewsId { get; set; }


        [ForeignKey("NewsId")]
        public News News { get; set; }


        [Display(Name = "Auteur / Author")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire. / Field {0} is required")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}