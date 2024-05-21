import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import Swiper from 'swiper';
// import function to register Swiper custom elements
import { register } from 'swiper/element/bundle';
// register Swiper custom elements
register();

@Component({
  selector: 'app-swiper',
  templateUrl: './swiper.component.html',
  styleUrls: ['./swiper.component.scss']
})
export class SwiperComponent implements AfterViewInit{
  @ViewChild('swiperEx') swiperEx?: ElementRef<{swiper: Swiper}>

  ngAfterViewInit() : void
  {
    register();
  }

  goNext(){
    this.swiperEx!.nativeElement.swiper.slideNext();
    console.log("next");
    // console.log(this.swiperEx);
    console.log(Swiper);
  }
  goPrev(){
    this.swiperEx?.nativeElement.swiper.slidePrev();
  }

  onSlideChange(): void {
    console.log('Поточний слайд:');
  }

}
