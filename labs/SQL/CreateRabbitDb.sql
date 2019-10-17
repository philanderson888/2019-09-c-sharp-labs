use master
go

drop database if exists RabbitDb
go

create database RabbitDb
go

use RabbitDb
go

drop table if exists Rabbits


CREATE TABLE Rabbits(
	RabbitId INT NOT NULL IDENTITY PRIMARY KEY,
	Age INT NULL,
	Name VARCHAR(50) NULL
);

INSERT INTO Rabbits Values ('1','Rabbit01')
INSERT INTO Rabbits Values ('0','Rabbit02')
INSERT INTO Rabbits Values ('0','Rabbit03')

SET IDENTITY_INSERT Rabbits ON
INSERT INTO Rabbits (RabbitId, Age, Name) values (4,0,'Rabbit04')
SET IDENTITY_INSERT Rabbits OFF

select 'Rabbit Database'

UPDATE Rabbits Set Name='Changed' WHERE RabbitId=3

delete from rabbits where RabbitId=4

select * from Rabbits

