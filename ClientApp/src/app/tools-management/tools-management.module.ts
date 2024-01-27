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
import { ToolsManagementRoutingModule } from "./tools-management-routing.module";
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
import { DemandListComponent } from "./demand/demand-list/demand-list.component";
import { NewDemandComponent } from "./demand/new-demand/new-demand.component";
import { NewItemStorComponent } from "./store/new-store/new-itemstor.component";
import { ViewDemandComponent } from "./demand/view-demand/view-demand.component";
import { ViewProcurementComponent } from "./procurement/view-procurement/view-procurement.component";
import { ViewAcceptanceComponent } from "./acceptance/view-acceptance/view-acceptance.component";
import { ViewItemStorComponent } from "./store/view-itemstor/view-itemstor.component";
import { CallibrationStateListComponent } from "./callibrationstate/callibrationstate-list/callibrationstate-list.component";
import { NewCallibrationStateComponent } from "./callibrationstate/new-callibrationstate/new-callibrationstate.component";
import { ReturnableIssueListComponent } from "./issueregister/returnableissue-list/returnableissue-list.component";
import { InventoryHistoryComponent } from "./inventory-history/inventory-history.component";
import { NewPreviousItemStoreComponent } from "./previousitemstore/new-previousitemstore/new-previousitemstore.component";
import { PreviousItemStoreListComponent } from "./previousitemstore/previousitemstore-list/previousitemstore-list.component";
// import { InventoryDetailsComponent } from "../spares-management/inventory-details/inventory-details.component";
import { MatRadioModule } from "@angular/material/radio";
import {CallibrationStateViewListComponent} from './callibrationstate/callibrationstateview-list/callibrationstateview-list.component';
import {SearchingComponent} from './searching/searching.component';


@NgModule({
  declarations: [
    CallibrationStateListComponent,
    NewCallibrationStateComponent,
    ItemDetailListComponent,
    NewItemDetailComponent,
    AcceptanceListComponent,
    NewAcceptanceComponent,
    ProcurementListComponent,
    NewProcurementComponent,
    DemandListComponent,
    NewDemandComponent,
    NewItemStorComponent,
    ViewDemandComponent,
    ViewProcurementComponent,
    ViewAcceptanceComponent,
    ViewItemStorComponent,
    ReturnableIssueListComponent,
    InventoryHistoryComponent,
    NewPreviousItemStoreComponent,
    PreviousItemStoreListComponent,
    CallibrationStateViewListComponent,
    SearchingComponent,
  ],
  imports: [
    CommonModule,
    ToolsManagementRoutingModule,
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
  ],
})
export class ToolsManagementModule {}
