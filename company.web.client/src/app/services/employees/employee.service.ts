import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { EmployeeDto } from './models';

@Injectable()
export class EmployeeService {

  constructor(private http: HttpClient) { }

  get(): Observable<EmployeeDto[]> {
    return this.http.get<EmployeeDto[]>('/api/employee')
      .pipe(map(r => 
        r.map(e => {
          e.personalInfo.fullName =
            [e.personalInfo.lastName, 
              e.personalInfo.firstName, 
              e.personalInfo.patronymic].join(' ');
            return e
        })));
  }
}
