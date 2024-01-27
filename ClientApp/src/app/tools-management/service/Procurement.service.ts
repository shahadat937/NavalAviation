import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IProcurementPagination, ProcurementPagination } from '../models/ProcurementPagination'
import { Procurement } from '../models/Procurement';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class ProcurementService {
  baseUrl = environment.apiUrl;
  Procurements: Procurement[] = [];
  ProcurementPagination = new ProcurementPagination();
  constructor(private http: HttpClient) { }

  getProcurements(pageNumber, pageSize, searchText,sparesCategoryId) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('sparesCategoryId', sparesCategoryId.toString());
    
    return this.http.get<IProcurementPagination>(this.baseUrl + '/procurement/get-procurements', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Procurements = [...this.Procurements, ...response.body.items];
        this.ProcurementPagination = response.body;
        return this.ProcurementPagination;
      })
    );
   
  }
  approvedProcurement(id: number) {
    return this.http.get<Procurement>(this.baseUrl + '/procurement/approved-Procurement/' + id);
  }
  getProcurementSpGetPrCompleteStatus(){
    return this.http.get<any>(this.baseUrl + '/procurement/get-SpGetPrCompleteStatus')
  }
  getPartNoPassItemCategoryIdInProcurement(itemDetailId:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/procurement/get-PartNoPassItemCategoryIdInProcurement?itemDetailId=' + itemDetailId);
  }
  getselectedItemDetails(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/item-detail/get-selectedItemDetails')
  }
  getselectedPrincipalNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/principal-name/get-selectedPrincipalNames')
  }
  getselectedManufacture(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/manufacture/get-selectedManufactures')
  }
  getselectedProcurementStatus(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/procurement-status/get-selectedProcurementStatuss')
  }
  // getselectedLocalAgents(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/local-agent/get-selectedLocalAgents')
  // }
  getselectedSupplier(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/suppliers/get-selectedSupplier')
  }
  getselectedSupplierA(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/suppliers/get-selectedSupplier')
  }
  getselectedSupplierM(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/suppliers/get-selectedSupplier')
  }
  getselectedPartOfShipments(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/part-of-shipment/get-selectedPartOfShipments')
  }

  GetselectedProcurementById(procurementId){
    return this.http.get<Procurement[]>(this.baseUrl + '/procurement/get-selectedProcurementById?procurementId='+procurementId);
  }

  getselectedDemands(departmentId,spearCategoryId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/demand/get-partnoFromDemandByDepartmentNameId?departmentNameId='+departmentId+'&sparesCategoryId='+spearCategoryId)
  }

  getselectedDemandsOnUpdate(departmentId,spearCategoryId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/demand/get-partnoFromDemandForUpdateByDepartmentNameId?departmentNameId='+departmentId+'&sparesCategoryId='+spearCategoryId)
  }

  getselectedCstTecs(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/cst-tec/get-selectedCstTec')
  }
  getProcurementListByDepartmentNameId(pageNumber, pageSize, searchText,sparesCategoryId,departmentId) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('sparesCategoryId', sparesCategoryId.toString());
    params = params.append('departmentNameId', departmentId.toString());
    
    return this.http.get<IProcurementPagination>(this.baseUrl + '/procurement/get-ProcurementListByDepartmentNameId', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Procurements = [...this.Procurements, ...response.body.items];
        this.ProcurementPagination = response.body;
        return this.ProcurementPagination;
      })
    );
   // 
  }

  find(id: number) {
    return this.http.get<Procurement>(this.baseUrl + '/procurement/get-procurementDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/procurement/update-procurement/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/procurement/save-procurement', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/procurement/delete-procurement/'+id);
  }

}


// import { Injectable } from '@angular/core';
// import { HttpClient, HttpParams } from '@angular/common/http';
// import { environment } from 'src/environments/environment';
// import {IProcurementPagination, ProcurementPagination } from '../models/ProcurementPagination'
// import { Procurement } from '../models/Procurement';
// import { map } from 'rxjs';
// import { SelectedModel } from 'src/app/core/models/selectedModel';
// @Injectable({
//   providedIn: 'root'
// })
// export class ProcurementService {
//   baseUrl = environment.apiUrl;
//   Procurements: Procurement[] = [];
//   ProcurementPagination = new ProcurementPagination();
//   constructor(private http: HttpClient) { }

