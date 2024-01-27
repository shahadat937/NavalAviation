import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { Page404Component } from '../authentication/page404/page404.component';
import { DepartmentNameListComponent } from './departmentname/departmentname-list/departmentname-list.component';
import { NewDepartmentNameComponent } from './departmentname/new-departmentname/new-departmentname.component';
import { CodeValueListComponent } from './codevalue/codevalue-list/codevalue-list.component';
import { NewCodeValueComponent } from './codevalue/new-codevalue/new-codevalue.component';
import { CodeValueTypeListComponent } from './codevaluetype/codevaluetype-list/codevaluetype-list.component';
import { NewCodeValueTypeComponent } from './codevaluetype/new-codevaluetype/new-codevaluetype.component';
import { GseMaintenanceListComponent } from './gsemaintenance/gsemaintenance-list/gsemaintenance-list.component';
import { NewGseMaintenanceComponent } from './gsemaintenance/new-gsemaintenance/new-gsemaintenance.component';
import { GseScheduleWorkTypeListComponent } from './gsescheduleworktype/gsescheduleworktype-list/gsescheduleworktype-list.component';
import { NewGseScheduleWorkTypeComponent } from './gsescheduleworktype/new-gsescheduleworktype/new-gsescheduleworktype.component';
import { GseMaintenanceScheduleNameListComponent } from './gsemaintenanceschedulename/gsemaintenanceschedulename-list/gsemaintenanceschedulename-list.component';
import { NewGseMaintenanceScheduleNameComponent } from './gsemaintenanceschedulename/new-gsemaintenanceschedulename/new-gsemaintenanceschedulename.component';
import { GseItemNameListComponent } from './gseitemname/gseitemname-list/gseitemname-list.component';
import { NewGseItemNameComponent } from './gseitemname/new-gseitemname/new-gseitemname.component';
import { LifeLimitItemListComponent } from './lifelimititem/lifelimititem-list/lifelimititem-list.component';
import { NewLifeLimitItemComponent } from './lifelimititem/new-lifelimititem/new-lifelimititem.component';
import { LifeLimitItemRunningHourListComponent } from './lifelimititemrunninghour/lifelimititemrunninghour-list/lifelimititemrunninghour-list.component';
import { NewLifeLimitItemRunningHourComponent } from './lifelimititemrunninghour/new-lifelimititemrunninghour/new-lifelimititemrunninghour.component';
import { ReminderTypeListComponent } from './remindertype/remindertype-list/remindertype-list.component';
import { NewReminderTypeComponent } from './remindertype/new-remindertype/new-remindertype.component';
import { TradeListComponent } from './trade/trade-list/trade-list.component';
import { NewTradeComponent } from './trade/new-trade/new-trade.component';
import { AccountTypeListComponent } from './accounttype/accounttype-list/accounttype-list.component';
import { NewAccountTypeComponent } from './accounttype/new-accounttype/new-accounttype.component';
import { ReligionListComponent } from './religion/religion-list/religion-list.component';
import { NewReligionComponent } from './religion/new-religion/new-religion.component';
import { DivisionListComponent } from './division/division-list/division-list.component';
import { NewDivisionComponent } from './division/new-division/new-division.component';
import { CasteListComponent } from './caste/caste-list/caste-list.component';
import { NewCasteComponent } from './caste/new-caste/new-caste.component';
import { DistrictListComponent } from './district/district-list/district-list.component';
import { NewDistrictComponent } from './district/new-district/new-district.component';
import { BaseNameListComponent } from './basename/basename-list/basename-list.component';
import { NewBaseNameComponent } from './basename/new-basename/new-basename.component';
import { ThanaListComponent } from './thana/thana-list/thana-list.component';
import { NewThanaComponent } from './thana/new-thana/new-thana.component';
import { ShelfLifeCategoryListComponent } from './shelflifecategory/shelflifecategory-list/shelflifecategory-list.component';
import { NewShelfLifeCategoryComponent } from './shelflifecategory/new-shelflifecategory/new-shelflifecategory.component';
import { StoreListComponent } from './store/store-list/store-list.component';
import { NewStoreComponent } from './store/new-store/new-store.component';
import { RankListComponent } from './rank/rank-list/rank-list.component';
import { NewRankComponent } from './rank/new-rank/new-rank.component';
import { OccasionOfDemandListComponent } from './occasionofdemand/occasionofdemand-list/occasionofdemand-list.component';
import { NewOccasionOfDemandComponent } from './occasionofdemand/new-occasionofdemand/new-occasionofdemand.component';
import { AuthorityListComponent } from './authority/authority-list/authority-list.component';
import { NewAuthorityComponent } from './authority/new-authority/new-authority.component';
import { AirCraftNameListComponent } from './aircraftname/aircraftname-list/aircraftname-list.component';
import { NewAirCraftNameComponent } from './aircraftname/new-aircraftname/new-aircraftname.component';
import { ViewAirCraftNameComponent } from './aircraftname/view-aircraftname/view-aircraftname.component'
import { RunningHourListComponent } from './runninghour/runninghour-list/runninghour-list.component';
import { NewRunningHourComponent } from './runninghour/new-runninghour/new-runninghour.component';
//import { MaintenanceSubCategoryListComponent } from './maintenancesubcategory/maintenancesubcategory-list/maintenancesubcategory-list.component';
//import { NewMaintenanceSubCategoryComponent } from './maintenancesubcategory/new-maintenancesubcategory/new-maintenancesubcategory.component';
import { DenoListComponent } from './deno/deno-list/deno-list.component';
import { NewDenoComponent } from './deno/new-deno/new-deno.component';
import { FiscalYearListComponent } from './fiscalyear/fiscalyear-list/fiscalyear-list.component';
import { NewFiscalYearComponent } from './fiscalyear/new-fiscalyear/new-fiscalyear.component';
import { ItemTypeListComponent } from './itemtype/itemtype-list/itemtype-list.component';
import { NewItemTypeComponent } from './itemtype/new-itemtype/new-itemtype.component';
import { ItemStatusListComponent } from './itemstatus/itemstatus-list/itemstatus-list.component';
import { NewItemStatusComponent } from './itemstatus/new-itemstatus/new-itemstatus.component';
import { SupplierListComponent } from './supplier/supplier-list/supplier-list.component';
import { NewSupplierComponent } from './supplier/new-supplier/new-supplier.component';
import { NewConditionOfItemComponent } from './conditionofitem/new-conditionofitem/new-conditionofitem.component';
import { ConditionOfItemListComponent } from './conditionofitem/conditionofitem-list/conditionofitem-list.component';
import { EndLifeTypeListComponent } from './endlifetype/endlifetype-list/endlifetype-list.component';
import { NewEndLifeTypeComponent } from './endlifetype/new-endlifetype/new-endlifetype.component';
import { ServiceLifeTypeListComponent } from './servicelifetype/servicelifetype-list/servicelifetype-list.component';
import { NewServiceLifeTypeComponent } from './servicelifetype/new-servicelifetype/new-servicelifetype.component';
import { ItemCategoryListComponent } from './itemcategory/itemcategory-list/itemcategory-list.component';
import { NewItemCategoryComponent } from './itemcategory/new-itemcategory/new-itemcategorycomponent';
import { IssueStatusListComponent } from './issuestatus/issuestatus-list/issuestatus-list.component';
import { NewIssueStatusComponent } from './issuestatus/new-issuestatus/new-issuestatus.component';
import { PartOfShipmentListComponent } from './partofshipment/partofshipment-list/partofshipment-list.component';
import { NewPartOfShipmentComponent } from './partofshipment/new-partofshipment/new-partofshipment.component';
import {NewToolsLocationComponent} from './toolslocation/new-toolslocation/new-toolslocation.component'
import {ToolsLocationListComponent} from './toolslocation/toolslocation-list/toolslocation-list.component'
import {ToolsBoxNameListComponent} from './toolsboxname/toolsboxname/toolsboxname-list.component'
import {NewToolsBoxNameComponent} from './toolsboxname/new-toolsboxname/new-toolsboxname.component'
import { SourceOfSupplyListComponent } from './sourceofsupply/sourceofsupply-list/sourceofsupply-list.component';
import { NewSourceOfSupplyComponent } from './sourceofsupply/new-sourceofsupply/new-sourceofsupply.component';
import { ManufactureListComponent } from './manufacture/manufacture-list/manufacture-list.component';
import { NewManufactureComponent } from './manufacture/new-manufacture/new-manufacture.component';
import { PrincipalNameListComponent } from './principalname/principalname-list/principalname-list.component';
import { NewPrincipalNameComponent } from './principalname/new-principalname/new-principalname.component';
import { AirCraftFlyingListComponent } from './aircraftflying/aircraftflying-list/aircraftflying-list.component';
import { NewAirCraftFlyingComponent } from './aircraftflying/new-aircraftflying/new-aircraftflying.component';
import { TrainingCrewListComponent } from './trainingcrew/trainingcrew-list/trainingcrew-list.component';
import { NewTrainingCrewComponent } from './trainingcrew/new-trainingcrew/new-trainingcrew.component';
import { ItemCategoryTypeListComponent } from './itemcategorytype/itemcategorytype-list/itemcategorytype-list.component';
import { NewItemCategoryTypeComponent } from './itemcategorytype/new-itemcategorytype/new-itemcategorytype.component';
import { CstTecListComponent } from './csttec/csttec-list/csttec-list.component';
import { NewCstTecComponent } from './csttec/new-csttec/new-csttec.component';
import { OverhaulingTypeListComponent } from './overhaulingtype/overhaulingtype-list/overhaulingtype-list.component';
import { NewOverhaulingTypeComponent } from './overhaulingtype/new-overhaulingtype/new-overhaulingtype.component';
import { NewEquipmentNameComponent } from './equipmentname/new-equipmentname/new-equipmentname.component';
import {NoticeBoardListComponent} from './noticeboard/noticeboard-list/noticeboard-list.component';
import {NewNoticeBoardComponent} from './noticeboard/new-noticeboard/new-noticeboard.component';
import { SailorRankListComponent } from './sailorrank/sailorrank-list/sailorrank-list.component';
import { NewSailorRankComponent } from './sailorrank/new-sailorrank/new-sailorrank.component';
import{NewAircraftFlyingDelayComponent} from './aircraftflying/new-aircraftflyingdelay/new-aircraftflyingdelay.component'
import { AcStatusListComponent } from './acstatus/acstatus-list/acstatus-list.component';
import { NewAcStatusComponent } from './acstatus/new-acstatus/new-acstatus.component';
import { NewDailyAirworthinessFromCategoryComponent } from './dailyairworthinessfromcategory/new-dailyairworthinessfromcategory/new-dailyairworthinessfromcategory.component';
import { MaintenanceTypeListComponent } from './maintenancetype/maintenancetype-list/maintenancetype-list.component';
import { NewMaintenanceTypeComponent } from './maintenancetype/new-maintenancetype/new-maintenancetype.component';
import { NewMaintenanceCategoryComponent } from './maintenancecategory/new-maintenancecategory/new-maintenancecategoryr.component';
import { MaintenanceSubCategoryListComponent } from './maintenancesubcategory/maintenancesubcategory-list/maintenancesubcategory-list.component';
import { NewMaintenanceSubCategoryComponent } from './maintenancesubcategory/new-maintenancesubcategory/new-maintenancesubcategory.component';
import { NameofPublicationListComponent } from './nameofpublication/nameofpublication-list/nameofpublication-list.component';
import { NewNameofPublicationComponent } from './nameofpublication/new-nameofpublication/new-nameofpublication.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },

  {
    path: 'aircraftflying-delay/:airCraftFlyingId',
    component: NewAircraftFlyingDelayComponent,
  },
  {
    path: 'noticeboard-list',
    component: NoticeBoardListComponent,
  },
  { path: 'update-noticeboard/:noticeBoardId', 
  component: NewNoticeBoardComponent 
  },
  {
    path: 'add-noticeboard',
    component: NewNoticeBoardComponent,
  },
  {
    path: 'add-dailyairworthinessfromcategory',
    component: NewDailyAirworthinessFromCategoryComponent
},
{ 
  path: 'update-dailyairworthinessfromcategory/:dailyAirworthinessFromCategoryId', 
  component: NewDailyAirworthinessFromCategoryComponent 
},
  {
    path: 'sailorrank-list',
    component: SailorRankListComponent,
  },
  { path: 'update-sailorrank/:sailorRankId', 
  component: NewSailorRankComponent 
  },
  {
    path: 'add-sailorrank',
    component: NewSailorRankComponent,
  },
  {
    path: 'nameofpublication-list',
    component: NameofPublicationListComponent,
  },
  { path: 'update-nameofpublication/:nameofPublicationId', 
  component: NewNameofPublicationComponent 
  },
  {
    path: 'add-nameofpublication',
    component: NewNameofPublicationComponent,
  },
 

  {
    path: 'acstatus-list',
    component: AcStatusListComponent,
  },
  { path: 'update-acstatus/:acStatusId', 
    component: NewAcStatusComponent 
  },
  {
    path: 'add-acstatus',
    component: NewAcStatusComponent,
  },
  {
    path: 'accounttype-list',
    component: AccountTypeListComponent,
  },
  { path: 'update-accounttype/:accountTypeId', 
  component: NewAccountTypeComponent 
  },
  {
    path: 'add-accounttype',
    component: NewAccountTypeComponent,
  },

  {
    path: 'codevalue-list',
    component: CodeValueListComponent,
  },
  { path: 'update-codevalue/:codeValueId', 
  component: NewCodeValueComponent 
  },
  {
    path: 'add-codevalue',
    component: NewCodeValueComponent,
  },

  {
    path: 'codevaluetype-list',
    component: CodeValueTypeListComponent,
  },
  { path: 'update-codevaluetype/:codeValueTypeId', 
  component: NewCodeValueTypeComponent 
  },
  {
    path: 'add-codevaluetype',
    component: NewCodeValueTypeComponent,
  },

  {

    path: 'shelflifecategory-list',
    component: ShelfLifeCategoryListComponent,
  },
  { path: 'update-shelflifecategory/:shelfLifeCategoryId', 
  component: NewShelfLifeCategoryComponent 
  },
  {
    path: 'add-shelflifecategory',
    component: NewShelfLifeCategoryComponent,
  },
  {
    path: 'store-list',
    component: StoreListComponent,
  },
  { path: 'update-store/:storeId', 
  component: NewStoreComponent 
  },
  {
    path: 'add-store',
    component: NewStoreComponent,
  },

  {
    path: 'rank-list',
    component: RankListComponent,
  },
  { path: 'update-rank/:rankId', 
  component: NewRankComponent 
  },
  {
    path: 'add-rank',
    component: NewRankComponent,
  },

  {
    path: 'occasionofdemand-list',
    component: OccasionOfDemandListComponent,
  },
  { path: 'update-occasionofdemand/:occasionOfDemandId', 
  component: NewOccasionOfDemandComponent 
  },
  {
    path: 'add-occasionofdemand',
    component: NewOccasionOfDemandComponent,
  },
  {
    path: 'authority-list',
    component: AuthorityListComponent,
  },
  { path: 'update-authority/:authorityId', 
  component: NewAuthorityComponent 
  },
  {
    path: 'add-authority',
    component: NewAuthorityComponent,
  },

  // {
  //   path: 'aircraftname-list',
  //   component: AirCraftNameListComponent,
  // },
  { path: 'update-aircraftname/:airCraftNameId', 
  component: NewAirCraftNameComponent 
  },
  {
    path: 'add-aircraftname',
    component: NewAirCraftNameComponent,
  },
  { 
    path: 'view-aircraftname/:airCraftNameId', 
    component: ViewAirCraftNameComponent
  },

  { path: 'update-equipmentname/:equipmentNameId', 
  component: NewEquipmentNameComponent 
  },
  {
    path: 'add-equipmentname',
    component: NewEquipmentNameComponent,
  },

  {
    path: 'runninghour-list',
    component: RunningHourListComponent,
  },
  { path: 'update-runninghour/:runningHourId', 
  component: NewRunningHourComponent 
  },
  {
    path: 'add-runninghour',
    component: NewRunningHourComponent,
  },
  {
    path: "maintenancetype-list",
    component: MaintenanceTypeListComponent,
  },
  {
    path: "update-maintenancetype/:maintenanceTypeId",
    component: NewMaintenanceTypeComponent,
  },
  {
    path: "add-maintenancetype",
    component: NewMaintenanceTypeComponent,
  },
  {
    path: "add-maintenancecategory",
    component: NewMaintenanceCategoryComponent,
  },
  {
    path: "update-maintenancecategory/:maintenanceCategoryId",
    component: NewMaintenanceCategoryComponent,
  },
  {
    path: "add-maintenancecategory",
    component: NewMaintenanceCategoryComponent,
  },
  {
    path: "maintenancesubcategory-list",
    component: MaintenanceSubCategoryListComponent,
  },
  {
    path: "update-maintenancesubcategory/:maintenanceSubCategoryId",
    component: NewMaintenanceSubCategoryComponent,
  },
  {
    path: "add-maintenancesubcategory",
    component: NewMaintenanceSubCategoryComponent,
  },

  // {
  //   path: 'maintenancesubcategory-list',
  //   component: MaintenanceSubCategoryListComponent,
  // },
  // { path: 'update-maintenancesubcategory/:maintenanceSubCategoryId', 
  // component: NewMaintenanceSubCategoryComponent 
  // },
  // {
  //   path: 'add-maintenancesubcategory',
  //   component: NewMaintenanceSubCategoryComponent,
  // },

  
  {
    path: 'departmentname-list',
    component: DepartmentNameListComponent,
  },
  { path: 'update-departmentname/:departmentNameId', 
  component: NewDepartmentNameComponent 
  },
  {
    path: 'add-departmentname',
    component: NewDepartmentNameComponent,
  },

  {
    path: 'partofshipment-list',
    component: PartOfShipmentListComponent,
  },
  { path: 'update-partofshipment/:partOfShipmentId', 
  component: NewPartOfShipmentComponent 
  },
  {
    path: 'add-partofshipment',
    component: NewPartOfShipmentComponent,
  },

  {
    path: 'gsemaintenance-list',
    component: GseMaintenanceListComponent,
  },
  { path: 'update-gsemaintenance/:gseMaintenanceId', 
  component: NewGseMaintenanceComponent 
  },
  {
    path: 'add-gsemaintenance',
    component: NewGseMaintenanceComponent,
  },

  {
    path: 'gsescheduleworktype-list',
    component: GseScheduleWorkTypeListComponent,
  },
  { path: 'update-gsescheduleworktype/:gseScheduleWorkTypeId', 
  component: NewGseScheduleWorkTypeComponent 
  },
  {
    path: 'add-gsescheduleworktype',
    component: NewGseScheduleWorkTypeComponent,
  },

  {
    path: 'gsemaintenanceschedulename-list',
    component: GseMaintenanceScheduleNameListComponent,
  },
  { path: 'update-gsemaintenanceschedulename/:gseMaintenanceScheduleNameId', 
  component: NewGseMaintenanceScheduleNameComponent 
  },
  {
    path: 'add-gsemaintenanceschedulename',
    component: NewGseMaintenanceScheduleNameComponent,
  },

  {
    path: 'gseitemname-list',
    component: GseItemNameListComponent,
  },
  { path: 'update-gseitemname/:gseItemNameId', 
  component: NewGseItemNameComponent 
  },
  {
    path: 'add-gseitemname',
    component: NewGseItemNameComponent,
  },
  {
    path: 'lifelimititem-list',
    component: LifeLimitItemListComponent,
  },
  { path: 'update-lifelimititem/:lifeLimitItemId', 
  component: NewLifeLimitItemComponent 
  },
  {
    path: 'add-lifelimititem',
    component: NewLifeLimitItemComponent,
  },

  {
    path: 'lifelimititemrunninghour-list',
    component: LifeLimitItemRunningHourListComponent,
  },
  { path: 'update-lifelimititemrunninghour/:lifeLimitItemRunningHourId', 
  component: NewLifeLimitItemRunningHourComponent 
  },
  {
    path: 'add-lifelimititemrunninghour',
    component: NewLifeLimitItemRunningHourComponent,
  },

  {
    path: 'remindertype-list',
    component: ReminderTypeListComponent,
  },
  { path: 'update-remindertype/:reminderTypeId', 
  component: NewReminderTypeComponent 
  },
  {
    path: 'add-remindertype',
    component: NewReminderTypeComponent,
  },

  {
    path: 'trade-list',
    component: TradeListComponent,
  },
  { path: 'update-trade/:tradeId', 
  component: NewTradeComponent 
  },
  {
    path: 'add-trade',
    component: NewTradeComponent,
  },
  
  
  {  
    path: 'religion-list',
    component: ReligionListComponent,
  },
  { path: 'update-religion/:religionId', 
  component: NewReligionComponent 
  },
  {
    path: 'add-religion',
    component: NewReligionComponent,
  },

 

  

  {
    path: 'division-list',
    component: DivisionListComponent,
  },
  { path: 'update-division/:divisionId', 
  component: NewDivisionComponent, 
  },
  {
    path: 'add-division',
    component: NewDivisionComponent,
  },



  {
    path: 'caste-list',
    component: CasteListComponent,
  },
  { path: 'update-caste/:casteId', 
  component: NewCasteComponent, 
  },
  {
    path: 'add-caste',
    component: NewCasteComponent,
  },

  {
    path: 'district-list',
    component: DistrictListComponent,
  },
  { path: 'update-district/:districtId', 
  component: NewDistrictComponent, 
  },
  {
    path: 'add-district',
    component: NewDistrictComponent,
  },

  {
    path: 'basename-list',
    component: BaseNameListComponent,
  },
  { path: 'update-basename/:baseNameId', 
  component: NewBaseNameComponent, 
  },
  {
    path: 'add-basename',
    component: NewBaseNameComponent,
  },

  
  {
    path: 'thana-list',
    component: ThanaListComponent,
  },
  { path: 'update-thana/:thanaId', 
  component: NewThanaComponent, 
  },
  {
    path: 'add-thana',
    component: NewThanaComponent,
  },

  {
    path: 'deno-list',
    component: DenoListComponent,
  },
  { path: 'update-deno/:denoId', 
  component: NewDenoComponent, 
  },
  {
    path: 'add-deno',
    component: NewDenoComponent,
  },

  {
    path: 'overhaulingtype-list',
    component: OverhaulingTypeListComponent,
  },
  { path: 'update-overhaulingtype/:overhaulingTypeId', 
  component: NewOverhaulingTypeComponent, 
  },
  {
    path: 'add-overhaulingtype',
    component: NewOverhaulingTypeComponent,
  },
  {
    path: 'itemcategorytype-list',
    component: ItemCategoryTypeListComponent,
  },
  { path: 'update-itemcategorytype/:itemCategoryTypeId', 
  component: NewItemCategoryTypeComponent, 
  },
  {
    path: 'add-itemcategorytype',
    component: NewItemCategoryTypeComponent,
  },
  {
    path: 'csttec-list',
    component: CstTecListComponent,
  },
  { path: 'update-csttec/:cstTecId', 
  component: NewCstTecComponent, 
  },
  {
    path: 'add-csttec',
    component: NewCstTecComponent,
  },

  // {
  //   path: 'aircraftflying-list',
  //   component: AirCraftFlyingListComponent,
  // },
  { path: 'update-aircraftflying/:airCraftFlyingId', 
  component: NewAirCraftFlyingComponent, 
  },
  {
    path: 'add-aircraftflying',
    component: NewAirCraftFlyingComponent,
  },
  {
    path: 'trainingcrew-list',
    component: TrainingCrewListComponent,
  },
  { path: 'update-trainingcrew/:trainingCrewId', 
  component: NewTrainingCrewComponent, 
  },
  {
    path: 'add-trainingcrew',
    component: NewTrainingCrewComponent,
  },

  {
    path: 'principalname-list',
    component: PrincipalNameListComponent,
  },
  { path: 'update-principalname/:principalNameId', 
  component: NewPrincipalNameComponent, 
  },
  {
    path: 'add-principalname',
    component: NewPrincipalNameComponent,
  },

  {
    path: 'manufacture-list',
    component: ManufactureListComponent,
  },
  { path: 'update-manufacture/:manufactureId', 
  component: NewManufactureComponent, 
  },
  {
    path: 'add-manufacture',
    component: NewManufactureComponent,
  },

  {
    path: 'sourceofsupply-list',
    component: SourceOfSupplyListComponent,
  },
  { path: 'update-sourceofsupply/:sourceOfSupplyId', 
  component: NewSourceOfSupplyComponent, 
  },
  {
    path: 'add-sourceofsupply',
    component: NewSourceOfSupplyComponent,
  },

  {
    path: 'fiscalyear-list',
    component: FiscalYearListComponent,
  },
  { path: 'update-fiscalyear/:fiscalYearId', 
  component: NewFiscalYearComponent, 
  },
  {
    path: 'add-fiscalyear',
    component: NewFiscalYearComponent,
  },

  {
    path: 'itemtype-list',
    component: ItemTypeListComponent,
  },
  { path: 'update-itemtype/:itemTypeId', 
  component: NewItemTypeComponent, 
  },
  {
    path: 'add-itemtype',
    component: NewItemTypeComponent,
  },

  {
    path: 'itemstatus-list',
    component: ItemStatusListComponent,
  },
  { path: 'update-itemstatus/:itemStatusId', 
  component: NewItemStatusComponent, 
  },
  {
    path: 'add-itemstatus',
    component: NewItemStatusComponent, 
  },

  {
    path: 'supplier-list',
    component: SupplierListComponent,
  },
  { path: 'update-supplier/:supplierId', 
  component: NewSupplierComponent, 
  },
  {
    path: 'add-supplier',
    component: NewSupplierComponent, 
  },

  {
    path: 'conditionofitem-list',
    component: ConditionOfItemListComponent,
  },
  { path: 'update-conditionofitem/:conditionOfItemId', 
  component: NewConditionOfItemComponent, 
  },
  {
    path: 'add-conditionofitem', 
    component: NewConditionOfItemComponent, 
  },

  {
    path: 'endlifetype-list',
    component: EndLifeTypeListComponent,
  },
  { path: 'update-endlifetype/:endLifeTypeId', 
  component: NewEndLifeTypeComponent, 
  },
  {
    path: 'add-endlifetype', 
    component: NewEndLifeTypeComponent, 
  },
  {
    path: 'issuestatus-list',
    component: IssueStatusListComponent,
  },
  { path: 'update-issuestatus/:issueStatusId', 
  component: NewIssueStatusComponent, 
  },
  {
    path: 'add-issuestatus', 
    component: NewIssueStatusComponent, 
  },

  {
    path: 'endlifetype-list',
    component: EndLifeTypeListComponent,
  },
  { path: 'update-endlifetype/:endLifeTypeId', 
  component: NewEndLifeTypeComponent, 
  },
  {
    path: 'add-endlifetype', 
    component: NewEndLifeTypeComponent, 
  },

  {
    path: 'servicelifetype-list',
    component: ServiceLifeTypeListComponent,
  },
  { path: 'update-servicelifetype/:serviceLifeTypeId', 
  component: NewServiceLifeTypeComponent, 
  },
  {
    path: 'add-servicelifetype', 
    component: NewServiceLifeTypeComponent, 
  },

  {
    path: 'itemcategory-list',
    component: ItemCategoryListComponent,
  },
  { path: 'update-itemcategory/:itemCategoryId', 
  component: NewItemCategoryComponent, 
  },
  {
    path: 'add-itemcategory', 
    component: NewItemCategoryComponent, 
  },

  {
    path: 'toolslocation-list',
    component: ToolsLocationListComponent,
  },
  { path: 'update-toolslocation/:toolsLocationId', 
  component: NewToolsLocationComponent, 
  },
  {
    path: 'add-toolslocation', 
    component: NewToolsLocationComponent, 
  },

  {
    path: 'toolsboxname-list',
    component: ToolsBoxNameListComponent,
  },
  { path: 'update-toolsboxname/:toolsBoxNameId', 
  component: NewToolsBoxNameComponent, 
  },
  {
    path: 'add-toolsboxname', 
    component: NewToolsBoxNameComponent, 
  },

  
  { path: '**', component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class BasicSetupRoutingModule { }
