using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblMainHeadGroup
{
    public int MainId { get; set; }

    public string? HeadGroupName { get; set; }

    public virtual ICollection<TblGroupMaster> TblGroupMasters { get; set; } = new List<TblGroupMaster>();
}
