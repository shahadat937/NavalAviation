import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IToolsLocationPagination,ToolsLocationPagination } from '../models/ToolsLocationPagination'
import { ToolsLocation } from '../models/ToolsLocation';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class ToolsLocationService {
  baseUrl = environment.apiUrl;
  ToolsLocations: ToolsLocation[] = [];
  ToolsLocationPagination = new ToolsLocationPagination();
  constructor(private http: HttpClient) { }

  getToolsLocations(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IToolsLocationPagination>(this.baseUrl + '/tools-location/get-toolsLocations', { observe: 'response', params })
    .pipe(
      map(response => {
        this.ToolsLocations = [...this.ToolsLocations, ...response.body.items];
        this.ToolsLocationPagination = response.body;
        return this.ToolsLocationPagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<ToolsLocation>(this.baseUrl + '/tools-location/get-toolsLocationDetail/' + id);
  }


  // getselecteddivision(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/ToolsLocation/get-selectedToolsLocation')
  // }tools-location/update-toolsLocation/2
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/tools-location/update-toolsLocation/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/tools-location/save-toolsLocation', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/tools-location/delete-toolsLocation/'+id);
  }

}
