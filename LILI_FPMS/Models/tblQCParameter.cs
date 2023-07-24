using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_IMS.Models
{
    public partial class TblQcparameter
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "QC Type Code is Required.")]
        [MaxLength(10)]
        public string TypeCode { get; set; }

        [Required]
        public string ProductCode { get; set; }

        [NotMapped]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "QC Parameter Code is Required.")]
        [MaxLength(10)]
        public string QcparameterCode { get; set; }

        [Required(ErrorMessage = "QC Parameter Name is Required.")]
        [MaxLength(250)]
        public string QcparameterName { get; set; }

        [Required(ErrorMessage = "QC Parameter Standard Value is Required.")]
        [MaxLength(50)]
        public string QcparameterStandardValue { get; set; }

        [MaxLength(250)]
        public string Comments { get; set; }
        public long PlantId { get; set; }
    }
}
