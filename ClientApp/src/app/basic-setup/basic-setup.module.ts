import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { BasicSetupRoutingModule } from './basic-setup-routing.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
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
import  { LifeLimitItemListComponent } from './lifelimititem/lifelimititem-list/lifelimititem-list.component';
import  { NewLifeLimitItemComponent } from './lifelimititem/new-lifelimititem/new-lifelimititem.component';
import { LifeLimitItemRunningHourListComponent } from './lifelimititemrunninghour/lifelimititemrunninghour-list/lifelimititemrunninghour-list.component';
import { NewLifeLimitItemRunningHourComponent } from './lifelimititemrunninghour/new-lifelimititemrunninghour/new-lifelimititemrunninghour.component';
import { ReminderTypeListComponent } from './remindertype/remindertype-list/remindertype-list.component';
import { NewReminderTypeComponent } from './remindertype/new-remindertype/new-remindertype.component';
import { TradeListComponent } from './trade/trade-list/trade-list.component';
import { NewTradeComponent } from './trade/new-trade/new-trade.component';
import { AccountTypeListComponent } from './accounttype/accounttype-list/accounttype-list.component';
import { NewAccountTypeComponent } from './accounttype/new-accounttype/new-accounttype.component';
import { ShelfLifeCategoryListComponent } from './shelflifecategory/shelflifecategory-list/shelflifecategory-list.component';
import { NewShelfLifeCategoryComponent } from './shelflifecategory/new-shelflifecategory/new-shelflifecategory.component';
import {ReligionListComponent} from './religion/religion-list/religion-list.component';
import {NewReligionComponent} from './religion/new-religion/new-religion.component';
import { DivisionListComponent } from './division/division-list/division-list.component';
import { NewDivisionComponent} from './division/new-division/new-division.component';
import { CasteListComponent } from './caste/caste-list/caste-list.component';
import { NewCasteComponent } from './caste/new-caste/new-caste.component';
import { DistrictListComponent } from './district/district-list/district-list.component';
import { NewDistrictComponent } from './district/new-district/new-district.component';
import { BaseNameListComponent } from './basename/basename-list/basename-list.component';
import { NewBaseNameComponent } from './basename/new-basename/new-basename.component';
import { ThanaListComponent } from './thana/thana-list/thana-list.component';
import { NewThanaComponent } from './thana/new-thana/new-thana.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MaterialFileInputModule } from 'ngx-material-file-input';
import { HttpClientModule } from '@angular/common/http';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { StoreListComponent } from './store/store-list/store-list.component';
import { NewStoreComponent } from './store/new-store/new-store.component';
import { RankListComponent } from './rank/rank-list/rank-list.component';
import { NewRankComponent} from './rank/new-rank/new-rank.component';
import { OccasionOfDemandListComponent } from './occasionofdemand/occasionofdemand-list/occasionofdemand-list.component';
import { NewOccasionOfDemandComponent } from './occasionofdemand/new-occasionofdemand/new-occasionofdemand.component';
import { AuthorityListComponent } from './authority/authority-list/authority-list.component';
import { NewAuthorityComponent } from './authority/new-authority/new-authority.component';
import {AirCraftNameListComponent} from './aircraftname/aircraftname-list/aircraftname-list.component';
import { NewAirCraftNameComponent } from './aircraftname/new-aircraftname/new-aircraftname.component';
import { ViewAirCraftNameComponent } from './aircraftname/view-aircraftname/view-aircraftname.component';
import { RunningHourListComponent } from './runninghour/runninghour-list/runninghour-list.component';
import { NewRunningHourComponent } from './runninghour/new-runninghour/new-runninghour.component';
//import { MaintenanceSubCategoryListComponent } from './maintenancesubcategory/maintenancesubcategory-list/maintenancesubcategory-list.component';
//import { NewMaintenanceSubCategoryComponent} from './maintenancesubcategory/new-maintenancesubcategory/new-maintenancesubcategory.component';
import { DenoListComponent } from './deno/deno-list/deno-list.component';
import { NewDenoComponent } from './deno/new-deno/new-deno.component';
import { FiscalYearListComponent } from './fiscalyear/fiscalyear-list/fiscalyear-list.component';
import { NewFiscalYearComponent } from './fiscalyear/new-fiscalyear/new-fiscalyear.component';
import { ItemTypeListComponent } from './itemtype/itemtype-list/itemtype-list.component';
import { NewItemTypeComponent } from './itemtype/new-itemtype/new-itemtype.component';
import { ItemStatusListComponent } from './itemstatus/itemstatus-list/itemstatus-list.component';
import { NewItemStatusComponent } from './itemstatus/new-itemstatus/new-itemstatus.component';
import { NewSupplierComponent } from './supplier/new-supplier/new-supplier.component';
import { SupplierListComponent } from './supplier/supplier-list/supplier-list.component';
import { NewConditionOfItemComponent } from './conditionofitem/new-conditionofitem/new-conditionofitem.component';
import { ConditionOfItemListComponent } from './conditionofitem/conditionofitem-list/conditionofitem-list.component';
import { EndLifeTypeListComponent } from './endlifetype/endlifetype-list/endlifetype-list.component';
import { NewEndLifeTypeComponent } from './endlifetype/new-endlifetype/new-endlifetype.component';
import { NewServiceLifeTypeComponent } from './servicelifetype/new-servicelifetype/new-servicelifetype.component';
import { ServiceLifeTypeListComponent } from './servicelifetype/servicelifetype-list/servicelifetype-list.component';
import { NewItemCategoryComponent } from './itemcategory/new-itemcategory/new-itemcategorycomponent';
import { ItemCategoryListComponent } from './itemcategory/itemcategory-list/itemcategory-list.component';
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
import {NewManufactureComponent } from './manufacture/new-manufacture/new-manufacture.component';
import { PrincipalNameListComponent } from './principalname/principalname-list/principalname-list.component';
import { NewPrincipalNameComponent } from './principalname/new-principalname/new-principalname.component';
import { AirCraftFlyingListComponent } from './aircraftflying/aircraftflying-list/aircraftflying-list.component';
import { NewAirCraftFlyingComponent } from './aircraftflying/new-aircraftflying/new-aircraftflying.component';
import { TrainingCrewListComponent } from './trainingcrew/trainingcrew-list/trainingcrew-list.component';
import { NewTrainingCrewComponent } from './trainingcrew/new-trainingcrew/new-trainingcrew.component'
import { ItemCategoryTypeListComponent } from './itemcategorytype/itemcategorytype-list/itemcategorytype-list.component';
import { NewItemCategoryTypeComponent } from './itemcategorytype/new-itemcategorytype/new-itemcategorytype.component'
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
import { MaintenanceCategoryListComponent } from './maintenancecategory/maintenancecategory-list/maintenancecategory-list.component';
import { NewMaintenanceCategoryComponent } from './maintenancecategory/new-maintenancecategory/new-maintenancecategoryr.component';
import { MaintenanceSubCategoryListComponent } from './maintenancesubcategory/maintenancesubcategory-list/maintenancesubcategory-list.component';
import { NewMaintenanceSubCategoryComponent } from './maintenancesubcategory/new-maintenancesubcategory/new-maintenancesubcategory.component';
import { NameofPublicationListComponent } from './nameofpublication/nameofpublication-list/nameofpublication-list.component';
import { NewNameofPublicationComponent } from './nameofpublication/new-nameofpublication/new-nameofpublication.component';


