/* put master in scope */
use master
go
drop database if exists OrangeDb
go
create database OrangeDb
go
use OrangeDb
drop table if exists Oranges



/* create sub-relationship table FIRST */
create table Categories(
   CategoryId INT NOT NULL IDENTITY PRIMARY KEY,
   CategoryName NVARCHAR(50) NULL
)

create table Oranges(
  OrangeId int not null IDENTITY PRIMARY KEY,
  OrangeName NVARCHAR(50) NULL,
  DateHarvested Date NULL,
  IsLuxuryGrade Bit NULL,
  CategoryId int null FOREIGN KEY REFERENCES Categories(CategoryId)
)

create table Batch(
	BatchId int NOT NULL IDENTITY PRIMARY KEY,
	OrangeID int NULL FOREIGN KEY REFERENCES Oranges(OrangeID),
	Quantity int NULL,
	DespatchDate Date NULL
)

/* populate minor category table FIRST */
INSERT INTO Categories values ('clementines')
INSERT INTO Categories values ('reds')
INSERT INTO Categories values ('easy peelers')

insert into Oranges values('Clementine','2019-09-07',0,2)
insert into Oranges values('Blood Orange','2019-09-15',1,1)
insert into Oranges values('Tangerine','2019-09-08','false',3)
insert into Oranges values('Clementine','2018-12-25',0,1)
go

insert into Batch values (1,100,'2019-09-30')
insert into Batch values (2,100,'2019-09-30')
insert into Batch values (3,100,getdate())
insert into Batch values (4,50,'2019-08-01')


select * from Oranges
select * from Categories

select orangeid, orangename, categoryname from Oranges 
inner join categories on oranges.categoryid = categories.categoryid

/* Expiry date = harvested date + 90 days */
select orangeid, orangename, categoryname, dateharvested, 
DATEADD(d,90,dateharvested) as 'expirydate' from oranges
inner join categories on oranges.CategoryId=Categories.CategoryId

select *, (DATEDIFF(d, dateharvested, GETDATE()))  as 'SinceHarvested',
CASE
WHEN (DATEDIFF(d, dateharvested, GETDATE())) > 90  THEN 'true'
ELSE 'false' 
END 
AS 'IsExpired'
from batch 
inner join oranges on oranges.OrangeId=batch.OrangeID


UPDATE Categories set CategoryName='red' where CategoryId=2
select * from Categories

insert into Oranges values('Dummy','2019-09-07',0,2)
select * from oranges
delete from oranges where OrangeId=5
select * from oranges