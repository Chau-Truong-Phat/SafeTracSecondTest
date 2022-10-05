--1.	I have 2 stored procedures on the same database and I want to have a temporary table that they can both access at the same time. How can I do this?
--Answer: 
--			Because SQL SQL Server will create an instance of the temp table per instance of the stored procedure, and it will only be visible to the creating scope
--			So we need to create one in the outer then run stored procedures, all of stored procedures can access to the temp table with full data
--			Or we can use Global Temporary Table for this point
CREATE TABLE ##UserDetails (id INT, name VARCHAR(25)) 
--select Id, First_Name from Users

ALTER PROC MainProc
AS
BEGIN
	CREATE TABLE #UserDetails (id INT, name VARCHAR(25)) 
	EXEC SupProc1 --Insert
	EXEC SupProc2 --Delete
END

ALTER PROC SupProc1
AS
BEGIN
	Insert INTO #UserDetails
	select Id, First_Name from Users

	select * from #UserDetails
END
ALTER PROC SupProc2
AS
BEGIN
	SELECT * from #UserDetails
END

EXEC MainProc
EXEC SupProc1 
EXEC SupProc2

--2.	Please write a stored procedure that will loop through a temporary table a record at a time without using a cursor.
--Answer
ALTER PROCEDURE loopTest
AS
BEGIN
	DECLARE @Counter INT
	DECLARE @UsersLength INT
	CREATE TABLE #UserTest (id INT, name VARCHAR(25), age INT)
	INSERT INTO #UserTest select id, First_Name, 0 from Users

	SELECT * from #UserTest

	SELECT @UsersLength = COUNT(*)
	FROM Users

	SET @COUNTER = 0
	WHILE (@Counter < @UsersLength)
	BEGIN
		UPDATE #UserTest
		SET age = (@COUNTER + 1) *2
		where Id = @COUNTER + 1

		SET @Counter = @Counter + 1
	END

	select * from #UserTest
END

EXEC loopTest
--3.	How can I optimize this query if it’s running too slow and there are over a million of record in each table?
--Answer

-- Select specifical columns which we need to check, we don’t check all unnecessary fields
-- Use TOP to limit result
-- Add Index on JOIN condition and WHERE condition

CREATE INDEX idxA ON tableA(ColumnA, ColumnD)
CREATE INDEX idxB ON tableB(ColumnB)
CREATE INDEX idxC ON tableC(ColumnC)

SELECT TOP 100 A.ColumnA, A.ColumnB, B.ColumnA, ...
FROM tableA A
	INNER JOIN tableB B ON A.ColumnA = B.ColumnB
	INNER JOIN tableC C ON B.ColumnA = C.ColumnB
WHERE A.ColumnD = 'ABC'

--4.	How can I find duplicate record with one field?
--Answer
--Write query to verify duplicates exist

--INSERT INTO Users
--select First_Name, Last_Name, User_Password, Email_Address, Date_Created, Date_Modified from Users

SELECT First_Name
FROM Users
GROUP BY First_Name
HAVING COUNT (*) > 1
--List all rows containing duplicates
SELECT a.*
FROM Users a
JOIN (
	SELECT First_Name
	FROM Users
	GROUP BY First_Name
	HAVING COUNT(*) > 1
) b ON a.First_Name = b.First_Name

--5.	Name some coding functionality/styles/architecture/etc that you have used to increase the scalability of an application.
-- Answer: we can use some ways below for the scalability of an application:
-- Apply architecture like MVC, Microservices 
-- Apply coding convention for easy to maintaince
