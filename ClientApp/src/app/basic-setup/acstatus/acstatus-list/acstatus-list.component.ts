import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { AcStatus } from '../../models/AcStatus';
import { AcStatusService } from '../../service/AcStatus.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router, ActivatedRoute } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AirCraftNameService } from '../../service/airCraftName.service';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';


@Component({
  selector: 'app-acstatus-list',
  templateUrl: './acstatus-list.component.html',
  styleUrls: ['./acstatus-list.component.sass']
})
export class AcStatusListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: AcStatus[] = [];
  isLoading = false;
  acAstatusList:any;

  role:any;
  userRole = Role;
  branchId:any;
  traineeId:any;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'aircraftName', 'status','excepRelease','upcomingMaint','plannedDate','requiredDays','remarks','aircraftStatus', 'actions'];
  dataSource: MatTableDataSource<AcStatus> = new MatTableDataSource();

  selection = new SelectionModel<AcStatus>(true, []);
  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private AirCraftNameService: AirCraftNameService,private AcStatusService: AcStatusService,private router: Router,private route: ActivatedRoute,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    
    this.getAcStatuses();
  }
 
  getAcStatuses() {
    this.isLoading = true;
    this.AcStatusService.getAcStatuses(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      console.log(response.items);
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getAcStatuses();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getAcStatuses();
  } 
  //UnderMaint Aircraft
  underMaintAircraft(element) {
    console.log(element);
    this.confirmService.confirm('Confirm Stop message', 'Are You Sure Change This Item?').subscribe(result => {
      if (result) {
        this.AirCraftNameService.underMaintAircraft(element.acStatusId).subscribe(() => {
          this.getAcStatuses();
          this.snackBar.open('Information UnderMaint Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-warning'
          });
        })
        // this.AirCraftNameService.operationalAircraft(element.airCraftNameId).subscribe(() => {
        //   this.getAcStatuses();
        //   this.snackBar.open('Information Operational Successfully ', '', {
        //     duration: 3000,
        //     verticalPosition: 'bottom',
        //     horizontalPosition: 'right',
        //     panelClass: 'snackbar-warning'
        //   });
        // })
      }
      
    })
    
  }
  //Operational  aircraft 
  // operationalAircraft(element) {
  //   this.confirmService.confirm('Confirm Stop message', 'Are You Sure Operational This Item?').subscribe(result => {
  //     if (result) {
  //       this.AirCraftNameService.operationalAircraft(element.airCraftNameId).subscribe(() => {
  
          
  //         this.snackBar.open('Information Operational Successfully ', '', {
  //           duration: 3000,
  //           verticalPosition: 'bottom',
  //           horizontalPosition: 'right',
  //           panelClass: 'snackbar-warning'
  //         });
  //       })
  //     }
  //   })
  // }

  deleteItem(row) {
    const id = row.acStatusId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.AcStatusService.delete(id).subscribe(() => {
          this.getAcStatuses();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })    
  }
}
