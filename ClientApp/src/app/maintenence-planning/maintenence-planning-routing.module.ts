import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";
import { Page404Component } from "../authentication/page404/page404.component";
import { MaintenanceTypeListComponent } from "./maintenancetype/maintenancetype-list/maintenancetype-list.component";
import { NewMaintenanceTypeComponent } from "./maintenancetype/new-maintenancetype/new-maintenancetype.component";
import { MaintenanceScheduleListComponent } from "./maintenanceschedule/maintenanceschedule-list/maintenanceschedule-list.component";
import { NewMaintenancePlanningComponent } from "./maintenanceplanning/new-maintenanceplanning/new-maintenanceplanning.component";
import { MaintenanceCategoryListComponent } from "../maintenence-planning/maintenancecategory/maintenancecategory-list/maintenancecategory-list.component";
import { NewMaintenanceCategoryComponent } from "../maintenence-planning/maintenancecategory/new-maintenancecategory/new-maintenancecategoryr.component";
// import { TrainingCrewListComponent } from './trainingcrew/trainingcrew-list/trainingcrew-list.component';
// import { NewTrainingCrewComponent } from './trainingcrew/new-trainingcrew/new-trainingcrew.component';
import { MaintenanceSubCategoryListComponent } from "../maintenence-planning/maintenancesubcategory/maintenancesubcategory-list/maintenancesubcategory-list.component";
import { NewMaintenanceSubCategoryComponent } from "../maintenence-planning/maintenancesubcategory/new-maintenancesubcategory/new-maintenancesubcategory.component";
import { NewMaintenanceScheduleComponent } from "./maintenanceschedule/new-maintenanceschedule/new-maintenanceschedule.component";
import { MeaSquadronStateListComponent } from "./measquadronstate/measquadronstate-list/measquadronstate-list.component";
import { NewMeaSquadronStateComponent } from "./measquadronstate/new-measquadronstate/new-measquadronstate.component";
import { CallibrationStateListComponent } from "./callibrationstate/callibrationstate-list/callibrationstate-list.component";
import { NewCallibrationStateComponent } from "./callibrationstate/new-callibrationstate/new-callibrationstate.component";
import { ViewMaintenancePlanningComponent } from "./maintenanceplanning/view-maintenanceplanning/view-maintenanceplanning.component";
import { NewDailyAirworthinessFromCategoryComponent } from "./dailyairworthinessfromcategory/new-dailyairworthinessfromcategory/new-dailyairworthinessfromcategory.component";
import { NewDailyAirworthinessFromComponent } from "./dailyairworthinessfrom/new-dailyairworthinessfrom/new-dailyairworthinessfrom.component";
import { NewDailyAirworthinessRecordFromComponent } from "./dailyairworthinessfrom/new-dailyairworthinesrecordsfrom/new-new-dailyairworthinesrecordsfrom.component";
import { NewRequiredSparesForMaintenanceComponent } from "./requiredsparesformaintenance/new-requiredsparesformaintenance/new-requiredsparesformaintenance.component";
import { InventoryDetailsComponent } from "../spares-management/inventory-details/inventory-details.component";
import { NsdStockDetailsComponent } from "../spares-management/nsdstock-details/nsdstock-details.component";
// import { MaintenanceScheduleRecordComponent } from './maintenanceschedule/maintenanceschedule-record/maintenanceschedule-record.component';
// import {SailorBioDataListComponent} from './sailorbiodata/sailorbiodata-list/sailorbiodata-list.component';
// import {NewSailorBiodataComponent} from './sailorbiodata/new-sailorbiodata/new-sailorbiodata.component';
import {MaintainenceStateListComponent} from './maintainencestate/maintainencestate-list/maintainencestate-list.component';
import {MaintainenceStateViewListComponent} from './maintainencestate/maintainencestateview-list/maintainencestateview-list.component'
import { MaintenanceScheduleRecordComponent } from '../record-room/maintenanceschedule/maintenanceschedule-record/maintenanceschedule-record.component';

