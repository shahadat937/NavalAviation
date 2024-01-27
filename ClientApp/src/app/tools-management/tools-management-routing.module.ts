// import { NgModule } from '@angular/core';
// import { CommonModule } from '@angular/common';
// import { Routes, RouterModule } from '@angular/router';
// import { Page404Component } from '../authentication/page404/page404.component';
// import { ItemDetailListComponent } from './itemdetail/itemdetail-list/itemdetail-list.component';
// import { NewItemDetailComponent } from './itemdetail/new-itemdetail/new-itemdetail.component';
// import { AcceptanceListComponent } from './acceptance/acceptance-list/acceptance-list.component';
// import { NewAcceptanceComponent } from './acceptance/new-acceptance/new-acceptance.component';
// import { DemandListComponent } from './demand/demand-list/demand-list.component';
// import { NewDemandComponent } from './demand/new-demand/new-demand.component';
// import { NewItemStorComponent} from './store/new-store/new-itemstor.component';
// import { ProcurementListComponent } from './procurement/procurement-list/procurement-list.component';
// import { NewProcurementComponent } from './procurement/new-procurement/new-procurement.component';
// import { ViewDemandComponent } from './demand/view-demand/view-demand.component';
// import { ViewProcurementComponent } from './procurement/view-procurement/view-procurement.component';
// import { ViewAcceptanceComponent } from './acceptance/view-acceptance/view-acceptance.component';
// import { ViewItemStorComponent } from './store/view-itemstor/view-itemstor.component';
// import { CallibrationStateListComponent } from './callibrationstate/callibrationstate-list/callibrationstate-list.component';
// import { NewCallibrationStateComponent } from './callibrationstate/new-callibrationstate/new-callibrationstate.component';
// import { ReturnableIssueListComponent } from './issueregister/returnableissue-list/returnableissue-list.component';

import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";
import { Page404Component } from "../authentication/page404/page404.component";
import { ItemDetailListComponent } from "./itemdetail/itemdetail-list/itemdetail-list.component";
import { NewItemDetailComponent } from "./itemdetail/new-itemdetail/new-itemdetail.component";
import { AcceptanceListComponent } from "./acceptance/acceptance-list/acceptance-list.component";
import { NewAcceptanceComponent } from "./acceptance/new-acceptance/new-acceptance.component";
import { DemandListComponent } from "./demand/demand-list/demand-list.component";
import { NewDemandComponent } from "./demand/new-demand/new-demand.component";
import { ProcurementListComponent } from "./procurement/procurement-list/procurement-list.component";
import { NewProcurementComponent } from "./procurement/new-procurement/new-procurement.component";
import { ViewDemandComponent } from "./demand/view-demand/view-demand.component";
import { ViewProcurementComponent } from "./procurement/view-procurement/view-procurement.component";
import { ViewAcceptanceComponent } from "./acceptance/view-acceptance/view-acceptance.component";
import { ViewItemStorComponent } from "./store/view-itemstor/view-itemstor.component";
import { CallibrationStateListComponent } from "./callibrationstate/callibrationstate-list/callibrationstate-list.component";
import { NewCallibrationStateComponent } from "./callibrationstate/new-callibrationstate/new-callibrationstate.component";
import { ReturnableIssueListComponent } from "./issueregister/returnableissue-list/returnableissue-list.component";
import { InventoryHistoryComponent } from "./inventory-history/inventory-history.component";
import { NewItemStorComponent } from "./store/new-store/new-itemstor.component";
import { NewPreviousItemStoreComponent } from "./previousitemstore/new-previousitemstore/new-previousitemstore.component";
import { PreviousItemStoreListComponent } from "./previousitemstore/previousitemstore-list/previousitemstore-list.component";
import { InventoryDetailsComponent } from "../spares-management/inventory-details/inventory-details.component";
import { NsdStockDetailsComponent } from "../spares-management/nsdstock-details/nsdstock-details.component";
import {CallibrationStateViewListComponent} from './callibrationstate/callibrationstateview-list/callibrationstateview-list.component';
import { SearchingComponent } from "./searching/searching.component";

const routes: Routes = [
  {
    path: "",
    redirectTo: "signin",
    pathMatch: "full",
  },

  {
    path: "add-itemdetail",
    component: NewItemDetailComponent,
  },
  {
    path: "update-itemdetail/:itemDetailId",
    component: NewItemDetailComponent,
  },
  {
    path: "add-itemdetail/:sparesCategoryId",
    component: NewItemDetailComponent,
  },
  
  {
    path: "view-inventorydetails/:itemDetailId",
    component: InventoryDetailsComponent,
  },
  {
    path: "view-availablestockdetails/:itemDetailId/:toolsLocationId",
    component: NsdStockDetailsComponent,
  },
  {
    path: "returnableissue-list",
    component: ReturnableIssueListComponent,
  },
  {
    path: 'searching',
    component: SearchingComponent,
  },
  {
    path: "inventory-history",
    component: InventoryHistoryComponent,
  },
  {
    path: "callibrationstate-list",
    component: CallibrationStateListComponent,
  },
  {
    path: "callibrationstateview-list",
    component: CallibrationStateViewListComponent,
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
    path: "previousitemstore-list",
    component: PreviousItemStoreListComponent,
  },
  {
    path: "update-previousitemstore/:itemStorId",
    component: NewPreviousItemStoreComponent,
  },
  {
    path: "add-previousitemstore",
    component: NewPreviousItemStoreComponent,
  },

  {
    path: "add-toolstore",
    component: NewItemStorComponent,
  },
  { path: "update-itemstor/:itemStorId", component: NewItemStorComponent },
  { path: "view-itemstor/:itemStorId", component: ViewItemStorComponent },

  //   path: "add-toolstore",
  //   component: NewItemStorsComponent,
  // },
  // { path: "update-itemstors/:itemStorId", component: NewItemStorsComponent },
  // { path: "view-itemstor/:itemStorId", component: ViewItemStorComponent },

  // {
  //   path: 'add-toolstore/:sparesCategoryId',
  //   component: NewItemStorsComponent,
  // },

  // {
  //   path: 'acceptance-list',
  //   component: AcceptanceListComponent,
  // },
  {
    path: "update-acceptance/:acceptanceId",
    component: NewAcceptanceComponent,
  },
  {
    path: "add-acceptance",
    component: NewAcceptanceComponent,
  },
  { path: "view-acceptance/:acceptanceId", component: ViewAcceptanceComponent },
  // {
  //   path: 'procurement-list',
  //   component: ProcurementListComponent,
  // },
  {
    path: "update-procurement/:procurementId",
    component: NewProcurementComponent,
  },
  {
    path: "add-procurement",
    component: NewProcurementComponent,
  },
  {
    path: "view-procurement/:procurementId",
    component: ViewProcurementComponent,
  },

  // {
  //   path: 'accounttype-list',
  //   component: AccountTypeListComponent,
  // },
  // { path: 'update-accounttype/:accountTypeId',
  // component: NewAccountTypeComponent
  // },
  // {
  //   path: 'add-accounttype',
  //   component: NewAccountTypeComponent,
  // },

  // {
  //   path: 'demand-list',
  //   component: DemandListComponent,
  // },
  { path: "update-demand/:demandId", component: NewDemandComponent },
  {
    path: "add-demand",
    component: NewDemandComponent,
  },
  { path: "view-demand/:demandId", component: ViewDemandComponent },

  { path: "**", component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ToolsManagementRoutingModule {}
