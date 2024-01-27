import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MeaBlankFormat } from '../../models/MeaBlankFormat';
import { MeaBlankFormatService } from '../../service/MeaBlankFormat.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-meablankformat',
  templateUrl: './meablankformat-list.component.html',
  styleUrls: ['./meablankformat-list.component.sass']
})
export class MeaMeaBlankFormatListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: MeaBlankFormat[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name', 'remarks', 'doc', 'actions'];
  dataSource: MatTableDataSource<MeaBlankFormat> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private MeaBlankFormatService: MeaBlankFormatService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getMeaBlankFormats();
  }
 
  getMeaBlankFormats() {
    this.isLoading = true;
    this.MeaBlankFormatService.getMeaBlankFormats(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getMeaBlankFormats();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getMeaBlankFormats();
  }

  deleteItem(row) {
    const id = row.meaBlankFormatId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.MeaBlankFormatService.delete(id).subscribe(() => {
          this.getMeaBlankFormats();
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
