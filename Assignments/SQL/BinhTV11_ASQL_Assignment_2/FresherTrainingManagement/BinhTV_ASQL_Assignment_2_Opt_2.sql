-- Create a new database called 'AssignmentOpt'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
	SELECT
	[name]
FROM
	sys.databases
WHERE [name] = N'AssignmentTwo'
)
CREATE DATABASE AssignmentTwo
GO

USE AssignmentTwo
GO

--Q1
CREATE TABLE Department
(
	DeptNo    INT           PRIMARY KEY IDENTITY
	,DeptName NVARCHAR(50)  NOT NULL
	,Note     NVARCHAR(max)
)
GO
CREATE TABLE Skill
(
	SkillNo    INT           PRIMARY KEY IDENTITY
	,SkillName NVARCHAR(50)  NOT NULL
	,Note      NVARCHAR(max)
)
GO
CREATE TABLE Employee
(
	EmpNo      INT           PRIMARY KEY NOT NULL
	,EmpName   NVARCHAR(50)  NOT NULL
	,BirthDay  DATE          NOT NULL
	,DeptNo    INT           NOT NULL
	,MgrNo     INT           NOT NULL
	,StartDate DATE          NOT NULL
	,Salary    MONEY         NOT NULL
	,[Level]   INT           NOT NULL CHECK ([Level] BETWEEN 1 AND 7)
	,[Status]  INT           NOT NULL CHECK ([Status] BETWEEN 0 AND 2)
	,Note      NVARCHAR(max)
)
GO
CREATE TABLE Emp_Skill
(
	SkillNo     INT           NOT NULL
	,EmpNo       INT           NOT NULL
	,SkillLevel  INT           NOT NULL CHECK (SkillLevel BETWEEN 1 AND 3)
	,RegDate     DATE          NOT NULL
	,Description NVARCHAR(max)
	,PRIMARY KEY (SkillNo, EmpNo)
	,FOREIGN KEY (SkillNo) REFERENCES Skill(SkillNo)
	,FOREIGN KEY (EmpNo) REFERENCES Employee(EmpNo),
)
GO
-- Q2
ALTER TABLE dbo.Employee ADD Email nvarchar(100) NOT NULL UNIQUE
GO
ALTER TABLE dbo.Employee ADD CONSTRAINT df_MgrNo DEFAULT 0 FOR MgrNo
GO
ALTER TABLE dbo.Employee ADD CONSTRAINT df_Status DEFAULT 0 FOR [Status]
GO
-- Q3
ALTER TABLE dbo.Employee ADD CONSTRAINT fk_DeptNo FOREIGN KEY (DeptNo) REFERENCES Department(DeptNo)
GO
ALTER TABLE dbo.Emp_Skill DROP COLUMN [Description]
GO
-- Q4
--add data
INSERT INTO dbo.Department
	(DeptName, Note)
VALUES
	('Dev' ,'note one')
	,('Java' ,'note two')
	,('PHP' ,'note three')
	,('DotNet' ,'note four')
	,('Python' ,'note five')
GO
INSERT INTO dbo.Skill
	(SkillName, Note)
VALUES
	('Rust' ,'note one')
	,('Dota 2' ,'note two')
	,('CSGO' ,'note three')
	,('PUBG' ,'note four')
	,('Fortnite' ,'note five')
GO
INSERT INTO dbo.Employee
	(EmpNo, EmpName, BirthDay, DeptNo, StartDate, Salary, [Level], Note, Email)
VALUES
	(1 ,N'Bình Trương' ,'1997-05-26' ,1 ,GETDATE() ,25 ,4 ,'note one' ,'binhtruong1@gmail.com')
	,(2 ,N'Bình Phạm' ,'1997-08-25' ,2 ,GETDATE() ,25 ,2 ,'note two' ,'binhtruong2@gmail.com')
	,(3 ,N'Bình Trần' ,'1997-03-26' ,3 ,GETDATE() ,25 ,5 ,'note three' ,'binhtruong3@gmail.com')
	,(4 ,N'Bình Vũ' ,'1997-05-23' ,4 ,GETDATE() ,25 ,7 ,'note four' ,'binhtruong4@gmail.com')
	,(5 ,N'Bình Lê' ,'1997-01-26' ,4 ,GETDATE() ,25 ,4 ,'note five' ,'binhtruong5@gmail.com')
GO
INSERT INTO dbo.Emp_Skill
	(EmpNo, SkillNo, RegDate, SkillLevel)
VALUES
	(1 ,1 ,getdate() ,2)
	,(4 ,2 ,getdate() ,3)
	,(2 ,3 ,getdate() ,1)
	,(3 ,1 ,getdate() ,2)
	,(5 ,2 ,getdate() ,3)
GO
-- create view
CREATE VIEW vwEmployee_Tracking
AS
	SELECT
		emp.EmpNo
		,emp.EmpName AS Emp_Name
		,emp.[Level]
	FROM
		dbo.Employee AS emp
	WHERE emp.[Level] BETWEEN 3 AND 5
GO

SELECT
	*
FROM
	vwEmployee_Tracking
GO