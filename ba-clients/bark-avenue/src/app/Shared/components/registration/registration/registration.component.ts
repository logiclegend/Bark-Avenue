import { Component } from '@angular/core';
import { ModalService } from 'src/app/Shared/services/modal.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {
  constructor(protected modalService: ModalService) {}

}
