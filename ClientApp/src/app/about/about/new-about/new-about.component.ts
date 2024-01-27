import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
@Component({
  selector: 'app-new-about',
  templateUrl: './new-about.component.html',
  styleUrls: ['./new-about.component.sass']
})
export class NewAboutComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  sparesCategoryId:number;
  AboutForm: FormGroup;
  validationErrors: string[] = [];
  departmentName: SelectedModel[];
  aircraftName: SelectedModel[];
  degitalDocType:SelectedModel[];
  files: any[];
  itemDetailId:any;
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
  constructor(private snackBar: MatSnackBar,private authService: AuthService, private confirmService: ConfirmService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) {
    this.files = [];
   }

  ngOnInit(): void {
    // const id = this.route.snapshot.paramMap.get('degitalArchieveId');

    // this.role = this.authService.currentUserValue.role.trim();
    // this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    // this.branchId =  this.authService.currentUserValue.branchId.trim();
    // console.log(this.role, this.traineeId,  this.branchId)

   
  }
 
  
  

}
