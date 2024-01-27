using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.MaintenanceCategory;
using SchoolManagement.Application.DTOs.AccountType;

using SchoolManagement.Application.DTOs.GseMaintenance;
using SchoolManagement.Application.DTOs.GseScheduleWorkType;
using SchoolManagement.Application.DTOs.GseMaintenanceScheduleName;
using SchoolManagement.Application.DTOs.GseItemName;
using SchoolManagement.Application.DTOs.LifeLimitItem;
using SchoolManagement.Application.DTOs.LifeLimitItemRunningHour;
using SchoolManagement.Application.DTOs.ReminderType;
using SchoolManagement.Application.DTOs.Trade;

using SchoolManagement.Application.DTOs.FiscalYears;
using SchoolManagement.Application.DTOs.Denos;
using SchoolManagement.Application.DTOs.ItemTypes;
using SchoolManagement.Application.DTOs.ItemStatuses;
using SchoolManagement.Application.DTOs.Suppliers;
using SchoolManagement.Application.DTOs.ConditionOfItems;
using SchoolManagement.Application.DTOs.EndLifeTypes;
using SchoolManagement.Application.DTOs.ServiceLifeTypes;
using SchoolManagement.Application.DTOs.ItemCategorys;
using SchoolManagement.Application.DTOs.ToolsTypes;
using SchoolManagement.Application.DTOs.SparesCategorys;
using SchoolManagement.Application.DTOs.AcctStores;
using SchoolManagement.Application.DTOs.AcStatus;
using SchoolManagement.Application.DTOs.Courses;
using SchoolManagement.Application.DTOs.Coursees;
using SchoolManagement.Application.DTOs.DemandAuthority;
using SchoolManagement.Application.DTOs.ShelfLifeCategory;
using SchoolManagement.Application.DTOs.Store;
using SchoolManagement.Application.DTOs.Rank;
using SchoolManagement.Application.DTOs.OccasionOfDemand;
using SchoolManagement.Application.DTOs.Authority;
using SchoolManagement.Application.DTOs.DepartmentName;
using SchoolManagement.Application.DTOs.AirCraftName;
using SchoolManagement.Application.DTOs.RunningHour;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory;
using SchoolManagement.Application.DTOs.MaintenanceType;
using SchoolManagement.Application.DTOs.DemandCompleteStatuses;
using SchoolManagement.Application.DTOs.DemandDocs;
using SchoolManagement.Application.DTOs.Acceptances;

using SchoolManagement.Application.DTOs.SourceOfSupply;
using SchoolManagement.Application.DTOs.RetirementType;
using SchoolManagement.Application.DTOs.ProcurementStatus;
using SchoolManagement.Application.DTOs.PrincipalName;
using SchoolManagement.Application.DTOs.PlaceOfDelivery;
using SchoolManagement.Application.DTOs.PartOfShipment;
using SchoolManagement.Application.DTOs.OverhaulingType;
using SchoolManagement.Application.DTOs.OfficersStatus;
using SchoolManagement.Application.DTOs.Manufacture;
using SchoolManagement.Application.DTOs.LocalAgent;
using SchoolManagement.Application.DTOs.ItemCategoryType;
using SchoolManagement.Application.DTOs.DemandType;
using SchoolManagement.Application.DTOs.Demands;
using SchoolManagement.Application.DTOs.ItemDetail;
using SchoolManagement.Application.DTOs.Procurement;

using SchoolManagement.Application.DTOs.ItemInspection;

using SchoolManagement.Application.DTOs.CstTec;
using SchoolManagement.Application.DTOs.ItemStor;
using SchoolManagement.Application.DTOs.IssueStatus;
using SchoolManagement.Application.DTOs.IssueRegister;
using SchoolManagement.Application.DTOs.MaintenancePlanning;
using SchoolManagement.Application.DTOs.TrainingCrew;
using SchoolManagement.Application.DTOs.Features;
using SchoolManagement.Application.DTOs.Modules;
using SchoolManagement.Application.DTOs.Role;
using SchoolManagement.Application.DTOs.RoleFeature;
using SchoolManagement.Application.DTOs.User;
using SchoolManagement.Application.DTOs.Caste;
using SchoolManagement.Application.DTOs.District;
using SchoolManagement.Application.DTOs.Division;
using SchoolManagement.Application.DTOs.Religion;
using SchoolManagement.Application.DTOs.Thana;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.CodeValueType;
using SchoolManagement.Application.DTOs.IssueRegister.MultipleInsertDto;
using SchoolManagement.Application.DTOs.MaintenancePlanningStatus;
using SchoolManagement.Application.Helpers;
using SchoolManagement.Application.DTOs.ToolsLocation;
using SchoolManagement.Application.DTOs.ToolsBoxNames;
using SchoolManagement.Application.DTOs.AirCraftFlying;
using SchoolManagement.Application.DTOs.EquipmentName;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;
using SchoolManagement.Application.DTOs.PreviousItemStore;
using SchoolManagement.Application.DTOs.PresentState;
using SchoolManagement.Application.DTOs.MeaSquadronState;
using SchoolManagement.Application.DTOs.CallibrationState;

using SchoolManagement.Application.DTOs.BaseSchoolNames;
using SchoolManagement.Application.DTOs.NoticeBoards;
//using SchoolManagement.Application.DTOs.NoticeBoardes;
using SchoolManagement.Application.DTOs.DemandStatus;
using SchoolManagement.Application.DTOs.EmployeeType;
using SchoolManagement.Application.DTOs.SailorRank;
using SchoolManagement.Application.DTOs.Status;
using SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory;
using SchoolManagement.Application.DTOs.DailyAirworthinessFrom;
using SchoolManagement.Application.DTOs.RequiredSparesForMaintenance;
using SchoolManagement.Application.DTOs.Survey;
using SchoolManagement.Application.DTOs.StockTransferNsd;
using SchoolManagement.Application.DTOs.DegitalArchieveDocType;
using SchoolManagement.Application.DTOs.DegitalArchieve;
using SchoolManagement.Application.DTOs.MeaWorkShop;
using SchoolManagement.Application.DTOs.MeaBlankFormat;
using SchoolManagement.Application.DTOs.MaintenenceState;
using SchoolManagement.Application.DTOs.NameofPublication;
using SchoolManagement.Application.DTOs.ArchivingforPublication;
using SchoolManagement.Application.DTOs.Attendence;
using SchoolManagement.Application.DTOs.PresentBillets;
using SchoolManagement.Application.DTOs.Shop;
using SchoolManagement.Application.DTOs.TestEquipmentDetail;

