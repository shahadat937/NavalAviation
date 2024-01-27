import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IMaintenanceSchedulePagination, MaintenanceSchedulePagination } from '../models/MaintenanceSchedulePagination'
import { MaintenanceSchedule } from '../models/MaintenanceSchedule';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MaintenancePlanning } from 'src/app/maintenence-planning/models/MaintenancePlanning';
@Injectable({
  providedIn: 'root'
})
export class MaintenanceScheduleService {
  baseUrl = environment.apiUrl;
  MaintenanceSchedules: MaintenanceSchedule[] = [];
  MaintenanceSchedulePagination = new MaintenanceSchedulePagination();
  constructor(private http: HttpClient) { }


  getMaintenanceSchedules(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IMaintenanceSchedulePagination>(this.baseUrl + '/maintenance-schedule/get-MaintenanceSchedules', { observe: 'response', params })
    .pipe(
      map(response => {
        this.MaintenanceSchedules = [...this.MaintenanceSchedules, ...response.body.items];
        this.MaintenanceSchedulePagination = response.body;
        return this.MaintenanceSchedulePagination;
      })
    );
   
  }
  getAirCraftNameByDepartmentNameId(departmentnameId:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/air-craft-name/get-selectedAirCraftNameByDepartmentNameId?departmentNameId=' + departmentnameId);
  }
  
