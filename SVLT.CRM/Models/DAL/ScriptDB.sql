﻿--
CREATE DATABASE dbSVLT
GO

--
USE dbSVLT
GO

--
CREATE TABLE TablesSVLT
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Age INT NOT NULL,
	Height DECIMAL(3,2) NOT NULL,
	Birthdate DATETIME NOT NULL
)
GO
