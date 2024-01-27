import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IDepartmentNamePagination, DepartmentNamePagination } from '../models/DepartmentNamePagination'
import { DepartmentName } from '../models/DepartmentName';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class DepartmentNameService {
  baseUrl = environment.apiUrl;
  DepartmentNames: DepartmentName[] = [];
  DepartmentNamePagination = new DepartmentNamePagination();
  constructor(private http: HttpClient) { }

  getDepartments(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IDepartmentNamePagination>(this.baseUrl + '/department-name/get-DepartmentNames', { observe: 'response', params })
    .pipe(
      map(response => {
        this.DepartmentNames = [...this.DepartmentNames, ...response.body.items];
        this.DepartmentNamePagination = response.body;
        return this.DepartmentNamePagination;
      })
    );
   
  }

  getselectedDepertments(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  find(id: number) {
    return this.http.get<DepartmentName>(this.baseUrl + '/department-name/get-DepartmentNameDetail/' + id);
  }
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/department-name/update-DepartmentName/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/department-name/save-DepartmentName', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/department-name/delete-DepartmentName/'+id);
  }

}
