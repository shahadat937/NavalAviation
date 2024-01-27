import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { environment } from "src/environments/environment";
import {
  IAcceptancePagination,
  AcceptancePagination,
} from "../models/AcceptancePagination";
import { Acceptance } from "../models/Acceptance";
import { map } from "rxjs";
import { SelectedModel } from "src/app/core/models/selectedModel";
@Injectable({
  providedIn: "root",
})
export class AcceptanceService {
  baseUrl = environment.apiUrl;
  Acceptances: Acceptance[] = [];
  AcceptancePagination = new AcceptancePagination();
  constructor(private http: HttpClient) {}

  getAcceptances(pageNumber, pageSize, searchText, sparesCategoryId) {
    let params = new HttpParams();

    params = params.append("searchText", searchText.toString());
    params = params.append("pageNumber", pageNumber.toString());
    params = params.append("pageSize", pageSize.toString());
    params = params.append("sparesCategoryId", sparesCategoryId.toString());

    return this.http
      .get<IAcceptancePagination>(
        this.baseUrl + "/acceptance/get-acceptances",
        { observe: "response", params }
      )
      .pipe(
        map((response) => {
          this.Acceptances = [...this.Acceptances, ...response.body.items];
          this.AcceptancePagination = response.body;
          return this.AcceptancePagination;
        })
      );
  }
  approvedAcceptance(id: number) {
    return this.http.get<Acceptance>(this.baseUrl + '/acceptance/approved-Acceptance/' + id);
  }
  getPartNoPassItemCategoryIdInAcceptance(itemDetailId: number) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/acceptance/get-PartNoPassItemCategoryIdInAcceptance?itemDetailId=" +
        itemDetailId
    );
  }
  getselectedItemDetails() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/item-detail/get-selectedItemDetails"
    );
  }

  getselectedProcurements(procurementId, spearCategoryId) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/procurement/get-partnoFromProcurementByDepartmentNameId?departmentNameId=" +
        procurementId +
        "&sparesCategoryId=" +
        spearCategoryId
    );
  }

  getselectedProcurementsOnUpdate(procurementId, spearCategoryId) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/procurement/get-partnoFromProcurementForUpdateByDepartmentNameId?departmentNameId=" +
        procurementId +
        "&sparesCategoryId=" +
        spearCategoryId
    );
  }

  getselectedSourceOfSupplys() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/source-of-supply/get-selectedSourceOfSupplys"
    );
  }
  getSelectedSchoolName(baseNameId) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/base-School-name/get-selectedSchoolNames?thirdLevel=" +
        baseNameId
    );
  }
  getselectedManufactures() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/manufacture/get-selectedManufactures"
    );
  }
  getselectedPrincipalNames() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/principal-name/get-selectedPrincipalNames"
    );
  }
  getselectedPlaceOfDeliverys() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/place-of-delivery/get-selectedPlaceOfDeliverys"
    );
  }
  // getselectedDemandAuthority(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/demand-authority/get-selectedDemandAuthority')
  // }
  getselectedConditionOfItem() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/condition-of-item/get-selectedConditionOfItem"
    );
  }
  getselectedProcurementStatuses() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/procurement-status/get-selectedProcurementStatuses"
    );
  }
  getselectedDepartmentNames() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/department-name/get-selectedDepartmentNames"
    );
  }
  // getselectedProcurementStatuses(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/procurement-status/get-selectedProcurementStatuses')
  // }
  getselectedItemInspections() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/item-inspection/get-selectedItemInspections"
    );
  }
  getAcceptanceListByDepartmentNameId(
    pageNumber,
    pageSize,
    searchText,
    sparesCategoryId,
    departmentId
  ) {
    let params = new HttpParams();

    params = params.append("searchText", searchText.toString());
    params = params.append("pageNumber", pageNumber.toString());
    params = params.append("pageSize", pageSize.toString());
    params = params.append("sparesCategoryId", sparesCategoryId.toString());
    params = params.append("departmentNameId", departmentId.toString());

    return this.http
      .get<IAcceptancePagination>(
        this.baseUrl + "/acceptance/get-AcceptanceListByDepartmentNameId",
        { observe: "response", params }
      )
      .pipe(
        map((response) => {
          this.Acceptances = [...this.Acceptances, ...response.body.items];
          this.AcceptancePagination = response.body;
          return this.AcceptancePagination;
        })
      );
  }

  find(id: number) {
    return this.http.get<Acceptance>(
      this.baseUrl + "/acceptance/get-acceptanceDetail/" + id
    );
  }
  update(id: number, model: any) {
    return this.http.put(
      this.baseUrl + "/acceptance/update-acceptance/" + id,
      model
    );
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + "/acceptance/save-acceptance", model);
  }
  delete(id: number) {
    return this.http.delete(
      this.baseUrl + "/acceptance/delete-acceptance/" + id
    );
  }
}


