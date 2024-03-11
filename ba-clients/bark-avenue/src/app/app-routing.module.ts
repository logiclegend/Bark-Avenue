import { NgModule } from '@angular/core';
import { RouterModule , Routes } from '@angular/router';
import { HomeComponent } from './pages/home-page/components/home/home.component';
import { EmptyPageComponent } from './pages/empty-page/empty-page.component';

const routes: Routes = [
  {path: 'home' , component: HomeComponent , title: "Bark Avenue"},
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
