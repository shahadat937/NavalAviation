import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { DepartmentName } from '../../models/DepartmentName';
import { DepartmentNameService } from '../../service/DepartmentName.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-departmentname',
  templateUrl: './departmentname-list.component.html',
  styleUrls: ['./departmentname-list.component.sass']
})
export class DepartmentNameListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: DepartmentName[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks',  'actions'];
  dataSource: MatTableDataSource<DepartmentName> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private DepartmentNameService: DepartmentNameService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getDepartments();
  }
 
  getDepartments() {
    this.isLoading = true;
    this.DepartmentNameService.getDepartments(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getDepartments();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getDepartments();
  }

  deleteItem(row) {
    const id = row.departmentNameId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      console.log(result);
      if (result) {
        this.DepartmentNameService.delete(id).subscribe(() => {
          this.getDepartments();
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
