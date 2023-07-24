using System;
using System.Collections.Generic;

namespace LILI_FPMS.Models
{
    public partial class TblProductWiseSectionSetup
    {
        public TblProductWiseSectionSetup()
        {
            tblProductWiseSectionSetupDetails = new List<TblProductWiseSectionSetupDetail>();
        }

        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }
        public long? PlantId { get; set; }
        public List<TblProductWiseSectionSetupDetail> tblProductWiseSectionSetupDetails { get; set; }
        




    }
}
