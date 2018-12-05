using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class News
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire. / Field {0} is required")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Title { get; set; }
       

        [Display(Name = "Résumé / Summary")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Summary { get; set; }

        [DataType(DataType.DateTime)]                             
        [Display(Name = "Date ")]        
        public DateTime Date {
            get {
                return DateTime.Now;
            }
          }


        [Display(Name = "Content")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string ContentEnglish { get; set; }

        [Display(Name = "Contenu ")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string ContentFrench { get; set; }

        [Display(Name = "内容")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string ContentChinese { get; set; }
       
        [Display(Name = "Des vues / Views ")]
        [Range(0, 1000, ErrorMessage = "Le Nombre de lignes doit être positif / Field has to be possitive")]
        public int View { get; set; }

        [Display(Name = "Sujet / Topic")]
        public int TopicId { get; set; }

        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }

        [Display(Name = "Editeur / Editor")]
        public int ColaborateurId { get; set; }

        [ForeignKey("ColaborateurId")]
        public Colaborateur Colaborateur { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<ImageNews> ImageNewss { get; set; }
    }
}