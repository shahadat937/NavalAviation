import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { Page404Component } from '../authentication/page404/page404.component';
import { MeaSquadronStateListComponent } from './measquadronstate/measquadronstate-list/measquadronstate-list.component';
import { NewMeaSquadronStateComponent } from './measquadronstate/new-measquadronstate/new-measquadronstate.component';
import { MeaWorkShopListComponent } from './meaworkshop/meaworkshop-list/meaworkshop-list.component';
import { NewMeaWorkShopComponent } from './meaworkshop/new-meaworkshop/new-meaworkshop.component';
import { MeaMeaBlankFormatListComponent } from './meablankformat/meablankformat-list/meablankformat-list.component';
import { NewMeaBlankFormatComponent } from './meablankformat/new-meablankformat/new-meablankformat.component';
import { ViewMeaSquadronStateComponent } from './measquadronstate/view-measquadronstate/view-measquadronstate.component';
import { WorkRequisitionListComponent } from './measquadronstate/workrequisition-list/workrequisition-list.component';
import { MeaWorkProgressListComponent } from './measquadronstate/workprogress-list/workprogress-list.component';
import { NewTestEquipmentDetailComponent } from './testequipmentdetail/new-testequipmentdetail/new-testequipmentdetail.component';




const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },
  {
    path: "workprogress-list",
    component: MeaWorkProgressListComponent,
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
    path: "view-measquadronstate/:meaSquadronStateId",
    component: ViewMeaSquadronStateComponent,
  },
  {
    path: "workrequisition-list",
    component: WorkRequisitionListComponent,
  },
  {
    path: "meablankformat-list",
    component: MeaMeaBlankFormatListComponent,
  },
  {
    path: "update-meablankformat/:meaBlankFormatId",
    component: NewMeaBlankFormatComponent,
  },
  {
    path: "add-meablankformat",
    component: NewMeaBlankFormatComponent,
  },
  {
    path: "meaworkshop-list",
    component: MeaWorkShopListComponent,
  },
  {
    path: "update-meaworkshop/:meaWorkShopId",
    component: NewMeaWorkShopComponent,
  },
  {
    path: "add-meaworkshop",
    component: NewMeaWorkShopComponent,
  },
  
  // { path: 'update-degitalarchieve/:degitalArchieveId', 
  // component: NewDegitalArchieveComponent 
  // },
  // {
  //   path: 'add-degitalarchieve',
  //   component: NewDegitalArchieveComponent,
  // },
  {
    path: "add-testequipmentdetail",
    component: NewTestEquipmentDetailComponent,
  },
  {
    path: "update-testequipmentdetail/:testEquipmentDetailId",
    component: NewTestEquipmentDetailComponent,
  },

  

  
  { path: '**', component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class MEARoutingModule { }
