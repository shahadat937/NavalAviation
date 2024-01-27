import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {INoticeBoardPagination,NoticeBoardPagination } from '../models/NoticeBoardPagination'
import { NoticeBoard } from '../models/NoticeBoard';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class NoticeBoardService {
  baseUrl = environment.apiUrl;
  NoticeBoards: NoticeBoard[] = [];
  NoticeBoardPagination = new NoticeBoardPagination();
  constructor(private http: HttpClient) { }

  getNoticeBoards(pageNumber, pageSize, searchText,departmentNameId) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('departmentNameId', departmentNameId.toString());

    
    return this.http.get<INoticeBoardPagination>(this.baseUrl + '/notice-board/get-noticeBoards', { observe: 'response', params })
    .pipe(
      map(response => {
        this.NoticeBoards = [...this.NoticeBoards, ...response.body.items];
        this.NoticeBoardPagination = response.body;
        return this.NoticeBoardPagination;
      })
    );
   
  }

  find(id: number) {
    return this.http.get<NoticeBoard>(this.baseUrl + '/notice-board/get-noticeBoardDetail/' + id);
  }


  getselecteddivision(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/notice-board/get-selectedNoticeBoard')
  }
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/notice-board/update-noticeBoard/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/notice-board/save-noticeBoard', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/notice-board/delete-noticeBoard/'+id);
  }

}