  maintenanceScheduleListByDepartmentAndAirCraftName(airCraftNameId:number, departmentNameId:number){
    return this.http.get<MaintenanceSchedule[]>(this.baseUrl + '/maintenance-schedule/get-maintenanceScheduleListByDepartmentNameId?airCraftNameId='+airCraftNameId+'&departmentNameId='+departmentNameId);
  }
  maintenanceScheduleListByDepartmentAndAirCraftNameAndType(maintenanceTypeId:number,airCraftNameId:number,departmentNameId:number){
    return this.http.get<MaintenanceSchedule[]>(this.baseUrl + '/maintenance-planning/get-maintemancePlanningListByDepartmentAndAirCraftNameAndType?maintenanceTypeId='+maintenanceTypeId+'&airCraftNameId='+airCraftNameId+'&departmentNameId='+departmentNameId);
  }
  maintenanceScheduleListByDepartmentAndAirCraftNameAndTypeAndCategory(maintenanceCategoryId:number,maintenanceTypeId:number,airCraftNameId:number,departmentNameId:number){
    return this.http.get<MaintenanceSchedule[]>(this.baseUrl + '/maintenance-planning/get-maintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategory?maintenanceCategoryId='+maintenanceCategoryId+'&maintenanceTypeId='+maintenanceTypeId+'&airCraftNameId='+airCraftNameId+'&departmentNameId='+departmentNameId);
  }
  maintenanceScheduleRecordListByParams(departmentNameId,airCraftNameId,maintenanceTypeId,maintanenceCategoryId,maintanenceSubCategoryId){
    return this.http.get<any[]>(this.baseUrl + '/maintenance-schedule/get-maintenanceScheduleRecordListByParams?departmentNameId='+departmentNameId+'&airCraftNameId='+airCraftNameId+'&maintanenceTypeId='+maintenanceTypeId+'&maintanenceCategoryId='+maintanenceCategoryId+'&maintanenceSubCategoryId='+maintanenceSubCategoryId);
  }
  maintenanceScheduleListByDepartmentAndAirCraftNameAndTypeAndCategoryAndSubCategory(maintenanceSubCategoryId:number,maintenanceCategoryId:number,maintenanceTypeId:number,airCraftNameId:number,departmentNameId:number){
    return this.http.get<MaintenanceSchedule[]>(this.baseUrl + '/maintenance-planning/get-maintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategoryAndSubCategory?maintenanceSubCategoryId='+maintenanceSubCategoryId+'&maintenanceCategoryId='+maintenanceCategoryId+'&maintenanceTypeId='+maintenanceTypeId+'&airCraftNameId='+airCraftNameId+'&departmentNameId='+departmentNameId);
  }
  getMaintenanceTypeByDepartmentNameId(departmentnameId:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-type/get-selectedMaintenanceTypeByDepartmentNameId?departmentNameId=' + departmentnameId);
  }
  getCategoryByDepartmentNameIdAndMaintenanceTypeId( maintenanceTypeId:number ){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-category/get-selectedCategoryByDepartmentNameIdAndMaintenanceTypeId?maintenanceTypeId='+maintenanceTypeId);
  }
  getSubCategoryByDepartmentNameIdAndMaintenanceCategoryId( maintenanceCategoryId:number ){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-sub-category/get-selectedSubCategoryByDepartmentNameIdAndMaintenanceCategoryId?maintenanceCategoryId='+maintenanceCategoryId);
  }
  getAllowedExtensionBySubCategoryId(id:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-sub-category/get-selectedAllowedExtensionBySubCategoryId?maintenanceSubCategoryId=' + id);
  }
  getselectedplanningStatus(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-planningStatus/get-selectedMaintenancePlanningStatus')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  getCategoryByDepartmentNameIdAndMaintenanceCategoryId( maintenanceCategoryId:number ){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-sub-category/get-selectedSubCategoryByDepartmentNameIdAndMaintenanceCategoryId?maintenanceCategoryId='+maintenanceCategoryId);
  }
  getselectedMaintenanceTypes(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-type/get-selectedMaintenanceTypes')
  }
  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getselectedAllowedExtensionBySubCategoryIdDepartmentIdAndCategoryId(departmentNameId: number, maintenanceCategoryId:number, maintenanceSubCategoryId:number){
    return this.http.get<any>(this.baseUrl + '/maintenance-sub-category/get-selectedAllowedExtensionBySubCategoryIdDepartmentIdAndCategoryId?departmentNameId='+departmentNameId+'&maintenanceCategoryId='+maintenanceCategoryId+'&maintenanceSubCategoryId='+maintenanceSubCategoryId)
  }
  getselectedMaintenancePlanning(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-planning/get-selectedMaintenancePlannings')
  }


  getMaintenancePlanningByParams(departmentNameId,airCraftNameId,maintenanceTypeId,maintenanceCategoryId,maintenanceSubCategoryId){
    return this.http.get<MaintenancePlanning[]>(this.baseUrl + '/maintenance-planning/get-maintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategoryAndSubCategory?maintenanceSubCategoryId='+maintenanceSubCategoryId+'&maintenanceCategoryId='+maintenanceCategoryId+'&maintenanceTypeId='+maintenanceTypeId+'&airCraftNameId='+airCraftNameId+'&departmentNameId='+departmentNameId)
  }
  getMaintenancePlanningListTableByDateRange(maintenancePlanningId, diffBetween){
    return this.http.get<any[]>(this.baseUrl + '/maintenance-schedule/get-maintenanceScheduleListByDateRange?maintenancePlanningId='+maintenancePlanningId+'&countBetween='+diffBetween);
  }
  // getselectedSubCategory(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-sub-category/get-selectedMaintenanceSubCategorys')
  // }
  getAllowedNestInspDateByMaintenancePlanningId(id:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-planning/get-selectedAllowedNestInspDateByMaintenancePlanningId?maintenancePlanningId=' + id);
  }
  

  find(id: number) {
    return this.http.get<MaintenanceSchedule>(this.baseUrl + '/maintenance-schedule/get-MaintenanceScheduleDetail/' + id);
  }

  updateScheduleMaintenence(id: number,model: any){
    return this.http.put(this.baseUrl + '/maintenance-schedule/update-scheduleMaintenence/'+id, model);
  }

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/maintenance-schedule/update-MaintenanceSchedule/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/maintenance-schedule/save-MaintenanceSchedule', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/maintenance-schedule/delete-MaintenanceSchedule/'+id);
  }

}
