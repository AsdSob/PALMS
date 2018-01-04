using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PALMS.Data.Objects.ClientModel;

namespace PALMS.Data.Objects.NoteModel
{
    public class ReceivingNote
    {
        [Key]
        public int ReceivingNoteId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public DateTime ReceivingDate { get; set; }
        public int NoteStatusId { get; set; }

        //[ForeignKey("DepartmentList")]
        public int DepartmentId { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<ReceivingNoteRows> ReceivingNoteRowses { get; set; }
        public virtual DepartmentList DepartmentList { get; set; }

    }
}
