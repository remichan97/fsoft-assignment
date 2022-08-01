-- Create a new database called 'AssignmentThreeOpt3'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
	SELECT
	[name]
FROM
	sys.databases
WHERE [name] = N'AssignmentThreeOpt3'
)
CREATE DATABASE AssignmentThreeOpt3
GO

USE AssignmentThreeOpt3
GO

--table creation:
CREATE TABLE Department
(
	DeptNo   INT           PRIMARY KEY IDENTITY
	,DeptName NVARCHAR(50)  NOT NULL
	,Note     NVARCHAR(max)
)
GO
CREATE TABLE Skill
(
	SkillNo   INT           PRIMARY KEY IDENTITY
	,SkillName NVARCHAR(50)  NOT NULL
	,Note      NVARCHAR(max)
)
GO
CREATE TABLE Employee
(
	EmpNo     INT           PRIMARY KEY IDENTITY
	,EmpName   NVARCHAR(50)  NOT NULL
	,BirthDay  DATE          NOT NULL
	,Email     NVARCHAR(150) NOT NULL UNIQUE
	,DeptNo    INT           NOT NULL
	,MgrNo     INT           NOT NULL DEFAULT 0
	,StartDate DATE          NOT NULL
	,Salary    MONEY         NOT NULL
	,[Level]   INT           NOT NULL CHECK ([Level] BETWEEN 1 AND 7)
	,[Status]  INT           NOT NULL CHECK ([Status] BETWEEN 0 AND 2) DEFAULT 0
	,Note      NVARCHAR(max)
	,FOREIGN KEY (DeptNo) REFERENCES Department(DeptNo)
)
GO
CREATE TABLE Emp_Skill
(
	SkillNo       INT           NOT NULL
	,EmpNo         INT           NOT NULL
	,SkillLevel    INT           NOT NULL CHECK ([SkillLevel] BETWEEN 1 AND 3)
	,RegDate       DATE          NOT NULL
	,[Description] NVARCHAR(max)
	,PRIMARY KEY (SkillNo, EmpNo)
	,FOREIGN KEY (SkillNo) REFERENCES Skill(SkillNo)
	,FOREIGN KEY (EmpNo) REFERENCES Employee(EmpNo)
)
GO
-- data insert:
INSERT INTO dbo.Department
	(DeptName, Note)
VALUES
	('Dept One' ,'Note One')
	,('Dept One' ,'Note One')
	,('Dept Two' ,'Note Two')
	,('Dept Three' ,'Note Three')
	,('Dept Four' ,'Note Four')
	,('Dept Five' ,'Note Five')
	,('Dept Six' ,'Note Six')
	,('Dept Seven' ,'Note Seven')
	,('Dept Eight' ,'Note Eight')
GO

INSERT INTO dbo.Skill
	(SkillName, Note)
VALUES
	('C++' ,'Note One')
	,('.NET' ,'Note One')
	,('Skill Two' ,'Note Two')
	,('Skill Three' ,'Note Three')
	,('Skill Four' ,'Note Four')
	,('Skill Five' ,'Note Five')
	,('Skill Six' ,'Note Six')
	,('Skill Seven' ,'Note Seven')
	,('Skill Eight' ,'Note Eight')
GO

INSERT INTO dbo.Employee
	(EmpName, BirthDay, Email, DeptNo, MgrNo, StartDate, Salary, [Level], Note)
VALUES
	('Binh Truong' ,'1997-04-08' ,'binh@gmail.com' ,1  ,0 ,GETDATE() ,120.5 ,7 ,'note one')
	,('Binh Pham' ,'1997-05-08' ,'binh1@gmail.com' ,2  ,0 ,GETDATE() ,120.5 ,6 ,'note two')
	,('Binh Tran' ,'1997-12-08' ,'binh2@gmail.com' ,3 ,1 ,GETDATE() ,120.5 ,1 ,'note one')
	,('Binh Hoa' ,'1997-02-25' ,'binh3@gmail.com' ,1 ,2 ,GETDATE() ,120.5 ,5 ,'note one')
	,('Binh Vu' ,'1997-07-08' ,'binh4@gmail.com' ,1 ,2 ,GETDATE() ,120.5 ,4 ,'note one')
	,('Binh Lai' ,'1997-09-08' ,'binh5@gmail.com' ,8 ,2 ,'2006-06-07' ,120.5 ,3 ,'note one')
	,('Binh Hoang' ,'1997-06-08' ,'binh6@gmail.com' ,1 ,1 ,GETDATE() ,120.5 ,5 ,'note one')
	,('Binh Nguyen' ,'1997-01-08' ,'binh7@gmail.com' ,3 ,2 ,GETDATE() ,120.5 ,3 ,'note one')

