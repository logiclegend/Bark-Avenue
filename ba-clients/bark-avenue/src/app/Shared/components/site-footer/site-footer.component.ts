import { Component , HostListener, OnInit} from '@angular/core';

@Component({
  selector: 'app-site-footer',
  templateUrl: './site-footer.component.html',
  styleUrls: ['./site-footer.component.scss']
})
export class SiteFooterComponent implements OnInit {
  isMobileSmall: boolean = true;

  ngOnInit(){
    this.chekScreenSize();
  }

  @HostListener('window:resize' , ['$event'])
  onResize(event: any){
    this.chekScreenSize();
  }

  chekScreenSize(){
    this.isMobileSmall = window.innerWidth < 479.98;
  }
}
