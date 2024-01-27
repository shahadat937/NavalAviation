import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IGseMaintenanceScheduleNamePagination, GseMaintenanceScheduleNamePagination } from '../models/GseMaintenanceScheduleNamePagination'
import { GseMaintenanceScheduleName } from '../models/GseMaintenanceScheduleName';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class GseMaintenanceScheduleNameService {
  baseUrl = environment.apiUrl;
  GseMaintenanceScheduleNames: GseMaintenanceScheduleName[] = [];
  GseMaintenanceScheduleNamePagination = new GseMaintenanceScheduleNamePagination();
  constructor(private http: HttpClient) { }

  getGseMaintenanceScheduleNames(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IGseMaintenanceScheduleNamePagination>(this.baseUrl + '/gse-maintenance-schedule-name/get-gseMaintenanceScheduleNames', { observe: 'response', params })
    .pipe(
      map(response => {
        this.GseMaintenanceScheduleNames = [...this.GseMaintenanceScheduleNames, ...response.body.items];
        this.GseMaintenanceScheduleNamePagination = response.body;
        return this.GseMaintenanceScheduleNamePagination;
      })
    );
   
  }

  

  getselectedGseMaintenanceScheduleNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/gse-maintenance-schedule-name/get-selectedGseMaintenanceScheduleNames')
  }

  find(id: number) {
    return this.http.get<GseMaintenanceScheduleName>(this.baseUrl + '/gse-maintenance-schedule-name/get-gseMaintenanceScheduleNameDetail/' + id);
  }
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/gse-maintenance-schedule-name/update-gseMaintenanceScheduleName/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/gse-maintenance-schedule-name/save-gseMaintenanceScheduleName', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/gse-maintenance-schedule-name/delete-gseMaintenanceScheduleName/'+id);
  }

}
