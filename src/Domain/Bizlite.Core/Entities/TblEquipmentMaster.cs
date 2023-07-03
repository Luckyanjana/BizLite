using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblEquipmentMaster
{
    public long EqupIdno { get; set; }

    public string? EqupName { get; set; }

    public long? BrandIdno { get; set; }

    public double? TotalQty { get; set; }

    public double? PricePerQty { get; set; }

    public double? TotalPrice { get; set; }

    public string? Remark { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public long? ModifiedByUserIdno { get; set; }

    public DateTime? WarrantyUpto { get; set; }

    public virtual TblBrandMaster? BrandIdnoNavigation { get; set; }
}
