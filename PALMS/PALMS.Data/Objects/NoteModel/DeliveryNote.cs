using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PALMS.Data.Objects.ClientModel;

namespace PALMS.Data.Objects.NoteModel
{
    public class DeliveryNote
    {
        [Key]
        public int DNoteId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public int NoteStatusId { get; set; }

        public DateTime DeliveryDate { get; set; }
        public string Comments { get; set; }
        public int? ReceivingNoteId { get; set; }
        public int? ReturnOrderId { get; set; }

        [ForeignKey("DeliveryType")]
        public int DeliveryTypeId { get; set; }

        //[ForeignKey("DepartmentList")]
        public int DepartmentID { get; set; }


        public virtual ICollection<DeliveryNoteRows> DeliveryNoteRowses { get; set; }
        public virtual ICollection<InvoiceRow> InvoiceRows { get; set; }
        public virtual DeliveryNoteDetails DeliveryNoteDetails { get; set; }

        public virtual Client Client { get; set; }
        public virtual DepartmentList DepartmentList { get; set; }

        public virtual ReceivingNote ReceivingNote { get; set; }
        public virtual ReturnOrder ReturnOrder { get; set; }
        public virtual DeliveryType DeliveryType { get; set; }

    }
}