const routes: Routes = [
  {
    path: "",
    redirectTo: "signin",
    pathMatch: "full",
  },

  // {
  //   path: 'sailorbiodata-list',
  //   component: SailorBioDataListComponent
  // },
  // { path: 'update-sailorbiodata/:trainingCrewId',
  // component: NewSailorBiodataComponent
  // },
  // {
  //   path: 'add-sailorbiodata',
  //   component: NewSailorBiodataComponent,
  // },
  {
    path: "maintenencestateview-list",
    component: MaintainenceStateViewListComponent,
  },
  {
    path: "maintenencestate-list",
    component: MaintainenceStateListComponent,
  },
  {
    path: "callibrationstate-list",
    component: CallibrationStateListComponent,
  },  
  {
    path: "maint-archive",
    component: MaintenanceScheduleRecordComponent,
  },
  {
    path: "add-requiredsparesformaintenance",
    component: NewRequiredSparesForMaintenanceComponent,
  },
  {
    path: "view-requiredsparesformaintenance/:viewType/:departmentNameId/:sparesCategoryId/:maintenanceTypeId/:maintenanceCategoryId/:maintenanceSubCategoryId",
    component: NewRequiredSparesForMaintenanceComponent,
  },
  {
    path: "update-requiredsparesformaintenance/:requiredSparesForMaintenanceId",
    component: NewRequiredSparesForMaintenanceComponent,
  },

  {
    path: "maintenancetype-list",
    component: MaintenanceTypeListComponent,
  },
  {
    path: "maintenanceschedule-list",
    component: MaintenanceScheduleListComponent,
  },
  {
    path: "view-inventorydetails/:itemDetailId",
    component: InventoryDetailsComponent,
  },
  {
    path: "view-nsdstockdetails/:itemDetailId",
    component: NsdStockDetailsComponent,
  },
  // {
  //   path: "view-maintenancerecord",
  //   component: MaintenanceScheduleRecordComponent,
  // },
  {
    path: "update-maintenancetype/:maintenanceTypeId",
    component: NewMaintenanceTypeComponent,
  },
  {
    path: "add-maintenancetype",
    component: NewMaintenanceTypeComponent,
  },

  {
    path: "measquadronstate-list",
    component: MeaSquadronStateListComponent,
  },
  {
    path: "update-measquadronstate/:meaSquadronStateId",
    component: NewMeaSquadronStateComponent,
  },
  {
    path: "add-measquadronstate",
    component: NewMeaSquadronStateComponent,
  },
  {
    path: "callibrationstate-list",
    component: CallibrationStateListComponent,
  },
  {
    path: "update-callibrationstate/:callibrationStateId",
    component: NewCallibrationStateComponent,
  },
  {
    path: "add-callibrationstate",
    component: NewCallibrationStateComponent,
  },
  {
    path: "add-maintenanceplanning",
    component: NewMaintenancePlanningComponent,
  },
  {
    path: "update-maintenanceplanning/:maintenancePlanningId",
    component: NewMaintenancePlanningComponent,
  },
  // {
  //   path: "add-maintenanceplanning",
  //   component: NewMaintenancePlanningComponent,
  // },
  {
    path: "view-maintenanceplanning/:maintenancePlanningId",
    component: ViewMaintenancePlanningComponent,
  },

  {
    path: "update-maintenanceschedule/:maintenanceScheduleId",
    component: NewMaintenanceScheduleComponent,
  },
  {
    path: "add-maintenanceschedule",
    component: NewMaintenanceScheduleComponent,
  },
  {
    path: "add-dailyairworthinessfromcategory",
    component: NewDailyAirworthinessFromCategoryComponent,
  },
  {
    path: "update-dailyairworthinessfromcategory/:dailyAirworthinessFromCategoryId",
    component: NewDailyAirworthinessFromCategoryComponent,
  },
  {
    path: "add-dailyairworthinessfrom",
    component: NewDailyAirworthinessFromComponent,
  },
  {
    path: "update-dailyairworthinessfrom/:dailyAirworthinessFromId",
    component: NewDailyAirworthinessFromComponent,
  },
  {
    path: "add-dailyairworthinessrecordfrom",
    component: NewDailyAirworthinessRecordFromComponent,
  },
  {
    path: "update-dailyairworthinessrecordfrom/:dailyAirworthinessFromId",
    component: NewDailyAirworthinessRecordFromComponent,
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
  // {
  //   path: "maintenancesubcategory-list",
  //   component: MaintenanceSubCategoryListComponent,
  // },
  // {
  //   path: "update-maintenancesubcategory/:maintenanceSubCategoryId",
  //   component: NewMaintenanceSubCategoryComponent,
  // },
  {
    path: "add-maintenancesubcategory",
    component: NewMaintenanceSubCategoryComponent,
  },
  // {
  //   path: 'trainingcrew-list',
  //   component: TrainingCrewListComponent,
  // },
  // { path: 'update-trainingcrew/:trainingCrewId',
  // component: NewTrainingCrewComponent
  // },
  // {
  //   path: 'add-trainingcrew',
  //   component: NewTrainingCrewComponent,
  // },

  { path: "**", component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MaintenecePlanningRoutingModule {}
