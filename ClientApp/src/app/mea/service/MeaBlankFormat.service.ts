import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IMeaBlankFormatPagination, MeaBlankFormatPagination } from '../models/MeaBlankFormatPagination'
import { MeaBlankFormat } from '../models/MeaBlankFormat';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class MeaBlankFormatService {
  baseUrl = environment.apiUrl;
  MeaBlankFormats: MeaBlankFormat[] = [];
  MeaBlankFormatPagination = new MeaBlankFormatPagination();
  constructor(private http: HttpClient) { }


  getMeaBlankFormats(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IMeaBlankFormatPagination>(this.baseUrl + '/mea-blank-format/get-MeaBlankFormats', { observe: 'response', params })
    .pipe(
      map(response => {
        this.MeaBlankFormats = [...this.MeaBlankFormats, ...response.body.items];
        this.MeaBlankFormatPagination = response.body;
        return this.MeaBlankFormatPagination;
      })
    );
   
  }

  
  // getselectedDepartmentNames(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  // }
  // getSelectedSchoolName(baseNameId){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  // }
  // getselectedPresentStates(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/present-state/get-selectedPresentState')
  // }
  // getselectedTrad(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/trade/get-selectedTrades')
  // }
  // getSelectedItemNameAndPattNo(departmentNameId){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/item-detail/get-itemNameAndPartNoByDepartmentNameId?departmentNameId='+departmentNameId)
  // }
  // getselectedConditionofItem(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/condition-of-item/get-selectedConditionOfItem')
  // }

  find(id: number) {
    return this.http.get<MeaBlankFormat>(this.baseUrl + '/mea-blank-format/get-MeaBlankFormatDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/mea-blank-format/update-MeaBlankFormat/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/mea-blank-format/save-MeaBlankFormat', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/mea-blank-format/delete-MeaBlankFormat/'+id);
  }

}
