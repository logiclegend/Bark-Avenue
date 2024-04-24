import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home-page/components/home/home.component';
import { SiteHeaderComponent } from './Shared/components/site-header/site-header.component';
import { SiteFooterComponent } from './Shared/components/site-footer/site-footer.component';
import { AppRoutingModule } from './app-routing.module';
import { EmptyPageComponent } from './pages/empty-page/empty-page.component';

import { AccordionComponent } from './Shared/components/accordion/accordion.component';
import { SwiperComponent } from './Shared/components/swiper/swiper.component';
import { AccountComponent } from './pages/account-page/components/account/account.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { ModalComponent } from './Shared/components/modal/modal.component';
import { ModalService } from './Shared/services/modal.service';
import { LoginComponent } from './user/login/login.component';
import { ContactsComponent } from './pages/contacts-page/components/contacts/contacts.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SiteHeaderComponent,
    SiteFooterComponent,
    EmptyPageComponent,
    AccordionComponent,
    SwiperComponent,
    AccountComponent,
    RegistrationComponent,
    ModalComponent,
    LoginComponent,
    ContactsComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  schemas:[CUSTOM_ELEMENTS_SCHEMA],

  providers: [ModalService],
  bootstrap: [AppComponent]
})
export class AppModule { }
