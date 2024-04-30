import { Component } from '@angular/core';
import { ModalService } from 'src/app/Shared/services/modal.service';
import { UserService } from '../user.service';
import { IUserSignUpCredentials } from '../user.model';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {
  credentials : IUserSignUpCredentials = {
    name: '', 
    email: '',
    number: '0977688807',
    password: '',
    confirm_password: ''
  }

  constructor(protected modalService: ModalService , private userService: UserService) {}

  signUp(){
    this.userService.signUp(this.credentials).subscribe();
  }



}
