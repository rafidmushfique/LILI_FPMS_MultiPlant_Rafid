using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblProductionProcess
    {
        public TblProductionProcess()
        {
            TblCodingDetailLine = new HashSet<TblCodingDetailLine>();
            TblCodingDetailMachine = new HashSet<TblCodingDetailMachine>();
            TblCodingDetailShift = new HashSet<TblCodingDetailShift>();
            TblManufacturingLine = new HashSet<TblManufacturingLine>();
            TblManufacturingMachine = new HashSet<TblManufacturingMachine>();
            TblManufacturingManPower = new HashSet<TblManufacturingManPower>();
            TblManufacturingShift = new HashSet<TblManufacturingShift>();
            TblPackingDetailLine = new HashSet<TblPackingDetailLine>();
            TblPackingDetailMachine = new HashSet<TblPackingDetailMachine>();
            TblPackingDetailShift = new HashSet<TblPackingDetailShift>();
            TblPackingManPower = new HashSet<TblPackingManPower>();
            TblProductionProcessDetail = new HashSet<TblProductionProcessDetail>();
        }

        public int Id { get; set; }
        public string ProcessNo { get; set; }
        public DateTime ProcessDate { get; set; }
        public string RequisitionNo { get; set; }
        public string BusinessCode { get; set; }
        public string IssueNo { get; set; }
        public decimal ProductionQty { get; set; }
        public string Sfgcode { get; set; }
        public decimal SfgproductionQty { get; set; }
        public DateTime? ManufacBatchStartTime { get; set; }
        public DateTime? ManufacBatchEndTime { get; set; }
        public string ManufacShiftCode { get; set; }
        public decimal? ManufacShiftBreakDownChangeTime { get; set; }
        public string ManufacLineCode { get; set; }
        public string ManufacMachineCode { get; set; }
        public decimal? ManufacMachineHour { get; set; }
        public decimal? ManufacManHour { get; set; }
        public decimal? ManufacNoOfWorker { get; set; }
        public decimal? ManufacCommonManHour { get; set; }
        public decimal? ManufacCommonNoOfWorker { get; set; }
        public DateTime? PackBatchStartTime { get; set; }
        public DateTime? PackBatchEndTime { get; set; }
        public string PackShiftCode { get; set; }
        public decimal? PackShiftBreakDownChangeTime { get; set; }
        public string PackLineCode { get; set; }
        public string PackMachineCode { get; set; }
        public decimal? PackMachineHour { get; set; }
        public decimal? PackManHour { get; set; }
        public decimal? PackNoOfWorker { get; set; }
        public decimal? PackCommonManHour { get; set; }
        public decimal? PackCommonNoOfWorker { get; set; }
        public string Comments { get; set; }
        public decimal? NumberOfBatch { get; set; }
        public string BatchNo { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }
        public decimal? ProductionQtyBeforeConversion { get; set; }
        public decimal? ProductionQtyConversionFactor { get; set; }
        public decimal? QcreferenceSampleQty { get; set; }
        public decimal? ManufacMachineNoOfWorker { get; set; }
        public decimal? ManufacMachineManHour { get; set; }
        public decimal? PackMachineNoOfWorker { get; set; }
        public decimal? PackMachineManHour { get; set; }
        public decimal? LumpQty { get; set; }
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
        public long? PlantId { get; set; }
        public string SectionCode { get; set; }

        public ICollection<TblCodingDetailLine> TblCodingDetailLine { get; set; }
        public ICollection<TblCodingDetailMachine> TblCodingDetailMachine { get; set; }
        public ICollection<TblCodingDetailShift> TblCodingDetailShift { get; set; }
        public ICollection<TblManufacturingLine> TblManufacturingLine { get; set; }
        public ICollection<TblManufacturingMachine> TblManufacturingMachine { get; set; }
        public ICollection<TblManufacturingManPower> TblManufacturingManPower { get; set; }
        public ICollection<TblManufacturingShift> TblManufacturingShift { get; set; }
        public ICollection<TblPackingDetailLine> TblPackingDetailLine { get; set; }
        public ICollection<TblPackingDetailMachine> TblPackingDetailMachine { get; set; }
        public ICollection<TblPackingDetailShift> TblPackingDetailShift { get; set; }
        public ICollection<TblPackingManPower> TblPackingManPower { get; set; }
        public ICollection<TblProductionProcessDetail> TblProductionProcessDetail { get; set; }
    }
}
