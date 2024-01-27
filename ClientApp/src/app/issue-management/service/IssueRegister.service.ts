import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IIssueRegisterPagination, IssueRegisterPagination } from '../models/IssueRegisterPagination'
import { IssueRegister } from '../models/IssueRegister';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { ItemStor } from 'src/app/spares-management/models/ItemStor';
@Injectable({
  providedIn: 'root'
})
export class IssueRegisterService {
  baseUrl = environment.apiUrl;
  IssueRegisters: IssueRegister[] = [];
  IssueRegisterPagination = new IssueRegisterPagination();
  constructor(private http: HttpClient) { }


  getIssueRegisters(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IIssueRegisterPagination>(this.baseUrl + '/issue-register/get-IssueRegisters', { observe: 'response', params })
    .pipe(
      map(response => {
        this.IssueRegisters = [...this.IssueRegisters, ...response.body.items];
        this.IssueRegisterPagination = response.body;
        return this.IssueRegisterPagination;
      })
    );
   
  }
  //autocomplete for By Pno  
  getSelectedPno(pno){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/training-crew/get-autocompletePnoForIssueRegister?pno='+pno)
      .pipe(
        map((response:[]) => response.map(item => item))
      )
  }

  //autocomplete for By PartNo  
  getSelectedPartNo(partNo){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/item-detail/get-autocompletePartNoByDepartment?partNo='+partNo)
      .pipe(
        map((response:[]) => response.map(item => item))
      )
  }

  getSelectedPartNoByNameByDepartmentId(partNo,departmentId) {
    return this.http
      .get<SelectedModel[]>(
        this.baseUrl +"/item-detail/get-autocompletePartNoByNameForSparesByDepartmentId?partNo="+partNo+"&departmentNameId="+departmentId+"")
      .pipe(map((response: []) => response.map((item) => item)));
  }
  

  getSelectedIssueRegisterList(departmentNameId,sparesCategoryId) {
    return this.http.get<IssueRegister[]>(this.baseUrl + '/issue-register/get-selectedIssueRegisterList?departmentNameId='+departmentNameId+'&sparesCategoryId=' + sparesCategoryId);
  }
  
  getselectedItemNameByDepartmentNameIdAndSpareCategoryIdItemDetailIdFromItemStore(departmentNameId,spareCategoryId,itemDetailId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/item-stor/get-selectedItemNameByDepartmentNameIdAndSpareCategoryIdItemDetailIdFromItemStore?departmentNameId='+departmentNameId+'&spareCategoryId='+spareCategoryId+'&itemDetailId='+itemDetailId+'')
  }

 getselectedPartNoByDepartmentNameIdAndSpareCategoryIdFromItemStore(departmentNameId,spareCategoryId){
  return this.http.get<SelectedModel[]>(this.baseUrl + '/item-stor/get-selectedPartNoByDepartmentNameIdAndSpareCategoryIdFromItemStore?departmentNameId='+departmentNameId+'&spareCategoryId='+spareCategoryId+'')
 }
  // getselectedItemStors(){
    //item-detail/get-itemNameByItemDetailId?itemDetailId=11
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/item-stor/get-selectedItemStors')
  // }
  getItemNameByItemDetailId(id:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/item-detail/get-itemNameByItemDetailId?itemDetailId=' + id);
  }
  getSelectedItemStorebyDepartmentNameIdAndSparesCategoryId(departmentNameId,dropdown){
    return this.http.get<ItemStor[]>(this.baseUrl + '/item-stor/get-itemStoreListForIssueRegisterByDepartmentNameIdAndSparesCategoryId?departmentNameId='+departmentNameId+'&sparesCategoryId='+dropdown+'')
  }

  getSelectedItemStorebyDepartmentNameIdAndSparesCategoryIdAndItemDetailId(departmentNameId,dropdown,itemDetailId){
    return this.http.get<ItemStor[]>(this.baseUrl + '/item-stor/get-itemStoreListForIssueRegisterByDepartmentNameIdAndSparesCategoryIdandItemDetail?departmentNameId='+departmentNameId+'&sparesCategoryId='+dropdown+'&itemDetailId='+itemDetailId+'')
  }

  getselectedSparesCategory(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/spares-category/get-selectedSparesCategory')
  }
  getselectedSparesCategoryForReturnableIssue(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/spares-category/get-selectedSparesCategoryForReturnableIssue')
  }
  getselectedSparesCategoryForToolsIssueRegister(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/spares-category/get-selectedSparesCategoryForToolsIssueRegister')
  }

  getselectedItemDetails(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/item-detail/get-selectedItemDetails')
  }
  getselectedIssueStatuses(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/issue-status/get-selectedIssueStatuses')
  }
  // getselectedDepartmentNames(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  // }
  returnIssueRegister(id: number,model: any) {
    return this.http.put(this.baseUrl + '/issue-register/return-IssueRegister/'+id, model);
  }

  getIssueRegisterForTyList(departmentNameId,sparesCategoryId,issueStatusId) {
    return this.http.get<IssueRegister[]>(this.baseUrl + '/issue-register/get-selectedIssueRegisterOfTyList?departmentNameId='+departmentNameId+'&sparesCategoryId='+sparesCategoryId+'&issueStatusId='+issueStatusId);
  }

  find(id: number) {
    return this.http.get<IssueRegister>(this.baseUrl + '/issue-register/get-IssueRegisterDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/issue-register/update-IssueRegister/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/issue-register/save-IssueRegister', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/issue-register/delete-IssueRegister/'+id);
  }

}
