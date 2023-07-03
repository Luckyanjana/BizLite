using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblSubGroupMaster
{
    public int SubGroupId { get; set; }

    public int? GroupId { get; set; }

    public string? SubGroupName { get; set; }

    public bool? ActiveStatus { get; set; }

    public DateTime? DateAdded { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public DateTime? DateModified { get; set; }

    public long? ModifiedByUserIdno { get; set; }

    public virtual TblGroupMaster? Group { get; set; }

    public virtual ICollection<TblLedgerAccountMaster> TblLedgerAccountMasters { get; set; } = new List<TblLedgerAccountMaster>();
}
