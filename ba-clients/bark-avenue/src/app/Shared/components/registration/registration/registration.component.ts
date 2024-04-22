import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalService } from '../../../services/modal.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
  registrationForm!: FormGroup;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    public modalService: ModalService  
  ) { }

  ngOnInit(): void {
    this.registrationForm = this.formBuilder.group({
      name: ['', Validators.required], // Обов'язкове поле для імені
      email: ['', [Validators.required, Validators.email]], // Обов'язкове поле для email і перевірка правильного формату
      password: ['', [Validators.required, Validators.minLength(8)]] // Обов'язкове поле для паролю та мінімальна довжина 8 символів
    });
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.registrationForm.invalid) {
      return;
    }
  }
}
