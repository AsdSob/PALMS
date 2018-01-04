using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PALMS.Data.Objects.NoteModel
{
    public class NoteStatus
    {
        [Key]
        public int NoteId { get; set; }

        public string StatusName { get; set; }

        public virtual ICollection<DeliveryNote> DeliveryNotes { get; set; }
        public virtual ICollection<ReceivingNote> ReceivingNotes { get; set; }
    }
}
