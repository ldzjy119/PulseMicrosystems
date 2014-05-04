/*
Create the Database and Tables
*/

CREATE DATABASE [PulseMicrosystems];

USE [PulseMicrosystems];

CREATE TABLE Template
(
   ID			INT IDENTITY(1,1) PRIMARY KEY,
   Name			VARCHAR(30) UNIQUE,
   IsSelected	bit
);

CREATE TABLE TemplateFields
(
   ID			INT IDENTITY(1,1) PRIMARY KEY,
   Name			VARCHAR(30) NOT NULL UNIQUE,
   TemplateId	INT,
   FOREIGN KEY (TemplateId) REFERENCES Template(ID)
);

CREATE TABLE Template1
(
   ID			INT IDENTITY(1,1) PRIMARY KEY,
   FirstName	VARCHAR(30) NOT NULL ,
   LastName		VARCHAR(30) NOT NULL 
);

CREATE TABLE Template2
(
   ID			INT IDENTITY(1,1) PRIMARY KEY,
   Hometown		VARCHAR(30) NOT NULL 
);

CREATE TABLE Template3
(
   ID			INT IDENTITY(1,1) PRIMARY KEY,
   SpouseName	VARCHAR(30) NOT NULL ,
   KidName1		VARCHAR(30) ,
   KidName2		VARCHAR(30) 
);

CREATE TABLE Users
(
   ID			INT IDENTITY(1,1) PRIMARY KEY,
   Name			VARCHAR(30) NOT NULL ,
   Address		VARCHAR(30) NOT NULL
);

CREATE TABLE UserData
(
   ID			INT IDENTITY(1,1) PRIMARY KEY,
   UserID		INT	NOT NULL UNIQUE,
   Template1ID	INT	,
   Template2ID	INT	,
   Template3ID	INT	,
   FOREIGN KEY (UserId)		 REFERENCES Users(ID),
   FOREIGN KEY (Template1Id) REFERENCES Template1(ID),
   FOREIGN KEY (Template2Id) REFERENCES Template2(ID),
   FOREIGN KEY (Template3Id) REFERENCES Template3(ID)
);


/* 
Populated tables with testing data
*/

INSERT INTO Template (name) VALUES ('Template1');
INSERT INTO Template (name) VALUES ('Template2');
INSERT INTO Template (name) VALUES ('Template3');

UPDATE Template SET IsSelected = 1 where ID = 1

INSERT INTO TemplateFields (Name, TemplateId) VALUES ('First_Name', 1);
INSERT INTO TemplateFields (Name, TemplateId) VALUES ('Last_Name', 1);

INSERT INTO TemplateFields (Name, TemplateId) VALUES ('Home_Town', 2);

INSERT INTO TemplateFields (Name, TemplateId) VALUES ('Spouse''s_Name', 3);
INSERT INTO TemplateFields (Name, TemplateId) VALUES ('Kid''s_Name_#1', 3);
INSERT INTO TemplateFields (Name, TemplateId) VALUES ('Kid''s_Name_#2', 3);
