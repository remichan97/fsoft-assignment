-- Create a new database called 'DMS'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
	SELECT
	[name]
FROM
	sys.databases
WHERE [name] = N'DMS'
)
CREATE DATABASE DMS
GO

USE DMS
GO

CREATE TABLE Act
(
	ActNo   INT           PRIMARY KEY
	,ActDesc NVARCHAR(150) NOT NULL,
)
GO
CREATE TABLE Emp
(
	EmpNo     CHAR(6)      PRIMARY KEY
	,LastName  NVARCHAR(50) NOT NULL
	,FirstName NVARCHAR(50) NOT NULL
	,Job       VARCHAR(50)  NULL
	,Salary    MONEY        NOT NULL
	,Bonus     MONEY        NULL
	,EduLevel  INT          NULL,
)
GO

CREATE TABLE EmpMajor
(
	EmpNo     CHAR(6)     NOT NULL
	,Major     CHAR(3)     NOT NULL
	,MajorName VARCHAR(50) NOT NULL
		PRIMARY KEY (EmpNo, Major)
	,FOREIGN KEY (EmpNo) REFERENCES Emp(EmpNo)
)

CREATE TABLE Dept
(
	DeptNo     CHAR(3)       PRIMARY KEY
	,DeptName   VARCHAR(50)   NOT NULL
	,AdminDept  CHAR(6)       NULL
	,[Location] NVARCHAR(150) NOT NULL
	,FOREIGN KEY (AdminDept) REFERENCES Emp(EmpNo)
)

CREATE TABLE Manager
(
	EmpNo     CHAR(6) NOT NULL
	,DeptNo    CHAR(3) NOT NULL
	,IsManager BIT     NOT NULL
	,PRIMARY KEY (EmpNo, DeptNo)
	,FOREIGN KEY (EmpNo) REFERENCES Emp(EmpNo)
	,FOREIGN KEY (DeptNo) REFERENCES Dept(DeptNo)
)

CREATE TABLE EmpProAct
(
	EmpNo  CHAR(6) NOT NULL
	,ProjNo CHAR(6) NOT NULL
	,ActNo  INT     NOT NULL
	,PRIMARY KEY (EmpNo, ProjNo, ActNo)
	,FOREIGN KEY (EmpNo) REFERENCES Emp(EmpNo)
	,FOREIGN KEY (ActNo) REFERENCES Act(ActNo)
)


