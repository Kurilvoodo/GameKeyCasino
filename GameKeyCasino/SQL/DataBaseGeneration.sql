USE [master]
GO
/****** Object:  Database [GameCasino]    Script Date: 09.03.2020 16:50:58 ******/
CREATE DATABASE [GameCasino]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GameCasino', FILENAME = N'D:\SQLExpress\MSSQL14.SQLEXPRESS\MSSQL\DATA\GameCasino.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GameCasino_log', FILENAME = N'D:\SQLExpress\MSSQL14.SQLEXPRESS\MSSQL\DATA\GameCasino_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GameCasino] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GameCasino].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GameCasino] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GameCasino] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GameCasino] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GameCasino] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GameCasino] SET ARITHABORT OFF 
GO
ALTER DATABASE [GameCasino] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GameCasino] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GameCasino] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GameCasino] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GameCasino] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GameCasino] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GameCasino] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GameCasino] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GameCasino] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GameCasino] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GameCasino] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GameCasino] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GameCasino] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GameCasino] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GameCasino] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GameCasino] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GameCasino] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GameCasino] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GameCasino] SET  MULTI_USER 
GO
ALTER DATABASE [GameCasino] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GameCasino] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GameCasino] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GameCasino] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GameCasino] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GameCasino] SET QUERY_STORE = OFF
GO
USE [GameCasino]
GO
/****** Object:  Table [dbo].[GameCodes]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameCodes](
	[GameId] [int] NOT NULL,
	[GameCode] [nvarchar](15) NOT NULL,
	[able] [int] NOT NULL,
UNIQUE NONCLUSTERED 
(
	[GameCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[typeOfGame] [int] NOT NULL,
	[GameName] [nvarchar](30) NOT NULL,
	[BasePrice] [decimal](18, 0) NOT NULL,
	[OurPrice] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_GAMES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolesInWebsite]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesInWebsite](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](24) NULL,
 CONSTRAINT [PK_RolesInWebsite] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](30) NOT NULL,
	[Password] [varbinary](256) NOT NULL,
	[Bill] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Users__536C85E42C41D204] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Website_Users_Roles]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Website_Users_Roles](
	[IdUser] [int] NOT NULL,
	[IdWebsiteRole] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GameCodes]  WITH CHECK ADD  CONSTRAINT [GameCodes_fk0] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[GameCodes] CHECK CONSTRAINT [GameCodes_fk0]
GO
/****** Object:  StoredProcedure [dbo].[AddMoney]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddMoney]
	@Id INT,
	@Money FLOAT
AS
BEGIN
	UPDATE Users
	SET Bill =Bill+@Money
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
	@Username NVARCHAR(30),
	@Password VARBINARY(256),
	@Bill FLOAT
AS
BEGIN
	INSERT INTO Users (Username, Password, Bill)
	VALUES(@Username, @Password, @Bill)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUserToRoleWebsite]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUserToRoleWebsite]
	@IDUser INT,
	@IDRole INT
AS
BEGIN
	INSERT INTO Website_Users_Roles(IDUser, IDWebsiteRole)
	Values(@IDUser, @IDRole)
END
GO
/****** Object:  StoredProcedure [dbo].[Authentification]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Authentification]
	@Username NVARCHAR(30),
	@Password NVARCHAR(30)
AS
BEGIN
	SELECT COUNT(*) FROM Users WHERE Username=@Username AND Password=@Password
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteGameCodeByIdGame]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteGameCodeByIdGame]
	@Id INT
AS
BEGIN
	DELETE TOP(1) FROM GameCodes WHERE GameId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllGames]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllGames]
AS
BEGIN
	SELECT*FROM Games
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllRolesWebsite]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllRolesWebsite]
AS
BEGIN
	SELECT* FROM RolesInWebsite
END
GO
/****** Object:  StoredProcedure [dbo].[GetGameById]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetGameById]
	@Id INT
AS
BEGIN
	SELECT*FROM Games WHERE Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetGameByType]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetGameByType]
	@typeOfGame INT
AS
BEGIN
	SELECT * FROM Games WHERE typeOfGame = @typeOfGame
END
GO
/****** Object:  StoredProcedure [dbo].[GetGameCodeByIdGame]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetGameCodeByIdGame]
	@Id INT
AS
BEGIN
	SELECT TOP(1) * FROM GameCodes WHERE GameId = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetIdRoleByRoleName]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetIdRoleByRoleName]
	@RoleName NVARCHAR(24)
AS
BEGIN
	SELECT IdRole FROM RolesInWebsite WHERE Name=@RoleName
END
GO
/****** Object:  StoredProcedure [dbo].[GetRolesForUserWebsite]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRolesForUserWebsite]
	@IdUser INT
AS
BEGIN
	SELECT RolesInWebsite.Name 
	FROM Website_Users_Roles
	INNER JOIN RolesInWebsite
	ON RolesInWebsite.IdRole = Website_Users_Roles.IdWebsiteRole
	WHERE Website_Users_Roles.IdUser = @IdUser
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserByUsername]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByUsername]
	@Username NVARCHAR(30)
AS
BEGIN
	SELECT*FROM Users WHERE Username = @Username
END
GO
/****** Object:  StoredProcedure [dbo].[IsUserInRoleWebsite]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IsUserInRoleWebsite]
	@IDUser INT,
	@IDRole INT
AS
BEGIN
	SELECT * 
	FROM Website_Users_Roles 
	WHERE IdUser = @IDUser AND IdWebsiteRole = @IDRole
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveMoney]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveMoney]
	@Id INT,
	@Money FLOAT
AS
BEGIN
	UPDATE Users
	SET Bill  = Bill-@Money
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveUserFromRoleWebsite]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveUserFromRoleWebsite]
	@IDUser INT,
	@IDRole INT
AS
BEGIN
	DELETE FROM Website_Users_Roles WHERE IdUser = @IDUser AND IdWebsiteRole = @IDRole
END
GO
/****** Object:  StoredProcedure [dbo].[RoleWebsiteExists]    Script Date: 09.03.2020 16:50:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleWebsiteExists]
	@Name NVARCHAR(24)
AS
BEGIN
	SELECT COUNT(*) FROM RolesInWebsite WHERE Name = @Name
END
GO
USE [master]
GO
ALTER DATABASE [GameCasino] SET  READ_WRITE 
GO
