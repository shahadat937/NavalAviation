import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router,ActivatedRoute } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DashboardService } from '../service/Dashboard.service';
import { RunningHourService } from '../../../basic-setup/service/runningHour.service';

@Component({
  selector: 'app-flyingdetails',
  templateUrl: './flyingdetails-list.component.html',
  styleUrls: ['./flyingdetails-list.component.sass']
})
export class FlyingDetailsListComponent implements OnInit {

  masterData = MasterData;
  isLoading = false;

  flyingdetailsList:any;
  Countflyingdetails:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  demandName:string;

  displayedColumns: string[] = ['ser', 'airCraftName', 'flightDate','flightTimeHr', 'flightTimeMin'];
  
  constructor(private snackBar: MatSnackBar,private RunningHourService: RunningHourService, private dashboardService: DashboardService,private router: Router,private route: ActivatedRoute,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    var deptid = this.route.snapshot.paramMap.get('departmentNameId'); 
    var airCraftid = this.route.snapshot.paramMap.get('airCraftNameId'); 
    this.RunningHourService.getRunningHourListByDepartmentAndAirCraftName(Number(airCraftid),Number(deptid)).subscribe(res=>{
      this.flyingdetailsList=res
      console.log( this.flyingdetailsList);
    });
  }
  
}
