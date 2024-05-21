import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
export class RegistrationComponent implements OnInit {
  registrationForm!: FormGroup;
  submitted = false;
  isPasswordVisible = false;

  constructor(
    private formBuilder: FormBuilder,
    protected modalService: ModalService,
    private userService: UserService,
    private router: Router
    
  ) {}

  ngOnInit(): void {
    this.registrationForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
    });
  }

  togglePasswordVisibility(): void {
    this.isPasswordVisible = !this.isPasswordVisible;
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.registrationForm.invalid) {
      return;
    }

    const credentials: IUserSignUpCredentials = {
      username: this.registrationForm.value.name,
      email: this.registrationForm.value.email,
      phone_number: '0977688807',
      password_user: this.registrationForm.value.password,
      confirm_password: this.registrationForm.value.password 
    };

    this.userService.signUp(credentials).subscribe({
      next: (res: any) => {
        this.modalService.close();
        this.router.navigate(['/home']);
        setTimeout(() => { alert(res); }, 1500);
      },
      error: (err: HttpErrorResponse) => {
        console.log(err.name);
        console.log(err.message);
        console.log(err.status);  
      }
    });
  }
}
