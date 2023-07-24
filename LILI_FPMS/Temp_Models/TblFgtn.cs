using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblFgtn
    {
        public TblFgtn()
        {
            TblFgtndetails = new HashSet<TblFgtndetails>();
        }

        public int Id { get; set; }
        public string Fgtnno { get; set; }
        public DateTime Fgtndate { get; set; }
        public string BusinessCode { get; set; }
        public string LocationCode { get; set; }
        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }
        public long? PlantId { get; set; }

        public ICollection<TblFgtndetails> TblFgtndetails { get; set; }
    }
}
