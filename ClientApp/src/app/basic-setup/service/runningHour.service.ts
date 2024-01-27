import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IRunningHourPagination, RunningHourPagination } from '../models/runningHourPagination'
import { RunningHour } from '../models/runningHour';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class RunningHourService {
  baseUrl = environment.apiUrl;
  RunningHours: RunningHour[] = [];
  RunningHourPagination = new RunningHourPagination();
  constructor(private http: HttpClient) { }

  getRunningHours(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IRunningHourPagination>(this.baseUrl + '/running-hour/get-RunningHours', { observe: 'response', params })
    .pipe(
      map(response => {
        this.RunningHours = [...this.RunningHours, ...response.body.items];
        this.RunningHourPagination = response.body;
        return this.RunningHourPagination;
      })
    );
   
  }
  getAirCraftNameByDepartmentId(id:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/air-craft-name/get-selectedAirCraftNameByDepartmentId?departmentNameId=' + id);
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  // getselectedAirCraftName(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/air-craft-name/get-selectedAirCraftNames')
  // }
  getselectedDepartmentName(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }

  getRunningHourListByDepartmentAndAirCraftName(airCraftNameId:number, departmentNameId:number){
    return this.http.get<RunningHour[]>(this.baseUrl + '/running-hour/get-RunningHourListByDepartmentAndAirCraftName?departmentNameId='+departmentNameId+'&airCraftNameId='+airCraftNameId);
   }

  find(id: number) {
    return this.http.get<RunningHour>(this.baseUrl + '/running-hour/get-RunningHourDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/running-hour/update-RunningHour/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/running-hour/save-RunningHour', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/running-hour/delete-RunningHour/'+id);
  }

}
