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

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(500, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "Content", ResourceType = typeof(StaticResource.Resources))]      
        public string Content { get; set; }


        [Display(Name = "News", ResourceType = typeof(StaticResource.Resources))]
        public int NewsId { get; set; }


        [ForeignKey("NewsId")]
        public News News { get; set; }


        [Display(Name = "PublishedBy", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
       
    }
}