USE [Members]
GO
ALTER TABLE [dbo].[Segments] DROP CONSTRAINT [FK_Segments_Group]
GO
/****** Object:  Table [dbo].[Segments]    Script Date: 12/11/2017 16:47:58 ******/
DROP TABLE [dbo].[Segments]
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 12/11/2017 16:47:58 ******/
DROP TABLE [dbo].[Profiles]
GO
/****** Object:  Table [dbo].[MemberLastImportLog]    Script Date: 12/11/2017 16:47:58 ******/
DROP TABLE [dbo].[MemberLastImportLog]
GO
/****** Object:  Table [dbo].[MemberImportLog]    Script Date: 12/11/2017 16:47:58 ******/
DROP TABLE [dbo].[MemberImportLog]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 12/11/2017 16:47:58 ******/
DROP TABLE [dbo].[Groups]
GO
/****** Object:  User [LC\JPK]    Script Date: 12/11/2017 16:47:58 ******/
DROP USER [LC\JPK]
GO
/****** Object:  User [sc]    Script Date: 12/11/2017 16:47:58 ******/
DROP USER [sc]
GO
USE [master]
GO
/****** Object:  Database [Members]    Script Date: 12/11/2017 16:47:58 ******/
DROP DATABASE [Members]
GO
/****** Object:  Database [Members]    Script Date: 12/11/2017 16:47:58 ******/
CREATE DATABASE [Members]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Members', FILENAME = N'd:\SqlData\Members.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Members_log', FILENAME = N'd:\SqlData\Members_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Members] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Members].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Members] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Members] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Members] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Members] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Members] SET ARITHABORT OFF 
GO
ALTER DATABASE [Members] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Members] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Members] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Members] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Members] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Members] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Members] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Members] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Members] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Members] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Members] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Members] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Members] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Members] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Members] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Members] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Members] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Members] SET RECOVERY FULL 
GO
ALTER DATABASE [Members] SET  MULTI_USER 
GO
ALTER DATABASE [Members] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Members] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Members] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Members] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Members] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Members] SET QUERY_STORE = OFF
GO
USE [Members]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Members]
GO
/****** Object:  User [sc]    Script Date: 12/11/2017 16:47:58 ******/
CREATE USER [sc] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [LC\JPK]    Script Date: 12/11/2017 16:47:58 ******/
CREATE USER [LC\JPK] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [sc]
GO
ALTER ROLE [db_owner] ADD MEMBER [LC\JPK]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 12/11/2017 16:47:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[ID] [int] NOT NULL,
	[ProfileID] [nvarchar](50) NULL,
	[SegmentID] [int] NULL,
	[OptIn] [bit] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberImportLog]    Script Date: 12/11/2017 16:47:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberImportLog](
	[id] [int] NOT NULL,
	[Date] [date] NULL,
	[UpdatedMembers] [int] NULL,
	[Message] [nvarchar](2000) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberLastImportLog]    Script Date: 12/11/2017 16:47:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberLastImportLog](
	[id] [int] NOT NULL,
	[Date] [date] NULL,
	[Message] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 12/11/2017 16:47:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](320) NULL,
	[MailUpID] [nvarchar](50) NULL,
	[OptIn] [bit] NULL,
	[Deleted] [bit] NULL,
	[Created] [date] NULL,
	[Updated] [date] NULL,
	[ExternalId] [nvarchar](50) NULL,
	[Firstname] [nvarchar](50) NULL,
	[Lastname] [nvarchar](50) NULL,
	[Address] [nvarchar](150) NULL,
	[Address2] [nvarchar](150) NULL,
	[Postcode] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[CVRnummer] [nvarchar](50) NULL,
	[BrugerID] [nvarchar](50) NULL,
	[Medlemsstatus] [nvarchar](50) NULL,
	[Foreningsnummer] [nvarchar](50) NULL,
	[Foedselsaar] [nvarchar](50) NULL,
	[HektarDrevet] [nvarchar](50) NULL,
	[AntalAndetKvaeg] [nvarchar](50) NULL,
	[AntalAmmekoeer] [nvarchar](50) NULL,
	[AntaMalkekoeer] [nvarchar](50) NULL,
	[AntalSlagtesvin] [nvarchar](50) NULL,
	[AntalSoeer] [nvarchar](50) NULL,
	[AntalAarssoeer] [nvarchar](50) NULL,
	[AntalPelsdyr] [nvarchar](50) NULL,
	[AntalHoens] [nvarchar](50) NULL,
	[AntalKyllinger] [nvarchar](50) NULL,
	[Ecology] [nvarchar](50) NULL,
	[Sektion_SSJ] [nvarchar](50) NULL,
	[Driftform_planteavl] [nvarchar](50) NULL,
	[Driftform_Koed_Koer] [nvarchar](50) NULL,
	[Driftform_Mælk] [nvarchar](50) NULL,
	[Driftform_Svin] [nvarchar](50) NULL,
	[Driftform_Pelsdyr] [nvarchar](50) NULL,
	[Driftform_Aeg_Kylling] [nvarchar](50) NULL,
	[Driftstoerrelse_Planteavl] [nvarchar](50) NULL,
	[Driftstoerrelse_Koed_Koer] [nvarchar](50) NULL,
	[Driftfstoerrelse_Mælk] [nvarchar](50) NULL,
	[Driftstoerrelse_Svin] [nvarchar](50) NULL,
	[Driftstoerrelse_Pelsdyr] [nvarchar](50) NULL,
	[Driftstoerrelse_Aeg_Kylling] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Segments]    Script Date: 12/11/2017 16:47:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Segments](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Query] [nvarchar](1500) NULL,
	[MailUpGroupID] [nvarchar](50) NULL,
 CONSTRAINT [PK_Segments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Segments]  WITH CHECK ADD  CONSTRAINT [FK_Segments_Group] FOREIGN KEY([ID])
REFERENCES [dbo].[Groups] ([ID])
GO
ALTER TABLE [dbo].[Segments] CHECK CONSTRAINT [FK_Segments_Group]
GO
USE [master]
GO
ALTER DATABASE [Members] SET  READ_WRITE 
GO
