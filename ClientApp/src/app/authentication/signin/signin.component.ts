import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DomSanitizer } from '@angular/platform-browser';
@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss'],
})
export class SigninComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  authForm: FormGroup;
  submitted = false;
  loading = false;
  error = '';
  hide = true;
  lastPublishDate:any;
  
  captchaValue: number = 0;
  captchaImage: any = '';

  @ViewChild('captchaCanvas') captchaCanvas!: ElementRef<HTMLCanvasElement>;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService,private snackBar: MatSnackBar,
    private sanitizer: DomSanitizer
  ) {
    super();
  }
  

  ngOnInit() {
    this.lastPublishDate = '02/26/2025';
    this.authForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
      captcha: ['', Validators.required],
    });
    this.generateCaptcha();
  }
  get f() {
    return this.authForm.controls;
  }
  // adminSet() {
  //   this.authForm.get('username').setValue('admin@school.org');
  //   this.authForm.get('password').setValue('admin@123');
  // }
  // teacherSet() {
  //   this.authForm.get('username').setValue('teacher@school.org');
  //   this.authForm.get('password').setValue('teacher@123');
  // }
  // studentSet() {
  //   this.authForm.get('username').setValue('student@school.org');
  //   this.authForm.get('password').setValue('student@123');
  // }
  onSubmit() {
    this.submitted = true;
    this.loading = true;
    this.error = '';
    if (this.authForm.invalid) {

      this.snackBar.open('Email and Password not valid !', '', {
        duration: 2000,
        verticalPosition: 'bottom',
        horizontalPosition: 'right',
        panelClass: 'snackbar-danger'
      });
      this.submitted = false;
      this.loading = false;
      this.generateCaptcha();
     
      return;
    }
    else if(this.f['captcha'].value != this.captchaValue){
      this.snackBar.open('Invalid Captcha Answer', '', {
        duration: 2000,
        verticalPosition: 'bottom',
        horizontalPosition: 'right',
        panelClass: 'snackbar-danger'
      });
      this.submitted = false;
      this.loading = false;
      this.generateCaptcha();
     
      return;
    }
    else {
      this.subs.sink = this.authService
        .login(this.f.email.value, this.f.password.value)
        .subscribe(
          (res) => {
            if (res) {
              this.snackBar.open('login successfull.', '', {
                duration: 3000,
                verticalPosition: 'bottom',
                horizontalPosition: 'right',
                panelClass: 'snackbar-success'
              });
             // setTimeout(() => {
              const role = this.authService.currentUserValue.role.trim();
              const traineeId =  this.authService.currentUserValue.traineeId.trim();
              const branchId =  this.authService.currentUserValue.branchId.trim();

              console.log(traineeId,role,branchId)

                //const role = this.authService.currentUserValue.role;
                if (role === Role.All || role === Role.SuperAdmin ) {
                  this.router.navigate(['/admin/dashboard/main']);
                } else if (role === Role.Admin) {
                  this.router.navigate(['/admin/dashboard/admin-dashboard']);

                } else if (role === Role.CO || role === Role.HR || role === Role.FLGWG) {
                   this.router.navigate(['/admin/dashboard/main']);
                } 
                // else if (role === Role.FLGWG) {
                //   this.router.navigate(['/admin/dashboard/flgwg-dashboard']);
                // }
                else if (role === Role.User) {
                  this.router.navigate(['/admin/dashboard/user-dashboard']);
                }
                else if (role === Role.MEA) {
                  this.router.navigate(['/admin/dashboard/user-dashboard']);
                }
                else if (role === Role.EXO) {
                  this.router.navigate(['/admin/dashboard/main']);
                }
               else {
                  this.router.navigate(['/authentication/signin']);
                }
                this.loading = false;
            //  }, 1000);
            } else {
              this.error = 'Invalid Login';
            }
          },
          (error) => {
            this.error = error;
            this.submitted = false;
            this.loading = false;
            this.generateCaptcha();
          }
        );
    }
  }

  
  generateCaptcha() {
    const num1 = Math.floor(Math.random() * 10) + 1;
    const num2 = Math.floor(Math.random() * 10) + 1;
    this.captchaValue = num1 + num2;

    const svg = `
      <svg xmlns="http://www.w3.org/2000/svg" width="100" height="50">
        <text x="10" y="30" font-size="20" fill="black">${num1} + ${num2} = ?</text>
      </svg>`;

    const encodedSvg = encodeURIComponent(svg);
    const svgUrl = `data:image/svg+xml,${encodedSvg}`;

    // Sanitize the SVG URL to bypass Angular's security
    this.captchaImage = this.sanitizer.bypassSecurityTrustResourceUrl(svgUrl);
  }

}
