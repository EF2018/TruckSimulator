
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/07/2018 23:18:27
-- Generated from EDMX file: C:\Users\Admin\source\repos\MyPortfolio\TruckSimulator\TruckSimulatorDAL_n\Model3.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TruckSimulator_MyModelN3];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MapMapPoint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PointSet_MapPoint] DROP CONSTRAINT [FK_MapMapPoint];
GO
IF OBJECT_ID(N'[dbo].[FK_VehicleRoutePoint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PointSet_RoutePoint] DROP CONSTRAINT [FK_VehicleRoutePoint];
GO
IF OBJECT_ID(N'[dbo].[FK_MapPoint_inherits_Point]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PointSet_MapPoint] DROP CONSTRAINT [FK_MapPoint_inherits_Point];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehicle_inherits_MapPoint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PointSet_Vehicle] DROP CONSTRAINT [FK_Vehicle_inherits_MapPoint];
GO
IF OBJECT_ID(N'[dbo].[FK_RoutePoint_inherits_Point]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PointSet_RoutePoint] DROP CONSTRAINT [FK_RoutePoint_inherits_Point];
GO
IF OBJECT_ID(N'[dbo].[FK_Cargo_inherits_MapPoint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PointSet_Cargo] DROP CONSTRAINT [FK_Cargo_inherits_MapPoint];
GO
IF OBJECT_ID(N'[dbo].[FK_User_inherits_Vehicle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PointSet_User] DROP CONSTRAINT [FK_User_inherits_Vehicle];
GO
IF OBJECT_ID(N'[dbo].[FK_Truck_inherits_Vehicle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PointSet_Truck] DROP CONSTRAINT [FK_Truck_inherits_Vehicle];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PointSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PointSet];
GO
IF OBJECT_ID(N'[dbo].[MapSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MapSet];
GO
IF OBJECT_ID(N'[dbo].[PointSet_MapPoint]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PointSet_MapPoint];
GO
IF OBJECT_ID(N'[dbo].[PointSet_Vehicle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PointSet_Vehicle];
GO
IF OBJECT_ID(N'[dbo].[PointSet_RoutePoint]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PointSet_RoutePoint];
GO
IF OBJECT_ID(N'[dbo].[PointSet_Cargo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PointSet_Cargo];
GO
IF OBJECT_ID(N'[dbo].[PointSet_User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PointSet_User];
GO
IF OBJECT_ID(N'[dbo].[PointSet_Truck]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PointSet_Truck];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PointSet'
CREATE TABLE [dbo].[PointSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Position_X] int  NOT NULL,
    [Position_Y] int  NOT NULL
);
GO

-- Creating table 'MapSet'
CREATE TABLE [dbo].[MapSet] (
    [IdMap] int IDENTITY(1,1) NOT NULL,
    [MapName] nvarchar(max)  NOT NULL,
    [NumCargoes] int  NOT NULL,
    [NumTrucks] int  NOT NULL,
    [NumIterations] int  NOT NULL,
    [CurIteration] int  NOT NULL
);
GO

-- Creating table 'PointSet_MapPoint'
CREATE TABLE [dbo].[PointSet_MapPoint] (
    [Name] nvarchar(max)  NOT NULL,
    [MapIdMap] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'PointSet_Vehicle'
CREATE TABLE [dbo].[PointSet_Vehicle] (
    [StepOfRoute] int  NOT NULL,
    [Fuelbalance] int  NOT NULL,
    [Status] bit  NOT NULL,
    [FuelCharge] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'PointSet_RoutePoint'
CREATE TABLE [dbo].[PointSet_RoutePoint] (
    [VehicleId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'PointSet_Cargo'
CREATE TABLE [dbo].[PointSet_Cargo] (
    [StatusCargo] bit  NOT NULL,
    [Value] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'PointSet_User'
CREATE TABLE [dbo].[PointSet_User] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'PointSet_Truck'
CREATE TABLE [dbo].[PointSet_Truck] (
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PointSet'
ALTER TABLE [dbo].[PointSet]
ADD CONSTRAINT [PK_PointSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdMap] in table 'MapSet'
ALTER TABLE [dbo].[MapSet]
ADD CONSTRAINT [PK_MapSet]
    PRIMARY KEY CLUSTERED ([IdMap] ASC);
GO

-- Creating primary key on [Id] in table 'PointSet_MapPoint'
ALTER TABLE [dbo].[PointSet_MapPoint]
ADD CONSTRAINT [PK_PointSet_MapPoint]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PointSet_Vehicle'
ALTER TABLE [dbo].[PointSet_Vehicle]
ADD CONSTRAINT [PK_PointSet_Vehicle]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PointSet_RoutePoint'
ALTER TABLE [dbo].[PointSet_RoutePoint]
ADD CONSTRAINT [PK_PointSet_RoutePoint]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PointSet_Cargo'
ALTER TABLE [dbo].[PointSet_Cargo]
ADD CONSTRAINT [PK_PointSet_Cargo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PointSet_User'
ALTER TABLE [dbo].[PointSet_User]
ADD CONSTRAINT [PK_PointSet_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PointSet_Truck'
ALTER TABLE [dbo].[PointSet_Truck]
ADD CONSTRAINT [PK_PointSet_Truck]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MapIdMap] in table 'PointSet_MapPoint'
ALTER TABLE [dbo].[PointSet_MapPoint]
ADD CONSTRAINT [FK_MapMapPoint]
    FOREIGN KEY ([MapIdMap])
    REFERENCES [dbo].[MapSet]
        ([IdMap])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MapMapPoint'
CREATE INDEX [IX_FK_MapMapPoint]
ON [dbo].[PointSet_MapPoint]
    ([MapIdMap]);
GO

-- Creating foreign key on [VehicleId] in table 'PointSet_RoutePoint'
ALTER TABLE [dbo].[PointSet_RoutePoint]
ADD CONSTRAINT [FK_VehicleRoutePoint]
    FOREIGN KEY ([VehicleId])
    REFERENCES [dbo].[PointSet_Vehicle]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleRoutePoint'
CREATE INDEX [IX_FK_VehicleRoutePoint]
ON [dbo].[PointSet_RoutePoint]
    ([VehicleId]);
GO

-- Creating foreign key on [Id] in table 'PointSet_MapPoint'
ALTER TABLE [dbo].[PointSet_MapPoint]
ADD CONSTRAINT [FK_MapPoint_inherits_Point]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PointSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PointSet_Vehicle'
ALTER TABLE [dbo].[PointSet_Vehicle]
ADD CONSTRAINT [FK_Vehicle_inherits_MapPoint]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PointSet_MapPoint]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PointSet_RoutePoint'
ALTER TABLE [dbo].[PointSet_RoutePoint]
ADD CONSTRAINT [FK_RoutePoint_inherits_Point]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PointSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PointSet_Cargo'
ALTER TABLE [dbo].[PointSet_Cargo]
ADD CONSTRAINT [FK_Cargo_inherits_MapPoint]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PointSet_MapPoint]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PointSet_User'
ALTER TABLE [dbo].[PointSet_User]
ADD CONSTRAINT [FK_User_inherits_Vehicle]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PointSet_Vehicle]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PointSet_Truck'
ALTER TABLE [dbo].[PointSet_Truck]
ADD CONSTRAINT [FK_Truck_inherits_Vehicle]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PointSet_Vehicle]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------