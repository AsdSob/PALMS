using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PALMS.Data.Objects.ClientModel;

namespace PALMS.Data.Objects.LinenModel
{
    public class LinenList 
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("MasterLinen")]
        public int LinenId { get; set; }

        public bool Active { get; set; }
        public int Weight { get; set; }
        public float Price { get; set; }
        public int RFID { get; set; }

        public virtual Client Client { get; set; }
        public virtual MasterLinen MasterLinen { get; set; }
    }
}
