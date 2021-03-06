USE [master]
GO
/****** Object:  Database [FoodOrderingDB]    Script Date: 10.03.2020 0:03:01 ******/
CREATE DATABASE [FoodOrderingDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FoodOrderingDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FoodOrderingDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FoodOrderingDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FoodOrderingDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FoodOrderingDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FoodOrderingDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FoodOrderingDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FoodOrderingDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FoodOrderingDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FoodOrderingDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FoodOrderingDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FoodOrderingDB] SET  MULTI_USER 
GO
ALTER DATABASE [FoodOrderingDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FoodOrderingDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FoodOrderingDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FoodOrderingDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FoodOrderingDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FoodOrderingDB] SET QUERY_STORE = OFF
GO
USE [FoodOrderingDB]
GO
/****** Object:  Table [dbo].[Basket]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Basket](
	[User_Id] [int] NOT NULL,
	[Product_Id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Id] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Product]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Product](
	[Order_Id] [int] NOT NULL,
	[Product_Id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Status]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Order_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[Сomposition] [nvarchar](100) NOT NULL,
	[ImageURL] [nvarchar](150) NOT NULL,
	[Category] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Order]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Order](
	[User_Id] [int] NOT NULL,
	[Order_Id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Role]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Role](
	[User_Id] [int] NOT NULL,
	[Role_Id] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_User]    Script Date: 10.03.2020 0:03:01 ******/