namespace SchoolManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


      //Lattar A
            #region Attendence Mapping    
            CreateMap<Attendence, AttendenceDto>().ReverseMap();
            CreateMap<Attendence, CreateAttendenceDto>().ReverseMap();
            #endregion

            #region MaintenanceCategory Mapping    
      CreateMap<MaintenanceCategoryDto, MaintenanceCategory>().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                .ForMember(d => d.MaintenanceType, o => o.MapFrom(s => s.MaintenanceType.Name));
            CreateMap<MaintenanceCategory, CreateMaintenanceCategoryDto>().ReverseMap();
            #endregion

            #region GseMaintenance Mapping    
            CreateMap<GseMaintenanceDto,GseMaintenance>().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                .ForMember(d => d.GseItemName, o => o.MapFrom(s => s.GseItemName.ItemName))
                .ForMember(d => d.GseMaintenanceScheduleName, o => o.MapFrom(s => s.GseMaintenanceScheduleName.ScheduleName))
                .ForMember(d => d.GseScheduleWorkType, o => o.MapFrom(s => s.GseScheduleWorkType.ScheduleWorkName));
            CreateMap<GseMaintenance, CreateGseMaintenanceDto>().ReverseMap();
            #endregion

            #region GseScheduleWorkType Mapping    
            CreateMap<GseScheduleWorkTypeDto, GseScheduleWorkType>().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                .ForMember(d => d.GseMaintenanceScheduleName, o => o.MapFrom(s => s.GseMaintenanceScheduleName.ScheduleName));
            CreateMap<GseScheduleWorkType, CreateGseScheduleWorkTypeDto>().ReverseMap();
            #endregion

            #region GseMaintenanceScheduleName Mapping    
            CreateMap<GseMaintenanceScheduleNameDto, GseMaintenanceScheduleName>().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName));
            CreateMap<GseMaintenanceScheduleName, CreateGseMaintenanceScheduleNameDto>().ReverseMap();
            #endregion

            #region GseItemName Mapping    
            CreateMap<GseItemNameDto,GseItemName>().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName));
            CreateMap<GseItemName, CreateGseItemNameDto>().ReverseMap();
            #endregion

            #region LifeLimitItem Mapping    
            CreateMap<LifeLimitItem, LifeLimitItemDto>().ReverseMap();
            CreateMap<LifeLimitItem, CreateLifeLimitItemDto>().ReverseMap();
            #endregion

            #region CstTec Mapping    
            CreateMap<CstTec, CstTecDto>().ReverseMap();
            CreateMap<CstTec, CreateCstTecDto>().ReverseMap();
            #endregion

            #region EmployeeType Mapping    
            CreateMap<EmployeeType, EmployeeTypeDto>().ReverseMap();
            CreateMap<EmployeeType, CreateEmployeeTypeDto>().ReverseMap();
            #endregion

            #region SailorRank Mapping    
            CreateMap<SailorRank, SailorRankDto>().ReverseMap();
            CreateMap<SailorRank, CreateSailorRankDto>().ReverseMap();
            #endregion

            #region LifeLimitItemRunningHour Mapping    
      CreateMap<LifeLimitItemRunningHourDto,LifeLimitItemRunningHour>().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                .ForMember(d => d.LifeLimitItem, o => o.MapFrom(s => s.LifeLimitItem.Name))
                .ForMember(d => d.MaintenanceCategory, o => o.MapFrom(s => s.MaintenanceCategory.CategoryName));
            CreateMap<LifeLimitItemRunningHour, CreateLifeLimitItemRunningHourDto>().ReverseMap();
            #endregion

            #region ReminderType Mapping    
            CreateMap<ReminderType, ReminderTypeDto>().ReverseMap();
            CreateMap<ReminderType, CreateReminderTypeDto>().ReverseMap();
            #endregion

            #region Trade Mapping    
            CreateMap<Trade, TradeDto>().ReverseMap();
            CreateMap<Trade, CreateTradeDto>().ReverseMap();
            #endregion

            #region Procurement Mapping    
            CreateMap<ProcurementDto, Procurement>().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                .ForMember(d => d.DemandType, o => o.MapFrom(s => s.DemandType.Name))
                .ForMember(d => d.CstTec, o => o.MapFrom(s => s.CstTec.Name))
                .ForMember(d => d.Supplier, o => o.MapFrom(s => s.Supplier.CompanyName))
                .ForMember(d => d.ItemDetail, o => o.MapFrom(s => s.ItemDetail.PartNo))
                .ForMember(d => d.ItemName, o => o.MapFrom(s => s.ItemDetail.NameOfItem))
                .ForMember(d => d.TenderSpecification, o => o.MapFrom<ProcurementFileUrlResolver>())
                .ForMember(d => d.TenderNotice, o => o.MapFrom<ProcurementCSTFileUrlResolver>())
                .ForMember(d => d.ProcurementDocument, o => o.MapFrom<ProcurementPurchFileUrlResolver>());
            CreateMap<Procurement, CreateProcurementDto>().ReverseMap();
            #endregion


            #region Features Mapping    
            CreateMap<FeatureDto, Feature>().ReverseMap()
             .ForMember(d => d.ModuleName, o => o.MapFrom(s => s.Module.ModuleName));

            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            #endregion

            #region Modules Mapping    
            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<Module, ModuleFeatureDto>().ReverseMap();

            CreateMap<Module, CreateModuleDto>().ReverseMap();
            #endregion 

            #region Role Mappings 
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, CreateRoleDto>().ReverseMap();
            #endregion

            #region RoleFeature Mappings 
            CreateMap<RoleFeature, RoleFeatureDto>().ReverseMap();
            CreateMap<RoleFeature, CreateRoleFeatureDto>().ReverseMap();
            #endregion

            //#region User Mapping    
            //CreateMap<UserDto, User>().ReverseMap()
            //  .ForMember(d => d.Role, o => o.MapFrom(s => s.Role.RoleName))
            //  .ForMember(d => d.BranchInfo, o => o.MapFrom(s => s.BranchInfo.BranchName));
            //CreateMap<User, CreateUserDto>().ReverseMap();
            //#endregion

            #region Caste Mappings
            CreateMap<CasteDto, Caste>().ReverseMap()
              .ForMember(d => d.Religion, o => o.MapFrom(s => s.Religion.ReligionName));

            CreateMap<Caste, CreateCasteDto>().ReverseMap();
            #endregion

            #region Religion Mappings
            CreateMap<Religion, ReligionDto>().ReverseMap();
            CreateMap<Religion, CreateReligionDto>().ReverseMap();
            #endregion


            #region Division Mappings
            CreateMap<Division, DivisionDto>().ReverseMap();
            CreateMap<Division, CreateDivisionDto>().ReverseMap();
            #endregion


            #region BaseSchoolNames Mapping   
            CreateMap<BaseSchoolName, BaseSchoolNameDto>().ReverseMap();
            CreateMap<BaseSchoolName, CreateBaseSchoolNameDto>().ReverseMap();
            #endregion  

            #region District Mappings
            CreateMap<DistrictDto, District>().ReverseMap()
              .ForMember(d => d.Division, o => o.MapFrom(s => s.Division.DivisionName));
            CreateMap<District, CreateDistrictDto>().ReverseMap();
            #endregion

            #region Thana Mappings
            CreateMap<ThanaDto, Thana>().ReverseMap()
              .ForMember(d => d.District, o => o.MapFrom(s => s.District.DistrictName));
            CreateMap<Thana, CreateThanaDto>().ReverseMap();
            #endregion

            #region CodeValues  Mappings 
            CreateMap<CodeValueDto, CodeValue>().ReverseMap()
              .ForMember(d => d.CodeValueType, o => o.MapFrom(s => s.CodeValueType.Type));

            CreateMap<CodeValue, CreateCodeValueDto>().ReverseMap();
            #endregion

            #region CodeValueType  Mappings 
            CreateMap<CodeValueType, CodeValueTypeDto>().ReverseMap();
            CreateMap<CodeValueType, CreateCodeValueTypeDto>().ReverseMap();
            #endregion

            //#region Procurement Mapping    
            //CreateMap<ProcurementDto, Procurement>().ReverseMap()
            //    .ForMember(d => d.Demand, o => o.MapFrom(s => s.Demand.RefPoNo))
            //    .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.Name))
            //    .ForMember(d => d.ItemDetail, o => o.MapFrom(s => s.ItemDetail.PartNo))
            //    .ForMember(d => d.LocalAgent, o => o.MapFrom(s => s.LocalAgent.Name))
            //    .ForMember(d => d.PartOfShipment, o => o.MapFrom(s => s.PartOfShipment.Name))
            //    .ForMember(d => d.PrincipalName, o => o.MapFrom(s => s.PrincipalName.Name))
            //    .ForMember(d => d.ProcurementStatus, o => o.MapFrom(s => s.ProcurementStatus.Name));
            //CreateMap<Procurement, CreateProcurementDto>().ReverseMap();
            //#endregion



            #region AccountType Mapping    
            CreateMap<AccountType, AccountTypeDto>().ReverseMap();
            CreateMap<AccountType, CreateAccountTypeDto>().ReverseMap();
            #endregion

            //#region CallibrationState Mapping    
            //CreateMap<CallibrationState, CallibrationStateDto>().ReverseMap();
            //   // .ForMember(d => d.Trade, o => o.MapFrom(s => s.Trade.Name));
            //CreateMap<CallibrationState, CreateCallibrationStateDto>().ReverseMap();
            //#endregion

            #region CallibrationState Mapping    
            CreateMap<CallibrationStateDto, CallibrationState>().ReverseMap()
                .ForMember(d => d.Trade, o => o.MapFrom(s => s.Trade.Name));
            CreateMap<CallibrationState, CreateCallibrationStateDto>().ReverseMap() 
                .ForMember(d => d.LastDateofCalibrated, o => o.MapFrom(s => s.CompletedDate))
                .ForMember(d => d.NextDueDate, o => o.MapFrom(s => s.NextCalibrationDate));
      #endregion

            #region MaintenenceState Mapping    
            CreateMap<MaintenenceStateDto, MaintenenceState>().ReverseMap()
                      .ForMember(d => d.Trade, o => o.MapFrom(s => s.Trade.Name));
      CreateMap<MaintenenceState, CreateMaintenenceStateDto>().ReverseMap()
          .ForMember(d => d.LastDateofMaintenence, o => o.MapFrom(s => s.CompletedDate));
                //.ForMember(d => d.NextDueDate, o => o.MapFrom(s => s.Next));
            #endregion

            #region FiscalYear Mappings 
      CreateMap<FiscalYear, FiscalYearDto>().ReverseMap();
            CreateMap<FiscalYear, CreateFiscalYearDto>().ReverseMap();
            #endregion

            #region DemandStatus Mappings 
            CreateMap<DemandStatus, DemandStatusDto>().ReverseMap();
            CreateMap<DemandStatus, CreateDemandStatusDto>().ReverseMap();
            #endregion

            #region RequiredSparesForMaintenance Mappings 
            CreateMap<RequiredSparesForMaintenanceDto, RequiredSparesForMaintenance >().ReverseMap()
                    .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                    .ForMember(d => d.MaintenanceType, o => o.MapFrom(s => s.MaintenanceType.Name))
                    .ForMember(d => d.MaintenanceCategory, o => o.MapFrom(s => s.MaintenanceCategory.CategoryName))
                    .ForMember(d => d.MaintenanceSubCategory, o => o.MapFrom(s => s.MaintenanceSubCategory.SubCategoryName))
                    .ForMember(d => d.PattNo, o => o.MapFrom(s => s.ItemDetail.PartNo))
                    .ForMember(d => d.ItemName, o => o.MapFrom(s => s.ItemDetail.NameOfItem));
            CreateMap<RequiredSparesForMaintenance, CreateRequiredSparesForMaintenanceDto>().ReverseMap();
            #endregion

            #region Deno Mappings 
      CreateMap<Deno, DenoDto>().ReverseMap();
            CreateMap<Deno, CreateDenoDto>().ReverseMap();
            #endregion
            #region EquipmentName Mappings 
            CreateMap<EquipmentNameDto, EquipmentName>().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName));
            CreateMap<EquipmentName, CreateEquipmentNameDto>().ReverseMap();
            #endregion

            #region ItemType Mappings 
            CreateMap<ItemType, ItemTypeDto>().ReverseMap();
            CreateMap<ItemType, CreateItemTypeDto>().ReverseMap();
            #endregion

            #region ItemStatus Mappings 
            CreateMap<ItemStatus, ItemStatusDto>().ReverseMap();
            CreateMap<ItemStatus, CreateItemStatusDto>().ReverseMap();
            #endregion

            #region ShelfLifeCategory Mapping    
            CreateMap<ShelfLifeCategory, ShelfLifeCategoryDto>().ReverseMap();
            CreateMap<ShelfLifeCategory, CreateShelfLifeCategoryDto>().ReverseMap();
            #endregion

            #region Store Mapping    
            CreateMap<Store, StoreDto>().ReverseMap();
            CreateMap<Store, CreateStoreDto>().ReverseMap();
            #endregion

            #region Rank Mapping    
            CreateMap<Rank, RankDto>().ReverseMap();
            CreateMap<Rank, CreateRankDto>().ReverseMap();
            #endregion


            #region OccasionOfDemand Mapping    
            CreateMap<OccasionOfDemandDto, OccasionOfDemand>().ReverseMap()
                .ForMember(d => d.FiscalYear, o => o.MapFrom(s => s.FiscalYear.FiscalYearName));
            CreateMap<OccasionOfDemand, CreateOccasionOfDemandDto>().ReverseMap();
            #endregion

            #region Authority Mapping    
            CreateMap<Authority, AuthorityDto>().ReverseMap();
            CreateMap<Authority, CreateAuthorityDto>().ReverseMap();
            #endregion

            #region DepartmentName Mapping    
            CreateMap<DepartmentName, DepartmentNameDto>().ReverseMap();
            CreateMap<DepartmentName, CreateDepartmentNameDto>().ReverseMap();
            #endregion

            #region AirCraftName Mapping    
            CreateMap<AirCraftNameDto, AirCraftName>().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                .ForMember(d => d.Image, o => o.MapFrom<PhotoUrlResolver>());
            CreateMap<AirCraftName, CreateAirCraftNameDto>().ReverseMap();
            #endregion

            #region AirCraftFlying Mapping    
            CreateMap<AirCraftFlyingDto, AirCraftFlying>().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                .ForMember(d => d.AirCraftName, o => o.MapFrom(s => s.AirCraftName.Name));
            CreateMap<AirCraftFlying, CreateAirCraftFlyingDto>().ReverseMap();
            CreateMap<AirCraftFlyingDelayDto, AirCraftFlying>().ReverseMap();
      #endregion

            #region RunningHour Mapping    
            CreateMap<RunningHourDto, RunningHour>().ReverseMap()
                .ForMember(d => d.AirCraftName, o => o.MapFrom(s => s.AirCraftName.Name))
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName));
            CreateMap<RunningHour, CreateRunningHourDto>().ReverseMap();
            #endregion

            #region MaintenanceSubCategory Mapping    
            CreateMap<MaintenanceSubCategoryDto, MaintenanceSubCategory>().ReverseMap()
                .ForMember(d => d.MaintenanceCategory, o => o.MapFrom(s => s.MaintenanceCategory.CategoryName))
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName));
            CreateMap<MaintenanceSubCategory, CreateMaintenanceSubCategoryDto>().ReverseMap();
            #endregion

            #region MaintenanceType Mapping    
            CreateMap<MaintenanceTypeDto, MaintenanceType>().ReverseMap()
                 .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName));
            CreateMap<MaintenanceType, CreateMaintenanceTypeDto>().ReverseMap();
            #endregion

            #region NoticeBoard Mapping    
            CreateMap<NoticeBoardDto, NoticeBoard>().ReverseMap()
                .ForMember(x=>x.DepartmentName,o=>o.MapFrom(s=>s.DepartmentName.SchoolName))
                .ForMember(d => d.NoticeDocument, o => o.MapFrom<NoticeBoardFileUrlResolver>());
            CreateMap<NoticeBoard, CreateNoticeBoardDto>().ReverseMap();
            #endregion

            #region SourceOfSupply Mapping    
            CreateMap<SourceOfSupply, SourceOfSupplyDto>().ReverseMap();
            CreateMap<SourceOfSupply, CreateSourceOfSupplyDto>().ReverseMap();
            #endregion

            #region RetirementType Mapping    
            CreateMap<RetirementType, RetirementTypeDto>().ReverseMap();
            CreateMap<RetirementType, CreateRetirementTypeDto>().ReverseMap();
            #endregion

            #region ProcurementStatus Mapping    
            CreateMap<ProcurementStatus, ProcurementStatusDto>().ReverseMap();
            CreateMap<ProcurementStatus, CreateProcurementStatusDto>().ReverseMap();
            #endregion

            #region PrincipalName Mapping    
            CreateMap<PrincipalName, PrincipalNameDto>().ReverseMap();
            CreateMap<PrincipalName, CreatePrincipalNameDto>().ReverseMap();
            #endregion

            #region PresentState Mapping    
            CreateMap<PresentState, PresentStateDto>().ReverseMap();
            CreateMap<PresentState, CreatePresentStateDto>().ReverseMap();
           #endregion
       
          #region PresentBillet Mapping    
          CreateMap<PresentBillet, PresentBilletDto>().ReverseMap();
          CreateMap<PresentBillet, CreatePresentBilletDto>().ReverseMap();
          #endregion

      #region DailyAirworthinessFromCategory Mapping    
      CreateMap<DailyAirworthinessFromCategoryDto, DailyAirworthinessFromCategory>().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName));
            CreateMap<DailyAirworthinessFromCategory, CreateDailyAirworthinessFromCategoryDto>().ReverseMap();
            #endregion

            #region DailyAirworthinessFrom Mapping    
            CreateMap<DailyAirworthinessFromDto, DailyAirworthinessFrom>().ReverseMap()
              .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
              .ForMember(d => d.FromCategory, o => o.MapFrom(s => s.DailyAirworthinessFromCategory.Name))
              .ForMember(d => d.AircraftName, o => o.MapFrom(s => s.AirCraftName.Name))
              .ForMember(d => d.Doc, o => o.MapFrom<AirworthinessFromFileUrlResolver>());
            CreateMap<DailyAirworthinessFrom, CreateDailyAirworthinessFromDto>().ReverseMap();
            #endregion

            #region Status Mapping    
            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<Status, CreateStatusDto>().ReverseMap();
            #endregion

            #region PreviousItemStore Mapping    
      CreateMap<PreviousItemStoreDto, PreviousItemStore>().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                .ForMember(d => d.PattNo, o => o.MapFrom(s => s.ItemDetail.PartNo))
                .ForMember(d => d.ItemDetail, o => o.MapFrom(s => s.ItemDetail.PartNo))
                .ForMember(d => d.ToolsBoxName, o => o.MapFrom(s => s.ToolsBoxName.Name))
                .ForMember(d => d.ToolsLocation, o => o.MapFrom(s => s.ToolsLocation.ToolsLocationName))
                .ForMember(d => d.ToolsType, o => o.MapFrom(s => s.ToolsType.Name))
                .ForMember(d => d.Deno, o => o.MapFrom(s => s.Deno.Name))
                .ForMember(d => d.ItemCategory, o => o.MapFrom(s => s.ItemCategory.Name))
                .ForMember(d => d.SparesCategory, o => o.MapFrom(s => s.SparesCategory.Name))
                .ForMember(d => d.ServisLifeType, o => o.MapFrom(s => s.ServiceLifeType.Name))
                .ForMember(d => d.EndLifeType, o => o.MapFrom(s => s.EndLifeType.Name))
                .ForMember(d => d.AcctStore, o => o.MapFrom(s => s.AcctStore.Name))
                .ForMember(d => d.OverhawlingType, o => o.MapFrom(s => s.OverhaulingType.Name))
                .ForMember(d => d.RetirmentType, o => o.MapFrom(s => s.RetirementType.Name));
            CreateMap<PreviousItemStore, CreatePreviousItemStoreDto>().ReverseMap();
            #endregion

            #region PlaceOfDelivery Mapping    
            CreateMap<PlaceOfDelivery, PlaceOfDeliveryDto>().ReverseMap();
            CreateMap<PlaceOfDelivery, CreatePlaceOfDeliveryDto>().ReverseMap();
            #endregion

            #region PartOfShipment Mapping    
            CreateMap<PartOfShipment, PartOfShipmentDto>().ReverseMap();
            CreateMap<PartOfShipment, CreatePartOfShipmentDto>().ReverseMap();
            #endregion

            #region OverhaulingType Mapping    
            CreateMap<OverhaulingType, OverhaulingTypeDto>().ReverseMap();
            CreateMap<OverhaulingType, CreateOverhaulingTypeDto>().ReverseMap();
            #endregion


            #region OfficersStatus Mapping    
            CreateMap<OfficersStatus, OfficersStatusDto>().ReverseMap();
            CreateMap<OfficersStatus, CreateOfficersStatusDto>().ReverseMap();
            #endregion


            #region Supplier Mappings 
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Supplier, CreateSupplierDto>().ReverseMap();
            #endregion

            #region MeaWorkShop Mappings 
            CreateMap<MeaWorkShop, MeaWorkShopDto>().ReverseMap();
            CreateMap<MeaWorkShop, CreateMeaWorkShopDto>().ReverseMap();
            #endregion

            #region DegitalArchieve Mappings 
            CreateMap<DegitalArchieveDto, DegitalArchieve >().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                .ForMember(d => d.AircraftName, o => o.MapFrom(s => s.AirCraftName.Name))
                .ForMember(d => d.DegitalArchieveDocType, o => o.MapFrom(s => s.DegitalArchieveDocType.Name))
                .ForMember(d => d.Doc, o => o.MapFrom<DegitalArchieveFileUrlResolver>());
            CreateMap<DegitalArchieve, CreateDegitalArchieveDto>().ReverseMap();
            #endregion

            #region DegitalArchieveDocType Mappings 
            CreateMap<DegitalArchieveDocType, DegitalArchieveDocTypeDto>().ReverseMap();
            CreateMap<DegitalArchieveDocType, CreateDegitalArchieveDocTypeDto>().ReverseMap();
            #endregion

            #region Survey Mappings 
            CreateMap<SurveyDto, Survey >().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                .ForMember(d => d.PattNo, o => o.MapFrom(s => s.ItemDetail.PartNo))
                .ForMember(d => d.ItemName, o => o.MapFrom(s => s.ItemDetail.NameOfItem))
                .ForMember(d => d.IMC, o => o.MapFrom(s => s.ItemDetail.ImcNumber))
                .ForMember(d => d.ItemCategory, o => o.MapFrom(s => s.ItemCategory.Name));
            CreateMap<Survey, CreateSurveyDto>().ReverseMap();
            #endregion

            #region StockTransferNsd Mappings 
            CreateMap<StockTransferNsdDto, StockTransferNsd >().ReverseMap()
              .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
              .ForMember(d => d.PattNo, o => o.MapFrom(s => s.ItemDetail.PartNo))
              .ForMember(d => d.ItemName, o => o.MapFrom(s => s.ItemDetail.NameOfItem))
              .ForMember(d => d.ToolsLocation, o => o.MapFrom(s => s.ToolsLocation.ToolsLocationName))
              .ForMember(d => d.DemandAuthority, o => o.MapFrom(s => s.DemandAuthority.Name))
               .ForMember(d => d.Doc, o => o.MapFrom<StockTransferNsdFileUrlResolver>());
            CreateMap<StockTransferNsd, CreateStockTransferNsdDto>().ReverseMap();
            #endregion



            #region ConditionOfItem Mappings 
      CreateMap<ConditionOfItem, ConditionOfItemDto>().ReverseMap();
            CreateMap<ConditionOfItem, CreateConditionOfItemDto>().ReverseMap();
            #endregion 

            #region EndLifeType Mappings 
            CreateMap<EndLifeType, EndLifeTypeDto>().ReverseMap();
            CreateMap<EndLifeType, CreateEndLifeTypeDto>().ReverseMap();
            #endregion

            #region ServiceLifeType Mappings 
            CreateMap<ServiceLifeType, ServiceLifeTypeDto>().ReverseMap();
            CreateMap<ServiceLifeType, CreateServiceLifeTypeDto>().ReverseMap();
            #endregion

            #region ItemCategory Mappings  
            CreateMap<ItemCategory, ItemCategoryDto>().ReverseMap();
            CreateMap<ItemCategory, CreateItemCategoryDto>().ReverseMap();
            #endregion

            #region ToolsType Mappings 
            CreateMap<ToolsType, ToolsTypeDto>().ReverseMap();
            CreateMap<ToolsType, CreateToolsTypeDto>().ReverseMap();
            #endregion

            #region SparesCategory Mappings  
            CreateMap<SparesCategory, SparesCategoryDto>().ReverseMap();
            CreateMap<SparesCategory, CreateSparesCategoryDto>().ReverseMap();
            #endregion

            #region AcctStore Mappings  
            CreateMap<AcctStore, AcctStoreDto>().ReverseMap();
            CreateMap<AcctStore, CreateAcctStoreDto>().ReverseMap();
            #endregion

            #region AcctStatus Mappings   
            CreateMap<AcStatusDto, AcStatus>().ReverseMap()
                .ForMember(d => d.AircraftName, o => o.MapFrom(s => s.AirCraftName.Name))
                .ForMember(d => d.AircraftStatus, o => o.MapFrom(s => s.AirCraftName.AircraftStatus))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.Name));
                CreateMap<AcStatus, CreateAcStatusDto>().ReverseMap();
            #endregion

            #region Course Mappings   
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            #endregion

            #region DemandAuthority Mappings   
            CreateMap<DemandAuthority, DemandAuthorityDto>().ReverseMap();
            CreateMap<DemandAuthority, CreateDemandAuthorityDto>().ReverseMap();
            #endregion

            #region DemandCompleteStatus Mappings   
            CreateMap<DemandCompleteStatus, DemandCompleteStatusDto>().ReverseMap();
            CreateMap<DemandCompleteStatus, CreateDemandCompleteStatusDto>().ReverseMap();
            #endregion

            #region DemandDoc Mappings   
            CreateMap<DemandDoc, DemandDocDto>().ReverseMap();
            CreateMap<DemandDoc, CreateDemandDocDto>().ReverseMap();
            #endregion

            #region Acceptance Mappings   
            CreateMap<AcceptanceDto, Acceptance>().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                .ForMember(d => d.DemandType, o => o.MapFrom(s => s.DemandType.Name))
                .ForMember(d => d.Condition, o => o.MapFrom(s => s.ConditionOfItem.Name))
                .ForMember(d => d.ItemDetail, o => o.MapFrom(s => s.ItemDetail.PartNo))
                .ForMember(d => d.ItemName, o => o.MapFrom(s => s.ItemDetail.NameOfItem))
                .ForMember(d => d.DemandDate, o => o.MapFrom(s => s.Demand.DemandDate))
                .ForMember(d => d.OuterLatterNo, o => o.MapFrom(s => s.Demand.LetterOuterNo))
                .ForMember(d => d.AcceptanceDocument, o => o.MapFrom<FileUrlResolverAcceptances>());
            CreateMap<Acceptance, CreateAcceptanceDto>().ReverseMap();
            #endregion

            #region Manufacture Mappings   
            CreateMap<Manufacture, ManufactureDto>().ReverseMap();
            CreateMap<Manufacture, CreateManufactureDto>().ReverseMap();
            #endregion

            #region LocalAgent Mappings   
            CreateMap<LocalAgent, LocalAgentDto>().ReverseMap();
            CreateMap<LocalAgent, CreateLocalAgentDto>().ReverseMap();
            #endregion

            #region ItemCategoryType Mappings   
            CreateMap<ItemCategoryType, ItemCategoryTypeDto>().ReverseMap();
            CreateMap<ItemCategoryType, CreateItemCategoryTypeDto>().ReverseMap();
            #endregion


            #region DemandType Mappings   
            CreateMap<DemandType, DemandTypeDto>().ReverseMap();
            CreateMap<DemandType, CreateDemandTypeDto>().ReverseMap();
            #endregion

            #region NameofPublication Mappings   
            CreateMap<NameofPublicationDto, NameofPublication>().ReverseMap()
              .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName));
            CreateMap<NameofPublication, CreateNameofPublicationDto>().ReverseMap();
            #endregion

            #region ArchivingforPublication Mappings   
            CreateMap<ArchivingforPublicationDto, ArchivingforPublication>().ReverseMap()
              .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
              .ForMember(d => d.AircraftName, o => o.MapFrom(s => s.AirCraftName.Name))
              .ForMember(d => d.NameofPublication, o => o.MapFrom(s => s.NameofPublication.Name))
              .ForMember(d => d.DocUpload, o => o.MapFrom<ArchivingforPublicationFileUrlResolver>());
            CreateMap<ArchivingforPublication, CreateArchivingforPublicationDto>().ReverseMap();
            #endregion


            #region Demand Mappings   
      CreateMap<DemandDto, Demand>().ReverseMap()
                .ForMember(d => d.DemandAuthority, o => o.MapFrom(s => s.DemandAuthority.Name))
                .ForMember(d => d.Authority, o => o.MapFrom(s => s.Authority.Name))
                .ForMember(d => d.Deno, o => o.MapFrom(s => s.Deno.Name))
                .ForMember(d => d.Supplier, o => o.MapFrom(s => s.Supplier.CompanyName))
                .ForMember(d => d.Manufacture, o => o.MapFrom(s => s.Manufacture.Name))
                .ForMember(d => d.ConditionOfItem, o => o.MapFrom(s => s.ConditionOfItem.Name))
                .ForMember(d => d.OccasionOfDemand, o => o.MapFrom(s => s.OccasionOfDemand.Name))
                .ForMember(d => d.FiscalYear, o => o.MapFrom(s => s.FiscalYear.FiscalYearName))
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                .ForMember(d => d.ItemDetail, o => o.MapFrom(s => s.ItemDetail.PartNo))
                .ForMember(d => d.PartNo, o => o.MapFrom(s => s.ItemDetail.PartNo))
                .ForMember(d => d.ItemName, o => o.MapFrom(s => s.ItemDetail.NameOfItem))
                .ForMember(d => d.ImcNumber, o => o.MapFrom(s => s.ItemDetail.ImcNumber))
                .ForMember(d => d.DemandType, o => o.MapFrom(s => s.DemandType.Name))
                .ForMember(d => d.Tread, o => o.MapFrom(s => s.Trade.Name))
                .ForMember(d => d.ItemCategory, o => o.MapFrom(s => s.ItemCategory.Name))
                .ForMember(d => d.DemandStatus, o => o.MapFrom(s => s.DemandStatus.Name))
                .ForMember(d => d.DemandLetterNo, o => o.MapFrom<FileUrlResolver>())
                .ForMember(d => d.SpecDoc, o => o.MapFrom<FileSpecUrlResolver>());
            CreateMap<Demand, CreateDemandDto>().ReverseMap();
            #endregion

            #region ItemDetail Mappings   

            CreateMap<ItemDetailDto, ItemDetail >().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                .ForMember(d => d.Trade, o => o.MapFrom(s => s.Trade.Name));
            CreateMap<ItemDetail, CreateItemDetailDto>().ReverseMap();
            #endregion

            #region ItemInspection Mappings   
            CreateMap<ItemInspection, ItemInspectionDto>().ReverseMap();
            CreateMap<ItemInspection, CreateItemInspectionDto>().ReverseMap();
            #endregion

            #region ItemStor Mappings   
            CreateMap<ItemStorDto, ItemStor>().ReverseMap()
             .ForMember(d => d.ItemDetail, o => o.MapFrom(s => s.ItemDetail.NameOfItem))
             .ForMember(d => d.Deno, o => o.MapFrom(s => s.Deno.Name))
             .ForMember(d => d.AcctStore, o => o.MapFrom(s => s.AcctStore.Name))
             .ForMember(d => d.PartNo, o => o.MapFrom(s => s.ItemDetail.PartNo))
             .ForMember(d => d.NameOfItem, o => o.MapFrom(s => s.ItemDetail.NameOfItem))
             .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
             .ForMember(d => d.SparesCategory, o => o.MapFrom(s => s.SparesCategory.Name))
             .ForMember(d => d.Condition, o => o.MapFrom(s => s.ConditionOfItem.Name))
             .ForMember(d => d.LifeLimitItem, o => o.MapFrom(s => s.LifeLimitItem.Name))
             .ForMember(d => d.ToolsType, o => o.MapFrom(s => s.ToolsType.Name))
             .ForMember(d => d.ToolsLocation, o => o.MapFrom(s => s.ToolsLocation.ToolsLocationName))
             .ForMember(d => d.ToolsBoxName, o => o.MapFrom(s => s.ToolsBoxName.Name))
             //.ForMember(d => d.TenderSpecification, o => o.MapFrom<ProcurementFileUrlResolver>(s => s.ItemStor.Procurement.TenderSpecification))
             //.ForMember(d => d.OtherDoc, o => o.MapFrom<ItemStoreFileUrlResolver>())
              .ForMember(d => d.OtherDoc, o => o.MapFrom<ItemStoreFileUrlResolver>());
            CreateMap<ItemStor, CreateItemStorDto>().ReverseMap();
            #endregion

            //#region ItemStorDto Mappings   
            //CreateMap<ItemStor, ItemStorDto>().ReverseMap();
            //CreateMap<ItemStor, CreateItemStorDto>().ReverseMap();
            //#endregion

            #region IssueStatus Mappings   
            CreateMap<IssueStatus, IssueStatusDto>().ReverseMap();
            CreateMap<IssueStatus, CreateIssueStatusDto>().ReverseMap();
            #endregion

            #region IssueRegister Mappings   
            CreateMap<IssueRegisterDto, IssueRegister>().ReverseMap()
                .ForMember(d => d.Pno, o => o.MapFrom(s => s.TrainingCrew.Pno))
                .ForMember(d => d.Name, o => o.MapFrom(s =>s.TrainingCrew.Name))
                .ForMember(d => d.ItemName, o => o.MapFrom(s => s.ItemDetail.NameOfItem))
                .ForMember(d => d.PartNO, o => o.MapFrom(s => s.ItemDetail.PartNo));
            CreateMap<IssueRegister, CreateIssueRegisterDto>().ReverseMap();
      #endregion

      #region MaintenancePlanning Mappings   
      CreateMap<MaintenancePlanningDto, MaintenancePlanning>().ReverseMap()
          .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
          .ForMember(d => d.AirCraftName, o => o.MapFrom(s => s.AirCraftName.Name))
          .ForMember(d => d.CategoryType, o => o.MapFrom(s => s.MaintenanceType.Name))
          .ForMember(d => d.Category, o => o.MapFrom(s => s.MaintenanceCategory.CategoryName))
          .ForMember(d => d.MPStatus, o => o.MapFrom(s => s.MaintenancePlanningStatus.Name))
          .ForMember(d => d.SubCategory, o => o.MapFrom(s => s.MaintenanceSubCategory.SubCategoryName))
          .ForMember(d => d.JobListDocument, o => o.MapFrom<MaintenanceFileUrlResolver>());
            CreateMap<MaintenancePlanning, CreateMaintenancePlanningDto>().ReverseMap();
            #endregion

            #region MeaSquadronState Mappings   
            CreateMap<MeaSquadronStateDto, MeaSquadronState>().ReverseMap()
                .ForMember(d => d.PresentState, o => o.MapFrom(s => s.PresentState.Name))
                .ForMember(d => d.PattNo, o => o.MapFrom(s => s.ItemDetail.PartNo))
                .ForMember(d => d.ItemName, o => o.MapFrom(s => s.ItemDetail.NameOfItem))
                .ForMember(d => d.Trad, o => o.MapFrom(s => s.Trade.Name))
                .ForMember(d => d.WorkShop, o => o.MapFrom(s => s.MeaWorkShop.Name))
                .ForMember(d => d.ItemCondition, o => o.MapFrom(s => s.ConditionOfItem.Name))
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName));
            CreateMap<MeaSquadronState, CreateMeaSquadronStateDto>().ReverseMap();
            CreateMap<CompletedMeaSquadronStateDto, MeaSquadronState>().ReverseMap();
            CreateMap<RemarksUpdateMeaSquadronStateDto, MeaSquadronState>().ReverseMap();
            #endregion

            #region MeaBlankFormat Mappings   
            CreateMap<MeaBlankFormatDto, MeaBlankFormat>().ReverseMap()
              .ForMember(d => d.Doc, o => o.MapFrom<MeaBlankFormatFileUrlResolver>());
            CreateMap<MeaBlankFormat, CreateMeaBlankFormatDto>().ReverseMap();
            #endregion

            #region MaintenanceSchedule Mappings   
            CreateMap<MaintenanceScheduleDto, MaintenanceSchedule>().ReverseMap()
                      .ForMember(d => d.MaintenancePlanning, o => o.MapFrom(s => s.MaintenancePlanning.LastInspDate))
                      .ForMember(d => d.LastInspectiobFh, o => o.MapFrom(s => s.MaintenancePlanning.LastInspectionFH))
                      .ForMember(d => d.LastInspectiobOh, o => o.MapFrom(s => s.MaintenancePlanning.LastInspectionOH))
                      .ForMember(d => d.JobCard, o => o.MapFrom(s => s.MaintenancePlanning.JobListDocument))
                      .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName))
                      .ForMember(d => d.AirCraftName, o => o.MapFrom(s => s.AirCraftName.Name))
                      .ForMember(d => d.CategoryType, o => o.MapFrom(s => s.MaintenanceType.Name))
                      .ForMember(d => d.Category, o => o.MapFrom(s => s.MaintenanceCategory.CategoryName))
                      .ForMember(d => d.MPStatus, o => o.MapFrom(s => s.MaintenancePlanningStatus.Name))
                      .ForMember(d => d.SubCategory, o => o.MapFrom(s => s.MaintenanceSubCategory.SubCategoryName))
                      .ForMember(d => d.ExtensionDays, o => o.MapFrom(s => s.MaintenanceSubCategory.AllowedExtension));
                  CreateMap<MaintenanceSchedule, CreateMaintenanceScheduleDto>().ReverseMap();
                  CreateMap<CompletedScheduleMaintDto, MaintenanceSchedule>().ReverseMap();
                 #endregion

            #region TrainingCrew Mappings   
            CreateMap<TrainingCrewDto, TrainingCrew>().ReverseMap()
                .ForMember(d => d.Rank, o => o.MapFrom(s => s.Rank.Name))
                 .ForMember(d => d.RankRemarks, o => o.MapFrom(s => s.Rank.Remarks))
                .ForMember(d => d.OfficersStatus, o => o.MapFrom(s => s.OfficersStatus.Name))
                .ForMember(d => d.SailorRank, o => o.MapFrom(s => s.SailorRank.Name))
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName.SchoolName));
            CreateMap<TrainingCrew, CreateTrainingCrewDto>().ReverseMap();
            #endregion

            #region MaintenancePlanningStatus Mappings   
            CreateMap<MaintenancePlanningStatus, MaintenancePlanningStatusDto>().ReverseMap();
            CreateMap<MaintenancePlanningStatus, CreateMaintenancePlanningStatusDto>().ReverseMap();
            #endregion

            #region ToolsLocation Mappings   
            CreateMap<ToolsLocation, ToolsLocationDto>().ReverseMap();
            CreateMap<ToolsLocation, CreateToolsLocationDto>().ReverseMap();
            #endregion
             
            #region ToolsBoxName Mappings   
            CreateMap<ToolsBoxName, ToolsBoxNameDto>().ReverseMap();
            CreateMap<ToolsBoxName, CreateToolsBoxNameDto>().ReverseMap();
            #endregion

            #region Shop Mappings   
            CreateMap<Shop, ShopDto>().ReverseMap();
            CreateMap<Shop, CreateShopDto>().ReverseMap();
            #endregion

            #region TestEquipmentDetail Mappings   
            CreateMap<TestEquipmentDetailDto,TestEquipmentDetail >().ReverseMap()
              .ForMember(d => d.Shop, o => o.MapFrom(s => s.Shop.Name));
            CreateMap<TestEquipmentDetail, CreateTestEquipmentDetailDto>().ReverseMap();
            #endregion
    }
  }
}

