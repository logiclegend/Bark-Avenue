import { Component } from '@angular/core';
import { ModalService } from 'src/app/Shared/services/modal.service';
import { IUserCredentials } from '../user.model';
import { UserService } from '../user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  credentials: IUserCredentials = {email: '', password: ''};
  signInError: boolean = false;

  constructor(protected modalService: ModalService , private userService: UserService, private router: Router) {}

  signIn(){
    this.signInError = false;
    this.userService.signIn(this.credentials).subscribe({
      next: () => this.router.navigate(['/contacts']),
      error: () => (this.signInError = true)
    });
  } 

  signOut(){
    this.userService.signOut();
  }

}
