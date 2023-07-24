using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LILI_IMS.Models
{
    public class tblRMRate
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string PlantCode { get; set; }

        [Required]
        [MaxLength(20)]
        public string ItemCode { get; set; }

        [Required]
        [MaxLength(6)]
        public string Period { get; set; }

        [Required]
        public decimal ClosingCost { get; set; }

        public string Iuser { get; set; }
        public DateTime Idate { get; set; }
        public string Euser { get; set; }
        public DateTime? Edate { get; set; }
    }
}
