using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_IMS.Models.ReprotsViewModels
{
    public class RequisitionSlipViewModel
    {

        public int Id { get; set; }

        [DisplayName("Plant ID")]
        public long PlantId { get; set; }
        [DisplayName("Plant Name")]
        public string PlantName { get; set; }

        [DisplayName("Requisition No")]
        public string RequisitionNo { get; set; }

        [DisplayName("Requisition Date")]
        public DateTime RequisitionDate { get; set; }
       

        [DisplayName("Issue No")]
        public long IssueNo { get; set; }

        [DisplayName("Issue Date")]
        public DateTime IssueDate { get; set; }

        [DisplayName("Material Code")]
        public string MaterialCode { get; set; }

        [DisplayName("Material Name")]
        public string MaterialName { get; set; }

        [DisplayName("Unit")]
        public string SKUoM { get; set; }
        [DisplayName("ItemNo")]
        public long ItemNo { get; set; }

        [DisplayName("Requisition Quantity")]
        public decimal RequisitionQuantity { get; set; }
        [DisplayName("Return Quantity")]
        public decimal ReturnQuantity { get; set; }

        [DisplayName("Stock")]
        public decimal Stock { get; set; }

        [DisplayName("BatchQuantity")]
        public decimal BatchQuantity { get; set; }

        [DisplayName("BatchSize")]
        public decimal BatchSize { get; set; }

        [DisplayName("Issue Quantity")]
        public decimal Quantity { get; set; }

        [DisplayName("GRNNo")]
        public string GRNNo { get; set; }

        [DisplayName("Product Code")]
        public string ProductCode { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [DisplayName("Material Type")]
        public string MaterialType { get; set; }

        [DisplayName("Prepared By")]
        public string PreparedBy { get; set; }

        [DisplayName("Approved By")]
        public string ApprovedBy { get; set; }

        [DisplayName("Comments")]
        public string Comments { get; set; }


    }
}