import { Page404Component } from './../authentication/page404/page404.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
// import { DashboardComponent } from './dashboard/dashboard.component';
import {SailorBioDataListComponent} from './../maintenence-planning/sailorbiodata/sailorbiodata-list/sailorbiodata-list.component';
import {NewSailorBiodataComponent} from './../maintenence-planning/sailorbiodata/new-sailorbiodata/new-sailorbiodata.component';
import {TrainingCrewListComponent} from './../maintenence-planning/trainingcrew/trainingcrew-list/trainingcrew-list.component';
import {NewTrainingCrewComponent} from './../maintenence-planning/trainingcrew/new-trainingcrew/new-trainingcrew.component';
import { ViewOfficerBiodataComponent } from '../maintenence-planning/trainingcrew/view-officerbiodata/view-officerbiodata.component';
import { ViewSailorBiodataComponent } from '../maintenence-planning/sailorbiodata/view-sailorbiodata/view-sailorbiodata.component';
import {NewAttendanceComponent} from '../biodata/new-attendance/new-attendance.component';
import {AttendanceListComponent} from '../biodata/attendance-list/attendance-list.component';

const routes: Routes = [
  // {
  //   path: 'dashboard',
  //   component: DashboardComponent,
  // },
    {
    path: 'sailorbiodata-list',
    component: SailorBioDataListComponent
  },
  { path: 'update-sailorbiodata/:trainingCrewId', 
  component: NewSailorBiodataComponent 
  },
  {
    path: 'add-sailorbiodata',
    component: NewSailorBiodataComponent,
  },
  { path: 'view-sailorbiodata/:trainingCrewId', 
    component: ViewSailorBiodataComponent
  },
  {
    path: 'trainingcrew-list',
    component: TrainingCrewListComponent,
  },
  { path: 'update-trainingcrew/:trainingCrewId', 
  component: NewTrainingCrewComponent 
  },
  {
    path: 'add-trainingcrew',
    component: NewTrainingCrewComponent,
  },
  { path: 'view-officerbiodata/:trainingCrewId', 
    component: ViewOfficerBiodataComponent
  },
  {
    path: 'add-attendance',
    component: NewAttendanceComponent,
  },
  {
    path: 'attendance-list',
    component: AttendanceListComponent,
  },
  
  { path: '**', component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BiodataRoutingModule {}
