import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {INameofPublicationPagination, NameofPublicationPagination } from '../models/NameofPublicationPagination'
import { NameofPublication } from '../models/NameofPublication';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class NameofPublicationService {
  baseUrl = environment.apiUrl;
  NameofPublications: NameofPublication[] = [];
  NameofPublicationPagination = new NameofPublicationPagination();
  constructor(private http: HttpClient) { }


  getNameofPublications(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<INameofPublicationPagination>(this.baseUrl + '/name-of-publication/get-NameofPublications', { observe: 'response', params })
    .pipe(
      map(response => {
        this.NameofPublications = [...this.NameofPublications, ...response.body.items];
        this.NameofPublicationPagination = response.body;
        return this.NameofPublicationPagination;
      })
    );
   
  }

  
  getselectedDepartmentNames(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/department-name/get-selectedDepartmentNames')
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }

  find(id: number) {
    return this.http.get<NameofPublication>(this.baseUrl + '/name-of-publication/get-NameofPublicationDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/name-of-publication/update-NameofPublication/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/name-of-publication/save-NameofPublication', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/name-of-publication/delete-NameofPublication/'+id);
  }

}
