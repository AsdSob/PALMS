using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PALMS.Data.Objects.LinenModel;

namespace PALMS.Data.Objects.NoteModel
{
    public class ReceivingNoteRows
    {
        [Key, Column(Order = 1), ForeignKey("ReceivingNote")]
        public int ReceivingNoteId { get; set; }

        [Key, Column(Order = 2), ForeignKey("MasterLinen")]
        public int LinenId { get; set; }

        public int Quantity { get; set; }

        public virtual MasterLinen MasterLinen { get; set; }
        public virtual ReceivingNote ReceivingNote { get; set; }
    }
}
