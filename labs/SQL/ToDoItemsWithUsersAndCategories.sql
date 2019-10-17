use master
Go

drop database if exists ToDoItemsDatabase
go

create database ToDoItemsDatabase
go

use ToDoItemsDatabase 
go 

drop table if exists ToDoItems

create table Users(
	UserId INT NOT NULL IDENTITY PRIMARY KEY,
	UserName NVARCHAR(50) NULL
);

create table Categories(
	CategoryId INT NOT NULL IDENTITY PRIMARY KEY,
	CategoryName NVARCHAR(50) NULL
);

create table ToDoItems(
	ToDoItemId INT NOT NULL IDENTITY PRIMARY KEY,
	Item VARCHAR(50) NULL,
	DateDue DATE NULL,
	Done bit NULL,
	UserId int null foreign key references Users(UserId),
	CategoryId int null foreign key references Categories(CategoryId)
);

INSERT INTO Users VALUES ('bob')
INSERT INTO Users VALUES ('bill')
INSERT INTO Users VALUES ('ben')

INSERT INTO Categories VALUES ('admin')
INSERT INTO Categories VALUES ('database')
INSERT INTO Categories VALUES ('coding')

INSERT INTO ToDoItems VALUES ('first item','2019-12-12',0, 1, 2)
INSERT INTO ToDoItems VALUES ('second item','2019-11-11',1, 2, 3)
INSERT INTO ToDoItems VALUES ('third item','2019-10-10',0, 3, 1)


select * from Users
select * from Categories
select * from ToDoItems