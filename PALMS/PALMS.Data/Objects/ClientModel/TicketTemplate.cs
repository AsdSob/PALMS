using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PALMS.Data.Objects.ClientModel
{
    public class TicketTemplate 
    {
        [Key]
        public int TicketId { get; set; }

        public string TicketName { get; set; }

        public virtual ICollection<ClientInfo> ClientInfos { get; set; }
    }
}
