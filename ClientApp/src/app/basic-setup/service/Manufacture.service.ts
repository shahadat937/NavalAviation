import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IManufacturePagination,ManufacturePagination } from '../models/ManufacturePagination'
import { Manufacture } from '../models/Manufacture';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class ManufactureService {
  baseUrl = environment.apiUrl;
  Manufactures: Manufacture[] = [];
  ManufacturePagination = new ManufacturePagination();
  constructor(private http: HttpClient) { }

  getManufactures(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IManufacturePagination>(this.baseUrl + '/manufacture/get-Manufactures', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Manufactures = [...this.Manufactures, ...response.body.items];
        this.ManufacturePagination = response.body;
        return this.ManufacturePagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<Manufacture>(this.baseUrl + '/manufacture/get-ManufactureDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/manufacture/update-Manufacture/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/manufacture/save-Manufacture', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/manufacture/delete-Manufacture/'+id);
  }

}
