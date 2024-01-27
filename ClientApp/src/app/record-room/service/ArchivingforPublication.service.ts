import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IArchivingforPublicationPagination, ArchivingforPublicationPagination } from '../models/ArchivingforPublicationPagination'
import { ArchivingforPublication } from '../models/ArchivingforPublication';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class ArchivingforPublicationService {
  baseUrl = environment.apiUrl;
  ArchivingforPublications: ArchivingforPublication[] = [];
  ArchivingforPublicationPagination = new ArchivingforPublicationPagination();
  constructor(private http: HttpClient) { }

  getArchivingforPublications(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IArchivingforPublicationPagination>(this.baseUrl + '/archiving-for-publication/get-ArchivingforPublications', { observe: 'response', params })
    .pipe(
      map(response => {
        this.ArchivingforPublications = [...this.ArchivingforPublications, ...response.body.items];
        this.ArchivingforPublicationPagination = response.body;
        return this.ArchivingforPublicationPagination;
      })
    );
   
  }
  getArchivingforPublicationListByDepartmentName( departmentNameId:number){
    return this.http.get<ArchivingforPublication[]>(this.baseUrl + '/archiving-for-publication/get-archivingforPublicationListByDepartmentNameId?departmentNameId='+departmentNameId);
   }
  //  getItemNameByDepartmentName( departmentNameId:number){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/issue-register/get-itemDetailForSurveyByDepartmentNameId?departmentNameId='+departmentNameId);
  //  }
  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  getselecteNameofPublication(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/name-of-publication/get-selectedNameofPublications')
  }
  getselecteAircraft(departmentNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/air-craft-name/get-selectedAirCraftNameByDepartmentId?departmentNameId='+departmentNameId)
  }

  find(id: number) {
    return this.http.get<ArchivingforPublication>(this.baseUrl + '/archiving-for-publication/get-ArchivingforPublicationDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/archiving-for-publication/update-ArchivingforPublication/'+id, model);
  }
  submit(model: any) {
    console.log(model)
    return this.http.post(this.baseUrl + '/archiving-for-publication/save-ArchivingforPublication', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/archiving-for-publication/delete-ArchivingforPublication/'+id);
  }

}
