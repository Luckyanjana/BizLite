using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblRateMaster
{
    public long RateIdno { get; set; }

    public long? MembershipIdno { get; set; }

    public double? MemberhipRate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public long? ModifiedByUserIdno { get; set; }

    public virtual TblMembership? MembershipIdnoNavigation { get; set; }
}
