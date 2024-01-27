import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IRankPagination, RankPagination } from '../models/rankPagination'
import { Rank } from '../models/rank';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class RankService {
  baseUrl = environment.apiUrl;
  Ranks: Rank[] = [];
  RankPagination = new RankPagination();
  constructor(private http: HttpClient) { }

  getRanks(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IRankPagination>(this.baseUrl + '/rank/get-Ranks', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Ranks = [...this.Ranks, ...response.body.items];
        this.RankPagination = response.body;
        return this.RankPagination;
      })
    );
   
  }

  

  find(id: number) {
    return this.http.get<Rank>(this.baseUrl + '/rank/get-RankDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/rank/update-Rank/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/rank/save-Rank', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/rank/delete-Rank/'+id);
  }

}
