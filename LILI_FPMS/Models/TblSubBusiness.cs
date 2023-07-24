using System;
using System.Collections.Generic;

namespace LILI_FPMS.Models
{
    public partial class TblSubBusiness
    {
        public int Id { get; set; }
        public string BusinessCode { get; set; }
        public string BusinessName { get; set; }
        public string SubBusinessCode { get; set; }
        public string SubBusinessName { get; set; }
    }
}
