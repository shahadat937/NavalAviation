import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {ISailorRankPagination,SailorRankPagination } from '../models/SailorRankPagination'
import { SailorRank } from '../models/SailorRank';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class SailorRankService {
  baseUrl = environment.apiUrl;
  SailorRanks: SailorRank[] = [];
  SailorRankPagination = new SailorRankPagination();
  constructor(private http: HttpClient) { }

  getSailorRanks(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<ISailorRankPagination>(this.baseUrl + '/sailor-rank/get-SailorRanks', { observe: 'response', params })
    .pipe(
      map(response => {
        this.SailorRanks = [...this.SailorRanks, ...response.body.items];
        this.SailorRankPagination = response.body;
        return this.SailorRankPagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<SailorRank>(this.baseUrl + '/sailor-rank/get-SailorRankDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/sailor-rank/update-SailorRank/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/sailor-rank/save-SailorRank', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/sailor-rank/delete-SailorRank/'+id);
  }

}
