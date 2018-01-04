using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PALMS.Data.Objects.ClientModel
{
    public class ClientInfo
    {
        [Key]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public string City { get; set; }
        public string Comment { get; set; }
        public DateTime? JoinDate { get; set; }

        [ForeignKey("TicketTemplate")]
        public int TicketId { get; set; }
        [ForeignKey("NoteTemplate")]
        public int NoteId { get; set; }
        [ForeignKey("InvoiceTemplate")]
        public int InvoiceId { get; set; }

        public virtual Client Client { get; set; }
        public virtual InvoiceTemplate InvoiceTemplate { get; set; }
        public virtual TicketTemplate TicketTemplate { get; set; }
        public virtual NoteTemplate NoteTemplate { get; set; }
    }
}
