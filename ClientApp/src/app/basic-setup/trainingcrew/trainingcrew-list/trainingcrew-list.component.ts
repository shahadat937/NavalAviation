import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TrainingCrew } from '../../models/TrainingCrew';
import { TrainingCrewService } from '../../service/TrainingCrew.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-trainingcrew-list',
  templateUrl: './trainingcrew-list.component.html',
  styleUrls: ['./trainingcrew-list.component.sass']
})
export class TrainingCrewListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: TrainingCrew[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'departmentName', 'officersStatus','rank','pno','name', 'dateOfJoin','mobile','email', 'actions'];
  dataSource: MatTableDataSource<TrainingCrew> = new MatTableDataSource();

  selection = new SelectionModel<TrainingCrew>(true, []);
  
  constructor(private snackBar: MatSnackBar,private TrainingCrewService: TrainingCrewService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getTrainingCrews();
  }
 
  getTrainingCrews() {
    this.isLoading = true;
    this.TrainingCrewService.getTrainingCrews(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getTrainingCrews();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getTrainingCrews();
  } 

  deleteItem(row) {
    const id = row.trainingCrewId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.TrainingCrewService.delete(id).subscribe(() => {
          this.getTrainingCrews();
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
