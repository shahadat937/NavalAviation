import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IAuthorityPagination, AuthorityPagination } from '../models/authorityPagination'
import { Authority } from '../models/authority';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class AuthorityService {
  baseUrl = environment.apiUrl;
  Authoritys: Authority[] = [];
  AuthorityPagination = new AuthorityPagination();
  constructor(private http: HttpClient) { }

  getAuthoritys(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IAuthorityPagination>(this.baseUrl + '/authority/get-Authoritys', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Authoritys = [...this.Authoritys, ...response.body.items];
        this.AuthorityPagination = response.body;
        return this.AuthorityPagination;
      })
    );
   
  }

  

  find(id: number) {
    return this.http.get<Authority>(this.baseUrl + '/authority/get-AuthorityDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/authority/update-Authority/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/authority/save-Authority', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/authority/delete-Authority/'+id);
  }

}
