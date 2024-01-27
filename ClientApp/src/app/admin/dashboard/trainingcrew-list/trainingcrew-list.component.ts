import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DashboardService } from '../service/Dashboard.service';
 

@Component({
  selector: 'app-trainingcrew',
  templateUrl: './trainingcrew-list.component.html',
  styleUrls: ['./trainingcrew-list.component.sass']
})
export class TrainingCrewListComponent implements OnInit {

  masterData = MasterData;
  isLoading = false;

  TrainingCrewList:any;
  CountTrainingCrew:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  deptName:string;

  displayedColumns: string[] = [ 'ser', 'deptName', 'name'];
  
  constructor(private snackBar: MatSnackBar, private dashboardService: DashboardService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.inActiveItem(0, 'All');
  }
  inActiveItem(id, name){  
    this.deptName = name;
    this.dashboardService.getTrainingCrew(id).subscribe(response => {
      this.TrainingCrewList = response; 
      this.CountTrainingCrew = response.length;
    }) 
  }
  
}
