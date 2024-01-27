import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {ILifeLimitItemPagination, LifeLimitItemPagination } from '../models/LifeLimitItemPagination'
import { LifeLimitItem } from '../models/LifeLimitItem';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class LifeLimitItemService {
  baseUrl = environment.apiUrl;
  LifeLimitItems: LifeLimitItem[] = [];
  LifeLimitItemPagination = new LifeLimitItemPagination();
  constructor(private http: HttpClient) { }

  getAdminAuthorities(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<ILifeLimitItemPagination>(this.baseUrl + '/life-limit-tem/get-lifeLimitItems', { observe: 'response', params })
    .pipe(
      map(response => {
        this.LifeLimitItems = [...this.LifeLimitItems, ...response.body.items];
        this.LifeLimitItemPagination = response.body;
        return this.LifeLimitItemPagination;
      })
    );
   
  }

  getselectedAdminAuthorities(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/life-limit-tem/get-selectedLifeLimitItems')
  }

  find(id: number) {
    return this.http.get<LifeLimitItem>(this.baseUrl + '/life-limit-tem/get-lifeLimitItemDetail/' + id);
  }
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/life-limit-tem/update-lifeLimitItem/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/life-limit-tem/save-lifeLimitItem', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/life-limit-tem/delete-lifeLimitItem/'+id);
  }

}
