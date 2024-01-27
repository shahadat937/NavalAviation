import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {ITestEquipmentDetailPagination, TestEquipmentDetailPagination } from '../models/TestEquipmentDetailPagination'
import { TestEquipmentDetail } from '../models/TestEquipmentDetail';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class TestEquipmentDetailService {
  baseUrl = environment.apiUrl;
  TestEquipmentDetails: TestEquipmentDetail[] = [];
  TestEquipmentDetailPagination = new TestEquipmentDetailPagination();
  constructor(private http: HttpClient) { }


  
  getTestEquipmentDetails(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    //params = params.append('departmentNameId', departmentNameId.toString());
    return this.http.get<ITestEquipmentDetailPagination>(this.baseUrl + '/test-equipment-detail/get-TestEquipmentDetails', { observe: 'response', params })
    .pipe(
      map(response => {
        this.TestEquipmentDetails = [...this.TestEquipmentDetails, ...response.body.items];
        this.TestEquipmentDetailPagination = response.body;
        return this.TestEquipmentDetailPagination;
      })
    );
   
  }
 
  
  getselectedShop(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/shop/get-selectedShops')
  }

  find(id: number) {
    return this.http.get<TestEquipmentDetail>(this.baseUrl + '/test-equipment-detail/get-TestEquipmentDetailDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/test-equipment-detail/update-TestEquipmentDetail/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/test-equipment-detail/save-TestEquipmentDetail', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/test-equipment-detail/delete-TestEquipmentDetail/'+id);
  }

}