INSERT INTO dbo.Emp_Skill
	(SkillNo, EmpNo, RegDate, SkillLevel, [Description])
VALUES
	(1 ,1 ,GETDATE() ,2 ,'note 1')
	,(3 ,1 ,GETDATE() ,2 ,'note 2')
	,(3 ,8 ,GETDATE() ,2 ,'note 3')
	,(4 ,3 ,GETDATE() ,2 ,'note 4')
	,(6 ,4 ,GETDATE() ,2 ,'note 5')
	,(2 ,3 ,GETDATE() ,2 ,'note 6')
	,(2 ,5 ,GETDATE() ,2 ,'note 7')
	,(2 ,4 ,GETDATE() ,2 ,'note 8')
GO

-- Employee worked at least 6 months:
SELECT
	em.EmpName
	,em.Email
	,dp.DeptName
FROM
	Employee AS em INNER JOIN Department AS dp ON em.DeptNo = dp.DeptNo
GROUP BY em.EmpName,em.Email, dp.DeptName, em.StartDate
HAVING DATEDIFF(MM, em.StartDate, GETDATE()) >= 6
GO
-- Employee who have either C++ or .NET Skill
SELECT
	em.EmpName
FROM
	Employee AS em INNER JOIN Emp_Skill AS es ON es.EmpNo = em.EmpNo INNER JOIN Skill AS sk ON es.SkillNo = sk.SkillNo
WHERE sk.SkillName IN ('C++', '.NET')
GO
-- List employee name and their manager name
SELECT
	em1.EmpName
	,em2.EmpName AS 'Manager Name'
	,em2.Email AS 'Manager Email'
FROM
	Employee AS em1 LEFT JOIN Employee AS em2 ON em2.MgrNo = em1.EmpNo
GROUP BY em1.EmpName, em2.EmpName, em2.Email
GO
-- Department with more than 2 employee
SELECT
	dp.DeptName
	,em.EmpName
FROM
	Department AS dp INNER JOIN Employee AS em ON em.DeptNo = dp.DeptNo
WHERE dp.DeptNo IN (SELECT
	em.DeptNo
FROM
	Employee AS em
GROUP BY em.DeptNo
HAVING COUNT(em.DeptNo) >= 2)
GROUP BY dp.DeptName, em.EmpName
GO
-- List all employee name, email and their number skills
SELECT
	em.EmpName
	,em.Email
	,COUNT(es.SkillNo) AS '# of Skills'
FROM
	Employee AS em INNER JOIN Emp_Skill AS es ON es.EmpNo = em.EmpNo
GROUP BY em.EmpName, em.Email
GO
-- List employee with name, email, birthday with multiple skills and working
SELECT
	em.EmpName
	,em.Email
	,em.BirthDay
FROM
	Employee AS em INNER JOIN Emp_Skill AS es ON es.EmpNo = em.EmpNo
WHERE em.[Status] = 0
GROUP BY em.EmpName, em.Email, em.BirthDay
HAVING COUNT(es.EmpNo) >= 2
GO
-- Create a view to list all employee who is actively working
CREATE VIEW vwWorking
AS
	SELECT
		em.EmpName
		,dp.DeptName
		,sk.SkillName
	FROM
		Employee AS em INNER JOIN Emp_Skill AS es ON es.EmpNo = em.EmpNo INNER JOIN Department AS dp ON em.DeptNo = dp.DeptNo INNER JOIN Skill AS sk ON es.SkillNo = sk.SkillNo
	WHERE em.[Status] = 0
	GROUP BY em.EmpName, dp.DeptName, sk.SkillName
GO
SELECT
	*
FROM
	vwWorking
GO