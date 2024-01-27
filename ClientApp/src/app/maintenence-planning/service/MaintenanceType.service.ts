import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IMaintenanceTypePagination, MaintenanceTypePagination } from '../models/MaintenanceTypePagination'
import { MaintenanceType } from '../models/MaintenanceType';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class MaintenanceTypeService {
  baseUrl = environment.apiUrl;
  MaintenanceTypes: MaintenanceType[] = [];
  MaintenanceTypePagination = new MaintenanceTypePagination();
  constructor(private http: HttpClient) { }


  getMaintenanceTypes(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IMaintenanceTypePagination>(this.baseUrl + '/maintenance-type/get-MaintenanceTypes', { observe: 'response', params })
    .pipe(
      map(response => {
        this.MaintenanceTypes = [...this.MaintenanceTypes, ...response.body.items];
        this.MaintenanceTypePagination = response.body;
        return this.MaintenanceTypePagination;
      })
    );
   
  }

  
  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }

  find(id: number) {
    return this.http.get<MaintenanceType>(this.baseUrl + '/maintenance-type/get-MaintenanceTypeDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/maintenance-type/update-MaintenanceType/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/maintenance-type/save-MaintenanceType', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/maintenance-type/delete-MaintenanceType/'+id);
  }

}
