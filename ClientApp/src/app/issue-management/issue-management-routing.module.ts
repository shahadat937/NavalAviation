import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { Page404Component } from '../authentication/page404/page404.component';
import { IssueRegisterListComponent } from './issueregister/issueregister-list/issueregister-list.component';
import { NewIssueRegisterComponent } from './issueregister/new-issueregister/new-issueregister.component';
import { ReturnableIssueListComponent } from './issueregister/returnableissue-list/returnableissue-list.component';
import { NewToolsIssueRegisterComponent } from './toolsissueregister/new-toolsissueregister/new-toolsissueregister.component';
import { NewSurveyComponent } from './survey/new-survey/new-survey.component';




const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },

  {
    path: 'returnableissue-list',
    component: ReturnableIssueListComponent,
  },
  // {
  //   path: 'issueregister-list',
  //   component: IssueRegisterListComponent,
  // },
  { path: 'update-issueregister/:issueRegisterId', 
  component: NewIssueRegisterComponent 
  },
  {
    path: 'add-issueregister',
    component: NewIssueRegisterComponent,
  },

  { path: 'update-toolsissueregister/:issueRegisterId', 
  component: NewToolsIssueRegisterComponent 
  },
  {
    path: 'add-toolsissueregister',
    component: NewToolsIssueRegisterComponent,
  },
  { path: 'update-survey/:surveyId', 
  component: NewSurveyComponent 
  },
  {
    path: 'add-survey',
    component: NewSurveyComponent,
  },

  
  { path: '**', component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class IssueManagementRoutingModule { }
