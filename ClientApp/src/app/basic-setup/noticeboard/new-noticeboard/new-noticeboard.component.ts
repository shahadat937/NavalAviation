import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NoticeBoardService } from '../../service/NoticeBoard.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import { AirCraftFlyingService } from '../../service/AirCraftFlying.service';
import { MasterData } from 'src/assets/data/master-data';
import { NoticeBoard } from '../../models/NoticeBoard';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-new-noticeboard',
  templateUrl: './new-noticeboard.component.html',
  styleUrls: ['./new-noticeboard.component.sass']
})
export class NewNoticeBoardComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  NoticeBoardForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 
  traineeId:any;
  role:any;
  branchId:any;
  userRole = Role;
  selectedDepartmentName:SelectedModel[];
  noticeBoardList:SelectedModel[];
  masterData = MasterData;


  ELEMENT_DATA: NoticeBoard[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'departmentNameId', 'date','event','orderBy', 'actions'];
  dataSource: MatTableDataSource<NoticeBoard> = new MatTableDataSource();

  selection = new SelectionModel<NoticeBoard>(true, []);

  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private NoticeBoardService: NoticeBoardService,private AirCraftFlyingService:AirCraftFlyingService, private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('noticeBoardId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if (id) {
      this.pageTitle = 'Edit NoticeBoard';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.NoticeBoardService.find(+id).subscribe(
        res => {
          this.NoticeBoardForm.patchValue({                 
            noticeBoardId: res.noticeBoardId,
            departmentNameId:res.departmentNameId,
            date:res.date,
            event:res.event,
            orderBy:res.orderBy,
            remarks:res.remarks,
            isActive:res.isActive
          });          
        }
      );
    } else {
      this.pageTitle = 'Create NoticeBoard';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      console.log("dd");
      this.NoticeBoardForm.get('departmentNameId').setValue(this.branchId);
      this.onDepartmentSelectionChangeGetNoticeBoardList();
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
  }
  intitializeForm() {
    this.NoticeBoardForm = this.fb.group({
      noticeBoardId: [0],
      departmentNameId:[],
      date:[],
      event:[''],
      orderBy:[''],
      remarks:[''],
      noticeDocument: [''],
      doc:[''],
      isActive:[true]
    })
  }
  
  // getNoticeBoards() {
  //   this.isLoading = true;
  //   this.NoticeBoardService.getNoticeBoards(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
  //     this.dataSource.data = response.items; 
  //     this.paging.length = response.totalItemsCount    
  //     this.isLoading = false;
  //   })
  // }
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getNoticeBoards();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getNoticeBoards();
  } 

  onDepartmentSelectionChangeGetNoticeBoardList() {
    var departmentNameId =this.NoticeBoardForm.value['departmentNameId'];
    if(departmentNameId == ''){
      departmentNameId = 0;
      console.log(departmentNameId)
    }
    console.log(departmentNameId)
    this.NoticeBoardService.getNoticeBoards(this.paging.pageIndex, this.paging.pageSize,this.searchText,departmentNameId).subscribe(response => {
      
      this.dataSource.data = response.items; 
      console.log("data---");
      console.log(this.dataSource.data)
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  getNoticeBoards(){
    this.onDepartmentSelectionChangeGetNoticeBoardList();
  }

  GetDepartmentNameById(baseNameId){    
    this.AirCraftFlyingService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.selectedDepartmentName=res
      console.log(res)
    }); 
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  deleteItem(row) {
    const id = row.noticeBoardId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.NoticeBoardService.delete(id).subscribe(() => {
         this.getNoticeBoards();
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

  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
     console.log(file);
      this.NoticeBoardForm.patchValue({
        doc: file,
      });
    }
  }

  onSubmit() {
    const id = this.NoticeBoardForm.get('noticeBoardId').value;   

    this.NoticeBoardForm.get('date').setValue((new Date(this.NoticeBoardForm.get('date').value)).toUTCString()) ;
    // this.ProcurementForm.get('tenderopeningDate').setValue((new Date(this.ProcurementForm.get('tenderopeningDate').value)).toUTCString()) ;
    // this.ProcurementForm.get('workOrderDate').setValue((new Date(this.ProcurementForm.get('workOrderDate').value)).toUTCString()) ;
    // this.ProcurementForm.get('dateOfDelivery').setValue((new Date(this.ProcurementForm.get('dateOfDelivery').value)).toUTCString()) ;
    
   // console.log(this.ProcurementForm.value)

    const formData = new FormData();
    for (const key of Object.keys(this.NoticeBoardForm.value)) {
      const value = this.NoticeBoardForm.value[key];
      formData.append(key, value);
    }

    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.NoticeBoardService.update(+id,formData).subscribe(response => {
            this.router.navigateByUrl('/admin/dashboard/add-noticeboard');
            this.snackBar.open('Information Updated Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          }, error => {
            this.validationErrors = error;
          })
        }
      })
    } else {
      this.NoticeBoardService.submit(formData).subscribe(response => {
        // this.router.navigateByUrl('/basic-setup/noticeboard-list');
        this.reloadCurrentRoute();
        this.snackBar.open('Information Inserted Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
}
