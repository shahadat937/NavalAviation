import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {ITradePagination, TradePagination } from '../models/TradePagination'
import { Trade } from '../models/Trade';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class TradeService {
  baseUrl = environment.apiUrl;
  Trades: Trade[] = [];
  TradePagination = new TradePagination();
  constructor(private http: HttpClient) { }

  getTrade(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<ITradePagination>(this.baseUrl + '/trade/get-Trades', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Trades = [...this.Trades, ...response.body.items];
        this.TradePagination = response.body;
        return this.TradePagination;
      })
    );
   
  }

  getselectedTrades(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/trade/get-selectedTrades')
  }

  find(id: number) {
    return this.http.get<Trade>(this.baseUrl + '/trade/get-tradeDetail/' + id);
  }
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/trade/update-trade/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/trade/save-trade', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/trade/delete-trade/'+id);
  }

}
