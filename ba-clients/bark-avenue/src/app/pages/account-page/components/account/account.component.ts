import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {

  defoultOpen(){
    document.getElementById("defoultOpen")?.click();
  }

  ngOnInit(): void {
      this.defoultOpen();
  }

  tabOpen(event:Event , content:string){
    
    const tabContent = document.getElementsByClassName("tab-content");
    for(let i = 0; i < tabContent.length; i++){
      (tabContent[i] as HTMLElement).style.display = "none";
    }
    const tabLinks = document.getElementsByClassName("tablinks");
    for(let i = 0; i < tabLinks.length; i++){
      tabLinks[i].className = tabLinks[i].className.replace(" active" , "");
    }

    (document.getElementById(content) as HTMLElement).style.display = "block";
    (event.currentTarget as HTMLElement).className += " active"

  }


}
