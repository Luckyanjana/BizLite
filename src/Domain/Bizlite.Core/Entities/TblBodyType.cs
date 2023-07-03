using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblBodyType
{
    public long BodyIdno { get; set; }

    public string? BodyName { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public long? ModifiedByUserIdno { get; set; }

    public virtual ICollection<TblLedgerAccountMaster> TblLedgerAccountMasters { get; set; } = new List<TblLedgerAccountMaster>();
}
