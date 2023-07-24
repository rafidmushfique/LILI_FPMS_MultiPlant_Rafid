using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LILI_IMS.Models
{
    public partial class TblLineSetup
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Line Code is Required.")]
        [MaxLength(10)]
        public string LineCode { get; set; }

        [Required(ErrorMessage = "Line Name is Required.")]
        [MaxLength(50)]
        public string LineName { get; set; }

        [MaxLength(250)]
        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }
        public long PlantId { get; set; }
    }
}
