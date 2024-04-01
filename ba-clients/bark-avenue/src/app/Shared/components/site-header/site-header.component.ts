import { Component , OnInit , HostListener } from '@angular/core';


@Component({
  selector: 'app-site-header',
  templateUrl: './site-header.component.html',
  styleUrls: ['./site-header.component.scss']
})
export class SiteHeaderComponent implements OnInit {
  isMobile: boolean = false;
  active : boolean = false;

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