CREATE NONCLUSTERED INDEX [IX_User] ON [dbo].[User]
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Product] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Product]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_User] FOREIGN KEY([User_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_User]
GO
ALTER TABLE [dbo].[Order_Status]  WITH CHECK ADD  CONSTRAINT [FK_Order_Status_Order] FOREIGN KEY([Id])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[Order_Status] CHECK CONSTRAINT [FK_Order_Status_Order]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[User_Order]  WITH CHECK ADD  CONSTRAINT [FK_User_Order_Order] FOREIGN KEY([Order_Id])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[User_Order] CHECK CONSTRAINT [FK_User_Order_Order]
GO
ALTER TABLE [dbo].[User_Order]  WITH CHECK ADD  CONSTRAINT [FK_User_Order_User] FOREIGN KEY([User_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User_Order] CHECK CONSTRAINT [FK_User_Order_User]
GO
ALTER TABLE [dbo].[User_Role]  WITH CHECK ADD  CONSTRAINT [FK_User_Role_Role] FOREIGN KEY([Role_Id])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User_Role] CHECK CONSTRAINT [FK_User_Role_Role]
GO
ALTER TABLE [dbo].[User_Role]  WITH CHECK ADD  CONSTRAINT [FK_User_Role_User] FOREIGN KEY([User_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User_Role] CHECK CONSTRAINT [FK_User_Role_User]
GO
/****** Object:  StoredProcedure [dbo].[AddNewOrder]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[AddNewOrder]
@UserId int,
@OrderId int output
as
  insert into [dbo].[Order] (User_Id, Status)
  values(@UserId, 1)
  set @OrderId = SCOPE_IDENTITY();
  insert into[dbo].[Order_Product] (Order_Id, Product_Id)
  select @OrderId, Product_Id from [dbo].[Basket]
    where User_Id = @UserId
  DELETE FROM [dbo].[Basket] 
    where User_Id = @UserId
GO
/****** Object:  StoredProcedure [dbo].[AddNewProduct]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[AddNewProduct]
@ProductName nvarchar(50),
@ProductСomposition nvarchar(150),
@ProductImage nvarchar(150),
@ProductPrice int
AS
  insert into [FoodOrderingDB].[dbo].[Product](Name, Сomposition, ImageURL, Price, Category)
  values(@ProductName, @ProductСomposition, @ProductImage, @ProductPrice, 4)
GO
/****** Object:  StoredProcedure [dbo].[AddNewUser]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddNewUser]
@Id int output
as
  insert into [dbo].[User] DEFAULT VALUES;
  set @Id = SCOPE_IDENTITY();
  insert into [dbo].[User_Role](User_Id, Role_Id)
  values(@Id, 1)
GO
/****** Object:  StoredProcedure [dbo].[AddProductToBasketById]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create procedure [dbo].[AddProductToBasketById]
  @UserId int,
  @ProductId int

as
insert [FoodOrderingDB].[dbo].[Basket] (User_Id, Product_Id)
values(@UserId, @ProductId)
GO
/****** Object:  StoredProcedure [dbo].[ChangeOrderStatusById]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ChangeOrderStatusById]
@OrderId int,
@Status int
as 
update  [dbo].[Order]
set Status = @Status
where Id = @OrderId
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductFromBasketById]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROCEDURE [dbo].[DeleteProductFromBasketById]
@UserId int,
@ProductId int 
as
delete from [dbo].[Basket]
where User_Id  = @UserId and Product_Id = @ProductId
GO
/****** Object:  StoredProcedure [dbo].[GetAllOrders]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllOrders]
as
SELECT [Id]
      ,[User_Id]
      ,[Status]
	  ,[User_Id]
  FROM [FoodOrderingDB].[dbo].[Order]
GO
/****** Object:  StoredProcedure [dbo].[GetAllProduct]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllProduct]
as
SELECT TOP (100) [Id]
      ,[Name]
      ,[Price]
      ,[Сomposition]
      ,[ImageURL]
  FROM [FoodOrderingDB].[dbo].[Product]
GO
/****** Object:  StoredProcedure [dbo].[GetBasketUserById]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create procedure [dbo].[GetBasketUserById]
  @UserId int
as
SELECT [Id]
      ,[Name]
      ,[Price]
      ,[Сomposition]
      ,[ImageURL]
  FROM [FoodOrderingDB].[dbo].[Product] 
, [FoodOrderingDB].[dbo].[Basket] 
  where Id = Product_Id and
 User_Id = @UserId
GO
/****** Object:  StoredProcedure [dbo].[GetByLogin]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetByLogin]
@UserLogin nvarchar(50)
AS
SELECT [Id]
      ,[Name]
      ,[Address]
      ,[Phone]
      ,[Login]
      ,[Password]
  FROM [FoodOrderingDB].[dbo].[User]
  WHERE [User].[Login] = @UserLogin
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryById]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetCategoryById]
@Id int
as
select [Category]
from [dbo].[Category]
where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetOrderByStatus]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetOrderByStatus]
@Status int
as
select  [Order].[Id]
      ,[User_Id]
	  ,[Order_Status].[Status]
 from [dbo].[Order], [dbo].[Order_Status]
 where [Order].[Status] = [Order_Status].[Id]
 and @Status = [Order].[Status]
GO
/****** Object:  StoredProcedure [dbo].[GetProductByCategory]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetProductByCategory]
@Category int
as
SELECT TOP (100) [Id]
      ,[Name]
      ,[Price]
      ,[Сomposition]
      ,[ImageURL]
  FROM [FoodOrderingDB].[dbo].[Product]
  where [Product].[Category] = @Category
GO
/****** Object:  StoredProcedure [dbo].[GetProductById]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create PROCEDURE [dbo].[GetProductById]
@ProductId int
AS
SELECT [Id]
      ,[Name]
      ,[Price]
      ,[Сomposition]
      ,[ImageURL]
      ,[Category]
  FROM [FoodOrderingDB].[dbo].[Product]
  WHERE [Product].[Id] = @ProductId
GO
/****** Object:  StoredProcedure [dbo].[GetProductFromOrderById]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetProductFromOrderById]
@Id int
as
SELECT [Id]
      ,[Name]
      ,[Price]
      ,[Сomposition]
      ,[ImageURL]
  FROM [FoodOrderingDB].[dbo].[Product],[FoodOrderingDB].[dbo].[Order_Product]
  where Product_Id = Id and Order_Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetRolesForUser]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRolesForUser]
@UserId int
AS
SELECT [Role].[Status]
  FROM [dbo].[User] 
    join  [User_Role]
    on [User_Role].[User_Id] = [User].[Id]
    join [Role]
    on [Role].[Id] = [User_Role].[Role_Id]
  WHERE [User].[Id] = @UserId
GO
/****** Object:  StoredProcedure [dbo].[GetStatusById]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetStatusById]
@Id int
as
select [Order_Status].[Status]
from [dbo].[Order_Status]
where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create PROCEDURE [dbo].[GetUserById]
@UserId int
AS
SELECT[Name]
      ,[Address]
      ,[Phone]
      ,[Login]
      ,[Password]
  FROM [FoodOrderingDB].[dbo].[User]
  WHERE [User].[Id] = @UserId
GO
/****** Object:  StoredProcedure [dbo].[Registration]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[Registration]
@UserId int,
@UserLogin nvarchar(50),
@UserPassword nvarchar(50)
AS
  UPDATE [FoodOrderingDB].[dbo].[User] 
  SET Login = @UserLogin,
  Password = @UserPassword
  WHERE Id = @UserId
  UPDATE  [FoodOrderingDB].[dbo].[User_Role]
  set User_Id = @UserId, Role_Id = 2
GO
/****** Object:  StoredProcedure [dbo].[UpdateProductById]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[UpdateProductById]
@ProductId int,
@ProductName nvarchar(50),
@ProductСomposition nvarchar(150),
@ProductImage nvarchar(150),
@ProductPrice int
AS
  update [FoodOrderingDB].[dbo].[Product]
   set [Name] = @ProductName
      ,[Price] = @ProductPrice
      ,[Сomposition] = @ProductСomposition
      ,[ImageURL] = @ProductImage
      ,[Category] = 4

  WHERE [Product].[Id] = @ProductId
GO
/****** Object:  StoredProcedure [dbo].[UserUpdate]    Script Date: 10.03.2020 0:03:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   CREATE PROCEDURE [dbo].[UserUpdate]
@UserId int,
@UserName nvarchar(50),
@UserLogin nvarchar(50),
@UserPassword nvarchar(50),
@UserPhone nvarchar(50),
@UserAddress nvarchar(250)
AS
  UPDATE [FoodOrderingDB].[dbo].[User] 
  SET Name = @UserName,
  Login = @UserLogin,
  Password = @UserPassword,
  Phone = @UserPhone,
  Address = @UserAddress
  WHERE Id = @UserID
GO
USE [master]
GO
ALTER DATABASE [FoodOrderingDB] SET  READ_WRITE 
GO
