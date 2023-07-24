using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblVisibility
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int IsVisible { get; set; }
        public long? PlantId { get; set; }
    }
}
