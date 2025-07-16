use CodeChallenge
drop Books
CREATE TABLE Books(
ID int primary key,
Title Varchar(100),
Author Varchar(100),
ISBN float(20) unique,
Published_date DateTime)

insert into Books Values(1,'My First SQL book','Mary Parker',981483029127,'2021-02-22 12:08:17'),
(2,'My Second SQL book','John Mayer',877300923713,'1972-07-03 09:22:45'),
(3,'My Third SQL book','Cary Flint',523120967812,'2015-10-18 14:05:44')

select * from Books



--Query -1
	--Write a query to fetch the details of the books written by author whose name ends with er.
	select * from books where Author like '%er'


create table reviews(id int primary key,
book_id int ,
reviewer_name varchar(100),
content varchar(100),
rating int,
Published_date DateTime
FOREIGN KEY (book_id) REFERENCES books(ID)
)

insert into reviews values(1,1,'John Smith','My first review',4,'2017-12-10 05:50:11.1'),
(2,2,'John Smith','My second review',5,'2017-10-13 15:05:12.6'),
(3,2,'Alice Walker','Another review',1,'2017-10-22 2:47:10')



select * from reviews
--Query-2:
	--Display the Title ,Author and ReviewerName for all the books from the above table

select b.Title,b.Author,r.reviewer_name from Books b join reviews r on b.ID=r.book_id


--Query-3:
	--Display the reviewer name who reviewed more than one book
select reviewer_name from reviews
group by reviewer_name
having COUNT(book_id)>1


create table Customers(ID int Primary key,
NAME varchar(100),
AGE varchar(100),
ADDRESS varchar(100),
SALARY Float(20))

insert into Customers values(1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',4500.00),
(7,'Muffy',24,'Indore',10000.00)



--Query-4:
	--Display the Name for the customer from above customer table who live in same address which has character 'o' anywhere in address

select NAME from Customers where ADDRESS like '%o%'

create table ORDERS(OID int primary key,
DATE DATETIME,
CUSTOMER_ID int,
AMOUNT int,
FOREIGN KEY (CUSTOMER_ID) REFERENCES Customers(ID)
)

INSERT INTO ORDERS VALUES(102,'2009-10-08 00:00:00',3,3000),
(100,'2009-10-08 00:00:00',3,1500),
(101,'2009-11-20 00:00:00',2,1560),
(103,'2008-05-20 00:00:00',4,2060)



--Query 5
	--Write a query to display the Date,Total no of customer placed order on same Date
select o.DATE,COUNT(Distinct o.CUSTOMER_ID) as 'TOTAL CUSTOMERS'
from ORDERS o join Customers c on o.CUSTOMER_ID=c.ID
group by o.DATE


create table Employee(ID INT PRIMARY KEY,
NAME VARCHAR(50),
AGE INT,
ADDRESS VARCHAR(20),
SALARY FLOAT(20))

INSERT INTO Employee VALUES
(1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',null),
(7,'Muffy',24,'Indore',null)

select * from Employee





--Query-6
	--Display the Names of the Employee in lower case, whose salary is null
select LOWER(NAME) as Employee_Name from Employee where SALARY is null


create table StudentDetails(RegisterNo int primary key,
Name varchar(20),
Age int,
Qualification varchar(20),
MobileNo float(10),
Mail_id varchar(25),
Location varchar(10),
Gender varchar(1))

insert into StudentDetails values (2,'Sai',22,'B.E',9952836777,'Sai@gmail.com','Chennai','M'),
(3,'Kumar',20,'BSC',7890125648,'Kumar@gmail.com','Madurai','M'),
(4,'Selvi',22,'B.Tech',8904567342,'selvi@gmail.com','Selam','F'),
(5,'Nisha',25,'M.E',7834672310,'Nisha@gmail.com','Theni','F'),
(6,'SaiSaran',21,'B.A',7890345678,'saran@gmail.com','Madurai','F'),
(7,'Tom',23,'BCA',8901234675,'Tom@gmail.com','Pune','M')



--Query-7
	--Write a sql server query to display the Gender,Total no of male and female from the above relation
select Gender,COUNT(*) as [Total Count] from StudentDetails
group by Gender
