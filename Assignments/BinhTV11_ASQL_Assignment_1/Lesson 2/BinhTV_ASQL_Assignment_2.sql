-- Create a new database called 'AssignmentOne'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
	SELECT
	[name]
FROM
	sys.databases
WHERE [name] = N'AssignmentOne'
)
CREATE DATABASE AssignmentOne
GO

USE AssignmentOne
GO
-- a: create tables and add values to tables
CREATE TABLE Trainee
(
	TraineeId         INT           PRIMARY KEY IDENTITY
	
	,Full_Name        NVARCHAR(200) NOT NULL
	
	,Birth_Date       DATE          NOT NULL
	
	,Gender           VARCHAR(6)    NOT NULL CHECK (Gender = 'Male' OR Gender = 'Female')
	
	,ET_IQ            INT           NOT NULL CHECK (ET_IQ >= 0 AND ET_IQ <= 20)
	
	,ET_Gmath         INT           NOT NULL CHECK (ET_Gmath >= 0 AND ET_Gmath <= 20)
	
	,ET_English       INT           NOT NULL CHECK (ET_English >= 0 AND ET_English <= 20)
	
	,Training_Class   NVARCHAR(40)  NOT NULL
	
	,Evaluation_Notes NVARCHAR(MAX)
)
GO
-- Insert data
INSERT INTO dbo.Trainee
	(Full_Name, Birth_Date, Gender, ET_IQ, ET_Gmath, ET_English, Training_Class, Evaluation_Notes)
VALUES
	(N'Bình Trương' ,'1997-08-25' ,'Male' ,8 ,8 ,8 ,'HN_Fresher_.NET' ,'none')
	,(N'Bình Trần' ,'1997-08-10' ,'Male' ,6 ,5 ,8 ,'HN_Fresher_.NET' ,'note one')
	,(N'Bình Đoàn' ,'1997-10-10' ,'Male' ,9 ,8 ,4 ,'HN_Fresher_.NET' ,'note two')
	,(N'Bình Nghiêm' ,'1997-11-04' ,'Male' ,13 ,10 ,10 ,'HN_Fresher_.NET' ,'note three')
	,(N'Bình Nguyễn' ,'1997-05-05' ,'Male' ,5 ,7 ,7 ,'HN_Fresher_.NET' ,'note four')
	,(N'Bình Phùng' ,'1997-01-20' ,'Male' ,9 ,8 ,9 ,'HN_Fresher_.NET' ,'note five')
	,(N'Bình Lưu' ,'1997-02-08' ,'Male' ,10 ,7 ,7 ,'HN_Fresher_.NET' ,'note six')
	,(N'Bình Phạm' ,'1997-10-08' ,'Male' ,8 ,10 ,15 ,'HN_Fresher_.NET' ,'note seven')
	,(N'Bình Vũ' ,'1997-11-21' ,'Male' ,8 ,8 ,13 ,'HN_Fresher_.NET' ,'note eigth')
	,(N'Bình Tên Rất Dài Nào Đó' ,'1997-11-08' ,'Male' ,9 ,9 ,13 ,'HN_Fresher_.NET' ,'note nine')
GO
SELECT
	t.TraineeId
	,t.Full_Name
	,t.Birth_Date
	,t.Gender
	,t.ET_IQ
	,t.ET_Gmath
	,t.ET_English
	,t.Training_Class
	,t.Evaluation_Notes
FROM
	dbo.Trainee AS t
-- b: Change the table Trainee to add one more field to the Trainee table with not null and unique constraint
ALTER TABLE dbo.Trainee ADD FSoft_Account NVARCHAR(30)
GO
UPDATE dbo.Trainee SET FSoft_Account = concat('BinhTV', Trainee.TraineeId)
GO
ALTER TABLE dbo.Trainee ALTER COLUMN FSoft_Account NVARCHAR(30) NOT NULL
GO
ALTER TABLE dbo.Trainee ADD CONSTRAINT uqTrainee_FSoftAccount UNIQUE (FSoft_Account)
GO
-- c: Create a view to show all passed trainee
CREATE VIEW vwShowPassedTrainee
AS
	SELECT
		t.TraineeId
		,t.Full_Name
		,t.Gender
		,t.Birth_Date
		,t.ET_IQ
		,t.ET_Gmath
		,t.ET_English
		,t.Training_Class
		,t.Evaluation_Notes
		,t.FSoft_Account
	FROM
		dbo.Trainee AS t
	WHERE t.ET_English >= 8 AND t.ET_Gmath >= 8 AND t.ET_IQ >= 8 AND (t.ET_English + t.ET_Gmath) >= 20
GO

SELECT
	*
FROM
	vwShowPassedTrainee
GO
-- d: Query all trainees who passed the entry test, group by birth months
SELECT
	t.TraineeId
	,t.Full_Name
	,t.Gender
	,t.Birth_Date
	,t.ET_IQ
	,t.ET_Gmath
	,t.ET_English
	,t.Training_Class
	,t.Evaluation_Notes
	,t.FSoft_Account
FROM
	dbo.Trainee AS t
WHERE t.ET_English >= 8 AND t.ET_Gmath >= 8 AND t.ET_IQ >= 8 AND (t.ET_English + t.ET_Gmath) >= 20
ORDER BY DATEPART(MONTH, t.Birth_Date)
GO
-- e: Query the trainee who has the longest name, showing his or her age along with basic information
SELECT
	TOP(1)
	t.TraineeId
	,t.Full_Name
	,DATEDIFF(yy, t.Birth_Date, GETDATE()) AS Age
	,t.ET_IQ
	,t.ET_Gmath
	,t.ET_English
	,t.Training_Class
	,t.Evaluation_Notes
	,t.FSoft_Account
FROM
	dbo.Trainee AS t
ORDER BY LEN(t.Full_Name) DESC