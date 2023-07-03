using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblCityAreaMaster
{
    public long CityareaIdno { get; set; }

    public long? StateIdno { get; set; }

    public long? CityIdno { get; set; }

    public string? AreaName { get; set; }

    public int? PinCode { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public long? ModifiedByUserIdno { get; set; }
}
