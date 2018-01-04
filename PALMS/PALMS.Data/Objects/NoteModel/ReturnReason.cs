using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PALMS.Data.Objects.NoteModel
{
    public class ReturnReason
    {
        [Key]
        public int ReturnReasonId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ReturnOrderRows> ReturnOrderRowses { get; set; }
    }
}
