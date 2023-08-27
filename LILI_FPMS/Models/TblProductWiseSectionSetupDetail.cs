using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_FPMS.Models
{
    public partial class TblProductWiseSectionSetupDetail
    {
        public int Id { get; set; }
        public int ProductSectionSetupId { get; set; }
        public string Section { get; set; }
        [NotMapped]
        public string SectionName { get; set; }
        public int Sequence { get; set; }
        public string Comments { get; set; }
        public string IsQcrequired { get; set; }
        public string IsSetupCompleted { get; set; }

        public TblProductWiseSectionSetup ProductSectionSetup { get; set; }
    }
}
