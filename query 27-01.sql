use master
go
create database [OnlineStoreDB]
go


USE [OnlineStoreDB]
go

CREATE TABLE [dbo].[PayMethod](
	[MethodId] [int] IDENTITY(1,1) NOT NULL,
	[MethodType] [varchar] (30),
	[Nombre] [varchar](20) NULL,
	CONSTRAINT "PK_PayMethod" PRIMARY KEY  CLUSTERED 
	(
		[MethodId]
	)
)
go

CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
	[State] [bit] NULL
	CONSTRAINT "PK_Category" PRIMARY KEY  CLUSTERED 
	(
		[CategoryID]
	)
)
go

CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[ProductNumber] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[State] [bit] NULL,
	[IsHomeSlider] [bit] not null default 0,
	CONSTRAINT "PK_Product" PRIMARY KEY  CLUSTERED 
	(
		[ProductID]
	),
	CONSTRAINT "FK_Product_Category" FOREIGN KEY 
	(
		[CategoryID]
	) REFERENCES [dbo].[Category] (
		[CategoryID]
	),
)
go


CREATE TABLE [dbo].[ProductDetail](
	[ProductDetailID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[Color] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Price] [decimal](18, 2) NULL,
	[PriceMin] [decimal](18, 2) NULL,
	[PriceMax] [decimal](18, 2) NULL,
	[StockMin]  [int] NULL,
	[StockNow] [int] NULL,
	[Image] [varchar](max) NULL
	CONSTRAINT "PK_ProductDetail" PRIMARY KEY  CLUSTERED 
	(
		[ProductDetailID]
	),
	CONSTRAINT "FK_ProductDetail_Product" FOREIGN KEY 
	(
		[ProductID]
	) REFERENCES [dbo].[Product] (
		[ProductID]
	),
)
go


CREATE TABLE [dbo].[UserWeb](
	[UserID] [int] IDENTITY(1, 1) NOT NULL,
	[Name] [varchar](25) NOT NULL,
	[Password] varbinary(250),
	[Email] [varchar](100) NULL,
	[LastName] [varchar](250) NULL,
	[State] [bit] NOT NULL default 0,
	[ImageRoute] [varchar](max) NULL,
	CONSTRAINT "PK_UserWeb" PRIMARY KEY  CLUSTERED 
	(
		[UserID]
	)
)
go


CREATE TABLE [dbo].[Order] (
	[OrderID] [int] IDENTITY (1, 1) NOT NULL ,
	[UserID] [int] NOT NULL ,
	[OrderNumber] [varchar](15) NULL,
	[CreatedDate] [datetime] NOT NULL ,
	[ConfirmDate] [datetime] Null,
	[ShippedDate] [datetime] Null,
	[Status] [varchar](10) NULL,
	CONSTRAINT "PK_Order" PRIMARY KEY  CLUSTERED 
	(
		[OrderID]
	),
	CONSTRAINT "FK_Order_UserWeb" FOREIGN KEY 
	(
		[UserID]
	) REFERENCES [dbo].[UserWeb] (
		[UserID]
	)
)
go


CREATE TABLE [dbo].[OrderDetail] (
	[OrderDetailID] [int] IDENTITY (1, 1) NOT NULL ,
	[OrderID] [int] NOT NULL ,
	[Products] [varchar](max) NOT NULL ,
	[TotalPay] [money] NOT NULL,
	CONSTRAINT "PK_OrderDetail" PRIMARY KEY  CLUSTERED 
	(
		[OrderDetailID]
	),
	CONSTRAINT "FK_OrderDetail_Order" FOREIGN KEY 
	(
		[OrderID]
	) REFERENCES [dbo].[Order] (
		[OrderID]
	)
)
go



set quoted_identifier on
go
set identity_insert dbo.Category off
go
ALTER TABLE dbo.Category NOCHECK CONSTRAINT ALL
go
insert into dbo.Category(CategoryName, [State])
values('Category1', 1)
insert into dbo.Category
values('Category2', 1)
insert into dbo.Category
values('Category3', 1)
insert into dbo.Category
values('Category4', 1)
go




set quoted_identifier on
go
set identity_insert dbo.Product off
go
ALTER TABLE dbo.Product NOCHECK CONSTRAINT ALL
go
insert into dbo.Product(CategoryID,ProductNumber, [Name], CreatedDate,[State], [IsHomeSlider])
values(1, '1111','Product1', getDate(),1,0)
insert into dbo.Product(CategoryID,ProductNumber, [Name], CreatedDate,[State], [IsHomeSlider])
values(1, '1111','Product1', getDate(),1,0)
insert into dbo.Product(CategoryID,ProductNumber, [Name], CreatedDate,[State], [IsHomeSlider])
values(1, '1111','Product1', getDate(),1,0)
insert into dbo.Product(CategoryID,ProductNumber, [Name], CreatedDate,[State], [IsHomeSlider])
values(2, '1111','Product1', getDate(),1,0)
insert into dbo.Product(CategoryID,ProductNumber, [Name], CreatedDate,[State], [IsHomeSlider])
values(2, '1111','Product1', getDate(),1,0)
insert into dbo.Product(CategoryID,ProductNumber, [Name], CreatedDate,[State], [IsHomeSlider])
values(2, '1111','Product1', getDate(),1,0)
insert into dbo.Product(CategoryID,ProductNumber, [Name], CreatedDate,[State], [IsHomeSlider])
values(3, '1111','Product1', getDate(),1,1)
insert into dbo.Product(CategoryID,ProductNumber, [Name], CreatedDate,[State], [IsHomeSlider])
values(3, '1111','Product1', getDate(),1,1)
insert into dbo.Product(CategoryID,ProductNumber, [Name], CreatedDate,[State], [IsHomeSlider])
values(3, '1111','Product1', getDate(),1,1)
insert into dbo.Product(CategoryID,ProductNumber, [Name], CreatedDate,[State], [IsHomeSlider])
values(1, '1111','Product1', getDate(),1,1)
insert into dbo.Product(CategoryID,ProductNumber, [Name], CreatedDate,[State], [IsHomeSlider])
values(4, '1111','Product1', getDate(),1,0)
go



