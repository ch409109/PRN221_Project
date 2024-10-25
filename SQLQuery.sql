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

INSERT INTO Role (RoleName) VALUES
('Admin'),
('User'),
('Staff');

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

INSERT INTO BookingItem (FoodAndDrinksID, Quantity, Price, BookingID) VALUES
(1, 1, 5.00, 1),
(2, 2, 6.00, 2);
INSERT INTO Showtime (MovieID, CinemaID, RoomID, Showtime, [Date]) VALUES
(1, 1, 1, '2024-10-10 19:00:00', '2024-10-10'),
(3, 2, 2, '2024-10-11 20:00:00', '2024-10-11');

-- Insert into MovieCategory
INSERT INTO MovieCategory (Name) VALUES 
('Action'),
('Horror'),
('Romance'),
('Animation'),
('Science Fiction'),
('Comedy');

-- Insert into Movies
INSERT INTO Movies (Title, Description, CategoryID, ReleaseDate, TrailerURL, Actor, Director, Poster, Status) VALUES
('Spider-Man: No Way Home', 'Peter Parker deals with his exposed identity', 17, '2021-12-17', 'https://www.youtube.com/watch?v=JfVOs4VSpmA', 'Tom Holland, Zendaya', 'Jon Watts', 'spiderman.jpg', 'Active'),
('Frozen 2', 'The adventure of Elsa and Anna in the enchanted forest', 20, '2019-11-22', 'https://www.youtube.com/watch?v=Zi4LMpSDccc', 'Kristen Bell, Idina Menzel', 'Chris Buck', 'frozen2.jpg', 'Active'),
('Inception', 'A thief who steals corporate secrets through dream-sharing technology', 21, '2010-07-16', 'https://www.youtube.com/watch?v=YoHD9XEInc0', 'Leonardo DiCaprio, Ellen Page', 'Christopher Nolan', 'inception.jpg', 'Active'),
('The Conjuring', 'Paranormal investigators help a family terrorized by a dark presence', 18, '2013-07-19', 'https://www.youtube.com/watch?v=k10ETZ41q5o', 'Vera Farmiga, Patrick Wilson', 'James Wan', 'conjuring.jpg', 'Active'),
('La La Land', 'A jazz musician and an aspiring actress fall in love', 19, '2016-12-09', 'https://www.youtube.com/watch?v=0pdqf4P9MB8', 'Ryan Gosling, Emma Stone', 'Damien Chazelle', 'lalaland.jpg', 'Active'),
('The Hangover', 'A bachelor party in Las Vegas goes hilariously wrong', 22, '2009-06-05', 'https://www.youtube.com/watch?v=tlize92ffnY', 'Bradley Cooper, Ed Helms', 'Todd Phillips', 'hangover.jpg', 'Active');

-- Insert into FoodAndDrinks
INSERT INTO FoodAndDrinks (Name, Price, Quantity, [Image], Status) VALUES
('Tacos', 7.99, 100, 'tacos.jpg', 'Active'),
('Coca Cola', 4.99, 200, 'coke.jpg', 'Active'),
('Popcorn', 11.99, 150, 'popcorn.jpg', 'Active'),
('French Fries', 5.99, 80, 'fries.jpg', 'Active'),
('Cheese Nachos', 6.99, 70, 'nachos.jpg', 'Active'),
('Classic Hotdog', 5.99, 90, 'hotdog.jpg', 'Active');

-- Insert into Cinema
INSERT INTO Cinema (Location, City, Name, Status) VALUES
('123 Main Street', 'New York', 'AMC Empire 25', 'Active'),
('456 Hollywood Blvd', 'Los Angeles', 'Regal LA LIVE', 'Active'),
('789 Michigan Ave', 'Chicago', 'AMC River East 21', 'Active'),
('321 Fillmore St', 'San Francisco', 'Century San Francisco', 'Active'),
('654 Peachtree St', 'Atlanta', 'Regal Atlantic Station', 'Active'),
('987 Congress Ave', 'Austin', 'Alamo Drafthouse Cinema', 'Active');