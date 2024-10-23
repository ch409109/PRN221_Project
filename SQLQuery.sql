USE [master];
GO

-- Xóa database nếu đã tồn tại
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'PRN221_FinalProject')
BEGIN
    DROP DATABASE PRN221_FinalProject;
END;
GO

-- Tạo lại database
CREATE DATABASE PRN221_FinalProject;
GO

-- Sử dụng database vừa tạo
USE PRN221_FinalProject;
GO

CREATE TABLE MovieCategory (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100)
);
CREATE TABLE Role (
    ID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL
);
CREATE TABLE Movies (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255),
    Description NVARCHAR(MAX),
    CategoryID INT,
    ReleaseDate DATE,
    TrailerURL NVARCHAR(255),
    Actor NVARCHAR(255),
    Director NVARCHAR(255),
    Poster VARCHAR(MAX),
    Status NVARCHAR(50),
    FOREIGN KEY (CategoryID) REFERENCES MovieCategory(ID)
);
CREATE TABLE [User] (
    ID INT PRIMARY KEY IDENTITY(1,1),
    RoleID INT,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(15),
    Dob DATE,
    FullName NVARCHAR(100),
    Status NVARCHAR(50),
    FOREIGN KEY (RoleID) REFERENCES Role(ID)
);
CREATE TABLE Feedback (
    ID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    MovieID INT,
    Comments NVARCHAR(1000),
    CreateAt DATETIME,
    FOREIGN KEY (UserID) REFERENCES [User](ID),
    FOREIGN KEY (MovieID) REFERENCES Movies(ID)
);
CREATE TABLE News (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255),
    Content NVARCHAR(MAX),
    Image NVARCHAR(255),
    CreateAt DATETIME,
    UpdateAt DATETIME,
    CreateBy INT,
    FOREIGN KEY (CreateBy) REFERENCES [User](ID)
);
CREATE TABLE Discount (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Code NVARCHAR(50),
    DiscountValue DECIMAL(5,2),
    StartDate DATE,
    EndDate DATE
);
CREATE TABLE Cinema (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Location NVARCHAR(255),
    City NVARCHAR(100),
    Name NVARCHAR(100),
	Status VARCHAR(15)
);
CREATE TABLE Room (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    CinemaID INT,
    [NumberOfRows] INT,
    FOREIGN KEY (CinemaID) REFERENCES Cinema(ID)
);
CREATE TABLE [Rows] (
    ID INT PRIMARY KEY IDENTITY(1,1),
	RowName Varchar(50),
    [RoomID] INT,
    NumberOfColumns INT,
	[Type] NVARCHAR(255),
    FOREIGN KEY (RoomID) REFERENCES Room(ID)
);

CREATE TABLE Seat (
    ID INT PRIMARY KEY IDentity(1,1),
	SeatName Varchar(15),
    [RowID] INT,
    Status NVARCHAR(255),
    FOREIGN KEY (RowID) REFERENCES [Rows](ID)
);
CREATE TABLE Booking (
    ID INT PRIMARY KEY IDENTITY(1,1),
    BookingDate DATETIME,
    CinemaID INT,
    MovieID INT,
    UserID INT,
    Status NVARCHAR(50),
    TotalPrice DECIMAL(10,2),
    FOREIGN KEY (CinemaID) REFERENCES Cinema(ID),
    FOREIGN KEY (MovieID) REFERENCES Movies(ID),
    FOREIGN KEY (UserID) REFERENCES [User](ID)
);
CREATE TABLE Payment (
    ID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT,
    Amount DECIMAL(10,2),
    DiscountID INT,
    FOREIGN KEY (BookingID) REFERENCES Booking(ID),
    FOREIGN KEY (DiscountID) REFERENCES Discount(ID)
);
CREATE TABLE Revenue (
    ID INT PRIMARY KEY IDENTITY(1,1),
    PaymentID INT,
    TotalRevenue DECIMAL(15,2),
    FromDate DATE,
    ToDate DATE,
    FOREIGN KEY (PaymentID) REFERENCES Payment(ID)
);
CREATE TABLE BookingSeatsDetail (
    ID INT PRIMARY KEY IDENTITY(1,1),
    SeatID INT,
    Price DECIMAL(10,2),
    BookingID INT,
    FOREIGN KEY (SeatID) REFERENCES Seat(ID),
    FOREIGN KEY (BookingID) REFERENCES Booking(ID)
);
CREATE TABLE FoodAndDrinks (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Price DECIMAL(10,2),
    Quantity INT,
	[Image] VARCHAR(MAX),
	Status VARCHAR(15)
);
CREATE TABLE BookingItem (
    ID INT PRIMARY KEY IDENTITY(1,1),
    FoodAndDrinksID INT,
    Quantity INT,
    Price DECIMAL(10,2),
    BookingID INT,
    FOREIGN KEY (FoodAndDrinksID) REFERENCES FoodAndDrinks(ID),
    FOREIGN KEY (BookingID) REFERENCES Booking(ID)
);
CREATE TABLE Showtime (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MovieID INT,
    CinemaID INT,
    RoomID INT,
    Showtime DATETIME,
    [Date] DATETIME,
    FOREIGN KEY (MovieID) REFERENCES Movies(ID),
    FOREIGN KEY (CinemaID) REFERENCES Cinema(ID),
    FOREIGN KEY (RoomID) REFERENCES Room(ID)
);