insert into dbo.ProductDetail(ProductID, Color, Price, StockNow, [Image], Description	)
values(1, 'Verde', 200, 0, 'http://placehold.it/700x400', 'Práctico para el verano, de fácil uso')
insert into dbo.ProductDetail(ProductID, Color, Price, StockNow, [Image], Description)
values(2, 'Verde', 200, 0, 'http://placehold.it/700x400', 'Práctico para el verano, de fácil uso')
insert into dbo.ProductDetail(ProductID, Color, Price, StockNow, [Image], Description)
values(3, 'Verde', 200, 0, 'http://placehold.it/700x400', 'Práctico para el verano, de fácil uso')
insert into dbo.ProductDetail(ProductID, Color, Price, StockNow, [Image], Description)
values(4, 'Verde', 200, 0, 'http://placehold.it/700x400', 'Práctico para el verano, de fácil uso')
insert into dbo.ProductDetail(ProductID, Color, Price, StockNow, [Image], Description)
values(5, 'Verde', 200, 0, 'http://placehold.it/700x400', 'Práctico para el verano, de fácil uso')
insert into dbo.ProductDetail(ProductID, Color, Price, StockNow, [Image], Description)
values(6, 'Verde', 200, 0, 'http://placehold.it/700x400', 'Práctico para el verano, de fácil uso')
insert into dbo.ProductDetail(ProductID, Color, Price, StockNow, [Image], Description)
values(7, 'Verde', 200, 0, 'http://placehold.it/900x350', 'Práctico para el verano, de fácil uso')
insert into dbo.ProductDetail(ProductID, Color, Price, StockNow, [Image], Description)
values(8, 'Verde', 200, 0, 'http://placehold.it/900x350', 'Práctico para el verano, de fácil uso')
insert into dbo.ProductDetail(ProductID, Color, Price, StockNow, [Image], Description)
values(9, 'Verde', 200, 0, 'http://placehold.it/900x350', 'Práctico para el verano, de fácil uso')
insert into dbo.ProductDetail(ProductID, Color, Price, StockNow, [Image], Description)
values(10, 'Verde', 200, 0, 'http://placehold.it/900x350', 'Práctico para el verano, de fácil uso')
insert into dbo.ProductDetail(ProductID, Color, Price, StockNow, [Image], Description)
values(11, 'Verde', 200, 0, 'http://placehold.it/900x350', 'Práctico para el verano, de fácil uso')


update ProductDetail
set [Image] = '/Content/Images/splash_screen.png'


insert into [dbo].[UserWeb] ([Name], [Password], [Email], [LastName], [State], [ImageRoute])
VALUES ('Bryan', HASHBYTES('SHA2_512','Contra123'), 'bvislao@gmail.com', 'Vislao Chavez', 1, '../../WebImage/universitariodedeportes.jpg')
insert into [dbo].[UserWeb] ([Name], [Password], [Email], [LastName], [State], [ImageRoute])
VALUES ('fernando', HASHBYTES('SHA2_512','12345678'), 'fhuamani@gmail.com', 'huamani', 1, '../../WebImage/universitariodedeportes.jpg')

insert into [dbo].[Order]( UserID, OrderNumber, [CreatedDate], [ConfirmDate], [ShippedDate], [Status])
VALUES( 1, '27112019001', getDate(), null, null, 'Nuevo')
insert into [dbo].[Order]( UserID, OrderNumber, [CreatedDate], [ConfirmDate], [ShippedDate], [Status])
VALUES( 2, '27112019002', getDate(), null, null, 'Nuevo')

insert into dbo.OrderDetail([OrderID],[Products],[TotalPay])
values(1, 'productos', 200)
insert into dbo.OrderDetail([OrderID],[Products],[TotalPay])
values(2, 'productos2', 200)



USE [OnlineStoreDB]
GO

select *
from [UserWeb]


select *
from OrderDetail

select *
from [Order]

select *
from product

select *
from ProductDetail


update ProductDetail
set [Image] = '/Content/Images/splash_screen.png'


select cast(case when [Password] = HASHBYTES('SHA2_512','Contra123') then 1 else 0 end as bit) flag
from [UserWeb]
where [Email] = 'bvislao@gmail.com' 


select [Name], [Email], [LastName], [State]
from UserWeb
where [Password] = HASHBYTES('SHA2_512','Contra123')



create procedure dbo.uspValidateUserWeb
@email varchar(100),
@password varchar(100)
AS
BEGIN
	select [Name], [Email], [LastName], [State]
	from UserWeb
	where [Password] = HASHBYTES('SHA2_512', @password)
	and [Email] = @email
END

exec dbo.uspValidateUserWeb 'bvislao@gmail.com', 'Contra123'



create procedure dbo.uspCreateUserWeb
@email varchar(100),
@password varchar(100),
@name varchar(250),
@lastName varchar(250)
AS
BEGIN TRY
	BEGIN TRAN
		insert into [UserWeb]([Email],[Name],[LastName],[Password],[State])
		values (@email, @name, @lastName,HASHBYTES('SHA2_512',@password),1)

	COMMIT TRAN

	select Email, [Name], LastName, [State]
	from [UserWeb]
	where Email = @email
	and [Password] = HASHBYTES('SHA2_512',@password)
END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH
