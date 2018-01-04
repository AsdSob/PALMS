using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PALMS.Data.Objects.NoteModel;

namespace PALMS.Data.Objects.LinenModel
{
    public class MasterLinen
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LinenId { get; set; }

        public string Nomination { get; set; }

        [ForeignKey("TypeLinen")]
        public int TypeId { get; set; }

        [ForeignKey("FamilyLinen")]
        public int FamilyId { get; set; }

        [ForeignKey("GroupLinen")]
        public int GroupId { get; set; }

        public virtual ICollection<LinenList> LinenLists { get; set; }
        public virtual ICollection<DeliveryNoteRows> DeliveryNoteRowses { get; set; }
        public virtual ICollection<ReturnOrderRows> ReturnOrderRowses { get; set; }
        public virtual ICollection<ReceivingNoteRows> ReceivingNoteRowses { get; set; }
        
        public virtual TypeLinen TypeLinen { get; set; }
        public virtual FamilyLinen FamilyLinen { get; set; }
        public virtual GroupLinen GroupLinen { get; set; }

    }
}
