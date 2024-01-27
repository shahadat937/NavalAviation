import { DashboardComponent as employeeDashboard } from "./../../employee/dashboard/dashboard.component";
import { DashboardComponent as userDashboard } from "./../../user-dashboard/dashboard/dashboard.component";
import { FLGWGDashboardComponent  } from "./flgwg-dashboard/flgwg-dashboard.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgxDatatableModule } from "@swimlane/ngx-datatable";
import { MatTableModule } from "@angular/material/table";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatStepperModule } from "@angular/material/stepper";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatSelectModule } from "@angular/material/select";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MaterialFileInputModule } from "ngx-material-file-input";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { PerfectScrollbarModule } from "ngx-perfect-scrollbar";
import { DashboardRoutingModule } from "./dashboard-routing.module";
import { MainComponent } from "./main/main.component";
import { NgxEchartsModule } from "ngx-echarts";
import { NgApexchartsModule } from "ng-apexcharts";
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from "@angular/material/button";
import { MatMenuModule } from "@angular/material/menu";
import { MatAutocompleteModule } from "@angular/material/autocomplete";

import { PendingDemandListComponent } from "./pendingdemand-list/pendingdemand-list.component";
import { PendingProcurementListComponent } from "./pendingprocurement-list/pendingprocurement-list.component";
import { PendingAcceptanceListComponent } from "./pendingacceptance-list/pendingacceptance-list.component";
import { FlyingDetailsListComponent } from "./flyingdetails-list/flyingdetails-list.component";
import { TrainingCrewListComponent } from "./trainingcrew-list/trainingcrew-list.component";
import { DemandListComponent } from "./demand-list/demand-list.component";
import { ACRunningHoursListComponent } from "./acrunninghours-list/acrunninghours-list.component";
import { procurementListComponent } from "./procurement-list/procurement-list.component";
import { acflyingprogramListComponent } from "./acflyingprogram-list/acflyingprogram-list.component";
import { AirCraftFlyingListComponent } from "./aircraftflying-list/aircraftflying-list.component";
import { AircraftNameOperationalListComponent } from "./aircraftnameoperational-list/aircraftnameoperational-list.component";
import { AircraftNameNonOperationalListComponent } from "./aircraftnamenonoperational-list/aircraftnamenonoperational-list.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { AircraftUnderMaintenanceListComponent } from "./aircraftundermaintenance-list/aircraftundermaintenance-list.component";
import { PersonalStateListComponent } from "./personalstate-list/personalstate-list.component";
import { logisticsIssuesListComponent } from "./logisticsissues-list/logisticsissues-list.component";
import { AircraftStatusListComponent } from "./aircraftstatus-list/aircraftstatus-list.component";
import { ViewNoticeComponent } from "./view-notice/view-notice.component";
import { PersonalStateByStatusListComponent } from "./personalstatebystatus-list/personalstatebystatus-list.component";
import { AcceptanceByPattnoComponent as AcceptanceByPattno } from "./../../spares-management/acceptance/acceptancebypattno-list/acceptancebypattno-list.component";

// import { ViewOfficerBiodataComponent } from '../../maintenence-planning/trainingcrew/view-officerbiodata/view-officerbiodata.component';

@NgModule({
  declarations: [
    MainComponent,
    PendingDemandListComponent,
    PendingProcurementListComponent,
    PendingAcceptanceListComponent,
    FlyingDetailsListComponent,
    TrainingCrewListComponent,
    DemandListComponent,
    ACRunningHoursListComponent,
    procurementListComponent,
    acflyingprogramListComponent,
    AirCraftFlyingListComponent,
    AircraftNameOperationalListComponent,
    AircraftNameNonOperationalListComponent,
    DashboardComponent,
    AircraftUnderMaintenanceListComponent,
    PersonalStateListComponent,
    logisticsIssuesListComponent,
    AircraftStatusListComponent,
    employeeDashboard,
    userDashboard,
    ViewNoticeComponent,
    AcceptanceByPattno,
    PersonalStateByStatusListComponent,
    FLGWGDashboardComponent,
    // ViewOfficerBiodataComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    NgxEchartsModule.forRoot({
      echarts: () => import("echarts"),
    }),
    PerfectScrollbarModule,
    MatIconModule,
    NgApexchartsModule,
    MatButtonModule,
    MatMenuModule,
    PerfectScrollbarModule,
    MatIconModule,
    NgApexchartsModule,
    MatButtonModule,
    MatMenuModule,
    CommonModule,
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
    MatSelectModule,
    MatDatepickerModule,
    MaterialFileInputModule,
    MatAutocompleteModule
  ],
})
export class DashboardModule {}
