import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IItemCategoryPagination,ItemCategoryPagination } from '../models/ItemCategoryPagination'
import { ItemCategory } from '../models/ItemCategory';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class ItemCategoryService {
  baseUrl = environment.apiUrl;
  ItemCategorys: ItemCategory[] = [];
  ItemCategoryPagination = new ItemCategoryPagination();
  constructor(private http: HttpClient) { }

  getItemCategorys(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IItemCategoryPagination>(this.baseUrl + '/item-category/get-itemCategories', { observe: 'response', params })
    .pipe(
      map(response => {
        this.ItemCategorys = [...this.ItemCategorys, ...response.body.items];
        this.ItemCategoryPagination = response.body;
        return this.ItemCategoryPagination;
      })
    );
   
  }

  getSelectedSparesCategory(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/spares-category/get-selectedSparesCategory')
  }

  find(id: number) {
    return this.http.get<ItemCategory>(this.baseUrl + '/item-category/get-itemCategoryDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/item-category/update-itemCategory/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/item-category/save-itemCategory', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/item-category/delete-itemCategory/'+id);
  }

}
