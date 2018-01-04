using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PALMS.Data.Objects.NoteModel;

namespace PALMS.Data.Objects.ClientModel
{
    public class DepartmentList
    {
        [Key, ForeignKey("Department"), Column(Order = 2)]
        public int DepartmentId { get; set; }

        [Key, ForeignKey("Client"), Column(Order = 1)]
        public int ClientId { get; set; }


        public virtual Department Department { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<ReceivingNote> ReceivingNotes { get; set; }
        public virtual ICollection<DeliveryNote> DeliveryNotes { get; set; }
    }
}