//   getProcurements(pageNumber, pageSize, searchText,sparesCategoryId) {

//     let params = new HttpParams();

//     params = params.append('searchText', searchText.toString());
//     params = params.append('pageNumber', pageNumber.toString());
//     params = params.append('pageSize', pageSize.toString());
//     params = params.append('sparesCategoryId', sparesCategoryId.toString());
    
//     return this.http.get<IProcurementPagination>(this.baseUrl + '/procurement/get-procurements', { observe: 'response', params })
//     .pipe(
//       map(response => {
//         this.Procurements = [...this.Procurements, ...response.body.items];
//         this.ProcurementPagination = response.body;
//         return this.ProcurementPagination;
//       })
//     );
   
//   }

//   getselectedItemDetails(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/item-detail/get-selectedItemDetails')
//   }
//   getselectedPrincipalNames(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/principal-name/get-selectedPrincipalNames')
//   }
//   getselectedManufacture(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/manufacture/get-selectedManufactures')
//   }
//   getselectedProcurementStatus(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/procurement-status/get-selectedProcurementStatuss')
//   }
//   // getselectedLocalAgents(){
//   //   return this.http.get<SelectedModel[]>(this.baseUrl + '/local-agent/get-selectedLocalAgents')
//   // }
//   getselectedSupplier(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/suppliers/get-selectedSupplier')
//   }
//   getselectedSupplierA(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/suppliers/get-selectedSupplier')
//   }
//   getselectedSupplierM(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/suppliers/get-selectedSupplier')
//   }
//   getselectedPartOfShipments(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/part-of-shipment/get-selectedPartOfShipments')
//   }

//   getselectedDemands(departmentId,spearCategoryId){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/demand/get-partnoFromDemandByDepartmentNameId?departmentNameId='+departmentId+'&sparesCategoryId='+spearCategoryId)
//   }

//   getselectedDemandsOnUpdate(departmentId,spearCategoryId){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/demand/get-partnoFromDemandForUpdateByDepartmentNameId?departmentNameId='+departmentId+'&sparesCategoryId='+spearCategoryId)
//   }

//   getselectedCstTecs(){
//     return this.http.get<SelectedModel[]>(this.baseUrl + '/cst-tec/get-selectedCstTec')
//   }
  
//   GetselectedProcurementById(procurementId){
//     return this.http.get<Procurement[]>(this.baseUrl + '/procurement/get-selectedProcurementById?procurementId='+procurementId);
//   }
//   getProcurementListByDepartmentNameId(pageNumber, pageSize, searchText,sparesCategoryId,departmentId) { 

//     let params = new HttpParams();

//     params = params.append('searchText', searchText.toString());
//     params = params.append('pageNumber', pageNumber.toString());
//     params = params.append('pageSize', pageSize.toString());
//     params = params.append('sparesCategoryId', sparesCategoryId.toString());
//     params = params.append('departmentNameId', departmentId.toString());
    
//     return this.http.get<IProcurementPagination>(this.baseUrl + '/procurement/get-ProcurementListForToolsByDepartmentNameId', { observe: 'response', params })
//     .pipe(
//       map(response => {
//         this.Procurements = [...this.Procurements, ...response.body.items];
//         this.ProcurementPagination = response.body;
//         return this.ProcurementPagination;
//       })
//     );
//    // 
//   }
  
//   find(id: number) {
//     return this.http.get<Procurement>(this.baseUrl + '/procurement/get-procurementDetail/' + id);
//   }
//   update(id: number,model: any) {
//     return this.http.put(this.baseUrl + '/procurement/update-procurement/'+id, model);
//   }
//   submit(model: any) {
//     return this.http.post(this.baseUrl + '/procurement/save-procurement', model);
//   } 
//   delete(id:number){
//     return this.http.delete(this.baseUrl + '/procurement/delete-procurement/'+id);
//   }

// }
