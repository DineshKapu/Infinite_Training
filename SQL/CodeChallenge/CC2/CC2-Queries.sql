 use CodeChallenge

 --Query-1
 --Write a query to display your birthday( day of week)
 select datename(weekday, cast('2003-07-18' as date)) as [Birthday_Week]




 --Query-2
 --Write a query to display your age in days
 select DATEDIFF(day, convert(date,'2003-07-18',120),getdate()) as Age_In_Days


 create table tbldept
(
    DEPTNO int primary key,
    DNAME varchar(20),
    LOC varchar(20)
)

insert into tbldept (DEPTNO, DNAME, LOC) values (10, 'ACCOUNTING', 'NEW YORK'),
                                             (20, 'RESEARCH', 'DALLAS'),
                                             (30, 'SALES', 'CHICAGO');
--select * from tbldept
 

create table tblemp
(
    EMPNO int primary key,
    ENAME varchar(20),
    JOB varchar(20),
    MGR_ID int,
    HIREDATE Date,
    SAL int,
    COMM int,
    DEPTNO int references tbldept(DEPTNO)
    
)

insert into tblemp(EMPNO, ENAME, JOB, MGR_ID, HIREDATE, SAL, COMM, DEPTNO) values (7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
                                                                               (7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
                                                                               (7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
                                                                               (7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
                                                                               (7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
                                                                               (7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
                                                                               (7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
                                                                               (7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
                                                                               (7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
                                                                               (7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
                                                                               (7876, 'ADAMS', 'CLERK', 7788, '2024-05-23', 1100, NULL, 20),
                                                                               (7900, 'JAMES', 'CLERK', 7698, '2024-05-03', 950, NULL, 30),
                                                                               (7902, 'FORD', 'ANALYST', 7566, '2024-07-03', 3000, NULL, 20),
                                                                               (7934, 'MILLER', 'CLERK', 7782, '2024-01-23', 1300, NULL, 10);
--select * from tblemp

--Query-3
--3.	Write a query to display all employees information those who joined before 5 years in the current month
 --(Hint : If required update some HireDates in your EMP table of the assignment)
select * from 
tblemp where hiredate < 
DATEADD (year, -5, getdate());


--Query-4:
--4.	Create table Employee with empno, ename, sal, doj columns or 
--use your emp table and perform the following operations in a single transaction

create table tblemployee
(

   empno int primary key,
   ename varchar(20),
   sal float,
   DOJ date
);

--Query-4-a:
  --a. First insert 3 rows 
begin tran

insert into tblemployee values (1,'Dinesh',50000,'2025-06-03'),
                                 (2,'Jaya Vardhan',60000,'2025-06-05'),
                                 (3,'Manohar',70000,'2025-06-07');
--select * from tblemployee
commit;


--Query-4-b:
--b. Update the second row sal with 15% increment 
begin tran
update tblemployee set sal = sal*1.15 where empno = 2;
--select * from tblemployee 
commit


----Query-4-c:
--Delete first row.
--After completing above all actions, 
--recall the deleted row without losing increment of second row.  
begin tran
delete from tblemployee where empno = 1;
select * from tblemployee where empno = 1;
rollback;
select * from tblemployee;


--Query-5
--Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
create function calculate_bonus (@empno int)
returns decimal(10,2)
as
begin
  declare @bonus decimal(10,2);
  declare @deptno int;
  declare @sal decimal(10,2);

  select @deptno = deptno, @sal = sal from tblemp where empno = @empno;
  --5-a) For Deptno 10 employees 15% of sal as bonus.
  if @deptno = 10
      set @bonus = @sal * 0.15;
  --5-b)For Deptno 20 employees  20% of sal as bonus
  else if @deptno = 20
      set @bonus = @sal * 0.20;
  --5-c) For Others employees 5%of sal as bonus
  else
      set @bonus = @sal * 0.05;

  return @bonus;
end;
GO

select empno, ename, sal, dbo.calculate_bonus(empno) 
as bonus from tblemp;


--use InfiniteDB
--select * from emp

--Query-6:
--6. Create a procedure to update the salary of employee by 500 
--whose dept name is Sales and 
--current salary is below 1500 (use emp table)
create or alter procedure UpdateSalesSalary
as
begin
    update tblemp
    set SAL = SAL + 500
    where DEPTNO in (
        select DEPTNO from tbldept where DNAME = 'SALES'
    )
    and SAL < 1500;
end;
GO
exec UpdateSalesSalary;
--select * from tblemp;
--To show the updated salary of employees whose DEPTNO=30 and
--sal<1500
select * from tblemp where DEPTNO=30;