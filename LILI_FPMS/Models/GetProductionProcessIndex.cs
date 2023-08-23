using LILI_IMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_FPMS.Models
{
    public class GetProductionProcessIndex
    {
        public int Id { get; set; }
        public string ProcessNo { get; set; }
        public DateTime ProcessDate { get; set; }
        public string BatchNo { get; set; }
        public string RequisitionNo { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal ProductionQty { get; set; }
        public string Comments { get; set; }
        public string SectionName { get; set; }


    }
}
