import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { environment } from "src/environments/environment";
import {
  IItemStorPagination,
  ItemStorPagination,
} from "../models/IItemStorePagination";
import { ItemStor } from "../models/ItemStor";
import { map } from "rxjs";
import { SelectedModel } from "src/app/core/models/selectedModel";
import { Acceptance } from "../models/Acceptance";
@Injectable({
  providedIn: "root",
})
export class ItemStorService {
  baseUrl = environment.apiUrl;
  ItemStors: ItemStor[] = [];
  ItemStorPagination = new ItemStorPagination();
  constructor(private http: HttpClient) {}

  getItemStors(pageNumber, pageSize, searchText, itemCategoryId) {
    let params = new HttpParams();

    params = params.append("searchText", searchText.toString());
    params = params.append("pageNumber", pageNumber.toString());
    params = params.append("pageSize", pageSize.toString());
    params = params.append("itemCategoryId", itemCategoryId.toString());

    return this.http
      .get<IItemStorPagination>(this.baseUrl + "/item-stor/get-ItemStors", {
        observe: "response",
        params,
      })
      .pipe(
        map((response) => {
          this.ItemStors = [...this.ItemStors, ...response.body.items];
          this.ItemStorPagination = response.body;
          return this.ItemStorPagination;
        })
      );
  }
  getItemStorsList(
    pageNumber,
    pageSize,
    searchText,
    departmentId,
    sparesCategoryId,
    status
  ) {
    let params = new HttpParams();

    params = params.append("searchText", searchText.toString());
    params = params.append("pageNumber", pageNumber.toString());
    params = params.append("pageSize", pageSize.toString());
    params = params.append("departmentNameId", departmentId.toString());
    params = params.append("sparesCategoryId", sparesCategoryId.toString());
    params = params.append("status", status.toString());

    return this.http
      .get<IItemStorPagination>(
        this.baseUrl + "/item-stor/get-ItemStorListByDepartmentNameId",
        { observe: "response", params }
      )
      .pipe(
        map((response) => {
          this.ItemStors = [...this.ItemStors, ...response.body.items];
          this.ItemStorPagination = response.body;
          return this.ItemStorPagination;
        })
      );
  }
  approvedItemStor(id: number) {
    return this.http.get<ItemStor>(this.baseUrl + '/item-stor/approved-ItemStore/' + id);
  }
  getSelectedItemCategory(spareCategoryId) {
    return this.http.get<SelectedModel[]>(this.baseUrl + "/item-category/get-selectedItemCategory?spareCategoryId="+spareCategoryId);
  }
  getselectedProcurementStatuses() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/procurement-status/get-selectedProcurementStatuses"
    );
  }
  getSelectedSchoolName(baseNameId) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/base-School-name/get-selectedSchoolNames?thirdLevel=" +
        baseNameId
    );
  }
  getselectedDepartmentNames() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/department-name/get-selectedDepartmentNames"
    );
  }
  getselectedDeno() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/deno/get-selectedDeno"
    );
  }
  getselectedSparesCategory() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/spares-category/get-selectedSparesCategory"
    );
  }
  getselectedConditionOfItem() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/condition-of-item/get-selectedConditionOfItem"
    );
  }
  getselectedToolsLocations() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/tools-location/get-selectedToolsLocations"
    );
  }
  getselectedLifeLimitItem() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/life-limit-tem/get-selectedLifeLimitItems"
    );
  }
  getselectedAcctStore() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/acct-store/get-selectedAcctStore"
    );
  }
  getselectedServiceLifeType() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/service-life-type/get-selectedServiceLifeType"
    );
  }

  getselectedEndLifeType() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/endlife-type/get-selectedEndLifeType"
    );
  }
  getselectedOverhaulingTypes() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/overhauling-type/get-selectedOverhaulingTypes"
    );
  }

  partnoFromAcceptanceByDepartmentName(departmentNameId, sparesCategoryId) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/acceptance/get-partnoFromAcceptanceByDepartmentNameId?departmentNameId=" +
        departmentNameId +
        "&sparesCategoryId=" +
        sparesCategoryId
    );
  }

  partnoFromAcceptanceForUpdateByDepartmentName(
    departmentNameId,
    sparesCategoryId
  ) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/acceptance/get-partnoFromAcceptanceForUpdateByDepartmentNameId?departmentNameId=" +
        departmentNameId +
        "&sparesCategoryId=" +
        sparesCategoryId
    );
  }

  getacceptanceById(acceptanceId) {
    return this.http.get<Acceptance[]>(
      this.baseUrl +
        "/acceptance/get-acceptanceById?acceptanceId=" +
        acceptanceId
    );
  }

  find(id: number) {
    return this.http.get<ItemStor>(
      this.baseUrl + "/item-stor/get-ItemStorDetail/" + id
    );
  }
  update(id: number, model: any) {
    return this.http.put(
      this.baseUrl + "/item-stor/update-ItemStor/" + id,
      model
    );
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + "/item-stor/save-ItemStor", model);
  }
  delete(id: number) {
    return this.http.delete(this.baseUrl + "/item-stor/delete-ItemStor/" + id);
  }
}

