import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IStockTransferNsdPagination, StockTransferNsdPagination } from '../models/StockTransferNsdPagination'
import { StockTransferNsd } from '../models/StockTransferNsd';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class StockTransferNsdService {
  baseUrl = environment.apiUrl;
  StockTransferNsds: StockTransferNsd[] = [];
  StockTransferNsdPagination = new StockTransferNsdPagination();
  constructor(private http: HttpClient) { }


  getStockTransferNsds(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IStockTransferNsdPagination>(this.baseUrl + '/stock-transfer-nsd/get-StockTransferNsds', { observe: 'response', params })
    .pipe(
      map(response => {
        this.StockTransferNsds = [...this.StockTransferNsds, ...response.body.items];
        this.StockTransferNsdPagination = response.body;
        return this.StockTransferNsdPagination;
      })
    );
   
  }
  // findRequirdSparesList( departmentId:number,sparesCategoryId:number,maintenanceTypeId:number,maintenanceCategoryId:number,maintenanceSubCategoryId:number){
  //   return this.http.get<StockTransferNsd[]>(this.baseUrl + '/required-spares-for-maintenance/get-presentStocksForMaintenance?departmentId='+departmentId+'&sparesCategoryId='+sparesCategoryId+'&maintenanceTypeId='+maintenanceTypeId+'&maintenanceCategoryId='+maintenanceCategoryId+'&maintenanceSubCategoryId='+maintenanceSubCategoryId);
  // }

  // getSelectedPartNoByNameForSpares(partNo) {
  //   return this.http
  //     .get<SelectedModel[]>(
  //       this.baseUrl +
  //         "/item-detail/get-autocompletePartNoByNameForSpares?partNo=" +
  //         partNo +
  //         ""
  //     )
  //     .pipe(map((response: []) => response.map((item) => item)));
  // }
  approvedStockTransferNsd(id: number) {
    return this.http.get<StockTransferNsd>(this.baseUrl + '/stock-transfer-nsd/approved-StockTransferNsd/' + id);
  }
  getStockTransferNsdListByDepartmentName( departmentNameId,status){
    return this.http.get<StockTransferNsd[]>(this.baseUrl + '/stock-transfer-nsd/get-stockTransferNsdListByDepartmentNameId?departmentNameId='+departmentNameId+'&status='+status);
   }
  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  getSelectedItemDetail(departmentNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/item-stor/get-itemDetailForStockTransferNsdByDepartmentNameId?departmentNameId='+departmentNameId)
  }
  ChangeStockStatus(id,status){
    return this.http.get<any[]>(this.baseUrl + '/stock-transfer-nsd/change-stockTransferNsdStatus?stockTransferNsdId='+id+'&status='+status)
  }
  getselectedDemandAuthority(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/demand-authority/get-selectedDemandAuthority')
  }
  getNsdQtyById(id: number) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/item-stor/get-NsdQtyByIdRequest?itemStorId="+id);
  }
  find(id: number) {
    return this.http.get<StockTransferNsd>(this.baseUrl + '/stock-transfer-nsd/get-StockTransferNsdDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/stock-transfer-nsd/update-StockTransferNsd/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/stock-transfer-nsd/save-StockTransferNsd', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/stock-transfer-nsd/delete-StockTransferNsd/'+id);
  }

}
