
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/05/2014 23:37:02
-- Generated from EDMX file: C:\Users\Anns\Downloads\MvcTesting\MvcTesting\Models\Data.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MVCTesting];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Emp_Dept]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emps] DROP CONSTRAINT [FK_Emp_Dept];
GO
IF OBJECT_ID(N'[dbo].[FK_activity_Emp1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[activities] DROP CONSTRAINT [FK_activity_Emp1];
GO
IF OBJECT_ID(N'[dbo].[FK_activity_Process]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[activities] DROP CONSTRAINT [FK_activity_Process];
GO
IF OBJECT_ID(N'[dbo].[FK_activity_Emp]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[activities] DROP CONSTRAINT [FK_activity_Emp];
GO
IF OBJECT_ID(N'[dbo].[FK_webpages_UsersInRoles_webpages_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[webpages_UsersInRoles] DROP CONSTRAINT [FK_webpages_UsersInRoles_webpages_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_webpages_UsersInRoles_UserProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[webpages_UsersInRoles] DROP CONSTRAINT [FK_webpages_UsersInRoles_UserProfile];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Depts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Depts];
GO
IF OBJECT_ID(N'[dbo].[Emps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emps];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[activities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[activities];
GO
IF OBJECT_ID(N'[dbo].[Processes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Processes];
GO
IF OBJECT_ID(N'[dbo].[forms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[forms];
GO
IF OBJECT_ID(N'[dbo].[UserProfiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProfiles];
GO
IF OBJECT_ID(N'[dbo].[webpages_Membership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_Membership];
GO
IF OBJECT_ID(N'[dbo].[webpages_OAuthMembership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_OAuthMembership];
GO
IF OBJECT_ID(N'[dbo].[webpages_Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_Roles];
GO
IF OBJECT_ID(N'[dbo].[webpages_UsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_UsersInRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Depts'
CREATE TABLE [dbo].[Depts] (
    [Dept_ID] int IDENTITY(1,1) NOT NULL,
    [Dept_Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'Emps'
CREATE TABLE [dbo].[Emps] (
    [E_ID] int IDENTITY(1,1) NOT NULL,
    [E_Name] varchar(50)  NOT NULL,
    [E_Desg] varchar(50)  NOT NULL,
    [Dept_ID] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'activities'
CREATE TABLE [dbo].[activities] (
    [A_ID] int IDENTITY(1,1) NOT NULL,
    [review] bit  NOT NULL,
    [Input] bit  NOT NULL,
    [Decision] bit  NOT NULL,
    [next_state] int  NOT NULL,
    [Process_ID] int  NOT NULL,
    [Check_In] datetime  NULL,
    [Check_Out] datetime  NULL,
    [Due_Date] datetime  NULL,
    [E_ID] int  NOT NULL
);
GO

-- Creating table 'Processes'
CREATE TABLE [dbo].[Processes] (
    [Process_ID] int IDENTITY(1,1) NOT NULL,
    [Process_Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'forms'
CREATE TABLE [dbo].[forms] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(20)  NOT NULL,
    [Description] varchar(50)  NOT NULL
);
GO

-- Creating table 'UserProfiles'
CREATE TABLE [dbo].[UserProfiles] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NULL
);
GO

-- Creating table 'webpages_Membership'
CREATE TABLE [dbo].[webpages_Membership] (
    [UserId] int  NOT NULL,
    [CreateDate] datetime  NULL,
    [ConfirmationToken] nvarchar(128)  NULL,
    [IsConfirmed] bit  NULL,
    [LastPasswordFailureDate] datetime  NULL,
    [PasswordFailuresSinceLastSuccess] int  NOT NULL,
    [Password] nvarchar(128)  NOT NULL,
    [PasswordChangedDate] datetime  NULL,
    [PasswordSalt] nvarchar(128)  NOT NULL,
    [PasswordVerificationToken] nvarchar(128)  NULL,
    [PasswordVerificationTokenExpirationDate] datetime  NULL
);
GO

-- Creating table 'webpages_OAuthMembership'
CREATE TABLE [dbo].[webpages_OAuthMembership] (
    [Provider] nvarchar(30)  NOT NULL,
    [ProviderUserId] nvarchar(100)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'webpages_Roles'
CREATE TABLE [dbo].[webpages_Roles] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'webpages_UsersInRoles'
CREATE TABLE [dbo].[webpages_UsersInRoles] (
    [webpages_Roles_RoleId] int  NOT NULL,
    [UserProfiles_UserId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Dept_ID] in table 'Depts'
ALTER TABLE [dbo].[Depts]
ADD CONSTRAINT [PK_Depts]
    PRIMARY KEY CLUSTERED ([Dept_ID] ASC);
GO

-- Creating primary key on [E_ID] in table 'Emps'
ALTER TABLE [dbo].[Emps]
ADD CONSTRAINT [PK_Emps]
    PRIMARY KEY CLUSTERED ([E_ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [A_ID] in table 'activities'
ALTER TABLE [dbo].[activities]
ADD CONSTRAINT [PK_activities]
    PRIMARY KEY CLUSTERED ([A_ID] ASC);
GO

-- Creating primary key on [Process_ID] in table 'Processes'
ALTER TABLE [dbo].[Processes]
ADD CONSTRAINT [PK_Processes]
    PRIMARY KEY CLUSTERED ([Process_ID] ASC);
GO

-- Creating primary key on [ID] in table 'forms'
ALTER TABLE [dbo].[forms]
ADD CONSTRAINT [PK_forms]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [UserId] in table 'UserProfiles'
ALTER TABLE [dbo].[UserProfiles]
ADD CONSTRAINT [PK_UserProfiles]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserId] in table 'webpages_Membership'
ALTER TABLE [dbo].[webpages_Membership]
ADD CONSTRAINT [PK_webpages_Membership]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Provider], [ProviderUserId] in table 'webpages_OAuthMembership'
ALTER TABLE [dbo].[webpages_OAuthMembership]
ADD CONSTRAINT [PK_webpages_OAuthMembership]
    PRIMARY KEY CLUSTERED ([Provider], [ProviderUserId] ASC);
GO

-- Creating primary key on [RoleId] in table 'webpages_Roles'
ALTER TABLE [dbo].[webpages_Roles]
ADD CONSTRAINT [PK_webpages_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [webpages_Roles_RoleId], [UserProfiles_UserId] in table 'webpages_UsersInRoles'
ALTER TABLE [dbo].[webpages_UsersInRoles]
ADD CONSTRAINT [PK_webpages_UsersInRoles]
    PRIMARY KEY NONCLUSTERED ([webpages_Roles_RoleId], [UserProfiles_UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Dept_ID] in table 'Emps'
ALTER TABLE [dbo].[Emps]
ADD CONSTRAINT [FK_Emp_Dept]
    FOREIGN KEY ([Dept_ID])
    REFERENCES [dbo].[Depts]
        ([Dept_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Emp_Dept'
CREATE INDEX [IX_FK_Emp_Dept]
ON [dbo].[Emps]
    ([Dept_ID]);
GO

-- Creating foreign key on [next_state] in table 'activities'
ALTER TABLE [dbo].[activities]
ADD CONSTRAINT [FK_activity_Emp1]
    FOREIGN KEY ([next_state])
    REFERENCES [dbo].[Emps]
        ([E_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_activity_Emp1'
CREATE INDEX [IX_FK_activity_Emp1]
ON [dbo].[activities]
    ([next_state]);
GO

-- Creating foreign key on [Process_ID] in table 'activities'
ALTER TABLE [dbo].[activities]
ADD CONSTRAINT [FK_activity_Process]
    FOREIGN KEY ([Process_ID])
    REFERENCES [dbo].[Processes]
        ([Process_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_activity_Process'
CREATE INDEX [IX_FK_activity_Process]
ON [dbo].[activities]
    ([Process_ID]);
GO

-- Creating foreign key on [E_ID] in table 'activities'
ALTER TABLE [dbo].[activities]
ADD CONSTRAINT [FK_activity_Emp]
    FOREIGN KEY ([E_ID])
    REFERENCES [dbo].[Emps]
        ([E_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_activity_Emp'
CREATE INDEX [IX_FK_activity_Emp]
ON [dbo].[activities]
    ([E_ID]);
GO

-- Creating foreign key on [webpages_Roles_RoleId] in table 'webpages_UsersInRoles'
ALTER TABLE [dbo].[webpages_UsersInRoles]
ADD CONSTRAINT [FK_webpages_UsersInRoles_webpages_Roles]
    FOREIGN KEY ([webpages_Roles_RoleId])
    REFERENCES [dbo].[webpages_Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserProfiles_UserId] in table 'webpages_UsersInRoles'
ALTER TABLE [dbo].[webpages_UsersInRoles]
ADD CONSTRAINT [FK_webpages_UsersInRoles_UserProfile]
    FOREIGN KEY ([UserProfiles_UserId])
    REFERENCES [dbo].[UserProfiles]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_webpages_UsersInRoles_UserProfile'
CREATE INDEX [IX_FK_webpages_UsersInRoles_UserProfile]
ON [dbo].[webpages_UsersInRoles]
    ([UserProfiles_UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------