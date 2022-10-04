--1.	I have 2 stored procedures on the same database and I want to have a temporary table that they can both access at the same time. How can I do this?
--Answer: We can excute stored procedure in other one
CREATE PROC MainProc
AS
BEGIN
	EXEC SupProc1 --Insert
	EXEC SupProc2 --Delete
END

CREATE PROC SupProc1
AS
BEGIN
	INSERT INTO TableA
END
CREATE PROC SupProc2
AS
BEGIN
	DELETE FROM TableA
END

EXEC MainProc
-- Merge two stored procedures into the only one with a specifical mission

--2.	Please write a stored procedure that will loop through a temporary table a record at a time without using a cursor.
--Answer
DECLARE @Counter INT
DECLARE @UsersLength INT

SELECT @UsersLength = COUNT(*)
FROM Users

SET @COUNTER = 0
WHILE (@Counter < @UserLength)
BEGIN
	-- Do something with data
	SET @Counter = @Counter + 1
END

--3.	How can I optimize this query if it’s running too slow and there are over a million of record in each table?
--Answer

-- Select specifical columns which we need to check, we don’t check all unnecessary fields
-- Use TOP to limit result
SELECT TOP 100 A.ColumnA, A.ColumnB, B.ColumnA, ...
FROM tableA A
	INNER JOIN tableB B ON A.ColumnA = B.ColumnB
	INNER JOIN tableC C ON B.ColumnA = C.ColumnB
WHERE A.ColumnD = 'ABC'
-- Add Index on where condition
CREATE INDEX idx ON tableA(ColumnD)

--4.	How can I find duplicate record with one field?
--Answer
--4.1/ Write query to verify duplicates exist
SELECT First_Name, Last_Name
FROM Users
GROUP BY First_Name, Last_Name
HAVING COUNT (*) > 1
--4.2/ List all rows containing duplicates
SELECT a.*
FROM Users a
JOIN (
	SELECT First_Name, Last_Name
	FROM Users
	GROUP BY First_Name, Last_Name
	HAVING COUNT(*) > 1
) b ON a.First_Name = b.First_Name
AND a.Last_Name = b.Last_Name

--5.	Name some coding functionality/styles/architecture/etc that you have used to increase the scalability of an application.
--Answer: we can use design pattern like MVC, Microservices and API to increase the scalability of an application