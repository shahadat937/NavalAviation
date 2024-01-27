import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MeaSquadronState } from '../../models/MeaSquadronState';
import { MeaSquadronStateService } from '../../service/MeaSquadronState.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
 

@Component({
  selector: 'app-measquadronstate',
  templateUrl: './measquadronstate-list.component.html',
  styleUrls: ['./measquadronstate-list.component.sass']
})
export class MeaSquadronStateListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: MeaSquadronState[] = [];
  isLoading = false;
  roleDisable: boolean = true;
  userRole = Role;
  status:any;
  traineeId:any;
  role:any;
  branchId:any;
  groupArrays: { departmentName: string; datas: any }[];
  completeStatus:any = 0;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'itemName', 'description','trad', 'workOrderNo','dateofSubmition', 'workShop','remarks','status', 'actions'];
  dataSource: MatTableDataSource<MeaSquadronState> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar,private route: ActivatedRoute,private authService: AuthService, private MeaSquadronStateService: MeaSquadronStateService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
     this.status=this.route.snapshot.paramMap.get('status');
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)
    this.getMeaSquadronStates();

    if(this.role == this.userRole.CO || this.role == this.userRole.MEA){
      this.roleDisable = false;
    }
  }
 
  getMeaSquadronStates() {
    this.isLoading = true;
    this.MeaSquadronStateService.getMeaSquadronStates(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.completeStatus).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount;
      console.log(response.items)  
      this.isLoading = false;

      // this gives an object with dates as keys
      // const groups = this.dataSource.data.reduce((groups, datas) => {
      //   const departmentName = datas.departmentName;
      //   if (!groups[departmentName]) {
      //     groups[departmentName] = [];
      //   }
      //   groups[departmentName].push(datas);
      //   return groups;
      // }, {});

      // // Edit: to add it in the array format instead
      // this.groupArrays = Object.keys(groups).map((departmentName) => {
      //   return {
      //     departmentName,
      //     datas: groups[departmentName],
      //   };
      // });

      // console.log(this.groupArrays);
    })
  }
  inActiveItem(row){
    const id = row.meaSquadronStateId; 
          this.confirmService.confirm('Confirm Accept message', 'Are You Sure Accept This Item').subscribe(result => {
            if (result) {
              console.log(result)
          this.MeaSquadronStateService.acceptMeaSquadronState(id).subscribe(() => {
            //this.getselectedPresentStocks(this.departmentId);
            this.reloadCurrentRoute();
            this.snackBar.open('Information Accepted Successfully ', '', {
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-warning'
            });
          })
        }
      })
    
}
inUnActiveItem(row){
  const id = row.meaSquadronStateId; 
        this.confirmService.confirm('Confirm  Not Accept message', 'Are You Sure Not Accept This Item').subscribe(result => {
          if (result) {
            console.log(result)
        this.MeaSquadronStateService.cancelMeaSquadronState(id).subscribe(() => {
          //this.getselectedPresentStocks(this.departmentId);
          this.reloadCurrentRoute();
          this.snackBar.open('Information Not Accepted Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-warning'
          });
        })
      }
    })
  
}
inCompletedItem(row){
  const id = row.meaSquadronStateId; 
        this.confirmService.confirm('Confirm  Completed message', 'Are You Sure  Completed This Item').subscribe(result => {
          if (result) {
            console.log(result)
        this.MeaSquadronStateService.completedMeaSquadronState(id).subscribe(() => {
          //this.getselectedPresentStocks(this.departmentId);
          this.reloadCurrentRoute();
          this.snackBar.open('Information  Completed Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-warning'
          });
        })
      }
    })
  
}
inUnCompletedItem(row){
  const id = row.meaSquadronStateId; 
        this.confirmService.confirm('Confirm  Pending message', 'Are You Sure Pending This Item').subscribe(result => {
          if (result) {
            console.log(result)
        this.MeaSquadronStateService.unCompletedMeaSquadronState(id).subscribe(() => {
          //this.getselectedPresentStocks(this.departmentId);
          this.reloadCurrentRoute();
          this.snackBar.open('Information Pending Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-warning'
          });
        })
      }
    })
  
}
reloadCurrentRoute() {
  let currentUrl = this.router.url;
  this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
      this.router.navigate([currentUrl]);
  });
}
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getMeaSquadronStates();
  }
  
  applyFilter(searchText: any,completeStatus: any){ 
    this.searchText = searchText;
    this.completeStatus = completeStatus;
    this.getMeaSquadronStates();
  }

  deleteItem(row) {
    const id = row.meaSquadronStateId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.MeaSquadronStateService.delete(id).subscribe(() => {
          this.getMeaSquadronStates();
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
