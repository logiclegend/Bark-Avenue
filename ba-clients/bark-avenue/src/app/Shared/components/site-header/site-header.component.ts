import { Component , OnInit , HostListener, TemplateRef } from '@angular/core';
import { Action } from 'rxjs/internal/scheduler/Action';
import { ModalService } from '../../services/modal.service';
import { IUser } from 'src/app/user/user.model';
import { UserService } from 'src/app/user/user.service';


@Component({
  selector: 'app-site-header',
  templateUrl: './site-header.component.html',
  styleUrls: ['./site-header.component.scss']
})
export class SiteHeaderComponent implements OnInit {
  isMobile: boolean = false;
  active : boolean = false;
  user: IUser | null = null;

  constructor(protected modalService: ModalService , private userService: UserService) {}
  

  ngOnInit(){
    this.chekScreenSize();
    this.userService.getUser().subscribe({
      next: (user) => {
        this.user = user
        this.modalService.close()
      }
    })
  }

  @HostListener('window:resize' , ['$event'])
  onResize(event: any){
    this.chekScreenSize();
  }

  chekScreenSize(){
    return this.isMobile = window.innerWidth < 767.98;
  }

  onMenuClick(){
    this.active = !this.active;
    
  }


}