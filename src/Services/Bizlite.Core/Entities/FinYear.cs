using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class FinYear
{
    public long FinIdno { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public long? CompId { get; set; }

    public bool? YrHndParts { get; set; }

    public bool? YrHndVehicle { get; set; }

    public bool? YrHndAccounts { get; set; }

    public int? IsActive { get; set; }

    public virtual ICollection<TblLedgerAccountMaster> TblLedgerAccountMasters { get; set; } = new List<TblLedgerAccountMaster>();
}
