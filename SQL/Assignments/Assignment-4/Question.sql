use Assignments

--1. Write a T-SQL Program to find the factorial of a given number.

declare @num int =6 
declare @fact float=1,@i int=1
while @i<=@num
begin
	set @fact=@fact * @i
	set @i+=1
end
print ' The Factorial of a Number '+'{'+cast(@num as varchar)+'}'+
		' is '+cast(@fact as varchar)

--2.Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 

create or alter procedure sp_MultiplicationTable
@no int,@limit int
as
begin
	declare @i int =1,@res int
	while @i<=@limit
	begin
		set @res=@no * @i
		print cast(@no as varchar)+'*'+cast(@i as varchar)+'='+
			  cast(@res as varchar)
			set @i+=1
	end
end

execute sp_MultiplicationTable @no=6,@limit=10


--3.3. Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly

create table student(Sid int primary key,Sname varchar(30))

insert into student values
(1,'Jack'),
(2,'Rithvik'),
(3,'Jaspreeth'),
(4,'Praveen'),
(5,'Bisa'),
(6,'Suraj')

select * from student

create table Marks(
Mid int primary key,
Sid int foreign key references student(Sid),
Score int)

insert into Marks values
(1,1,23),
(2,6,95),
(3,4,98),
(4,2,17),
(5,3,53),
(6,5,13)

select * from Marks

create or alter function fn_Status(@score int)
returns varchar(10)
as
begin 
	return 
		case
			when @score>=50 then 'Pass'
			else 'Fail'
		end
end

select s.Sid as [Student ID],s.Sname as [Student Name],m.Score as [Student Marks],dbo.fn_Status(m.Score) as [STATUS]
from student s join Marks m on s.Sid=m.Sid