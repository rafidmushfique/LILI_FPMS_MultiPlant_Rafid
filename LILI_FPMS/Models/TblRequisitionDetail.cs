using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_IMS.Models
{
    public partial class TblRequisitionDetail
    {
        public int Id { get; set; }
        public string RequisitionNo { get; set; }
        public string MaterialCode { get; set; }

        [NotMapped]
        public string MaterialName { get; set; }

        [NotMapped]
        public string Unit { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.0000}", ApplyFormatInEditMode = true)]
        public decimal RequiredQty { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.0000}", ApplyFormatInEditMode = true)]
        public decimal StandardRecipeQty { get; set; }


        [DisplayFormat(DataFormatString = "{0:0.0000}", ApplyFormatInEditMode = true)]
        public decimal FloorStock { get; set; }

        public decimal AvailableStock { get; set; }

        public TblRequisition RequisitionNoNavigation { get; set; }
    }
}
