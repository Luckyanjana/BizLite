using System;
using System.Collections.Generic;

namespace Bizlite.Core.Entities;

public partial class TblLedgerAccountMaster
{
    public long LedgerId { get; set; }

    public int? SubGroupId { get; set; }

    public long? BodyTypeIdno { get; set; }

    public long? MembershipIdno { get; set; }

    public int? TitleNameIdno { get; set; }

    public long? YearIdno { get; set; }

    public string? PartyName { get; set; }

    public int? AccountTypeId { get; set; }

    public double? OpeningBalance { get; set; }

    public string? BalanceType { get; set; }

    public int? PinCode { get; set; }

    public string? ContactPersonName { get; set; }

    public long? Mobile { get; set; }

    public string? Email { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public long? StateIdno { get; set; }

    public long? CityIdno { get; set; }

    public bool? ActiveStatus { get; set; }

    public DateTime? DateOn { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateModified { get; set; }

    public long? AddedbyUserIdno { get; set; }

    public long? ModifiedByUserIdno { get; set; }

    public virtual TblBodyType? BodyTypeIdnoNavigation { get; set; }

    public virtual TblMembership? MembershipIdnoNavigation { get; set; }

    public virtual StateMaster? StateIdnoNavigation { get; set; }

    public virtual TblSubGroupMaster? SubGroup { get; set; }

    public virtual FinYear? YearIdnoNavigation { get; set; }
}
