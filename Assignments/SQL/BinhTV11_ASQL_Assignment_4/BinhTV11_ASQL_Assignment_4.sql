-- Create a new database called 'EMS'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
	SELECT
	[name]
FROM
	sys.databases
WHERE [name] = N'EMS'
)
CREATE DATABASE EMS
GO

USE EMS
GO

CREATE TABLE [dbo].[Employee]
(
	[EmpNo]     [INT]        NOT NULL
	,[EmpName]   [NCHAR](30)  COLLATE
SQL_Latin1_General_CP1_CI_AS NOT NULL
	,[BirthDay]  [DATETIME]   NOT NULL
	,[DeptNo]    [INT]        NOT NULL
	,[MgrNo]     [INT]        NOT NULL
	,[StartDate] [DATETIME]   NOT NULL
	,[Salary]    [MONEY]      NOT NULL
	,[Status]    [INT]        NOT NULL
	,[Note]      [NCHAR](100) COLLATE
SQL_Latin1_General_CP1_CI_AS NULL
	,[Level]     [INT]        NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE Employee
ADD CONSTRAINT PK_Emp PRIMARY KEY (EmpNo)
GO
ALTER TABLE [dbo].[Employee] ADD CONSTRAINT [chk_Level] CHECK (([Level]=(7) OR [Level]=(6) OR
[Level]=(5) OR [Level]=(4) OR [Level]=(3) OR [Level]=(2) OR [Level]=(1)))
GO
ALTER TABLE [dbo].[Employee] ADD CONSTRAINT [chk_Status] CHECK (([Status]=(2) OR [Status]=(1) OR
[Status]=(0)))
GO
ALTER TABLE [dbo].[Employee]
ADD Email NCHAR(30)
GO
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT chk_Email CHECK (Email IS NOT NULL)
GO
ALTER TABLE [dbo].[Employee] ADD CONSTRAINT chk_Email1 UNIQUE(Email)
GO
ALTER TABLE Employee
ADD CONSTRAINT DF_EmpNo DEFAULT 0 FOR EmpNo
GO
ALTER TABLE Employee
ADD CONSTRAINT DF_Status DEFAULT 0 FOR [Status]
GO
CREATE TABLE [dbo].[Skill]
(
	[SkillNo]   [INT]        IDENTITY(1,1) NOT NULL
	,[SkillName] [NCHAR](30)  COLLATE
SQL_Latin1_General_CP1_CI_AS NOT NULL
	,[Note]      [NCHAR](100) COLLATE
SQL_Latin1_General_CP1_CI_AS NULL

) ON [PRIMARY]
GO
ALTER TABLE Skill
ADD CONSTRAINT PK_Skill PRIMARY KEY (SkillNo)
GO
CREATE TABLE [dbo].[Department]
(
	[DeptNo]   [INT]        IDENTITY(1,1) NOT NULL
	,[DeptName] [NCHAR](30)  COLLATE
SQL_Latin1_General_CP1_CI_AS NOT NULL
	,[Note]     [NCHAR](100) COLLATE
SQL_Latin1_General_CP1_CI_AS NULL

) ON [PRIMARY]
GO
ALTER TABLE Department
ADD CONSTRAINT PK_Dept PRIMARY KEY (DeptNo)
GO
CREATE TABLE [dbo].[Emp_Skill]
(
	[SkillNo]     [INT]        NOT NULL
	,[EmpNo]       [INT]        NOT NULL
	,[SkillLevel]  [INT]        NOT NULL
	,[RegDate]     [DATETIME]   NOT NULL
	,[Description] [NCHAR](100) COLLATE
SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE Emp_Skill
ADD CONSTRAINT PK_Emp_Skill PRIMARY KEY (SkillNo, EmpNo)
GO
ALTER TABLE Employee ADD CONSTRAINT [FK_1] FOREIGN KEY([DeptNo])
REFERENCES Department (DeptNo)
-- insert data
INSERT INTO [dbo].[Department]
	(DeptName, Note)
VALUES
	('Dept 1' ,'Note 1')
	,('Dept 2,' ,'Note 2')
	,('Dept 3,' ,'Note 3')
	,('Dept 4,' ,'Note 4')
	,('Dept 5,' ,'Note 5')
	,('Dept 6,' ,'Note 6')
	,('Dept 7,' ,'Note 7')
	,('Dept 8,' ,'Note 8')
GO
INSERT INTO [dbo].[Skill]
	(SkillName, Note)
VALUES
	('Skill 1' ,'Note 1')
	,('Skill 2,' ,'Note 2')
	,('Skill 3,' ,'Note 3')
	,('Skill 4,' ,'Note 4')
	,('Skill 5,' ,'Note 5')
	,('Skill 6,' ,'Note 6')
	,('Skill 7,' ,'Note 7')
	,('Skill 8,' ,'Note 8')
GO
INSERT INTO [dbo].[Employee]
	(EmpNo,EmpName, BirthDay, DeptNo, MgrNo, StartDate, Salary, [Status], Note, [Level], Email)
VALUES
	(1 ,'Binh Truong' ,'1997-08-25' ,1 ,0 ,'2018-05-03' ,250 ,1 ,'note 1' ,1 ,'binhtruong@gmail.com')
	,(2 ,'Binh Pham' ,'1997-08-15' ,1 ,0 ,'2020-05-03' ,250 ,1 ,'note 2' ,1 ,'binhtruong1@gmail.com')
	,(3 ,'Binh Tran' ,'1997-08-10' ,1 ,0 ,'2021-05-03' ,250 ,1 ,'note 3' ,1 ,'binhtruong2@gmail.com')
	,(4 ,'Binh Vu' ,'1997-08-05' ,1 ,0 ,'2022-05-03' ,250 ,1 ,'note 4' ,1 ,'binhtruong3@gmail.com')
	,(5 ,'Binh Le' ,'1997-08-03' ,1 ,0 ,'2020-08-03' ,250 ,1 ,'note 5' ,1 ,'binhtruong4@gmail.com')
	,(6 ,'Binh Lai' ,'1997-08-01' ,1 ,0 ,'2021-05-03' ,250 ,1 ,'note 6' ,1 ,'binhtruong5@gmail.com')
	,(7 ,'Binh Nguyen' ,'1997-08-02' ,1 ,0 ,'2015-05-03' ,250 ,1 ,'note 7'  ,1 ,'binhtruong6@gmail.com')
	,(8 ,'Binh Tong' ,'1997-01-01' ,1 ,0 ,'2022-04-03' ,250 ,1 ,'note 8' ,1 ,'binhtruong7@gmail.com')
GO
INSERT INTO [dbo].[Emp_Skill]
	(EmpNo, SkillNo, RegDate, SkillLevel, [Description])
VALUES
	(1 ,1 ,GETDATE() ,5 ,'Description 1')
	,(2 ,2 ,GETDATE() ,4 ,'Description 2')
	,(3 ,4 ,GETDATE()  ,7 ,'Description 3')
	,(4 ,3 ,GETDATE() ,3 ,'Description 4')
	,(5 ,2 ,GETDATE() ,5 ,'Description 5')
	,(6 ,4 ,GETDATE() ,4 ,'Description 6')
	,(7 ,5 ,GETDATE() ,6 ,'Description 7')
	,(8 ,6 ,GETDATE() ,7 ,'Description 8')
GO
-- store procedure to update all employee to level 2 for those with level 1 and work for at least 3 years
CREATE PROCEDURE [dbo].sp_UpdateEmpLevel2
	@Total INT out
AS
BEGIN
	UPDATE Employee SET [Level] = 2 WHERE [Level] = 1 AND DATEDIFF(YY, StartDate, GETDATE()) >= 3
	SELECT
		@Total = COUNT(em.[Level])
	FROM
		Employee AS em
	WHERE em.[Level] = 1 AND DATEDIFF(YY, StartDate, GETDATE()) >= 3
END
GO
DECLARE @Total INT
EXEC sp_UpdateEmpLevel2 @Total
SELECT
	@Total
GO
-- store procedure (with EmpNo parameter) to print out Employee name, employee email, address and departmemt name of employee that has been out
CREATE OR ALTER PROCEDURE [dbo].sp_printOutEmployee
	@EmpNo INT
AS
BEGIN
	IF @EmpNo = 0
	SELECT
		em.EmpName
		,em.Email
		,dp.DeptName
	FROM
		Employee AS em INNER JOIN Department AS dp ON em.DeptNo = dp.DeptNo
	WHERE em.[Status] = 0
	ELSE IF NOT EXISTS (SELECT
		em.EmpName
		,em.Email
		,dp.DeptName
	FROM
		Employee AS em INNER JOIN Department AS dp ON em.DeptNo = dp.DeptNo
	WHERE em.[Status] = 0 AND em.EmpNo = @EmpNo)
		SELECT
		em.EmpName
		,em.Email
		,dp.DeptName
	FROM
		Employee AS em INNER JOIN Department AS dp ON em.DeptNo = dp.DeptNo
	WHERE em.[Status] = 0 AND em.EmpNo = @EmpNo 
	ELSE
	PRINT 'This employeee is still working'
END
GO
DECLARE @EmpNoInput INT
SET @EmpNoInput = 0
EXEC sp_printOutEmployee @EmpNoInput
GO
-- write a function (with EmpNo parameter) to return the salary of employee that has been working
CREATE OR ALTER FUNCTION [dbo].udf_EmpTracking
	(@EmpNo INT)
returns TABLE
AS
RETURN
(
	SELECT
	em.EmpNo
	,em.EmpName
	,em.Salary
FROM
	Employee AS em
WHERE em.[Status] IN (1, 2) AND em.[EmpNo] = @EmpNo
)
GO
DECLARE @EmpNo INT
SET @EmpNo = 1
SELECT
	EmpNo
	,EmpName
	,Salary
FROM
	[dbo].udf_EmpTracking(@EmpNo)
GO
-- write a trigger preventing level = 1 and salary > 10000000 from being inputted into the database
CREATE OR ALTER TRIGGER [dbo].tg_PreventWrongInput ON Employee FOR UPDATE, INSERT
AS
	IF EXISTS (SELECT
	i.[Level]
FROM
	inserted AS i
WHERE i.[Level] = 1)
	RAISERROR('Level cannot be set to 1', 1, 1)
	ELSE IF EXISTS (SELECT
	i.[Level]
FROM
	inserted AS i
WHERE i.Salary > 10000000)
	RAISERROR('Salary cannot be higher than 10000000', 1, 1)
	ROLLBACK TRANSACTION
GO
INSERT INTO [dbo].[Employee]
	(EmpNo,EmpName, BirthDay, DeptNo, MgrNo, StartDate, Salary, [Status], Note, [Level], Email)
VALUES
	(9 ,'Binh Truong' ,'1997-08-25' ,5 ,0 ,'2018-05-03' ,1000000025 ,1 ,'note 1' ,2 ,'binhtruong10@gmail.com')
GO
