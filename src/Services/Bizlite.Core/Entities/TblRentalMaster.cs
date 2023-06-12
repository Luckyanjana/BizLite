using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblRentalMaster
{
    public int RentalId { get; set; }

    public int? AreaId { get; set; }

    public double? AreaRent { get; set; }

    public int? RentType { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public double? Duration { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public long? ModifiedByUserIdno { get; set; }

    public virtual TblAreaMaster? Area { get; set; }
}
