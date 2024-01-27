import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { SelectedModel } from "src/app/core/models/selectedModel";
import { map } from "rxjs";
@Injectable({
  providedIn: "root",
})
export class DashboardService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  getAircraftFlyingData(id) {
    return this.http.get<any[]>(this.baseUrl + "/dashboard/get-aircraftinFlightData?departmentId="+id);
  }
  //dashboard/get-nonOpearionalAircraftNameCount?departmentId=0
  getTodayNoticeBoardData(id) {
    return this.http.get<any[]>(this.baseUrl + "/dashboard/get-todayNoticeBoardData?departmentId="+id);
  }
  

  getOperatinalAircraftNameCount(id) {
    return this.http.get<any>(
      this.baseUrl +
        "/dashboard/get-opearionalAircraftNameCount?departmentId=" +
        id +
        ""
    );
  }

  getNonOperatinalAircraftNameCount(id) {
    return this.http.get<any>(
      this.baseUrl +
        "/dashboard/get-nonOpearionalAircraftNameCount?departmentId=" +
        id +
        ""
    );
  }

  getRemainProcurementQty(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-remainProcurementQty?departmentId=" + id
    );
  }
  getDepartmentNameById(id) {
    return this.http.get<any>(this.baseUrl + "/base-School-name/get-baseSchoolNameDetail/"+id);
  }

  getPendingDemands(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-pendingDemands?departmentId=" + id
    );
  }
  getTrainingCrew(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-trainingCrew?departmentId=" + id
    );
  }
  getPendingProcurements(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-pendingProcurements?departmentId=" + id
    );
  }

  getPendingAcceptances(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-pendingAcceptances?departmentId=" + id
    );
  }

  getAvailableQty(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-availableQty?departmentId=" + id
    );
  }
  getFlyingTimeByAricraft(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-flyingTimeByAricraft?departmentId=" + id
    );
  }
  getAricraftFlying(current, id) {
    return this.http.get<any>(
      this.baseUrl +
        "/dashboard/get-aricraftFlying?currentDate=" +
        current +
        "&departmentId=" +
        id
    );
  }
  getDemandSpGetCompleteStatus(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-SpGetCompleteStatus?departmentId=" + id
    );
  }
  getSelectedSchoolName(baseNameId) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/base-School-name/get-selectedSchoolNames?thirdLevel=" +
        baseNameId
    );
  }
  getAricraftFlyingSchedule(dateFrom,dateTo, id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-spFlyingSchedule?dateFrom="+dateFrom+"&dateTo="+dateTo+"&departmentId="+id);
  }
  // getAricraftFlyingSchedules(datefrom,dateto, id) {
  //   return this.http.get<any>(
  //     this.baseUrl +
  //       "/dashboard/get-spFlyingSchedule?dateFrom=" +datefrom +"&dateTo"+dateto+ "&departmentId=" +id);
  // }
  getAricraftUnderMaintenance(current, id) {
    return this.http.get<any>(
      this.baseUrl +
        "/dashboard/get-spAcUnderMaintenance?currentDate=" +
        current +
        "&departmentId=" +
        id
    );
  }
  getAircraftStatusCount(departmentId) {
    return this.http.get<any>(
      this.baseUrl +
        "/dashboard/get-spAricraftStatusCount?departmentId=" +
        departmentId
    );
  }
  getAircraftStatus(current, departmentId) {
    return this.http.get<any>(
      this.baseUrl +
        "/dashboard/get-spAricraftStatus?currentDate=" +
        current +
        "&departmentId=" +
        departmentId
    );
  }
  getPersonalState(departmentId) {
    return this.http.get<any[]>(
      this.baseUrl + "/dashboard/get-personalState?departmentId=" + departmentId
    );
  }
  maintenanceScheduleListByDepartmentAndAirCraftName(airCraftNameId, departmentNameId){
    return this.http.get<any[]>(this.baseUrl + '/maintenance-schedule/get-maintenanceScheduleListByDepartmentNameId?airCraftNameId='+airCraftNameId+'&departmentNameId='+departmentNameId);
  }
  

  maintenanceScheduleListByDepartmentAndAirCraftNameFilter(airCraftNameId, departmentNameId,dateFrom,dateTo){
    return this.http.get<any[]>(this.baseUrl + '/maintenance-schedule/get-maintenanceScheduleListByDepartmentNameId?airCraftNameId='+airCraftNameId+'&departmentNameId='+departmentNameId+'&dateFrom='+dateFrom+'&dateTo='+dateTo);
  }
  getPersonalStateTotalCount() {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-personalStateTotalCount"
    );
  }

  getPersonalStateTotalCountByDepartmentNameId(departmentId) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-personalStateTotalCountByDepartmentNameId?departmentNameId="+departmentId);
  }

  
  getpersonalStateTotalByStatus(departmentNameId,officersStatusId,presentBilletId,employeeTypeId) {
    return this.http.get<any[]>(
      this.baseUrl + "/dashboard/get-personalStateTotalByStatus?departmentNameId="+departmentNameId+"&officersStatusId="+officersStatusId+"&presentBilletId="+presentBilletId+"&employeeTypeId="+employeeTypeId);
  }
  
  getSelectedEmployeeType() {
    return this.http.get<any[]>(
      this.baseUrl + "/employee-type/get-selectedEmployeeType");
  }
}
