import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TrainingCrew } from '../../models/TrainingCrew';
import { TrainingCrewService } from '../../service/TrainingCrew.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-view-officerbiodata',
  templateUrl: './view-officerbiodata.component.html',
  styleUrls: ['./view-officerbiodata.component.sass']
})
export class ViewOfficerBiodataComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: TrainingCrew[] = [];
  isLoading = false;
  // trainingCrewId: number;
  pageTitle:any;
  departmentNameId: number;
  employeeTypeId: number;
  departmentName:string;
  pno:string;
  rankId:number;
  rank:string;
  sailorRank:string;
  name:string;
  dateOfJoin:Date;
  duties:string;
  aviationCategory:string;
  mobile:string;
  email:string;
  remarks:string;
  trainingCrewId:any;
  profileStatus:any;
    

  constructor(private route: ActivatedRoute,private authService: AuthService,private snackBar: MatSnackBar,private TrainingCrewService: TrainingCrewService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    this.trainingCrewId = Number(this.route.snapshot.paramMap.get('trainingCrewId')); 
    this.profileStatus = this.route.snapshot.paramMap.get('profileStatus'); 
    if(this.profileStatus){
      this.pageTitle = 'View Profile';
      console.log('inside');
      var crewId = this.authService.currentUserValue.traineeId;
      
      this.trainingCrewId = Number(crewId);
      console.log(this.trainingCrewId);
    }
    this.TrainingCrewService.find(+this.trainingCrewId).subscribe( res => {
      console.log(res);
      this.trainingCrewId= res.trainingCrewId,
      this.departmentNameId=res.departmentNameId,
      this.employeeTypeId=res.employeeTypeId,
      this.departmentName=res.departmentName,
      this.pno=res.pno,
      this.rank=res.rank,
      this.sailorRank=res.sailorRank,
      this.name=res.name,
      this.dateOfJoin=res.dateOfJoin,
      this.duties=res.duties,
      this.aviationCategory=res.aviationCategory,
      this.mobile=res.mobile,
      this.email=res.email,
      this.remarks=res.remarks
      
    })
  }
}
