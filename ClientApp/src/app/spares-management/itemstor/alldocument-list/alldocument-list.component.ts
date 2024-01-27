import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { AllDocument } from '../../models/AllDocument';
import { ItemStorService } from '../../service/ItemStor.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
 

@Component({
  selector: 'app-alldocument',
  templateUrl: './alldocument-list.component.html',
  styleUrls: ['./alldocument-list.component.sass']
})
export class AllDocumentListComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: AllDocument[] = [];
  isLoading = false;
  allDocumentData: AllDocument[];
  itemStorId:any;
  fileUrl = "/content/";
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser','demandLetterNo', 'specDoc', 'tenderSpecification','tenderNotice', 'procurementDocument', 'acceptanceDocument','otherDoc','actions'];
  dataSource: MatTableDataSource<AllDocument> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar, private ItemStorService: ItemStorService,private router: Router,   private route: ActivatedRoute,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.itemStorId = this.route.snapshot.paramMap.get("itemStorId");
    console.log(this.itemStorId)
    console.log("Item store Id")
    this.getAllStoreListofDocument(this.itemStorId);
    
  }
 
  getAllStoreListofDocument(itemStorId) {
    this.isLoading = true;
    this.ItemStorService.getAllStoreListofDocument(itemStorId).subscribe(response => {
      //this.allDocumentData = response;
      this.dataSource.data = response; 
      console.log("data store list")
      console.log(this.dataSource.data);
      //this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    
  })
}
  
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    //this.getItemDetails();
    this.getAllStoreListofDocument(this.itemStorId);
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    //this.getItemDetails();
    //this.getItemDetailsForSpares();
  }

  // deleteItem(row) {
  //   const id = row.itemDetailId; 
  //   this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
  //     console.log(result);
  //     if (result) {
  //       this.ItemDetailService.delete(id).subscribe(() => {
  //         //this.getItemDetails();
  //         //this.getItemDetailsForSpares();
  //         this.snackBar.open('Information Deleted Successfully ', '', {
  //           duration: 2000,
  //           verticalPosition: 'bottom',
  //           horizontalPosition: 'right',
  //           panelClass: 'snackbar-danger'
  //         });
  //       })
  //     }
  //   })
  // }
}
