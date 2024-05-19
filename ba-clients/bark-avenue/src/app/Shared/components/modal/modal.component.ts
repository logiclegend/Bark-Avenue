import { Component, ViewEncapsulation, ElementRef, Input, OnInit, OnDestroy, ViewChild, Injectable } from '@angular/core'; 

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
        this.modalService.add(this);
        document.body.appendChild(this.element);

        this.element.addEventListener('click', (el: any) => {
            if (el.target.classList.contains('modal-back')) {
                this.close();
            }
        });

        this.color = this.id == "modal-2" ? this.color1 : this.color2;
    }

    ngOnDestroy() {
        this.modalService.remove(this);
        this.element.remove();
    }

    open() {
        this.modal?.nativeElement.classList.add('modal-open');
        this.isOpen = true;
        
    }

    close() {
        this.modal?.nativeElement.classList.remove('modal-open');
        this.isOpen = false;
    }
}
