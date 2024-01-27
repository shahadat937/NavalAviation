import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { Page404Component } from '../authentication/page404/page404.component';
import { NewDegitalArchieveComponent } from './degitalarchieve/new-degitalarchieve/new-degitalarchieve.component';
import { MaintenanceScheduleRecordComponent } from './maintenanceschedule/maintenanceschedule-record/maintenanceschedule-record.component';
import { NewDailyAirworthinessFromComponent } from './dailyairworthinessfrom/new-dailyairworthinessfrom/new-dailyairworthinessfrom.component';
import { NewArchivingforPublicationComponent } from './archivingforpublication/new-archivingforpublication/new-archivingforpublication.component';




const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },
  { path: 'update-archivingforpublication/:archivingforPublicationId', 
  component: NewArchivingforPublicationComponent 
  },
  {
    path: 'add-archivingforpublication',
    component: NewArchivingforPublicationComponent,
  },
  
  { path: 'update-degitalarchieve/:degitalArchieveId', 
  component: NewDegitalArchieveComponent 
  },
  {
    path: 'add-degitalarchieve',
    component: NewDegitalArchieveComponent,
  },
  {
    path: "view-maintenancerecord",
    component: MaintenanceScheduleRecordComponent,
  },
  {
    path: "add-dailyairworthinessfrom",
    component: NewDailyAirworthinessFromComponent,
  },
  {
    path: "update-dailyairworthinessfrom/:dailyAirworthinessFromId",
    component: NewDailyAirworthinessFromComponent,
  },

  

  
  { path: '**', component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class RecordRoomRoutingModule { }
