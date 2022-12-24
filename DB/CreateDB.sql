USE [master]
GO
/****** Object:  Database [Akvelon_TestTask]    Script Date: 24.12.2022 21:00:00 ******/
CREATE DATABASE [Akvelon_TestTask]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Akvelon_TestTask', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Akvelon_TestTask.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Akvelon_TestTask_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Akvelon_TestTask_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Akvelon_TestTask] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Akvelon_TestTask].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Akvelon_TestTask] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET ARITHABORT OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Akvelon_TestTask] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Akvelon_TestTask] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Akvelon_TestTask] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Akvelon_TestTask] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Akvelon_TestTask] SET  MULTI_USER 
GO
ALTER DATABASE [Akvelon_TestTask] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Akvelon_TestTask] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Akvelon_TestTask] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Akvelon_TestTask] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Akvelon_TestTask] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Akvelon_TestTask] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Akvelon_TestTask] SET QUERY_STORE = OFF
GO
USE [Akvelon_TestTask]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 24.12.2022 21:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](64) NOT NULL,
	[ProjectStartDate] [date] NULL,
	[ProjectCompletionDate] [date] NULL,
	[ProjectStatusId] [tinyint] NOT NULL,
	[ProjectPriority] [int] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectStatuses]    Script Date: 24.12.2022 21:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectStatuses](
	[ProjectStatusId] [tinyint] NOT NULL,
	[ProjectStatusName] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_ProjectStatuses] PRIMARY KEY CLUSTERED 
(
	[ProjectStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 24.12.2022 21:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [nvarchar](64) NOT NULL,
	[TaskStatusId] [tinyint] NOT NULL,
	[TaskDescription] [nvarchar](max) NULL,
	[TaskPriority] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskStatuses]    Script Date: 24.12.2022 21:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskStatuses](
	[TaskStatusId] [tinyint] NOT NULL,
	[TaskStatusName] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_TaskStatuses] PRIMARY KEY CLUSTERED 
(
	[TaskStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_ProjectStatuses] FOREIGN KEY([ProjectStatusId])
REFERENCES [dbo].[ProjectStatuses] ([ProjectStatusId])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_ProjectStatuses]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Projects]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_TaskStatuses] FOREIGN KEY([TaskStatusId])
REFERENCES [dbo].[TaskStatuses] ([TaskStatusId])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_TaskStatuses]
GO
USE [master]
GO
ALTER DATABASE [Akvelon_TestTask] SET  READ_WRITE 
GO