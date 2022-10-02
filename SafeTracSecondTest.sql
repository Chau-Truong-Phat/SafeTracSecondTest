--https://www.youtube.com/watch?v=EVvZLfJtAK8
--https://www.sqlshack.com/an-overview-of-the-column-level-sql-server-encryption/

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

CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'SafeTracMasterKey@123'

SELECT name KeyName, 
    symmetric_key_id KeyID, 
    key_length KeyLength, 
    algorithm_desc KeyAlgorithm
FROM sys.symmetric_keys

CREATE CERTIFICATE Phat_Certificate WITH SUBJECT = 'Protect my data'

SELECT name CertName, 
    certificate_id CertID, 
    pvt_key_encryption_type_desc EncryptType, 
    issuer_name Issuer
FROM sys.certificates

CREATE SYMMETRIC KEY SymKey_test WITH ALGORITHM = AES_256 ENCRYPTION BY CERTIFICATE Phat_Certificate;

SELECT name KeyName, 
    symmetric_key_id KeyID, 
    key_length KeyLength, 
    algorithm_desc KeyAlgorithm
FROM sys.symmetric_keys

OPEN SYMMETRIC KEY SymKey_test DECRYPTION BY CERTIFICATE Phat_Certificate;

UPDATE Users
SET Email_Address = EncryptByKey (Key_GUID('SymKey_test'), Email_Address)
FROM Users

CLOSE SYMMETRIC KEY SymKey_test

CREATE TABLE Areas (
	Id INT NOT NULL PRIMARY KEY,
	Area_Name NVARCHAR(255)
)

--Insert into Areas (Id, Area_Name) VALUES (1, 'Training') --0001
--Insert into Areas (Id, Area_Name) VALUES (2, 'Reports') --0010
--Insert into Areas (Id, Area_Name) VALUES (4, 'Tags') --0011
--Insert into Areas (Id, Area_Name) VALUES (8, 'Tasks') --0100

CREATE TABLE UserPermissions (
	Id INT IDENTITY (1, 1) PRIMARY KEY,
	User_Id INT NOT NULL,
	Permission INT NOT NULL,
	FOREIGN KEY (User_Id) REFERENCES Users(Id)
)

INSERT INTO UserPermissions (User_Id, Permission)
select Id, (((0 | 1) | 2) | 4) | 8 from Users
