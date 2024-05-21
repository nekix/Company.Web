import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { NgbDatepickerModule, NgbModule, NgbAlertModule, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './components/home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { NavbarComponent } from './components/navbar/navbar.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { EmployeeService } from './services/employees/employee.service';
import { NgxBootstrapIconsModule, allIcons } from 'ngx-bootstrap-icons';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    EmployeeComponent,
    NavbarComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgbModule,
    AppRoutingModule,
    NgxDatatableModule,
    NgbDatepickerModule,
    NgxBootstrapIconsModule.pick(allIcons),
    NgbAlertModule,
    FormsModule
  ],
  providers: [EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
