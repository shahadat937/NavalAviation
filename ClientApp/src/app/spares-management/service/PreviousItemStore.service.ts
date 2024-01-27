import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { environment } from "src/environments/environment";
import {
  IPreviousItemStorePagination,
  PreviousItemStorePagination,
} from "../models/PreviousItemStorePagination";
import { PreviousItemStore } from "../models/PreviousItemStore";
import { map } from "rxjs";
import { SelectedModel } from "src/app/core/models/selectedModel";
@Injectable({
  providedIn: "root",
})
export class PreviousItemStoreService {
  baseUrl = environment.apiUrl;
  PreviousItemStores: PreviousItemStore[] = [];
  PreviousItemStorePagination = new PreviousItemStorePagination();
  constructor(private http: HttpClient) {}

  getPreviousItemStores(pageNumber, pageSize, searchText) {
    let params = new HttpParams();

    params = params.append("searchText", searchText.toString());
    params = params.append("pageNumber", pageNumber.toString());
    params = params.append("pageSize", pageSize.toString());
    return this.http
      .get<IPreviousItemStorePagination>(
        this.baseUrl + "/previous-item-store/get-PreviousItemStores",
        { observe: "response", params }
      )
      .pipe(
        map((response) => {
          this.PreviousItemStores = [
            ...this.PreviousItemStores,
            ...response.body.items,
          ];
          this.PreviousItemStorePagination = response.body;
          return this.PreviousItemStorePagination;
        })
      );
  }
  getPreviousItemStoreListByDepartmentId(departmentNameId) {
    return this.http.get<PreviousItemStore[]>(
      this.baseUrl +
        "/previous-item-store/get-selectedPreviousItemStoreListByDepartmentId?departmentNameId=" +
        departmentNameId
    );
  }
  getselectedItemDetails(departmentNameId, sparesCategoryId) {
    return this.http.get<SelectedModel[]>(this.baseUrl + "/item-detail/get-selectedItemDetails?departmentNameId="+departmentNameId+"&sparesCategoryId="+sparesCategoryId);
  }
  getSelectedPartNoForSpareParameterRequest(partNo,departmentId,spareCategoryId) {
    return this.http
      .get<SelectedModel[]>(
        this.baseUrl +"/item-detail/get-autocompletePartNoForParameterRequest?partNo="+partNo+"&departmentNameId="+departmentId+"&spareCategoryId="+spareCategoryId+"")
      .pipe(map((response: []) => response.map((item) => item)));
  }
 
  getselectedLifeLimitItem() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/life-limit-tem/get-selectedLifeLimitItems"
    );
  }
  getselectedToolsType() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/tools-type/get-selectedToolsType"
    );
  }
  getselectedToolsBoxNames() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/toolsbox-name/get-selectedToolsBoxNames"
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
  getselectedDeno() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/deno/get-selectedDeno"
    );
  }
  getselectedDepartmentNames() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/department-name/get-selectedDepartmentNames"
    );
  }
  
  getSelectedItemCategory(spareCategoryId) {
    return this.http.get<SelectedModel[]>(this.baseUrl + "/item-category/get-selectedItemCategory?spareCategoryId="+spareCategoryId);
  }
  getSelectedSchoolName(baseNameId) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/base-School-name/get-selectedSchoolNames?thirdLevel=" +
        baseNameId
    );
  }
  getselectedSparesCategory() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/spares-category/get-selectedSparesCategory"
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
  getselectedAcctStore() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/acct-store/get-selectedAcctStore"
    );
  }
  getselectedOverhaulingTypes() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/overhauling-type/get-selectedOverhaulingTypes"
    );
  }
  getselectedRetirementTypes() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/retirement-type/get-selectedRetirementTypes"
    );
  }

  find(id: number) {
    return this.http.get<PreviousItemStore>(
      this.baseUrl + "/previous-item-store/get-PreviousItemStoreDetail/" + id
    );
  }
  update(id: number, model: any) {
    return this.http.put(
      this.baseUrl + "/previous-item-store/update-PreviousItemStore/" + id,
      model
    );
  }
  submit(model: any) {
    return this.http.post(
      this.baseUrl + "/previous-item-store/save-PreviousItemStore",
      model
    );
  }
  delete(id: number) {
    return this.http.delete(
      this.baseUrl + "/previous-item-store/delete-PreviousItemStore/" + id
    );
  }
}
