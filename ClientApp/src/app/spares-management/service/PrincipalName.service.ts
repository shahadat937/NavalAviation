import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IPrincipalNamePagination,PrincipalNamePagination } from '../models/PrincipalNamePagination'
import { PrincipalName } from '../models/PrincipalName';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class PrincipalNameService {
  baseUrl = environment.apiUrl;
  PrincipalNames: PrincipalName[] = [];
  PrincipalNamePagination = new PrincipalNamePagination();
  constructor(private http: HttpClient) { }

  getPrincipalNames(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IPrincipalNamePagination>(this.baseUrl + '/principal-name/get-PrincipalNames', { observe: 'response', params })
    .pipe(
      map(response => {
        this.PrincipalNames = [...this.PrincipalNames, ...response.body.items];
        this.PrincipalNamePagination = response.body;
        return this.PrincipalNamePagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<PrincipalName>(this.baseUrl + '/principal-name/get-PrincipalNameDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/principal-name/update-PrincipalName/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/principal-name/save-PrincipalName', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/principal-name/delete-PrincipalName/'+id);
  }

}