// import { Injectable } from '@angular/core';
// import { HttpClient, HttpParams } from '@angular/common/http';
// import { environment } from 'src/environments/environment';
// import {IItemStorPagination, ItemStorPagination } from '../models/IItemStorePagination'
// import { ItemStor } from '../models/ItemStor';
// import { map } from 'rxjs';
// import { SelectedModel } from 'src/app/core/models/selectedModel';
// import { Acceptance } from '../models/Acceptance';
// @Injectable({
//   providedIn: 'root'
// })
// export class ItemStorService {
//   baseUrl = environment.apiUrl;
//   ItemStors: ItemStor[] = [];
//   ItemStorPagination = new ItemStorPagination();
//   constructor(private http: HttpClient) { }

//   getItemStors(pageNumber, pageSize, searchText, itemCategoryId) {

//     let params = new HttpParams();

//     params = params.append('searchText', searchText.toString());
//     params = params.append('pageNumber', pageNumber.toString());
//     params = params.append('pageSize', pageSize.toString());
//     params = params.append('itemCategoryId', itemCategoryId.toString());

//     return this.http.get<IItemStorPagination>(this.baseUrl + '/item-stor/get-ItemStorListForToolsByDepartmentNameId', { observe: 'response', params })
//     .pipe(
//       map(response => {
//         this.ItemStors = [...this.ItemStors, ...response.body.items];
//         this.ItemStorPagination = response.body;
//         return this.ItemStorPagination;
//       })
//     );
//   }

//   getItemStorsByParameter(pageNumber, pageSize, searchText,departmentNameId, sparesCategoryId) {

//     let params = new HttpParams();

//     params = params.append('searchText', searchText.toString());
//     params = params.append('pageNumber', pageNumber.toString());
//     params = params.append('pageSize', pageSize.toString());
//     params = params.append('departmentNameId', departmentNameId.toString());
//     params = params.append('sparesCategoryId', sparesCategoryId.toString());

//     return this.http.get<IItemStorPagination>(this.baseUrl + '/item-stor/get-itemStorListByParameterRequest', { observe: 'response', params })
//     .pipe(
//       map(response => {
//         this.ItemStors = [...this.ItemStors, ...response.body.items];
//         this.ItemStorPagination = response.body;
//         return this.ItemStorPagination;
//       })
//     );
//   }

//   getselectedItemCategory(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/item-category/get-selectedItemCategory')
//   }
//   getSelectedSchoolName(baseNameId){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
//   }
//   getselectedDepartmentNames(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
//   }
//   getselectedDeno(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/deno/get-selectedDeno')
//   }
//   getselectedSparesCategory(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/spares-category/get-selectedSparesCategoryForTools')
//   }
//   getselectedConditionOfItem(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/condition-of-item/get-selectedConditionOfItem')
//   }
//   getselectedLifeLimitItem(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/life-limit-tem/get-selectedLifeLimitItems')
//   }
//   getselectedAcctStore(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/acct-store/get-selectedAcctStore')
//   }
//   getselectedServiceLifeType(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/service-life-type/get-selectedServiceLifeType')
//   }

//   getselectedEndLifeType(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/endlife-type/get-selectedEndLifeType')
//   }
//   getselectedOverhaulingTypes(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/overhauling-type/get-selectedOverhaulingTypes')
//   }

//   partnoFromAcceptanceByDepartmentName(departmentNameId,sparesCategoryId) {
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/acceptance/get-partnoFromAcceptanceByDepartmentNameId?departmentNameId='+departmentNameId+'&sparesCategoryId='+sparesCategoryId);
//   }

//   partnoFromAcceptanceForUpdateByDepartmentName(departmentNameId,sparesCategoryId) {
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/acceptance/get-partnoFromAcceptanceForUpdateByDepartmentNameId?departmentNameId='+departmentNameId+'&sparesCategoryId='+sparesCategoryId);
//   }
//   getselectedToolsType(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/tools-type/get-selectedToolsType');
//   }

//   getselectedLocation(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/tools-location/get-selectedToolsLocations');
//   }

//   getselectedToolsBoxName() {
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/toolsbox-name/get-selectedToolsBoxNames');
//   }

//   getacceptanceById(acceptanceId) {
//     return this.http.get<Acceptance[]>(this.baseUrl + '/acceptance/get-acceptanceById?acceptanceId='+acceptanceId);
//   }

//   find(id: number) {
//     return this.http.get<ItemStor>(this.baseUrl + '/item-stor/get-ItemStorDetail/' + id);
//   }
//   update(id: number,model: any) {
//     return this.http.put(this.baseUrl + '/item-stor/update-ItemStor/'+id, model);
//   }
//   submit(model: any) {
//     return this.http.post(this.baseUrl + '/item-stor/save-ItemStor', model);
//   }
//   delete(id:number){
//     return this.http.delete(this.baseUrl + '/item-stor/delete-ItemStor/'+id);
//   }

// }
