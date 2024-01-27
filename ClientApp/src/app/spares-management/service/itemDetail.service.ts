import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { environment } from "src/environments/environment";
import {
  IItemDetailPagination,
  ItemDetailPagination,
} from "../models/itemDetailPagination";
import { ItemDetail } from "../models/itemDetail";
import { map } from "rxjs";
import { SelectedModel } from "src/app/core/models/selectedModel";
@Injectable({
  providedIn: "root",
})
export class ItemDetailService {
  baseUrl = environment.apiUrl;
  ItemDetails: ItemDetail[] = [];
  ItemDetailPagination = new ItemDetailPagination();
  constructor(private http: HttpClient) {}

  getItemDetails(pageNumber, pageSize, searchText) {
    let params = new HttpParams();

    params = params.append("searchText", searchText.toString());
    params = params.append("pageNumber", pageNumber.toString());
    params = params.append("pageSize", pageSize.toString());

    return this.http
      .get<IItemDetailPagination>(
        this.baseUrl + "/item-detail/get-ItemDetails",
        { observe: "response", params }
      )
      .pipe(
        map((response) => {
          this.ItemDetails = [...this.ItemDetails, ...response.body.items];
          this.ItemDetailPagination = response.body;
          return this.ItemDetailPagination;
        })
      );
  }

  getItemDetailsForTools(pageNumber, pageSize, searchText, sparesCategoryId) {
    let params = new HttpParams();

    params = params.append("searchText", searchText.toString());
    params = params.append("pageNumber", pageNumber.toString());
    params = params.append("pageSize", pageSize.toString());
    params = params.append("sparesCategoryId", sparesCategoryId.toString());
    //item-detail/get-itemDetailsForTools?PageSize=5&PageNumber=1&sparesCategoryId=2
    return this.http
      .get<IItemDetailPagination>(
        this.baseUrl + "/item-detail/get-itemDetailsForTools",
        { observe: "response", params }
      )
      .pipe(
        map((response) => {
          this.ItemDetails = [...this.ItemDetails, ...response.body.items];
          this.ItemDetailPagination = response.body;
          return this.ItemDetailPagination;
        })
      );
  }
  // getselectedEquipmentName(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/equipment-name/get-selectedEquipmentName')
  // }
  getselectedSparesCategory() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/spares-category/get-selectedSparesCategory"
    );
  }

  getItemNameIsExistCheck(nameOfItem){  //item-detail/get-nameOfItemIsExistCheck?nameOfItem=ba
    return this.http.get<boolean>(this.baseUrl + '/item-detail/get-nameOfItemIsExistCheck?nameOfItem='+nameOfItem+'')
  }
  getEquipmentNameBySparesCategoryId(sparesCategoryId: number) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/equipment-name/get-selectedEquipmentNameBySparesCategoryId?sparesCategoryId=" +
        sparesCategoryId
    );
  }

  getselectedItemDetail() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/item-detail/get-selectedItemDetails"
    );
  }
  getselectedItemDetailByDepartmentNameId(departmentNameId) {
    return this.http.get<ItemDetail[]>(
      this.baseUrl +
        "/item-detail/get-ItemDetailByDepartmentId?departmentNameId=" +
        departmentNameId +
        ""
    );
  }
  getselectedItemCategoryTypes() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/item-category-type/get-selectedItemCategoryTypes"
    );
  }
  getselectedItemType() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/item-type/get-selectedItemType"
    );
  }
  getselectedTrades() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/trade/get-selectedTrades"
    );
  }
  getselectedItemNameAndPattNo() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/item-detail/get-selectedItemNameAndPattNo"
    );
  }
  getselectedPresentStocks(departmentId, sparesCategoryId, searchText) {
    return this.http.get<any[]>(
      this.baseUrl +"/item-detail/get-presentStocks?departmentId="+departmentId+"&sparesCategoryId="+sparesCategoryId+"&searchText="+searchText);
  }
  getsearchingByItemDetailId(itemDetailId) {
    return this.http.get<any[]>(
      this.baseUrl +"/item-detail/get-searchingByItemDetailId?itemDetailId="+itemDetailId);
  }
  getSelectedSchoolName(baseNameId) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/base-School-name/get-selectedSchoolNames?thirdLevel=" +
        baseNameId
    );
  }
  approvedItemDetail(id: number) {
    return this.http.get<ItemDetail>(this.baseUrl + '/item-detail/approved-ItemDetail/' + id);
  }
  
  getAvailableIssueQtyDetailList(itemDetailId) {
    return this.http.get<any[]>(this.baseUrl + "/issue-register/get-availableIssueQtyDetailList?itemDetailId=" + itemDetailId);
  }

  getPresentNsdStocksForMaintenance(itemDetailId,toolsLocationId) {
    return this.http.get<any[]>(this.baseUrl + "/required-spares-for-maintenance/get-presentNsdStocksForMaintenance?itemDetailId=" + itemDetailId + "&toolsLocationId=" + toolsLocationId);
  }
  getPartNoByDepartmentNameId(id: number) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/item-detail/get-partnoByDepartmentNameId?departmentNameId=" +
        id
    );
  }
  getPartNoForSparesByDepartmentNameId(departmentNameId,spareCategoryId) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +"/item-detail/get-partnoForSparesByDepartmentNameId?departmentNameId="+departmentNameId+"&spareCategoryId="+spareCategoryId);
  }
  // getPartNoForSparesByDepartmentNameId(id: number) {
  //   return this.http.get<SelectedModel[]>(
  //     this.baseUrl +"/item-detail/get-partnoForSparesByDepartmentNameId?departmentNameId="+id+"");
  // }
  getItemNameById(id: number) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/demand/get-itemNameByIdRequest?itemDetailId=" + id
    );
  }
  find(id: number) {
    return this.http.get<ItemDetail>(
      this.baseUrl + "/item-detail/get-ItemDetailDetail/" + id
    );
  }
  update(id: number, model: any) {
    return this.http.put(
      this.baseUrl + "/item-detail/update-ItemDetail/" + id,
      model
    );
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + "/item-detail/save-ItemDetail", model);
  }
  delete(id: number) {
    return this.http.delete(
      this.baseUrl + "/item-detail/delete-ItemDetail/" + id
    );
  }
}
