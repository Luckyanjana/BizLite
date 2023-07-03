using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblBrandMaster
{
    public long BrandIdno { get; set; }

    public string? BrandName { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public long? ModifiedByUserIdno { get; set; }

    public virtual ICollection<TblEquipmentMaster> TblEquipmentMasters { get; set; } = new List<TblEquipmentMaster>();
}
