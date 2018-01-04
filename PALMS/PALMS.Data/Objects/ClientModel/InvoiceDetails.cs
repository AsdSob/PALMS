using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PALMS.Data.Objects.ClientModel
{
    public class InvoiceDetail
    {
        [Key]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [ForeignKey("Payment")]
        public int PaymentId { get; set; }

        public float MonthlyCharge { get; set; }
        public float WeightCharge { get; set; }
        public int ExpressCharge { get; set; }
        public float ExtraCharge { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public int VAT { get; set; }

        public virtual Client Client { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
