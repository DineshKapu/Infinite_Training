CREATE DATABASE ElectricityBillDB;

USE ElectricityBillDB;

CREATE TABLE ElectricityBill
(
    consumer_number VARCHAR(20)  NOT NULL,
    consumer_name   VARCHAR(50)  NOT NULL,
    units_consumed  INT          NOT NULL,
    bill_amount     FLOAT        NOT NULL,
	uploaded_datetime DATETIME     NOT NULL

);

SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'ElectricityBill';

select * from ElectricityBill