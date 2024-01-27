import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IServiceLifeTypePagination,ServiceLifeTypePagination } from '../models/ServiceLifeTypePagination'
import { ServiceLifeType } from '../models/ServiceLifeType';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class ServiceLifeTypeService {
  baseUrl = environment.apiUrl;
  ServiceLifeTypes: ServiceLifeType[] = [];
  ServiceLifeTypePagination = new ServiceLifeTypePagination();
  constructor(private http: HttpClient) { }

  getServiceLifeTypes(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IServiceLifeTypePagination>(this.baseUrl + '/service-life-type/get-serviceLifeTypes', { observe: 'response', params })
    .pipe(
      map(response => {
        this.ServiceLifeTypes = [...this.ServiceLifeTypes, ...response.body.items];
        this.ServiceLifeTypePagination = response.body;
        return this.ServiceLifeTypePagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<ServiceLifeType>(this.baseUrl + '/service-life-type/get-serviceLifeTypeDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/service-life-type/update-serviceLifeType/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/service-life-type/save-serviceLifeType', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/service-life-type/delete-serviceLifeType/'+id);
  }

}
