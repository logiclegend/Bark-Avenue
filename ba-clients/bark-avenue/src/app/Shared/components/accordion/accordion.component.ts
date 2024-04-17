import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-accordion',
  templateUrl: './accordion.component.html',
  styleUrls: ['./accordion.component.scss']
})
export class AccordionComponent implements OnInit {
  @Input() headerTitle: string = '';
  @Input() headerClass: string = '';
  isOpen: boolean = false;
  
  ngOnInit(): void {    
  }

  onAccordionClick(){
    this.isOpen = !this.isOpen;
  }

} 
