import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IStorePagination, StorePagination } from '../models/storePagination'
import { Store } from '../models/store';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class StoreService {
  baseUrl = environment.apiUrl;
  Stores: Store[] = [];
  StorePagination = new StorePagination();
  constructor(private http: HttpClient) { }

  getStores(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IStorePagination>(this.baseUrl + '/store/get-Stores', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Stores = [...this.Stores, ...response.body.items];
        this.StorePagination = response.body;
        return this.StorePagination;
      })
    );
   
  }

  

  find(id: number) {
    return this.http.get<Store>(this.baseUrl + '/store/get-StoreDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/store/update-Store/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/store/save-Store', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/store/delete-Store/'+id);
  }

}