@NgModule({
  declarations: [
    //MatTimepickerModule,
   // MatTimepickerModule,
   NameofPublicationListComponent,
   NewNameofPublicationComponent,
   NewMaintenanceSubCategoryComponent,
   MaintenanceSubCategoryListComponent,
   NewMaintenanceCategoryComponent,
   MaintenanceCategoryListComponent,
   MaintenanceTypeListComponent,
   NewMaintenanceTypeComponent,
   NewDailyAirworthinessFromCategoryComponent,
   NewAircraftFlyingDelayComponent,
    AccountTypeListComponent,
    NewAccountTypeComponent,
    NewReligionComponent,
    ReligionListComponent,
    CodeValueListComponent,
    NewCodeValueComponent,
    CodeValueTypeListComponent,
    NewCodeValueTypeComponent,
    ShelfLifeCategoryListComponent,
    NewShelfLifeCategoryComponent,
    StoreListComponent,
    NewStoreComponent,
    RankListComponent,
    NewRankComponent,
    OccasionOfDemandListComponent,
    NewOccasionOfDemandComponent,
    AuthorityListComponent,
    NewAuthorityComponent,
    AirCraftNameListComponent,
    NewAirCraftNameComponent,
    ViewAirCraftNameComponent,
    NewEquipmentNameComponent,
    RunningHourListComponent,
    NewRunningHourComponent,
    //MaintenanceSubCategoryListComponent,
   // NewMaintenanceSubCategoryComponent,
    PartOfShipmentListComponent,
    NewPartOfShipmentComponent,
    DepartmentNameListComponent,
    NewDepartmentNameComponent,
    GseMaintenanceListComponent,
    NewGseMaintenanceComponent,
    GseScheduleWorkTypeListComponent,
    NewGseScheduleWorkTypeComponent,
    GseMaintenanceScheduleNameListComponent,
    NewGseMaintenanceScheduleNameComponent,
    LifeLimitItemRunningHourListComponent,
    NewLifeLimitItemRunningHourComponent,
    LifeLimitItemListComponent,
    NewLifeLimitItemComponent,
    ReminderTypeListComponent,
    NewReminderTypeComponent,
    GseItemNameListComponent,
    NewGseItemNameComponent,
    TradeListComponent,
    NewTradeComponent,
    DivisionListComponent,
    NewDivisionComponent,
    CasteListComponent,
    NewCasteComponent,
    DistrictListComponent,
    NewDistrictComponent,
    BaseNameListComponent,
    NewBaseNameComponent,
    ThanaListComponent,
    NewThanaComponent,
    DenoListComponent,
    NewDenoComponent,
    FiscalYearListComponent,
    NewFiscalYearComponent,
    ItemTypeListComponent,
    NewItemTypeComponent,
    NewItemStatusComponent,
    ItemStatusListComponent,
    NewSupplierComponent,
    SupplierListComponent,
    NewConditionOfItemComponent,
    ConditionOfItemListComponent,
    NewEndLifeTypeComponent,
    EndLifeTypeListComponent,
    NewServiceLifeTypeComponent,
    ServiceLifeTypeListComponent,
    ItemCategoryListComponent,
    NewItemCategoryComponent,
    IssueStatusListComponent,
    NewIssueStatusComponent,
    NewToolsLocationComponent,
    ToolsLocationListComponent,
    ToolsBoxNameListComponent,
    NewToolsBoxNameComponent,
    SourceOfSupplyListComponent,
    NewSourceOfSupplyComponent,
    ManufactureListComponent,
    NewManufactureComponent,
    PrincipalNameListComponent,
    NewPrincipalNameComponent,
    AirCraftFlyingListComponent,
    NewAirCraftFlyingComponent,
    TrainingCrewListComponent,
    NewTrainingCrewComponent,
    ItemCategoryTypeListComponent,
    NewItemCategoryTypeComponent,
    CstTecListComponent,
    NewCstTecComponent,
    OverhaulingTypeListComponent,
    NewOverhaulingTypeComponent,
    NoticeBoardListComponent,
    NewNoticeBoardComponent,
    SailorRankListComponent,
    NewSailorRankComponent,
    AcStatusListComponent,
    NewAcStatusComponent,
  ],
  imports: [
   // NgxMatTimepickerModule,
    CommonModule,
    BasicSetupRoutingModule,
    CommonModule,
    FormsModule,  
    ReactiveFormsModule,
    NgxDatatableModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatStepperModule,
    MatSnackBarModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MaterialFileInputModule,
    MatProgressSpinnerModule,
    HttpClientModule,
   MatAutocompleteModule,
    
  ]
})
export class BasicSetupModule { }
