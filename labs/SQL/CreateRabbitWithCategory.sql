use master
go

drop database if exists RabbitDb
go

create database RabbitDb
go

use RabbitDb
go

create table Categories(
	CategoryId INT IDENTITY PRIMARY KEY NOT NULL,
	CategoryName VARCHAR(50) NULL
)

create table Rabbits(
	RabbitId INT IDENTITY PRIMARY KEY NOT NULL,
	RabbitName varchar(50) NULL,
	Age INT NULL,
	/* CREATE RELATIONSHIP */
	CategoryId INT NULL FOREIGN KEY REFERENCES Categories(CategoryId)
);

insert into Categories values ('White');
insert into Categories values ('Black');
insert into Categories values ('Pink');

insert into Rabbits  values ('Bunny',10,1);
insert into Rabbits  values ('Hoppy',12,2);
/* no relationship at present */
update Rabbits set CategoryId=5 where RabbitId = 1;

select * from Rabbits
select * from Categories
