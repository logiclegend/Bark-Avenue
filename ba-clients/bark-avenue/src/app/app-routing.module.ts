import { NgModule } from '@angular/core';
import { RouterModule , Routes } from '@angular/router';
import { HomeComponent } from './pages/home-page/components/home/home.component';
import { EmptyPageComponent } from './pages/empty-page/empty-page.component';

import { AccountComponent } from './pages/account-page/components/account/account.component';

import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';

import { ContactsComponent } from './pages/contacts-page/components/contacts/contacts.component';
import { MapComponent } from './pages/custom-map/components/map/map.component';

const routes: Routes = [
  {path: 'home' , component: HomeComponent , title: "Bark Avenue"},
  {path: 'contacts' , component: ContactsComponent , title: "Bark Avenue"},
  {path: 'account' , component: AccountComponent , title: "Bark Avenue"},
  {path: 'map' , component: MapComponent , title: "Bark Avenue"},
  {path: '', redirectTo: '/home' , pathMatch: 'full' },
  {path: '**' , component: EmptyPageComponent}
];


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
