import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import {ArchivingforPublicationService } from '../../service/ArchivingforPublication.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { ArchivingforPublication } from '../../models/ArchivingforPublication';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
import { ItemDetailService } from 'src/app/spares-management/service/itemDetail.service';
import { IssueRegisterService } from 'src/app/issue-management/service/IssueRegister.service';

@Component({
  selector: 'app-new-archivingforpublication',
  templateUrl: './new-archivingforpublication.component.html',
  styleUrls: ['./new-archivingforpublication.component.sass']
})
export class NewArchivingforPublicationComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  sparesCategoryId:number;
  ArchivingforPublicationForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  aircraftName: SelectedModel[];
  NameofPublication:SelectedModel[];
  files: any[];
  itemDetailId:any;
  ArchivingforPublicationList:ArchivingforPublication[];
  isShown: boolean = false ;
  isCoHide: boolean = true ;
  masterData = MasterData;
  itemCategoryId:any;
  userRole = Role;

  groupArrays: { departmentName: string; datas: any }[];
  
  traineeId:any;
  role:any;
  branchId:any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = [ 'ser', 'departmentName', 'aircraftName', 'degitalArchieveDocType','name', 'dateOfLastRev', 'actions'];
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private IssueRegisterService: IssueRegisterService, private ItemDetailService: ItemDetailService, private confirmService: ConfirmService,private ArchivingforPublicationService: ArchivingforPublicationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) {
    this.files = [];
   }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('archivingforPublicationId');

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId,  this.branchId)

    if (id) {
      this.pageTitle = ' Archiving for Publication';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.ArchivingforPublicationService.find(+id).subscribe(
        res => {
          this.ArchivingforPublicationForm.patchValue({          

            archivingforPublicationId: res.archivingforPublicationId,
            departmentNameId:res.departmentNameId,
            airCraftNameId:res.airCraftNameId,
            itemDetailId:res.itemDetailId,
            nameofPublicationId:res.nameofPublicationId,
            documentName:res.documentName,
            date:res.date,
            docUpload: res.docUpload,
            remarks: res.remarks,
            //status: res.status
          
          }); 
          this.getselecteAircraft(); 
        }
      );
    } else {
      this.pageTitle = ' Archiving for Publication';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin && this.role != this.userRole.CO){
      this.ArchivingforPublicationForm.get('departmentNameId').setValue(this.branchId);
      this.onArchivingforPublicationListByDepartmentNameSelectionChange();    
    }
    if(this.role == this.userRole.CO){
      this.isCoHide = false;
      this.ArchivingforPublicationForm.get('departmentNameId').setValue(0);
      this.onArchivingforPublicationListByDepartmentNameSelectionChange();    
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.navalAviation);
    
    this.getselecteNameofPublication();
  }
  intitializeForm() {
    this.ArchivingforPublicationForm = this.fb.group({
      archivingforPublicationId: [0],
      departmentNameId:[],
      airCraftNameId:[],
      //itemDetailId:[],
      nameofPublicationId:[],
      documentName:[''],
      date:[],
      docUpload:[''],
      document:[''],
      remarks:[''],
      status:[''],
      isActive: [true]
    
    })
  }
  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log(file);
      this.ArchivingforPublicationForm.patchValue({
        document: file,
      });
    }
  }
  onArchivingforPublicationListByDepartmentNameSelectionChange(){
    this.isShown=true;
    var departmentNameId =this.ArchivingforPublicationForm.value['departmentNameId'];
    console.log(departmentNameId);
      this.ArchivingforPublicationService.getArchivingforPublicationListByDepartmentName(departmentNameId).subscribe(res=>{
        this.ArchivingforPublicationList=res
        console.log( this.ArchivingforPublicationList);
        // this gives an object with dates as keys
      const groups = this.ArchivingforPublicationList.reduce((groups, datas) => {
        const departmentName = datas.departmentName;
        if (!groups[departmentName]) {
          groups[departmentName] = [];
        }
        groups[departmentName].push(datas);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((departmentName) => {
        return {
          departmentName,
          datas: groups[departmentName],
        };
      });

      console.log(this.groupArrays);   

        this.getselecteAircraft();
      });
  }
  getselecteAircraft(){    
    var departmentNameId =this.ArchivingforPublicationForm.value['departmentNameId'];
    this.ArchivingforPublicationService.getselecteAircraft(departmentNameId).subscribe(res=>{
      this.aircraftName=res
      console.log(res)
    }); 
  }
  getselecteNameofPublication(){    
    this.ArchivingforPublicationService.getselecteNameofPublication().subscribe(res=>{
      this.NameofPublication=res
      console.log(res)
    }); 
  }
  GetDepartmentNameById(baseNameId){    
    this.ArchivingforPublicationService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log(res)
    }); 
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  onSubmit() {
    const id = this.ArchivingforPublicationForm.get('archivingforPublicationId').value;   
    console.log(this.ArchivingforPublicationForm)
    this.ArchivingforPublicationForm.get("date").setValue(
      new Date(this.ArchivingforPublicationForm.get("date").value).toUTCString()
    );

    console.log(this.ArchivingforPublicationForm.value);

    const formData = new FormData();
    for (const key of Object.keys(this.ArchivingforPublicationForm.value)) {
      const value = this.ArchivingforPublicationForm.value[key];
      formData.append(key, value);
    }
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
         console.log(result)
        if (result) {
          this.ArchivingforPublicationService.update(+id,formData).subscribe(response => {
            this.router.navigateByUrl('/record-room/add-archivingforpublication');
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
      this.ArchivingforPublicationService.submit(formData).subscribe(response => {
        console.log(this.ArchivingforPublicationForm)
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
  deleteItem(row) {
    const id = row.archivingforPublicationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.ArchivingforPublicationService.delete(id).subscribe(() => {
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

}
