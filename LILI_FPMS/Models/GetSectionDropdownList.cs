using System;
using System.Collections.Generic;

namespace LILI_IMS.Models
{
    public partial class GetSectionDropdownList
    {
        public Int32 Id { get; set; }
         public string SectionCode { get; set; } 
        public string SectionName { get; set; }
       
        public int Sequence { get; set; }
    }
}
