import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgxDatatableModule } from "@swimlane/ngx-datatable";
import { MatTableModule } from "@angular/material/table";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatSelectModule } from "@angular/material/select";
import { SparesManagementRoutingModule } from "./spares-management-routing.module";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatStepperModule } from "@angular/material/stepper";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatNativeDateModule } from "@angular/material/core";
import { MaterialFileInputModule } from "ngx-material-file-input";
import { HttpClientModule } from "@angular/common/http";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatAutocompleteModule } from "@angular/material/autocomplete";
import { ItemDetailListComponent } from "./itemdetail/itemdetail-list/itemdetail-list.component";
import { NewItemDetailComponent } from "./itemdetail/new-itemdetail/new-itemdetail.component";
import { AcceptanceListComponent } from "./acceptance/acceptance-list/acceptance-list.component";
import { NewAcceptanceComponent } from "./acceptance/new-acceptance/new-acceptance.component";
import { MatTooltipModule } from "@angular/material/tooltip";
import { ProcurementListComponent } from "./procurement/procurement-list/procurement-list.component";
import { NewProcurementComponent } from "./procurement/new-procurement/new-procurement.component";
import { NewDemandComponent } from "./demand/new-demand/new-demand.component";
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
import { MatRadioModule } from '@angular/material/radio';
import { NewStockTransferNsdComponent } from './stocktransfernsd/new-stocktransfernsd/new-stocktransfernsd.component';
import { NsdStockDetailsComponent } from './nsdstock-details/nsdstock-details.component';
import { SearchingComponent } from './searching/searching.component';
import { NgxBarcodeModule } from 'ngx-barcode';
import {
  BarcodeScannerLivestreamModule,
  BarcodeScannerLivestreamOverlayModule
} from 'ngx-barcode-scanner';
import { AllDocumentListComponent } from './itemstor/alldocument-list/alldocument-list.component'

@NgModule({
  declarations: [
    AllDocumentListComponent,
    NewStockTransferNsdComponent,
    ItemDetailListComponent,
    NewItemDetailComponent,
    AcceptanceListComponent,
    NewAcceptanceComponent,
    ProcurementListComponent,
    NewProcurementComponent,
    NewDemandComponent,
    ItemStorListComponent,
    NewItemStorMainEquComponent,
    NewItemStorSparesComponent,
    NewItemStorConsumbleComponent,
    NewItemStorReturnableComponent,
    NewItemStorLifeLimitItemComponent,
    NewItemStorMiscComponent,
    PreviousItemStoreListComponent,
    NewPreviousItemStoreComponent,
    ManufactureListComponent,
    NewManufactureComponent,
    SupplierListComponent,
    NewSupplierComponent,
    PrincipalNameListComponent,
    NewPrincipalNameComponent,
    NewItemStorComponent,
    ViewDemandComponent,
    ViewProcurementComponent,
    ViewAcceptanceComponent,
    ViewItemStorComponent,
    ViewPreviousItemStoreComponent,
    InventoryHistoryComponent,
    InventoryDetailsComponent,
    ProcurementProgressComponent,
    NsdStockDetailsComponent,
    SearchingComponent
  ],
  imports: [
    CommonModule,
    SparesManagementRoutingModule,
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
    MatTooltipModule,
    MatRadioModule,
    NgxBarcodeModule,
    BarcodeScannerLivestreamModule,
    BarcodeScannerLivestreamOverlayModule
  ],
})
export class SparesManagementModule {}
