import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IAcStatusPagination,AcStatusPagination } from '../models/AcStatusPagination'
import { AcStatus } from '../models/AcStatus';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class AcStatusService {
  baseUrl = environment.apiUrl;
  AcStatuses: AcStatus[] = [];
  AcStatusPagination = new AcStatusPagination();
  constructor(private http: HttpClient) { }

  getAcStatuses(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IAcStatusPagination>(this.baseUrl + '/ac-status/get-acStatuses', { observe: 'response', params })
    .pipe(
      map(response => {
        this.AcStatuses = [...this.AcStatuses, ...response.body.items];
        this.AcStatusPagination = response.body;
        return this.AcStatusPagination;
      })
    );
   
  }
  getAcStatusesByDepartment(departmentNameId){
    return this.http.get<any[]>(this.baseUrl + '/ac-status/get-AcStatusListByDepartmentId?departmentNameId='+departmentNameId)
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  getStatus(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/status/get-selectedStatus')
  }
  getAirCraftNameByDepartmentId(id:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/air-craft-name/get-selectedAirCraftNameByDepartmentId?departmentNameId=' + id);
  }

  getAirCraftNameByDepartmentIdForStatus(id:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/air-craft-name/get-selectedAirCraftNameByDepartmentIdForStatus?departmentNameId=' + id);
  }

  find(id: number) {
    return this.http.get<AcStatus>(this.baseUrl + '/ac-status/get-acStatusDetail/' + id);
  }

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/ac-status/update-acStatus/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/ac-status/save-acStatus', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/ac-status/delete-acStatus/'+id);
  }

}
