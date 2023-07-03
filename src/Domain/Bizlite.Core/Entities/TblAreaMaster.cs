using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblAreaMaster
{
    public int AreaId { get; set; }

    public string? AreaName { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public long? ModifiedByUserIdno { get; set; }

    public virtual ICollection<TblRentalMaster> TblRentalMasters { get; set; } = new List<TblRentalMaster>();
}
