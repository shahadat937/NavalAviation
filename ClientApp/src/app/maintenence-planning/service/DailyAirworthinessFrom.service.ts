import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { environment } from "src/environments/environment";
import {
  IDailyAirworthinessFromPagination,
  DailyAirworthinessFromPagination,
} from "../models/DailyAirworthinessFromPagination";
import { DailyAirworthinessFrom } from "../models/DailyAirworthinessFrom";
import { map } from "rxjs";
import { SelectedModel } from "src/app/core/models/selectedModel";
@Injectable({
  providedIn: "root",
})
export class DailyAirworthinessFromService {
  baseUrl = environment.apiUrl;
  DailyAirworthinessFroms: DailyAirworthinessFrom[] = [];
  DailyAirworthinessFromPagination = new DailyAirworthinessFromPagination();
  constructor(private http: HttpClient) {}

  getDailyAirworthinessFroms(pageNumber, pageSize, searchText) {
    let params = new HttpParams();

    params = params.append("searchText", searchText.toString());
    params = params.append("pageNumber", pageNumber.toString());
    params = params.append("pageSize", pageSize.toString());

    return this.http
      .get<IDailyAirworthinessFromPagination>(
        this.baseUrl + "/daily-airworthiness-from/get-DailyAirworthinessFroms",
        { observe: "response", params }
      )
      .pipe(
        map((response) => {
          this.DailyAirworthinessFroms = [
            ...this.DailyAirworthinessFroms,
            ...response.body.items,
          ];
          this.DailyAirworthinessFromPagination = response.body;
          return this.DailyAirworthinessFromPagination;
        })
      );
  }
  getDailyAirworthinessFromListByDepartmentName(departmentNameId, docType) {
    return this.http.get<any[]>(
      this.baseUrl +
        "/daily-airworthiness-from/get-dailyAirworthinessFromListByDepartmentNameId?departmentNameId=" +
        departmentNameId +
        " &docType=" +
        docType
    );
  }
  getselectedDepartmentNames() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl + "/department-name/get-selectedDepartmentNames"
    );
  }
  getDailyAirworthinessFromCategory() {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/daily-airworthiness-from-category/get-selectedDailyAirworthinessFromCategories"
    );
  }
  getAircraftName(id: number) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/air-craft-name/get-selectedAirCraftNameByDepartmentId?departmentNameId=" +
        id
    );
  }
  getSelectedSchoolName(baseNameId) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/base-School-name/get-selectedSchoolNames?thirdLevel=" +
        baseNameId
    );
  }
  find(id: number) {
    return this.http.get<DailyAirworthinessFrom>(
      this.baseUrl +
        "/daily-airworthiness-from/get-DailyAirworthinessFromDetail/" +
        id
    );
  }
  update(id: number, model: any) {
    return this.http.put(
      this.baseUrl +
        "/daily-airworthiness-from/update-DailyAirworthinessFrom/" +
        id,
      model
    );
  }
  submit(model: any) {
    console.log(model);
    return this.http.post(
      this.baseUrl + "/daily-airworthiness-from/save-DailyAirworthinessFrom",
      model
    );
  }
  delete(id: number) {
    return this.http.delete(
      this.baseUrl +
        "/daily-airworthiness-from/delete-DailyAirworthinessFrom/" +
        id
    );
  }
}
