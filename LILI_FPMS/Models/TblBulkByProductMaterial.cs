using System;
using System.Collections.Generic;

namespace LILI_FPMS.Models
{
    public partial class TblBulkByProductMaterial
    {
        public int Id { get; set; }
        public long CompanyId { get; set; }
        public string BusinessCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string BaseUnit { get; set; }
        public long MaterialTypeId { get; set; }
        public long? SubCategoryId { get; set; }
        public long PlantId { get; set; }
    }
}
