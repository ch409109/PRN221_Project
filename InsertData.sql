USE PRN221_FinalProject

INSERT INTO MovieCategory (Name) VALUES 
('Action'),
('Horror'),
('Romance'),
('Animation'),
('Science Fiction'),
('Comedy');

INSERT INTO Movies (Title, Description, CategoryID, ReleaseDate, TrailerURL, Actor, Director, Poster, Status) VALUES
('Spider-Man: No Way Home', 'Peter Parker deals with his exposed identity', 1, '2021-12-17', 'https://www.youtube.com/watch?v=JfVOs4VSpmA', 'Tom Holland, Zendaya', 'Jon Watts', 'spiderman.jpg', 'Active'),
('Frozen 2', 'The adventure of Elsa and Anna in the enchanted forest', 4, '2019-11-22', 'https://www.youtube.com/watch?v=Zi4LMpSDccc', 'Kristen Bell, Idina Menzel', 'Chris Buck', 'frozen2.jpg', 'Active'),
('Inception', 'A thief who steals corporate secrets through dream-sharing technology', 5, '2010-07-16', 'https://www.youtube.com/watch?v=YoHD9XEInc0', 'Leonardo DiCaprio, Ellen Page', 'Christopher Nolan', 'inception.jpg', 'Active'),
('The Conjuring', 'Paranormal investigators help a family terrorized by a dark presence', 2, '2013-07-19', 'https://www.youtube.com/watch?v=k10ETZ41q5o', 'Vera Farmiga, Patrick Wilson', 'James Wan', 'conjuring.jpg', 'Active'),
('La La Land', 'A jazz musician and an aspiring actress fall in love', 3, '2016-12-09', 'https://www.youtube.com/watch?v=0pdqf4P9MB8', 'Ryan Gosling, Emma Stone', 'Damien Chazelle', 'lalaland.jpg', 'Active'),
('The Hangover', 'A bachelor party in Las Vegas goes hilariously wrong', 6, '2009-06-05', 'https://www.youtube.com/watch?v=tlize92ffnY', 'Bradley Cooper, Ed Helms', 'Todd Phillips', 'hangover.jpg', 'Active');

INSERT INTO Cinema (Location, City, Name, Status) VALUES 
(N'Tầng 3 & 4 – TTTM AEON MALL HÀ ĐÔNG, P. Dương Nội, Q. Hà Đông', N'Hà Nội', N'CGV Aeon Hà Đông', 'Active'),
(N'Tầng 4, Trung Tâm Thương Mại Vincom Ocean Park, Huyện Gia Lâm', N'Hà Nội', N'CGV Vincom Ocean Park', 'Inactive');

INSERT INTO [dbo].[Room] ([Name],[CinemaID],[NumberOfRows])
     VALUES ('Starium',1,9),
			('Aquarius',1,9)

INSERT INTO [dbo].[Rows] ([RowName],[RoomID],[NumberOfColumns],[Type])
     VALUES
           ('A',1,14,'Regular'),('B',1,15,'Regular'),('C',1,15,'Regular'),
		   ('D',1,15,'VIP'),('E',1,15,'VIP'),('F',1,15,'VIP'),
		   ('G',1,15,'VIP'),('H',1,15,'VIP'),('J',1,15,'Sweetbox')


		   /*Manage Users*/
INSERT INTO Role (RoleName) VALUES 
('Admin'),('Customer'),('Movie Theater Owner'),('Staff');

INSERT INTO [User] (RoleID, Username, Password, Email, PhoneNumber, Dob, FullName, Status) VALUES 
(1, 'admin', '123456', 'admin@example.com', '0123456789', '1990-01-01', 'Administrator', 'Active'),
(2, 'TungNVHE170677', '123456', 'TungNVHE170677@fpt.edu.vn', '0987654321', '1995-05-20', N'Nguyễn Việt Tùng', 'Active'),
(3, 'TuanTNHE163211', '123456', 'TuanTNHE163211@fpt.edu.vn', '0987654321', '1995-05-20', N'Trình Ngọc Tuân', 'Active'),
(4, 'CongHTHE172673', '123456', 'CongHTHE172673@fpt.edu.vn', '0123456789', '1992-03-15', N'Hoàng Thành Công', 'Inactive'),
(2, 'NhatLVHE176909', '123456', 'NhatLVHE176909@fpt.edu.vn', '0987654321', '1995-05-20', N'Lê Việt Nhật', 'Inactive');

