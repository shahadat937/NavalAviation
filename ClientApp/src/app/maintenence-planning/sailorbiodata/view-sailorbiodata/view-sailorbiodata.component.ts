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

@Component({
  selector: 'app-view-sailorbiodata',
  templateUrl: './view-sailorbiodata.component.html',
  styleUrls: ['./view-sailorbiodata.component.sass']
})
export class ViewSailorBiodataComponent implements OnInit {

  masterData = MasterData;
  ELEMENT_DATA: TrainingCrew[] = [];
  isLoading = false;
  trainingCrewId: number;
  departmentNameId: number;
  departmentName:string;
  pno:string;
  sailorRankId:number;
  sailorRank:string;
  name:string;
  dateOfJoin:Date;
  duties:string;
  aviationCategory:string;
  mobile:string;
  email:string;
  remarks:string;
    

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private TrainingCrewService: TrainingCrewService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('trainingCrewId'); 
    this.TrainingCrewService.find(+id).subscribe( res => {
      console.log(res);
      this.trainingCrewId= res.trainingCrewId,
      this.departmentNameId=res.departmentNameId,
      this.departmentName=res.departmentName,
      this.pno=res.pno,
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
