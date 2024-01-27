import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IFiscalYearPagination,FiscalYearPagination } from '../models/FiscalYearPagination'
import { FiscalYear } from '../models/FiscalYear';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class FiscalYearService {
  baseUrl = environment.apiUrl;
  FiscalYears: FiscalYear[] = [];
  FiscalYearPagination = new FiscalYearPagination();
  constructor(private http: HttpClient) { }

  getFiscalYears(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return this.http.get<IFiscalYearPagination>(this.baseUrl + '/fiscal-year/get-fiscalYears', { observe: 'response', params })
    .pipe(
      map(response => {
        this.FiscalYears = [...this.FiscalYears, ...response.body.items];
        this.FiscalYearPagination = response.body;
        return this.FiscalYearPagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<FiscalYear>(this.baseUrl + '/fiscal-year/get-fiscalYearDetail/' + id);
  }


  getselecteddivision(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/fiscal-year/get-selectedFiscalYear')
  }
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/fiscal-year/update-fiscalYear/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/fiscal-year/save-fiscalYear', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/fiscal-year/delete-fiscalYear/'+id);
  }

}