INSERT INTO Feedback (UserID, MovieID, Comments, CreateAt) VALUES
(2, 1, 'Amazing movie with stunning visuals!', '2024-10-11 10:00:00'),
(2, 3, 'Great love story, very touching.', '2024-10-11 11:00:00');

INSERT INTO News (Title, Content, Image, CreateAt, UpdateAt, CreateBy) VALUES
('New Release: Inception', 'Inception is now available in cinemas!', 'https://example.com/news/inception.jpg', '2024-10-10 12:00:00', '2024-10-11 09:00:00', 1);

INSERT INTO Discount (Code, DiscountValue, StartDate, EndDate) VALUES
('DISCOUNT10', 10.00, '2024-10-01', '2024-10-31'),
('HALFOFF', 50.00, '2024-11-01', '2024-11-30');

INSERT INTO Booking (BookingDate, CinemaID, MovieID, UserID, Status, TotalPrice) VALUES
('2024-10-10 19:00:00', 1, 1, 2, 'Confirmed', 20.00),
('2024-10-11 20:00:00', 2, 3, 2, 'Confirmed', 50.00);

INSERT INTO Payment (BookingID, Amount, DiscountID) VALUES
(1, 20.00, 1),
(2, 25.00, 2);

INSERT INTO Revenue (PaymentID, TotalRevenue, FromDate, ToDate) VALUES
(1, 2000.00, '2024-10-01', '2024-10-10'),
(2, 2500.00, '2024-10-11', '2024-10-20');

INSERT INTO FoodAndDrinks (Name, Price, Quantity, [Image], Status) VALUES
('Tacos', 7.99, 100, 'tacos.jpg', 'Active'),
('Coca Cola', 4.99, 200, 'coke.jpg', 'Active'),
('Popcorn', 11.99, 150, 'popcorn.jpg', 'Active'),
('French Fries', 5.99, 80, 'fries.jpg', 'Active'),
('Cheese Nachos', 6.99, 70, 'nachos.jpg', 'Active'),
('Classic Hotdog', 5.99, 90, 'hotdog.jpg', 'Active');

INSERT INTO BookingItem (FoodAndDrinksID, Quantity, Price, BookingID) VALUES
(1, 1, 5.00, 1),
(2, 2, 6.00, 2);

INSERT INTO Showtime (MovieID, CinemaID, RoomID, Showtime, [Date]) VALUES
(1, 1, 1, '2024-10-10 19:00:00', '2024-10-10'),
(3, 2, 2, '2024-10-11 20:00:00', '2024-10-11');

-- Insert seats for Row A (ID = 1)
INSERT INTO Seat (SeatName, RowID, Status)
VALUES
('A1', 1, 'Available'), ('A2', 1, 'Available'), ('A3', 1, 'Available'),
('A4', 1, 'Available'), ('A5', 1, 'Available'), ('A6', 1, 'Available'),
('A7', 1, 'Available'), ('A8', 1, 'Available'), ('A9', 1, 'Available'),
('A10', 1, 'Available'), ('A11', 1, 'Available'), ('A12', 1, 'Available'),
('A13', 1, 'Available'), ('A14', 1, 'Available');

-- Insert seats for Row B (ID = 2)
INSERT INTO Seat (SeatName, RowID, Status)
VALUES
('B1', 2, 'Available'), ('B2', 2, 'Available'), ('B3', 2, 'Available'),
('B4', 2, 'Available'), ('B5', 2, 'Available'), ('B6', 2, 'Available'),
('B7', 2, 'Available'), ('B8', 2, 'Available'), ('B9', 2, 'Available'),
('B10', 2, 'Available'), ('B11', 2, 'Available'), ('B12', 2, 'Available'),
('B13', 2, 'Available'), ('B14', 2, 'Available'), ('B15', 2, 'Available');

