DROP TABLE IF EXISTS Employee_Details;

CREATE TABLE Employee_Details (
    Empno INT PRIMARY KEY IDENTITY(1,1),
    EmpName VARCHAR(50) NOT NULL,
    Empsal float,
    EmpGender varchar(5) CHECK(EmpGender IN ('Male', 'Female')),
    NetSalary AS (Empsal * 0.90) 
)

CREATE OR ALTER PROCEDURE AddEmployee 
    @EmpName VARCHAR(50),  
    @Empsal float, 
    @EmpGender varchar(6)
AS
BEGIN
    INSERT INTO Employee_Details (EmpName, Empsal, EmpGender)
    VALUES (@EmpName, @Empsal, @EmpGender);
END

--check the procedure
exec AddEmployee @EmpName = 'Dinesh', @Empsal = 40000, @EmpGender = 'Male';


CREATE OR ALTER PROCEDURE UpdateSalary 
    @Empid INT,
    @UpdatedSalary FLOAT OUTPUT
AS
BEGIN
    UPDATE Employee_Details
    SET Empsal= Empsal+ 100
    WHERE Empno= @Empid;

    SELECT @UpdatedSalary = Empsal FROM Employee_Details WHERE Empno = @Empid;
END;

DECLARE @UpdatedSalary FLOAT;

EXEC UpdateSalary @Empid = 1, @UpdatedSalary = @UpdatedSalary OUTPUT;




select * from Employee_Details

