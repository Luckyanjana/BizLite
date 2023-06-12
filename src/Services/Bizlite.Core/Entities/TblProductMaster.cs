using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblProductMaster
{
    public long ProductIdno { get; set; }

    public string? ProductName { get; set; }

    public int? PtypeIdno { get; set; }

    public DateTime? DateOn { get; set; }

    public int? TermIdno { get; set; }

    public double? ProductPrice { get; set; }

    public int? NumberOfSittings { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public long? ModifiedByUserIdno { get; set; }
}
