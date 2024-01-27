import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IAirCraftNamePagination, AirCraftNamePagination } from '../models/airCraftNamePagination'
import { AirCraftName } from '../models/airCraftName';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class AirCraftNameService {
  baseUrl = environment.apiUrl;
  AirCraftNames: AirCraftName[] = [];
  AirCraftNamePagination = new AirCraftNamePagination();
  constructor(private http: HttpClient) { }

  getAirCraftNames(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IAirCraftNamePagination>(this.baseUrl + '/air-craft-name/get-AirCraftNames', { observe: 'response', params })
    .pipe(
      map(response => {
        this.AirCraftNames = [...this.AirCraftNames, ...response.body.items];
        this.AirCraftNamePagination = response.body;
        return this.AirCraftNamePagination;
      })
    );
   
  }
  getAirCraftNameListByDepartmentName( departmentNameId:number){
    return this.http.get<AirCraftName[]>(this.baseUrl + '/air-craft-name/get-AirCraftNameListByDepartmentNameId?departmentNameId='+departmentNameId);
   }
  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  operationalAircraft(airCraftNameId){
    return this.http.get<AirCraftName[]>(this.baseUrl + '/air-craft-name/operational-aircraft/'+airCraftNameId)
  }
  underMaintAircraft(acStatusId){
    return this.http.get<AirCraftName[]>(this.baseUrl + '/air-craft-name/underMaint-aircraft/'+acStatusId)
  }

  find(id: number) {
    return this.http.get<AirCraftName>(this.baseUrl + '/air-craft-name/get-AirCraftNameDetail/' + id);
  }
  update(id: number,model: any) {
    //console.log(model)
    return this.http.put(this.baseUrl + '/air-craft-name/update-AirCraftName/'+id, model);
  }
  submit(model: any) {
    console.log(model)
    return this.http.post(this.baseUrl + '/air-craft-name/save-AirCraftName', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/air-craft-name/delete-AirCraftName/'+id);
  }

}
