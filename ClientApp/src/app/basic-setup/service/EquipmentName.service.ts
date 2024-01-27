import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IEquipmentNamePagination, EquipmentNamePagination } from '../models/EquipmentNamePagination'
import { EquipmentName } from '../models/EquipmentName';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class EquipmentNameService {
  baseUrl = environment.apiUrl;
  EquipmentNames: EquipmentName[] = [];
  EquipmentNamePagination = new EquipmentNamePagination();
  constructor(private http: HttpClient) { }

  getEquipmentNames(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IEquipmentNamePagination>(this.baseUrl + '/equipment-name/get-equipmentNames', { observe: 'response', params })
    .pipe(
      map(response => {
        this.EquipmentNames = [...this.EquipmentNames, ...response.body.items];
        this.EquipmentNamePagination = response.body;
        return this.EquipmentNamePagination;
      })
    );
   
  }
  getEquipmentNameListByDepartmentName( departmentNameId:number){
    return this.http.get<EquipmentName[]>(this.baseUrl + '/equipment-name/get-equipmentNameListByDepartmentNameId?departmentNameId='+departmentNameId);
   }
  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  find(id: number) {
    return this.http.get<EquipmentName>(this.baseUrl + '/equipment-name/get-equipmentNameDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/equipment-name/update-equipmentName/'+id, model);
  }
  submit(model: any) {
    console.log(model)
    return this.http.post(this.baseUrl + '/equipment-name/save-equipmentName', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/equipment-name/delete-equipmentName/'+id);
  }

}
