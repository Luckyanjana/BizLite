using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblSourceMaster
{
    public long SourceIdno { get; set; }

    public string? SourceName { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public long? ModifiedByUserIdno { get; set; }
}
