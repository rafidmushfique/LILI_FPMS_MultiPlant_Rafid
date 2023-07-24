using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LILI_FPMS;
using LILI_IMS.Models;
using LILI_IMS.Models.ReprotsViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using NPOI.SS.Formula.Functions;
using System.Linq;
using LILI_FPMS.Models;
using System.Drawing;
using Newtonsoft.Json;
using System.Web.Helpers;
using System.Xml;

namespace LILI_IMS.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly dbFormulationProductionSystemContext _context;
        private readonly IConfiguration _configuration;

        public ReportController(dbFormulationProductionSystemContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult DetailsConsumption(string year = "", string month = "", string code = "", string batch = "")
        {
            ViewBag.Year = year;
            ViewBag.Month = month;
            ViewBag.Code = code;
            ViewBag.Batch = batch;

            if (code == null) code = "";
            if (batch == null) batch = "";

            var data = new List<DetailsConsumptionViewModel>();

            string connString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(@"sp_DetailsConsumption", conn))
                    {
                        var parameters = new SqlParameter[]
                        {
                            new SqlParameter("@year", year),
                            new SqlParameter("@month", month),
                            new SqlParameter("@code", code),
                            new SqlParameter("@batch", batch),
                            new SqlParameter("@plantId", GlobalVariable.PlantId)
                        };
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var dc = new DetailsConsumptionViewModel();
                                dc.FGCodeBatchNoAndCategory = dr.GetString(0);
                                dc.FGCodeAndBatchNo = dr.GetString(1);
                                dc.FGCode = dr.GetString(2);
                                dc.FGName = dr.GetString(3);
                                dc.PackSize = dr.GetString(4);
                                dc.BatchSize = dr.GetString(5);
                                dc.BatchNo = dr.GetString(6);
                                dc.Category = dr.GetString(7);
                                dc.MatCode = dr.GetString(8);
                                dc.MaterialName = dr.GetString(9);
                                dc.Unit = dr.GetString(10);
                                dc.ProcessLoss = dr.GetString(11);
                                dc.Wastage = dr.GetString(12);
                                dc.TotalConsumption = dr.GetString(13);
                                dc.Rate = dr.GetString(14);
                                dc.StandardValue = dr.GetString(15);
                                dc.UsedValue = dr.GetString(16);
                                dc.ProcessLossValue = dr.GetString(17);
                                dc.WastageValue = dr.GetString(18);
                                dc.TotalConsumptionValue = dr.GetString(19);
                                dc.StdConsumptionQty = dr.GetString(20);
                                dc.CurrentUseQty = dr.GetString(21);

                                data.Add(dc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return View(data);
        }

        public ActionResult DetailsConsumptionFactory(string year = "", string month = "", string code = "", string batch = "")
        {
            ViewBag.Year = year;
            ViewBag.Month = month;
            ViewBag.Code = code;
            ViewBag.Batch = batch;

            if (code == null) code = "";
            if (batch == null) batch = "";

            var data = new List<DetailsConsumptionViewModel>();

            string connString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(@"sp_DetailsConsumption", conn))
                    {
                        var parameters = new SqlParameter[]
                        {
                            new SqlParameter("@year", year),
                            new SqlParameter("@month", month),
                            new SqlParameter("@code", code),
                            new SqlParameter("@batch", batch),
                            new SqlParameter("@plantId", GlobalVariable.PlantId)
                        };
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var dc = new DetailsConsumptionViewModel();
                                dc.FGCodeBatchNoAndCategory = dr.GetString(0);
                                dc.FGCodeAndBatchNo = dr.GetString(1);
                                dc.FGCode = dr.GetString(2);
                                dc.FGName = dr.GetString(3);
                                dc.PackSize = dr.GetString(4);
                                dc.BatchSize = dr.GetString(5);
                                dc.BatchNo = dr.GetString(6);
                                dc.Category = dr.GetString(7);
                                dc.MatCode = dr.GetString(8);
                                dc.MaterialName = dr.GetString(9);
                                dc.Unit = dr.GetString(10);
                                dc.ProcessLoss = dr.GetString(11);
                                dc.Wastage = dr.GetString(12);
                                dc.TotalConsumption = dr.GetString(13);
                                dc.Rate = dr.GetString(14);
                                dc.StandardValue = dr.GetString(15);
                                dc.UsedValue = dr.GetString(16);
                                dc.ProcessLossValue = dr.GetString(17);
                                dc.WastageValue = dr.GetString(18);
                                dc.TotalConsumptionValue = dr.GetString(19);
                                dc.StdConsumptionQty = dr.GetString(20);
                                dc.CurrentUseQty = dr.GetString(21);

                                data.Add(dc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return View(data);
        }

        public ActionResult BatchWiseProductWiseSummary(string year = "", string month = "", string code = "", string batch = "")
        {
            ViewBag.Year = year;
            ViewBag.Month = month;
            ViewBag.Code = code;
            ViewBag.Batch = batch;

            if (code == null) code = "";
            if (batch == null) batch = "";

            var data = new List<BatchWiseProductWiseSummaryViewModel>();

            string connString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(@"sp_BatchWiseProductWiseSummary", conn))
                    {
                        var parameters = new SqlParameter[]
                        {
                            new SqlParameter("@year", year),
                            new SqlParameter("@month", month),
                            new SqlParameter("@code", code),
                            new SqlParameter("@batch", batch),
                            new SqlParameter("@plantId", GlobalVariable.PlantId)
                        };
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                data.Add(new BatchWiseProductWiseSummaryViewModel
                                {
                                    CodePlusBatch = dr.GetString(0),
                                    FGCode = dr.GetString(1),
                                    FGName = dr.GetString(2),
                                    PackSize = dr.GetString(3),
                                    BatchNo = dr.GetString(4),
                                    FGQuantity = dr.GetDecimal(5),
                                    RM = dr.GetDecimal(6),
                                    PM = dr.GetDecimal(7),
                                    ProcessLoss = dr.GetDecimal(8),
                                    Wastage = dr.GetDecimal(9),
                                    OHCost = dr.GetDecimal(10),
                                    TotalConsumption = dr.GetDecimal(11),
                                    ActualRM = dr.GetDecimal(12),
                                    ActualPM = dr.GetDecimal(13),
                                    ActualProcessLoss = dr.GetDecimal(14),
                                    ActualWastage = dr.GetDecimal(15),
                                    ActualOHCost = dr.GetDecimal(16),
                                    ActualTotalConsumption = dr.GetDecimal(17),
                                    DifferenceRM = dr.GetDecimal(18),
                                    DifferencePM = dr.GetDecimal(19),
                                    DifferenceProcessLoss = dr.GetDecimal(20),
                                    DifferenceWastage = dr.GetDecimal(21),
                                    DifferenceOHCost = dr.GetDecimal(22),
                                    DifferenceTotalConsumption = dr.GetDecimal(23)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return View(data);
        }

        public ActionResult ProductWiseCosting(string year = "", string month = "", string code = "", string batch = "")
        {
            ViewBag.Year = year;
            ViewBag.Month = month;
            ViewBag.Code = code;
            ViewBag.Batch = batch;

            if (code == null) code = "";
            if (batch == null) batch = "";


            var data = new List<ProductWiseCostingViewModel>();

            string connString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(@"sp_ProductWiseCosting", conn))
                    {
                        var parameters = new SqlParameter[]
                        {
                            new SqlParameter("@year", year),
                            new SqlParameter("@month", month),
                            new SqlParameter("@code", code),
                            new SqlParameter("@batch", batch)
                        };
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                data.Add(new ProductWiseCostingViewModel
                                {
                                    FGCode = dr.GetString(0),
                                    FGName = dr.GetString(1),
                                    PackSize = dr.GetString(2),
                                    Production = dr.GetDecimal(3),
                                    StandardTotalRM = dr.GetDecimal(4),
                                    StandardTotalPM = dr.GetDecimal(5),
                                    StandardTotalOH = dr.GetDecimal(6),
                                    StandardRMPerUnit = dr.GetDecimal(7),
                                    StandardPMPerUnit = dr.GetDecimal(8),
                                    StandardOHPerUnit = dr.GetDecimal(9),
                                    StandardCOGS = dr.GetDecimal(10),
                                    ActualTotalRM = dr.GetDecimal(11),
                                    ActualTotalPM = dr.GetDecimal(12),
                                    ActualTotalOH = dr.GetDecimal(13),
                                    ActualRMPerUnit = dr.GetDecimal(14),
                                    ActualPMPerUnit = dr.GetDecimal(15),
                                    ActualOHPerUnit = dr.GetDecimal(16),
                                    ActualCOGS = dr.GetDecimal(17),
                                    VarianceTotalRM = dr.GetDecimal(18),
                                    VarianceTotalPM = dr.GetDecimal(19),
                                    VarianceTotalOH = dr.GetDecimal(20),
                                    VarianceCOGS = dr.GetDecimal(21)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return View(data);
        }

        public ActionResult FloorStock(string year = "", string month = "")
        {
            List<SelectListItem> monthList = new List<SelectListItem>();
            monthList.Add(new SelectListItem { Value = "<--Select Month-->", Text = "00" });
            monthList.Add(new SelectListItem { Value = "January", Text = "01" });
            monthList.Add(new SelectListItem { Value = "February", Text = "02" });
            monthList.Add(new SelectListItem { Value = "March", Text = "03" });
            monthList.Add(new SelectListItem { Value = "April", Text = "04" });
            monthList.Add(new SelectListItem { Value = "May", Text = "05" });
            monthList.Add(new SelectListItem { Value = "June", Text = "06" });
            monthList.Add(new SelectListItem { Value = "July", Text = "07" });
            monthList.Add(new SelectListItem { Value = "August", Text = "08" });
            monthList.Add(new SelectListItem { Value = "September", Text = "09" });
            monthList.Add(new SelectListItem { Value = "October", Text = "10" });
            monthList.Add(new SelectListItem { Value = "November", Text = "11" });
            monthList.Add(new SelectListItem { Value = "December", Text = "12" });
            ViewData["ddlMonth"] = monthList;


            ViewBag.Year = year.Length <= 0 ? DateTime.Now.Year.ToString() : year;
            ViewBag.Month = month;

            //ViewBag.Code = code;
            //ViewBag.Batch = batch;

            //if (code == null) code = "";
            //if (batch == null) batch = "";

            var data = new List<FloorStockViewModel>();

            string connString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(@"sp_FloorStockReport", conn))
                    {
                        var parameters = new SqlParameter[]
                        {
                            new SqlParameter("@year", year),
                            new SqlParameter("@month", month),
                            new SqlParameter("@plantId", GlobalVariable.PlantId)
                            //new SqlParameter("@code", code),
                            //new SqlParameter("@batch", batch)
                        };
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var dc = new FloorStockViewModel();
                                dc.PlantId = dr.GetInt64(0);
                                dc.Period = dr.GetInt32(1);
                                dc.MaterialCode = dr.GetString(2);
                                dc.MaterialName = dr.GetString(3);
                                dc.Openning = dr.GetDecimal(4);
                                dc.Receive = dr.GetDecimal(5);
                                dc.Consumption = dr.GetDecimal(6);
                                dc.Returned = dr.GetDecimal(7);
                                dc.ClosingBalance = dr.GetDecimal(8);

                                data.Add(dc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return View(data);
        }

        public ActionResult YieldReport(string year = "", string month = "", string code = "")
        {
            List<SelectListItem> monthList = new List<SelectListItem>();
            monthList.Add(new SelectListItem { Value = "<--Select Month-->", Text = "00" });
            monthList.Add(new SelectListItem { Value = "January", Text = "January" });
            monthList.Add(new SelectListItem { Value = "February", Text = "February" });
            monthList.Add(new SelectListItem { Value = "March", Text = "March" });
            monthList.Add(new SelectListItem { Value = "April", Text = "April" });
            monthList.Add(new SelectListItem { Value = "May", Text = "May" });
            monthList.Add(new SelectListItem { Value = "June", Text = "June" });
            monthList.Add(new SelectListItem { Value = "July", Text = "July" });
            monthList.Add(new SelectListItem { Value = "August", Text = "August" });
            monthList.Add(new SelectListItem { Value = "September", Text = "September" });
            monthList.Add(new SelectListItem { Value = "October", Text = "October" });
            monthList.Add(new SelectListItem { Value = "November", Text = "November" });
            monthList.Add(new SelectListItem { Value = "December", Text = "December" });
            ViewData["ddlMonth"] = monthList;


            ViewBag.Year = year.Length <= 0 ? DateTime.Now.Year.ToString() : year;
            ViewBag.Month = month;

            ViewBag.Code = code;
            //ViewBag.Batch = batch;

            if (code == null) code = "";
            //if (batch == null) batch = "";

            var data = new List<YieldReportViewModel>();

            string connString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(@"sp_YieldReport", conn))
                    {
                        var parameters = new SqlParameter[]
                        {
                            new SqlParameter("@year", year),
                            new SqlParameter("@month", month),
                            new SqlParameter("@code", code),
                            new SqlParameter("@plantId", GlobalVariable.PlantId)
                            //new SqlParameter("@batch", batch)
                        };
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var dc = new YieldReportViewModel();
                                dc.RequisitionNo = dr.GetString(0);
                                dc.ProcessNo = dr.GetString(1);
                                dc.ItemCode = dr.GetString(2);
                                dc.SKUProduct = dr.GetString(3);
                                dc.PackSize = dr.GetDecimal(4);
                                dc.BatchNo = dr.GetDecimal(5);
                                dc.StdOutputPcs = dr.GetDecimal(6);
                                dc.ActOutputPcs = dr.GetDecimal(7);
                                dc.Yield = dr.GetDecimal(8);
                                dc.StdInputBatch = dr.GetDecimal(9);
                                dc.StdOutputBatch = dr.GetDecimal(10);
                                dc.Yield1 = dr.GetDecimal(11);
                                dc.ActualInput = dr.GetDecimal(12);
                                dc.ActualOutput = dr.GetDecimal(13);
                                dc.Yield2 = dr.GetDecimal(14);
                                dc.GainLoss = dr.GetDecimal(15);
                                dc.Wastage = dr.GetDecimal(16);

                                data.Add(dc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return View(data);
        }


        public ActionResult ManHourReport(string year = "", string month = "", string code = "")
        {
            List<SelectListItem> monthList = new List<SelectListItem>();
            monthList.Add(new SelectListItem { Value = "<--Select Month-->", Text = "00" });
            monthList.Add(new SelectListItem { Value = "January", Text = "January" });
            monthList.Add(new SelectListItem { Value = "February", Text = "February" });
            monthList.Add(new SelectListItem { Value = "March", Text = "March" });
            monthList.Add(new SelectListItem { Value = "April", Text = "April" });
            monthList.Add(new SelectListItem { Value = "May", Text = "May" });
            monthList.Add(new SelectListItem { Value = "June", Text = "June" });
            monthList.Add(new SelectListItem { Value = "July", Text = "July" });
            monthList.Add(new SelectListItem { Value = "August", Text = "August" });
            monthList.Add(new SelectListItem { Value = "September", Text = "September" });
            monthList.Add(new SelectListItem { Value = "October", Text = "October" });
            monthList.Add(new SelectListItem { Value = "November", Text = "November" });
            monthList.Add(new SelectListItem { Value = "December", Text = "December" });
            ViewData["ddlMonth"] = monthList;


            ViewBag.Year = year.Length <= 0 ? DateTime.Now.Year.ToString() : year;
            ViewBag.Month = month;

            ViewBag.Code = code;
            //ViewBag.Batch = batch;

            if (code == null) code = "";
            //if (batch == null) batch = "";

            var data = new List<ManHourReportViewModel>();

            string connString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(@"sp_ManHourReport", conn))
                    {
                        var parameters = new SqlParameter[]
                        {
                            new SqlParameter("@year", year),
                            new SqlParameter("@month", month),
                            new SqlParameter("@code", code),
                            new SqlParameter("@plantId", GlobalVariable.PlantId)
                            //new SqlParameter("@batch", batch)
                        };
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var dc = new ManHourReportViewModel();
                                dc.RequisitionNo = dr.GetString(0);
                                dc.ProcessNo = dr.GetString(1);
                                dc.ItemCode = dr.GetString(2);
                                dc.SKUProduct = dr.GetString(3);
                                dc.PackSize = dr.GetDecimal(4);
                                dc.BatchNo = dr.GetDecimal(5);
                                dc.TotalProductionPcs = dr.GetDecimal(6);

                                dc.StandardMHRM = dr.GetDecimal(7);
                                dc.StandardMHPM = dr.GetDecimal(8);
                                dc.StandardMHTotal = dr.GetDecimal(9);

                                dc.ActualMHRM = dr.GetDecimal(10);
                                dc.ActualMHPM = dr.GetDecimal(11);
                                dc.ActualMHTotal = dr.GetDecimal(12);

                                dc.VarianceRM = dr.GetDecimal(13);
                                dc.VariancePM = dr.GetDecimal(14);
                                dc.VarianceTotal = dr.GetDecimal(15);

                                data.Add(dc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return View(data);
        }

        //public ActionResult RequisitionSlipReport(string RequisitionNo = "")
        //{
        //    ViewBag.RequisitionNo = RequisitionNo;


        //    //ViewBag.Code = code;
        //    //ViewBag.Batch = batch;

        //    //if (code == null) code = "";
        //    //if (batch == null) batch = "";

        //    var data = new List<RequisitionSlipViewModel>();

        //    string connString = _configuration.GetConnectionString("DefaultConnection");
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(@"sp_RequisitionSlipReport", conn))
        //            {
        //                var parameters = new SqlParameter[]
        //                {
        //                    new SqlParameter("@CompanyId", 1),
        //                    new SqlParameter("@PlantId", 3),
        //                    new SqlParameter("@RequisitionNo", RequisitionNo)
        //                    //new SqlParameter("@code", code),
        //                    //new SqlParameter("@batch", batch)
        //                };
        //                cmd.Parameters.AddRange(parameters);
        //                conn.Open();

        //                cmd.CommandType = CommandType.StoredProcedure;
        //                SqlDataReader dr = cmd.ExecuteReader();

        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        var dc = new RequisitionSlipViewModel();
        //                        //dc.PlantId = dr.GetInt64(0);
        //                        dc.PlantName = dr.GetString(1);
        //                        //dc.IssueNo = dr.GetInt64(2);
        //                        //dc.IssueDate = dr.GetDateTime(3);
        //                        dc.RequisitionNo = dr.GetString(4);
        //                        dc.RequisitionDate = dr.GetDateTime(5);
        //                        dc.MaterialCode = dr.GetString(6);
        //                        dc.MaterialName = dr.GetString(7);
        //                        dc.SKUoM = dr.GetString(8);
        //                        //dc.ItemNo = dr.GetInt64(9);
        //                        dc.RequisitionQuantity = dr.GetDecimal(10);
        //                        dc.Stock = dr.GetDecimal(11);
        //                        dc.ReturnQuantity = dr.GetDecimal(12);
        //                        dc.BatchQuantity = dr.GetDecimal(13);
        //                        dc.BatchSize = dr.GetDecimal(14);
        //                        dc.Quantity = dr.GetDecimal(15);
        //                        dc.GRNNo = dr.GetString(16);
        //                        dc.ProductCode = dr.GetString(17);
        //                        dc.ProductName = dr.GetString(18);
        //                        dc.MaterialType = dr.GetString(19);

        //                        data.Add(dc);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception: " + ex.Message);
        //    }

        //    return View(data);
        //}

        //public IActionResult ReportAllSubmissionParameter()
        //{
        //    QuotationSubmittedReportParameter drpModel = new QuotationSubmittedReportParameter();
        //    List<TblRfq> quotationList = new List<TblRfq>();
        //    quotationList = (from quotation in eFQuotationReqContext.TblRfq
        //                    select quotation).OrderBy(x=>x.Id).ToList();
        //    ViewBag.QuotationList = quotationList;
        //    return View(drpModel); 
        //}

        //public IActionResult ReportAllSubmission(QuotationSubmittedReportParameter drpModel)
        //{

        //    ViewData["QuotationNo"] = drpModel.QuotationNo.ToString();
        //    ViewData["ItemCode"] = drpModel.ItemCode == null? "": drpModel.ItemCode.ToString();
        //    ViewData["ParticipantCode"] = drpModel.ParticipantCode == null ? "" : drpModel.ParticipantCode;
        //    ViewData["RateProvided"] = drpModel.hasRate;

        //    var quotationNo = drpModel.QuotationNo.ToString();

        //    var itemCode = drpModel.ItemCode == null ? "0" : drpModel.ItemCode.ToString();
        //    var participantCode = drpModel.ParticipantCode == null ? "0" : drpModel.ParticipantCode.ToString();
        //    var hasRate = drpModel.hasRate;

        //    ReportSubmission rptSub = new ReportSubmission();
        //    var comparisonList = eFQuotationReqContext.ReportSubmission   ("sp_ComparisonReport " + '"' + quotationNo + '"' +',' + '"' + itemCode + '"' + ',' + '"' + participantCode + '"' + ',' + '"' + hasRate + '"').ToList();

        //    return new ViewAsPdf(comparisonList, ViewData);         
        //}

        //public JsonResult GetQuotationWiseItemList(string quotationNo)
        //{
        //    List<View_Item> itemList = new List<View_Item>();
        //    itemList = (from  itm in eFQuotationReqContext.View_Item
        //                from rfqItm in eFQuotationReqContext.TblRfqitemDetail
        //                where rfqItm.Rfqno == quotationNo && itm.ItemCode == rfqItm.ItemCode 
        //                select itm).OrderBy(x=> x.ItemName).ToList();
        //    itemList.Insert(0, new View_Item { ItemCode = "", ItemName = "Select Item" });

        //    return Json(new SelectList(itemList, "ItemCode", "ItemName"));
        //}


        public ActionResult RequisitionSlipReport(string RequisitionNo = "")
        {



            ViewBag.RequisitionNo = RequisitionNo;

            TblRequisition entities = new TblRequisition();
            List<TblRequisition> requisitionList = new List<TblRequisition>();
            requisitionList = (from c in _context.TblRequisition
                               where c.PlantId == GlobalVariable.PlantId
                               orderby c.RequisitionDate descending
                               select new TblRequisition
                               {
                                   Id = c.Id,
                                   RequisitionNo = c.RequisitionNo
                               }).ToList();
            requisitionList.Insert(0, new TblRequisition { RequisitionNo = "-- Select Requisition No --" });
            ViewBag.ListOfRequisitionNo = requisitionList;


            var data = new List<RequisitionSlipViewModel>();

            string connString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(@"sp_RequisitionSlipReport", conn))
                    {
                        var parameters = new SqlParameter[]
                        {
                            new SqlParameter("@CompanyId", 1),
                            //new SqlParameter("@PlantId", 3),
                            new SqlParameter("@plantId", GlobalVariable.PlantId),
                            new SqlParameter("@RequisitionNo", RequisitionNo)

                        };
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var dc = new RequisitionSlipViewModel();
                                //dc.PlantId = dr.GetInt64(0);
                                dc.PlantName = dr.GetString(1);
                                //dc.IssueNo = dr.GetInt64(2);
                                //dc.IssueDate = dr.GetDateTime(3);
                                dc.RequisitionNo = dr.GetString(4);
                                dc.RequisitionDate = dr.GetDateTime(5);
                                dc.MaterialCode = dr.GetString(6);
                                dc.MaterialName = dr.GetString(7);
                                dc.SKUoM = dr.GetString(8);
                                //dc.ItemNo = dr.GetInt64(9);
                                dc.RequisitionQuantity = dr.GetDecimal(10);
                                dc.Stock = dr.GetDecimal(11);
                                dc.ReturnQuantity = dr.GetDecimal(12);
                                dc.BatchQuantity = dr.GetDecimal(13);
                                dc.BatchSize = dr.GetDecimal(14);
                                dc.Quantity = dr.GetDecimal(15);
                                dc.GRNNo = dr.GetString(16);
                                dc.ProductCode = dr.GetString(17);
                                dc.ProductName = dr.GetString(18);
                                dc.MaterialType = dr.GetString(19);
                                dc.PreparedBy = dr.GetString(20);
                                dc.ApprovedBy = dr.GetString(21);
                                dc.Comments = dr.GetString(22);

                                data.Add(dc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return View(data);
        }

        public ActionResult MonthlyConsumptionReport(string year = "", string month = "", long materialCategory = 0, string subBusiness = "",string dateFrom = "",string dateTo = "")
        {
            if (!string.IsNullOrEmpty(dateFrom) || !string.IsNullOrEmpty(dateTo)) { 
              month="";
            }
            List<SelectListItem> monthList = new List<SelectListItem>();
            monthList.Add(new SelectListItem { Value = "<--Select Month-->", Text = "00" });
            monthList.Add(new SelectListItem { Value = "January", Text = "January" });
            monthList.Add(new SelectListItem { Value = "February", Text = "February" });
            monthList.Add(new SelectListItem { Value = "March", Text = "March" });
            monthList.Add(new SelectListItem { Value = "April", Text = "April" });
            monthList.Add(new SelectListItem { Value = "May", Text = "May" });
            monthList.Add(new SelectListItem { Value = "June", Text = "June" });
            monthList.Add(new SelectListItem { Value = "July", Text = "July" });
            monthList.Add(new SelectListItem { Value = "August", Text = "August" });
            monthList.Add(new SelectListItem { Value = "September", Text = "September" });
            monthList.Add(new SelectListItem { Value = "October", Text = "October" });
            monthList.Add(new SelectListItem { Value = "November", Text = "November" });
            monthList.Add(new SelectListItem { Value = "December", Text = "December" });
            ViewData["ddlMonth"] = monthList;


            ViewBag.Year = year.Length <= 0 ? DateTime.Now.Year.ToString() : year;
            ViewBag.Month = month;


            List<SelectListItem> materialCategoryList = new List<SelectListItem>();
            materialCategoryList.Add(new SelectListItem { Value = "0", Text = "<--All-->" });
            materialCategoryList.Add(new SelectListItem { Value = "1", Text = "Raw Materials" });
            materialCategoryList.Add(new SelectListItem { Value = "2", Text = "Packing Materials" });
            materialCategoryList.Add(new SelectListItem { Value = "4", Text = "Semi-Finished Goods" });
            ViewData["ddlCategory"] = materialCategoryList;

            ViewBag.materialCategory = materialCategory;


            //List<SelectListItem> subBusinessList = new List<SelectListItem>();
            //subBusinessList.Add(new SelectListItem { Value = "", Text = "<--All-->" });
            //subBusinessList.Add(new SelectListItem { Value = "03", Text = "Granular" });
            //subBusinessList.Add(new SelectListItem { Value = "05", Text = "Liquid" });
            //subBusinessList.Add(new SelectListItem { Value = "06", Text = "Powder" });
            //ViewData["ddlSubBusiness"] = subBusinessList;

            //ViewBag.subBusiness = subBusiness;

            List<TblSubBusiness> subBusinessList = new List<TblSubBusiness>();
            subBusinessList = (from c in _context.TblSubBusiness
                               select c).ToList();
            subBusinessList.Insert(0, new TblSubBusiness { SubBusinessCode = "", SubBusinessName = "<--Select Sub-Business-->" });
            ViewData["ddlSubBusiness"] = subBusinessList;
            ViewBag.subBusiness = subBusiness;

            var data = new List<MonthlyConsumptionViewModel>();

            string connString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(@"sp_MonthlyConsumptionReport", conn))
                    {
                        var parameters = new SqlParameter[]
                        {
                            new SqlParameter("@year", year),
                            new SqlParameter("@month", month),
                            new SqlParameter("@MaterialCategory", materialCategory),
                            new SqlParameter("@subBusiness", subBusiness),
                            new SqlParameter("@dateFrom", dateFrom),
                            new SqlParameter("@dateTo", dateTo),
                            new SqlParameter("@plantId", GlobalVariable.PlantId)
                        };
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var dc = new MonthlyConsumptionViewModel();
                                dc.ProductName = dr.GetString(1);
                                dc.ProductionQty = dr.GetString(2);
                                dc.MaterialCode = dr.GetString(3);
                                dc.MaterialName = dr.GetString(4);
                                dc.BaseUnit = dr.GetString(5);
                                dc.StdConsumptionQty = dr.GetString(6);
                                dc.OpeningStock = dr.GetString(7);
                                dc.IssueQty = dr.GetString(8);
                                dc.ReturnQty = dr.GetString(9);
                                dc.TotalConsumption = dr.GetString(10);
                                dc.ClosingStock = dr.GetString(11);
                                dc.LossAccess = dr.GetString(12);
                                dc.Yield = dr.GetString(13);

                                data.Add(dc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            foreach(var item in data)
            {
                
            }

            return View(data);
        }

        public ActionResult MonthlyManhourReport(string year = "", string month = "", string subBusiness = "", string dateFrom = "", string dateTo = "")
        {
            if (!string.IsNullOrEmpty(dateFrom) || !string.IsNullOrEmpty(dateTo))
            {
                month = "";
            }
            List<SelectListItem> monthList = new List<SelectListItem>();
            monthList.Add(new SelectListItem { Value = "<--Select Month-->", Text = "00" });
            monthList.Add(new SelectListItem { Value = "January", Text = "January" });
            monthList.Add(new SelectListItem { Value = "February", Text = "February" });
            monthList.Add(new SelectListItem { Value = "March", Text = "March" });
            monthList.Add(new SelectListItem { Value = "April", Text = "April" });
            monthList.Add(new SelectListItem { Value = "May", Text = "May" });
            monthList.Add(new SelectListItem { Value = "June", Text = "June" });
            monthList.Add(new SelectListItem { Value = "July", Text = "July" });
            monthList.Add(new SelectListItem { Value = "August", Text = "August" });
            monthList.Add(new SelectListItem { Value = "September", Text = "September" });
            monthList.Add(new SelectListItem { Value = "October", Text = "October" });
            monthList.Add(new SelectListItem { Value = "November", Text = "November" });
            monthList.Add(new SelectListItem { Value = "December", Text = "December" });
            ViewData["ddlMonth"] = monthList;

            ViewBag.Year = year;
            ViewBag.Month = month;


            List<TblSubBusiness> subBusinessList = new List<TblSubBusiness>();
            subBusinessList = (from c in _context.TblSubBusiness
                               select c).ToList();
            subBusinessList.Insert(0, new TblSubBusiness { SubBusinessCode = "", SubBusinessName = "<--Select Sub-Business-->" });
            ViewData["ddlSubBusiness"] = subBusinessList;
            ViewBag.subBusiness = subBusiness;


            var data = new List<MonthlyManhourViewModel>();

            string connString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(@"sp_MonthlyManhourReport", conn))
                    {
                        var parameters = new SqlParameter[]
                        {
                            new SqlParameter("@year", year),
                            new SqlParameter("@month", month),
                            new SqlParameter("@subBusiness", subBusiness),
                            new SqlParameter("@dateFrom", dateFrom),
                            new SqlParameter("@dateTo", dateTo),
                            new SqlParameter("@plantId", GlobalVariable.PlantId)
                        };
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var dc = new MonthlyManhourViewModel();
                                dc.ProductCode = dr.GetString(1);
                                dc.ProductName = dr.GetString(2);
                                dc.PackSize = dr.GetString(3);
                                dc.ProductionQty = dr.GetString(4);
                                dc.NoOfWorker = dr.GetString(5);
                                dc.CommonNoOfWorker = dr.GetString(6);
                                dc.WorkerManHour = dr.GetString(7);
                                dc.CommonManHour = dr.GetString(8);
                                dc.TotalManHour = dr.GetString(9);
                                dc.ManHourPerProductUnit = dr.GetString(10);
                                data.Add(dc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return View(data);
        }

        public ActionResult MonthlyProductionReportFG(string year = "", string month = "", string subBusiness = "", string dateFrom = "", string dateTo = "")
        {
            if (!string.IsNullOrEmpty(dateFrom) || !string.IsNullOrEmpty(dateTo))
            {
                month = "";
            }
            List<SelectListItem> monthList = new List<SelectListItem>();
            monthList.Add(new SelectListItem { Value = "<--Select Month-->", Text = "00" });
            monthList.Add(new SelectListItem { Value = "January", Text = "January" });
            monthList.Add(new SelectListItem { Value = "February", Text = "February" });
            monthList.Add(new SelectListItem { Value = "March", Text = "March" });
            monthList.Add(new SelectListItem { Value = "April", Text = "April" });
            monthList.Add(new SelectListItem { Value = "May", Text = "May" });
            monthList.Add(new SelectListItem { Value = "June", Text = "June" });
            monthList.Add(new SelectListItem { Value = "July", Text = "July" });
            monthList.Add(new SelectListItem { Value = "August", Text = "August" });
            monthList.Add(new SelectListItem { Value = "September", Text = "September" });
            monthList.Add(new SelectListItem { Value = "October", Text = "October" });
            monthList.Add(new SelectListItem { Value = "November", Text = "November" });
            monthList.Add(new SelectListItem { Value = "December", Text = "December" });
            ViewData["ddlMonth"] = monthList;

            ViewBag.Year = year;
            ViewBag.Month = month;

            List<TblSubBusiness> subBusinessList = new List<TblSubBusiness>();
            subBusinessList = (from c in _context.TblSubBusiness
                               select c).ToList();
            subBusinessList.Insert(0, new TblSubBusiness { SubBusinessCode = "", SubBusinessName = "<--Select Sub-Business-->" });
            ViewData["ddlSubBusiness"] = subBusinessList;
            ViewBag.subBusiness = subBusiness;

            var data = new List<MonthlyProductionReportFGViewModel>();

            string connString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(@"sp_MonthlyProductionReportFG", conn))
                    {
                        var parameters = new SqlParameter[]
                        {
                            new SqlParameter("@year", year),
                            new SqlParameter("@month", month),
                            new SqlParameter("@subBusiness", subBusiness),
                            new SqlParameter("@dateFrom", dateFrom),
                            new SqlParameter("@dateTo", dateTo),
                            new SqlParameter("@plantId", GlobalVariable.PlantId)
                        };
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var dc = new MonthlyProductionReportFGViewModel();
                                dc.ProductCode = dr.GetString(1);
                                dc.ProductName = dr.GetString(2);
                                dc.PackSize = dr.GetString(3);
                                dc.OpeningStock = dr.GetString(4);
                                dc.ProductionQty = dr.GetString(5);
                                dc.QCReferenceSampleQty = dr.GetString(6);
                                dc.DespatchQty = dr.GetString(7);
                                dc.ClosingStock = dr.GetString(8);
                                dc.QCHoldQty = dr.GetString(9);

                                data.Add(dc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return View(data);
        }

        public ActionResult MonthlyProductionReportSFG(string year = "", string month = "", string subBusiness = "", string dateFrom = "", string dateTo = "")
        {
            if (!string.IsNullOrEmpty(dateFrom) || !string.IsNullOrEmpty(dateTo))
            {
                month = "";
            }
            List<SelectListItem> monthList = new List<SelectListItem>();
            monthList.Add(new SelectListItem { Value = "<--Select Month-->", Text = "00" });
            monthList.Add(new SelectListItem { Value = "January", Text = "January" });
            monthList.Add(new SelectListItem { Value = "February", Text = "February" });
            monthList.Add(new SelectListItem { Value = "March", Text = "March" });
            monthList.Add(new SelectListItem { Value = "April", Text = "April" });
            monthList.Add(new SelectListItem { Value = "May", Text = "May" });
            monthList.Add(new SelectListItem { Value = "June", Text = "June" });
            monthList.Add(new SelectListItem { Value = "July", Text = "July" });
            monthList.Add(new SelectListItem { Value = "August", Text = "August" });
            monthList.Add(new SelectListItem { Value = "September", Text = "September" });
            monthList.Add(new SelectListItem { Value = "October", Text = "October" });
            monthList.Add(new SelectListItem { Value = "November", Text = "November" });
            monthList.Add(new SelectListItem { Value = "December", Text = "December" });
            ViewData["ddlMonth"] = monthList;

            ViewBag.Year = year;
            ViewBag.Month = month;

            List<TblSubBusiness> subBusinessList = new List<TblSubBusiness>();
            subBusinessList = (from c in _context.TblSubBusiness
                               select c).ToList();
            subBusinessList.Insert(0, new TblSubBusiness { SubBusinessCode = "", SubBusinessName = "<--Select Sub-Business-->" });
            ViewData["ddlSubBusiness"] = subBusinessList;
            ViewBag.subBusiness = subBusiness;

            var data = new List<MonthlyProductionReportSFGViewModel>();

            string connString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(@"sp_MonthlyProductionReportSFG", conn))
                    {
                        var parameters = new SqlParameter[]
                        {
                            new SqlParameter("@year", year),
                            new SqlParameter("@month", month),
                            new SqlParameter("@subBusiness", subBusiness),
                            new SqlParameter("@dateFrom", dateFrom),
                            new SqlParameter("@dateTo", dateTo)
                        };
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var dc = new MonthlyProductionReportSFGViewModel();
                                dc.ProductCode = dr.GetString(1);
                                dc.ProductName = dr.GetString(2);
                                dc.PackSize = dr.GetString(3);
                                dc.OpeningStock = dr.GetString(4);
                                dc.ProductionQty = dr.GetString(5);
                                dc.QCReferenceSampleQty = dr.GetString(6);
                                dc.UsedActual = dr.GetString(7);
                                dc.ClosingStock = dr.GetString(8);

                                data.Add(dc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return View(data);
        }

        public ActionResult DailyConsumptionReport(string dateFrom , string dateTo) 
        {
            var data = new List<DailyConsumptionViewModel>();
            DataTable dt = new DataTable();
            string connString = _configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(@"sp_DailyConsumptionReport", conn))
                    {
                        var parameters = new SqlParameter[]
                        {
                            new SqlParameter("@dateFrom", dateFrom),
                            new SqlParameter("@dateTo", dateTo),
                            new SqlParameter("@plantId", GlobalVariable.PlantId)
                        };
                        cmd.Parameters.AddRange(parameters);
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();
                        
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var dc = new DailyConsumptionViewModel();

                                dc.ProcessDate = dr.GetDateTime(0);
                                dc.ManufacturingShift=dr.GetString(1);
                                dc.CodingDetailShift=dr.GetString(2);
                                dc.PackingDeatialShift=dr.GetString(3);
                                dc.RequisitionNo=dr.GetString(4);
                                dc.ProcessNo=dr.GetString(5);
                                dc.FGName=dr.GetString(6);
                                dc.MaterialCode=dr.GetString(7);
                                dc.MaterialName=dr.GetString(8);

                                dc.BaseUnit=dr.GetString(9);
                                dc.StdConsumptionQty=dr.GetDecimal(10);
                                dc.OpeningStock = dr.GetDecimal(11);
                                dc.IssueQty=dr.GetDecimal(12);
                                dc.ReturnQty=dr.GetDecimal(13);
                                dc.TotalConsumption=dr.GetDecimal(14);
                                dc.ClosingStock=dr.GetDecimal(15);
                                dc.LossAccess=dr.GetDecimal(16);
                                dc.Yield=dr.GetDecimal(17);
                                
                                data.Add(dc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            return View(data);
        }
        
    }

}