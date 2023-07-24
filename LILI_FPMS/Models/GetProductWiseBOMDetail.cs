using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_IMS.Models
{
    public partial class GetProductWiseBOMDetail
    {
        public Int64 Id { get; set; }
        public string MaterialCode { get; set; }
        //[NotMapped]
        public string MaterialName { get; set; }
        //[NotMapped]
        public string Unit { get; set; }
        public decimal StandardRecipeQty { get; set; }
        public decimal FloorStock { get; set; }
        public decimal RequiredQty { get; set; }
        public decimal AvailableStock { get; set; }

    }
}
