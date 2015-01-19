
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/19/2015 14:14:16
-- Generated from EDMX file: C:\Users\atunbridge\Documents\GitHub\CPETime\CPETime\CPETime.Data.EntityFramework\Model\CPETimeModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CPETime];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmployeeClockEntry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClockEntries] DROP CONSTRAINT [FK_EmployeeClockEntry];
GO
IF OBJECT_ID(N'[dbo].[FK_ClockEntryBreakAdjustment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BreakAdjustments] DROP CONSTRAINT [FK_ClockEntryBreakAdjustment];
GO
IF OBJECT_ID(N'[dbo].[FK_BreakAdjustmentEmployeeBreak]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BreakAdjustments] DROP CONSTRAINT [FK_BreakAdjustmentEmployeeBreak];
GO
IF OBJECT_ID(N'[dbo].[FK_BreakEmployeeBreak]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeBreaks] DROP CONSTRAINT [FK_BreakEmployeeBreak];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeEmployeeBreak]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeBreaks] DROP CONSTRAINT [FK_EmployeeEmployeeBreak];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[ClockEntries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClockEntries];
GO
IF OBJECT_ID(N'[dbo].[Breaks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Breaks];
GO
IF OBJECT_ID(N'[dbo].[EmployeeBreaks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeBreaks];
GO
IF OBJECT_ID(N'[dbo].[BreakAdjustments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BreakAdjustments];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [MiddleName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [IsNightShift] bit  NOT NULL,
    [BasicShiftHours] float  NOT NULL,
    [HoursPerWeek] int  NOT NULL
);
GO

-- Creating table 'ClockEntries'
CREATE TABLE [dbo].[ClockEntries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActualStart] datetime  NOT NULL,
    [ModifiedStart] datetime  NULL,
    [ActualEnd] datetime  NULL,
    [ModifiedEnd] datetime  NULL,
    [EmployeeId] int  NOT NULL
);
GO

-- Creating table 'Breaks'
CREATE TABLE [dbo].[Breaks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [StartTime] time  NOT NULL,
    [EndTime] time  NOT NULL,
    [IsPaid] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EmployeeBreaks'
CREATE TABLE [dbo].[EmployeeBreaks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BreakId] int  NOT NULL,
    [EmployeeId] int  NOT NULL
);
GO

-- Creating table 'BreakAdjustments'
CREATE TABLE [dbo].[BreakAdjustments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActualStartTime] time  NOT NULL,
    [ActualEndTime] time  NOT NULL,
    [BreakWasSkipped] bit  NOT NULL,
    [ClockEntryId] int  NOT NULL,
    [EmployeeBreakId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClockEntries'
ALTER TABLE [dbo].[ClockEntries]
ADD CONSTRAINT [PK_ClockEntries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Breaks'
ALTER TABLE [dbo].[Breaks]
ADD CONSTRAINT [PK_Breaks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeBreaks'
ALTER TABLE [dbo].[EmployeeBreaks]
ADD CONSTRAINT [PK_EmployeeBreaks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BreakAdjustments'
ALTER TABLE [dbo].[BreakAdjustments]
ADD CONSTRAINT [PK_BreakAdjustments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeId] in table 'ClockEntries'
ALTER TABLE [dbo].[ClockEntries]
ADD CONSTRAINT [FK_EmployeeClockEntry]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeClockEntry'
CREATE INDEX [IX_FK_EmployeeClockEntry]
ON [dbo].[ClockEntries]
    ([EmployeeId]);
GO

-- Creating foreign key on [ClockEntryId] in table 'BreakAdjustments'
ALTER TABLE [dbo].[BreakAdjustments]
ADD CONSTRAINT [FK_ClockEntryBreakAdjustment]
    FOREIGN KEY ([ClockEntryId])
    REFERENCES [dbo].[ClockEntries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClockEntryBreakAdjustment'
CREATE INDEX [IX_FK_ClockEntryBreakAdjustment]
ON [dbo].[BreakAdjustments]
    ([ClockEntryId]);
GO

-- Creating foreign key on [EmployeeBreakId] in table 'BreakAdjustments'
ALTER TABLE [dbo].[BreakAdjustments]
ADD CONSTRAINT [FK_BreakAdjustmentEmployeeBreak]
    FOREIGN KEY ([EmployeeBreakId])
    REFERENCES [dbo].[EmployeeBreaks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BreakAdjustmentEmployeeBreak'
CREATE INDEX [IX_FK_BreakAdjustmentEmployeeBreak]
ON [dbo].[BreakAdjustments]
    ([EmployeeBreakId]);
GO

-- Creating foreign key on [BreakId] in table 'EmployeeBreaks'
ALTER TABLE [dbo].[EmployeeBreaks]
ADD CONSTRAINT [FK_BreakEmployeeBreak]
    FOREIGN KEY ([BreakId])
    REFERENCES [dbo].[Breaks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BreakEmployeeBreak'
CREATE INDEX [IX_FK_BreakEmployeeBreak]
ON [dbo].[EmployeeBreaks]
    ([BreakId]);
GO

-- Creating foreign key on [EmployeeId] in table 'EmployeeBreaks'
ALTER TABLE [dbo].[EmployeeBreaks]
ADD CONSTRAINT [FK_EmployeeEmployeeBreak]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeEmployeeBreak'
CREATE INDEX [IX_FK_EmployeeEmployeeBreak]
ON [dbo].[EmployeeBreaks]
    ([EmployeeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------