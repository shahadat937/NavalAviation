import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {ISurveyPagination, SurveyPagination } from '../models/SurveyPagination'
import { Survey } from '../models/Survey';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class SurveyService {
  baseUrl = environment.apiUrl;
  Surveys: Survey[] = [];
  SurveyPagination = new SurveyPagination();
  constructor(private http: HttpClient) { }

  getSurveys(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<ISurveyPagination>(this.baseUrl + '/survey/get-Surveyss', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Surveys = [...this.Surveys, ...response.body.items];
        this.SurveyPagination = response.body;
        return this.SurveyPagination;
      })
    );
   
  }
//AutoComplete
  getSelectedPartNoByNameByDepartmentId(nameOfItem,departmentId) {
    return this.http
      .get<SelectedModel[]>( //issue-register/get-autocompleteItemNameForSurveyParameterRequest?nameOfItem=Key%20assy%20&departmentNameId=9
        this.baseUrl +"/issue-register/get-autocompleteItemNameForSurveyParameterRequest?nameOfItem="+nameOfItem+"&departmentNameId="+departmentId+"")
      .pipe(map((response: []) => response.map((item) => item)));
  }
  getSurveyListByDepartmentName( departmentNameId:number){
    return this.http.get<Survey[]>(this.baseUrl + '/survey/get-surveyListByDepartmentNameId?departmentNameId='+departmentNameId);
   }
   getItemNameByDepartmentName( departmentNameId:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/issue-register/get-itemDetailForSurveyByDepartmentNameId?departmentNameId='+departmentNameId);
   }
  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }


  find(id: number) {
    return this.http.get<Survey>(this.baseUrl + '/survey/get-SurveyDetailDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/survey/update-Survey/'+id, model);
  }
  submit(model: any) {
    console.log(model)
    return this.http.post(this.baseUrl + '/survey/save-Survey', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/survey/delete-Survey/'+id);
  }

}
