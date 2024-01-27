import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {IDenoPagination,DenoPagination } from '../models/DenoPagination'
import { Deno } from '../models/Deno';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class DenoService {
  baseUrl = environment.apiUrl;
  Denos: Deno[] = [];
  DenoPagination = new DenoPagination();
  constructor(private http: HttpClient) { }

  getDenos(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<IDenoPagination>(this.baseUrl + '/deno/get-denos', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Denos = [...this.Denos, ...response.body.items];
        this.DenoPagination = response.body;
        return this.DenoPagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<Deno>(this.baseUrl + '/deno/get-denoDetail/' + id);
  }


  getselecteddivision(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/deno/get-selectedDeno')
  }
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/deno/update-deno/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/deno/save-deno', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/deno/delete-deno/'+id);
  }

}
