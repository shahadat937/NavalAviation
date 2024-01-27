import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IConditionOfItemPagination,ConditionOfItemPagination } from '../models/ConditionOfItemPagination'
import { ConditionOfItem } from '../models/ConditionOfItem';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class ConditionOfItemService {
  baseUrl = environment.apiUrl;
  ConditionOfItems: ConditionOfItem[] = [];
  ConditionOfItemPagination = new ConditionOfItemPagination();
  constructor(private http: HttpClient) { }

  getConditionOfItems(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IConditionOfItemPagination>(this.baseUrl + '/condition-of-item/get-conditionOfItems', { observe: 'response', params })
    .pipe(
      map(response => {
        this.ConditionOfItems = [...this.ConditionOfItems, ...response.body.items];
        this.ConditionOfItemPagination = response.body;
        return this.ConditionOfItemPagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<ConditionOfItem>(this.baseUrl + '/condition-of-item/get-conditionOfItemDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/condition-of-item/update-conditionOfItem/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/condition-of-item/save-conditionOfItem', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/condition-of-item/delete-conditionOfItem/'+id);
  }

}
