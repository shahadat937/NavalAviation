import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IIssueStatusPagination, IssueStatusPagination } from '../models/IssueStatusPagination'
import { IssueStatus } from '../models/IssueStatus';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class IssueStatusService {
  baseUrl = environment.apiUrl;
  IssueStatuses: IssueStatus[] = [];
  IssueStatusPagination = new IssueStatusPagination();
  constructor(private http: HttpClient) { }

  getIssueStatuses(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IIssueStatusPagination>(this.baseUrl + '/issue-status/get-IssueStatuses', { observe: 'response', params })
    .pipe(
      map(response => {
        this.IssueStatuses = [...this.IssueStatuses, ...response.body.items];
        this.IssueStatusPagination = response.body;
        return this.IssueStatusPagination;
      })
    );
   
  }

  

  find(id: number) {
    return this.http.get<IssueStatus>(this.baseUrl + '/issue-status/get-IssueStatusDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/issue-status/update-IssueStatus/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/issue-status/save-IssueStatus', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/issue-status/delete-IssueStatus/'+id);
  }

}
