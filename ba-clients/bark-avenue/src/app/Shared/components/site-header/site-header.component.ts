import { Component , OnInit , HostListener, TemplateRef } from '@angular/core';
import { Action } from 'rxjs/internal/scheduler/Action';
import { ModalService } from '../../services/modal.service';


@Component({
  selector: 'app-site-header',
  templateUrl: './site-header.component.html',
  styleUrls: ['./site-header.component.scss']
})
export class SiteHeaderComponent implements OnInit {
  isMobile: boolean = false;
  active : boolean = false;

  constructor(protected modalService: ModalService) {}
  

  ngOnInit(){
    this.chekScreenSize();
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
