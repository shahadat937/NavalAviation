import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { TestEquipmentDetailService } from '../../service/TestEquipmentDetail.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { TestEquipmentDetail } from '../../models/TestEquipmentDetail';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-new-testequipmentdetail',
  templateUrl: './new-testequipmentdetail.component.html',
  styleUrls: ['./new-testequipmentdetail.component.sass']
})
export class NewTestEquipmentDetailComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  TestEquipmentDetailForm: FormGroup;
  validationErrors: string[] = [];
  selectedDepartmentNames:SelectedModel[]; 
  selectedPresentStates:SelectedModel[]; 
  selectedShop:SelectedModel[];
  selectedItemNameAndPattNo :SelectedModel[];
  selectedConditionofItem:SelectedModel[];
  masterData = MasterData;
  userRole = Role;
  isLoading = false;
  traineeId:any;
  role:any;
  branchId:any;
  searchText="";

  displayedColumns: string[] = ['ser', 'pattNo',  'equipmentName', 'deno', 'qty','shop', 'remarks','actions'];
  dataSource: MatTableDataSource<TestEquipmentDetail> = new MatTableDataSource();
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private TestEquipmentDetailService: TestEquipmentDetailService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('testEquipmentDetailId'); 
    this.getTestEquipmentDetails();
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)
  
    if (id) {
      this.pageTitle = 'Edit Test Equipment Details';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.TestEquipmentDetailService.find(+id).subscribe(
        res => {
          this.TestEquipmentDetailForm.patchValue({          

            testEquipmentDetailId: res.testEquipmentDetailId,
            shopId: res.shopId,
            equipmentName:res.equipmentName,
            pattNo:res.pattNo,
            deno:res.deno,
            qty:res.qty,
            shelfLife:res.shelfLife,
            remarks:res.remarks,
            menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Equipment/Tools List';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    
    this.getselectedShop();
    
  }
  intitializeForm() {
    this.TestEquipmentDetailForm = this.fb.group({
      testEquipmentDetailId: [0],
      shopId:[],
      equipmentName:[],
      pattNo:[],
      deno:[],
      qty:[],
      shelfLife:[],
      remarks:[],
      //menuPosition: [''],
      isActive: [true],
    
    })
  }

  
  getselectedShop(){
    this.TestEquipmentDetailService.getselectedShop().subscribe(res=>{
      this.selectedShop=res
      console.log(this.selectedShop);      
    });
  }
  getTestEquipmentDetails() {
    this.isLoading = true;
    this.TestEquipmentDetailService.getTestEquipmentDetails(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
      console.log(this.dataSource.data)
      console.log("data")
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getTestEquipmentDetails();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getTestEquipmentDetails();
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
  deleteItem(row) {
    const id = row.testEquipmentDetailId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.TestEquipmentDetailService.delete(id).subscribe(() => {
          //this.getTestEquipmentDetails();
          this.reloadCurrentRoute();
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
  onSubmit() {
    const id = this.TestEquipmentDetailForm.get('testEquipmentDetailId').value;  
    console.log(this.TestEquipmentDetailForm.value); 
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        
        if (result) {
          this.TestEquipmentDetailService.update(+id,this.TestEquipmentDetailForm.value).subscribe(response => {
            this.router.navigateByUrl('/mea/add-testequipmentdetail');
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
      this.TestEquipmentDetailService.submit(this.TestEquipmentDetailForm.value).subscribe(response => {
        //this.router.navigateByUrl('/mea/testequipmentdetail-list');
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
