import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {ISourceOfSupplyPagination,SourceOfSupplyPagination } from '../models/SourceOfSupplyPagination'
import { SourceOfSupply } from '../models/SourceOfSupply';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class SourceOfSupplyService {
  baseUrl = environment.apiUrl;
  SourceOfSupplys: SourceOfSupply[] = [];
  SourceOfSupplyPagination = new SourceOfSupplyPagination();
  constructor(private http: HttpClient) { }

  getSourceOfSupplys(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<ISourceOfSupplyPagination>(this.baseUrl + '/source-of-supply/get-SourceOfSupplys', { observe: 'response', params })
    .pipe(
      map(response => {
        this.SourceOfSupplys = [...this.SourceOfSupplys, ...response.body.items];
        this.SourceOfSupplyPagination = response.body;
        return this.SourceOfSupplyPagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<SourceOfSupply>(this.baseUrl + '/source-of-supply/get-SourceOfSupplyDetail/' + id);
  }
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/source-of-supply/update-SourceOfSupply/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/source-of-supply/save-SourceOfSupply', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/source-of-supply/delete-SourceOfSupply/'+id);
  }

}
