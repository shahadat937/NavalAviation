import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IDegitalArchievePagination, DegitalArchievePagination } from '../models/DegitalArchievePagination'
import { DegitalArchieve } from '../models/DegitalArchieve';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class DegitalArchieveService {
  baseUrl = environment.apiUrl;
  DegitalArchieves: DegitalArchieve[] = [];
  DegitalArchievePagination = new DegitalArchievePagination();
  constructor(private http: HttpClient) { }

  getDegitalArchieves(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IDegitalArchievePagination>(this.baseUrl + '/degital-archieve/get-DegitalArchieves', { observe: 'response', params })
    .pipe(
      map(response => {
        this.DegitalArchieves = [...this.DegitalArchieves, ...response.body.items];
        this.DegitalArchievePagination = response.body;
        return this.DegitalArchievePagination;
      })
    );
   
  }
  getDegitalArchieveListByDepartmentName( departmentNameId:number){
    return this.http.get<DegitalArchieve[]>(this.baseUrl + '/degital-archieve/get-degitalArchieveListByDepartmentNameId?departmentNameId='+departmentNameId);
   }
  //  getItemNameByDepartmentName( departmentNameId:number){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/issue-register/get-itemDetailForSurveyByDepartmentNameId?departmentNameId='+departmentNameId);
  //  }
  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  getselecteDegitalDocType(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/degital-archieve-doc-type/get-selectedDegitalArchieveDocTypes')
  }
  getselecteAircraft(departmentNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/air-craft-name/get-selectedAirCraftNameByDepartmentId?departmentNameId='+departmentNameId)
  }

  find(id: number) {
    return this.http.get<DegitalArchieve>(this.baseUrl + '/degital-archieve/get-DegitalArchieveDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/degital-archieve/update-DegitalArchieve/'+id, model);
  }
  submit(model: any) {
    console.log(model)
    return this.http.post(this.baseUrl + '/degital-archieve/save-DegitalArchieve', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/degital-archieve/delete-DegitalArchieve/'+id);
  }

}
