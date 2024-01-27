import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";
import { Page404Component } from "../authentication/page404/page404.component";
import { ItemDetailListComponent } from "./itemdetail/itemdetail-list/itemdetail-list.component";
import { NewItemDetailComponent } from "./itemdetail/new-itemdetail/new-itemdetail.component";
import { AcceptanceListComponent } from "./acceptance/acceptance-list/acceptance-list.component";
import { NewAcceptanceComponent } from "./acceptance/new-acceptance/new-acceptance.component";
import { NewDemandComponent } from "./demand/new-demand/new-demand.component";
import { ProcurementListComponent } from "./procurement/procurement-list/procurement-list.component";
import { NewProcurementComponent } from "./procurement/new-procurement/new-procurement.component";
import { ItemStorListComponent } from "./itemstor/itemstor-list/itemstor-list.component";
import { NewItemStorMainEquComponent } from "./itemstor/new-itemstor-main-equ/new-itemstor-main-equ.component";
import { NewItemStorSparesComponent } from "./itemstor/new-itemstor-spares/new-itemstor-spares.component";
import { NewItemStorConsumbleComponent } from "./itemstor/new-itemstor-consumble/new-itemstor-consumble.component";
import { NewItemStorReturnableComponent } from "./itemstor/new-itemstor-returnable/new-itemstor-returnable.component";
import { NewItemStorLifeLimitItemComponent } from "./itemstor/new-itemstor-lifelimititem/new-itemstor-lifelimititem.component";
import { NewItemStorMiscComponent } from "./itemstor/new-itemstor-misc/new-itemstor-misc.component";
import { PreviousItemStoreListComponent } from "./previousitemstore/previousitemstore-list/previousitemstore-list.component";
import { NewPreviousItemStoreComponent } from "./previousitemstore/new-previousitemstore/new-previousitemstore.component";
import { ManufactureListComponent } from "./manufacture/manufacture-list/manufacture-list.component";
import { NewManufactureComponent } from "./manufacture/new-manufacture/new-manufacture.component";
import { SupplierListComponent } from "./supplier/supplier-list/supplier-list.component";
import { NewSupplierComponent } from "./supplier/new-supplier/new-supplier.component";
import { PrincipalNameListComponent } from "./principalname/principalname-list/principalname-list.component";
import { NewPrincipalNameComponent } from "./principalname/new-principalname/new-principalname.component";
import { NewItemStorComponent } from "./itemstor/new-itemstor/new-itemstor.component";
import { ViewDemandComponent } from "./demand/view-demand/view-demand.component";
import { ViewProcurementComponent } from "./procurement/view-procurement/view-procurement.component";
import { ViewAcceptanceComponent } from "./acceptance/view-acceptance/view-acceptance.component";
import { ViewItemStorComponent } from "./itemstor/view-itemstor/view-itemstor.component";
import { ViewPreviousItemStoreComponent } from "./previousitemstore/view-previousitemstore/view-previousitemstore.component";
import { InventoryHistoryComponent } from "./inventory-history/inventory-history.component";
import { InventoryDetailsComponent } from "./inventory-details/inventory-details.component";
import { ProcurementProgressComponent } from "./procurement/procurement-progress/procurement-progress.component";
import { NewStockTransferNsdComponent } from "./stocktransfernsd/new-stocktransfernsd/new-stocktransfernsd.component";
import { NsdStockDetailsComponent } from './nsdstock-details/nsdstock-details.component';
// import { AcceptanceByPattnoComponent } from './acceptance/acceptancebypattno-list/acceptancebypattno-list.component';
import { SearchingComponent } from './searching/searching.component';
import { AllDocumentListComponent } from "./itemstor/alldocument-list/alldocument-list.component";

