using LILI_FPMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_IMS.Models
{
    public partial class TblRequisition
    {
        public TblRequisition()
        {
            TblProductionProcess = new HashSet<TblProductionProcess>();
            TblRequisitionDetail = new List<TblRequisitionDetail>();
            TblReturn = new HashSet<TblReturn>();
        }

        public int Id { get; set; }
        [Required]
        public string RequisitionNo { get; set; }
        public DateTime RequisitionDate { get; set; }
        public string BusinessCode { get; set; }
        
        public string BatchNo { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Contact number should not contain characters")]
        public decimal NumberOfBatch { get; set; }
        [Required]
        public string ProductCode { get; set; }

        [NotMapped]
        public string ProductName { get; set; }

        [NotMapped]
        public decimal StandardOutput { get; set; }

        [NotMapped]
        public decimal BatchSize { get; set; }

        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }

        public long BOMId { get; set; }

        [NotMapped]
        public string ApprovalStatus { get; set; }

        [NotMapped]
        public decimal MonthlyPlannedQty { get; set; }

        [NotMapped]
        public decimal MonthlyPlannedPendingQty { get; set; }
        [NotMapped]
        public decimal ProductionQty { get; set; }

        public string ExtOfRequisitionNo { get; set; }

        [NotMapped]
        public string IssueStatus { get; set; }

        public long PlantId { get; set; }
        public ICollection<TblProductionProcess> TblProductionProcess { get; set; }
        //public ICollection<TblRequisitionDetail> TblRequisitionDetail { get; set; }
        public List<TblRequisitionDetail> TblRequisitionDetail { get; set; }
        public ICollection<TblReturn> TblReturn { get; set; }
    }
}
