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
import { MEARoutingModule } from './mea-routing.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MaterialFileInputModule } from 'ngx-material-file-input';
import { HttpClientModule } from '@angular/common/http';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MeaSquadronStateListComponent } from './measquadronstate/measquadronstate-list/measquadronstate-list.component';
import { NewMeaSquadronStateComponent } from './measquadronstate/new-measquadronstate/new-measquadronstate.component';
import { MeaWorkShopListComponent } from './meaworkshop/meaworkshop-list/meaworkshop-list.component';
import { NewMeaWorkShopComponent } from './meaworkshop/new-meaworkshop/new-meaworkshop.component';
import { MeaMeaBlankFormatListComponent } from './meablankformat/meablankformat-list/meablankformat-list.component'
import { NewMeaBlankFormatComponent } from './meablankformat/new-meablankformat/new-meablankformat.component';
import { ViewMeaSquadronStateComponent } from './measquadronstate/view-measquadronstate/view-measquadronstate.component';
import { WorkRequisitionListComponent } from './measquadronstate/workrequisition-list/workrequisition-list.component';
import { MeaWorkProgressListComponent } from './measquadronstate/workprogress-list/workprogress-list.component';
import { NewTestEquipmentDetailComponent } from './testequipmentdetail/new-testequipmentdetail/new-testequipmentdetail.component';


@NgModule({
  declarations: [

    MeaSquadronStateListComponent,
    NewMeaSquadronStateComponent,
    ViewMeaSquadronStateComponent,
    MeaWorkShopListComponent,
    NewMeaWorkShopComponent,
    MeaMeaBlankFormatListComponent,
    NewMeaBlankFormatComponent,
    WorkRequisitionListComponent,
    MeaWorkProgressListComponent,
    NewTestEquipmentDetailComponent

  ],
  imports: [
    CommonModule,
    MEARoutingModule,
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
    
  ]
})
export class MEAModule { }