// import { Injectable } from '@angular/core';
// import { HttpClient, HttpParams } from '@angular/common/http';
// import { environment } from 'src/environments/environment';
// import {IAcceptancePagination, AcceptancePagination } from '../models/AcceptancePagination'
// import { Acceptance } from '../models/Acceptance';
// import { map } from 'rxjs';
// import { SelectedModel } from 'src/app/core/models/selectedModel';
// @Injectable({
//   providedIn: 'root'
// })
// export class AcceptanceService {
//   baseUrl = environment.apiUrl;
//   Acceptances: Acceptance[] = [];
//   AcceptancePagination = new AcceptancePagination();
//   constructor(private http: HttpClient) { }

//   getAcceptances(pageNumber, pageSize, searchText,sparesCategoryId) {
//     let params = new HttpParams();

//     params = params.append('searchText', searchText.toString());
//     params = params.append('pageNumber', pageNumber.toString());
//     params = params.append('pageSize', pageSize.toString());
//     params = params.append('sparesCategoryId', sparesCategoryId.toString());
    
//     return this.http.get<IAcceptancePagination>(this.baseUrl + '/acceptance/get-acceptances', { observe: 'response', params })
//     .pipe(
//       map(response => {
//         this.Acceptances = [...this.Acceptances, ...response.body.items];
//         this.AcceptancePagination = response.body;
//         return this.AcceptancePagination;
//       })
//     );
   
//   }

//   getselectedItemDetails(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/item-detail/get-selectedItemDetails')
//   }
//   getselectedSourceOfSupplys(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/source-of-supply/get-selectedSourceOfSupplys')
//   }
//   getselectedManufactures(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/manufacture/get-selectedManufactures')
//   }
//   getselectedPrincipalNames(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/principal-name/get-selectedPrincipalNames')
//   }
//   getselectedPlaceOfDeliverys(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/place-of-delivery/get-selectedPlaceOfDeliverys')
//   }
//   // getselectedDemandAuthority(){
//   //   return this.http.get<SelectedModel[]>(this.baseUrl + '/demand-authority/get-selectedDemandAuthority')
//   // }
//   getselectedProcurementsOnUpdate(procurementId, spearCategoryId){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/procurement/get-partnoFromProcurementForUpdateByDepartmentNameId?departmentNameId='+procurementId+'&sparesCategoryId='+spearCategoryId)
//   }
//   getselectedProcurements(procurementId, spearCategoryId){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/procurement/get-partnoFromProcurementByDepartmentNameId?departmentNameId='+procurementId+'&sparesCategoryId='+spearCategoryId)
//   }
//   getSelectedSchoolName(baseNameId){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
//   }
//   getselectedConditionOfItem(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/condition-of-item/get-selectedConditionOfItem')
//   }
//   getselectedProcurementStatuses(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/procurement-status/get-selectedProcurementStatuses')
//   }
//   getselectedDepartmentNames(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
//   }
//   getselectedItemInspections(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/item-inspection/get-selectedItemInspections')
//   }
//   getAcceptanceListByDepartmentNameId(pageNumber, pageSize, searchText,sparesCategoryId,departmentId) { 

//     let params = new HttpParams();

//     params = params.append('searchText', searchText.toString());
//     params = params.append('pageNumber', pageNumber.toString());
//     params = params.append('pageSize', pageSize.toString());
//     params = params.append('sparesCategoryId', sparesCategoryId.toString());
//     params = params.append('departmentNameId', departmentId.toString());
    
//     return this.http.get<IAcceptancePagination>(this.baseUrl + '/acceptance/get-AcceptanceListForToolsByDepartmentNameId', { observe: 'response', params })
//     .pipe(
//       map(response => {
//         this.Acceptances = [...this.Acceptances, ...response.body.items];
//         this.AcceptancePagination = response.body;
//         return this.AcceptancePagination;
//       })
//     );
   
//   }

//   find(id: number) {
//     return this.http.get<Acceptance>(this.baseUrl + '/acceptance/get-acceptanceDetail/' + id);
//   }
//   update(id: number,model: any) {
//     return this.http.put(this.baseUrl + '/acceptance/update-acceptance/'+id, model);
//   }
//   submit(model: any) {
//     return this.http.post(this.baseUrl + '/acceptance/save-acceptance', model);
//   } 
//   delete(id:number){
//     return this.http.delete(this.baseUrl + '/acceptance/delete-acceptance/'+id);
//   }

// }