const routes: Routes = [
  {
    path: "",
    redirectTo: "signin",
    pathMatch: "full",
  },

  {
    path: 'searching',
    component: SearchingComponent,
  },
  {
    path: "alldocument-list/:itemStorId",
    component: AllDocumentListComponent,
  },

  {
    path: "update-itemdetail/:itemDetailId",
    component: NewItemDetailComponent,
  },
  {
    path: "add-itemdetail",
    component: NewItemDetailComponent,
  },
  {
    path: "inventory-history",
    component: InventoryHistoryComponent,
  },
  {
    path: "procurement-progress",
    component: ProcurementProgressComponent,
  },
  // {
  //   path: "acceptancebypattno-list",
  //   component: AcceptanceByPattnoComponent,
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
  {
    path: "view-acceptance/:acceptanceId",
    component: ViewAcceptanceComponent,
  },
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
  {
    path: "itemstor-list",
    component: ItemStorListComponent,
  },

  {
    path: "update-itemstor-main-equ/:itemStorId",
    component: NewItemStorMainEquComponent,
  },
  {
    path: "add-itemstor-main-equ",
    component: NewItemStorMainEquComponent,
  },

  {
    path: "update-itemstor-spares/:itemStorId",
    component: NewItemStorSparesComponent,
  },
  {
    path: "add-itemstor-spares",
    component: NewItemStorSparesComponent,
  },

  {
    path: "update-itemstor-consumble/:itemStorId",
    component: NewItemStorConsumbleComponent,
  },
  {
    path: "add-itemstor-consumble",
    component: NewItemStorConsumbleComponent,
  },

  {
    path: "update-itemstor-returnable/:itemStorId",
    component: NewItemStorReturnableComponent,
  },
  {
    path: "add-itemstor-returnable",
    component: NewItemStorReturnableComponent,
  },

  {
    path: "update-itemstor-lifelimititem/:itemStorId",
    component: NewItemStorLifeLimitItemComponent,
  },
  {
    path: "add-itemstor-lifelimititem",
    component: NewItemStorLifeLimitItemComponent,
  },

  {
    path: "update-itemstor-misc/:itemStorId",
    component: NewItemStorMiscComponent,
  },
  {
    path: "add-itemstor-misc",
    component: NewItemStorMiscComponent,
  },

  {
    path: "update-itemstor/:itemStorId",
    component: NewItemStorComponent,
  },
  {
    path: "add-itemstor",
    component: NewItemStorComponent,
  },
  {
    path: "view-itemstor/:itemStorId",
    component: ViewItemStorComponent,
  },
  {
    path: "manufacture-list",
    component: ManufactureListComponent,
  },
  {
    path: "update-manufacture/:manufactureId",
    component: NewManufactureComponent,
  },
  {
    path: "add-manufacture",
    component: NewManufactureComponent,
  },

  {
    path: "supplier-list",
    component: SupplierListComponent,
  },
  { path: "update-supplier/:supplierId", component: NewSupplierComponent },
  {
    path: "add-supplier",
    component: NewSupplierComponent,
  },

  {
    path: "principalname-list",
    component: PrincipalNameListComponent,
  },
  {
    path: "update-principalname/:principalNameId",
    component: NewPrincipalNameComponent,
  },
  {
    path: "add-principalname",
    component: NewPrincipalNameComponent,
  },

  // {
  //   path: 'demand-list',
  //   component: DemandListComponent,
  // },
  { path: "update-demand/:demandId", component: NewDemandComponent },
  {
    path: "add-demand",
    component: NewDemandComponent,
  },
  {
    path: "view-demand/:demandId",
    component: ViewDemandComponent,
  },
  {
    path: "previousitemstore-list",
    component: PreviousItemStoreListComponent,
  },
  {
    path: "update-previousitemstore/:previousItemStoreId",
    component: NewPreviousItemStoreComponent,
  },
  {
    path: "add-previousitemstore",
    component: NewPreviousItemStoreComponent,
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
    path: "view-previousitemstore/:previousItemStoreId",
    component: ViewPreviousItemStoreComponent,
  },
  {
    path: "update-stocktransfernsd/:stockTransferNsdId",
    component: NewStockTransferNsdComponent,
  },
  {
    path: "add-stocktransfernsd",
    component: NewStockTransferNsdComponent,
  },

  { path: "**", component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SparesManagementRoutingModule {}
