import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IShelfLifeCategoryPagination, ShelfLifeCategoryPagination } from '../models/shelfLifeCategoryPagination'
import { ShelfLifeCategory } from '../models/shelfLifeCategory';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class ShelfLifeCategoryService {
  baseUrl = environment.apiUrl;
  ShelfLifeCategorys: ShelfLifeCategory[] = [];
  ShelfLifeCategoryPagination = new ShelfLifeCategoryPagination();
  constructor(private http: HttpClient) { }

  getShelfLifeCategorys(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IShelfLifeCategoryPagination>(this.baseUrl + '/shelf-life-category/get-ShelfLifeCategorys', { observe: 'response', params })
    .pipe(
      map(response => {
        this.ShelfLifeCategorys = [...this.ShelfLifeCategorys, ...response.body.items];
        this.ShelfLifeCategoryPagination = response.body;
        return this.ShelfLifeCategoryPagination;
      })
    );
   
  }

  

  find(id: number) {
    return this.http.get<ShelfLifeCategory>(this.baseUrl + '/shelf-life-category/get-ShelfLifeCategoryDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/shelf-life-category/update-ShelfLifeCategory/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/shelf-life-category/save-ShelfLifeCategory', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/shelf-life-category/delete-ShelfLifeCategory/'+id);
  }

}
