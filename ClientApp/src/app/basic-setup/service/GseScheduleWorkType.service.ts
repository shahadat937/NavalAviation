import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IGseScheduleWorkTypePagination, GseScheduleWorkTypePagination } from '../models/GseScheduleWorkTypePagination'
import { GseScheduleWorkType } from '../models/GseScheduleWorkType';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class GseScheduleWorkTypeService {
  baseUrl = environment.apiUrl;
  GseScheduleWorkTypes: GseScheduleWorkType[] = [];
  GseScheduleWorkTypePagination = new GseScheduleWorkTypePagination();
  constructor(private http: HttpClient) { }

  getGseScheduleWorkTypes(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IGseScheduleWorkTypePagination>(this.baseUrl + '/gse-schedule-work-type/get-gseScheduleWorkTypes', { observe: 'response', params })
    .pipe(
      map(response => {
        this.GseScheduleWorkTypes = [...this.GseScheduleWorkTypes, ...response.body.items];
        this.GseScheduleWorkTypePagination = response.body;
        return this.GseScheduleWorkTypePagination;
      })
    );
   
  }

  

  getselectedGseMaintenanceScheduleNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/gse-maintenance-schedule-name/get-selectedGseMaintenanceScheduleNames')
  }

  getselectedGseScheduleWorkTypes(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/gse-schedule-work-type/get-selectedGseScheduleWorkTypes')
  }

  find(id: number) {
    return this.http.get<GseScheduleWorkType>(this.baseUrl + '/gse-schedule-work-type/get-gseScheduleWorkTypeDetail/' + id);
  }
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/gse-schedule-work-type/update-gseScheduleWorkType/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/gse-schedule-work-type/save-gseScheduleWorkType', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/gse-schedule-work-type/delete-gseScheduleWorkType/'+id);
  }

}
