import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IMaintenancePlanningPagination, MaintenancePlanningPagination } from '../models/MaintenancePlanningPagination'
import { MaintenancePlanning } from '../models/MaintenancePlanning';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class MaintenancePlanningService {
  baseUrl = environment.apiUrl;
  MaintenancePlannings: MaintenancePlanning[] = [];
  MaintenancePlanningPagination = new MaintenancePlanningPagination();
  constructor(private http: HttpClient) { }


  getMaintenancePlannings(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IMaintenancePlanningPagination>(this.baseUrl + '/maintenance-planning/get-MaintenancePlannings', { observe: 'response', params })
    .pipe(
      map(response => {
        this.MaintenancePlannings = [...this.MaintenancePlannings, ...response.body.items];
        this.MaintenancePlanningPagination = response.body;
        return this.MaintenancePlanningPagination;
      })
    );
   
  }
  completeMaintenancePlanning(id: number) { //maintenance-planning/completeStatus-maintenancePlanning/2310
    return this.http.get<MaintenancePlanning>(this.baseUrl + '/maintenance-planning/completeStatus-maintenancePlanning/' + id);
  }
  approvedMaintenancePlanning(id: number) {
    return this.http.get<MaintenancePlanning>(this.baseUrl + '/maintenance-planning/approved-maintenancePlanning/' + id);
  }
  getAirCraftNameByDepartmentNameId(departmentnameId:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/air-craft-name/get-selectedAirCraftNameByDepartmentNameId?departmentNameId=' + departmentnameId);
  }
  getMaintenanceTypeByDepartmentNameId(departmentnameId:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-type/get-selectedMaintenanceTypeByDepartmentNameId?departmentNameId=' + departmentnameId);
  }
  getCategoryByDepartmentNameIdAndMaintenanceTypeId( departmentId,maintenanceTypeId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-category/get-selectedCategoryByDepartmentNameIdAndMaintenanceTypeId?departmentNameId='+departmentId+'&maintenanceTypeId='+maintenanceTypeId);
  }
  getCategoryByDepartmentNameIdAndMaintenanceCategoryId( maintenanceCategoryId:number ){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-sub-category/get-selectedSubCategoryByDepartmentNameIdAndMaintenanceCategoryId?maintenanceCategoryId='+maintenanceCategoryId);
  }
  getAllowedExtensionBySubCategoryId(id:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-sub-category/get-selectedAllowedExtensionBySubCategoryId?maintenanceSubCategoryId=' + id);
  }
  maintenancePlanningListByDepartmentAndAirCraftName(airCraftNameId:number,departmentNameId:number){
    return this.http.get<MaintenancePlanning[]>(this.baseUrl + '/maintenance-planning/get-maintemancePlanningListByDepartmentAndAirCraftName?airCraftNameId='+airCraftNameId+'&departmentNameId='+departmentNameId);
  }
  maintenancePlanningListByDepartmentAndAirCraftNameAndType(maintenanceTypeId:number,airCraftNameId:number,departmentNameId:number){
    return this.http.get<MaintenancePlanning[]>(this.baseUrl + '/maintenance-planning/get-maintemancePlanningListByDepartmentAndAirCraftNameAndType?maintenanceTypeId='+maintenanceTypeId+'&airCraftNameId='+airCraftNameId+'&departmentNameId='+departmentNameId);
  }
  maintenancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategory(maintenanceCategoryId:number,maintenanceTypeId:number,airCraftNameId:number,departmentNameId:number){
    return this.http.get<MaintenancePlanning[]>(this.baseUrl + '/maintenance-planning/get-maintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategory?maintenanceCategoryId='+maintenanceCategoryId+'&maintenanceTypeId='+maintenanceTypeId+'&airCraftNameId='+airCraftNameId+'&departmentNameId='+departmentNameId);
  }
  
  maintemanceScheduleListByParams(departmentNameId,airCraftNameId,maintenanceTypeId,maintenanceCategoryId,maintenanceSubCategoryId){
    return this.http.get<any[]>(this.baseUrl + '/maintenance-schedule/get-maintemanceScheduleListByParams?departmentNameId='+departmentNameId+'&airCraftNameId='+airCraftNameId+'&maintenanceTypeId='+maintenanceTypeId+'&maintenanceCategoryId='+maintenanceCategoryId+'&maintenanceSubCategoryId='+maintenanceSubCategoryId);
  }

  maintenancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategoryAndSubCategory(maintenanceSubCategoryId:number,maintenanceCategoryId:number,maintenanceTypeId:number,airCraftNameId:number,departmentNameId:number){
    return this.http.get<MaintenancePlanning[]>(this.baseUrl + '/maintenance-planning/get-maintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategoryAndSubCategory?maintenanceSubCategoryId='+maintenanceSubCategoryId+'&maintenanceCategoryId='+maintenanceCategoryId+'&maintenanceTypeId='+maintenanceTypeId+'&airCraftNameId='+airCraftNameId+'&departmentNameId='+departmentNameId);
  }
  // getselectedAirCraftNames(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/air-craft-name/get-selectedAirCraftNames')
  // }
  getselectedMaintenanceTypes(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-type/get-selectedMaintenanceTypes')
  }
  // getselectedMaintenanceCategorys(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-category/get-selectedMaintenanceCategorys')
  // }
  // getselectedMaintenanceSubCategorys(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-sub-category/get-selectedMaintenanceSubCategorys')
  // }
  getselectedplanningStatus(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-planningStatus/get-selectedMaintenancePlanningStatus')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }


  find(id: number) {
    return this.http.get<MaintenancePlanning>(this.baseUrl + '/maintenance-planning/get-MaintenancePlanningDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/maintenance-planning/update-MaintenancePlanning/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/maintenance-planning/save-MaintenancePlanning', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/maintenance-planning/delete-MaintenancePlanning/'+id);
  }

}
