import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IEndLifeTypePagination,EndLifeTypePagination } from '../models/EndLifeTypePagination'
import { EndLifeType } from '../models/EndLifeType';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class EndLifeTypeService {
  baseUrl = environment.apiUrl;
  EndLifeTypes: EndLifeType[] = [];
  EndLifeTypePagination = new EndLifeTypePagination();
  constructor(private http: HttpClient) { }

  getEndLifeTypes(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IEndLifeTypePagination>(this.baseUrl + '/endlife-type/get-endLifeTypes', { observe: 'response', params })
    .pipe(
      map(response => {
        this.EndLifeTypes = [...this.EndLifeTypes, ...response.body.items];
        this.EndLifeTypePagination = response.body;
        return this.EndLifeTypePagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<EndLifeType>(this.baseUrl + '/endlife-type/get-endLifeTypeDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/endlife-type/update-endLifeType/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/endlife-type/save-endLifeType', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/endlife-type/delete-endLifeType/'+id);
  }

}
