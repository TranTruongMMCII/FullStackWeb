
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/06/2021 19:33:35
-- Generated from EDMX file: D:\Intern\Course\FullStackWeb\EF\Lecture 1\DemoDBFirst\DemoDBFirstModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DemoDBFirst];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Person]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NULL,
    [Gender] nvarchar(100)  NULL,
    [Address] nvarchar(100)  NULL,
    [Type] int  NULL
);
GO

-- Creating table 'People_Student'
CREATE TABLE [dbo].[People_Student] (
    [ID] int  NOT NULL
);
GO

-- Creating table 'People_Trainer'
CREATE TABLE [dbo].[People_Trainer] (
    [ID] int  NOT NULL
);
GO

-- Creating table 'People_Officer'
CREATE TABLE [dbo].[People_Officer] (
    [ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'People_Student'
ALTER TABLE [dbo].[People_Student]
ADD CONSTRAINT [PK_People_Student]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'People_Trainer'
ALTER TABLE [dbo].[People_Trainer]
ADD CONSTRAINT [PK_People_Trainer]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'People_Officer'
ALTER TABLE [dbo].[People_Officer]
ADD CONSTRAINT [PK_People_Officer]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ID] in table 'People_Student'
ALTER TABLE [dbo].[People_Student]
ADD CONSTRAINT [FK_Student_inherits_Person]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[People]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'People_Trainer'
ALTER TABLE [dbo].[People_Trainer]
ADD CONSTRAINT [FK_Trainer_inherits_Person]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[People]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID] in table 'People_Officer'
ALTER TABLE [dbo].[People_Officer]
ADD CONSTRAINT [FK_Officer_inherits_Person]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[People]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------