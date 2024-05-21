USE [CompanyDb]
GO

SELECT [Id]
      ,[FirstName]
      ,[LastName]
      ,[Patronymic]
      ,[BirthDate]
      ,[Department]
      ,[EmploymentDate]
      ,[MonthlySalary]
  FROM [dbo].[Employees]
  WHERE [MonthlySalary] > 10000
GO


