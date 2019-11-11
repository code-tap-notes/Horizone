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
        public DateTime Date { get; set; }
        
        [AllowHtml]
        [Display(Name = "Content", ResourceType = typeof(StaticResource.Resources))]      
        public string Content { get; set; }

        [Display(Name = "News", ResourceType = typeof(StaticResource.Resources))]
        public int NewsId { get; set; }

        [ForeignKey("NewsId")]
        public News News { get; set; }

        [Display(Name = "Client", ResourceType = typeof(StaticResource.Resources))]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
    }
}