INSERT INTO MovieCategory (Name) VALUES
('Action'),
('Comedy'),
('Drama'),
('Horror'),
('Sci-Fi');
INSERT INTO Role (RoleName) VALUES
('Admin'),
('User'),
('Staff');
INSERT INTO Movies (Title, Description, CategoryID, ReleaseDate, TrailerURL, ShowTime, Actor, Director, Poster, Status) VALUES
('Inception', 'A mind-bending thriller by Christopher Nolan', 5, '2010-07-16', 'https://example.com/trailer/inception', '2010-07-16 19:00:00', 'Leonardo DiCaprio', 'Christopher Nolan', 'https://example.com/poster/inception.jpg', 'Available'),
('The Dark Knight', 'A superhero film directed by Christopher Nolan', 1, '2008-07-18', 'https://example.com/trailer/darkknight', '2008-07-18 21:00:00', 'Christian Bale', 'Christopher Nolan', 'https://example.com/poster/darkknight.jpg', 'Available'),
('Titanic', 'A romance film based on the tragic sinking of the Titanic', 3, '1997-12-19', 'https://example.com/trailer/titanic', '1997-12-19 18:00:00', 'Leonardo DiCaprio', 'James Cameron', 'https://example.com/poster/titanic.jpg', 'Available');
INSERT INTO [User] (RoleID, Username, Password, Email, PhoneNumber, Dob, FullName, Status) VALUES
(1, 'admin', 'password123', 'admin@example.com', '0123456789', '1980-01-01', 'Admin User', 'Active'),
(2, 'john_doe', 'password123', 'john.doe@example.com', '0123456788', '1990-06-15', 'John Doe', 'Active'),
(3, 'staff_01', 'password123', 'staff01@example.com', '0123456787', '1985-03-10', 'Staff One', 'Active');
INSERT INTO Feedback (UserID, MovieID, Comments, CreateAt) VALUES
(2, 1, 'Amazing movie with stunning visuals!', '2024-10-11 10:00:00'),
(2, 3, 'Great love story, very touching.', '2024-10-11 11:00:00');
INSERT INTO News (Title, Content, Image, CreateAt, UpdateAt, CreateBy) VALUES
('New Release: Inception', 'Inception is now available in cinemas!', 'https://example.com/news/inception.jpg', '2024-10-10 12:00:00', '2024-10-11 09:00:00', 1);
INSERT INTO Discount (Code, DiscountValue, StartDate, EndDate) VALUES
('DISCOUNT10', 10.00, '2024-10-01', '2024-10-31'),
('HALFOFF', 50.00, '2024-11-01', '2024-11-30');
INSERT INTO Cinema (Location, City, Name) VALUES
('123 Main Street', 'New York', 'Cinema One'),
('456 Elm Street', 'Los Angeles', 'Cinema Two');
INSERT INTO Room (Name, CinemaID, Rows, Columns) VALUES
('Room 1', 1, 10, 20),
('Room 2', 2, 12, 24);

INSERT INTO Booking (BookingDate, CinemaID, MovieID, UserID, Status, TotalPrice) VALUES
('2024-10-10 19:00:00', 1, 1, 2, 'Confirmed', 20.00),
('2024-10-11 20:00:00', 2, 3, 2, 'Confirmed', 50.00);
INSERT INTO Payment (BookingID, Amount, DiscountID) VALUES
(1, 20.00, 1),
(2, 25.00, 2);
INSERT INTO Revenue (PaymentID, TotalRevenue, FromDate, ToDate) VALUES
(1, 2000.00, '2024-10-01', '2024-10-10'),
(2, 2500.00, '2024-10-11', '2024-10-20');
INSERT INTO BookingSeatsDetail (SeatID, Price, BookingID) VALUES
(1, 10.00, 1),
(2, 10.00, 1),
(3, 25.00, 2),
(4, 25.00, 2);
INSERT INTO FoodAndDrinks (Name, Price, Quantity) VALUES
('Popcorn', 5.00, 100),
('Soda', 3.00, 200);
INSERT INTO BookingItem (FoodAndDrinksID, Quantity, Price, BookingID) VALUES
(1, 1, 5.00, 1),
(2, 2, 6.00, 2);
INSERT INTO Showtime (MovieID, CinemaID, RoomID, Showtime, [Date]) VALUES
(1, 1, 1, '2024-10-10 19:00:00', '2024-10-10'),
(3, 2, 2, '2024-10-11 20:00:00', '2024-10-11');