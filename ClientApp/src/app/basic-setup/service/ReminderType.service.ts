import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IReminderTypePagination, ReminderTypePagination } from '../models/ReminderTypePagination'
import { ReminderType } from '../models/ReminderType';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class ReminderTypeService {
  baseUrl = environment.apiUrl;
  ReminderTypes: ReminderType[] = [];
  ReminderTypePagination = new ReminderTypePagination();
  constructor(private http: HttpClient) { }

  getremindertype(pageNumber, pageSize, searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
    return this.http.get<IReminderTypePagination>(this.baseUrl + '/reminder-type/get-reminderTypes', { observe: 'response', params })
    .pipe(
      map(response => {
        this.ReminderTypes = [...this.ReminderTypes, ...response.body.items];
        this.ReminderTypePagination = response.body;
        return this.ReminderTypePagination;
      })
    );
   
  }

  getselectedremindertypes(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/reminder-type/get-selectedReminderTypes')
  }

  find(id: number) {
    return this.http.get<ReminderType>(this.baseUrl + '/reminder-type/get-reminderTypeDetail/' + id);
  }
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/reminder-type/update-reminderType/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/reminder-type/save-reminderType', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/reminder-type/delete-reminderType/'+id);
  }

}
