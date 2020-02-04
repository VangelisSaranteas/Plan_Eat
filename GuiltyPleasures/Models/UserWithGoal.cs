using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Models
{
    public class UserWithGoal
    {
        [Key]        
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
       
        [Range(0,20000)]
        public double Goal { get; set; }
        public int? PackageId { get; set; }
        [ForeignKey("PackageId")]
        public virtual Package  Package { get; set; }
    }
}