import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {ICstTecPagination,CstTecPagination } from '../models/CstTecPagination'
import { CstTec } from '../models/CstTec';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class CstTecService {
  baseUrl = environment.apiUrl;
  CstTecs: CstTec[] = [];
  CstTecPagination = new CstTecPagination();
  constructor(private http: HttpClient) { }

  getCstTecs(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<ICstTecPagination>(this.baseUrl + '/cst-tec/get-cstTec', { observe: 'response', params })
    .pipe(
      map(response => {
        this.CstTecs = [...this.CstTecs, ...response.body.items];
        this.CstTecPagination = response.body;
        return this.CstTecPagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<CstTec>(this.baseUrl + '/cst-tec/get-cstTecDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/cst-tec/update-cstTec/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/cst-tec/save-cstTec', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/cst-tec/delete-cstTec/'+id);
  }

}
