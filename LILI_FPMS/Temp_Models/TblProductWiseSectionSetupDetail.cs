using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblProductWiseSectionSetupDetail
    {
        public int Id { get; set; }
        public int ProductSectionSetupId { get; set; }
        public string Section { get; set; }
        public string Sequence { get; set; }
        public string Comments { get; set; }
        public string IsQcrequired { get; set; }

        public TblProductWiseSectionSetup ProductSectionSetup { get; set; }
    }
}
