using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PALMS.Data.Objects.NoteModel
{
    public class DeliveryType
    {
        [Key]
        public int DeliveryTypeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<DeliveryNote> DeliveryNotes { get; set; }
    }
}
