using System;
using System.Collections.Generic;

namespace LILI_FPMS.Models
{
    public partial class TblManufacturingBreakDownCause
    {
        public TblManufacturingBreakDownCause()
        {
            TblManufacturingShift = new HashSet<TblManufacturingShift>();
            TblPackingDetailShift = new HashSet<TblPackingDetailShift>();

        }

        public int BreakeDownCauseId { get; set; }
        public string BreakeDownCause { get; set; }
        public long PlantId { get; set; }

        public ICollection<TblManufacturingShift> TblManufacturingShift { get; set; }
        public ICollection<TblPackingDetailShift> TblPackingDetailShift { get; set; }
        public ICollection<TblCodingDetailShift> TblCodingDetailShift { get; set; }

    }
}
