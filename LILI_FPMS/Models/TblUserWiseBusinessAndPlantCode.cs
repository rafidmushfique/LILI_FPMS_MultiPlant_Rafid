using System;
using System.Collections.Generic;

namespace LILI_FPMS.Models
{
    public partial class TblUserWiseBusinessAndPlantCode
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string BusinessCode { get; set; }
        public long PlantId { get; set; }
    }
}
