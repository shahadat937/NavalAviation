import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { IItemStorPagination, ItemStorPagination } from "../../spares-management/models/ItemStorPagination";
import { ItemStor } from "../../spares-management/models/ItemStor";
import { map } from "rxjs";
import { SelectedModel } from "src/app/core/models/selectedModel";

@Injectable({
  providedIn: "root",
})
export class ItemStorService {
  baseUrl = environment.apiUrl;
  ItemStors: ItemStor[] = [];
  ItemStorPagination = new ItemStorPagination();
  constructor(private http: HttpClient) {}

  
  findResult(itemDetailId) {
    return this.http.get<any>(this.baseUrl + '/item-stor/get-barcodeResult?itemDetailId=' + itemDetailId);
  }

  getSelectedSchoolName(baseNameId) {
    return this.http.get<SelectedModel[]>( this.baseUrl + "/base-School-name/get-selectedSchoolNames?thirdLevel=" + baseNameId);
  }
  
  getSelectedSparesCategory() {
    return this.http.get<SelectedModel[]>( this.baseUrl + "/spares-category/get-selectedSparesCategory");
  }

  getBarcodePrintList(pageNumber,pageSize,searchText,departmentId,sparesCategoryId) {
    let params = new HttpParams();

    params = params.append("searchText", searchText.toString());
    params = params.append("pageNumber", pageNumber.toString());
    params = params.append("pageSize", pageSize.toString());
    params = params.append("departmentNameId", departmentId.toString());
    params = params.append("sparesCategoryId", sparesCategoryId.toString());

    return this.http.get<ItemStorPagination>(this.baseUrl + "/item-stor/get-barcodePrintList",{ observe: "response", params }).pipe(map((response) => {
      this.ItemStors = [...this.ItemStors, ...response.body.items];
      this.ItemStorPagination = response.body;
      return this.ItemStorPagination;
    }));
  }  
}
