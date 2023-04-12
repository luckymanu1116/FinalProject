using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
	public class WeightDbModel
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string _id { get; set; }

        [Required]
        public string Weight { get; set; }

        [Required]
        public String Date { get; set; }

        [Required]
        public String UserId { get; set; }
    }
}

