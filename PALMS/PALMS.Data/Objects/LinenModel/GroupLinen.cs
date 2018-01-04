using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PALMS.Data.Objects.LinenModel
{
    public class GroupLinen 
    {
        [Key]
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public virtual ICollection<MasterLinen> MasterLinens { get; set; }
    }
}
