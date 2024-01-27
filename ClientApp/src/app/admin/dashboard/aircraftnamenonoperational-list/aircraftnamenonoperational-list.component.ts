import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DashboardService } from '../service/Dashboard.service';
 
// aircraftnameoperational-list
@Component({
  selector: 'app-aircraftnamenonoperational',
  templateUrl: './aircraftnamenonoperational-list.component.html',
  styleUrls: ['./aircraftnamenonoperational-list.component.sass']
})
export class AircraftNameNonOperationalListComponent implements OnInit {

  masterData = MasterData;
  isLoading = false;

  pendingDemandList:any;
  CountpendingDemand:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  groupArrays:{ schoolName: string; courses: any; }[];

  demandName:string;
  nonOperationalAircraftNameList:any[];

  displayedColumns: string[] = [ 'ser', 'schoolName', 'name', 'manufacturer','manufacturerMobile', 'maintenenceState'];
  
  constructor(private snackBar: MatSnackBar, private dashboardService: DashboardService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
   this.getNonOperatinalAircraftNameCount();
  }
  getNonOperatinalAircraftNameCount(){
    this.dashboardService.getNonOperatinalAircraftNameCount(0).subscribe(response => {   
      this.nonOperationalAircraftNameList=response;
      const groups = this.nonOperationalAircraftNameList.reduce((groups, courses) => {
        const schoolName = courses.schoolName;
        if (!groups[schoolName]) {
          groups[schoolName] = [];
        }
        groups[schoolName].push(courses);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((schoolName) => {
        return {
          schoolName,
          courses: groups[schoolName]
        };
      });
      console.log("");
    })
  }
}
