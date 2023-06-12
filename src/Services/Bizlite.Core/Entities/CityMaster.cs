using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class CityMaster
{
    public long CityIdno { get; set; }

    public long? StateIdno { get; set; }

    public string Name { get; set; } = null!;

    public string? Abbreviation { get; set; }

    public bool? Status { get; set; }

    public int? YearIdno { get; set; }

    public int? CompIdno { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public long? CountryIdno { get; set; }

    public string? CountryName { get; set; }

    public string? StateName { get; set; }

    public long? ErpCityIdno { get; set; }

    public long? ErpStateIdno { get; set; }

    public long? ErpCountryIdno { get; set; }

    public bool? IsMetro { get; set; }
}
