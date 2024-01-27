import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IItemTypePagination,ItemTypePagination } from '../models/ItemTypePagination'
import { ItemType } from '../models/ItemType';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class ItemTypeService {
  baseUrl = environment.apiUrl;
  ItemTypes: ItemType[] = [];
  ItemTypePagination = new ItemTypePagination();
  constructor(private http: HttpClient) { }

  getItemTypes(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IItemTypePagination>(this.baseUrl + '/item-type/get-itemTypes', { observe: 'response', params })
    .pipe(
      map(response => {
        this.ItemTypes = [...this.ItemTypes, ...response.body.items];
        this.ItemTypePagination = response.body;
        return this.ItemTypePagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<ItemType>(this.baseUrl + '/item-type/get-itemTypeDetail/' + id);
  }

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/item-type/update-itemType/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/item-type/save-itemType', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/item-type/delete-itemType/'+id);
  }

}
