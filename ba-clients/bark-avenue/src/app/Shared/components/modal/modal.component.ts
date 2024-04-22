import { Component, ViewEncapsulation, ElementRef, Input, OnInit, OnDestroy, ViewChild, Injectable } from '@angular/core'; // Додано імпорт Injectable

import { ModalService } from '../../services/modal.service';

@Component({
    selector: 'app-modal',
    templateUrl: './modal.component.html',
    styleUrls: ['./modal.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class ModalComponent implements OnInit, OnDestroy {
    @Input() id?: string;
    isOpen = false;
    private element: any;
    @ViewChild('modal') modal?: ElementRef;

    constructor(private modalService: ModalService, private el: ElementRef) {
        this.element = el.nativeElement;
    }

    color1 = 'white';
    color2 = 'black';
    color?: string;
    
    




    ngOnInit() {
        // add self (this modal instance) to the modal service so it can be opened from any component
        this.modalService.add(this);

        // move element to bottom of page (just before </body>) so it can be displayed above everything else
        document.body.appendChild(this.element);

        // close modal on background click
        this.element.addEventListener('click', (el: any) => {
            if (el.target.classList.contains('modal-back')) {
                this.close();
            }
        });

        this.color = this.id == "modal-2" ? this.color1 : this.color2;
    }

    ngOnDestroy() {
        // remove self from modal service
        this.modalService.remove(this);

        // remove modal element from html
        this.element.remove();
    }

    open() {
        // this.element.style.display = 'block';
        this.modal?.nativeElement.classList.add('modal-open');
        this.isOpen = true;
        
    }

    close() {
        // this.element.style.display = 'none';
        this.modal?.nativeElement.classList.remove('modal-open');
        this.isOpen = false;
        
    }
}
