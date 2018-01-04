using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PALMS.Data.Objects.LinenModel;
using PALMS.Data.Objects.NoteModel;

namespace PALMS.Data.Objects.ClientModel
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        public string ClientName { get; set; }
        public string ShortName { get; set; }
        public string Color { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<LinenList> LinenLists { get; set; }
        public virtual ICollection<DeliveryNote> DeliveryNotes { get; set; }
        public virtual ICollection<ReceivingNote> ReceivingNotes { get; set; }
        public virtual ICollection<ReturnOrder> ReturnOrders { get; set; }
        public virtual ICollection<DepartmentList> DepartmentLists { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual ClientInfo ClientInfo { get; set; }
        public virtual InvoiceDetail InvoiceDetail { get; set; }
    }
}
