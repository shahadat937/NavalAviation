import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { Page404Component } from '../authentication/page404/page404.component';
import { NewAboutComponent } from './about/new-about/new-about.component';




const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },
  
  
  // { path: 'update-degitalarchieve/:degitalArchieveId', 
  // component: NewDegitalArchieveComponent 
  // },
  {
    path: 'add-about',
    component: NewAboutComponent,
  },
 
  

  
  { path: '**', component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class AboutRoutingModule { }
