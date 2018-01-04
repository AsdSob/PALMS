using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PALMS.Data.Objects.ClientModel;

namespace PALMS.Data.Objects.NoteModel
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public DateTime Date { get; set; }
        public int? MonthlyCharge { get; set; }
        public float? WeightCharge { get; set; }
        public int? ExtraCharge { get; set; }
        public int? VAT { get; set; }
        public float? ExtraWeight { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<InvoiceRow> InvoiceRows { get; set; }
    }
}
