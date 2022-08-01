-- Create a new database called 'AssignmentThreeOpt2'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
	SELECT
	[name]
FROM
	sys.databases
WHERE [name] = N'AssignmentThreeOpt2'
)
CREATE DATABASE AssignmentThreeOpt2
GO

USE AssignmentThreeOpt2
GO

-- Q1
-- table creation
CREATE TABLE San_Pham
(
	Ma_SP   VARCHAR(5)   PRIMARY KEY
	,Ten_SP  NVARCHAR(30) NOT NULL
	,Don_Gia DECIMAL      NOT NULL
)
GO
CREATE TABLE Khach_Hang
(
	Ma_KH    VARCHAR(5)    PRIMARY KEY
	,Ten_KH   NVARCHAR(30)  NOT NULL
	,Phone_No CHAR(18)      NOT NULL
	,Ghi_Chu  NVARCHAR(max)
)
GO
CREATE TABLE Don_Hang
(
	Ma_DH    INT        PRIMARY KEY IDENTITY
	,Ngay_DH  DATE       NOT NULL
	,Ma_SP    VARCHAR(5) NOT NULL
	,So_Luong INT        NOT NULL
	,Ma_KH    VARCHAR(5) NOT NULL
	,FOREIGN KEY (Ma_SP) REFERENCES San_Pham(Ma_SP)
	,FOREIGN KEY (Ma_KH) REFERENCES Khach_Hang(Ma_KH)
)
GO
-- insert data
INSERT INTO San_Pham
	(Ma_SP, Ten_SP, Don_Gia)
VALUES
	('ACS12' ,'San pham 1' ,125.2)
	,('ACS13' ,'San pham 2' ,125.2)
	,('ACS14' ,'San pham 3' ,123.2)
GO
INSERT INTO Khach_Hang
	(Ma_KH, Ten_KH, Phone_No, Ghi_Chu)
VALUES
	('KH01' ,'Binh Truong' ,'+84912378516' ,'note 1')
	,('KH02' ,'Binh Pham' ,'+84912378526' ,'note 2')
	,('KH03' ,'Binh Vu' ,'+84912378236' ,'note 3')
GO
INSERT INTO Don_Hang
	(Ngay_DH, Ma_SP, So_Luong, Ma_KH)
VALUES
	(GETDATE() ,'ACS12' ,2 ,'KH01')
	,(GETDATE() ,'ACS13' ,3 ,'KH01')
	,(GETDATE() ,'ACS13' ,7 ,'KH03')
	,(GETDATE() ,'ACS13' ,7 ,'KH01')
GO
-- create view
CREATE VIEW vwOrderSlip
AS
	SELECT
		kh.Ten_KH
		,dh.Ngay_DH
		,spm.Ten_SP
		,dh.So_Luong
		,(spm.Don_Gia * dh.So_Luong) AS 'Thanh_Tien'
	FROM
		Don_Hang AS dh LEFT JOIN Khach_Hang AS kh ON dh.Ma_KH = kh.Ma_KH INNER JOIN San_Pham AS spm ON dh.Ma_SP = spm.Ma_SP
GO

-- Q2
-- table creation
CREATE TABLE Department
(
	Department_Number INT          PRIMARY KEY IDENTITY
	,Department_Name   NVARCHAR(50) NOT NULL,
)
GO
CREATE TABLE Skill
(
	Skill_Number INT          PRIMARY KEY IDENTITY
	,Skill_Name   NVARCHAR(50) NOT NULL,
)
GO
CREATE TABLE Employee_Table
(
	Employee_Number   INT          PRIMARY KEY IDENTITY
	,Employee_Name     NVARCHAR(50) NOT NULL
	,Department_Number INT          NOT NULL
	,FOREIGN KEY (Department_Number) REFERENCES Department(Department_Number)
)
GO
CREATE TABLE Employee_Skill
(
	Employee_Number INT  NOT NULL
	,Skill_Number    INT  NOT NULL
	,Date_Registered DATE NOT NULL
	,FOREIGN KEY (Employee_Number) REFERENCES Employee_Table(Employee_Number)
	,FOREIGN KEY (Skill_Number) REFERENCES Skill(Skill_Number),
)
GO

--data insert
INSERT INTO Department
	(Department_Name)
VALUES
	('Java Dev')
	,('Python Dev')
	,('.NET Dev')
GO

INSERT INTO Skill
	(Skill_Name)
VALUES
	('Java')
	,('.NET')
	,('Python')
GO

INSERT INTO Employee_Table
	(Employee_Name, Department_Number)
VALUES
	('Binh Truong' ,1)
	,('Binh Pham' ,2)
	,('Binh Vu' ,2)
GO

INSERT INTO Employee_Skill
	(Skill_Number, Employee_Number, Date_Registered)
VALUES
	(1 ,1 ,GETDATE())
	,(3 ,2 ,GETDATE())
	,(3 ,3 ,GETDATE())

-- Emp with Java skill using join
SELECT
	em.Employee_Name
FROM
	Employee_Table AS em INNER JOIN Employee_Skill AS ems ON ems.Employee_Number = em.Employee_Number INNER JOIN Skill AS sk ON ems.Skill_Number = sk.Skill_Number
WHERE sk.Skill_Name LIKE 'Java'
GO
-- Emp with Java skill using sub-query
SELECT
	em.Employee_Name
FROM
	Employee_Table AS em INNER JOIN Employee_Skill AS ems ON ems.Employee_Number = em.Employee_Number
WHERE ems.Skill_Number IN (SELECT
	sk.Skill_Number
FROM
	Skill AS sk
WHERE sk.Skill_Name LIKE 'Java')
GO
-- Dep with more than 3 emp
SELECT
	dp.Department_Name
	,em.Employee_Name
FROM
	Employee_Table AS em INNER JOIN Department AS dp ON em.Department_Number = dp.Department_Number
WHERE em.Department_Number IN (SELECT
	em.Department_Number
FROM
	Employee_Table AS em
GROUP BY em.Department_Number
HAVING count(em.Department_Number) >= 3
)
GO
-- List peopple with multiple skills
SELECT
	em.Employee_Name
FROM
	Employee_Table AS em INNER JOIN Employee_Skill AS ek ON em.Employee_Number = ek.Employee_Number
WHERE em.Employee_Number IN (SELECT
	ek.Employee_Number
FROM
	Employee_Skill AS ek
GROUP BY ek.Employee_Number
HAVING count(ek.Skill_Number) > 2)
GO
-- create view to list people with multiple skills
CREATE VIEW vwMultiSkill
AS
	SELECT
		em.Employee_Number
		,em.Employee_Name
		,dp.Department_Name
	FROM
		Employee_Table AS em INNER JOIN Employee_Skill AS ek ON em.Employee_Number = ek.Employee_Number INNER JOIN Department AS dp ON em.Department_Number = dp.Department_Number
	WHERE em.Employee_Number IN (SELECT
		ek.Employee_Number
	FROM
		Employee_Skill AS ek
	GROUP BY ek.Employee_Number
	HAVING count(ek.Skill_Number) > 2)
GO
SELECT
	*
FROM
	vwMultiSkill
GO