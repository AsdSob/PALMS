using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PALMS.Data.Objects.LinenModel
{
    public class FamilyLinen 
    {
        [Key]
        public int FamilyId { get; set; }

        public string FamilyName { get; set; }

        public virtual ICollection<MasterLinen> MasterLinens { get; set; }
    }
}
