using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblBookingHead
{
    public long BisrheadIdno { get; set; }

    public DateTime? BisrDate { get; set; }

    public int? ClientId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateAdded { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public DateTime? DateModified { get; set; }

    public long? ModifiedByUserIdno { get; set; }

    public virtual ICollection<TblBookingDetail> TblBookingDetails { get; set; } = new List<TblBookingDetail>();
}
