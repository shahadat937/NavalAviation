import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IMeaWorkShopPagination, MeaWorkShopPagination } from '../models/MeaWorkShopPagination'
import { MeaWorkShop } from '../models/MeaWorkShop';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class MeaWorkShopService {
  baseUrl = environment.apiUrl;
  MeaWorkShops: MeaWorkShop[] = [];
  MeaWorkShopPagination = new MeaWorkShopPagination();
  constructor(private http: HttpClient) { }

  getMeaWorkShops(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IMeaWorkShopPagination>(this.baseUrl + '/mea-work-shop/get-MeaWorkShops', { observe: 'response', params })
    .pipe(
      map(response => {
        this.MeaWorkShops = [...this.MeaWorkShops, ...response.body.items];
        this.MeaWorkShopPagination = response.body;
        return this.MeaWorkShopPagination;
      })
    );
   
  }

  

  find(id: number) {
    return this.http.get<MeaWorkShop>(this.baseUrl + '/mea-work-shop/get-MeaWorkShopDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/mea-work-shop/update-MeaWorkShop/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/mea-work-shop/save-MeaWorkShop', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/mea-work-shop/delete-MeaWorkShop/'+id);
  }

}
