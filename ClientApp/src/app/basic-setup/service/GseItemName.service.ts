import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IGseItemNamePagination, GseItemNamePagination } from '../models/GseItemNamePagination'
import { GseItemName } from '../models/GseItemName';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class GseItemNameService {
  baseUrl = environment.apiUrl;
  GseItemNames: GseItemName[] = [];
  GseItemNamePagination = new GseItemNamePagination();
  constructor(private http: HttpClient) { }

  getGseItemNames(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IGseItemNamePagination>(this.baseUrl + '/gse-item-name/get-gseItemNames', { observe: 'response', params })
    .pipe(
      map(response => {
        this.GseItemNames = [...this.GseItemNames, ...response.body.items];
        this.GseItemNamePagination = response.body;
        return this.GseItemNamePagination;
      })
    );
   
  }

  

  getselectedGseItemNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/gse-item-name/get-selectedGseItemNames')
  }

  find(id: number) {
    return this.http.get<GseItemName>(this.baseUrl + '/gse-item-name/get-gseItemNameDetail/' + id);
  }
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/gse-item-name/update-gseItemName/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/gse-item-name/save-gseItemName', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/gse-item-name/delete-gseItemName/'+id);
  }

}
