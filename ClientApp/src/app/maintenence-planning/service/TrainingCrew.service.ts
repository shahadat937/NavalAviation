import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {ITrainingCrewPagination, TrainingCrewPagination } from '../models/TrainingCrewPagination'
import { TrainingCrew } from '../models/TrainingCrew';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class TrainingCrewService {
  baseUrl = environment.apiUrl;
  TrainingCrews: TrainingCrew[] = [];
  TrainingCrewPagination = new TrainingCrewPagination();
  constructor(private http: HttpClient) { }


  getTrainingCrews(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<ITrainingCrewPagination>(this.baseUrl + '/training-crew/get-TrainingCrews', { observe: 'response', params })
    .pipe(
      map(response => {
        this.TrainingCrews = [...this.TrainingCrews, ...response.body.items];
        this.TrainingCrewPagination = response.body;
        return this.TrainingCrewPagination;
      })
    );
   
  }
  

  getselectedRank(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/rank/get-selectedRanks')
  }
  getselectedSailorRank(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/sailor-rank/get-selectedSailorRank')
  }
  getselectedOfficersStatuses(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/officers-status/get-selectedOfficersStatuses')
  }
  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  
 getTrainingCrewListByDepartmentNameId(text:string, departmentNameId:number,employeeTypeId){
  return this.http.get<TrainingCrew[]>(this.baseUrl + '/training-crew/get-TrainingCrewListByDepartmentNameId?text='+text+'&departmentNameId='+departmentNameId+'&employeeTypeId='+employeeTypeId+'');
 }


 getTrainingCrewListByDepartmentNameIdForSailor(text:string,departmentNameId:number,employeeTypeId){
  return this.http.get<TrainingCrew[]>(this.baseUrl + '/training-crew/get-TrainingCrewListByDepartmentNameIdForSailor?text='+text+'&departmentNameId='+departmentNameId+'&employeeTypeId='+employeeTypeId+'');
 }

 UpdateCrewStatus( trainingCrewId,officersStatusId){
  return this.http.get<TrainingCrew[]>(this.baseUrl + '/training-crew/change-OfficerStatus?trainingCrewId='+trainingCrewId+'&officerStatusId='+officersStatusId);
 }
  
 getSelectedPresentBillet(){
  return this.http.get<SelectedModel[]>(this.baseUrl + '/present-billet/get-selectedPresentBillet');
 }

  find(id: number) {
    return this.http.get<TrainingCrew>(this.baseUrl + '/training-crew/get-TrainingCrewDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/training-crew/update-TrainingCrew/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/training-crew/save-TrainingCrew', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/training-crew/delete-TrainingCrew/'+id);
  }

}
