using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_IMS.Models
{
    public partial class TblQc
    {
        public TblQc()
        {
            //TblQcdetails = new HashSet<TblQcdetails>();
            TblQcdetails = new List<TblQcdetails>();
            //TblQCParameterdetails = new List<TblQcparameter>();
        }

        public int Id { get; set; }
        public string Qcno { get; set; }
        public DateTime Qcdate { get; set; }
        public string BusinessCode { get; set; }
        public string RequisitionNo { get; set; }
        public string ProcessNo { get; set; }
        public decimal Qcqty { get; set; }
        public decimal QcpassQty { get; set; }
        public decimal QcrejectQty { get; set; }
        public decimal QcholdQty { get; set; }
        public decimal SFGQcqty { get; set; }
        public decimal SFGQcpassQty { get; set; }
        public decimal SFGQcrejectQty { get; set; }        
        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }
        public decimal QCQuarantineQty { get; set; }

        public bool IsSendToFloorStockFG { get; set; }
        public bool IsSendToFloorStockSFG { get; set; }
        public string SectionCode { get; set; }

        [NotMapped]
        public string ProductCode { get; set; }

        [NotMapped]
        public string ProductName { get; set; }

        [NotMapped]
        public decimal StandardOutput { get; set; }


        [NotMapped]
        public string BatchNo { get; set; }

        [NotMapped]
        public string PackSize { get; set; }

        [NotMapped]
        public decimal BatchSize { get; set; }

        [NotMapped]
        public decimal AvailableStock { get; set; }

        [NotMapped]
        public string TypeCode { get; set; }
        public long PlantId { get; set; }

        public decimal FGQCQtyBeforeConversion { get; set; }
        public decimal FGQCQtyConversionFactor { get; set; }
        public decimal QCReferenceSampleQty { get; set; }

        //public ICollection<TblQcdetails> TblQcdetails { get; set; }

        public List<TblQcdetails> TblQcdetails { get; set; }
        //public List<TblQcparameter> TblQCParameterdetails { get; set; }
    }
}
