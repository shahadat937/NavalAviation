import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { EndLifeType } from '../../models/EndLifeType';
import { EndLifeTypeService } from '../../service/EndLifeType.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-endlifetype-list',
  templateUrl: './endlifetype-list.component.html',
  styleUrls: ['./endlifetype-list.component.sass']
})
export class EndLifeTypeListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: EndLifeType[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'actions'];
  dataSource: MatTableDataSource<EndLifeType> = new MatTableDataSource();

  selection = new SelectionModel<EndLifeType>(true, []);
  
  constructor(private snackBar: MatSnackBar,private EndLifeTypeService: EndLifeTypeService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getEndLifeTypes();
  }
 
  getEndLifeTypes() {
    this.isLoading = true;
    this.EndLifeTypeService.getEndLifeTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getEndLifeTypes();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getEndLifeTypes();
  } 

  deleteItem(row) {
    const id = row.endLifeTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.EndLifeTypeService.delete(id).subscribe(() => {
          this.getEndLifeTypes();
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
