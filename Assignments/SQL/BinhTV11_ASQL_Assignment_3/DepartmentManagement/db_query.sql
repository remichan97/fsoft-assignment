USE DMS
GO

INSERT INTO dbo.Act
	(ActNo, ActDesc)
VALUES
	(90 ,'act one')
	,(95 ,'act two')
	,(98 ,'act three')
	,(101 ,'act four')
	,(110 ,'act five')
	,(180 ,'act six')
	,(85 ,'act seven')
	,(99 ,'act eigth')
GO
INSERT INTO dbo.Emp
	(EmpNo, LastName, FirstName, Job, Salary, Bonus, EduLevel)
VALUES
	('EMP001' ,'Binh' ,'Truong' ,'Java Dev' ,125 ,NULL ,2)
	,('EMP002' ,'Binh' ,'Vu' ,'.NET Dev' ,125 ,NULL ,2)
	,('EMP003' ,'Binh' ,'Tran' ,'C++ Dev' ,128.6 ,NULL ,5)
	,('EMP004' ,'Binh' ,'Pham' ,'Python Dev' ,250.5 ,145 ,7)
	,('EMP005' ,'Binh' ,'Hai' ,'.NET Dev' ,250 ,NULL ,2)
	,('EMP006' ,'Binh' ,'Lai' ,'Java Dev' ,150 ,NULL ,3)
	,('EMP007' ,'Binh' ,'Pham' ,'Python Dev' ,850 ,120 ,4)
	,('EMP008' ,'Binh' ,'Nguyen' ,'Java Dev' ,255 ,NULL ,1)
GO
INSERT INTO dbo.EmpMajor
	(EmpNo, Major, MajorName)
VALUES
	('EMP001' ,'CSI' ,'Computer Science')
	,('EMP001' ,'MAT' ,'Math')
	,('EMP002' ,'CSI' ,'Computer Science')
	,('EMP003' ,'CSI' ,'Computer Science')
	,('EMP004' ,'MAT' ,'Math')
	,('EMP005' ,'CSI' ,'Computer Science')
	,('EMP005' ,'MAT' ,'Math')
	,('EMP007' ,'CSI' ,'Computer Science')
GO
INSERT INTO dbo.Dept
	(DeptNo, DeptName, AdminDept,[Location])
VALUES
	('D01' ,'Python' ,'EMP004' ,'Hanoi')
	,('D02' ,'Java' ,'EMP006' ,'Hanoi')
	,('D03' ,'.NET' ,'EMP002' ,'Hanoi')
	,('D04' ,'C++' ,NULL ,'Hanoi')
	,('D05' ,'Ruby' ,NULL ,'Hanoi')
	,('D06' ,'Rail' ,NULL ,'Hanoi')
	,('D07' ,'React' ,NULL ,'Hanoi')
	,('D08' ,'Web' ,NULL ,'Hanoi')
GO
INSERT INTO dbo.Manager
	(EmpNo, DeptNo, IsManager)
VALUES
	('EMP001' ,'D02' ,0)
	,('EMP002' ,'D03' ,1)
	,('EMP003' ,'D03' ,0)
	,('EMP004' ,'D02' ,1)
	,('EMP005' ,'D03' ,0)
	,('EMP006' ,'D02' ,1)
	,('EMP007' ,'D01' ,0)
	,('EMP008' ,'D02' ,0)
GO
INSERT INTO dbo.EmpProAct
	(EmpNo, ProjNo, ActNo)
VALUES
	('EMP001' ,'PRJ001' ,90)
	,('EMP002' ,'PRJ002' ,180)
	,('EMP003' ,'PRJ004' ,95)
	,('EMP004' ,'PRJ005' ,85)
	,('EMP001' ,'PRJ006' ,85)
	,('EMP003' ,'PRJ007' ,99)
	,('EMP002' ,'PRJ008' ,101)
	,('EMP005' ,'PRJ006' ,180)
GO
-- Employee working on Project
SELECT
	ema.EmpNo
	,em.FirstName
	,em.LastName
FROM
	Emp AS em INNER JOIN EmpProAct AS ema ON ema.EmpNo = em.EmpNo
GROUP BY ema.EmpNo, em.FirstName, em.LastName
HAVING COUNT(ema.EmpNo) >= 2
GO
-- Employee majors in MAT and CSI
SELECT
	em.EmpNo
	,emp.FirstName
	,emp.LastName
	,em.MajorName
FROM
	Emp AS emp INNER JOIN EmpMajor em ON em.EmpNo = emp.EmpNo
WHERE em.Major IN ('MAT', 'CSI') AND em.EmpNo IN (SELECT
		e.EmpNo
	FROM
		EmpMajor AS e
	GROUP BY e.EmpNo
	HAVING COUNT(e.Major) > 1)
GROUP BY em.EmpNo, emp.FirstName, emp.LastName, em.MajorName
GO
-- Employeee with activities from 90 to 110
SELECT
	em.EmpNo
	,em.FirstName
	,em.LastName
FROM
	Emp AS em INNER JOIN EmpProAct AS epa ON epa.EmpNo = em.EmpNo
WHERE epa.ActNo BETWEEN 90 AND 110
GROUP BY em.EmpNo, em.FirstName, em.LastName
GO
-- Print department number, department name, total payroll of the highest payroll
SELECT
	TOP(1)
	dp.DeptNo
	,dp.DeptName
	,CASE WHEN em.Bonus IS NULL THEN SUM(em.Salary) ELSE SUM(em.Bonus + em.Salary) END AS 'Payroll'
FROM
	Dept AS dp INNER JOIN Manager AS ma ON ma.DeptNo = dp.DeptNo INNER JOIN Emp AS em ON ma.EmpNo = em.EmpNo
GROUP BY dp.DeptNo, dp.DeptName, em.Bonus
GO
-- Return top 5 employee with high salaries (can be duplicate)
SELECT
	TOP(5)
	RANK() OVER (ORDER BY em.Salary DESC) AS RANK_NO
	,em.EmpNo
	,em.FirstName
	,em.LastName
	,em.Salary
FROM
	Emp AS em
GO
-- Return top 5 employee with high salaries (no duplicate)
SELECT
	TOP(5)
	DENSE_RANK() OVER (ORDER BY em.Salary DESC) AS RANK_NO
	,em.EmpNo
	,em.FirstName
	,em.LastName
	,em.Salary
FROM
	Emp AS em
GO