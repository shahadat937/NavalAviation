import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IItemCategoryTypePagination,ItemCategoryTypePagination } from '../models/ItemCategoryTypePagination'
import { ItemCategoryType } from '../models/ItemCategoryType';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class ItemCategoryTypeService {
  baseUrl = environment.apiUrl;
  ItemCategoryTypes: ItemCategoryType[] = [];
  ItemCategoryTypePagination = new ItemCategoryTypePagination();
  constructor(private http: HttpClient) { }

  getItemCategoryTypes(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IItemCategoryTypePagination>(this.baseUrl + '/item-category-type/get-ItemCategoryTypes', { observe: 'response', params })
    .pipe(
      map(response => {
        this.ItemCategoryTypes = [...this.ItemCategoryTypes, ...response.body.items];
        this.ItemCategoryTypePagination = response.body;
        return this.ItemCategoryTypePagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<ItemCategoryType>(this.baseUrl + '/item-category-type/get-ItemCategoryTypeDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/item-category-type/update-ItemCategoryType/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/item-category-type/save-ItemCategoryType', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/item-category-type/delete-ItemCategoryType/'+id);
  }

}
