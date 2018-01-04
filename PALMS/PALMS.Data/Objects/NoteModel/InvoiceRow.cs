using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PALMS.Data.Objects.NoteModel
{
   public class InvoiceRow
    {
        [Key]
        [Column(Order = 2)]
        [ForeignKey("DeliveryNote")]
        public int DeliveryNoteId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        
        public virtual Invoice Invoice { get; set; }
        public virtual DeliveryNote DeliveryNote { get; set; }

    }
}
