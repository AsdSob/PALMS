using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PALMS.Data.Objects.ClientModel
{
    public class InvoiceTemplate
    {
        [Key]
        public int InvoiciID { get; set; }

        public string InvoiceName { get; set; }

        public virtual ICollection<ClientInfo> ClientInfos { get; set; }
    }
}
