USE [CompanyDb]
GO

UPDATE [dbo].[Employees]
   SET [MonthlySalary] = 15000
 WHERE [MonthlySalary] < 15000
GO


