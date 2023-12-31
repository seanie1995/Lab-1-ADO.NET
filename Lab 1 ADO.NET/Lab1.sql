USE [master]
GO
/****** Object:  Database [Lab1]    Script Date: 10/12/2023 11:37:16 ******/
CREATE DATABASE [Lab1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Lab1', FILENAME = N'C:\Users\HP Victus\Lab1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Lab1_log', FILENAME = N'C:\Users\HP Victus\Lab1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Lab1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Lab1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Lab1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Lab1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Lab1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Lab1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Lab1] SET ARITHABORT OFF 
GO
ALTER DATABASE [Lab1] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Lab1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Lab1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Lab1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Lab1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Lab1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Lab1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Lab1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Lab1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Lab1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Lab1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Lab1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Lab1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Lab1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Lab1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Lab1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Lab1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Lab1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Lab1] SET  MULTI_USER 
GO
ALTER DATABASE [Lab1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Lab1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Lab1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Lab1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Lab1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Lab1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Lab1] SET QUERY_STORE = OFF
GO
USE [Lab1]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 10/12/2023 11:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 10/12/2023 11:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 10/12/2023 11:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[GradeId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[GradeValue] [int] NOT NULL,
	[GradeDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 10/12/2023 11:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[PositionId] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 10/12/2023 11:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[PositionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 10/12/2023 11:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[ClassID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Courses]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Students]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Positions] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([PositionId])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Positions]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Classes] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Classes] ([ClassID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Classes]
GO
/****** Object:  StoredProcedure [dbo].[AddNewStaff]    Script Date: 10/12/2023 11:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddNewStaff]
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Position Int
AS
BEGIN
    INSERT INTO STAFF (FirstName, LastName, PositionId)
    VALUES (@FirstName, @LastName, @Position);
END;
GO
/****** Object:  StoredProcedure [dbo].[AddNewStudent]    Script Date: 10/12/2023 11:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddNewStudent]
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Class Int
AS
BEGIN
    INSERT INTO Students (FirstName, LastName, ClassID)
    VALUES (@FirstName, @LastName, @Class);
END;
GO
/****** Object:  StoredProcedure [dbo].[GetLatestGrades]    Script Date: 10/12/2023 11:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetLatestGrades]
AS
BEGIN
    SELECT
        CONCAT(Students.LastName, ', ', Students.FirstName) AS StudentName,
        Courses.CourseName,
        Grades.GradeValue,
        Grades.GradeDate
    FROM
        Grades
    JOIN
        Students ON Grades.StudentID = Students.StudentID
    JOIN
        Courses ON Grades.CourseID = Courses.CourseID
    WHERE 
        MONTH(Grades.GradeDate) = MONTH((SELECT MAX(GradeDate) FROM Grades))
    ORDER BY
        GradeDate DESC;
END;

GO
/****** Object:  StoredProcedure [dbo].[GetStudentsByClassName]    Script Date: 10/12/2023 11:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStudentsByClassName]
    @ClassName NVARCHAR(50)
AS
BEGIN
    SELECT Students.StudentId, Students.FirstName, Students.LastName, Classes.ClassName
    FROM Students
    JOIN Classes ON Students.ClassID = Classes.ClassID
    WHERE Classes.ClassName = @ClassName;
END;
GO
/****** Object:  StoredProcedure [dbo].[StudentsByFirstNameFalling]    Script Date: 10/12/2023 11:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StudentsByFirstNameFalling]
    
AS
BEGIN   
    SELECT * FROM Students 
    ORDER BY FirstName DESC
END;
GO
/****** Object:  StoredProcedure [dbo].[StudentsByFirstNameRising]    Script Date: 10/12/2023 11:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StudentsByFirstNameRising]
   
AS
BEGIN   
    SELECT * FROM Students 
    ORDER BY FirstName ASC
END;
GO
/****** Object:  StoredProcedure [dbo].[StudentsBySurnameFalling]    Script Date: 10/12/2023 11:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StudentsBySurnameFalling]
    
AS
BEGIN   
    SELECT * FROM Students 
    ORDER BY LastName DESC
END;
GO
/****** Object:  StoredProcedure [dbo].[StudentsBySurnameRising]    Script Date: 10/12/2023 11:37:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StudentsBySurnameRising]
    
AS
BEGIN   
    SELECT * FROM Students 
    ORDER BY LastName ASC
END;
GO
USE [master]
GO
ALTER DATABASE [Lab1] SET  READ_WRITE 
GO
