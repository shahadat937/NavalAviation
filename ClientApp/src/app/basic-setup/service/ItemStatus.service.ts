import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IItemStatusPagination,ItemStatusPagination } from '../models/ItemStatusPagination'
import { ItemStatus } from '../models/ItemStatus';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class ItemStatusService {
  baseUrl = environment.apiUrl;
  ItemStatuss: ItemStatus[] = [];
  ItemStatusPagination = new ItemStatusPagination();
  constructor(private http: HttpClient) { }

  getItemStatuss(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IItemStatusPagination>(this.baseUrl + '/item-status/get-ItemStatuss', { observe: 'response', params })
    .pipe(
      map(response => {
        this.ItemStatuss = [...this.ItemStatuss, ...response.body.items];
        this.ItemStatusPagination = response.body;
        return this.ItemStatusPagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<ItemStatus>(this.baseUrl + '/item-status/get-itemStatusDetail/' + id);
  }

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/item-status/update-itemStatus/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/item-status/save-itemStatus', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/item-status/delete-itemStatus/'+id);
  }

}
