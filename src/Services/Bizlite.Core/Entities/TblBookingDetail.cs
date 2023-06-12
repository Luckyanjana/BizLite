using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblBookingDetail
{
    public long BisrdetlIdno { get; set; }

    public long? BisrheadIdno { get; set; }

    public long? AreaIdno { get; set; }

    public long? RentId { get; set; }

    public virtual TblBookingHead? BisrheadIdnoNavigation { get; set; }
}
