using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PALMS.Data.Objects.ClientModel
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public virtual ICollection<DepartmentList> DepartmentLists { get; set; }

    }
}
