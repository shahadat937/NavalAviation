import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IToolsBoxNamePagination,ToolsBoxNamePagination } from '../models/ToolsBoxNamePagination'
import { ToolsBoxName } from '../models/ToolsBoxName';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class ToolsBoxNameService {
  baseUrl = environment.apiUrl;
  ToolsBoxNames: ToolsBoxName[] = [];
  ToolsBoxNamePagination = new ToolsBoxNamePagination();
  constructor(private http: HttpClient) { }

  getToolsBoxNames(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IToolsBoxNamePagination>(this.baseUrl + '/toolsbox-name/get-toolsBoxNames', { observe: 'response', params })
    .pipe(
      map(response => {
        this.ToolsBoxNames = [...this.ToolsBoxNames, ...response.body.items];
        this.ToolsBoxNamePagination = response.body;
        return this.ToolsBoxNamePagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<ToolsBoxName>(this.baseUrl + '/toolsbox-name/get-toolsBoxNameDetail/' + id);
  }


  // getselecteddivision(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/ToolsBoxName/get-selectedToolsBoxName')
  // }tools-location/update-ToolsBoxName/2
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/toolsbox-name/update-toolsBoxName/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/toolsbox-name/save-toolsBoxName', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/toolsbox-name/delete-toolsBoxName/'+id);
  }

}
