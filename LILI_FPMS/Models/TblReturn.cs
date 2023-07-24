using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_IMS.Models
{
    public partial class TblReturn
    {
        public TblReturn()
        {
            TblReturnDetails = new List<TblReturnDetails>();
        }

        public int Id { get; set; }
        public string ReturnNo { get; set; }
        public DateTime ReturnDate { get; set; }
        public string BusinessCode { get; set; }
        public string RequisitionNo { get; set; }
        public string IssueNo { get; set; }
        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }

        [NotMapped]
        public string BatchNo { get; set; }

        [NotMapped]
        public string BatchSize { get; set; }

        [NotMapped]
        public string Unit { get; set; }

        [NotMapped]
        public string ProductCode { get; set; }

        [NotMapped]
        public string ProductName { get; set; }

        public long PlantId { get; set; }
        public TblRequisition RequisitionNoNavigation { get; set; }
        public List<TblReturnDetails> TblReturnDetails { get; set; }
    }
}
