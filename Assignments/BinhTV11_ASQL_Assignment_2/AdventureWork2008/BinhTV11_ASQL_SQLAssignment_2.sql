USE AdventureWorks2008R2
GO
-- Query #1
SELECT
	prd.ProductID
	,prd.Name
	,prd.Color
	,prd.ListPrice
FROM
	Production.Product AS prd
GO
-- Query #2
SELECT
	prd.ProductID
	,prd.Name
	,prd.Color
	,prd.ListPrice
FROM
	Production.Product AS prd
WHERE prd.ListPrice > 0
GO
-- Query #3
SELECT
	prd.ProductID
	,prd.Name
	,prd.Color
	,prd.ListPrice
FROM
	Production.Product AS prd
WHERE prd.Color IS NULL
GO
-- Query #4
SELECT
	prd.ProductID
	,prd.Name
	,prd.Color
	,prd.ListPrice
FROM
	Production.Product AS prd
WHERE prd.Color IS NOT NULL
GO
-- Query #5
SELECT
	prd.ProductID
	,prd.Name
	,prd.Color
	,prd.ListPrice
FROM
	Production.Product AS prd
WHERE prd.Color IS NOT NULL AND prd.ListPrice > 0
GO
-- Query #6
SELECT
	CONCAT(prd.Name, ' : ', prd.Color) AS 'Name and Colour'
FROM
	Production.Product AS prd
WHERE prd.Color IS NOT NULL
GO
-- Query #7
SELECT
	CONCAT('NAME: ', prd.Name, ' -- ', 'COLOUR: ', prd.Color) AS 'Name and Colour'
FROM
	Production.Product AS prd
WHERE prd.Color IS NOT NULL
GO
-- Query #8
SELECT
	prd.ProductID
	,prd.Name
FROM
	Production.Product AS prd
WHERE prd.ProductID BETWEEN 400 AND 500
GO
-- Query #9
SELECT
	prd.ProductID
	,prd.Name
	,prd.Color
FROM
	Production.Product AS prd
WHERE prd.Color IN ('Black', 'Blue')
GO
-- Query #10
SELECT
	prd.Name
	,prd.ListPrice
FROM
	Production.Product AS prd
WHERE prd.Name LIKE 'S%'
ORDER BY prd.Name ASC
GO
-- Query #11
SELECT
	prd.Name
	,prd.ListPrice
FROM
	Production.Product AS prd
WHERE prd.Name LIKE '[SA]%'
ORDER BY prd.Name ASC
GO
-- Query #12
SELECT
	prd.Name
	,prd.ListPrice
FROM
	Production.Product AS prd
WHERE prd.Name LIKE 'SPO[^K]%'
ORDER BY prd.Name ASC
GO
-- Query #13
SELECT
	DISTINCT
	prd.Color
FROM
	Production.Product AS prd

-- Query #14
SELECT
	prd.ProductSubcategoryID
	,prd.Color
FROM
	Production.Product AS prd
GROUP BY prd.ProductSubcategoryID, prd.Color
HAVING prd.ProductSubcategoryID IS NOT NULL AND prd.Color IS NOT NULL
GO
--Query #15
SELECT
	ProductSubCategoryID
 
	,LEFT([Name],35) AS [Name]
 
	,Color
	,ListPrice
FROM
	Production.Product
WHERE Color IN ('Red','Black')
	AND ProductSubCategoryID = 1
	OR ListPrice BETWEEN 1000 AND 2000
ORDER BY ProductID
GO
--Query #16
SELECT
	prd.Name
	,CASE WHEN prd.Color IS NULL THEN 'Unknown' ELSE prd.Color END AS 'Color'
	,prd.ListPrice
FROM
	Production.Product AS prd
GO