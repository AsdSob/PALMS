using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PALMS.Data.Objects.ClientModel;

namespace PALMS.Data.Objects.NoteModel
{
    public class ReturnOrder
    {
        [Key]
        public int ReturnOrderId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public DateTime? ReceivingDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<ReturnOrderRows> ReturnOrderRowses { get; set; }
    }
}
