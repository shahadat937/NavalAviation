import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {ICallibrationStatePagination, CallibrationStatePagination } from '../models/CallibrationStatePagination'
import { CallibrationState } from '../models/CallibrationState';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class CallibrationStateService {
  baseUrl = environment.apiUrl;
  CallibrationStates: CallibrationState[] = [];
  CallibrationStatePagination = new CallibrationStatePagination();
  constructor(private http: HttpClient) { }


  getCallibrationStates(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<ICallibrationStatePagination>(this.baseUrl + '/callibration-state/get-CallibrationStates', { observe: 'response', params })
    .pipe(
      map(response => {
        this.CallibrationStates = [...this.CallibrationStates, ...response.body.items];
        this.CallibrationStatePagination = response.body;
        return this.CallibrationStatePagination;
      })
    );
   
  }

  getCalibrationStateForTools(departmentNameId){
    return this.http.get<any[]>(this.baseUrl + '/callibration-state/get-calibrationStateForToolsSpRequest?departmentNameId='+departmentNameId+'')
  }

  getCalibrationStateListForTools(departmentNameId,searchText){
    return this.http.get<any[]>(this.baseUrl + '/callibration-state/get-calibrationStateListForToolsSpRequest?departmentNameId='+departmentNameId+'&searchText='+searchText+'')
  }

  getCalibrationStateForSpare(departmentNameId){
    return this.http.get<any[]>(this.baseUrl + '/callibration-state/get-calibrationStateForSpareSpRequest?departmentNameId='+departmentNameId+'')
  }

  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getselectedTrades(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/trade/get-selectedTrades')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }

  find(id: number) {
    return this.http.get<CallibrationState>(this.baseUrl + '/callibration-state/get-CallibrationStateDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/callibration-state/update-CallibrationState/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/callibration-state/save-CallibrationState', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/callibration-state/delete-CallibrationState/'+id);
  }

}
