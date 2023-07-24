using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_IMS.Models
{
    public partial class TblShiftSetup
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Shift Code is Required.")]
        [MaxLength(10)]
        public string ShiftCode { get; set; }

        [Required(ErrorMessage = "Shift Name is Required.")]
        [MaxLength(50)]
        public string ShiftName { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Standard Shift Hour should not contain characters")]
        public decimal StandardShiftHour { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Planned Down Change Time should not contain characters")]
        public decimal PlannedDownChangeTime { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Productive Shift Hour should not contain characters")]
        public decimal ProductiveShiftHour { get; set; }

        [MaxLength(250)]
        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }
        public DateTime? ShiftStartTime { get; set; }
        public DateTime? ShiftEndTime { get; set; }
        public long PlantId { get; set; }

    }
}
