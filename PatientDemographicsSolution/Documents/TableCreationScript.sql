/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.1742)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2016
    Target Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [PatientDemographics]
GO

/****** Object:  Table [dbo].[PersonData]    Script Date: 12/13/2018 20:08:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PersonData](
	[PID] [int] IDENTITY(1,1) NOT NULL,
	[PersonXML] [varchar](1000) NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[UpdatedDate] [date] NULL
) ON [PRIMARY]
GO


