import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {BarcodeResultComponent} from './barcode-result/barcode-result.component';
import {BarcodeListComponent} from './barcode-list/barcode-list.component';
// import {NewProfileUpdateComponent} from './profileupdate/new-profileupdate.component'
// import {NewPasswordChangeComponent} from './passwordchange/new-passwordchange.component'
//import { NewPasswordChangeComponent } from 'src/app/instructor/passwordchange/new-passwordchange.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },

  // {
  //   path: 'profile-update',
  //   component: NewProfileUpdateComponent,
  // },
  {
    path: 'barcode-scan',
    component: BarcodeResultComponent,
  },
  {
    path: 'barcode-print',
    component: BarcodeListComponent,
  },
  // {
  //   path: 'password-change',
  //   component: NewPasswordChangeComponent,
  // },
  // {
  //   path: 'passwordupdate-student',
  //   component: NewPasswordChangeComponent,
  // },
  
]; 

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BarcodeManagementRoutingModule { }
