using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuiltyPleasures.Models
{
    public class Money
    {

        [Key]
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; } = 300;
    }
}