use diplom

CREATE TABLE [dbo].[admins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[DealShare] [varchar](50) NULL,
	[login] [varchar](20) NOT NULL,
	[password] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[login] [varchar](20) NOT NULL,
	[password] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[catalog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [varchar](50) NOT NULL,
	[Weights] [float] NOT NULL,
	[Description] [varchar](max) NULL,
	[Image] [varchar](max) NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into catalog 
values
('strawberry cake', '1250', 0.85, null, 'pexels-photo-1055272.jpeg'),
('wedding cake', '6000', 3.65, null, 'pexels-photo.jpg'),
('cherry cake', '1600', 0.8, null, 'pexels-photo-140831.jpeg'),
('chokolate cake', '500', 0.5, null, 'pexels-photo-264892.jpeg'),
('brownie', '900', 0.7, null, 'pexels-photo-291528.jpeg'),
('lemon cake', '1100', 1.2, null, 'pexels-photo-1070896.jpeg')

insert into admins
values
('a', 'a', 'a', '5252', '5252')

insert into clients
values
('a', 'a', 'a', '89996475728', null, '2222', '2222')

create table [dbo].[order](
id int primary key identity(1,1),
saledate date,
productID int,
phoneNumber varchar(11)
)