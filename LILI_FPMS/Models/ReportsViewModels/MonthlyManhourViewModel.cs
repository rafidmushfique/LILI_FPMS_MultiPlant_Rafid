using System.ComponentModel;

namespace LILI_IMS.Models.ReprotsViewModels
{
    public class MonthlyManhourViewModel
    {
        public int Id { get; set; }

        [DisplayName("ProductCode")]
        public string ProductCode { get; set; }

        [DisplayName("ProductName")]
        public string ProductName { get; set; }

        [DisplayName("Pack Size")]
        public string PackSize { get; set; }

        [DisplayName("Month Production")]
        public string ProductionQty { get; set; }

        [DisplayName("Total Man-Power Worker")]
        public string NoOfWorker { get; set; }

        [DisplayName("Total Man-Power Common")]
        public string CommonNoOfWorker { get; set; }

        [DisplayName("Worker Man Hrs")]
        public string WorkerManHour { get; set; }

        [DisplayName("Common Man hrs")]
        public string CommonManHour { get; set; }

        [DisplayName("Total Man Hrs")]
        public string TotalManHour { get; set; }

        [DisplayName("Man-Hour/Unit")]
        public string ManHourPerProductUnit { get; set; }


    }
}