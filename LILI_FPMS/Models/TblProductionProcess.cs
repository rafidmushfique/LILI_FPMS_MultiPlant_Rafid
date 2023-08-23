using LILI_IMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_FPMS.Models
{
    public partial class TblProductionProcess
    {
        public TblProductionProcess()
        {
            TblManufacturingShift = new List<TblManufacturingShift>();
            TblManufacturingMachine = new List<TblManufacturingMachine>();
            TblManufacturingLine = new List<TblManufacturingLine>();
            TblManufacturingManPower = new List<TblManufacturingManPower>();

            TblPackingDetailShift = new List<TblPackingDetailShift>();
            TblPackingDetailLine = new List<TblPackingDetailLine>();
            TblPackingDetailMachine = new List<TblPackingDetailMachine>();
            TblPackingManPower = new List<TblPackingManPower>();

            TblCodingDetailShift = new List<TblCodingDetailShift>();
            TblCodingDetailLine = new List<TblCodingDetailLine>();
            TblCodingDetailMachine = new List<TblCodingDetailMachine>();
            
            TblProductionProcessDetail = new List<TblProductionProcessDetail>();
            
            
        }

        public int Id { get; set; }
        public string ProcessNo { get; set; }
        public DateTime ProcessDate { get; set; }
        public string RequisitionNo { get; set; }
        [NotMapped]
        public string ProductCode { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
        [Required]
        public string BatchNo { get; set; }
        public string SFGCode { get; set; }
        public decimal SFGProductionQty { get; set; }

        [NotMapped]
        public decimal StandardOutput { get; set; }
        [NotMapped]
        public decimal BatchSize { get; set; }
        public decimal NumberOfBatch { get; set; }
        public string BusinessCode { get; set; }
        public string IssueNo { get; set; }
        public decimal ProductionQty { get; set; }
        public DateTime? ManufacBatchStartTime { get; set; }
        public DateTime? ManufacBatchEndTime { get; set; }
        public string ManufacShiftCode { get; set; }
        public decimal? ManufacShiftBreakDownChangeTime { get; set; }
        public string ManufacLineCode { get; set; }
        public string ManufacMachineCode { get; set; }
        [NotMapped]
        public string ManufacMachineCapacity { get; set; }
        public decimal? ManufacMachineHour { get; set; }
        public decimal? ManufacManHour { get; set; }

        public decimal? ManufacMachineNoOfWorker { get; set; }
        public decimal? ManufacMachineManHour { get; set; }
        public decimal? ManufacCommonManHour { get; set; }

        public decimal? ManufacNoOfWorker { get; set; }
        //public string ManufacManPowerStaffId { get; set; }

        public decimal? ManufacCommonNoOfWorker { get; set; }
        //public decimal NumberOfBatch { get; set; }
        public DateTime? PackBatchStartTime { get; set; }
        public DateTime? PackBatchEndTime { get; set; }
        public string PackShiftCode { get; set; }
        public decimal? PackShiftBreakDownChangeTime { get; set; }
        public string PackLineCode { get; set; }
        public string PackMachineCode { get; set; }
        //public string PackManPowerStaffId { get; set; }
        [NotMapped]
        public string PackMachineCapacity { get; set; }
        public decimal? PackMachineHour { get; set; }
        public decimal? PackManHour { get; set; }

        public decimal? PackMachineNoOfWorker { get; set; }
        public decimal? PackMachineManHour { get; set; }


        public decimal? PackNoOfWorker { get; set; }
        public decimal? PackCommonManHour { get; set; }
        public decimal? PackCommonNoOfWorker { get; set; }
        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }

        [NotMapped]
        public int BreakeDownCauseId { get; set; }
        [NotMapped]
        public int PackingBreakeDownCauseId { get; set; }

        [NotMapped]
        public int CodingBreakeDownCauseId { get; set; }

        public decimal ProductionQtyBeforeConversion { get; set; }
        public decimal ProductionQtyConversionFactor { get; set; }

        [NotMapped]
        public decimal PreviousProcessedBatchNo { get; set; }
        [NotMapped]
        public decimal NoOfBatchInRequisition { get; set; }

        [NotMapped]
        public decimal PreviousProcessedProductionQty { get; set; }

        public decimal QCReferenceSampleQty { get; set; }
        public decimal LumpQty { get; set; }


        public DateTime? CodeBatchStartTime { get; set; }
        public DateTime? CodeBatchEndTime { get; set; }
        public string CodeShiftCode { get; set; }
        public decimal? CodeShiftBreakDownChangeTime { get; set; }
        public string CodeLineCode { get; set; }
        public string CodeMachineCode { get; set; }
        public decimal? CodeMachineHour { get; set; }
        public decimal? CodeManHour { get; set; }
        public decimal? CodeNoOfWorker { get; set; }
        public decimal? CodeCommonManHour { get; set; }
        public decimal? CodeCommonNoOfWorker { get; set; }
        public decimal? CodeMachineNoOfWorker { get; set; }
        public decimal? CodeMachineManHour { get; set; }
        public decimal CodingQty { get; set; }
        public decimal PackingQty { get; set; }
        [Required]
        public string SectionCode { get; set; }
        [NotMapped]
        public string CodeMachineCapacity { get; set; }
       

        [NotMapped]
        public decimal PrevSecProductionQty { get; set; }
        
        public long PlantId { get; set; }


        public TblRequisition RequisitionNoNavigation { get; set; }

        public List<TblManufacturingShift> TblManufacturingShift { get; set; }
        public List<TblManufacturingMachine> TblManufacturingMachine { get; set; }
        public List<TblManufacturingLine> TblManufacturingLine { get; set; }
        public List<TblManufacturingManPower> TblManufacturingManPower { get; set; }
        public List<TblPackingDetailShift> TblPackingDetailShift { get; set; }
        public List<TblPackingDetailLine> TblPackingDetailLine { get; set; }
        public List<TblPackingDetailMachine> TblPackingDetailMachine { get; set; }
        public List<TblPackingManPower> TblPackingManPower { get; set; }
        public List<TblCodingDetailShift> TblCodingDetailShift { get; set; }
        public List<TblCodingDetailLine> TblCodingDetailLine { get; set; }
        public List<TblCodingDetailMachine> TblCodingDetailMachine { get; set; }
      
      

        public List<TblProductionProcessDetail> TblProductionProcessDetail { get; set; }
    }
}
