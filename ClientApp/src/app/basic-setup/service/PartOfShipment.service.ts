import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IPartOfShipmentPagination,PartOfShipmentPagination } from '../models/PartOfShipmentPagination'
import { PartOfShipment } from '../models/PartOfShipment';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class PartOfShipmentService {
  baseUrl = environment.apiUrl;
  PartOfShipments: PartOfShipment[] = [];
  PartOfShipmentPagination = new PartOfShipmentPagination();
  constructor(private http: HttpClient) { }

  getPartOfShipments(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IPartOfShipmentPagination>(this.baseUrl + '/part-of-shipment/get-PartOfShipments', { observe: 'response', params })
    .pipe(
      map(response => {
        this.PartOfShipments = [...this.PartOfShipments, ...response.body.items];
        this.PartOfShipmentPagination = response.body;
        return this.PartOfShipmentPagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<PartOfShipment>(this.baseUrl + '/part-of-shipment/get-PartOfShipmentDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/part-of-shipment/update-PartOfShipment/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/part-of-shipment/save-PartOfShipment', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/part-of-shipment/delete-PartOfShipment/'+id);
  }

}
