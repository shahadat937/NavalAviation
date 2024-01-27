using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolManagement.Api.Models
{
    public partial class BNISMMSDB2Context : DbContext
    {
        public BNISMMSDB2Context()
        {
        }

        public BNISMMSDB2Context(DbContextOptions<BNISMMSDB2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AcStatus> AcStatuses { get; set; }
        public virtual DbSet<Acceptance> Acceptances { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<AcctStore> AcctStores { get; set; }
        public virtual DbSet<AdminAuthority> AdminAuthorities { get; set; }
        public virtual DbSet<AirCraftFlying> AirCraftFlyings { get; set; }
        public virtual DbSet<AirCraftName> AirCraftNames { get; set; }
        public virtual DbSet<ArchivingforPublication> ArchivingforPublications { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Attendence> Attendences { get; set; }
        public virtual DbSet<Authority> Authorities { get; set; }
        public virtual DbSet<BaseName> BaseNames { get; set; }
        public virtual DbSet<BaseSchoolName> BaseSchoolNames { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<BranchInfo> BranchInfos { get; set; }
        public virtual DbSet<CallibrationState> CallibrationStates { get; set; }
        public virtual DbSet<Caste> Castes { get; set; }
        public virtual DbSet<CodeValue> CodeValues { get; set; }
        public virtual DbSet<CodeValueType> CodeValueTypes { get; set; }
        public virtual DbSet<ConditionOfItem> ConditionOfItems { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CountryGroup> CountryGroups { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseType> CourseTypes { get; set; }
        public virtual DbSet<CstTec> CstTecs { get; set; }
        public virtual DbSet<CurrencyName> CurrencyNames { get; set; }
        public virtual DbSet<DailyAirworthinessFrom> DailyAirworthinessFroms { get; set; }
        public virtual DbSet<DailyAirworthinessFromCategory> DailyAirworthinessFromCategories { get; set; }
        public virtual DbSet<DefenseType> DefenseTypes { get; set; }
        public virtual DbSet<DegitalArchieve> DegitalArchieves { get; set; }
        public virtual DbSet<DegitalArchieveDocType> DegitalArchieveDocTypes { get; set; }
        public virtual DbSet<Demand> Demands { get; set; }
        public virtual DbSet<DemandAuthority> DemandAuthorities { get; set; }
        public virtual DbSet<DemandCompleteStatus> DemandCompleteStatuses { get; set; }
        public virtual DbSet<DemandDoc> DemandDocs { get; set; }
        public virtual DbSet<DemandStatus> DemandStatuses { get; set; }
        public virtual DbSet<DemandType> DemandTypes { get; set; }
        public virtual DbSet<Deno> Denos { get; set; }
        public virtual DbSet<DepartmentName> DepartmentNames { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<EndLifeType> EndLifeTypes { get; set; }
        public virtual DbSet<EquipmentIssue> EquipmentIssues { get; set; }
        public virtual DbSet<EquipmentName> EquipmentNames { get; set; }
        public virtual DbSet<FailureStatus> FailureStatuses { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<FiscalYear> FiscalYears { get; set; }
        public virtual DbSet<ForceType> ForceTypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GseItemName> GseItemNames { get; set; }
        public virtual DbSet<GseMaintenance> GseMaintenances { get; set; }
        public virtual DbSet<GseMaintenanceScheduleName> GseMaintenanceScheduleNames { get; set; }
        public virtual DbSet<GseScheduleWorkType> GseScheduleWorkTypes { get; set; }
        public virtual DbSet<IssueRegister> IssueRegisters { get; set; }
        public virtual DbSet<IssueStatus> IssueStatuses { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<ItemCategoryType> ItemCategoryTypes { get; set; }
        public virtual DbSet<ItemDetail> ItemDetails { get; set; }
        public virtual DbSet<ItemInspection> ItemInspections { get; set; }
        public virtual DbSet<ItemReminder> ItemReminders { get; set; }
        public virtual DbSet<ItemStatus> ItemStatuses { get; set; }
        public virtual DbSet<ItemStor> ItemStors { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }
        public virtual DbSet<LeaveType> LeaveTypes { get; set; }
        public virtual DbSet<LifeLimitItem> LifeLimitItems { get; set; }
        public virtual DbSet<LifeLimitItemRunningHour> LifeLimitItemRunningHours { get; set; }
        public virtual DbSet<LocalAgent> LocalAgents { get; set; }
        public virtual DbSet<MaintenanceCategory> MaintenanceCategories { get; set; }
        public virtual DbSet<MaintenancePlanning> MaintenancePlannings { get; set; }
        public virtual DbSet<MaintenancePlanningStatus> MaintenancePlanningStatuses { get; set; }
        public virtual DbSet<MaintenanceSchedule> MaintenanceSchedules { get; set; }
        public virtual DbSet<MaintenanceSubCategory> MaintenanceSubCategories { get; set; }
        public virtual DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        public virtual DbSet<MaintenenceState> MaintenenceStates { get; set; }
        public virtual DbSet<Manufacture> Manufactures { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public virtual DbSet<MeaBlankFormat> MeaBlankFormats { get; set; }
        public virtual DbSet<MeaSquadronState> MeaSquadronStates { get; set; }
        public virtual DbSet<MeaWorkShop> MeaWorkShops { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<NameofPublication> NameofPublications { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<NewAtempt> NewAtempts { get; set; }
        public virtual DbSet<NoticeBoard> NoticeBoards { get; set; }
        public virtual DbSet<OccasionOfDemand> OccasionOfDemands { get; set; }
        public virtual DbSet<OfficersStatus> OfficersStatuses { get; set; }
        public virtual DbSet<OverhaulingType> OverhaulingTypes { get; set; }
        public virtual DbSet<PartOfShipment> PartOfShipments { get; set; }
        public virtual DbSet<PlaceOfDelivery> PlaceOfDeliveries { get; set; }
        public virtual DbSet<PresentBillet> PresentBillets { get; set; }
        public virtual DbSet<PresentState> PresentStates { get; set; }
        public virtual DbSet<PreviousItemStore> PreviousItemStores { get; set; }
        public virtual DbSet<PrincipalName> PrincipalNames { get; set; }
        public virtual DbSet<Procurement> Procurements { get; set; }
        public virtual DbSet<ProcurementStatus> ProcurementStatuses { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }
        public virtual DbSet<ReminderType> ReminderTypes { get; set; }
        public virtual DbSet<RequiredSparesForMaintenance> RequiredSparesForMaintenances { get; set; }
        public virtual DbSet<ResultStatus> ResultStatuses { get; set; }
        public virtual DbSet<RetirementType> RetirementTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleFeature> RoleFeatures { get; set; }
        public virtual DbSet<RunningHour> RunningHours { get; set; }
        public virtual DbSet<SailorRank> SailorRanks { get; set; }
        public virtual DbSet<ServiceLifeType> ServiceLifeTypes { get; set; }
        public virtual DbSet<ShelfLifeCategory> ShelfLifeCategories { get; set; }
        public virtual DbSet<ShowRight> ShowRights { get; set; }
        public virtual DbSet<SourceOfSupply> SourceOfSupplies { get; set; }
        public virtual DbSet<SparesCategory> SparesCategories { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<StepRelation> StepRelations { get; set; }
        public virtual DbSet<StockTransferNsd> StockTransferNsds { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<SurveyItem> SurveyItems { get; set; }
        public virtual DbSet<Thana> Thanas { get; set; }
        public virtual DbSet<ToolsBoxName> ToolsBoxNames { get; set; }
        public virtual DbSet<ToolsIssue> ToolsIssues { get; set; }
        public virtual DbSet<ToolsLocation> ToolsLocations { get; set; }
        public virtual DbSet<ToolsType> ToolsTypes { get; set; }
        public virtual DbSet<Trade> Trades { get; set; }
        public virtual DbSet<TrainingCrew> TrainingCrews { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=114.134.95.235,1434;Database=BNISMMSDB-2;user id=sa;password=B@ngl@d3sh;Trusted_Connection=false;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcStatus>(entity =>
            {
                entity.ToTable("AcStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ExcepRelease).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PlannedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.RequiredDays).HasMaxLength(450);

                entity.Property(e => e.UpcomingMaint).HasMaxLength(450);

                entity.HasOne(d => d.AirCraftName)
                    .WithMany(p => p.AcStatuses)
                    .HasForeignKey(d => d.AirCraftNameId)
                    .HasConstraintName("FK_AcStatus_AirCraftName");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.AcStatuses)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_AcStatus_BaseSchoolName");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.AcStatuses)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_AcStatus_Status");
            });

            modelBuilder.Entity<Acceptance>(entity =>
            {
                entity.ToTable("Acceptance");

                entity.Property(e => e.AcDocument).HasMaxLength(450);

                entity.Property(e => e.AcceptanceDocument).HasMaxLength(450);

                entity.Property(e => e.ArcDocument).HasMaxLength(450);

                entity.Property(e => e.Brand).HasMaxLength(450);

                entity.Property(e => e.CofcDocument).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateOfManufacture).HasColumnType("datetime");

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.DocVerification).HasMaxLength(450);

                entity.Property(e => e.InspectionDate).HasColumnType("datetime");

                entity.Property(e => e.ItemSerNo).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Model).HasMaxLength(450);

                entity.Property(e => e.OthersDocument).HasMaxLength(450);

                entity.Property(e => e.PurchasePrice).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.SftDate).HasColumnType("datetime");

                entity.Property(e => e.SftLetterNo).HasMaxLength(450);

                entity.Property(e => e.SftRegPage).HasMaxLength(450);

                entity.Property(e => e.Warranty).HasMaxLength(450);

                entity.Property(e => e.WarrantyFrom).HasColumnType("datetime");

                entity.Property(e => e.WarrantyTo).HasColumnType("datetime");

                entity.Property(e => e.WorkOrderDate).HasColumnType("datetime");

                entity.Property(e => e.WorkOrderNo).HasMaxLength(450);

                entity.HasOne(d => d.ConditionOfItem)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.ConditionOfItemId)
                    .HasConstraintName("FK_Acceptance_ConditionOfItem");

                entity.HasOne(d => d.DemandAuthority)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.DemandAuthorityId)
                    .HasConstraintName("FK_Acceptance_DemandAuthority");

                entity.HasOne(d => d.Demand)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.DemandId)
                    .HasConstraintName("FK_Acceptance_Demand");

                entity.HasOne(d => d.DemandType)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.DemandTypeId)
                    .HasConstraintName("FK_Acceptance_DemandType");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_Acceptance_BaseSchoolName1");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_Acceptance_ItemCategory");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_Acceptance_ItemDetail");

                entity.HasOne(d => d.ItemInspection)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.ItemInspectionId)
                    .HasConstraintName("FK_Acceptance_ItemInspection");

                entity.HasOne(d => d.Manufacture)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.ManufactureId)
                    .HasConstraintName("FK_Acceptance_Manufacture");

                entity.HasOne(d => d.PlaceOfDelivery)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.PlaceOfDeliveryId)
                    .HasConstraintName("FK_Acceptance_PlaceOfDelivery");

                entity.HasOne(d => d.PrincipalName)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.PrincipalNameId)
                    .HasConstraintName("FK_Acceptance_PrincipalName");

                entity.HasOne(d => d.ProcurementStatus)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.ProcurementStatusId)
                    .HasConstraintName("FK_Acceptance_ProcurementStatus");

                entity.HasOne(d => d.SourceOfSupply)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.SourceOfSupplyId)
                    .HasConstraintName("FK_Acceptance_SourceOfSupply");

                entity.HasOne(d => d.SparesCategory)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.SparesCategoryId)
                    .HasConstraintName("FK_Acceptance_SparesCategory");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("AccountType");

                entity.Property(e => e.AccoutType).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AcctStore>(entity =>
            {
                entity.ToTable("AcctStore");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<AdminAuthority>(entity =>
            {
                entity.ToTable("AdminAuthority");

                entity.Property(e => e.AdminAuthorityName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AirCraftFlying>(entity =>
            {
                entity.ToTable("AirCraftFlying");

                entity.Property(e => e.AcNo).HasMaxLength(450);

                entity.Property(e => e.CallSign).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Crew).HasMaxLength(450);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Dup).HasMaxLength(450);

                entity.Property(e => e.Duration).HasMaxLength(450);

                entity.Property(e => e.Endurance).HasMaxLength(450);

                entity.Property(e => e.Fuel).HasMaxLength(450);

                entity.Property(e => e.LandingTimePlanned).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Mon).HasMaxLength(450);

                entity.Property(e => e.OpaOff).HasMaxLength(450);

                entity.Property(e => e.Pdf).HasMaxLength(500);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.StartUp).HasMaxLength(450);

                entity.Property(e => e.StartUpDelay).HasMaxLength(450);

                entity.Property(e => e.StartupPlanned).HasMaxLength(450);

                entity.Property(e => e.TypeOfAc)
                    .HasMaxLength(450)
                    .HasColumnName("TypeOfAC");

                entity.HasOne(d => d.AirCraftName)
                    .WithMany(p => p.AirCraftFlyings)
                    .HasForeignKey(d => d.AirCraftNameId)
                    .HasConstraintName("FK_AirCraftFlying_AirCraftName");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.AirCraftFlyings)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_AirCraftFlying_BaseSchoolName");
            });

            modelBuilder.Entity<AirCraftName>(entity =>
            {
                entity.ToTable("AirCraftName");

                entity.Property(e => e.BasicOperatingWt).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Crew).HasMaxLength(450);

                entity.Property(e => e.CruisingSpeed).HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Endurance).HasMaxLength(450);

                entity.Property(e => e.FuelCapacity).HasMaxLength(450);

                entity.Property(e => e.Height).HasMaxLength(450);

                entity.Property(e => e.Image).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MadeBy).HasMaxLength(450);

                entity.Property(e => e.Manufacturer).HasMaxLength(450);

                entity.Property(e => e.ManufacturerMobile).HasMaxLength(50);

                entity.Property(e => e.MaxRange).HasMaxLength(450);

                entity.Property(e => e.MaxTakeoffAndLandingWt).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.OverallLength).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.WingSpan).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.AirCraftNames)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_AirCraftName_BaseSchoolName");
            });

            modelBuilder.Entity<ArchivingforPublication>(entity =>
            {
                entity.ToTable("ArchivingforPublication");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DocUpload).HasMaxLength(550);

                entity.Property(e => e.DocumentName).HasMaxLength(550);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(550);

                entity.HasOne(d => d.AirCraftName)
                    .WithMany(p => p.ArchivingforPublications)
                    .HasForeignKey(d => d.AirCraftNameId)
                    .HasConstraintName("FK_ArchivingforPublication_AirCraftName");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.ArchivingforPublications)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_ArchivingforPublication_BaseSchoolName");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.ArchivingforPublications)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_ArchivingforPublication_ItemDetail");

                entity.HasOne(d => d.NameofPublication)
                    .WithMany(p => p.ArchivingforPublications)
                    .HasForeignKey(d => d.NameofPublicationId)
                    .HasConstraintName("FK_ArchivingforPublication_NameofPublication");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.BranchId).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.InActiveDate).HasColumnType("datetime");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.RoleName).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Attendence>(entity =>
            {
                entity.ToTable("Attendence");

                entity.Property(e => e.AttendenceDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.Attendences)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_Attendence_BaseSchoolName");

                entity.HasOne(d => d.TrainingCrew)
                    .WithMany(p => p.Attendences)
                    .HasForeignKey(d => d.TrainingCrewId)
                    .HasConstraintName("FK_Attendence_TrainingCrew");
            });

            modelBuilder.Entity<Authority>(entity =>
            {
                entity.ToTable("Authority");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<BaseName>(entity =>
            {
                entity.ToTable("BaseName");

                entity.Property(e => e.BaseLogo).HasMaxLength(450);

                entity.Property(e => e.BaseNames)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ShortName).HasMaxLength(450);

                entity.HasOne(d => d.AdminAuthority)
                    .WithMany(p => p.BaseNames)
                    .HasForeignKey(d => d.AdminAuthorityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaseName_AdminAuthority");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.BaseNames)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_BaseName_District");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.BaseNames)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaseName_Division");

                entity.HasOne(d => d.ForceType)
                    .WithMany(p => p.BaseNames)
                    .HasForeignKey(d => d.ForceTypeId)
                    .HasConstraintName("FK_BaseName_ForceType");
            });

            modelBuilder.Entity<BaseSchoolName>(entity =>
            {
                entity.ToTable("BaseSchoolName");

                entity.Property(e => e.Address)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Cellphone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SchoolLogo).HasMaxLength(450);

                entity.Property(e => e.SchoolName).HasMaxLength(450);

                entity.Property(e => e.ServerName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName).HasMaxLength(450);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ShortName).HasMaxLength(450);
            });

            modelBuilder.Entity<BranchInfo>(entity =>
            {
                entity.ToTable("BranchInfo");

                entity.Property(e => e.AccountNoFc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AccountNoFC");

                entity.Property(e => e.AccountNoLc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AccountNoLC");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BranchLevel)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BranchType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')")
                    .IsFixedLength();

                entity.Property(e => e.Cellphone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode).HasDefaultValueSql("('BD')");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CurrencyCode).HasDefaultValueSql("('BDT')");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FifthLevel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstLevel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FourthLevel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MinimumCoverFund)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MinimumNrdbalance)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("MinimumNRDBalance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NativeBranchCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OwnBranchCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SecondLevel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ServerName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThirdLevel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ZoneInfoIdentity).HasDefaultValueSql("('0000')");
            });

            modelBuilder.Entity<CallibrationState>(entity =>
            {
                entity.ToTable("CallibrationState");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ItemName).HasMaxLength(450);

                entity.Property(e => e.LastDateofCalibrated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NextDueDate).HasColumnType("datetime");

                entity.Property(e => e.PresentState).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.SerNo).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.CallibrationStates)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_CallibrationState_BaseSchoolName");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.CallibrationStates)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_CallibrationState_ItemDetail");

                entity.HasOne(d => d.Trade)
                    .WithMany(p => p.CallibrationStates)
                    .HasForeignKey(d => d.TradeId)
                    .HasConstraintName("FK_CallibrationState_Trade");
            });

            modelBuilder.Entity<Caste>(entity =>
            {
                entity.ToTable("Caste");

                entity.Property(e => e.CastName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.Castes)
                    .HasForeignKey(d => d.ReligionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Caste_Religion");
            });

            modelBuilder.Entity<CodeValue>(entity =>
            {
                entity.ToTable("CodeValue");

                entity.Property(e => e.AdditonalValue)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DisplayCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeValue)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeValueType)
                    .WithMany(p => p.CodeValues)
                    .HasForeignKey(d => d.CodeValueTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CodeValue_CodeValueType");
            });

            modelBuilder.Entity<CodeValueType>(entity =>
            {
                entity.ToTable("CodeValueType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<ConditionOfItem>(entity =>
            {
                entity.ToTable("ConditionOfItem");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ShortName).HasMaxLength(450);

                entity.HasOne(d => d.CountryGroup)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.CountryGroupId)
                    .HasConstraintName("FK_Country_CountryGroup");

                entity.HasOne(d => d.CurrencyName)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.CurrencyNameId)
                    .HasConstraintName("FK_Country_CurrencyName");
            });

            modelBuilder.Entity<CountryGroup>(entity =>
            {
                entity.ToTable("CountryGroup");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<CourseType>(entity =>
            {
                entity.ToTable("CourseType");

                entity.Property(e => e.CourseTypeName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CstTec>(entity =>
            {
                entity.ToTable("CstTec");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<CurrencyName>(entity =>
            {
                entity.ToTable("CurrencyName");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CurrencyNames)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_CurrencyName_Country");
            });

            modelBuilder.Entity<DailyAirworthinessFrom>(entity =>
            {
                entity.ToTable("DailyAirworthinessFrom");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Doc).HasMaxLength(1000);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(510);

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.HasOne(d => d.AirCraftName)
                    .WithMany(p => p.DailyAirworthinessFroms)
                    .HasForeignKey(d => d.AirCraftNameId)
                    .HasConstraintName("FK_DailyAirworthinessFrom_AirCraftName");

                entity.HasOne(d => d.DailyAirworthinessFromCategory)
                    .WithMany(p => p.DailyAirworthinessFroms)
                    .HasForeignKey(d => d.DailyAirworthinessFromCategoryId)
                    .HasConstraintName("FK_DailyAirworthinessFrom_DailyAirworthinessFromCategory");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.DailyAirworthinessFroms)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_DailyAirworthinessFrom_BaseSchoolName");
            });

            modelBuilder.Entity<DailyAirworthinessFromCategory>(entity =>
            {
                entity.ToTable("DailyAirworthinessFromCategory");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.DailyAirworthinessFromCategories)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_DailyAirworthinessFromCategory_BaseSchoolName");
            });

            modelBuilder.Entity<DefenseType>(entity =>
            {
                entity.ToTable("DefenseType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DefenseTypeName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DegitalArchieve>(entity =>
            {
                entity.ToTable("DegitalArchieve");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateOfLastRev).HasColumnType("datetime");

                entity.Property(e => e.Doc).HasMaxLength(550);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(550);

                entity.Property(e => e.Remarks).HasMaxLength(550);

                entity.HasOne(d => d.AirCraftName)
                    .WithMany(p => p.DegitalArchieves)
                    .HasForeignKey(d => d.AirCraftNameId)
                    .HasConstraintName("FK_DegitalArchieve_AirCraftName");

                entity.HasOne(d => d.DegitalArchieveDocType)
                    .WithMany(p => p.DegitalArchieves)
                    .HasForeignKey(d => d.DegitalArchieveDocTypeId)
                    .HasConstraintName("FK_DegitalArchieve_DegitalArchieveDocType");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.DegitalArchieves)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_DegitalArchieve_BaseSchoolName");
            });

            modelBuilder.Entity<DegitalArchieveDocType>(entity =>
            {
                entity.ToTable("DegitalArchieveDocType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(550);

                entity.Property(e => e.Remarks).HasMaxLength(550);
            });

            modelBuilder.Entity<Demand>(entity =>
            {
                entity.ToTable("Demand");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DemandDate).HasColumnType("datetime");

                entity.Property(e => e.DemandLetterNo).HasMaxLength(450);

                entity.Property(e => e.DemandNo).HasMaxLength(50);

                entity.Property(e => e.DemandQty).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.LetterOuterNo).HasMaxLength(450);

                entity.Property(e => e.ManufactureAddress).HasMaxLength(450);

                entity.Property(e => e.OldPrice).HasMaxLength(450);

                entity.Property(e => e.OldRefNo).HasMaxLength(450);

                entity.Property(e => e.RefPoNo).HasMaxLength(450);

                entity.Property(e => e.RefPrice).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.SpecDoc).HasMaxLength(450);

                entity.HasOne(d => d.Authority)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.AuthorityId)
                    .HasConstraintName("FK_Demand_Authority");

                entity.HasOne(d => d.ConditionOfItem)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.ConditionOfItemId)
                    .HasConstraintName("FK_Demand_ConditionOfItem");

                entity.HasOne(d => d.DemandAuthority)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.DemandAuthorityId)
                    .HasConstraintName("FK_Demand_DemandAuthority");

                entity.HasOne(d => d.DemandDoc)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.DemandDocId)
                    .HasConstraintName("FK_Demand_DemandDoc");

                entity.HasOne(d => d.DemandStatus)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.DemandStatusId)
                    .HasConstraintName("FK_Demand_DemandStatus");

                entity.HasOne(d => d.DemandType)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.DemandTypeId)
                    .HasConstraintName("FK_Demand_DemandType");

                entity.HasOne(d => d.Deno)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.DenoId)
                    .HasConstraintName("FK_Demand_Deno");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_Demand_BaseSchoolName");

                entity.HasOne(d => d.FiscalYear)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.FiscalYearId)
                    .HasConstraintName("FK_Demand_FiscalYear");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_Demand_ItemCategory");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_Demand_ItemDetail");

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.ItemTypeId)
                    .HasConstraintName("FK_Demand_ItemType");

                entity.HasOne(d => d.Manufacture)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.ManufactureId)
                    .HasConstraintName("FK_Demand_Manufacture");

                entity.HasOne(d => d.OccasionOfDemand)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.OccasionOfDemandId)
                    .HasConstraintName("FK_Demand_OccasionOfDemand");

                entity.HasOne(d => d.SparesCategory)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.SparesCategoryId)
                    .HasConstraintName("FK_Demand_SparesCategory");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Demand_Supplier");

                entity.HasOne(d => d.Trade)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.TradeId)
                    .HasConstraintName("FK_Demand_Trade");
            });

            modelBuilder.Entity<DemandAuthority>(entity =>
            {
                entity.ToTable("DemandAuthority");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<DemandCompleteStatus>(entity =>
            {
                entity.ToTable("DemandCompleteStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<DemandDoc>(entity =>
            {
                entity.ToTable("DemandDoc");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<DemandStatus>(entity =>
            {
                entity.ToTable("DemandStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<DemandType>(entity =>
            {
                entity.ToTable("DemandType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<Deno>(entity =>
            {
                entity.ToTable("Deno");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<DepartmentName>(entity =>
            {
                entity.ToTable("DepartmentName");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_Division");
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.ToTable("Division");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DivisionName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.ToTable("EmployeeType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<EndLifeType>(entity =>
            {
                entity.ToTable("EndLifeType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<EquipmentIssue>(entity =>
            {
                entity.ToTable("EquipmentIssue");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.IssueQuantity).HasMaxLength(450);

                entity.Property(e => e.IssuedTo).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.LastStockQuantityBeforeIssue).HasMaxLength(450);

                entity.Property(e => e.Reason).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.ReturnableQty).HasMaxLength(450);

                entity.Property(e => e.TotalReceivedQuantity).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.EquipmentIssues)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_EquipmentIssue_BaseSchoolName");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.EquipmentIssues)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_EquipmentIssue_ItemCategory");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.EquipmentIssues)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_EquipmentIssue_ItemDetail");

                entity.HasOne(d => d.ItemStore)
                    .WithMany(p => p.EquipmentIssues)
                    .HasForeignKey(d => d.ItemStoreId)
                    .HasConstraintName("FK_EquipmentIssue_ItemStor");
            });

            modelBuilder.Entity<EquipmentName>(entity =>
            {
                entity.ToTable("EquipmentName");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.EquipmentNames)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_EquipmentName_BaseSchoolName");

                entity.HasOne(d => d.SparesCategory)
                    .WithMany(p => p.EquipmentNames)
                    .HasForeignKey(d => d.SparesCategoryId)
                    .HasConstraintName("FK_EquipmentName_SparesCategory");
            });

            modelBuilder.Entity<FailureStatus>(entity =>
            {
                entity.ToTable("FailureStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.FailureStatusName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.ToTable("Feature");

                entity.Property(e => e.Class).HasMaxLength(250);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.FeatureName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.GroupTitle).HasMaxLength(250);

                entity.Property(e => e.Icon).HasMaxLength(250);

                entity.Property(e => e.IconName).HasMaxLength(250);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feature_Module");
            });

            modelBuilder.Entity<FiscalYear>(entity =>
            {
                entity.ToTable("FiscalYear");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.FiscalYearName).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ShortName).HasMaxLength(450);
            });

            modelBuilder.Entity<ForceType>(entity =>
            {
                entity.ToTable("ForceType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ForceTypeName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(150);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(150);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GseItemName>(entity =>
            {
                entity.ToTable("GseItemName");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ItemName).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.GseItemNames)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_GseItemName_BaseSchoolName");
            });

            modelBuilder.Entity<GseMaintenance>(entity =>
            {
                entity.ToTable("GseMaintenance");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.GseMaintenances)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_GseMaintenance_BaseSchoolName");

                entity.HasOne(d => d.GseItemName)
                    .WithMany(p => p.GseMaintenances)
                    .HasForeignKey(d => d.GseItemNameId)
                    .HasConstraintName("FK_GseMaintenance_GseItemName");

                entity.HasOne(d => d.GseMaintenanceScheduleName)
                    .WithMany(p => p.GseMaintenances)
                    .HasForeignKey(d => d.GseMaintenanceScheduleNameId)
                    .HasConstraintName("FK_GseMaintenance_GseMaintenanceScheduleName");

                entity.HasOne(d => d.GseScheduleWorkType)
                    .WithMany(p => p.GseMaintenances)
                    .HasForeignKey(d => d.GseScheduleWorkTypeId)
                    .HasConstraintName("FK_GseMaintenance_GseScheduleWorkType");
            });

            modelBuilder.Entity<GseMaintenanceScheduleName>(entity =>
            {
                entity.ToTable("GseMaintenanceScheduleName");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.ScheduleName).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.GseMaintenanceScheduleNames)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_GseMaintenanceScheduleName_BaseSchoolName");
            });

            modelBuilder.Entity<GseScheduleWorkType>(entity =>
            {
                entity.ToTable("GseScheduleWorkType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.ScheduleWorkName).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.GseScheduleWorkTypes)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_GseScheduleWorkType_BaseSchoolName");

                entity.HasOne(d => d.GseMaintenanceScheduleName)
                    .WithMany(p => p.GseScheduleWorkTypes)
                    .HasForeignKey(d => d.GseMaintenanceScheduleNameId)
                    .HasConstraintName("FK_GseScheduleWorkType_GseMaintenanceScheduleName");
            });

            modelBuilder.Entity<IssueRegister>(entity =>
            {
                entity.ToTable("IssueRegister");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.IssuedTo).HasMaxLength(450);

                entity.Property(e => e.LastCalibrationDate).HasColumnType("datetime");

                entity.Property(e => e.LastMaintenanceDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Reason).HasMaxLength(450);

                entity.Property(e => e.ReceivedPerson).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.IssueRegisters)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_IssueRegister_BaseSchoolName");

                entity.HasOne(d => d.IssueStatus)
                    .WithMany(p => p.IssueRegisters)
                    .HasForeignKey(d => d.IssueStatusId)
                    .HasConstraintName("FK_IssueRegister_IssueStatus");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.IssueRegisters)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_IssueRegister_ItemDetail");

                entity.HasOne(d => d.ItemStore)
                    .WithMany(p => p.IssueRegisters)
                    .HasForeignKey(d => d.ItemStoreId)
                    .HasConstraintName("FK_IssueRegister_ItemStor");

                entity.HasOne(d => d.SparesCategory)
                    .WithMany(p => p.IssueRegisters)
                    .HasForeignKey(d => d.SparesCategoryId)
                    .HasConstraintName("FK_IssueRegister_SparesCategory");

                entity.HasOne(d => d.TrainingCrew)
                    .WithMany(p => p.IssueRegisters)
                    .HasForeignKey(d => d.TrainingCrewId)
                    .HasConstraintName("FK_IssueRegister_TrainingCrew");
            });

            modelBuilder.Entity<IssueStatus>(entity =>
            {
                entity.ToTable("IssueStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.ToTable("ItemCategory");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<ItemCategoryType>(entity =>
            {
                entity.ToTable("ItemCategoryType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<ItemDetail>(entity =>
            {
                entity.ToTable("ItemDetail");

                entity.Property(e => e.AlternatiovePrartNo).HasMaxLength(450);

                entity.Property(e => e.Brand).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ImcNumber).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MinimumStock).HasMaxLength(450);

                entity.Property(e => e.Model).HasMaxLength(450);

                entity.Property(e => e.NameOfItem).HasMaxLength(450);

                entity.Property(e => e.PartNo).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.SerialNo).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.ItemDetails)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_ItemDetail_BaseSchoolName");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.ItemDetails)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_ItemDetail_ItemCategory");

                entity.HasOne(d => d.ItemCategoryType)
                    .WithMany(p => p.ItemDetails)
                    .HasForeignKey(d => d.ItemCategoryTypeId)
                    .HasConstraintName("FK_ItemDetail_ItemCategoryType");

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.ItemDetails)
                    .HasForeignKey(d => d.ItemTypeId)
                    .HasConstraintName("FK_ItemDetail_ItemType");

                entity.HasOne(d => d.SparesCategory)
                    .WithMany(p => p.ItemDetails)
                    .HasForeignKey(d => d.SparesCategoryId)
                    .HasConstraintName("FK_ItemDetail_SparesCategory");

                entity.HasOne(d => d.Trade)
                    .WithMany(p => p.ItemDetails)
                    .HasForeignKey(d => d.TradeId)
                    .HasConstraintName("FK_ItemDetail_Trade");
            });

            modelBuilder.Entity<ItemInspection>(entity =>
            {
                entity.ToTable("ItemInspection");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<ItemReminder>(entity =>
            {
                entity.ToTable("ItemReminder");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ReminderDate).HasColumnType("datetime");

                entity.Property(e => e.ReminderDocument).HasMaxLength(450);

                entity.Property(e => e.ReminderStep).HasMaxLength(450);

                entity.HasOne(d => d.Procurement)
                    .WithMany(p => p.ItemReminders)
                    .HasForeignKey(d => d.ProcurementId)
                    .HasConstraintName("FK_ItemReminder_Procurement");

                entity.HasOne(d => d.ReminderType)
                    .WithMany(p => p.ItemReminders)
                    .HasForeignKey(d => d.ReminderTypeId)
                    .HasConstraintName("FK_ItemReminder_ReminderType");
            });

            modelBuilder.Entity<ItemStatus>(entity =>
            {
                entity.ToTable("ItemStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<ItemStor>(entity =>
            {
                entity.ToTable("ItemStor");

                entity.Property(e => e.Accessories).HasMaxLength(450);

                entity.Property(e => e.Brand).HasMaxLength(450);

                entity.Property(e => e.CalibrationDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateOfTenderFloat).HasColumnType("datetime");

                entity.Property(e => e.DemandDate).HasColumnType("datetime");

                entity.Property(e => e.DemandQty).HasMaxLength(450);

                entity.Property(e => e.EndLifeTime).HasMaxLength(450);

                entity.Property(e => e.EndShalfLife).HasMaxLength(450);

                entity.Property(e => e.IcmNo).HasMaxLength(450);

                entity.Property(e => e.IssuedQty).HasColumnName("issuedQty");

                entity.Property(e => e.ItemReceivedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemSerNo).HasMaxLength(450);

                entity.Property(e => e.LastCalibrationDate).HasColumnType("datetime");

                entity.Property(e => e.LastMaintenanceDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.LetterOuterNo).HasMaxLength(450);

                entity.Property(e => e.Location).HasMaxLength(450);

                entity.Property(e => e.ManufacturingDate).HasColumnType("datetime");

                entity.Property(e => e.Model).HasMaxLength(450);

                entity.Property(e => e.NextCalibrationDate).HasColumnType("datetime");

                entity.Property(e => e.NextMaintenenceDate).HasColumnType("datetime");

                entity.Property(e => e.OtherDoc).HasMaxLength(550);

                entity.Property(e => e.RefPoNo).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.RetirmentLife).HasMaxLength(450);

                entity.Property(e => e.ServiceLife).HasMaxLength(450);

                entity.Property(e => e.ShelfLife).HasMaxLength(450);

                entity.Property(e => e.StockRegisterPageNo).HasMaxLength(450);

                entity.Property(e => e.TenderNotice).HasMaxLength(450);

                entity.Property(e => e.TenderNumber).HasMaxLength(450);

                entity.Property(e => e.TenderPublishDate).HasColumnType("datetime");

                entity.Property(e => e.TenderopeningDate).HasColumnType("datetime");

                entity.Property(e => e.Tyqty).HasColumnName("TYQty");

                entity.Property(e => e.WarrantyEndDate).HasColumnType("datetime");

                entity.Property(e => e.WarrantyStartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Acceptance)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.AcceptanceId)
                    .HasConstraintName("FK_ItemStor_Acceptance");

                entity.HasOne(d => d.AcctStore)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.AcctStoreId)
                    .HasConstraintName("FK_ItemStor_AcctStore");

                entity.HasOne(d => d.ConditionOfItem)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.ConditionOfItemId)
                    .HasConstraintName("FK_ItemStor_ConditionOfItem");

                entity.HasOne(d => d.Demand)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.DemandId)
                    .HasConstraintName("FK_ItemStor_Demand");

                entity.HasOne(d => d.Deno)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.DenoId)
                    .HasConstraintName("FK_ItemStor_Deno");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_ItemStor_BaseSchoolName");

                entity.HasOne(d => d.EndLifeType)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.EndLifeTypeId)
                    .HasConstraintName("FK_ItemStor_EndLifeType");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_ItemStor_ItemCategory");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_ItemStor_ItemDetail");

                entity.HasOne(d => d.LifeLimitItem)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.LifeLimitItemId)
                    .HasConstraintName("FK_ItemStor_LifeLimitItem");

                entity.HasOne(d => d.OverhaulingType)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.OverhaulingTypeId)
                    .HasConstraintName("FK_ItemStor_OverhaulingType");

                entity.HasOne(d => d.Procurement)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.ProcurementId)
                    .HasConstraintName("FK_ItemStor_Procurement");

                entity.HasOne(d => d.RetirementType)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.RetirementTypeId)
                    .HasConstraintName("FK_ItemStor_RetirementType");

                entity.HasOne(d => d.ServiceLifeType)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.ServiceLifeTypeId)
                    .HasConstraintName("FK_ItemStor_ServiceLifeType");

                entity.HasOne(d => d.SparesCategory)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.SparesCategoryId)
                    .HasConstraintName("FK_ItemStor_SparesCategory");

                entity.HasOne(d => d.ToolsBoxName)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.ToolsBoxNameId)
                    .HasConstraintName("FK_ItemStor_ToolsBoxName");

                entity.HasOne(d => d.ToolsLocation)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.ToolsLocationId)
                    .HasConstraintName("FK_ItemStor_ToolsLocation");

                entity.HasOne(d => d.ToolsType)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.ToolsTypeId)
                    .HasConstraintName("FK_ItemStor_ToolsType");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.ToTable("ItemType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<LeaveAllocation>(entity =>
            {
                entity.HasIndex(e => e.LeaveTypeId, "IX_LeaveAllocations_LeaveTypeId");

                entity.HasOne(d => d.LeaveType)
                    .WithMany(p => p.LeaveAllocations)
                    .HasForeignKey(d => d.LeaveTypeId);
            });

            modelBuilder.Entity<LeaveRequest>(entity =>
            {
                entity.HasIndex(e => e.LeaveTypeId, "IX_LeaveRequests_LeaveTypeId");

                entity.HasOne(d => d.LeaveType)
                    .WithMany(p => p.LeaveRequests)
                    .HasForeignKey(d => d.LeaveTypeId);
            });

            modelBuilder.Entity<LifeLimitItem>(entity =>
            {
                entity.ToTable("LifeLimitItem");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<LifeLimitItemRunningHour>(entity =>
            {
                entity.ToTable("LifeLimitItemRunningHour");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.FlightDate).HasColumnType("datetime");

                entity.Property(e => e.FlightTimeHr).HasMaxLength(450);

                entity.Property(e => e.FlightTimeMin).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.SlNo).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.LifeLimitItemRunningHours)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_LifeLimitItemRunningHour_BaseSchoolName");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.LifeLimitItemRunningHours)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_LifeLimitItemRunningHour_ItemDetail");

                entity.HasOne(d => d.LifeLimitItem)
                    .WithMany(p => p.LifeLimitItemRunningHours)
                    .HasForeignKey(d => d.LifeLimitItemId)
                    .HasConstraintName("FK_LifeLimitItemRunningHour_LifeLimitItem");

                entity.HasOne(d => d.MaintenanceCategory)
                    .WithMany(p => p.LifeLimitItemRunningHours)
                    .HasForeignKey(d => d.MaintenanceCategoryId)
                    .HasConstraintName("FK_LifeLimitItemRunningHour_MaintenanceCategory");
            });

            modelBuilder.Entity<LocalAgent>(entity =>
            {
                entity.ToTable("LocalAgent");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<MaintenanceCategory>(entity =>
            {
                entity.ToTable("MaintenanceCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.MaintenanceCategories)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_MaintenanceCategory_BaseSchoolName");

                entity.HasOne(d => d.MaintenanceType)
                    .WithMany(p => p.MaintenanceCategories)
                    .HasForeignKey(d => d.MaintenanceTypeId)
                    .HasConstraintName("FK_MaintenanceCategory_MaintenanceType");
            });

            modelBuilder.Entity<MaintenancePlanning>(entity =>
            {
                entity.ToTable("MaintenancePlanning");

                entity.Property(e => e.CommencingDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ExtensionDay).HasMaxLength(450);

                entity.Property(e => e.ExtensionDocument).HasMaxLength(450);

                entity.Property(e => e.JobListDocument).HasMaxLength(450);

                entity.Property(e => e.LastInspDate).HasColumnType("datetime");

                entity.Property(e => e.LastInspectionDay).HasMaxLength(450);

                entity.Property(e => e.LastInspectionFh)
                    .HasMaxLength(450)
                    .HasColumnName("LastInspectionFH");

                entity.Property(e => e.LastInspectionOh)
                    .HasMaxLength(450)
                    .HasColumnName("LastInspectionOH");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MaintenanceDocument).HasMaxLength(450);

                entity.Property(e => e.NestInspDate).HasColumnType("datetime");

                entity.Property(e => e.NextInspectionDay).HasMaxLength(450);

                entity.Property(e => e.NextInspectionFh)
                    .HasMaxLength(450)
                    .HasColumnName("NextInspectionFH");

                entity.Property(e => e.NextInspectionOh)
                    .HasMaxLength(450)
                    .HasColumnName("NextInspectionOH");

                entity.Property(e => e.OthersDocument).HasMaxLength(450);

                entity.Property(e => e.PlannedCompletionDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.RequiredConsumablesDoc).HasMaxLength(450);

                entity.Property(e => e.RequiredDay).HasMaxLength(450);

                entity.Property(e => e.RequiredSpearsDoc).HasMaxLength(450);

                entity.Property(e => e.RequiredToolsDoc).HasMaxLength(450);

                entity.Property(e => e.SlNo).HasMaxLength(450);

                entity.Property(e => e.ToleranceDocument).HasMaxLength(450);

                entity.HasOne(d => d.AirCraftName)
                    .WithMany(p => p.MaintenancePlannings)
                    .HasForeignKey(d => d.AirCraftNameId)
                    .HasConstraintName("FK_MaintenancePlanning_AirCraftName");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.MaintenancePlannings)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_MaintenancePlanning_BaseSchoolName");

                entity.HasOne(d => d.MaintenanceCategory)
                    .WithMany(p => p.MaintenancePlannings)
                    .HasForeignKey(d => d.MaintenanceCategoryId)
                    .HasConstraintName("FK_MaintenancePlanning_MaintenanceCategory");

                entity.HasOne(d => d.MaintenancePlanningStatus)
                    .WithMany(p => p.MaintenancePlannings)
                    .HasForeignKey(d => d.MaintenancePlanningStatusId)
                    .HasConstraintName("FK_MaintenancePlanning_MaintenancePlanningStatus");

                entity.HasOne(d => d.MaintenanceSubCategory)
                    .WithMany(p => p.MaintenancePlannings)
                    .HasForeignKey(d => d.MaintenanceSubCategoryId)
                    .HasConstraintName("FK_MaintenancePlanning_MaintenanceSubCategory");

                entity.HasOne(d => d.MaintenanceType)
                    .WithMany(p => p.MaintenancePlannings)
                    .HasForeignKey(d => d.MaintenanceTypeId)
                    .HasConstraintName("FK_MaintenancePlanning_MaintenanceType");
            });

            modelBuilder.Entity<MaintenancePlanningStatus>(entity =>
            {
                entity.ToTable("MaintenancePlanningStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<MaintenanceSchedule>(entity =>
            {
                entity.ToTable("MaintenanceSchedule");

                entity.Property(e => e.AllowedExtension).HasMaxLength(450);

                entity.Property(e => e.CompletedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.EndInspDate).HasColumnType("datetime");

                entity.Property(e => e.ExtensionDay).HasMaxLength(450);

                entity.Property(e => e.ExtensionDocument).HasMaxLength(450);

                entity.Property(e => e.ExtensionGiven).HasMaxLength(450);

                entity.Property(e => e.JobListDocument).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MaintenanceDocument).HasMaxLength(450);

                entity.Property(e => e.OthersDocument).HasMaxLength(450);

                entity.Property(e => e.ProgressBar).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.RequiredConsumablesDoc).HasMaxLength(450);

                entity.Property(e => e.RequiredDay).HasMaxLength(450);

                entity.Property(e => e.RequiredSpearsDoc).HasMaxLength(450);

                entity.Property(e => e.RequiredToolsDoc).HasMaxLength(450);

                entity.Property(e => e.SlNo).HasMaxLength(450);

                entity.Property(e => e.StartInspDate).HasColumnType("datetime");

                entity.Property(e => e.ToleranceDocument).HasMaxLength(450);

                entity.HasOne(d => d.AirCraftName)
                    .WithMany(p => p.MaintenanceSchedules)
                    .HasForeignKey(d => d.AirCraftNameId)
                    .HasConstraintName("FK_MaintenanceSchedule_AirCraftName");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.MaintenanceSchedules)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_MaintenanceSchedule_BaseSchoolName");

                entity.HasOne(d => d.MaintenanceCategory)
                    .WithMany(p => p.MaintenanceSchedules)
                    .HasForeignKey(d => d.MaintenanceCategoryId)
                    .HasConstraintName("FK_MaintenanceSchedule_MaintenanceCategory");

                entity.HasOne(d => d.MaintenancePlanning)
                    .WithMany(p => p.MaintenanceSchedules)
                    .HasForeignKey(d => d.MaintenancePlanningId)
                    .HasConstraintName("FK_MaintenanceSchedule_MaintenancePlanning");

                entity.HasOne(d => d.MaintenancePlanningStatus)
                    .WithMany(p => p.MaintenanceSchedules)
                    .HasForeignKey(d => d.MaintenancePlanningStatusId)
                    .HasConstraintName("FK_MaintenanceSchedule_MaintenancePlanningStatus");

                entity.HasOne(d => d.MaintenanceSubCategory)
                    .WithMany(p => p.MaintenanceSchedules)
                    .HasForeignKey(d => d.MaintenanceSubCategoryId)
                    .HasConstraintName("FK_MaintenanceSchedule_MaintenanceSubCategory");

                entity.HasOne(d => d.MaintenanceType)
                    .WithMany(p => p.MaintenanceSchedules)
                    .HasForeignKey(d => d.MaintenanceTypeId)
                    .HasConstraintName("FK_MaintenanceSchedule_MaintenanceType");
            });

            modelBuilder.Entity<MaintenanceSubCategory>(entity =>
            {
                entity.ToTable("MaintenanceSubCategory");

                entity.Property(e => e.AllowedExtension).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.SubCategoryName).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.MaintenanceSubCategories)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_MaintenanceSubCategory_BaseSchoolName");

                entity.HasOne(d => d.MaintenanceCategory)
                    .WithMany(p => p.MaintenanceSubCategories)
                    .HasForeignKey(d => d.MaintenanceCategoryId)
                    .HasConstraintName("FK_MaintenanceSubCategory_MaintenanceCategory");

                entity.HasOne(d => d.MaintenanceType)
                    .WithMany(p => p.MaintenanceSubCategories)
                    .HasForeignKey(d => d.MaintenanceTypeId)
                    .HasConstraintName("FK_MaintenanceSubCategory_MaintenanceType");
            });

            modelBuilder.Entity<MaintenanceType>(entity =>
            {
                entity.ToTable("MaintenanceType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.MaintenanceTypes)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_MaintenanceType_BaseSchoolName");
            });

            modelBuilder.Entity<MaintenenceState>(entity =>
            {
                entity.ToTable("MaintenenceState");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ItemName).HasMaxLength(450);

                entity.Property(e => e.LastDateofMaintenence).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NextDueDate).HasColumnType("datetime");

                entity.Property(e => e.PresentState).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.SerNo).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.MaintenenceStates)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_MaintenenceState_BaseSchoolName");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.MaintenenceStates)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_MaintenenceState_ItemDetail");

                entity.HasOne(d => d.ItemStore)
                    .WithMany(p => p.MaintenenceStates)
                    .HasForeignKey(d => d.ItemStoreId)
                    .HasConstraintName("FK_MaintenenceState_ItemStor");

                entity.HasOne(d => d.Trade)
                    .WithMany(p => p.MaintenenceStates)
                    .HasForeignKey(d => d.TradeId)
                    .HasConstraintName("FK_MaintenenceState_Trade");
            });

            modelBuilder.Entity<Manufacture>(entity =>
            {
                entity.ToTable("Manufacture");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.ToTable("MaritalStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(150);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MaritalStatusName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<MeaBlankFormat>(entity =>
            {
                entity.ToTable("MeaBlankFormat");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Doc).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<MeaSquadronState>(entity =>
            {
                entity.ToTable("MeaSquadronState");

                entity.Property(e => e.AtaCode).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateOfDiscrepancy).HasColumnType("datetime");

                entity.Property(e => e.DateofInstall).HasColumnType("datetime");

                entity.Property(e => e.DateofSubmition).HasColumnType("datetime");

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ModelNo).HasMaxLength(450);

                entity.Property(e => e.RegistrationNo).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.ResonForRemoval).HasMaxLength(450);

                entity.Property(e => e.SerNo).HasMaxLength(450);

                entity.Property(e => e.TotalAcHour).HasMaxLength(450);

                entity.Property(e => e.TotalHouratOccation).HasMaxLength(450);

                entity.Property(e => e.TotalLandingCycles).HasMaxLength(450);

                entity.Property(e => e.TotalhouratDelivey).HasMaxLength(450);

                entity.Property(e => e.WorkOrderDate).HasColumnType("datetime");

                entity.Property(e => e.WorkOrderNo).HasMaxLength(450);

                entity.Property(e => e.WorkOrderReceived).HasMaxLength(450);

                entity.Property(e => e.WorkshopName).HasMaxLength(450);

                entity.HasOne(d => d.ConditionOfItem)
                    .WithMany(p => p.MeaSquadronStates)
                    .HasForeignKey(d => d.ConditionOfItemId)
                    .HasConstraintName("FK_MeaSquadronState_ConditionOfItem");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.MeaSquadronStates)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_MeaSquadronState_BaseSchoolName");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.MeaSquadronStates)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_MeaSquadronState_ItemDetail");

                entity.HasOne(d => d.MeaWorkShop)
                    .WithMany(p => p.MeaSquadronStates)
                    .HasForeignKey(d => d.MeaWorkShopId)
                    .HasConstraintName("FK_MeaSquadronState_MeaWorkShop");

                entity.HasOne(d => d.PresentState)
                    .WithMany(p => p.MeaSquadronStates)
                    .HasForeignKey(d => d.PresentStateId)
                    .HasConstraintName("FK_MeaSquadronState_PresentState");

                entity.HasOne(d => d.Trade)
                    .WithMany(p => p.MeaSquadronStates)
                    .HasForeignKey(d => d.TradeId)
                    .HasConstraintName("FK_MeaSquadronState_Trade");
            });

            modelBuilder.Entity<MeaWorkShop>(entity =>
            {
                entity.ToTable("MeaWorkShop");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(550);

                entity.Property(e => e.Remarks).HasMaxLength(550);
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("Module");

                entity.Property(e => e.Class).HasMaxLength(250);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.GroupTitle).HasMaxLength(250);

                entity.Property(e => e.Icon).HasMaxLength(250);

                entity.Property(e => e.IconName).HasMaxLength(250);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ModuleName).HasMaxLength(450);

                entity.Property(e => e.Title).HasMaxLength(450);
            });

            modelBuilder.Entity<NameofPublication>(entity =>
            {
                entity.ToTable("NameofPublication");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.NameofPublications)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_NameofPublication_BaseSchoolName");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("Nationality");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NationalityName)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<NewAtempt>(entity =>
            {
                entity.ToTable("NewAtempt");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<NoticeBoard>(entity =>
            {
                entity.ToTable("NoticeBoard");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Event).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NoticeDocument).HasMaxLength(450);

                entity.Property(e => e.OrderBy).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.NoticeBoards)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_NoticeBoard_BaseSchoolName");
            });

            modelBuilder.Entity<OccasionOfDemand>(entity =>
            {
                entity.ToTable("OccasionOfDemand");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.FiscalYear)
                    .WithMany(p => p.OccasionOfDemands)
                    .HasForeignKey(d => d.FiscalYearId)
                    .HasConstraintName("FK_OccasionOfDemand_FiscalYear");
            });

            modelBuilder.Entity<OfficersStatus>(entity =>
            {
                entity.ToTable("OfficersStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<OverhaulingType>(entity =>
            {
                entity.ToTable("OverhaulingType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<PartOfShipment>(entity =>
            {
                entity.ToTable("PartOfShipment");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<PlaceOfDelivery>(entity =>
            {
                entity.ToTable("PlaceOfDelivery");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<PresentBillet>(entity =>
            {
                entity.ToTable("PresentBillet");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PresentBilletName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<PresentState>(entity =>
            {
                entity.ToTable("PresentState");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<PreviousItemStore>(entity =>
            {
                entity.ToTable("PreviousItemStore");

                entity.Property(e => e.Accessories).HasMaxLength(450);

                entity.Property(e => e.CalibrationDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateOfTenderFloat).HasColumnType("datetime");

                entity.Property(e => e.DemandDate).HasColumnType("datetime");

                entity.Property(e => e.DemandQty).HasMaxLength(450);

                entity.Property(e => e.EndLifeTime).HasMaxLength(450);

                entity.Property(e => e.EndShalfLife).HasMaxLength(450);

                entity.Property(e => e.IcmNo).HasMaxLength(450);

                entity.Property(e => e.IssuedQty).HasColumnName("issuedQty");

                entity.Property(e => e.ItemReceivedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemSerNo).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.LetterOuterNo).HasMaxLength(450);

                entity.Property(e => e.Location).HasMaxLength(450);

                entity.Property(e => e.NextCalibrationDate).HasColumnType("datetime");

                entity.Property(e => e.RefPoNo).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.RetirmentLife).HasMaxLength(450);

                entity.Property(e => e.ServiceLife).HasMaxLength(450);

                entity.Property(e => e.ShelfLife).HasMaxLength(450);

                entity.Property(e => e.StockRegisterPageNo).HasMaxLength(450);

                entity.Property(e => e.TenderNotice).HasMaxLength(450);

                entity.Property(e => e.TenderNumber).HasMaxLength(450);

                entity.Property(e => e.TenderPublishDate).HasColumnType("datetime");

                entity.Property(e => e.TenderopeningDate).HasColumnType("datetime");

                entity.Property(e => e.WarrantyEndDate).HasColumnType("datetime");

                entity.Property(e => e.WarrantyStartDate).HasColumnType("datetime");

                entity.HasOne(d => d.AcctStore)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.AcctStoreId)
                    .HasConstraintName("FK_PreviousItemStore_AcctStore");

                entity.HasOne(d => d.Deno)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.DenoId)
                    .HasConstraintName("FK_PreviousItemStore_Deno");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_PreviousItemStore_BaseSchoolName");

                entity.HasOne(d => d.EndLifeType)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.EndLifeTypeId)
                    .HasConstraintName("FK_PreviousItemStore_EndLifeType");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_PreviousItemStore_ItemCategory");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_PreviousItemStore_ItemDetail");

                entity.HasOne(d => d.OverhaulingType)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.OverhaulingTypeId)
                    .HasConstraintName("FK_PreviousItemStore_OverhaulingType");

                entity.HasOne(d => d.RetirementType)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.RetirementTypeId)
                    .HasConstraintName("FK_PreviousItemStore_RetirementType");

                entity.HasOne(d => d.ServiceLifeType)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.ServiceLifeTypeId)
                    .HasConstraintName("FK_PreviousItemStore_ServiceLifeType");

                entity.HasOne(d => d.SparesCategory)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.SparesCategoryId)
                    .HasConstraintName("FK_PreviousItemStore_SparesCategory");

                entity.HasOne(d => d.ToolsBoxName)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.ToolsBoxNameId)
                    .HasConstraintName("FK_PreviousItemStore_ToolsBoxName");

                entity.HasOne(d => d.ToolsLocation)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.ToolsLocationId)
                    .HasConstraintName("FK_PreviousItemStore_ToolsLocation");

                entity.HasOne(d => d.ToolsType)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.ToolsTypeId)
                    .HasConstraintName("FK_PreviousItemStore_ToolsType");
            });

            modelBuilder.Entity<PrincipalName>(entity =>
            {
                entity.ToTable("PrincipalName");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<Procurement>(entity =>
            {
                entity.ToTable("Procurement");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateOfDelivery).HasColumnType("datetime");

                entity.Property(e => e.DateOfTenderFloat).HasColumnType("datetime");

                entity.Property(e => e.FinancialApproval).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.LatestProgress).HasMaxLength(550);

                entity.Property(e => e.ProcurementDocument).HasMaxLength(450);

                entity.Property(e => e.Qty).HasMaxLength(450);

                entity.Property(e => e.Reason).HasMaxLength(550);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.SupplierAid).HasColumnName("SupplierAId");

                entity.Property(e => e.SupplierMid).HasColumnName("SupplierMId");

                entity.Property(e => e.TenderNotice).HasMaxLength(450);

                entity.Property(e => e.TenderNumber).HasMaxLength(450);

                entity.Property(e => e.TenderPublishDate).HasColumnType("datetime");

                entity.Property(e => e.TenderSpecification).HasMaxLength(450);

                entity.Property(e => e.TenderopeningDate).HasColumnType("datetime");

                entity.Property(e => e.UnitPrice).HasMaxLength(450);

                entity.Property(e => e.WorkOrder).HasMaxLength(450);

                entity.Property(e => e.WorkOrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.CstTec)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.CstTecId)
                    .HasConstraintName("FK_Procurement_CstTec");

                entity.HasOne(d => d.Demand)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.DemandId)
                    .HasConstraintName("FK_Procurement_Demand");

                entity.HasOne(d => d.DemandType)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.DemandTypeId)
                    .HasConstraintName("FK_Procurement_DemandType");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_Procurement_BaseSchoolName");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_Procurement_ItemCategory");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_Procurement_ItemDetail");

                entity.HasOne(d => d.LocalAgent)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.LocalAgentId)
                    .HasConstraintName("FK_Procurement_LocalAgent");

                entity.HasOne(d => d.Manufacture)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.ManufactureId)
                    .HasConstraintName("FK_Procurement_Manufacture");

                entity.HasOne(d => d.PartOfShipment)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.PartOfShipmentId)
                    .HasConstraintName("FK_Procurement_PartOfShipment");

                entity.HasOne(d => d.PrincipalName)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.PrincipalNameId)
                    .HasConstraintName("FK_Procurement_PrincipalName");

                entity.HasOne(d => d.ProcurementStatus)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.ProcurementStatusId)
                    .HasConstraintName("FK_Procurement_ProcurementStatus");

                entity.HasOne(d => d.SparesCategory)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.SparesCategoryId)
                    .HasConstraintName("FK_Procurement_SparesCategory");

                entity.HasOne(d => d.SupplierA)
                    .WithMany(p => p.ProcurementSupplierAs)
                    .HasForeignKey(d => d.SupplierAid)
                    .HasConstraintName("FK_Procurement_Supplier1");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.ProcurementSuppliers)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Procurement_Supplier");

                entity.HasOne(d => d.SupplierM)
                    .WithMany(p => p.ProcurementSupplierMs)
                    .HasForeignKey(d => d.SupplierMid)
                    .HasConstraintName("FK_Procurement_Supplier2");
            });

            modelBuilder.Entity<ProcurementStatus>(entity =>
            {
                entity.ToTable("ProcurementStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.ToTable("Rank");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<Religion>(entity =>
            {
                entity.ToTable("Religion");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ReligionName)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<ReminderType>(entity =>
            {
                entity.ToTable("ReminderType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<RequiredSparesForMaintenance>(entity =>
            {
                entity.ToTable("RequiredSparesForMaintenance");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.AirCraftName)
                    .WithMany(p => p.RequiredSparesForMaintenances)
                    .HasForeignKey(d => d.AirCraftNameId)
                    .HasConstraintName("FK_RequiredSparesForMaintenance_AirCraftName");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.RequiredSparesForMaintenances)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_RequiredSparesForMaintenance_BaseSchoolName");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.RequiredSparesForMaintenances)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_RequiredSparesForMaintenance_ItemDetail");

                entity.HasOne(d => d.MaintenanceCategory)
                    .WithMany(p => p.RequiredSparesForMaintenances)
                    .HasForeignKey(d => d.MaintenanceCategoryId)
                    .HasConstraintName("FK_RequiredSparesForMaintenance_MaintenanceCategory");

                entity.HasOne(d => d.MaintenanceSubCategory)
                    .WithMany(p => p.RequiredSparesForMaintenances)
                    .HasForeignKey(d => d.MaintenanceSubCategoryId)
                    .HasConstraintName("FK_RequiredSparesForMaintenance_MaintenanceSubCategory");

                entity.HasOne(d => d.MaintenanceType)
                    .WithMany(p => p.RequiredSparesForMaintenances)
                    .HasForeignKey(d => d.MaintenanceTypeId)
                    .HasConstraintName("FK_RequiredSparesForMaintenance_MaintenanceType");

                entity.HasOne(d => d.SparesCategory)
                    .WithMany(p => p.RequiredSparesForMaintenances)
                    .HasForeignKey(d => d.SparesCategoryId)
                    .HasConstraintName("FK_RequiredSparesForMaintenance_SparesCategory");
            });

            modelBuilder.Entity<ResultStatus>(entity =>
            {
                entity.ToTable("ResultStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ResultStatusName).HasMaxLength(450);
            });

            modelBuilder.Entity<RetirementType>(entity =>
            {
                entity.ToTable("RetirementType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredRoleName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<RoleFeature>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.FeatureKey })
                    .HasName("PK_Company.RoleFeature");

                entity.ToTable("RoleFeature");
            });

            modelBuilder.Entity<RunningHour>(entity =>
            {
                entity.ToTable("RunningHour");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.FlightDate).HasColumnType("datetime");

                entity.Property(e => e.FlightTimeHr).HasMaxLength(450);

                entity.Property(e => e.FlightTimeMin).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.AirCraftName)
                    .WithMany(p => p.RunningHours)
                    .HasForeignKey(d => d.AirCraftNameId)
                    .HasConstraintName("FK_RunningHour_AirCraftName");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.RunningHours)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_RunningHour_BaseSchoolName");
            });

            modelBuilder.Entity<SailorRank>(entity =>
            {
                entity.ToTable("SailorRank");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<ServiceLifeType>(entity =>
            {
                entity.ToTable("ServiceLifeType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<ShelfLifeCategory>(entity =>
            {
                entity.ToTable("ShelfLifeCategory");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<ShowRight>(entity =>
            {
                entity.ToTable("ShowRight");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ShowRightName).HasMaxLength(450);
            });

            modelBuilder.Entity<SourceOfSupply>(entity =>
            {
                entity.ToTable("SourceOfSupply");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<SparesCategory>(entity =>
            {
                entity.ToTable("SparesCategory");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<StepRelation>(entity =>
            {
                entity.ToTable("StepRelation");

                entity.Property(e => e.CreatedBy).HasMaxLength(150);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(150);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StepRelationType).HasMaxLength(150);
            });

            modelBuilder.Entity<StockTransferNsd>(entity =>
            {
                entity.ToTable("StockTransferNsd");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Doc).HasMaxLength(450);

                entity.Property(e => e.IssuedQty).HasColumnName("issuedQty");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.StockAdjustmentDate).HasColumnType("datetime");

                entity.HasOne(d => d.DemandAuthority)
                    .WithMany(p => p.StockTransferNsds)
                    .HasForeignKey(d => d.DemandAuthorityId)
                    .HasConstraintName("FK_StockTransferNsd_DemandAuthority");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.StockTransferNsds)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_StockTransferNsd_BaseSchoolName");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.StockTransferNsds)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_StockTransferNsd_ItemDetail");

                entity.HasOne(d => d.ItemStor)
                    .WithMany(p => p.StockTransferNsds)
                    .HasForeignKey(d => d.ItemStorId)
                    .HasConstraintName("FK_StockTransferNsd_ItemStor");

                entity.HasOne(d => d.ToolsLocation)
                    .WithMany(p => p.StockTransferNsds)
                    .HasForeignKey(d => d.ToolsLocationId)
                    .HasConstraintName("FK_StockTransferNsd_ToolsLocation");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.CompanyName).HasMaxLength(450);

                entity.Property(e => e.ContractPersonName).HasMaxLength(450);

                entity.Property(e => e.ContractPersonNumber).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress).HasMaxLength(450);

                entity.Property(e => e.Fax).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PermanentAddress).HasMaxLength(450);

                entity.Property(e => e.PhoneNumber).HasMaxLength(450);

                entity.Property(e => e.PresentAddress).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.TelephoneNumber).HasMaxLength(450);
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("Survey");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SurveyDate).HasColumnType("datetime");

                entity.Property(e => e.SurveyNumber).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_Survey_BaseSchoolName");

                entity.HasOne(d => d.IssueRegister)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.IssueRegisterId)
                    .HasConstraintName("FK_Survey_IssueRegister");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_Survey_ItemCategory");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_Survey_ItemDetail");
            });

            modelBuilder.Entity<SurveyItem>(entity =>
            {
                entity.ToTable("SurveyItem");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DemandNo).HasMaxLength(450);

                entity.Property(e => e.ItemSerNo).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NsdSrNo).HasMaxLength(450);

                entity.Property(e => e.Qty).HasMaxLength(450);

                entity.Property(e => e.ReturnStore).HasMaxLength(450);

                entity.Property(e => e.SurveyDate).HasColumnType("datetime");

                entity.Property(e => e.SurveyDocument).HasMaxLength(450);

                entity.Property(e => e.SurveyNo).HasMaxLength(450);

                entity.HasOne(d => d.Deno)
                    .WithMany(p => p.SurveyItems)
                    .HasForeignKey(d => d.DenoId)
                    .HasConstraintName("FK_SurveyItem_Deno");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.SurveyItems)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_SurveyItem_ItemDetail");

                entity.HasOne(d => d.ItemStatus)
                    .WithMany(p => p.SurveyItems)
                    .HasForeignKey(d => d.ItemStatusId)
                    .HasConstraintName("FK_SurveyItem_ItemStatus");
            });

            modelBuilder.Entity<Thana>(entity =>
            {
                entity.ToTable("Thana");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ThanaName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Thanas)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Thana_District");
            });

            modelBuilder.Entity<ToolsBoxName>(entity =>
            {
                entity.ToTable("ToolsBoxName");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<ToolsIssue>(entity =>
            {
                entity.ToTable("ToolsIssue");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.IssueQuantity).HasMaxLength(450);

                entity.Property(e => e.IssuedTo).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.LastStockQuantityBeforeIssue).HasMaxLength(450);

                entity.Property(e => e.Reason).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.ReturnableQty).HasMaxLength(450);

                entity.Property(e => e.TotalReceivedQuantity).HasMaxLength(450);

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.ToolsIssues)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_ToolsIssue_BaseSchoolName");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.ToolsIssues)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_ToolsIssue_ItemCategory");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.ToolsIssues)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_ToolsIssue_ItemDetail");

                entity.HasOne(d => d.ItemStore)
                    .WithMany(p => p.ToolsIssues)
                    .HasForeignKey(d => d.ItemStoreId)
                    .HasConstraintName("FK_ToolsIssue_ItemStor");
            });

            modelBuilder.Entity<ToolsLocation>(entity =>
            {
                entity.ToTable("ToolsLocation");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.ToolsLocationName).HasMaxLength(450);
            });

            modelBuilder.Entity<ToolsType>(entity =>
            {
                entity.ToTable("ToolsType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<Trade>(entity =>
            {
                entity.ToTable("Trade");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);
            });

            modelBuilder.Entity<TrainingCrew>(entity =>
            {
                entity.ToTable("TrainingCrew");

                entity.Property(e => e.AviationCategory).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateOfJoin).HasColumnType("datetime");

                entity.Property(e => e.Duties).HasMaxLength(450);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.Pno).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TrainingCrews)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_TrainingCrew_Course");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.TrainingCrews)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_TrainingCrew_BaseSchoolName");

                entity.HasOne(d => d.EmployeeType)
                    .WithMany(p => p.TrainingCrews)
                    .HasForeignKey(d => d.EmployeeTypeId)
                    .HasConstraintName("FK_TrainingCrew_EmployeeType");

                entity.HasOne(d => d.OfficersStatus)
                    .WithMany(p => p.TrainingCrews)
                    .HasForeignKey(d => d.OfficersStatusId)
                    .HasConstraintName("FK_TrainingCrew_OfficersStatus");

                entity.HasOne(d => d.PresentBillet)
                    .WithMany(p => p.TrainingCrews)
                    .HasForeignKey(d => d.PresentBilletId)
                    .HasConstraintName("FK_TrainingCrew_PresentBillet");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.TrainingCrews)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("FK_TrainingCrew_Rank");

                entity.HasOne(d => d.SailorRank)
                    .WithMany(p => p.TrainingCrews)
                    .HasForeignKey(d => d.SailorRankId)
                    .HasConstraintName("FK_TrainingCrew_SailorRank");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.AttemptCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.BankCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmPassword).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HostName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsFirstTime).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredUserName).HasMaxLength(256);

                entity.Property(e => e.MobileAlias).HasMaxLength(16);

                entity.Property(e => e.ParmitedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PasswordChangeDate).HasColumnType("datetime");

                entity.Property(e => e.PasswordValidity).HasDefaultValueSql("((0))");

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.TransLimit).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.UserExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.UserFullName).HasMaxLength(150);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.Property(e => e.VerifyLimit).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WinPassword).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_User_BaseSchoolName");

                entity.HasOne(d => d.BranchInfo)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BranchInfoId)
                    .HasConstraintName("FK_User_BranchInfo");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
