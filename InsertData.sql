USE PRN221_FinalProject
/*Insert*/
INSERT INTO Cinema (Location, City, Name) VALUES 
(N'Tầng 3 & 4 – TTTM AEON MALL HÀ ĐÔNG, P. Dương Nội, Q. Hà Đông', N'Hà Nội', N'CGV Aeon Hà Đông'),
(N'Tầng 4, Trung Tâm Thương Mại Vincom Ocean Park, Huyện Gia Lâm', N'Hà Nội', N'CGV Vincom Ocean Park');

INSERT INTO [dbo].[Room] ([Name],[CinemaID],[NumberOfRows])
     VALUES ('Starium',1,9)

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
(2, 'NhatLVHE176909', '123456', 'NhatLVHE176909@fpt.edu.vn', '0987654321', '1995-05-20', N'Lê Việt Nhật', 'Inactive')

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





