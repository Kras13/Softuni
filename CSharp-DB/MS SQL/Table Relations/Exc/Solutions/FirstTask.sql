CREATE DATABASE EntityRelationsDemo

USE EntityRelationsDemo

-----------below is solution-----------

CREATE Table Passports(
	PassportId INT Primary Key NOT NULL,
	PassportNumber CHAR(8) NOT NULL
)

CREATE Table Persons(
	PersonId INT Primary Key IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	Salary DECIMAL(8,2) NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE
)

INSERT INTO Passports(PassportId,PassportNumber)
	VALUES
		(101, 'N34FG21B'),
		(102, 'K65LO4R7'),
		(103, 'ZE657QP2')


INSERT INTO Persons(FirstName,Salary,PassportID)
	VALUES
		('Roberto',43300.00,102),
		('TOM',56100.00,103),
		('YANA',60200.00,101)
