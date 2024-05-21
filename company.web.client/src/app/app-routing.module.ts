import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CommonModule } from '@angular/common';
import { EmployeeComponent } from './components/employee/employee.component';

const routes: Routes = [
  { 
    path: '',
    component: HomeComponent
  },
  {
    path: "employees",
    component: EmployeeComponent
  }
];

@NgModule({
  declarations: [],
  imports: [ RouterModule.forRoot(routes)],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
