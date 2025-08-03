--Create Tables
--drop table users
CREATE TABLE Users (
    userid INT PRIMARY KEY IDENTITY,
    username VARCHAR(50),
    [password] VARCHAR(50),
    roles VARCHAR(10)
);

INSERT INTO Users VALUES 
('Dinesh','Dinesh@123','admin'),
('Arthi','arthi@123','user'),
('kala','kala@123','user')

select * from Users

CREATE TABLE Trains (
    tno INT PRIMARY KEY,
    tname VARCHAR(50),
    [from] VARCHAR(50),
    dest VARCHAR(50),
    price DECIMAL(10, 2),
    class_of_travel VARCHAR(50),
    train_status VARCHAR(10),
    seats_available INT
);

INSERT INTO Trains VALUES 
(12739, 'Secunderabad Garib Rath Express', 'Visakhapatnam', 'Secunderabad',785, '3AC', 'active', 120),
(18463, 'Prashanti Express', 'Bhubaneswar', 'KSR Bengaluru', 2100, '2AC', 'active', 24),
(12727, 'Godavari Express', 'visakhapatnam', 'Nampally', 2555, '1AC', 'inactive', 54),
(12841, 'Coromandal Express', 'visakhapatnam', 'MGR Chennai Ctl', 1085, '3E', 'active', 20);

select * from Trains

CREATE TABLE Bookings (
    booking_id INT PRIMARY KEY IDENTITY,
    tno INT,
    userid INT,
    seats_booked INT,
    booking_date DATETIME,
    deleted BIT DEFAULT 0,
    FOREIGN KEY (tno) REFERENCES Trains(tno)
);
select * from Bookings
CREATE TABLE Cancellations (
    cancellation_id INT PRIMARY KEY IDENTITY,
    booking_id INT,
    seats_cancelled INT,
    cancellation_date DATETIME,
    deleted BIT DEFAULT 0,
    FOREIGN KEY (booking_id) REFERENCES Bookings(booking_id)
);

select * from Cancellations
CREATE TABLE DeletedTrains (
    tno INT,
    tname VARCHAR(50),
    [from] VARCHAR(50),
    dest VARCHAR(50),
    price DECIMAL(10, 2),
    class_of_travel VARCHAR(50),
    train_status VARCHAR(10),
    seats_available INT,
    deleted_on DATETIME
);

select * from DeletedTrains