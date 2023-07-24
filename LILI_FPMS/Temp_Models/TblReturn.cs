using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblReturn
    {
        public TblReturn()
        {
            TblReturnDetails = new HashSet<TblReturnDetails>();
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
        public long? PlantId { get; set; }

        public TblRequisition RequisitionNoNavigation { get; set; }
        public ICollection<TblReturnDetails> TblReturnDetails { get; set; }
    }
}
