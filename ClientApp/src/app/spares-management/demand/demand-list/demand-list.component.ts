// import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
// import { MatPaginator, PageEvent } from '@angular/material/paginator';
// import { MatTableDataSource } from '@angular/material/table';
// import { Demand } from '../../../spares-management/models/Demand';
// import { DemandService } from '../../../spares-management/service/Demand.service';
// import { SelectionModel } from '@angular/cdk/collections';
// import { Router } from '@angular/router';
// import { ConfirmService } from 'src/app/core/service/confirm.service';
// import{MasterData} from 'src/assets/data/master-data';
// import { MatSnackBar } from '@angular/material/snack-bar';
// import { ProcurementService } from '../../service/Procurement.service';

// @Component({
//   selector: 'app-demand-list',
//   templateUrl: './demand-list.component.html',
//   styleUrls: ['./demand-list.component.sass']
// })
// export class DemandListComponent implements OnInit {

//   masterData = MasterData;
//   //ELEMENT_DATA: Demand[] = [];
//   isLoading = false;
//   StatusByDeptName:string = 'All';
//   StatusList:any;
//   CountStatus:any;
  
//   paging = {
//     pageIndex: this.masterData.paging.pageIndex,
//     pageSize: this.masterData.paging.pageSize,
//     length: 1
//   }
//   searchText="";
//   displayedColumns: string[] = [ 'ser', 'demandNo','partNo', 'nameOfItem','demandCompleteStatus','procurementCompleteStatus','sftStatus'];
//   //displayedColumns: string[] = [ 'ser','departmentName','demandDate','itemDetail','demandQty', 'deno',/*'demandLetterNo','specDoc',*/'isActive', 'actions'];
//   dataSource: MatTableDataSource<Demand> = new MatTableDataSource();

//   selection = new SelectionModel<Demand>(true, []);
  
//   constructor(private snackBar: MatSnackBar,private ProcurementService: ProcurementService,private DemandService: DemandService,private router: Router,private confirmService: ConfirmService) { }
  
//   ngOnInit() {
//     this.getDemands();
//     this.getDemandSpGetCompleteStatus();
//   }
 
//   getDemands() {
//     this.isLoading = true;
//     this.DemandService.getDemands(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.masterData.sparescategory.spares).subscribe(response => {
      
//       this.dataSource.data = response.items;
//       console.log(this.dataSource.data )
//       this.paging.length = response.totalItemsCount    
//       this.isLoading = false;
//     })
    
//   }
//   pageChanged(event: PageEvent) {
//     this.paging.pageIndex = event.pageIndex
//     this.paging.pageSize = event.pageSize
//     this.paging.pageIndex = this.paging.pageIndex + 1
//     this.getDemands();
//   }

//   applyFilter(searchText: any){ 
//     this.searchText = searchText;
//     this.getDemands();
//   } 
//   getDemandSpGetCompleteStatus(){
//     this.DemandService.getDemandSpGetCompleteStatus(0).subscribe(response => { 
//       this.getDemands=response;
//       this.CountStatus = response.length;
//       console.log(this.getDemands)
//     })
//   }
//   StatusByDept(id, name){  
//     this.StatusByDeptName = name;
//     //let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
//     this.DemandService.getDemandSpGetCompleteStatus(id).subscribe(response => {   
//       this.StatusList=response;
//       this.CountStatus = response.length;
//     }) 
//   }
  

//   deleteItem(row) {
//     const id = row.demandId; 
//     this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
//       console.log(result);
//       if (result) {
//         this.DemandService.delete(id).subscribe(() => {
//           this.getDemands();
//           this.snackBar.open('Information Deleted Successfully ', '', {
//             duration: 2000,
//             verticalPosition: 'bottom',
//             horizontalPosition: 'right',
//             panelClass: 'snackbar-danger'
//           });
//         })
//       }
//     })    
//   }
// }
