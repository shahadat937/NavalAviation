import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MaterialFileInputModule } from 'ngx-material-file-input';
import { HttpClientModule } from '@angular/common/http';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { BiodataRoutingModule } from './biodata-routing.module';
import {SailorBioDataListComponent} from './../maintenence-planning/sailorbiodata/sailorbiodata-list/sailorbiodata-list.component';
import {NewSailorBiodataComponent} from './../maintenence-planning/sailorbiodata/new-sailorbiodata/new-sailorbiodata.component';
import {TrainingCrewListComponent} from './../maintenence-planning/trainingcrew/trainingcrew-list/trainingcrew-list.component';
import {NewTrainingCrewComponent} from './../maintenence-planning/trainingcrew/new-trainingcrew/new-trainingcrew.component';
import { ViewOfficerBiodataComponent } from './../maintenence-planning/trainingcrew/view-officerbiodata/view-officerbiodata.component'
import { ViewSailorBiodataComponent } from './../maintenence-planning/sailorbiodata/view-sailorbiodata/view-sailorbiodata.component';
import {NewAttendanceComponent} from '../biodata/new-attendance/new-attendance.component';
import {AttendanceListComponent} from '../biodata/attendance-list/attendance-list.component';

@NgModule({
  declarations: [
    SailorBioDataListComponent,
    NewSailorBiodataComponent,
    TrainingCrewListComponent,
    NewTrainingCrewComponent,
    ViewOfficerBiodataComponent,
    ViewSailorBiodataComponent,
    NewAttendanceComponent,
    AttendanceListComponent
  ],
  imports: [
    CommonModule,
    CommonModule,
    FormsModule, 
    BiodataRoutingModule, 
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
  ],
})
export class BiodataModule {}
