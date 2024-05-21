USE [CompanyDb]
GO

DELETE FROM [dbo].[Employees]
      WHERE DATEDIFF(YEAR, [BirthDate], GETDATE()) > 70;
GO


