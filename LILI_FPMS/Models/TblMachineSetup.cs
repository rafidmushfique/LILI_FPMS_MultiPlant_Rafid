using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_IMS.Models
{
    public partial class TblMachineSetup
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Machine Code is Required.")]
        [MaxLength(20)]
        public string MachineCode { get; set; }

        //[Required(ErrorMessage = "Machine Name is Required.")]
        //[MaxLength(50)]
        [NotMapped]
        public string MachineName { get; set; }

        [MaxLength(50)]
        public string Capacity { get; set; }

        [MaxLength(50)]
        public string Speed { get; set; }

        [MaxLength(250)]
        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }

        [Required]
        public string ProductCode { get; set; }

        [NotMapped]
        public string ProductName { get; set; }

        [MaxLength(50)]
        public string CapacityPacking { get; set; }

        [MaxLength(50)]
        public string SpeedPacking { get; set; }
        public long PlantId { get; set; }
    }
}
