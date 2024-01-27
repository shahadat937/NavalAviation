import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IDailyAirworthinessFromCategoryPagination, DailyAirworthinessFromCategoryPagination } from '../models/DailyAirworthinessFromCategoryPagination'
import { DailyAirworthinessFromCategory } from '../models/DailyAirworthinessFromCategory';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class DailyAirworthinessFromCategoryService {
  baseUrl = environment.apiUrl;
  DailyAirworthinessFromCategorys: DailyAirworthinessFromCategory[] = [];
  DailyAirworthinessFromCategoryPagination = new DailyAirworthinessFromCategoryPagination();
  constructor(private http: HttpClient) { }

  getDailyAirworthinessFromCategorys(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IDailyAirworthinessFromCategoryPagination>(this.baseUrl + '/daily-airworthiness-from-category/get-DailyAirworthinessFromCategories', { observe: 'response', params })
    .pipe(
      map(response => {
        this.DailyAirworthinessFromCategorys = [...this.DailyAirworthinessFromCategorys, ...response.body.items];
        this.DailyAirworthinessFromCategoryPagination = response.body;
        return this.DailyAirworthinessFromCategoryPagination;
      })
    );
   
  }
  getDailyAirworthinessFromCategoryListByDepartmentName( departmentNameId:number){
    return this.http.get<DailyAirworthinessFromCategory[]>(this.baseUrl + '/daily-airworthiness-from-category/get-dailyAirworthinessFromListByDepartmentNameId?departmentNameId='+departmentNameId);
   }
  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  find(id: number) {
    return this.http.get<DailyAirworthinessFromCategory>(this.baseUrl + '/daily-airworthiness-from-category/get-DailyAirworthinessFromCategoryDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/daily-airworthiness-from-category/update-DailyAirworthinessFromCategory/'+id, model);
  }
  submit(model: any) {
    console.log(model)
    return this.http.post(this.baseUrl + '/daily-airworthiness-from-category/save-DailyAirworthinessFromCategory', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/daily-airworthiness-from-category/delete-DailyAirworthinessFromCategory/'+id);
  }

}
