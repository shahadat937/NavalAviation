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
import { MaintenecePlanningRoutingModule } from "./maintenence-planning-routing.module";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatStepperModule } from "@angular/material/stepper";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatNativeDateModule } from "@angular/material/core";
import { MaterialFileInputModule } from "ngx-material-file-input";
import { HttpClientModule } from "@angular/common/http";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatAutocompleteModule } from "@angular/material/autocomplete";

import { MaintenanceTypeListComponent } from "./maintenancetype/maintenancetype-list/maintenancetype-list.component";
import { NewMaintenanceTypeComponent } from "./maintenancetype/new-maintenancetype/new-maintenancetype.component";
import { MaintenanceScheduleListComponent } from "./maintenanceschedule/maintenanceschedule-list/maintenanceschedule-list.component";
import { NewMaintenancePlanningComponent } from "./maintenanceplanning/new-maintenanceplanning/new-maintenanceplanning.component";
import { MaintenanceCategoryListComponent } from "./maintenancecategory/maintenancecategory-list/maintenancecategory-list.component";
import { NewMaintenanceCategoryComponent } from "./maintenancecategory/new-maintenancecategory/new-maintenancecategoryr.component";
import { MaintenanceSubCategoryListComponent } from "./maintenancesubcategory/maintenancesubcategory-list/maintenancesubcategory-list.component";
import { NewMaintenanceSubCategoryComponent } from "./maintenancesubcategory/new-maintenancesubcategory/new-maintenancesubcategory.component";
import { MatTooltipModule } from "@angular/material/tooltip";
import { NewMaintenanceScheduleComponent } from "./maintenanceschedule/new-maintenanceschedule/new-maintenanceschedule.component";
import { MeaSquadronStateListComponent } from "./measquadronstate/measquadronstate-list/measquadronstate-list.component";
import { NewMeaSquadronStateComponent } from "./measquadronstate/new-measquadronstate/new-measquadronstate.component";
import { CallibrationStateListComponent } from "./callibrationstate/callibrationstate-list/callibrationstate-list.component";
import { NewCallibrationStateComponent } from "./callibrationstate/new-callibrationstate/new-callibrationstate.component";
import { ViewMaintenancePlanningComponent } from "./maintenanceplanning/view-maintenanceplanning/view-maintenanceplanning.component";
import { NewDailyAirworthinessFromCategoryComponent } from "./dailyairworthinessfromcategory/new-dailyairworthinessfromcategory/new-dailyairworthinessfromcategory.component";
import { NewDailyAirworthinessFromComponent } from "./dailyairworthinessfrom/new-dailyairworthinessfrom/new-dailyairworthinessfrom.component";
import { NewDailyAirworthinessRecordFromComponent } from "./dailyairworthinessfrom/new-dailyairworthinesrecordsfrom/new-new-dailyairworthinesrecordsfrom.component";
import { NewRequiredSparesForMaintenanceComponent } from './requiredsparesformaintenance/new-requiredsparesformaintenance/new-requiredsparesformaintenance.component';
import {MaintainenceStateListComponent} from './maintainencestate/maintainencestate-list/maintainencestate-list.component';
import {MaintainenceStateViewListComponent} from './maintainencestate/maintainencestateview-list/maintainencestateview-list.component'


@NgModule({
  declarations: [
    MaintenanceTypeListComponent,
    NewMaintenanceTypeComponent,
    MaintenanceScheduleListComponent,
    NewMaintenancePlanningComponent,
    MaintenanceCategoryListComponent,
    NewMaintenanceCategoryComponent,
    MaintenanceSubCategoryListComponent,
    NewMaintenanceSubCategoryComponent,
    NewMaintenanceScheduleComponent,
    MeaSquadronStateListComponent,
    NewMeaSquadronStateComponent,
    CallibrationStateListComponent,
    NewCallibrationStateComponent,
    ViewMaintenancePlanningComponent,
    NewDailyAirworthinessFromCategoryComponent,
    NewDailyAirworthinessFromComponent,
    NewDailyAirworthinessRecordFromComponent,
    NewRequiredSparesForMaintenanceComponent,
    MaintainenceStateListComponent,
    MaintainenceStateViewListComponent
  ],
  imports: [
    CommonModule,
    MaintenecePlanningRoutingModule,
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
  ],
})
export class MaintenecePlanningModule {}
