using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PALMS.Data.Objects.LinenModel;

namespace PALMS.Data.Objects.NoteModel
{
    public class DeliveryNoteRows 
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("DeliveryNote")]
        public int DeliveryNoteId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("MasterLinen")]
        public int LinenId { get; set; }

        public int Quantity { get; set; }
        public int? LinenWeight { get; set; }
        public float? LinenPrice { get; set; }
        public int? RFIDPrice { get; set; }

        public virtual MasterLinen MasterLinen { get; set; }
        public virtual DeliveryNote DeliveryNote { get; set; }
        //public ICollection<DeliveryNote> DeliveryNotes { get; set; }

    }
}
