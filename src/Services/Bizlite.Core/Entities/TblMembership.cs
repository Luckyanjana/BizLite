using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblMembership
{
    public long MembershipIdno { get; set; }

    public string? MembershipName { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public long? ModifiedByUserIdno { get; set; }

    public virtual ICollection<TblLedgerAccountMaster> TblLedgerAccountMasters { get; set; } = new List<TblLedgerAccountMaster>();

    public virtual ICollection<TblRateMaster> TblRateMasters { get; set; } = new List<TblRateMaster>();
}
