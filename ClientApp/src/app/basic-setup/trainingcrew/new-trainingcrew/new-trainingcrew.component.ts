import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TrainingCrewService } from '../../service/TrainingCrew.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-trainingcrew',
  templateUrl: './new-trainingcrew.component.html',
  styleUrls: ['./new-trainingcrew.component.sass']
})
export class NewTrainingCrewComponent implements OnInit {
  pageTitle: string;
  destination:string;
  btnText:string;
  TrainingCrewForm: FormGroup;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[]; 
  selectedDepartmentName:SelectedModel[];
  selectedOfficersStatuses:SelectedModel[];
  selectedRanks:SelectedModel[];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private TrainingCrewService: TrainingCrewService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('trainingCrewId'); 
    if (id) {
      this.pageTitle = 'Edit Training Crew';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.TrainingCrewService.find(+id).subscribe(
        res => {
          this.TrainingCrewForm.patchValue({          

            trainingCrewId: res.trainingCrewId,
            departmentNameId: res.departmentNameId,
            officersStatusId: res.officersStatusId,
            rankId: res.rankId,
            pno: res.pno,
            name: res.name,
            dateOfJoin: res.dateOfJoin,
            duties: res.duties,
            aviationCategory: res.aviationCategory,
            mobile: res.mobile,
            email: res.email,
            remarks:res.remarks
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Training Crew';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    this.getselectedDepartmentName();
    this.getselectedOfficersStatuses();
    this.getselectedRanks();
  }
  intitializeForm() {
    this.TrainingCrewForm = this.fb.group({
      trainingCrewId: [0],
      departmentNameId: [],
      officersStatusId: [],
      rankId: [],
      pno: [''],
      name: [''],
      dateOfJoin: [''],
      duties: [''],
      aviationCategory: [''],
      mobile: [''],
      email: [''],
      remarks: [''],
      isActive: [true]
    })
  }
  getselectedDepartmentName(){
    this.TrainingCrewService.getselectedDepartmentName().subscribe(res=>{
      this.selectedDepartmentName=res
      console.log(this.selectedDepartmentName);      
    });
  }
  getselectedOfficersStatuses(){
    this.TrainingCrewService.getselectedOfficersStatuses().subscribe(res=>{
      this.selectedOfficersStatuses=res
      console.log(this.selectedOfficersStatuses);      
    });
  }
  getselectedRanks(){
    this.TrainingCrewService.getselectedRanks().subscribe(res=>{
      this.selectedRanks=res
      console.log(this.selectedRanks);      
    });
  }
  onSubmit() {
    const id = this.TrainingCrewForm.get('trainingCrewId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.TrainingCrewService.update(+id,this.TrainingCrewForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/trainingcrew-list');
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
      this.TrainingCrewService.submit(this.TrainingCrewForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/trainingcrew-list');
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
