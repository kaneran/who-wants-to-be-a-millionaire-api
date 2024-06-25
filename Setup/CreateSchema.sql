IF NOT EXISTS(SELECT 1 FROM sys.databases WHERE name = 'WWTBAM')
BEGIN 
    CREATE DATABASE WWTBAM;
END
GO

USE [WWTBAM];
GO

IF NOT EXISTS (SELECT 1 FROM sysobjects WHERE name='Answer_Type' AND xtype='U')
BEGIN
    CREATE TABLE Answer_Type (
        Answer_Type_CD char(1) PRIMARY KEY NOT NULL,
        Name varchar(255) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sysobjects WHERE name='Category' AND xtype='U')
BEGIN
    CREATE TABLE Category (
        Category_ID int PRIMARY KEY IDENTITY NOT NULL,
        Name varchar(255) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sysobjects WHERE name='Question' AND xtype='U')
BEGIN
    CREATE TABLE Question (
        Question_ID int PRIMARY KEY IDENTITY NOT NULL,
        Text varchar(max) NOT NULL,
        Category_ID int NOT NULL,
        FOREIGN KEY (Category_ID) REFERENCES Category(Category_ID)
    );
END

IF NOT EXISTS (SELECT 1 FROM sysobjects WHERE name='Answer' AND xtype='U')
BEGIN
    CREATE TABLE Answer (
        Answer_ID int PRIMARY KEY IDENTITY NOT NULL,
        Text varchar(max) NOT NULL,
        Answer_Type_CD char(1) NOT NULL,
        Question_ID INT NOT NULL,
        FOREIGN KEY (Answer_Type_CD) REFERENCES Answer_Type(Answer_Type_CD),
        FOREIGN KEY (Question_ID) REFERENCES Question(Question_ID)
    );
END

IF NOT EXISTS (SELECT 1 FROM sysobjects WHERE name='Score' AND xtype='U')
BEGIN
    CREATE TABLE Score (
        Score_ID int PRIMARY KEY IDENTITY NOT NULL,
        Correct_Answers int NOT NULL,
        Prize int NOT NULL,
        Date datetime
    );
END
GO
