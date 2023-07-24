using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_IMS.Models
{
    public partial class ReportApprovalFormForImport
    {
        public Int64 Id { get; set; }
        public string PRNo { get; set; }
        public decimal PRQuantity { get; set; }
        public decimal MAC { get; set; }
        public decimal StandardOrderSize { get; set; }
        public decimal ShelfLifeYear { get; set; }
        public decimal LeadTimeMonth { get; set; }
        public string ShortDue { get; set; }
        public string MaterialArrival { get; set; }
        public string ACISpecNo { get; set; } 
        public string Title { get; set; }
        public string FormNo { get; set; }
        public string Revision { get; set; }
        public string ApprovedBy { get; set; }
        public string DateEffectiveRevised { get; set; }
        public string NameofTheMaterial { get; set; }
        public string ForTheManufactureOfFinishedProduct { get; set; }
        public string Business { get; set; }
        public string StockOfMaterialAsOn { get; set; }
        public string FGOpeningStockQuantity { get; set; }
        public string FGSalesConsumptionWeek { get; set; }

        public decimal RMPMOpeningStockQuantity { get; set; }
        public decimal RMPMSalesConsumptionWeek { get; set; }

        public decimal RMInFGStockQuantity { get; set; }
        public decimal RMInFGSalesConsumptionWeek { get; set; }
        public decimal InTransitOnOrderStockQuantity { get; set; }
        public decimal InTransitOnOrderSalesConsumptionWeek { get; set; }
        public decimal SubTotal123QuantityUnit { get; set; }
        public decimal SubTotal123SalesConsumptionWeeks { get; set; }
        public decimal ProposedOrderQuantityUnit { get; set; }
        public decimal ProposedOrderSalesConsumptionWeek { get; set; }
        public decimal Total45QuantityUnit { get; set; }
        public decimal Total45SalesConsumptionWeeks { get; set; }
        public decimal LeadTimeSalesConsumptionWeeks { get; set; }
        public decimal StockwhenatFactory67Week { get; set; }

        public decimal LCValue { get; set; }
        public string ETD { get; set; }
        public string IndentorID { get; set; }
        public string IndentorName { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public string PriceUnit { get; set; }
        public string SourceValidationInDGDA { get; set; }
        public string QCSourceArovalStatus { get; set; }

        public string LastPurchaseRate { get; set; }
        public string LastAwardedManufacturer { get; set; }
        public string ReferenceRateinPreviousYear { get; set; }
        public decimal ConsumptioninPreviousYear { get; set; }
        public string HistoricalHighestRate { get; set; }
        public decimal RequirementinCurrentYear { get; set; }
        public string HistoricalLowestRate { get; set; }
        public decimal PurchasedinCurrentYear { get; set; }

    }
}
