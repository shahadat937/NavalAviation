import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IMaintenanceSubCategoryPagination,MaintenanceSubCategoryPagination } from '../models/maintenanceSubCategoryPagination'
import { MaintenanceSubCategory } from '../models/maintenanceSubCategory';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class MaintenanceSubCategoryService {
  baseUrl = environment.apiUrl;
  MaintenanceSubCategorys: MaintenanceSubCategory[] = [];
  MaintenanceSubCategoryPagination = new MaintenanceSubCategoryPagination();
  constructor(private http: HttpClient) { }

  getMaintenanceSubCategorys(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IMaintenanceSubCategoryPagination>(this.baseUrl + '/maintenance-sub-category/get-MaintenanceSubCategorys', { observe: 'response', params })
    .pipe(
      map(response => {
        this.MaintenanceSubCategorys = [...this.MaintenanceSubCategorys, ...response.body.items];
        this.MaintenanceSubCategoryPagination = response.body;
        return this.MaintenanceSubCategoryPagination;
      })
    );
   
  }
  getMaintenanceCategoryByDepartmentAndType(departmentId,maintenanceTypeId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-category/get-selectedCategoryByDepartmentNameIdAndMaintenanceTypeId?departmentNameId='+departmentId+'&maintenanceTypeId='+maintenanceTypeId)
  }

  getMaintenanceSubCategoryByDepartmentAndCategory(departmentNameId,maintenanceCategoryId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-sub-category/get-selectedMaintenanceSubCategorysByIdAndDepartmentId?departmentNameId='+departmentNameId+'&maintenanceCategoryId='+maintenanceCategoryId);
  }
  getselectedMaintenanceCategory(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-category/get-selectedMaintenanceCategorys')
  }
  getselectedDepartmentName(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  //maintenance-sub-category/get-selectedMaintenanceSubCategorysByIdAndDepartmentId?departmentNameId=2&maintenanceSubCategoryId=4
  getSelectedMaintenanceSubCategory(departmentNameId:number,maintenanceCategoryId:number){
    return this.http.get<MaintenanceSubCategory[]>(this.baseUrl + '/maintenance-sub-category/get-selectedMaintenanceSubCategorysByIdAndDepartmentId?departmentNameId='+departmentNameId+'&maintenanceCategoryId='+maintenanceCategoryId)
  }

  find(id: number) {
    return this.http.get<MaintenanceSubCategory>(this.baseUrl + '/maintenance-sub-category/get-MaintenanceSubCategoryDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/maintenance-sub-category/update-MaintenanceSubCategory/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/maintenance-sub-category/save-MaintenanceSubCategory', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/maintenance-sub-category/delete-MaintenanceSubCategory/'+id);
  }

}
