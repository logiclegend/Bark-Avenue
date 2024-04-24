import { Component } from '@angular/core';
import { ModalService } from 'src/app/Shared/services/modal.service';
import { IUserCredentials } from '../user.model';
// import { UserService } from '../user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  credentials: IUserCredentials = {email: '', password: ''};
  
  constructor(protected modalService: ModalService){}

  // constructor(protected modalService: ModalService , private userService: UserService, private router: Router) {}

  // signIn(){
  //   this.userService.signIn(this.credentials).subscribe({
  //     next: () => this.router.navigate(['/home'])
  //   });
  // } 

}
