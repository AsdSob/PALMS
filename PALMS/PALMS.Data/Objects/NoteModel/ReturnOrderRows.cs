using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PALMS.Data.Objects.LinenModel;

namespace PALMS.Data.Objects.NoteModel
{
    public class ReturnOrderRows
    {
        [Key, ForeignKey("ReturnOrder"), Column(Order = 1)]
        public int ReturnOrderId { get; set; }

        [Key, ForeignKey("MasterLinen"), Column(Order = 2)]
        public int LinenId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("ReturnReason")]
        public int ReturnReasonId { get; set; }

        public virtual ReturnReason ReturnReason { get; set; }
        public virtual MasterLinen MasterLinen { get; set; }
        public virtual ReturnOrder ReturnOrder { get; set; }

    }
}
