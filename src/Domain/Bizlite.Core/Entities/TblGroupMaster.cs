using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblGroupMaster
{
    public int AccGroupId { get; set; }

    public int? HeadGrId { get; set; }

    public string? AccGroupName { get; set; }

    public bool? ActiveStatus { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public long? ModifiedByUserIdno { get; set; }

    public virtual TblMainHeadGroup? HeadGr { get; set; }

    public virtual ICollection<TblSubGroupMaster> TblSubGroupMasters { get; set; } = new List<TblSubGroupMaster>();
}
