CREATE DATABASE SafeTracSecondTest

USE SafeTracSecondTest

CREATE TABLE Users (
	Id INT IDENTITY (1, 1) PRIMARY KEY,
	First_Name NVARCHAR(255),
	Last_Name NVARCHAR(255),
	User_Password NVARCHAR(255),
	Email_Address NVARCHAR(255),
	Date_Created DATETIME,
	Date_Modified DATETIME
)

--insert into Users (First_Name, Last_Name, User_Password, Email_Address, Date_Created, Date_Modified) values ('Alberta', 'Shedd', 'RbQZW8Qr', 'ashedd0@squarespace.com', GETUTCDATE(), GETUTCDATE());
--insert into Users (First_Name, Last_Name, User_Password, Email_Address, Date_Created, Date_Modified) values ('Tildie', 'Gallgher', 'uqpBaNJ0M6i', 'tgallgher1@chronoengine.com', GETUTCDATE(), GETUTCDATE());
--insert into Users (First_Name, Last_Name, User_Password, Email_Address, Date_Created, Date_Modified) values ('Tobe', 'Fear', 'lCHyjRLei', 'tfear2@vkontakte.ru', GETUTCDATE(), GETUTCDATE());
--insert into Users (First_Name, Last_Name, User_Password, Email_Address, Date_Created, Date_Modified) values ('Venita', 'Alleway', 'QnCNeil3EC', 'valleway3@ebay.com', GETUTCDATE(), GETUTCDATE());

CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'SafeTracMasterKey@123'

CREATE CERTIFICATE Phat_Certificate WITH SUBJECT = 'Protect my data'

CREATE SYMMETRIC KEY SymKey_test WITH ALGORITHM = AES_256 ENCRYPTION BY CERTIFICATE Phat_Certificate;

OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Phat_Certificate;

UPDATE Users
SET Email_Address = EncryptByKey (Key_GUID('SymKey_test'), Email_Address)
FROM Users

CLOSE SYMMETRIC KEY SymKey_test

CREATE TABLE Areas (
	Id INT NOT NULL PRIMARY KEY,
	Area_Name NVARCHAR(255)
)

Insert into Areas (Id, Area_Name) VALUES (1, 'Training')
Insert into Areas (Id, Area_Name) VALUES (2, 'Reports')
Insert into Areas (Id, Area_Name) VALUES (4, 'Tags')
Insert into Areas (Id, Area_Name) VALUES (8, 'Tasks')

CREATE TABLE UserPermissions (
	Id INT IDENTITY (1, 1) PRIMARY KEY,
	User_Id INT NOT NULL,
	Permission INT NOT NULL,
	FOREIGN KEY (User_Id) REFERENCES Users(Id)
)

INSERT INTO UserPermissions (User_Id, Permission)
select Id, (((0 | 1) | 2) | 4) | 8 from Users
-- function
CREATE FUNCTION TO_AUS_DATETIME (@date DATETIME) 
RETURNS VARCHAR(100)
AS 
BEGIN
	RETURN FORMAT(@date, 'dd/MM/yyyy, hh:mm:ss tt')
END
GO

-- stored procedure
ALTER PROCEDURE GetUsers
@FirstName nvarchar(200) = '',
@LastName nvarchar(200) = '',
@Email nvarchar(200) = '',
@DateCreated nvarchar(200) = '',
@SortBy nvarchar(200) = '',
@SortDirection bit = 0
AS
BEGIN

	DECLARE @query varchar(max) = 
	'
	SELECT
		Id,
		First_Name, 
		Last_Name, 
		CONVERT(nvarchar, DecryptByKey(Email_Address)) AS Email_Address,
		dbo.TO_AUS_DATETIME(Date_Created) AS Date_Created
	FROM Users
	WHERE 1=1 
		AND (First_Name LIKE ''%'+@FirstName+'%'')
		AND (Last_Name LIKE ''%'+@LastName+'%'')
		AND (Email_Address LIKE ''%'+@Email+'%'')
	'

	IF @DateCreated IS NOT NULL AND @DateCreated <> ''
	BEGIN
		select @query = @query + 'AND (DATEDIFF(DAY,Date_Created,'+@DateCreated+') = 0)'
	END
	IF @SortBy IS NOT NULL AND @SortBy <> ''
	BEGIN
		SELECT @query = @query + ' ORDER BY ' + @SortBy + CASE WHEN @SortDirection = 0 THEN ' ASC' ELSE ' DESC' END
	END

	OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Phat_Certificate; 
	EXEC (@query)
	CLOSE SYMMETRIC KEY SymKey_test
END