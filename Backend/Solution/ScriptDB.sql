
create table Users
(
   Id int identity(1,1) primary key not null,
   Names varchar(50) null, 
   LastName varchar(50) null,
   Email varchar(50) null
)
create table Shopping
(
   Id int identity(1,1) primary key not null,
   UserId int not null,
   Amount  float  null,
   IdentificatorOfMoney varchar(50) null
)

ALTER TABLE [dbo].[Shopping]  WITH CHECK ADD  CONSTRAINT [FK_Users_Shopping] FOREIGN KEY(UserId)
REFERENCES [dbo].[Users] (Id)
GO

ALTER TABLE [dbo].[Shopping] CHECK CONSTRAINT [FK_Users_Shopping]
GO