-- Insert seats for Row C (ID = 3)
INSERT INTO Seat (SeatName, RowID, Status)
VALUES
('C1', 3, 'Available'), ('C2', 3, 'Available'), ('C3', 3, 'Available'),
('C4', 3, 'Available'), ('C5', 3, 'Available'), ('C6', 3, 'Available'),
('C7', 3, 'Available'), ('C8', 3, 'Available'), ('C9', 3, 'Available'),
('C10', 3, 'Available'), ('C11', 3, 'Available'), ('C12', 3, 'Available'),
('C13', 3, 'Available'), ('C14', 3, 'Available'), ('C15', 3, 'Available');

-- Insert seats for Row D (ID = 4)
INSERT INTO Seat (SeatName, RowID, Status)
VALUES
('D1', 4, 'Available'), ('D2', 4, 'Available'), ('D3', 4, 'Available'),
('D4', 4, 'Available'), ('D5', 4, 'Available'), ('D6', 4, 'Available'),
('D7', 4, 'Available'), ('D8', 4, 'Available'), ('D9', 4, 'Available'),
('D10', 4, 'Available'), ('D11', 4, 'Available'), ('D12', 4, 'Available'),
('D13', 4, 'Available'), ('D14', 4, 'Available'), ('D15', 4, 'Available');

-- Insert seats for Row E (ID = 5)
INSERT INTO Seat (SeatName, RowID, Status)
VALUES
('E1', 5, 'Available'), ('E2', 5, 'Available'), ('E3', 5, 'Available'),
('E4', 5, 'Available'), ('E5', 5, 'Available'), ('E6', 5, 'Available'),
('E7', 5, 'Available'), ('E8', 5, 'Available'), ('E9', 5, 'Available'),
('E10', 5, 'Available'), ('E11', 5, 'Available'), ('E12', 5, 'Available'),
('E13', 5, 'Available'), ('E14', 5, 'Available'), ('E15', 5, 'Available');

-- Insert seats for Row F (ID = 6)
INSERT INTO Seat (SeatName, RowID, Status)
VALUES
('F1', 6, 'Available'), ('F2', 6, 'Available'), ('F3', 6, 'Available'),
('F4', 6, 'Available'), ('F5', 6, 'Available'), ('F6', 6, 'Available'),
('F7', 6, 'Available'), ('F8', 6, 'Available'), ('F9', 6, 'Available'),
('F10', 6, 'Available'), ('F11', 6, 'Available'), ('F12', 6, 'Available'),
('F13', 6, 'Available'), ('F14', 6, 'Available'), ('F15', 6, 'Available');

-- Insert seats for Row G (ID = 7)
INSERT INTO Seat (SeatName, RowID, Status)
VALUES
('G1', 7, 'Available'), ('G2', 7, 'Available'), ('G3', 7, 'Available'),
('G4', 7, 'Available'), ('G5', 7, 'Available'), ('G6', 7, 'Available'),
('G7', 7, 'Available'), ('G8', 7, 'Available'), ('G9', 7, 'Available'),
('G10', 7, 'Available'), ('G11', 7, 'Available'), ('G12', 7, 'Available'),
('G13', 7, 'Available'), ('G14', 7, 'Available'), ('G15', 7, 'Available');

-- Insert seats for Row H (ID = 8)
INSERT INTO Seat (SeatName, RowID, Status)
VALUES
('H1', 8, 'Available'), ('H2', 8, 'Available'), ('H3', 8, 'Available'),
('H4', 8, 'Available'), ('H5', 8, 'Available'), ('H6', 8, 'Available'),
('H7', 8, 'Available'), ('H8', 8, 'Available'), ('H9', 8, 'Available'),
('H10', 8, 'Available'), ('H11', 8, 'Available'), ('H12', 8, 'Available'),
('H13', 8, 'Available'), ('H14', 8, 'Available'), ('H15', 8, 'Available');

INSERT INTO BookingSeatsDetail (SeatID, Price, BookingID) VALUES
(1, 10.00, 1),
(2, 10.00, 1),
(3, 25.00, 2),
(4, 25.00, 2);





