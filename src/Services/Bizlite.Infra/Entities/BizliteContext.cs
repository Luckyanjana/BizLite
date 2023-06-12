using System;
using System.Collections.Generic;
using Bizlite.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Core = Bizlite.Core.Entities;

namespace Bizlite.Infra.Entities;

public partial class BizliteContext : DbContext
{
    public BizliteContext()
    {
    }

    public BizliteContext(DbContextOptions<BizliteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CityMaster> CityMasters { get; set; }

    public virtual DbSet<FinYear> FinYears { get; set; }

    public virtual DbSet<StateMaster> StateMasters { get; set; }

    public virtual DbSet<TblAreaMaster> TblAreaMasters { get; set; }

    public virtual DbSet<TblBodyType> TblBodyTypes { get; set; }

    public virtual DbSet<TblBookingDetail> TblBookingDetails { get; set; }

    public virtual DbSet<TblBookingHead> TblBookingHeads { get; set; }

    public virtual DbSet<TblBrandMaster> TblBrandMasters { get; set; }

    public virtual DbSet<TblCityAreaMaster> TblCityAreaMasters { get; set; }

    public virtual DbSet<TblEquipmentMaster> TblEquipmentMasters { get; set; }

    public virtual DbSet<TblGroupMaster> TblGroupMasters { get; set; }

    public virtual DbSet<TblLedgerAccountMaster> TblLedgerAccountMasters { get; set; }

    public virtual DbSet<TblMainHeadGroup> TblMainHeadGroups { get; set; }

    public virtual DbSet<TblMembership> TblMemberships { get; set; }

    public virtual DbSet<TblOccupationMaster> TblOccupationMasters { get; set; }

    public virtual DbSet<TblProductMaster> TblProductMasters { get; set; }

    public virtual DbSet<TblProductType> TblProductTypes { get; set; }

    public virtual DbSet<TblRateMaster> TblRateMasters { get; set; }

    public virtual DbSet<TblRentalMaster> TblRentalMasters { get; set; }

    public virtual DbSet<TblSourceMaster> TblSourceMasters { get; set; }

    public virtual DbSet<TblSubGroupMaster> TblSubGroupMasters { get; set; }

    public virtual DbSet<TblTermMaster> TblTermMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CityMaster>(entity =>
        {
            entity.HasKey(e => e.CityIdno);

            entity.ToTable("CityMaster");

            entity.Property(e => e.CityIdno).HasColumnName("City_Idno");
            entity.Property(e => e.Abbreviation).HasMaxLength(10);
            entity.Property(e => e.CompIdno).HasColumnName("Comp_Idno");
            entity.Property(e => e.CountryIdno).HasColumnName("Country_Idno");
            entity.Property(e => e.CountryName)
                .HasMaxLength(250)
                .HasColumnName("Country_Name");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.ErpCityIdno).HasColumnName("ERP_City_Idno");
            entity.Property(e => e.ErpCountryIdno).HasColumnName("ERP_Country_Idno");
            entity.Property(e => e.ErpStateIdno).HasColumnName("ERP_State_Idno");
            entity.Property(e => e.IsMetro).HasColumnName("Is_Metro");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.StateIdno).HasColumnName("State_Idno");
            entity.Property(e => e.StateName)
                .HasMaxLength(250)
                .HasColumnName("State_Name");
            entity.Property(e => e.YearIdno).HasColumnName("Year_Idno");
        });

        modelBuilder.Entity<FinYear>(entity =>
        {
            entity.HasKey(e => e.FinIdno);

            entity.ToTable("FinYear");

            entity.Property(e => e.FinIdno).HasColumnName("Fin_Idno");
            entity.Property(e => e.CompId).HasDefaultValueSql("((0))");
            entity.Property(e => e.EndDate)
                .HasDefaultValueSql("('')")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("('')")
                .HasColumnType("datetime");
            entity.Property(e => e.YrHndAccounts)
                .HasDefaultValueSql("((0))")
                .HasColumnName("YrHnd_Accounts");
            entity.Property(e => e.YrHndParts)
                .HasDefaultValueSql("((0))")
                .HasColumnName("YrHnd_Parts");
            entity.Property(e => e.YrHndVehicle)
                .HasDefaultValueSql("((0))")
                .HasColumnName("YrHnd_Vehicle");
        });

        modelBuilder.Entity<StateMaster>(entity =>
        {
            entity.HasKey(e => e.StateIdno);

            entity.ToTable("StateMaster");

            entity.Property(e => e.StateIdno).HasColumnName("State_Idno");
            entity.Property(e => e.Abbreviation).HasMaxLength(50);
            entity.Property(e => e.CompIdno).HasColumnName("Comp_Idno");
            entity.Property(e => e.CountryIdno).HasColumnName("Country_Idno");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.GststateCode)
                .HasMaxLength(5)
                .HasDefaultValueSql("('')")
                .HasColumnName("GSTState_Code");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UnionTeritory).HasColumnName("Union_Teritory");
            entity.Property(e => e.YearIdno).HasColumnName("Year_Idno");
        });

        modelBuilder.Entity<TblAreaMaster>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK_AreaMasterTB");

            entity.ToTable("tblAreaMaster");

            entity.Property(e => e.AreaId).HasColumnName("Area_ID");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.AreaName)
                .HasMaxLength(50)
                .HasColumnName("Area_Name");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");
        });

        modelBuilder.Entity<TblBodyType>(entity =>
        {
            entity.HasKey(e => e.BodyIdno);

            entity.ToTable("tblBodyType");

            entity.Property(e => e.BodyIdno).HasColumnName("Body_Idno");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.BodyName)
                .HasMaxLength(250)
                .HasColumnName("Body_Name");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");
        });

        modelBuilder.Entity<TblBookingDetail>(entity =>
        {
            entity.HasKey(e => e.BisrdetlIdno).HasName("PK_BISRDetl");

            entity.ToTable("tblBookingDetail");

            entity.Property(e => e.BisrdetlIdno).HasColumnName("BISRDetl_Idno");
            entity.Property(e => e.AreaIdno).HasColumnName("Area_Idno");
            entity.Property(e => e.BisrheadIdno).HasColumnName("BISRHead_Idno");
            entity.Property(e => e.RentId).HasColumnName("Rent_id");

            entity.HasOne(d => d.BisrheadIdnoNavigation).WithMany(p => p.TblBookingDetails)
                .HasForeignKey(d => d.BisrheadIdno)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_BISRDetl_BISRDetl");
        });

        modelBuilder.Entity<TblBookingHead>(entity =>
        {
            entity.HasKey(e => e.BisrheadIdno).HasName("PK_BISRHead");

            entity.ToTable("tblBookingHead");

            entity.Property(e => e.BisrheadIdno).HasColumnName("BISRHead_Idno");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.BisrDate)
                .HasColumnType("date")
                .HasColumnName("BISR_Date");
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");
        });

        modelBuilder.Entity<TblBrandMaster>(entity =>
        {
            entity.HasKey(e => e.BrandIdno);

            entity.ToTable("tblBrandMaster");

            entity.Property(e => e.BrandIdno).HasColumnName("Brand_Idno");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.BrandName)
                .HasMaxLength(250)
                .HasColumnName("Brand_Name");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");
        });

        modelBuilder.Entity<TblCityAreaMaster>(entity =>
        {
            entity.HasKey(e => e.CityareaIdno);

            entity.ToTable("tblCityAreaMaster");

            entity.Property(e => e.CityareaIdno).HasColumnName("Cityarea_Idno");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.AreaName)
                .HasMaxLength(250)
                .HasColumnName("Area_name");
            entity.Property(e => e.CityIdno).HasColumnName("City_Idno");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");
            entity.Property(e => e.PinCode).HasColumnName("Pin_Code");
            entity.Property(e => e.StateIdno).HasColumnName("State_Idno");
        });

        modelBuilder.Entity<TblEquipmentMaster>(entity =>
        {
            entity.HasKey(e => e.EqupIdno);

            entity.ToTable("tblEquipmentMaster");

            entity.Property(e => e.EqupIdno).HasColumnName("Equp_Idno");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.BrandIdno).HasColumnName("Brand_Idno");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.EqupName)
                .HasMaxLength(250)
                .HasColumnName("Equp_Name");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");
            entity.Property(e => e.PricePerQty).HasColumnName("Price_PerQty");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("date")
                .HasColumnName("Purchase_Date");
            entity.Property(e => e.TotalPrice).HasColumnName("Total_Price");
            entity.Property(e => e.WarrantyUpto)
                .HasColumnType("date")
                .HasColumnName("Warranty_upto");

            entity.HasOne(d => d.BrandIdnoNavigation).WithMany(p => p.TblEquipmentMasters)
                .HasForeignKey(d => d.BrandIdno)
                .HasConstraintName("FK_tblEquipmentMaster_tblBrandMaster");
        });

        modelBuilder.Entity<TblGroupMaster>(entity =>
        {
            entity.HasKey(e => e.AccGroupId).HasName("PK_AccountGroupMasterTB");

            entity.ToTable("tblGroupMaster");

            entity.Property(e => e.AccGroupId).HasColumnName("Acc_group_id");
            entity.Property(e => e.AccGroupName)
                .HasMaxLength(200)
                .HasColumnName("Acc_group_name");
            entity.Property(e => e.ActiveStatus).HasColumnName("Active_status");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.HeadGrId).HasColumnName("head_grId");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");

            entity.HasOne(d => d.HeadGr).WithMany(p => p.TblGroupMasters)
                .HasForeignKey(d => d.HeadGrId)
                .HasConstraintName("FK_AccountGroupMasterTB_AccountGroupMasterTB");
        });

        modelBuilder.Entity<TblLedgerAccountMaster>(entity =>
        {
            entity.HasKey(e => e.LedgerId).HasName("PK_LedgerAccountMasterTB");

            entity.ToTable("tblLedgerAccountMaster");

            entity.Property(e => e.LedgerId).HasColumnName("ledger_id");
            entity.Property(e => e.AccountTypeId).HasColumnName("account_typeId");
            entity.Property(e => e.ActiveStatus).HasColumnName("active_status");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.Address1)
                .HasMaxLength(250)
                .HasColumnName("address_1");
            entity.Property(e => e.Address2)
                .HasMaxLength(250)
                .HasColumnName("address_2");
            entity.Property(e => e.BalanceType)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("balance_type");
            entity.Property(e => e.BodyTypeIdno).HasColumnName("BodyType_Idno");
            entity.Property(e => e.CityIdno).HasColumnName("city_Idno");
            entity.Property(e => e.ContactPersonName)
                .HasMaxLength(50)
                .HasColumnName("contact_person_name");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.DateOn)
                .HasColumnType("date")
                .HasColumnName("Date_On");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.MembershipIdno).HasColumnName("Membership_Idno");
            entity.Property(e => e.Mobile).HasColumnName("mobile");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");
            entity.Property(e => e.OpeningBalance).HasColumnName("opening_balance");
            entity.Property(e => e.PartyName)
                .HasMaxLength(250)
                .HasColumnName("party_name");
            entity.Property(e => e.PinCode).HasColumnName("pin_code");
            entity.Property(e => e.StateIdno).HasColumnName("state_Idno");
            entity.Property(e => e.SubGroupId).HasColumnName("sub_group_id");
            entity.Property(e => e.TitleNameIdno).HasColumnName("title_name_Idno");
            entity.Property(e => e.YearIdno).HasColumnName("Year_Idno");

            entity.HasOne(d => d.BodyTypeIdnoNavigation).WithMany(p => p.TblLedgerAccountMasters)
                .HasForeignKey(d => d.BodyTypeIdno)
                .HasConstraintName("FK_tblLedgerAccountMaster_tblBodyType");

            entity.HasOne(d => d.MembershipIdnoNavigation).WithMany(p => p.TblLedgerAccountMasters)
                .HasForeignKey(d => d.MembershipIdno)
                .HasConstraintName("FK_tblLedgerAccountMaster_tblMembership");

            entity.HasOne(d => d.StateIdnoNavigation).WithMany(p => p.TblLedgerAccountMasters)
                .HasForeignKey(d => d.StateIdno)
                .HasConstraintName("FK_LedgerAccountMasterTB_LedgerAccountMasterTB1");

            entity.HasOne(d => d.SubGroup).WithMany(p => p.TblLedgerAccountMasters)
                .HasForeignKey(d => d.SubGroupId)
                .HasConstraintName("FK_LedgerAccountMasterTB_Acc_Sub_Group_MasterTB");

            entity.HasOne(d => d.YearIdnoNavigation).WithMany(p => p.TblLedgerAccountMasters)
                .HasForeignKey(d => d.YearIdno)
                .HasConstraintName("FK_LedgerAccountMasterTB_LedgerAccountMasterTB");
        });

        modelBuilder.Entity<TblMainHeadGroup>(entity =>
        {
            entity.HasKey(e => e.MainId).HasName("PK_Head_GroupTB");

            entity.ToTable("tblMainHeadGroup");

            entity.Property(e => e.MainId).HasColumnName("Main_Id");
            entity.Property(e => e.HeadGroupName)
                .HasMaxLength(200)
                .HasColumnName("head_group_name");
        });

        modelBuilder.Entity<TblMembership>(entity =>
        {
            entity.HasKey(e => e.MembershipIdno);

            entity.ToTable("tblMembership");

            entity.Property(e => e.MembershipIdno).HasColumnName("Membership_Idno");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.MembershipName)
                .HasMaxLength(250)
                .HasColumnName("Membership_Name");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");
        });

        modelBuilder.Entity<TblOccupationMaster>(entity =>
        {
            entity.HasKey(e => e.OccupId);

            entity.ToTable("tblOccupationMaster");

            entity.Property(e => e.OccupId).HasColumnName("Occup_Id");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");
            entity.Property(e => e.OccupationName)
                .HasMaxLength(250)
                .HasColumnName("Occupation_Name");
        });

        modelBuilder.Entity<TblProductMaster>(entity =>
        {
            entity.HasKey(e => e.ProductIdno);

            entity.ToTable("tblProductMaster");

            entity.Property(e => e.ProductIdno).HasColumnName("Product_Idno");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.DateOn)
                .HasColumnType("date")
                .HasColumnName("Date_on");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");
            entity.Property(e => e.NumberOfSittings).HasColumnName("Number_of_sittings");
            entity.Property(e => e.ProductName)
                .HasMaxLength(250)
                .HasColumnName("Product_name");
            entity.Property(e => e.ProductPrice).HasColumnName("Product_price");
            entity.Property(e => e.PtypeIdno).HasColumnName("Ptype_Idno");
            entity.Property(e => e.TermIdno).HasColumnName("Term_Idno");
        });

        modelBuilder.Entity<TblProductType>(entity =>
        {
            entity.HasKey(e => e.ProTypeIdno);

            entity.ToTable("tblProductType");

            entity.Property(e => e.ProTypeIdno).HasColumnName("ProType_Idno");
            entity.Property(e => e.ProductTypeName)
                .HasMaxLength(250)
                .HasColumnName("ProductType_name");
        });

        modelBuilder.Entity<TblRateMaster>(entity =>
        {
            entity.HasKey(e => e.RateIdno);

            entity.ToTable("tblRateMaster");

            entity.Property(e => e.RateIdno).HasColumnName("Rate_Idno");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.MemberhipRate).HasColumnName("Memberhip_Rate");
            entity.Property(e => e.MembershipIdno).HasColumnName("Membership_Idno");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");

            entity.HasOne(d => d.MembershipIdnoNavigation).WithMany(p => p.TblRateMasters)
                .HasForeignKey(d => d.MembershipIdno)
                .HasConstraintName("FK_tblRateMaster_tblMembership");
        });

        modelBuilder.Entity<TblRentalMaster>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PK_RentalMaster");

            entity.ToTable("tblRentalMaster");

            entity.Property(e => e.RentalId).HasColumnName("Rental_id");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.AreaId).HasColumnName("Area_id");
            entity.Property(e => e.AreaRent).HasColumnName("Area_Rent");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.EffectiveDate)
                .HasColumnType("date")
                .HasColumnName("Effective_Date");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");
            entity.Property(e => e.RentType).HasColumnName("Rent_Type");

            entity.HasOne(d => d.Area).WithMany(p => p.TblRentalMasters)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK_RentalMasterTB_AreaMasterTB");
        });

        modelBuilder.Entity<TblSourceMaster>(entity =>
        {
            entity.HasKey(e => e.SourceIdno);

            entity.ToTable("tblSourceMaster");

            entity.Property(e => e.SourceIdno).HasColumnName("Source_Idno");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");
            entity.Property(e => e.SourceName)
                .HasMaxLength(250)
                .HasColumnName("Source_name");
        });

        modelBuilder.Entity<TblSubGroupMaster>(entity =>
        {
            entity.HasKey(e => e.SubGroupId).HasName("PK_Acc_Sub_Group_MasterTB");

            entity.ToTable("tblSubGroupMaster");

            entity.Property(e => e.SubGroupId).HasColumnName("Sub_group_Id");
            entity.Property(e => e.ActiveStatus).HasColumnName("Active_status");
            entity.Property(e => e.AddedbyUserIdno).HasColumnName("Addedby_UserIdno");
            entity.Property(e => e.DateAdded)
                .HasColumnType("datetime")
                .HasColumnName("Date_Added");
            entity.Property(e => e.DateModified)
                .HasColumnType("datetime")
                .HasColumnName("Date_Modified");
            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.ModifiedByUserIdno).HasColumnName("ModifiedBy_UserIdno");
            entity.Property(e => e.SubGroupName)
                .HasMaxLength(200)
                .HasColumnName("sub_group_name");

            entity.HasOne(d => d.Group).WithMany(p => p.TblSubGroupMasters)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_Acc_Sub_Group_MasterTB_Head_GroupTB");
        });

        modelBuilder.Entity<TblTermMaster>(entity =>
        {
            entity.HasKey(e => e.TermIdno);

            entity.ToTable("tblTermMaster");

            entity.Property(e => e.TermIdno).HasColumnName("Term_Idno");
            entity.Property(e => e.TermName)
                .HasMaxLength(100)
                .HasColumnName("Term_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
