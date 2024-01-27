import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IOverhaulingTypePagination,OverhaulingTypePagination } from '../models/OverhaulingTypePagination'
import { OverhaulingType } from '../models/OverhaulingType';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class OverhaulingTypeService {
  baseUrl = environment.apiUrl;
  OverhaulingTypes: OverhaulingType[] = [];
  OverhaulingTypePagination = new OverhaulingTypePagination();
  constructor(private http: HttpClient) { }

  getOverhaulingTypes(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IOverhaulingTypePagination>(this.baseUrl + '/overhauling-type/get-OverhaulingTypes', { observe: 'response', params })
    .pipe(
      map(response => {
        this.OverhaulingTypes = [...this.OverhaulingTypes, ...response.body.items];
        this.OverhaulingTypePagination = response.body;
        return this.OverhaulingTypePagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<OverhaulingType>(this.baseUrl + '/overhauling-type/get-OverhaulingTypeDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/overhauling-type/update-OverhaulingType/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/overhauling-type/save-OverhaulingType', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/overhauling-type/delete-OverhaulingType/'+id);
  }

}
