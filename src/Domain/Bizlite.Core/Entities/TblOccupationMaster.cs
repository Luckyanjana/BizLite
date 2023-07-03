using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblOccupationMaster
{
    public long OccupId { get; set; }

    public string? OccupationName { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public long? ModifiedByUserIdno { get; set; }
}
