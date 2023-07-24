using System;
using System.Collections.Generic;

namespace LILI_IMS.Models
{
    public partial class View_Material
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string BusinessCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public long MaterialTypeId { get; set; }
        public long? SubCategoryId { get; set; }
        public string BaseUnit { get; set; }
        //public decimal ConversionValue { get; set; }
        //public string SkuoM { get; set; }
        //public decimal AuoMconversionValue { get; set; }
        //public string AlternativeUoM { get; set; }
        //public string SubBusinessCode { get; set; }
        //public string Discontinue { get; set; }
        //public string InsertIpaddress { get; set; }
        //public string EditIpaddress { get; set; }
        //public string Iuser { get; set; }
        //public DateTime? Idate { get; set; }
        //public string Euser { get; set; }
        //public DateTime? Edate { get; set; }
    }
}
