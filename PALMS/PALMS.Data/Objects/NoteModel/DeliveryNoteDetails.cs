using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PALMS.Data.Objects.NoteModel
{
    public class DeliveryNoteDetails
    {
        [Key]
        [ForeignKey("DeliveryNote")]
        public int DeliveryNoteId { get; set; }

        public int ExpressCharge { get; set; }
        public float WeightCharge { get; set; }
        public int MonthlyCharge { get; set; }
        public int ExtraCharge { get; set; }

        [ForeignKey("DeliveryType")]
        public int DeliveryTypeId { get; set; }


        public virtual DeliveryType DeliveryType { get; set; }
        public virtual DeliveryNote DeliveryNote { get; set; }
    }
}
