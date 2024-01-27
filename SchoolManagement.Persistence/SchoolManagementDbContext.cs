using SchoolManagement.Domain;
using SchoolManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Persistence
{
    public class SchoolManagementDbContext : AuditableDbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AcStatus>(entity =>
            {
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

                entity.HasOne(d => d.Procurement)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.ProcurementId)
                    .HasConstraintName("FK_Acceptance_Procurement");

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

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.Acceptances)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_Acceptance_ItemCategory");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {

            });

            modelBuilder.Entity<Attendence>(entity =>
            {
              entity.HasOne(d => d.DepartmentName)
                   .WithMany(p => p.Attendences)
                   .HasForeignKey(d => d.DepartmentNameId)
                   .HasConstraintName("FK_Attendence_BaseSchoolName");

              entity.HasOne(d => d.TrainingCrew)
                   .WithMany(p => p.Attendences)
                   .HasForeignKey(d => d.TrainingCrewId)
                   .HasConstraintName("FK_Attendence_TrainingCrew");

            });

            modelBuilder.Entity<AcctStore>(entity =>
            {

            });

            modelBuilder.Entity<Status>(entity =>
            {

            });

            modelBuilder.Entity<AdminAuthority>(entity =>
            {

            });

            modelBuilder.Entity<AirCraftName>(entity =>
            {
                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.AirCraftNames)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_AirCraftName_BaseSchoolName");

            });

            modelBuilder.Entity<ArchivingforPublication>(entity =>
            {
                  entity.HasOne(d => d.DepartmentName)
                      .WithMany(p => p.ArchivingforPublications)
                      .HasForeignKey(d => d.DepartmentNameId)
                      .HasConstraintName("FK_ArchivingforPublication_BaseSchoolName");

                  entity.HasOne(d => d.ItemDetail)
                      .WithMany(p => p.ArchivingforPublications)
                      .HasForeignKey(d => d.ItemDetailId)
                      .HasConstraintName("FK_ArchivingforPublication_ItemDetail");

                  entity.HasOne(d => d.AirCraftName)
                      .WithMany(p => p.ArchivingforPublications)
                      .HasForeignKey(d => d.AirCraftNameId)
                      .HasConstraintName("FK_ArchivingforPublication_AirCraftName");

                  entity.HasOne(d => d.NameofPublication)
                      .WithMany(p => p.ArchivingforPublications)
                      .HasForeignKey(d => d.NameofPublicationId)
                      .HasConstraintName("FK_ArchivingforPublication_NameofPublication");

            });

            modelBuilder.Entity<NameofPublication>(entity =>
            {
              entity.HasOne(d => d.DepartmentName)
                  .WithMany(p => p.NameofPublications)
                  .HasForeignKey(d => d.DepartmentNameId)
                  .HasConstraintName("FK_NameofPublication_BaseSchoolName");

            });

            modelBuilder.Entity<AirCraftFlying>(entity =>
            {
                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.AirCraftFlyings)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_AirCraftFlying_BaseSchoolName");

                entity.HasOne(d => d.AirCraftName)
                   .WithMany(p => p.AirCraftFlyings)
                   .HasForeignKey(d => d.AirCraftNameId)
                   .HasConstraintName("FK_AirCraftFlying_AirCraftName");

            });

            modelBuilder.Entity<Authority>(entity =>
            {

            });

            modelBuilder.Entity<BaseName>(entity =>
            {
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

            });
            modelBuilder.Entity<Branch>(entity =>
            {

            });

            modelBuilder.Entity<BranchInfo>(entity =>
            {

            });
            modelBuilder.Entity<CallibrationState>(entity =>
            {
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
                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.Castes)
                    .HasForeignKey(d => d.ReligionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Caste_Religion");
            });

            modelBuilder.Entity<CodeValue>(entity =>
            {
                entity.HasOne(d => d.CodeValueType)
                    .WithMany(p => p.CodeValues)
                    .HasForeignKey(d => d.CodeValueTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CodeValue_CodeValueType");
            });

            modelBuilder.Entity<CodeValueType>(entity =>
            {

            });

            modelBuilder.Entity<ConditionOfItem>(entity =>
            {

            });

            modelBuilder.Entity<Country>(entity =>
            {
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

            });

            modelBuilder.Entity<Course>(entity =>
            {

            });

            modelBuilder.Entity<CourseType>(entity =>
            {

            });

            modelBuilder.Entity<CstTec>(entity =>
            {

            });

            modelBuilder.Entity<CurrencyName>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CurrencyNames)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_CurrencyName_Country");
            });

            modelBuilder.Entity<DailyAirworthinessFrom>(entity =>
            {
              entity.HasOne(d => d.AirCraftName)
                    .WithMany(p => p.DailyAirworthinessFroms)
                    .HasForeignKey(d => d.AirCraftNameId)
                    .HasConstraintName("FK_DailyAirworthinessFrom_AirCraftName");

              entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.DailyAirworthinessFroms)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_DailyAirworthinessFrom_BaseSchoolName");

              entity.HasOne(d => d.DailyAirworthinessFromCategory)
                    .WithMany(p => p.DailyAirworthinessFroms)
                    .HasForeignKey(d => d.DailyAirworthinessFromCategoryId)
                    .HasConstraintName("FK_DailyAirworthinessFrom_DailyAirworthinessFromCategory");

            });

            modelBuilder.Entity<DailyAirworthinessFromCategory>(entity =>
            {
              entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.DailyAirworthinessFromCategories)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_DailyAirworthinessFromCategory_BaseSchoolName");

            });

            modelBuilder.Entity<DefenseType>(entity =>
            {

            });

            modelBuilder.Entity<DegitalArchieve>(entity =>
            {
                  entity.HasOne(d => d.DepartmentName)
                        .WithMany(p => p.DegitalArchieves)
                        .HasForeignKey(d => d.DepartmentNameId)
                        .HasConstraintName("FK_DegitalArchieve_BaseSchoolName");

                  entity.HasOne(d => d.AirCraftName)
                        .WithMany(p => p.DegitalArchieves)
                        .HasForeignKey(d => d.AirCraftNameId)
                        .HasConstraintName("FK_DegitalArchieve_AirCraftName");

                  entity.HasOne(d => d.DegitalArchieveDocType)
                        .WithMany(p => p.DegitalArchieves)
                        .HasForeignKey(d => d.DegitalArchieveDocTypeId)
                        .HasConstraintName("FK_DegitalArchieve_DegitalArchieveDocType");

            });

            modelBuilder.Entity<DegitalArchieveDocType>(entity =>
            {

            });

            modelBuilder.Entity<Demand>(entity =>
            {
                entity.HasOne(d => d.Authority)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.AuthorityId)
                    .HasConstraintName("FK_Demand_Authority");

                entity.HasOne(d => d.Trade)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.TradeId)
                    .HasConstraintName("FK_Demand_Trade");

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

                entity.HasOne(d => d.DemandType)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.DemandTypeId)
                    .HasConstraintName("FK_Demand_DemandType");

                entity.HasOne(d => d.DemandStatus)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.DemandStatusId)
                    .HasConstraintName("FK_Demand_DemandStatus");

                entity.HasOne(d => d.Deno)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.DenoId)
                    .HasConstraintName("FK_Demand_Deno");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Demand_Supplier");

                entity.HasOne(d => d.Manufacture)
                   .WithMany(p => p.Demands)
                   .HasForeignKey(d => d.ManufactureId)
                   .HasConstraintName("FK_Demand_Manufacture");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_Demand_BaseSchoolName");

                entity.HasOne(d => d.FiscalYear)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.FiscalYearId)
                    .HasConstraintName("FK_Demand_FiscalYear");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_Demand_ItemDetail");

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.ItemTypeId)
                    .HasConstraintName("FK_Demand_ItemType");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_Demand_ItemCategory");

                entity.HasOne(d => d.OccasionOfDemand)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.OccasionOfDemandId)
                    .HasConstraintName("FK_Demand_OccasionOfDemand");

                entity.HasOne(d => d.SparesCategory)
                    .WithMany(p => p.Demands)
                    .HasForeignKey(d => d.SparesCategoryId)
                    .HasConstraintName("FK_Demand_SparesCategory");
            });

            modelBuilder.Entity<DemandAuthority>(entity =>
            {

            });

            modelBuilder.Entity<DemandCompleteStatus>(entity =>
            {

            });

            modelBuilder.Entity<DemandDoc>(entity =>
            {

            });

            modelBuilder.Entity<DemandStatus>(entity =>
            {

            });

            modelBuilder.Entity<DemandType>(entity =>
            {

            });

            modelBuilder.Entity<Deno>(entity =>
            {

            });

            modelBuilder.Entity<DepartmentName>(entity =>
            {

            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasOne(d => d.Division)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_Division");
            });

            modelBuilder.Entity<Division>(entity =>
            {

            });

            modelBuilder.Entity<EndLifeType>(entity =>
            {

            });

            modelBuilder.Entity<EquipmentIssue>(entity =>
            {
                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.EquipmentIssues)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_EquipmentIssue_BaseSchoolName");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.EquipmentIssues)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_EquipmentIssue_ItemCategory");

                entity.HasOne(d => d.ItemStore)
                    .WithMany(p => p.EquipmentIssues)
                    .HasForeignKey(d => d.ItemStoreId)
                    .HasConstraintName("FK_EquipmentIssue_ItemStor");
            });

            modelBuilder.Entity<EquipmentName>(entity =>
            {

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

            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feature_Module");
            });

            modelBuilder.Entity<FiscalYear>(entity =>
            {

            });

            modelBuilder.Entity<MeaWorkShop>(entity =>
            {

            });

            modelBuilder.Entity<ForceType>(entity =>
            {

            });

            modelBuilder.Entity<Gender>(entity =>
            {

            });

            modelBuilder.Entity<Group>(entity =>
            {

            });

            modelBuilder.Entity<GseItemName>(entity =>
            {
                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.GseItemNames)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_GseItemName_BaseSchoolName");
            });

            modelBuilder.Entity<GseMaintenance>(entity =>
            {
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
                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.GseMaintenanceScheduleNames)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_GseMaintenanceScheduleName_BaseSchoolName");
            });

            modelBuilder.Entity<GseScheduleWorkType>(entity =>
            {
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
                entity.HasOne(d => d.ItemStor)
                    .WithMany(p => p.IssueRegisters)
                    .HasForeignKey(d => d.ItemStoreId)
                    .HasConstraintName("FK_IssueRegister_ItemStor");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.IssueRegisters)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_IssueRegister_BaseSchoolName");

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.IssueRegisters)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_IssueRegister_ItemDetail");

                entity.HasOne(d => d.IssueStatus)
                    .WithMany(p => p.IssueRegisters)
                    .HasForeignKey(d => d.IssueStatusId)
                    .HasConstraintName("FK_IssueRegister_IssueStatus");

                entity.HasOne(d => d.SparesCategory)
                    .WithMany(p => p.IssueRegisters)
                    .HasForeignKey(d => d.SparesCategoryId)
                    .HasConstraintName("FK_IssueRegister_SparesCategory");

            });

            modelBuilder.Entity<IssueStatus>(entity =>
            {

            });

            modelBuilder.Entity<ItemInspection>(entity =>
            {

            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {

            });

            modelBuilder.Entity<ItemCategoryType>(entity =>
            {

            });

            modelBuilder.Entity<ItemDetail>(entity =>
            {
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

                entity.HasOne(d => d.ItemCategory)
                  .WithMany(p => p.ItemDetails)
                  .HasForeignKey(d => d.ItemCategoryId)
                  .HasConstraintName("FK_ItemDetail_ItemCategory");

                entity.HasOne(d => d.Trade)
                    .WithMany(p => p.ItemDetails)
                    .HasForeignKey(d => d.TradeId)
                    .HasConstraintName("FK_ItemDetail_Trade");

                //entity.HasOne(d => d.EquipmentName)
                //    .WithMany(p => p.ItemDetails)
                //    .HasForeignKey(d => d.EquipmentNameId)
                //    .HasConstraintName("FK_ItemDetail_EquipmentName");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.ItemDetails)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_ItemDetail_BaseSchoolName");
            });

            modelBuilder.Entity<ItemReminder>(entity =>
            {
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

            });

            modelBuilder.Entity<ItemStor>(entity =>
            {
                entity.HasOne(d => d.Acceptance)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.AcceptanceId)
                    .HasConstraintName("FK_ItemStor_Acceptance");

                entity.HasOne(d => d.AcctStore)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.AcctStoreId)
                    .HasConstraintName("FK_ItemStor_AcctStore");

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

                entity.HasOne(d => d.ConditionOfItem)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.ConditionOfItemId)
                    .HasConstraintName("FK_ItemStor_ConditionOfItem");

                entity.HasOne(d => d.LifeLimitItem)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.LifeLimitItemId)
                    .HasConstraintName("FK_ItemStor_LifeLimitItem");

                entity.HasOne(d => d.ToolsType)
                    .WithMany(p => p.ItemStors)
                    .HasForeignKey(d => d.ToolsTypeId)
                    .HasConstraintName("FK_ItemStor_ToolsType");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {

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

            });

            modelBuilder.Entity<LifeLimitItemRunningHour>(entity =>
            {
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

            });

            modelBuilder.Entity<MaintenanceCategory>(entity =>
            {
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
                entity.HasOne(d => d.MaintenancePlanningStatus)
                    .WithMany(p => p.MaintenancePlannings)
                    .HasForeignKey(d => d.MaintenancePlanningStatusId)
                    .HasConstraintName("FK_MaintenancePlanning_MaintenancePlanningStatus");

                entity.HasOne(d => d.AirCraftName)
                    .WithMany(p => p.MaintenancePlannings)
                    .HasForeignKey(d => d.AirCraftNameId)
                    .HasConstraintName("FK_MaintenancePlanning_AirCraftName");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.MaintenancePlannings)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_MaintenancePlanning_BaseSchoolName");

                //entity.HasOne(d => d.ItemStatus)
                //    .WithMany(p => p.MaintenancePlannings)
                //    .HasForeignKey(d => d.ItemStatusId)
                //    .HasConstraintName("FK_MaintenancePlanning_ItemStatus");

                entity.HasOne(d => d.MaintenanceCategory)
                    .WithMany(p => p.MaintenancePlannings)
                    .HasForeignKey(d => d.MaintenanceCategoryId)
                    .HasConstraintName("FK_MaintenancePlanning_MaintenanceCategory");

                entity.HasOne(d => d.MaintenanceSubCategory)
                    .WithMany(p => p.MaintenancePlannings)
                    .HasForeignKey(d => d.MaintenanceSubCategoryId)
                    .HasConstraintName("FK_MaintenancePlanning_MaintenanceSubCategory");

                entity.HasOne(d => d.MaintenanceType)
                    .WithMany(p => p.MaintenancePlannings)
                    .HasForeignKey(d => d.MaintenanceTypeId)
                    .HasConstraintName("FK_MaintenancePlanning_MaintenanceType");
            });

            modelBuilder.Entity<MaintenanceSchedule>(entity =>
            {
                entity.HasOne(d => d.MaintenancePlanning)
                    .WithMany(p => p.MaintenanceSchedules)
                    .HasForeignKey(d => d.MaintenancePlanningId)
                    .HasConstraintName("FK_MaintenanceSchedule_MaintenancePlanning");

                entity.HasOne(d => d.MaintenancePlanningStatus)
                    .WithMany(p => p.MaintenanceSchedules)
                    .HasForeignKey(d => d.MaintenancePlanningStatusId)
                    .HasConstraintName("FK_MaintenanceSchedule_MaintenancePlanningStatus");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.MaintenanceSchedules)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_MaintenanceSchedule_BaseSchoolName");

                entity.HasOne(d => d.AirCraftName)
                    .WithMany(p => p.MaintenanceSchedules)
                    .HasForeignKey(d => d.AirCraftNameId)
                    .HasConstraintName("FK_MaintenanceSchedule_AirCraftName");

                entity.HasOne(d => d.MaintenanceType)
                    .WithMany(p => p.MaintenanceSchedules)
                    .HasForeignKey(d => d.MaintenanceTypeId)
                    .HasConstraintName("FK_MaintenanceSchedule_MaintenanceType");

                entity.HasOne(d => d.MaintenanceCategory)
                    .WithMany(p => p.MaintenanceSchedules)
                    .HasForeignKey(d => d.MaintenanceCategoryId)
                    .HasConstraintName("FK_MaintenanceSchedule_MaintenanceCategory");

                entity.HasOne(d => d.MaintenanceSubCategory)
                    .WithMany(p => p.MaintenanceSchedules)
                    .HasForeignKey(d => d.MaintenanceSubCategoryId)
                    .HasConstraintName("FK_MaintenanceSchedule_MaintenanceSubCategory");


            });

            modelBuilder.Entity<MaintenancePlanningStatus>(entity =>
            {

            });

            modelBuilder.Entity<MaintenanceSubCategory>(entity =>
            {
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
                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.MaintenanceTypes)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_MaintenanceType_BaseSchoolName");
            });

            modelBuilder.Entity<Manufacture>(entity =>
            {

            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {

            });
            modelBuilder.Entity<MeaBlankFormat>(entity =>
            {

            });

            modelBuilder.Entity<MeaSquadronState>(entity =>
            {                
                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.MeaSquadronStates)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_MeaSquadronState_BaseSchoolName");

                entity.HasOne(d => d.PresentState)
                    .WithMany(p => p.MeaSquadronStates)
                    .HasForeignKey(d => d.PresentStateId)
                    .HasConstraintName("FK_MeaSquadronState_PresentState");

                entity.HasOne(d => d.ItemDetail)
                     .WithMany(p => p.MeaSquadronStates)
                     .HasForeignKey(d => d.ItemDetailId)
                     .HasConstraintName("FK_MeaSquadronState_ItemDetail");

                entity.HasOne(d => d.ConditionOfItem)
                     .WithMany(p => p.MeaSquadronStates)
                     .HasForeignKey(d => d.ConditionOfItemId)
                     .HasConstraintName("FK_MeaSquadronState_ConditionOfItem");

                entity.HasOne(d => d.Trade)
                     .WithMany(p => p.MeaSquadronStates)
                     .HasForeignKey(d => d.TradeId)
                     .HasConstraintName("FK_MeaSquadronState_Trade");

                entity.HasOne(d => d.MeaWorkShop)
                     .WithMany(p => p.MeaSquadronStates)
                     .HasForeignKey(d => d.MeaWorkShopId)
                     .HasConstraintName("FK_MeaSquadronState_MeaWorkShop");
            });

            modelBuilder.Entity<Module>(entity =>
            {

            });

          modelBuilder.Entity<MaintenenceState>(entity =>
          {
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

            modelBuilder.Entity<NoticeBoard>(entity =>
            {
                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.NoticeBoards)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_NoticeBoard_BaseSchoolName");
            });
            modelBuilder.Entity<Nationality>(entity =>
            {

            });

            modelBuilder.Entity<NewAtempt>(entity =>
            {

            });

            modelBuilder.Entity<OccasionOfDemand>(entity =>
            {
                entity.HasOne(d => d.FiscalYear)
                    .WithMany(p => p.OccasionOfDemands)
                    .HasForeignKey(d => d.FiscalYearId)
                    .HasConstraintName("FK_OccasionOfDemand_FiscalYear");

            });

            modelBuilder.Entity<OfficersStatus>(entity =>
            {

            });

            modelBuilder.Entity<OverhaulingType>(entity =>
            {

            });

            modelBuilder.Entity<PartOfShipment>(entity =>
            {

            });

            modelBuilder.Entity<PlaceOfDelivery>(entity =>
            {

            });

            modelBuilder.Entity<PresentBillet>(entity =>
            {

            });

            modelBuilder.Entity<PresentState>(entity =>
            {

            });

            modelBuilder.Entity<PreviousItemStore>(entity =>
            {

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_PreviousItemStore_ItemDetail");

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

                entity.HasOne(d => d.Deno)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.DenoId)
                    .HasConstraintName("FK_PreviousItemStore_Deno");


                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_PreviousItemStore_BaseSchoolName");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_PreviousItemStore_ItemCategory");

                entity.HasOne(d => d.SparesCategory)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.SparesCategoryId)
                    .HasConstraintName("FK_PreviousItemStore_SparesCategory");

                entity.HasOne(d => d.ServiceLifeType)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.ServiceLifeTypeId)
                    .HasConstraintName("FK_PreviousItemStore_ServiceLifeType");

                entity.HasOne(d => d.EndLifeType)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.EndLifeTypeId)
                    .HasConstraintName("FK_PreviousItemStore_EndLifeType");

                entity.HasOne(d => d.AcctStore)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.AcctStoreId)
                    .HasConstraintName("FK_PreviousItemStore_AcctStore");

                entity.HasOne(d => d.OverhaulingType)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.OverhaulingTypeId)
                    .HasConstraintName("FK_PreviousItemStore_OverhaulingType");

                entity.HasOne(d => d.RetirementType)
                    .WithMany(p => p.PreviousItemStores)
                    .HasForeignKey(d => d.RetirementTypeId)
                    .HasConstraintName("FK_PreviousItemStore_RetirementType");

            });

            modelBuilder.Entity<PrincipalName>(entity =>
            {

            });

            modelBuilder.Entity<Procurement>(entity =>
            {
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

                entity.HasOne(d => d.ItemDetail)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.ItemDetailId)
                    .HasConstraintName("FK_Procurement_ItemDetail");

                entity.HasOne(d => d.LocalAgent)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.LocalAgentId)
                    .HasConstraintName("FK_Procurement_LocalAgent");

                entity.HasOne(d => d.Supplier)
                   .WithMany(p => p.Procurements)
                   .HasForeignKey(d => d.SupplierId)
                   .HasConstraintName("FK_Procurement_Supplier");

                entity.HasOne(d => d.Supplier)
                  .WithMany(p => p.Procurements)
                  .HasForeignKey(d => d.SupplierId)
                  .HasConstraintName("FK_Procurement_Supplier1");

                entity.HasOne(d => d.Supplier)
                  .WithMany(p => p.Procurements)
                  .HasForeignKey(d => d.SupplierId)
                  .HasConstraintName("FK_Procurement_Supplier2");

                entity.HasOne(d => d.PartOfShipment)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.PartOfShipmentId)
                    .HasConstraintName("FK_Procurement_PartOfShipment");

                entity.HasOne(d => d.PrincipalName)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.PrincipalNameId)
                    .HasConstraintName("FK_Procurement_PrincipalName");

                entity.HasOne(d => d.Manufacture)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.ManufactureId)
                    .HasConstraintName("FK_Procurement_Manufacture");

                entity.HasOne(d => d.ProcurementStatus)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.ProcurementStatusId)
                    .HasConstraintName("FK_Procurement_ProcurementStatus");

                entity.HasOne(d => d.SparesCategory)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.SparesCategoryId)
                    .HasConstraintName("FK_Procurement_SparesCategory");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.Procurements)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK_Procurement_ItemCategory");
            });

            modelBuilder.Entity<ProcurementStatus>(entity =>
            {

            });

            modelBuilder.Entity<Rank>(entity =>
            {

            });

            modelBuilder.Entity<Religion>(entity =>
            {

            });

            modelBuilder.Entity<ReminderType>(entity =>
            {

            });

            modelBuilder.Entity<RequiredSparesForMaintenance>(entity =>
            {

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

                  entity.HasOne(d => d.MaintenanceType)
                        .WithMany(p => p.RequiredSparesForMaintenances)
                        .HasForeignKey(d => d.MaintenanceTypeId)
                        .HasConstraintName("FK_RequiredSparesForMaintenance_MaintenanceType");

                  entity.HasOne(d => d.MaintenanceCategory)
                        .WithMany(p => p.RequiredSparesForMaintenances)
                        .HasForeignKey(d => d.MaintenanceCategoryId)
                        .HasConstraintName("FK_RequiredSparesForMaintenance_MaintenanceCategory");

                  entity.HasOne(d => d.MaintenanceSubCategory)
                        .WithMany(p => p.RequiredSparesForMaintenances)
                        .HasForeignKey(d => d.MaintenanceSubCategoryId)
                        .HasConstraintName("FK_RequiredSparesForMaintenance_MaintenanceSubCategory");

                  entity.HasOne(d => d.SparesCategory)
                        .WithMany(p => p.RequiredSparesForMaintenances)
                        .HasForeignKey(d => d.SparesCategoryId)
                        .HasConstraintName("FK_RequiredSparesForMaintenance_SparesCategory");

            });

            modelBuilder.Entity<ResultStatus>(entity =>
            {

            });

            modelBuilder.Entity<RetirementType>(entity =>
            {

            });

            modelBuilder.Entity<Role>(entity =>
            {

            });

            modelBuilder.Entity<RoleFeature>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.FeatureKey })
                    .HasName("PK_Company.RoleFeature");

                entity.ToTable("RoleFeature");
            });

            modelBuilder.Entity<RunningHour>(entity =>
            {
                entity.HasOne(d => d.AirCraftName)
                    .WithMany(p => p.RunningHours)
                    .HasForeignKey(d => d.AirCraftNameId)
                    .HasConstraintName("FK_RunningHour_AirCraftName");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.RunningHours)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_RunningHour_BaseSchoolName");
            });

            modelBuilder.Entity<ServiceLifeType>(entity =>
            {

            });

            modelBuilder.Entity<ShelfLifeCategory>(entity =>
            {

            });

            modelBuilder.Entity<ShowRight>(entity =>
            {

            });

            modelBuilder.Entity<SourceOfSupply>(entity =>
            {

            });

            modelBuilder.Entity<Survey>(entity =>
            {
                   entity.HasOne(d => d.DepartmentName)
                         .WithMany(p => p.Surveys)
                         .HasForeignKey(d => d.DepartmentNameId)
                         .HasConstraintName("FK_Survey_BaseSchoolName");

                  entity.HasOne(d => d.IssueRegister)
                        .WithMany(p => p.Surveys)
                        .HasForeignKey(d => d.IssueRegisterId)
                        .HasConstraintName("FK_Survey_IssueRegister");

                  entity.HasOne(d => d.ItemDetail)
                        .WithMany(p => p.Surveys)
                        .HasForeignKey(d => d.ItemDetailId)
                        .HasConstraintName("FK_Survey_ItemDetail");

                  entity.HasOne(d => d.ItemCategory)
                        .WithMany(p => p.Surveys)
                        .HasForeignKey(d => d.ItemCategoryId)
                        .HasConstraintName("FK_Survey_ItemCategory");


            });

            modelBuilder.Entity<SparesCategory>(entity =>
            {

            });

            modelBuilder.Entity<StepRelation>(entity =>
            {

            });

            modelBuilder.Entity<StockTransferNsd>(entity =>
            {
                  entity.HasOne(d => d.DepartmentName)
                        .WithMany(p => p.StockTransferNsds)
                        .HasForeignKey(d => d.DepartmentNameId)
                        .HasConstraintName("FK_StockTransferNsd_BaseSchoolName");

                  entity.HasOne(d => d.ItemStor)
                        .WithMany(p => p.StockTransferNsds)
                        .HasForeignKey(d => d.ItemStorId)
                        .HasConstraintName("FK_StockTransferNsd_ItemStor");

                 entity.HasOne(d => d.DemandAuthority)
                       .WithMany(p => p.StockTransferNsds)
                       .HasForeignKey(d => d.DemandAuthorityId)
                       .HasConstraintName("FK_StockTransferNsd_DemandAuthority");

                  entity.HasOne(d => d.ItemDetail)
                       .WithMany(p => p.StockTransferNsds)
                       .HasForeignKey(d => d.ItemDetailId)
                       .HasConstraintName("FK_StockTransferNsd_ItemDetail");

                 entity.HasOne(d => d.ToolsLocation)
                       .WithMany(p => p.StockTransferNsds)
                       .HasForeignKey(d => d.ToolsLocationId)
                       .HasConstraintName("FK_StockTransferNsd_ToolsLocation");



            });

            modelBuilder.Entity<Store>(entity =>
            {

            });

            modelBuilder.Entity<Supplier>(entity =>
            {

            });

            modelBuilder.Entity<SurveyItem>(entity =>
            {
                entity.HasOne(d => d.Deno)
                    .WithMany(p => p.SurveyItems)
                    .HasForeignKey(d => d.DenoId)
                    .HasConstraintName("FK_SurveyItem_Deno");

                entity.HasOne(d => d.ItemStatus)
                    .WithMany(p => p.SurveyItems)
                    .HasForeignKey(d => d.ItemStatusId)
                    .HasConstraintName("FK_SurveyItem_ItemStatus");
            });

            modelBuilder.Entity<Thana>(entity =>
            {
                entity.HasOne(d => d.District)
                    .WithMany(p => p.Thanas)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Thana_District");
            });

            modelBuilder.Entity<ToolsType>(entity =>
            {

            });
            modelBuilder.Entity<EmployeeType>(entity =>
            {
           
            });
            modelBuilder.Entity<SailorRank>(entity =>
            {

            });

            modelBuilder.Entity<ToolsIssue>(entity =>
            {
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

                entity.HasOne(d => d.ItemStor)
                    .WithMany(p => p.ToolsIssues)
                    .HasForeignKey(d => d.ItemStoreId)
                    .HasConstraintName("FK_ToolsIssue_ItemStor");
            });

            modelBuilder.Entity<Trade>(entity =>
            {

            });

            modelBuilder.Entity<TrainingCrew>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TrainingCrews)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_TrainingCrew_Course");

                entity.HasOne(d => d.DepartmentName)
                    .WithMany(p => p.TrainingCrews)
                    .HasForeignKey(d => d.DepartmentNameId)
                    .HasConstraintName("FK_TrainingCrew_BaseSchoolName");

              entity.HasOne(d => d.PresentBillet)
                    .WithMany(p => p.TrainingCrews)
                    .HasForeignKey(d => d.PresentBilletId)
                    .HasConstraintName("FK_TrainingCrew_PresentBillet");

              entity.HasOne(d => d.OfficersStatus)
                    .WithMany(p => p.TrainingCrews)
                    .HasForeignKey(d => d.OfficersStatusId)
                    .HasConstraintName("FK_TrainingCrew_OfficersStatus");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.TrainingCrews)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("FK_TrainingCrew_Rank");

              entity.HasOne(d => d.EmployeeType)
                    .WithMany(p => p.TrainingCrews)
                    .HasForeignKey(d => d.EmployeeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrainingCrew_EmployeeType");

              entity.HasOne(d => d.SailorRank)
                   .WithMany(p => p.TrainingCrews)
                   .HasForeignKey(d => d.SailorRankId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_TrainingCrew_SailorRank");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(d => d.BranchInfo)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BranchInfoId)
                    .HasConstraintName("FK_User_BranchInfo");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<UserTransferBackup>(entity =>
            {
              
            });

             modelBuilder.Entity<Shop>(entity =>
             {

             });

             modelBuilder.Entity<TestEquipmentDetail>(entity =>
             {
               entity.HasOne(d => d.Shop)
                   .WithMany(p => p.TestEquipmentDetails)
                   .HasForeignKey(d => d.ShopId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_TestEquipmentDetail_Shop");

               

             });
          }




        public virtual DbSet<AcStatus> AcStatus { get; set; } = null!;
        public virtual DbSet<Acceptance> Acceptance { get; set; } = null!;
        public virtual DbSet<AccountType> AccountType { get; set; } = null!;
        public virtual DbSet<Attendence> Attendence { get; set; } = null!;
        public virtual DbSet<AcctStore> AcctStore { get; set; } = null!;
        public virtual DbSet<AirCraftName> AirCraftName { get; set; } = null!;
        public virtual DbSet<AirCraftFlying> AirCraftFlying { get; set; } = null!;
        public virtual DbSet<Authority> Authority { get; set; } = null!;
        public virtual DbSet<ConditionOfItem> ConditionOfItem { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<CountryGroup> CountryGroups { get; set; } = null!;
        public virtual DbSet<Course> Course { get; set; } = null!;
        public virtual DbSet<CourseType> CourseTypes { get; set; } = null!;
        public virtual DbSet<CstTec> CstTec { get; set; } = null!;
        public virtual DbSet<CurrencyName> CurrencyNames { get; set; } = null!;
        public virtual DbSet<DefenseType> DefenseTypes { get; set; } = null!;
        public virtual DbSet<Demand> Demands { get; set; } = null!; 
        public virtual DbSet<DemandAuthority> DemandAuthority { get; set; } = null!; 

        public virtual DbSet<DemandDoc> DemandDocs { get; set; } = null!;
        public virtual DbSet<Deno> Deno { get; set; } = null!;
        public virtual DbSet<EmployeeType> EmployeeType { get; set; } = null!;
        public virtual DbSet<SailorRank> SailorRank { get; set; } = null!;
        public virtual DbSet<DepartmentName> DepartmentNames { get; set; } = null!;
        public virtual DbSet<Deno> Denos { get; set; } = null!;
        public virtual DbSet<DepartmentName> DepartmentName { get; set; } = null!;
        public virtual DbSet<EndLifeType> EndLifeType { get; set; } = null!;
        public virtual DbSet<FailureStatus> FailureStatuses { get; set; } = null!;
        public virtual DbSet<Feature> Features { get; set; } = null!;
        public virtual DbSet<FiscalYear> FiscalYear { get; set; } = null!;
        public virtual DbSet<ForceType> ForceTypes { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<ItemCategory> ItemCategory { get; set; } = null!;
        public virtual DbSet<ItemReminder> ItemReminders { get; set; } = null!;
        public virtual DbSet<ItemStatus> ItemStatus { get; set; } = null!;
        public virtual DbSet<ItemType> ItemType { get; set; } = null!;
        public virtual DbSet<LeaveAllocation> LeaveAllocations { get; set; } = null!;
        public virtual DbSet<LeaveRequest> LeaveRequests { get; set; } = null!;
        public virtual DbSet<LeaveType> LeaveTypes { get; set; } = null!;
        public virtual DbSet<MaintenanceCategory> MaintenanceCategories { get; set; } = null!;
        public virtual DbSet<MaintenancePlanning> MaintenancePlannings { get; set; } = null!;
        public virtual DbSet<MaintenanceSubCategory> MaintenanceSubCategory { get; set; } = null!;
        public virtual DbSet<MaintenanceType> MaintenanceType { get; set; } = null!;
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; } = null!;
        public virtual DbSet<MeaSquadronState> MeaSquadronState { get; set; } = null!;
        public virtual DbSet<MeaBlankFormat> MeaBlankFormat { get; set; } = null!;
        public virtual DbSet<Module> Modules { get; set; } = null!;
        public virtual DbSet<Nationality> Nationalities { get; set; } = null!;
        public virtual DbSet<NewAtempt> NewAtempts { get; set; } = null!;
        public virtual DbSet<NoticeBoard> NoticeBoard { get; set; }
        public virtual DbSet<OccasionOfDemand> OccasionOfDemand { get; set; } = null!;
        public virtual DbSet<OfficersStatus> OfficersStatuses { get; set; } = null!;
        public virtual DbSet<OverhaulingType> OverhaulingTypes { get; set; } = null!;
        public virtual DbSet<PartOfShipment> PartOfShipments { get; set; } = null!;
        public virtual DbSet<PlaceOfDelivery> PlaceOfDeliveries { get; set; } = null!;
        public virtual DbSet<PresentBillet> PresentBillets { get; set; } = null!;
        public virtual DbSet<PrincipalName> PrincipalNames { get; set; } = null!;
        public virtual DbSet<Procurement> Procurements { get; set; } = null!;
        public virtual DbSet<ProcurementStatus> ProcurementStatuses { get; set; } = null!;
        public virtual DbSet<Rank> Rank { get; set; } = null!;
        public virtual DbSet<ReminderType> ReminderTypes { get; set; } = null!;
        public virtual DbSet<ResultStatus> ResultStatuses { get; set; } = null!;
        public virtual DbSet<RetirementType> RetirementTypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleFeature> RoleFeatures { get; set; } = null!;
        public virtual DbSet<RunningHour> RunningHours { get; set; } = null!;
        public virtual DbSet<ServiceLifeType> ServiceLifeType { get; set; } = null!;
        public virtual DbSet<ShelfLifeCategory> ShelfLifeCategories { get; set; } = null!;
        public virtual DbSet<RunningHour> RunningHour { get; set; } = null!;
        public virtual DbSet<ServiceLifeType> ServiceLifeTypes { get; set; } = null!;
        public virtual DbSet<ShelfLifeCategory> ShelfLifeCategory { get; set; } = null!;
        public virtual DbSet<ShowRight> ShowRights { get; set; } = null!;
        public virtual DbSet<SourceOfSupply> SourceOfSupplies { get; set; } = null!;
        public virtual DbSet<SparesCategory> SparesCategory { get; set; } = null!;
        public virtual DbSet<StepRelation> StepRelations { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<Supplier> Supplier { get; set; } = null!; 
        public virtual DbSet<Survey> Survey { get; set; } = null!; 

        public virtual DbSet<Store> Store { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<SurveyItem> SurveyItems { get; set; } = null!;
        public virtual DbSet<ToolsType> ToolsType { get; set; } = null!;
        public virtual DbSet<Trade> Trades { get; set; } = null!;
        public virtual DbSet<Status> Status { get; set; } = null!;
        public virtual DbSet<TrainingCrew> TrainingCrews { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        public virtual DbSet<AdminAuthority> AdminAuthority { get; set; } = null!;
        public virtual DbSet<BaseName> BaseName { get; set; } = null!;
        public virtual DbSet<BaseSchoolName> BaseSchoolName { get; set; } = null!;
        public virtual DbSet<Branch> Branch { get; set; } = null!;
        public virtual DbSet<BranchInfo> BranchInfo { get; set; } = null!;
        public virtual DbSet<CallibrationState> CallibrationState { get; set; } = null!;
        public virtual DbSet<Caste> Caste { get; set; } = null!;
        public virtual DbSet<CodeValue> CodeValue { get; set; } = null!;
        public virtual DbSet<CodeValueType> CodeValueType { get; set; } = null!;
        public virtual DbSet<Country> Country { get; set; } = null!;
        public virtual DbSet<CountryGroup> CountryGroup { get; set; } = null!;
        public virtual DbSet<CourseType> CourseType { get; set; } = null!; 
        public virtual DbSet<CurrencyName> CurrencyName { get; set; } = null!;
        public virtual DbSet<DailyAirworthinessFrom> DailyAirworthinessFrom { get; set; } = null!;
        public virtual DbSet<DailyAirworthinessFromCategory> DailyAirworthinessFromCategory { get; set; } = null!;
        public virtual DbSet<DefenseType> DefenseType { get; set; } = null!;
        public virtual DbSet<DegitalArchieve> DegitalArchieve { get; set; } = null!;
        public virtual DbSet<DegitalArchieveDocType> DegitalArchieveDocType { get; set; } = null!;
        public virtual DbSet<Demand> Demand { get; set; } = null!;

        public virtual DbSet<DemandCompleteStatus> DemandCompleteStatus { get; set; } = null!;
        public virtual DbSet<DemandDoc> DemandDoc { get; set; } = null!;
        public virtual DbSet<DemandType> DemandType { get; set; } = null!;
        public virtual DbSet<DemandStatus> DemandStatus { get; set; } = null!;
        public virtual DbSet<District> District { get; set; } = null!;
        public virtual DbSet<Division> Division { get; set; } = null!;
        public virtual DbSet<EquipmentIssue> EquipmentIssue { get; set; } = null!;
        public virtual DbSet<EquipmentName> EquipmentName { get; set; } = null!;
        public virtual DbSet<FailureStatus> FailureStatus { get; set; } = null!;
        public virtual DbSet<Feature> Feature { get; set; } = null!;
        public virtual DbSet<ForceType> ForceType { get; set; } = null!;
        public virtual DbSet<Gender> Gender { get; set; } = null!;
        public virtual DbSet<Group> Group { get; set; } = null!;
        public virtual DbSet<GseItemName> GseItemName { get; set; } = null!;
        public virtual DbSet<GseMaintenance> GseMaintenance { get; set; } = null!;
        public virtual DbSet<GseMaintenanceScheduleName> GseMaintenanceScheduleName { get; set; } = null!;
        public virtual DbSet<GseScheduleWorkType> GseScheduleWorkType { get; set; } = null!;
        public virtual DbSet<IssueRegister> IssueRegister { get; set; } = null!;
        public virtual DbSet<IssueStatus> IssueStatus { get; set; } = null!;
        public virtual DbSet<ItemCategoryType> ItemCategoryType { get; set; } = null!;
        public virtual DbSet<ItemDetail> ItemDetail { get; set; } = null!;
        public virtual DbSet<ItemInspection> ItemInspection { get; set; } = null!;
        public virtual DbSet<ItemReminder> ItemReminder { get; set; } = null!;
        public virtual DbSet<ItemStor> ItemStor { get; set; } = null!;
        public virtual DbSet<LeaveAllocation> LeaveAllocation { get; set; } = null!;
        public virtual DbSet<LeaveRequest> LeaveRequest { get; set; } = null!;
        public virtual DbSet<LeaveType> LeaveType { get; set; } = null!;
        public virtual DbSet<LifeLimitItem> LifeLimitItem { get; set; } = null!;
        public virtual DbSet<LifeLimitItemRunningHour> LifeLimitItemRunningHour { get; set; } = null!;
        public virtual DbSet<LocalAgent> LocalAgent { get; set; } = null!;
        public virtual DbSet<MaintenanceCategory> MaintenanceCategory { get; set; } = null!;
        public virtual DbSet<MaintenancePlanning> MaintenancePlanning { get; set; } = null!;
        public virtual DbSet<MaintenanceSchedule> MaintenanceSchedule { get; set; } = null!;
        public virtual DbSet<MaintenancePlanningStatus> MaintenancePlanningStatus { get; set; } = null!;
        public virtual DbSet<Manufacture> Manufacture { get; set; } = null!;
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; } = null!;
        public virtual DbSet<Module> Module { get; set; } = null!;
        public virtual DbSet<MeaWorkShop> MeaWorkShop { get; set; } = null!;
        public virtual DbSet<Nationality> Nationality { get; set; } = null!;
        public virtual DbSet<NewAtempt> NewAtempt { get; set; } = null!;
        public virtual DbSet<OfficersStatus> OfficersStatus { get; set; } = null!;
        public virtual DbSet<OverhaulingType> OverhaulingType { get; set; } = null!;
        public virtual DbSet<PartOfShipment> PartOfShipment { get; set; } = null!;
        public virtual DbSet<PlaceOfDelivery> PlaceOfDelivery { get; set; } = null!;
        public virtual DbSet<PresentBillet> PresentBillet { get; set; } = null!;
        public virtual DbSet<PresentState> PresentState { get; set; } = null!;
        public virtual DbSet<PreviousItemStore> PreviousItemStore { get; set; } = null!;
        public virtual DbSet<PrincipalName> PrincipalName { get; set; } = null!;
        public virtual DbSet<Procurement> Procurement { get; set; } = null!;
        public virtual DbSet<ProcurementStatus> ProcurementStatus { get; set; } = null!;
        public virtual DbSet<Religion> Religion { get; set; } = null!;
        public virtual DbSet<ReminderType> ReminderType { get; set; } = null!;
        public virtual DbSet<ResultStatus> ResultStatus { get; set; } = null!;
        public virtual DbSet<RequiredSparesForMaintenance> RequiredSparesForMaintenance { get; set; } = null!;
        public virtual DbSet<RetirementType> RetirementType { get; set; } = null!; 
        public virtual DbSet<Role> Role { get; set; } = null!;
        public virtual DbSet<RoleFeature> RoleFeature { get; set; } = null!;
        public virtual DbSet<ToolsLocation> ToolsLocation { get; set; } = null!;
        public virtual DbSet<ToolsBoxName> ToolsBoxName { get; set; } = null!;
        public virtual DbSet<ShowRight> ShowRight { get; set; } = null!;
        public virtual DbSet<SourceOfSupply> SourceOfSupply { get; set; } = null!;
        public virtual DbSet<StepRelation> StepRelation { get; set; } = null!; 
        public virtual DbSet<SurveyItem> SurveyItem { get; set; } = null!;
        public virtual DbSet<Thana> Thana { get; set; } = null!;
        public virtual DbSet<ToolsIssue> ToolsIssue { get; set; } = null!;
        public virtual DbSet<Trade> Trade { get; set; } = null!; 
        public virtual DbSet<TrainingCrew> TrainingCrew { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;
        public virtual DbSet<UserTransferBackup> UserTransferBackup { get; set; } = null!;
        public virtual DbSet<MaintenenceState> MaintenenceState { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<TestEquipmentDetail> TestEquipmentDetail { get; set; }
  }
}
