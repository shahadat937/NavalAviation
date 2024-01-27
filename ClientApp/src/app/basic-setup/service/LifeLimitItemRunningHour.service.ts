import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {ILifeLimitItemRunningHourPagination, LifeLimitItemRunningHourPagination } from '../models/LifeLimitItemRunningHourPagination'
import { LifeLimitItemRunningHour } from '../models/LifeLimitItemRunningHour';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class LifeLimitItemRunningHourService {
  baseUrl = environment.apiUrl;
  LifeLimitItemRunningHours: LifeLimitItemRunningHour[] = [];
  LifeLimitItemRunningHourPagination = new LifeLimitItemRunningHourPagination();
  constructor(private http: HttpClient) { }

  getLifeLimitItemRunningHours(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<ILifeLimitItemRunningHourPagination>(this.baseUrl + '/life-limit-item-running-hour/get-lifeLimitItemRunningHours', { observe: 'response', params })
    .pipe(
      map(response => {
        this.LifeLimitItemRunningHours = [...this.LifeLimitItemRunningHours, ...response.body.items];
        this.LifeLimitItemRunningHourPagination = response.body;
        return this.LifeLimitItemRunningHourPagination;
      })
    );
   
  }

  getselectedLifeLimitItemRunningHours(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/life-limit-item-running-hour/get-selectedLifeLimitItemRunningHours')
  }

  getselectedGseItemNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/life-limit-item-running-hour/get-selectedGseItemNames')
  }

  getselectedLifeLimitItems(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/life-limit-tem/get-selectedLifeLimitItems')
  }

  getselectedMaintenanceCategorys(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/maintenance-category/get-selectedMaintenanceCategorys')
  }
  
  find(id: number) {
    return this.http.get<LifeLimitItemRunningHour>(this.baseUrl + '/life-limit-item-running-hour/get-lifeLimitItemRunningHourDetail/' + id);
  }

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/life-limit-item-running-hour/update-lifeLimitItemRunningHour/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/life-limit-item-running-hour/save-lifeLimitItemRunningHour', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/life-limit-item-running-hour/delete-lifeLimitItemRunningHour/'+id);
  }

}
