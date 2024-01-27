import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IAirCraftFlyingPagination,AirCraftFlyingPagination } from '../models/AirCraftFlyingPagination'
import { AirCraftFlying } from '../models/AirCraftFlying';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class AirCraftFlyingService {
  baseUrl = environment.apiUrl;
  AirCraftFlyings: AirCraftFlying[] = [];
  AirCraftFlyingPagination = new AirCraftFlyingPagination();
  constructor(private http: HttpClient) { }

  getAirCraftFlyings(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IAirCraftFlyingPagination>(this.baseUrl + '/air-craft-flying/get-AirCraftFlyings', { observe: 'response', params })
    .pipe(
      map(response => {
        this.AirCraftFlyings = [...this.AirCraftFlyings, ...response.body.items];
        this.AirCraftFlyingPagination = response.body;
        return this.AirCraftFlyingPagination;
      })
    );
   
  }
  getAirCraftNameByDepartmentId(id:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/air-craft-name/get-selectedAirCraftNameByDepartmentId?departmentNameId=' + id);
  }
  getselectedDepartmentName(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  getAirCraftFlyingListByDepartmentName(airCraftNameId:number, departmentNameId:number){
    return this.http.get<AirCraftFlying[]>(this.baseUrl + '/air-craft-flying/get-AirCraftFlyingListByDepartmentNameId?departmentNameId='+departmentNameId+'&airCraftNameId='+airCraftNameId);
   }

  find(id: number) {
    return this.http.get<AirCraftFlying>(this.baseUrl + '/air-craft-flying/get-AirCraftFlyingDetail/' + id);
  }

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/air-craft-flying/update-AirCraftFlying/'+id, model);
  }
  updateAircraftFlyingDelay(id: number,model: any) {
    return this.http.put(this.baseUrl + '/air-craft-flying/update-aircraftflyingdelay/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/air-craft-flying/save-AirCraftFlying', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/air-craft-flying/delete-AirCraftFlying/'+id);
  }

}
