
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/22/2017 16:25:59
-- Generated from EDMX file: E:\C_too_big\VS_15\projects\pmf_2\pmf_2\Models\co_log.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [jrj_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_co_log_project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[co_log] DROP CONSTRAINT [FK_co_log_project];
GO
IF OBJECT_ID(N'[dbo].[FK_project_ToASPNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[project] DROP CONSTRAINT [FK_project_ToASPNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_user_proj_ToTable_AspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[user_project] DROP CONSTRAINT [FK_user_proj_ToTable_AspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_user_proj_ToTable_project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[user_project] DROP CONSTRAINT [FK_user_proj_ToTable_project];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[co_log]', 'U') IS NOT NULL
    DROP TABLE [dbo].[co_log];
GO
IF OBJECT_ID(N'[dbo].[project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[project];
GO
IF OBJECT_ID(N'[dbo].[user_project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user_project];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'co_log'
CREATE TABLE [dbo].[co_log] (
    [co_Id] int IDENTITY(1,1) NOT NULL,
    [project_Id] int  NOT NULL,
    [co_num] nchar(10)  NULL,
    [proc] int  NULL,
    [n_proc] int  NULL,
    [gc_co] nvarchar(50)  NULL,
    [description] nvarchar(250)  NULL,
    [owed] int  NULL,
    [notes] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'user_project'
CREATE TABLE [dbo].[user_project] (
    [user_proj_Id] int  NOT NULL,
    [user_Id] nvarchar(128)  NOT NULL,
    [project_Id] int  NOT NULL
);
GO

-- Creating table 'projects'
CREATE TABLE [dbo].[projects] (
    [project_Id] int IDENTITY(1,1) NOT NULL,
    [project_number] int  NULL,
    [project_name] nchar(50)  NULL,
    [pm_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [co_Id] in table 'co_log'
ALTER TABLE [dbo].[co_log]
ADD CONSTRAINT [PK_co_log]
    PRIMARY KEY CLUSTERED ([co_Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [user_proj_Id] in table 'user_project'
ALTER TABLE [dbo].[user_project]
ADD CONSTRAINT [PK_user_project]
    PRIMARY KEY CLUSTERED ([user_proj_Id] ASC);
GO

-- Creating primary key on [project_Id] in table 'projects'
ALTER TABLE [dbo].[projects]
ADD CONSTRAINT [PK_projects]
    PRIMARY KEY CLUSTERED ([project_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [user_Id] in table 'user_project'
ALTER TABLE [dbo].[user_project]
ADD CONSTRAINT [FK_user_proj_ToTable_AspNetUser]
    FOREIGN KEY ([user_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_user_proj_ToTable_AspNetUser'
CREATE INDEX [IX_FK_user_proj_ToTable_AspNetUser]
ON [dbo].[user_project]
    ([user_Id]);
GO

-- Creating foreign key on [pm_Id] in table 'projects'
ALTER TABLE [dbo].[projects]
ADD CONSTRAINT [FK_project_ToASPNetUser]
    FOREIGN KEY ([pm_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_project_ToASPNetUser'
CREATE INDEX [IX_FK_project_ToASPNetUser]
ON [dbo].[projects]
    ([pm_Id]);
GO

-- Creating foreign key on [project_Id] in table 'co_log'
ALTER TABLE [dbo].[co_log]
ADD CONSTRAINT [FK_co_log_project]
    FOREIGN KEY ([project_Id])
    REFERENCES [dbo].[projects]
        ([project_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_co_log_project'
CREATE INDEX [IX_FK_co_log_project]
ON [dbo].[co_log]
    ([project_Id]);
GO

-- Creating foreign key on [project_Id] in table 'user_project'
ALTER TABLE [dbo].[user_project]
ADD CONSTRAINT [FK_user_proj_ToTable_project]
    FOREIGN KEY ([project_Id])
    REFERENCES [dbo].[projects]
        ([project_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_user_proj_ToTable_project'
CREATE INDEX [IX_FK_user_proj_ToTable_project]
ON [dbo].[user_project]
    ([project_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------