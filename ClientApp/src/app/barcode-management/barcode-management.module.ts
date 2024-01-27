import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {BarcodeManagementRoutingModule} from './barcode-management-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MaterialFileInputModule } from 'ngx-material-file-input';
// import { NewProfileUpdateComponent } from './profileupdate/new-profileupdate.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { NgxBarcodeModule } from 'ngx-barcode';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import {BarcodeResultComponent} from './barcode-result/barcode-result.component';
import {BarcodeListComponent} from './barcode-list/barcode-list.component';

@NgModule({
  declarations: [
    //  NewProfileUpdateComponent,
    BarcodeResultComponent,
    BarcodeListComponent
  ],
  imports: [
    CommonModule,
    MatDatepickerModule,
    BarcodeManagementRoutingModule,
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
    MatAutocompleteModule,
    MaterialFileInputModule,
    NgxBarcodeModule
  ]
})
export class BarcodeManagementModule { }
