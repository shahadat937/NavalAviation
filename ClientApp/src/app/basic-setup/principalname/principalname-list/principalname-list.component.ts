import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { PrincipalName } from '../../models/PrincipalName';
import { PrincipalNameService } from '../../service/PrincipalName.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-principalname-list',
  templateUrl: './principalname-list.component.html',
  styleUrls: ['./principalname-list.component.sass']
})
export class PrincipalNameListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: PrincipalName[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'actions'];
  dataSource: MatTableDataSource<PrincipalName> = new MatTableDataSource();

  selection = new SelectionModel<PrincipalName>(true, []);
  
  constructor(private snackBar: MatSnackBar,private PrincipalNameService: PrincipalNameService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getPrincipalNames();
  }
 
  getPrincipalNames() {
    this.isLoading = true;
    this.PrincipalNameService.getPrincipalNames(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getPrincipalNames();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getPrincipalNames();
  } 

  deleteItem(row) {
    const id = row.principalNameId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.PrincipalNameService.delete(id).subscribe(() => {
          this.getPrincipalNames();
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
