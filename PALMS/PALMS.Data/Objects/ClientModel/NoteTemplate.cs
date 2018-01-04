using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PALMS.Data.Objects.ClientModel
{
    public class NoteTemplate 
    {
        [Key]
        public int NoteId { get; set; }

        public string NoteName { get; set; }

        public virtual ICollection<ClientInfo> ClientInfos { get; set; }
    }
}
