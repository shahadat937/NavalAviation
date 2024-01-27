// import { DashboardComponent as studentDashboard } from './../../student/dashboard/dashboard.component';
// import { DashboardComponent as teacherDashboard } from './../../teacher/dashboard/dashboard.component';
import { DashboardComponent as employeeDashboard } from './../../employee/dashboard/dashboard.component';
import { DashboardComponent as userDashboard } from './../../user-dashboard/dashboard/dashboard.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main/main.component';
import { PendingDemandListComponent } from './pendingdemand-list/pendingdemand-list.component';
import { PendingProcurementListComponent } from './pendingprocurement-list/pendingprocurement-list.component';
import { PendingAcceptanceListComponent } from './pendingacceptance-list/pendingacceptance-list.component';
import { FlyingDetailsListComponent }from './flyingdetails-list/flyingdetails-list.component';
import { TrainingCrewListComponent }from './trainingcrew-list/trainingcrew-list.component';
import { DemandListComponent } from './demand-list/demand-list.component';
import { ACRunningHoursListComponent } from './acrunninghours-list/acrunninghours-list.component';
import { procurementListComponent } from './procurement-list/procurement-list.component';
import { acflyingprogramListComponent } from './acflyingprogram-list/acflyingprogram-list.component';
import { AirCraftFlyingListComponent } from './aircraftflying-list/aircraftflying-list.component';
import {AircraftNameOperationalListComponent} from './aircraftnameoperational-list/aircraftnameoperational-list.component';
import {AircraftNameNonOperationalListComponent} from './aircraftnamenonoperational-list/aircraftnamenonoperational-list.component';
import { AircraftUnderMaintenanceListComponent } from './aircraftundermaintenance-list/aircraftundermaintenance-list.component';
import { PersonalStateListComponent } from './personalstate-list/personalstate-list.component';
import {logisticsIssuesListComponent} from './logisticsissues-list/logisticsissues-list.component';
import { AircraftStatusListComponent } from './aircraftstatus-list/aircraftstatus-list.component';
import { NewAirCraftFlyingComponent } from '../../basic-setup/aircraftflying/new-aircraftflying/new-aircraftflying.component';
import { AcStatusListComponent } from '../../basic-setup/acstatus/acstatus-list/acstatus-list.component';
import { NewAcStatusComponent } from '../../basic-setup/acstatus/new-acstatus/new-acstatus.component';
import {NewNoticeBoardComponent} from '../../basic-setup/noticeboard/new-noticeboard/new-noticeboard.component';
import { ViewNoticeComponent } from "./view-notice/view-notice.component";
import { AcceptanceByPattnoComponent as AcceptanceByPattno } from "./../../spares-management/acceptance/acceptancebypattno-list/acceptancebypattno-list.component";
import { PersonalStateByStatusListComponent } from "./personalstatebystatus-list/personalstatebystatus-list.component";
import { FLGWGDashboardComponent  } from "./flgwg-dashboard/flgwg-dashboard.component";
import { ViewOfficerBiodataComponent } from '../../maintenence-planning/trainingcrew/view-officerbiodata/view-officerbiodata.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'main',
    pathMatch: 'full',
  },

  {
    path: 'logistisissues-list',
    component: logisticsIssuesListComponent,
  },
  {
    path: 'flgwg-dashboard',
    component: FLGWGDashboardComponent,
  },
  {
    path: "acceptancebypattno-list",
    component: AcceptanceByPattno,
  },
  {
    path: "view-profile/:profileStatus",
    component: ViewOfficerBiodataComponent,
  },
  {
    path: 'nonoperationalaircraftname-list',
    component: AircraftNameNonOperationalListComponent,
  },

  {
    path: 'operationalaircraftname-list',
    component: AircraftNameOperationalListComponent,
  },
  {
    path: 'personalstatebystatus-list/:officersStatusId/:presentBilletId',
    component: PersonalStateByStatusListComponent,
  },
  {
    path: 'main',
    component: MainComponent,
  },
  {
    path: 'admin-dashboard',
    component: employeeDashboard,
  },
  {
    path: 'user-dashboard',
    component: userDashboard,
  },
  {
    path: 'pendingDemand-list',
    component: PendingDemandListComponent,
  },
  {
    path: 'pendingProcurement-list',
    component: PendingProcurementListComponent,
  },
  {
    path: 'pendingAcceptance-list',
    component: PendingAcceptanceListComponent,
  },
  {
    path: 'demand-list',
    component: DemandListComponent,
  },
  {
    path: 'aircraftflying-list',
    component: AirCraftFlyingListComponent,
  },
  
  {
    path: 'aircraftundermaintenance-list',
    component: AircraftUnderMaintenanceListComponent,
  },
  {
    path: 'aircraftstatus-list',
    component: AircraftStatusListComponent,
  },
  {
    path: 'personalstate-list',
    component: PersonalStateListComponent,
  },
  {
    path: 'acrunninghours-list',
    component: ACRunningHoursListComponent,
  },
  {
    path: 'procurement-list',
    component: procurementListComponent,
  },
  {
    path: 'acflyingprogram-list',
    component: acflyingprogramListComponent,
  },
  {
    path: 'trainingcrew-list',
    component: TrainingCrewListComponent,
  },
  {
    path: 'flyingDetails-list/:departmentNameId/:airCraftNameId',
    component: FlyingDetailsListComponent,
  },

  { path: 'update-aircraftflying/:airCraftFlyingId', 
  component: NewAirCraftFlyingComponent, 
  },
  {
    path: 'add-aircraftflying',
    component: NewAirCraftFlyingComponent,
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

  { path: 'update-noticeboard/:noticeBoardId', 
  component: NewNoticeBoardComponent 
  },
  {
    path: 'add-noticeboard',
    component: NewNoticeBoardComponent,
  },
  {
    path: 'view-noticeboard/:noticeBoardId',
    component: ViewNoticeComponent,
  },

  // {
  //   path: 'teacher-dashboard',
  //   component: teacherDashboard,
  // },
  // {
  //   path: 'student-dashboard',
  //   component: studentDashboard,
  // },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DashboardRoutingModule {}
