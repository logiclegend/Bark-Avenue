import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home-page/components/home/home.component';
import { SiteHeaderComponent } from './Shared/components/site-header/site-header.component';
import { SiteFooterComponent } from './Shared/components/site-footer/site-footer.component';
import { AppRoutingModule } from './app-routing.module';
import { EmptyPageComponent } from './pages/empty-page/empty-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SiteHeaderComponent,
    SiteFooterComponent,
    EmptyPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
