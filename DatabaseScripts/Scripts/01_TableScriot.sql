CREATE TABLE [dbo].[Customer](
	[Id] [int] Primary Key IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](255) NOT NULL,
)
GO;

CREATE TABLE [dbo].[Order](
	[Id] [int] Primary key IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] references Customer(Id),
	[Amount] [numeric](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
);
GO

