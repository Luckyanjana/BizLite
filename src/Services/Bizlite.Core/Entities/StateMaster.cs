using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class StateMaster
{
    public long StateIdno { get; set; }

    public string? Name { get; set; }

    public string? Abbreviation { get; set; }

    public bool? Status { get; set; }

    public int? YearIdno { get; set; }

    public int? CompIdno { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public bool UnionTeritory { get; set; }

    public string? GststateCode { get; set; }

    public long? CountryIdno { get; set; }

    public virtual ICollection<TblEmployee> TblEmployees { get; set; } = new List<TblEmployee>();

    public virtual ICollection<TblLedgerAccountMaster> TblLedgerAccountMasters { get; set; } = new List<TblLedgerAccountMaster>();
}
