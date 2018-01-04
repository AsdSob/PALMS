using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PALMS.Data.Objects.LinenModel
{
    public class TypeLinen 
    {
        [Key]
        public int TypeId { get; set; }

        [Required]
        public string TypeName { get; set; }

        public virtual ICollection<MasterLinen> MasterLinens { get; set; }
    }
}
