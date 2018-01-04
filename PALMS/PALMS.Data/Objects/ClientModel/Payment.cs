using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PALMS.Data.Objects.ClientModel
{
    public class Payment 
    {   
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public string PaymentType { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
