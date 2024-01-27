import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { OverhaulingType } from '../../models/OverhaulingType';
import { OverhaulingTypeService } from '../../service/OverhaulingType.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-overhaulingtype-list',
  templateUrl: './overhaulingtype-list.component.html',
  styleUrls: ['./overhaulingtype-list.component.sass']
})
export class OverhaulingTypeListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: OverhaulingType[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'actions'];
  dataSource: MatTableDataSource<OverhaulingType> = new MatTableDataSource();

  selection = new SelectionModel<OverhaulingType>(true, []);
  
  constructor(private snackBar: MatSnackBar,private OverhaulingTypeService: OverhaulingTypeService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getOverhaulingTypes();
  }
 
  getOverhaulingTypes() {
    this.isLoading = true;
    this.OverhaulingTypeService.getOverhaulingTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getOverhaulingTypes();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getOverhaulingTypes();
  } 

  deleteItem(row) {
    const id = row.overhaulingTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.OverhaulingTypeService.delete(id).subscribe(() => {
          this.getOverhaulingTypes();
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
