using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LILI_FPMS.Models
{
    public partial class TblFgtn
    {
        public TblFgtn()
        {
            TblFgtndetails = new List<TblFgtndetails>();
        }

        public int Id { get; set; }
        public string Fgtnno { get; set; }
        public DateTime Fgtndate { get; set; }
        public string BusinessCode { get; set; }
        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }
        [Required(ErrorMessage ="Please Select Location.")]
        public string LocationCode { get; set; }
        public long PlantId { get; set; }
        public List<TblFgtndetails> TblFgtndetails { get; set; }
    }
}
