import { Component, OnInit } from '@angular/core';
import { NgbDate, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { BehaviorSubject, Subject } from 'rxjs';
import { EmployeeDto, EmployeeService } from 'src/app/services/employees';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  private _employees: EmployeeDto[] = [];
  employees: EmployeeDto[] = [];
  employeesSub: BehaviorSubject<EmployeeDto[]> = new BehaviorSubject<EmployeeDto[]>([]);

  departmentFilter: string = '';
  fullNameFilter: string = '';
  birthDateFilter: string = '';
  employmentDateFilter: string = '';
  monthlySalaryFilter: string = '';

  emloymentDateStruct?: NgbDateStruct | undefined;
  birthDateStruct?: NgbDateStruct | undefined;

  constructor(private employeeService: EmployeeService) {
  }

  public ngOnInit(): void {
    this.employeeService.get().subscribe(e => {
      this._employees = e;
      this.updateFiltredValues();
    });
  }

  updateDepartmentFilter(event: KeyboardEvent) {
    this.departmentFilter = this.getInputValue(event);
    this.updateFiltredValues();
  }

  updateFullNameFilter(event: KeyboardEvent) {
    this.fullNameFilter = this.getInputValue(event);
    this.updateFiltredValues();
  }

  updateBirthDateFilter(date: NgbDate) {
    const strDate = this.ngbDateToString(date);
    if (strDate == this.birthDateFilter) {
      this.birthDateStruct = undefined;
      this.birthDateFilter = '';
    }
    else {
      this.birthDateFilter = strDate;
    }

    this.updateFiltredValues();
  }

  updateEmploymentDateFilter(date: NgbDate) {
    const strDate = this.ngbDateToString(date);

    if (strDate == this.employmentDateFilter) {
      this.emloymentDateStruct = undefined;
      this.employmentDateFilter = '';
    }
    else {
      this.employmentDateFilter = strDate;
    }

    this.updateFiltredValues();
  }

  updateMonthlySalaryFilter(event: KeyboardEvent) {
    this.monthlySalaryFilter = this.getInputValue(event);
    this.updateFiltredValues();
  }

  private ngbDateToString(date: NgbDate): string {
    return `${date.year}-${date.month}-${date.day}`;
  }

  private getInputValue(event: KeyboardEvent): string {
    return (event.target as HTMLInputElement).value.toLowerCase();
  }

  private updateFiltredValues(): void {
    let temp = this.filterByString(this._employees, this.departmentFilter, x => x.department);
    temp = this.filterByString(temp, this.fullNameFilter, x => x.personalInfo.fullName);
    temp = this.filterByString(temp, this.birthDateFilter, x => x.personalInfo.birthDate.toString().split('0').join(''));
    temp = this.filterByString(temp, this.employmentDateFilter, x => x.employmentDate.toString().replace('0', ''));
    temp = this.filterByString(temp, this.monthlySalaryFilter, x => x.monthlySalary.toString());

    this.employees = temp;
  }

  private filterByString<T>(array: T[], filter: string, predicate: (value: T) => string): T[] {
    if (filter == '') {
      return array;
    }
    return array.filter(x => predicate(x).toLowerCase().indexOf(filter) !== -1 || !filter);
  }
}
