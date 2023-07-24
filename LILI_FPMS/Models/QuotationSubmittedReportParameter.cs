using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LILI_IMS.Models
{
    public class QuotationSubmittedReportParameter
    {
        //[Required(ErrorMessage ="Please Provide Quotation No.")]
        [Required(ErrorMessage = "Please select Quotation No.")]
        public string QuotationNo { get; set; }

        //[Required(ErrorMessage ="Please Select Item.")]
        public string ItemCode { get; set; }
        public string ParticipantCode { get; set; }
        public bool hasRate { get; set; }
    }
}
