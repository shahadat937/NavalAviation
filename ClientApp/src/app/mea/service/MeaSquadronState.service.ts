import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IMeaSquadronStatePagination, MeaSquadronStatePagination } from '../models/MeaSquadronStatePagination'
import { MeaSquadronState } from '../models/MeaSquadronState';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class MeaSquadronStateService {
  baseUrl = environment.apiUrl;
  MeaSquadronStates: MeaSquadronState[] = [];
  MeaSquadronStatePagination = new MeaSquadronStatePagination();
  constructor(private http: HttpClient) { }


  getMeaSquadronStates(pageNumber, pageSize, searchText, completeStatus) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('completeStatus', completeStatus.toString());

    return this.http.get<IMeaSquadronStatePagination>(this.baseUrl + '/mea-squadron-state/get-MeaSquadronStates', { observe: 'response', params })
    .pipe(
      map(response => {
        this.MeaSquadronStates = [...this.MeaSquadronStates, ...response.body.items];
        this.MeaSquadronStatePagination = response.body;
        return this.MeaSquadronStatePagination;
      })
    );
   
  }
  getMeaSquadronStatesForWorkShop(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    //params = params.append('departmentNameId', departmentNameId.toString());
    return this.http.get<IMeaSquadronStatePagination>(this.baseUrl + '/mea-squadron-state/get-meaSquadronStateListForWorkShopByJobStatus', { observe: 'response', params })
    .pipe(
      map(response => {
        this.MeaSquadronStates = [...this.MeaSquadronStates, ...response.body.items];
        this.MeaSquadronStatePagination = response.body;
        return this.MeaSquadronStatePagination;
      })
    );
   
  }
  getMeaSquadronStatesForWorkProgress(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    //params = params.append('departmentNameId', departmentNameId.toString());
    return this.http.get<IMeaSquadronStatePagination>(this.baseUrl + '/mea-squadron-state/get-meaSquadronStateListForForWorkProgressByWorkCompletedStatus', { observe: 'response', params })
    .pipe(
      map(response => {
        this.MeaSquadronStates = [...this.MeaSquadronStates, ...response.body.items];
        this.MeaSquadronStatePagination = response.body;
        return this.MeaSquadronStatePagination;
      })
    );
   
  }
  acceptMeaSquadronState(id: number) {
    return this.http.get<MeaSquadronState>(this.baseUrl + '/mea-squadron-state/accept-meaSquadronState/' + id);
  }
  cancelMeaSquadronState(id: number) {
    return this.http.get<MeaSquadronState>(this.baseUrl + '/mea-squadron-state/cancel-meaSquadronState/' + id);
  }
  completedMeaSquadronState(id: number,) {
    return this.http.get<MeaSquadronState>(this.baseUrl + '/mea-squadron-state/completedStatus-meaSquadronState/' + id);
  }
  unCompletedMeaSquadronState(id: number) {
    return this.http.get<MeaSquadronState>(this.baseUrl + '/mea-squadron-state/unCompletedStatus-meaSquadronState/' + id);
  }
  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  getselectedPresentStates(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/present-state/get-selectedPresentState')
  }
  getselectedTrad(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/trade/get-selectedTrades')
  }
  getselectedWorkShop(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/mea-work-shop/get-selectedMeaWorkShops')
  }
  getSelectedItemNameAndPattNo(departmentNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/item-detail/get-itemNameAndPartNoByDepartmentNameId?departmentNameId='+departmentNameId)
  }
  getselectedConditionofItem(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/condition-of-item/get-selectedConditionOfItem')
  }

  find(id: number) {
    return this.http.get<MeaSquadronState>(this.baseUrl + '/mea-squadron-state/get-MeaSquadronStateDetail/' + id);
  }
  updateMeaSquadronState(id: number,model: any){
    return this.http.put(this.baseUrl + '/mea-squadron-state/update-completedMeaSquadronState/'+id, model);
  }
  updateRemarksMeaSquadronState(id: number,model: any){
    return this.http.put(this.baseUrl + '/mea-squadron-state/update-remarksMeaSquadronState/'+id, model);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/mea-squadron-state/update-MeaSquadronState/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/mea-squadron-state/save-MeaSquadronState', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/mea-squadron-state/delete-MeaSquadronState/'+id);
  }

}
