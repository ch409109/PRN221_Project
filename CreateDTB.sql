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
	Rate FLOAT,
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
    DiscountValue INT,
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
    TotalPrice INT,
	TicketCode VARCHAR(50) UNIQUE,
    FOREIGN KEY (CinemaID) REFERENCES Cinema(ID),
    FOREIGN KEY (MovieID) REFERENCES Movies(ID),
    FOREIGN KEY (UserID) REFERENCES [User](ID)
);
CREATE TABLE Payment (
    ID INT PRIMARY KEY IDENTITY(1,1),
    BookingID INT,
    Amount INT,
    DiscountID INT,
    FOREIGN KEY (BookingID) REFERENCES Booking(ID),
    FOREIGN KEY (DiscountID) REFERENCES Discount(ID)
);
CREATE TABLE Revenue (
    ID INT PRIMARY KEY IDENTITY(1,1),
    CinemaID INT,
    TotalRevenue INT,
    FromDate DATE,
    ToDate DATE,
    FOREIGN KEY (CinemaID) REFERENCES Cinema(ID)
);
CREATE TABLE BookingSeatsDetail (
    ID INT PRIMARY KEY IDENTITY(1,1),
    SeatID INT,
    Price INT,
    BookingID INT,
    FOREIGN KEY (SeatID) REFERENCES Seat(ID),
    FOREIGN KEY (BookingID) REFERENCES Booking(ID)
);
CREATE TABLE FoodAndDrinks (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Price INT,
    Quantity INT,
	[Image] VARCHAR(MAX),
	Status VARCHAR(15)
);
CREATE TABLE BookingItem (
    ID INT PRIMARY KEY IDENTITY(1,1),
    FoodAndDrinksID INT,
    Quantity INT,
    Price INT,
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

