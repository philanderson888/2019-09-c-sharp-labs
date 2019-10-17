select top 5 * from customers order by customerid desc

select * from products

update products set unitsinstock=200 where productid=31
select * from products where unitsinstock < 10 and discontinued=0 
order by unitsinstock desc

select country from customers order by country
select distinct country from customers order by country

select * from products where ProductName like '%ch%'
select * from products where ProductName like 'ch%'
select * from products where ProductName not like 'ch%'

select distinct region from customers
select * from customers where region in ('ak','bc','ca')

select * from products where unitprice between 10 and 15 order by unitprice

/* COUNT CITY, COUNTRY */
select count(distinct city) as 'cities', count(distinct country) as 'countries' from customers
select count(distinct country) from customers

/* AVERAGE PRICE, MIN PRICE, MAX PRICE */
select avg(unitprice) as 'averageprice', 
min(unitprice) as 'minprice',
max(unitprice) as 'maxprice',
count(*) as 'count' from products
select min(unitprice) as 'minprice' from products
select max(unitprice) as 'maxprice' from products
/* SUM OF UNITS ON STOCK */
select sum(UnitsInStock) as 'Stock Total' from products

select * from orders
select * from [Order Details]
-- Get product, price, discount, price including discount from ORDER DETAILS
select ProductName, Quantity, [Order Details].UnitPrice, Discount, 
([order details].UnitPrice*(1-Discount)) as 'Discount Price' from [Order Details]
inner join Products on products.productid = [order details].productid
order by 'Discount Price' desc
-- Get total of (quantity*unitprice) as 'ordervalue'
select sum(unitprice*quantity) from [order details]
-- get total of (1-discount)* 'ordervalue'
select sum(unitprice*quantity*(1-discount)) from [Order Details]
-- difference
select
sum(unitprice*quantity) as 'gross sales',
sum(unitprice*quantity*(1-discount)) as 'discounted sales',
(sum(unitprice*quantity) - sum(unitprice*quantity*(1-discount))) as 'discount given',
(sum (unitprice*quantity*discount)) as 'discount given'
from [order details]


select 'GROUP BY'
select supplierid, sum(unitsonorder) as 'Total Units On Order' from products
group by supplierid
having sum(unitsonorder) = 0
order by 'total units on order' desc

select 'GROUP BY'
select supplierid, sum(unitsonorder) as 'Total Units On Order' from products
group by supplierid
having sum(unitsonorder) > 0
order by 'total units on order' desc


/* subqueries */
select * from customers where customerid not in
(select customerid from orders)




