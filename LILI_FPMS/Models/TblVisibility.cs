using System;
using System.Collections.Generic;

namespace LILI_FPMS.Models
{
    public partial class TblVisibility
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Isvisible { get; set; }
        public long PlantId { get; set; }
    }
}
