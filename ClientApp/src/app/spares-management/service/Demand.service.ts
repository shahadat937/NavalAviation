import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { environment } from "src/environments/environment";
import {
  IDemandPagination,
  DemandPagination,
} from "../models/IDemandPagination";
import { Demand } from "../models/Demand";
import { map } from "rxjs";
import { SelectedModel } from "../../core/models/selectedModel";
@Injectable({
  providedIn: "root",
})
export class DemandService {
  baseUrl = environment.apiUrl;
  Demands: Demand[] = [];
  DemandPagination = new DemandPagination();
  constructor(private http: HttpClient) {}

  getDemands(pageNumber, pageSize, searchText, sparesCategoryId) {
    let params = new HttpParams();

    params = params.append("searchText", searchText.toString());
    params = params.append("pageNumber", pageNumber.toString());
    params = params.append("pageSize", pageSize.toString());
    params = params.append("sparesCategoryId", sparesCategoryId.toString());

    return this.http
      .get<IDemandPagination>(this.baseUrl + "/demand/get-demands", {
        observe: "response",
        params,
      })
      .pipe(
        map((response) => {
          this.Demands = [...this.Demands, ...response.body.items];
          this.DemandPagination = response.body;
          return this.DemandPagination;
        })
      );
    //
  }
  getDemandSpGetCompleteStatus(id) {
    return this.http.get<any>(
      this.baseUrl + "/demand/get-SpGetCompleteStatus?departmentId=" + id
    );
  }

  //autocomplete for Course item-detail/get-autocompletePartNoByNameForSpares?partNo=Spar123'
  getSelectedCourseByName(courseName) {
    return this.http
      .get<SelectedModel[]>(
        this.baseUrl +
          "/demand/get-autocompletePartNoByName?partNo=" +
          courseName
      )
      .pipe(map((response: []) => response.map((item) => item)));
  }

  //autocomplete for By PartNo
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

  getSelectedPartNoForSpareParameterRequest(partNo,departmentId,spareCategoryId) {
    return this.http
      .get<SelectedModel[]>(
        this.baseUrl +"/item-detail/get-autocompletePartNoForParameterRequest?partNo="+partNo+"&departmentNameId="+departmentId+"&spareCategoryId="+spareCategoryId+"")
      .pipe(map((response: []) => response.map((item) => item)));
  }

  getSelectedAuthority() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/authority/get-selectedAuthoritys"
    );
  }

  getSelectedItemDetails() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/item-detail/get-selectedItemDetails"
    );
  }
  getSelectedTypeOfDemand() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/demand-type/get-selectedDemandTypes"
    );
  }
  getSelectedDeno() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/deno/get-selectedDeno"
    );
  }
  getSelectedDemandStatus() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/demand-status/get-selectedDemandStatuses"
    );
  }
  getSelectedTrade() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/trade/get-selectedTrades"
    );
  }

  getSelectedManufacture() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/manufacture/get-selectedManufactures"
    );
  }
  getSelectedSuplier() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/suppliers/get-selectedSupplier"
    );
  }
  getDemandListByDepartmentNameId(
    pageNumber,
    pageSize,
    searchText,
    sparesCategoryId,
    departmentId,
    demandTypeId
  ) {
    let params = new HttpParams();

    params = params.append("searchText", searchText.toString());
    params = params.append("pageNumber", pageNumber.toString());
    params = params.append("pageSize", pageSize.toString());
    params = params.append("sparesCategoryId", sparesCategoryId.toString());
    params = params.append("departmentNameId", departmentId.toString());
    params = params.append("demandTypeId", demandTypeId.toString());

    return this.http
      .get<IDemandPagination>(
        this.baseUrl + "/demand/get-DemandListForSparesByDepartmentNameId",
        { observe: "response", params }
      )
      .pipe(
        map((response) => {
          this.Demands = [...this.Demands, ...response.body.items];
          this.DemandPagination = response.body;
          return this.DemandPagination;
        })
      );
    //
  }
  // getaDemandListByDepartmentNameId( departmentNameId:number){
  //   return this.http.get<Demand[]>(this.baseUrl + '/demand/get-DemandListByDepartmentNameId?departmentNameId='+departmentNameId);
  //  }
  getPartNoPassItemCategoryIdInDemand(itemDetailId: number) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/demand/get-PartNoPassItemCategoryIdInDemand?itemDetailId=" +
        itemDetailId
    );
  }
  approvedDemand(id: number) {
    return this.http.get<Demand>(this.baseUrl + '/demand/approved-Demand/' + id);
  }
  getSelectedFiscalYear() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/fiscal-year/get-selectedFiscalYear"
    );
  }
  getSelectedItemType() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/item-type/get-selectedItemType"
    );
  }
  getSelectedOccasionOfDemand() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/occasion-of-demand/get-selectedOccasionOfDemands"
    );
  }
  getSelectedDemandAuthority() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/demand-authority/get-selectedDemandAuthority"
    );
  }

  getSelectedDepartmentName() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/department-name/get-selectedDepartmentNames"
    );
  }
  getSelectedSchoolName(baseNameId) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/base-School-name/get-selectedSchoolNames?thirdLevel=" +
        baseNameId
    );
  }
  getSelectedItemCategory(spareCategoryId) {
    return this.http.get<SelectedModel[]>(this.baseUrl + "/item-category/get-selectedItemCategory?spareCategoryId="+spareCategoryId);
  }
  getSelectedConditionOfItem() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/condition-of-item/get-selectedConditionOfItem"
    );
  }

  GetselectedDemandById(demandId) {
    return this.http.get<Demand[]>(
      this.baseUrl + "/demand/get-selectedDemandById?demandId=" + demandId
    );
  }

  find(id: number) {
    return this.http.get<Demand>(
      this.baseUrl + "/demand/get-demandDetail/" + id
    );
  }

  update(id: number, model: any) {
    return this.http.put(this.baseUrl + "/demand/update-demand/" + id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + "/demand/save-demand", model);
  }
  delete(id: number) {
    return this.http.delete(this.baseUrl + "/demand/delete-demand/" + id);
  }
}
