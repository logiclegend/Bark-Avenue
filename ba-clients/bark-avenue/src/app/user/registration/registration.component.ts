import { Component } from '@angular/core';
import { ModalService } from 'src/app/Shared/services/modal.service';
import { UserService } from '../user.service';
import { IUserSignUpCredentials } from '../user.model';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {
  credentials : IUserSignUpCredentials = {
    username: '', 
    email: '',
    phone_number: '0977688807',
    password_user: '',
    confirm_password: ''
  }

  constructor(protected modalService: ModalService , private userService: UserService , private router : Router) {}

  signUp(){
    this.userService.signUp(this.credentials).subscribe({
      next: (res: any) => {
        this.modalService.close();
        this.router.navigate(['/home']);
        setTimeout(() => {alert(res)}, 1500)
      },
      error: (err : HttpErrorResponse) => {
        console.log(err.name);
        console.log(err.message);
        console.log(err.status);  
      }
  });
  }



}
