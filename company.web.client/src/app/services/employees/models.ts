export interface EmployeeDto {
    id: string,
    personalInfo: PersonalInfoDto,
    department: string,
    employmentDate: Date,
    monthlySalary: number
}

export interface PersonalInfoDto {
    firstName: string;
    lastName: string;
    patronymic?: string | undefined;
    birthDate: Date;
    fullName: string;
}