using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_IMS.Models
{
    public partial class TblQcdetails
    {
        public int Id { get; set; }
        public string Qcno { get; set; }
        public string QcparameterCode { get; set; }
        [NotMapped]
        public string QcparameterName { get; set; }
        [NotMapped]
        public string QcparameterStandardValue { get; set; }

        public string QcparameterActualValue { get; set; }
        public string Comments { get; set; }

        public TblQc QcnoNavigation { get; set; }
    }
}
