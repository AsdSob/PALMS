using System;

namespace PALMS.Data.Objects
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? DeletedDate { get; set; }
        bool IsNew { get; }
    }


}