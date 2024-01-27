import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IOccasionOfDemandPagination, OccasionOfDemandPagination } from '../models/occasionOfDemandPagination'
import { OccasionOfDemand } from '../models/occasionOfDemand';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class OccasionOfDemandService {
  baseUrl = environment.apiUrl;
  OccasionOfDemands: OccasionOfDemand[] = [];
  OccasionOfDemandPagination = new OccasionOfDemandPagination();
  constructor(private http: HttpClient) { }

  getOccasionOfDemands(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IOccasionOfDemandPagination>(this.baseUrl + '/occasion-of-demand/get-OccasionOfDemands', { observe: 'response', params })
    .pipe(
      map(response => {
        this.OccasionOfDemands = [...this.OccasionOfDemands, ...response.body.items];
        this.OccasionOfDemandPagination = response.body;
        return this.OccasionOfDemandPagination;
      })
    );
   
  }

  getSelectedFiscalYear(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/fiscal-year/get-selectedFiscalYear')
  }

  find(id: number) {
    return this.http.get<OccasionOfDemand>(this.baseUrl + '/occasion-of-demand/get-OccasionOfDemandDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/occasion-of-demand/update-OccasionOfDemand/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/occasion-of-demand/save-OccasionOfDemand', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/occasion-of-demand/delete-OccasionOfDemand/'+id);
  }

}
