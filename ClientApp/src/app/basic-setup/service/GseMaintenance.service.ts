import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IGseMaintenancePagination, GseMaintenancePagination } from '../models/GseMaintenancePagination'
import { GseMaintenance } from '../models/GseMaintenance';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class GseMaintenanceService {
  baseUrl = environment.apiUrl;
  GseMaintenances: GseMaintenance[] = [];
  GseMaintenancePagination = new GseMaintenancePagination();
  constructor(private http: HttpClient) { }

  getGseMaintenances(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IGseMaintenancePagination>(this.baseUrl + '/gse-maintenance/get-gseMaintenances', { observe: 'response', params })
    .pipe(
      map(response => {
        this.GseMaintenances = [...this.GseMaintenances, ...response.body.items];
        this.GseMaintenancePagination = response.body;
        return this.GseMaintenancePagination;
      })
    );
   
  }

  getselectedGseMAintenances(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/gse-maintenance/get-selectedGseMaintenances')
  }

  getselectedGseItemNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/gse-item-name/get-selectedGseItemNames')
  }

  getselectedGseScheduleWorkTypes(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/gse-schedule-work-type/get-selectedGseScheduleWorkTypes')
  }

  getselectedGseMaintenanceScheduleNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/gse-maintenance-schedule-name/get-selectedGseMaintenanceScheduleNames')
  }

  find(id: number) {
    return this.http.get<GseMaintenance>(this.baseUrl + '/gse-maintenance/get-gseMaintenanceDetail/' + id);
  }
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/gse-maintenance/update-gseMaintenance/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/gse-maintenance/save-gseMaintenance', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/gse-maintenance/delete-gseMaintenance/'+id);
  }

}
