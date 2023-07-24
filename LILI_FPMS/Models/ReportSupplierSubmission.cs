using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_IMS.Models
{
    public partial class ReportSupplierSubmission
    {
        public int Id { get; set; }
        public string SubmissionNo { get; set; }
        public string ItemCode { get; set; }
        public decimal BidQuantity { get; set; }
        public decimal MinOrderQuantity { get; set; }
        public decimal QuotedRate { get; set; } 
        public decimal Fobrate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public long? SupplierCountryId { get; set; }
        public string ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public long? ManufacturerCountryId { get; set; }
        public string Remarks { get; set; }
        public bool IsDGDAValid { get; set; }
        public string ItemName { get; set; }

        //[NotMapped]
        //public string ItemName { get; set; }

        [NotMapped]
        public string TargetSpec { get; set; }

        [NotMapped]
        public string UOM { get; set; }

        [NotMapped]
        public decimal Quantity { get; set; }

        [NotMapped]
        public int ShipMode { get; set; }

        [NotMapped]
        public int Currency { get; set; }

        [NotMapped]
        public string Incoterm { get; set; }




        [NotMapped]
        public string ShipModeName { get; set; }

        [NotMapped]
        public string CurrencyName { get; set; }

        [NotMapped]
        public string IncotermName { get; set; }

        [NotMapped]
        public string RequisitionNo { get; set; }


        public string IndentorName { get; set; }

    }
}
