import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {ISupplierPagination,SupplierPagination } from '../models/SupplierPagination'
import { Supplier } from '../models/Supplier';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class SupplierService {
  baseUrl = environment.apiUrl;
  Suppliers: Supplier[] = [];
  SupplierPagination = new SupplierPagination();
  constructor(private http: HttpClient) { }

  getSuppliers(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<ISupplierPagination>(this.baseUrl + '/suppliers/get-suppliers', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Suppliers = [...this.Suppliers, ...response.body.items];
        this.SupplierPagination = response.body;
        return this.SupplierPagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<Supplier>(this.baseUrl + '/suppliers/get-supplierDetail/' + id);
  }

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/suppliers/update-supplier/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/suppliers/save-supplier', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/suppliers/delete-supplier/'+id);
  }

}
