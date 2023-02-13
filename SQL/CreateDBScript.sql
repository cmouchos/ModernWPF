create database MVVMLoginDb
go
use MVVMLoginDb
go
create table [User]
(
	Id UNIQUEIDENTIFIER primary Key default NEWID(),
	Username nvarchar(50) unique not null,
	[Password] nvarchar(100) not null,
	[Name] nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(100) unique not null
)
go
insert into [User] values (NEWID(), 'admin', 'admin', 'Bruce', 'Wayne', 'brucewayne@batman.com')
insert into [User] values (NEWID(), 'robin', 'nightwing', 'Dick', 'Grayson', 'dickgreyson@batman.com')
insert into [User] values (NEWID(), 'butler', 'forever', 'Alfred', 'Pennyworth', 'alfredpennyworth@batman.com')
go

select * from [User]