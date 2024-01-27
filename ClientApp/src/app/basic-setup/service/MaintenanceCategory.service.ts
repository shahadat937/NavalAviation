import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IMaintenanceCategoryPagination, MaintenanceCategoryPagination } from '../models/MaintenanceCategoryPagination'
import { MaintenanceCategory } from '../models/MaintenanceCategory';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class MaintenanceCategoryService {
  baseUrl = environment.apiUrl;
  MaintenanceCategorys: MaintenanceCategory[] = [];
  MaintenanceCategoryPagination = new MaintenanceCategoryPagination();
  constructor(private http: HttpClient) { }


  getMaintenanceCategorys(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IMaintenanceCategoryPagination>(this.baseUrl + '/maintenance-category/get-maintenanceCategories', { observe: 'response', params })
    .pipe(
      map(response => {
        this.MaintenanceCategorys = [...this.MaintenanceCategorys, ...response.body.items];
        this.MaintenanceCategoryPagination = response.body;
        return this.MaintenanceCategoryPagination;
      })
    );
   
  }

  // getselectedItemStors(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/item-stor/get-selectedItemStors')
  // }
  getselectedItemDetails(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/item-detail/get-selectedItemDetails')
  }
  getselectedIssueStatuses(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/issue-status/get-selectedIssueStatuses')
  }
  // getselectedDepartmentNames(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
 // maintenance-category/get-maintenanceCategoryByTypeAndDepartment?maintenanceTypeId=1&departmentNameId=2'
  // }
 getMaintainencesCategoryByTypeAndDepartment(maintenanceTypeId:number,departmentNameId:number){
  return this.http.get<MaintenanceCategory[]>(this.baseUrl + '/maintenance-category/get-maintenanceCategoryByTypeAndDepartment?maintenanceTypeId='+maintenanceTypeId+'&departmentNameId='+departmentNameId);
 }
  getselectedMaintenanceType(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-type/get-selectedMaintenanceTypes')
  }
  getMaintenanceTypeByDepartmentNameId(departmentnameId:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-type/get-selectedMaintenanceTypeByDepartmentNameId?departmentNameId=' + departmentnameId);
  }
  find(id: number) {
    return this.http.get<MaintenanceCategory>(this.baseUrl + '/maintenance-category/get-maintenanceCategoryDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/maintenance-category/update-maintenanceCategory/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/maintenance-category/save-maintenanceCategory', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/maintenance-category/delete-maintenanceCategory/'+id);
  }

}
