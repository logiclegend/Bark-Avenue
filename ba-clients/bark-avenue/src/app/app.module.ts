import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home-page/components/home/home.component';
import { SiteHeaderComponent } from './Shared/components/site-header/site-header.component';
import { SiteFooterComponent } from './Shared/components/site-footer/site-footer.component';
import { AppRoutingModule } from './app-routing.module';
import { EmptyPageComponent } from './pages/empty-page/empty-page.component';
import { AccordionComponent } from './Shared/components/accordion/accordion.component';
import { SwiperComponent } from './Shared/components/swiper/swiper.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SiteHeaderComponent,
    SiteFooterComponent,
    EmptyPageComponent,
    AccordionComponent,
    SwiperComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  schemas:[CUSTOM_ELEMENTS_SCHEMA],

  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
