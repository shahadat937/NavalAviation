import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MaintenancePlanning } from '../../models/MaintenancePlanning';
import { MaintenancePlanningService } from '../../service/MaintenancePlanning.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { ConfirmService } from 'src/app/core/service/confirm.service';

@Component({
  selector: 'app-view-maintenanceplanning',
  templateUrl: './view-maintenanceplanning.component.html',
  styleUrls: ['./view-maintenanceplanning.component.sass']
})
export class ViewMaintenancePlanningComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: MaintenancePlanning[] = [];
  isLoading = false;
  maintenancePlanningId: number;
  departmentNameId: number;
  departmentName:string;
  airCraftNameId:number;
  airCraftName:string;
  maintenanceTypeId:number;
  categoryType:string;
  maintenanceCategoryId:number;
  category:string;
  maintenanceSubCategoryId:number;
  subCategory:string;
  lastInspDate:Date;
  nestInspDate:Date;
  lastInspectionFH:string;
  nextInspectionFH:string;
  lastInspectionOH:string;
  nextInspectionOH:string;
  jobListDocument:string;
  remarks:string;
  
    

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private MaintenancePlanningService: MaintenancePlanningService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('maintenancePlanningId'); 
    this.MaintenancePlanningService.find(+id).subscribe( res => {
      console.log(res);
      this.maintenancePlanningId= res.maintenancePlanningId,
      this.departmentNameId=res.departmentNameId,
      this.departmentName=res.departmentName,
      this.airCraftName=res.airCraftName,
      this.categoryType=res.categoryType,
      this.category=res.category,
      this.subCategory=res.subCategory,
      this.lastInspDate=res.lastInspDate,
      this.nestInspDate=res.nestInspDate,
      this.lastInspectionFH=res.lastInspectionFH,
      this.nextInspectionFH=res.nextInspectionFH,
      this.lastInspectionOH=res.lastInspectionOH,
      this.nextInspectionOH=res.nextInspectionOH,
      this.jobListDocument=res.jobListDocument,
      this.remarks=res.remarks
      
    })
  }
}
