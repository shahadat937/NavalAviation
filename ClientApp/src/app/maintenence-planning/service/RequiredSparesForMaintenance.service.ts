import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IRequiredSparesForMaintenancePagination, RequiredSparesForMaintenancePagination } from '../models/RequiredSparesForMaintenancePagination'
import { RequiredSparesForMaintenance } from '../models/RequiredSparesForMaintenance';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class RequiredSparesForMaintenanceService {
  baseUrl = environment.apiUrl;
  RequiredSparesForMaintenances: RequiredSparesForMaintenance[] = [];
  RequiredSparesForMaintenancePagination = new RequiredSparesForMaintenancePagination();
  constructor(private http: HttpClient) { }


  getRequiredSparesForMaintenances(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IRequiredSparesForMaintenancePagination>(this.baseUrl + '/required-spares-for-maintenance/get-RequiredSparesForMaintenances', { observe: 'response', params })
    .pipe(
      map(response => {
        this.RequiredSparesForMaintenances = [...this.RequiredSparesForMaintenances, ...response.body.items];
        this.RequiredSparesForMaintenancePagination = response.body;
        return this.RequiredSparesForMaintenancePagination;
      })
    );
   
  }
  findRequirdSparesList( departmentId:number,sparesCategoryId:number,maintenanceTypeId:number,maintenanceCategoryId:number,maintenanceSubCategoryId:number){
    return this.http.get<RequiredSparesForMaintenance[]>(this.baseUrl + '/required-spares-for-maintenance/get-presentStocksForMaintenance?departmentId='+departmentId+'&sparesCategoryId='+sparesCategoryId+'&maintenanceTypeId='+maintenanceTypeId+'&maintenanceCategoryId='+maintenanceCategoryId+'&maintenanceSubCategoryId='+maintenanceSubCategoryId);
  }

  getSelectedPartNoByNameForSpares(partNo) {
    return this.http
      .get<SelectedModel[]>(
        this.baseUrl +
          "/item-detail/get-autocompletePartNoByNameForSpares?partNo=" +
          partNo +
          ""
      )
      .pipe(map((response: []) => response.map((item) => item)));
  }
  getSelectedPartNoByNameForSparesByDepartmentId(partNo,departmentId) {
    return this.http
      .get<SelectedModel[]>(
        this.baseUrl +"/item-detail/get-autocompletePartNoByNameForSparesByDepartmentId?partNo="+partNo+"&departmentNameId="+departmentId+"")
      .pipe(map((response: []) => response.map((item) => item)));
  }

  approvedRequiredSparesForMaintenance(id: number) {
    return this.http.get<RequiredSparesForMaintenance>(this.baseUrl + '/required-spares-for-maintenance/approved-requiredSparesForMaintenance/' + id);
  }
  getRequiredSparesForMaintenanceListByDepartmentName( departmentNameId:number){
    return this.http.get<RequiredSparesForMaintenance[]>(this.baseUrl + '/required-spares-for-maintenance/get-RequiredSparesForMaintenanceListByDepartmentNameId?departmentNameId='+departmentNameId);
   }
  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getselectedSparesCategory(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/spares-category/get-selectedSparesCategoryforRequired')
  }
  getselecteditemNameandPattNo(departmentNameId:number,spare:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/item-detail/get-itemNmaeAndPartNoByDepartmentNameId?departmentNameId='+departmentNameId+'&spare='+spare)
  }
  // getselectedMaintenanceTypes(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-type/get-selectedMaintenanceTypes')
  // }
  getselectedMaintenanceTypes(departmentNameId:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-type/get-selectedMaintenanceTypeByDepartmentNameId?departmentNameId='+departmentNameId)
  }
  getselectedMaintenanceCategory(departmentNameId:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-category/get-maintenanceCategoryByDepartment?departmentNameId='+departmentNameId)
  }

  getselectedMaintenanceCategoryByDeptAndType(departmentNameId,maintenanceTypeId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-category/get-selectedCategoryByDepartmentNameIdAndMaintenanceTypeId?departmentNameId='+departmentNameId+'&maintenanceTypeId='+maintenanceTypeId)
  }
  
  getselectedMaintenanceSubCategoryByDeptAndType(departmentNameId,maintenanceCategoryId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-sub-category/get-selectedMaintenanceSubCategorysByIdAndDepartmentId?departmentNameId='+departmentNameId+'&maintenanceCategoryId='+maintenanceCategoryId);
  }
  
  getselectedMaintenanceSubCategory(departmentNameId:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-sub-category/get-selectedMaintenanceSubCategoryByDepartmentId?departmentNameId='+departmentNameId)
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }

  find(id: number) {
    return this.http.get<RequiredSparesForMaintenance>(this.baseUrl + '/required-spares-for-maintenance/get-RequiredSparesForMaintenanceDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/required-spares-for-maintenance/update-RequiredSparesForMaintenance/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/required-spares-for-maintenance/save-RequiredSparesForMaintenance', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/required-spares-for-maintenance/delete-RequiredSparesForMaintenance/'+id);
  }

}
