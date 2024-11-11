/*Cinema*/
INSERT INTO Cinema (Location, City, Name, Status) VALUES 
/*(N'Tầng 3 & 4 – TTTM AEON MALL HÀ ĐÔNG, P. Dương Nội, Q. Hà Đông', N'Hà Nội', N'CGV Aeon Hà Đông', 'Active'),
(N'Tầng 4, Trung Tâm Thương Mại Vincom Ocean Park, Huyện Gia Lâm', N'Hà Nội', N'CGV Vincom Ocean Park', 'Inactive'),*/
(N'Tầng 3, Trung Tâm Thương Mại Vincom Times City, P. Vĩnh Tuy, Q. Hai Bà Trưng', N'Hà Nội', N'CGV Vincom Times City', 'Active'),
(N'Tầng 6, TTTM Lotte Center, 54 Liễu Giai, Q. Ba Đình', N'Hà Nội', N'CGV Lotte Center Hà Nội', 'Active'),
(N'Tầng 5, TTTM Mipec Tower, 229 Tây Sơn, Q. Đống Đa', N'Hà Nội', N'CGV Mipec Tower', 'Inactive'),
(N'Tầng 4, TTTM The Garden, Mễ Trì, Q. Nam Từ Liêm', N'Hà Nội', N'CGV The Garden', 'Active'),
(N'Tầng 3, TTTM Vincom Nguyễn Chí Thanh, 54A Nguyễn Chí Thanh, Q. Đống Đa', N'Hà Nội', N'CGV Vincom Nguyễn Chí Thanh', 'Active'),
(N'Tầng 4, TTTM Royal City, 72A Nguyễn Trãi, Q. Thanh Xuân', N'Hà Nội', N'CGV Royal City', 'Inactive'),
(N'Tầng 2, TTTM Vincom Bắc Từ Liêm, Q. Bắc Từ Liêm', N'Hà Nội', N'CGV Vincom Bắc Từ Liêm', 'Active'),
(N'Tầng 4, TTTM Vincom Trần Duy Hưng, 119 Trần Duy Hưng, Q. Cầu Giấy', N'Hà Nội', N'CGV Vincom Trần Duy Hưng', 'Active'),
(N'Tầng 5, TTTM Lotte Mart Đống Đa, P. Trung Liệt, Q. Đống Đa', N'Hà Nội', N'CGV Lotte Mart Đống Đa', 'Inactive'),
(N'Tầng 3, TTTM Vincom Bà Triệu, Q. Hai Bà Trưng', N'Hà Nội', N'CGV Vincom Bà Triệu', 'Active'),
(N'Tầng 5, TTTM Vincom Center Đồng Khởi, Q.1', N'Hồ Chí Minh', N'CGV Vincom Center Đồng Khởi', 'Active'),
(N'Tầng 3, TTTM Aeon Mall Tân Phú Celadon, Q. Tân Phú', N'Hồ Chí Minh', N'CGV Aeon Tân Phú', 'Inactive'),
(N'Tầng 4, TTTM Crescent Mall, Q.7', N'Hồ Chí Minh', N'CGV Crescent Mall', 'Active'),
(N'Tầng 6, TTTM Pearl Plaza, Q. Bình Thạnh', N'Hồ Chí Minh', N'CGV Pearl Plaza', 'Active'),
(N'Tầng 4, TTTM Vincom Landmark 81, Q. Bình Thạnh', N'Hồ Chí Minh', N'CGV Landmark 81', 'Inactive'),
(N'Tầng 3, TTTM Estella Place, Q.2', N'Hồ Chí Minh', N'CGV Estella Place', 'Active'),
(N'Tầng 5, TTTM Vincom Thảo Điền, Q.2', N'Hồ Chí Minh', N'CGV Vincom Thảo Điền', 'Active'),
(N'Tầng 2, TTTM SC VivoCity, Q.7', N'Hồ Chí Minh', N'CGV SC VivoCity', 'Inactive'),
(N'Tầng 3, TTTM Giga Mall Thủ Đức, Q. Thủ Đức', N'Hồ Chí Minh', N'CGV Giga Mall', 'Active'),
(N'Tầng 2, TTTM Vincom Mega Mall, Q.2', N'Hồ Chí Minh', N'CGV Vincom Mega Mall', 'Active'),
(N'Tầng 3, TTTM Vincom Plaza Lê Văn Việt, Q.9', N'Hồ Chí Minh', N'CGV Vincom Plaza Lê Văn Việt', 'Active'),
(N'Tầng 5, TTTM Nowzone Fashion Mall, Q.1', N'Hồ Chí Minh', N'CGV Nowzone', 'Inactive');

/*Room*/
/* Thêm phòng chiếu cho CinemaID từ 1 đến 22 */
INSERT INTO [dbo].[Room] ([Name], [CinemaID], [NumberOfRows]) VALUES
    -- CinemaID 1
    ('Starium', 1, 9),         -- Phòng chiếu "Starium" thuộc rạp "CGV Aeon Hà Đông"
    ('Aquarius', 1, 9), 
    ('Ra', 1, 8),         -- Vị thần Ra của Ai Cập
    ('Vayne', 1, 8),
    ('Neith', 1, 7),      -- Vị thần Neith của Ai Cập
    ('Sylas', 1, 8),
    ('Teemo', 1, 7),
    ('Mars', 1, 8),       -- Hành tinh Mars (Sao Hỏa)
    ('Twitch', 1, 6),
    ('Jupiter', 1, 7),    -- Hành tinh Jupiter (Sao Mộc)
    
    -- CinemaID 2
    ('Orion', 2, 8),           -- Phòng chiếu "Orion" thuộc rạp "CGV Vincom Ocean Park"
    ('Hercules', 2, 8),
    ('Amun', 2, 6),       -- Vị thần Amun của Ai Cập
    ('Vi', 2, 9),
    ('Viktor', 2, 8),
    ('Vladimir', 2, 7),
    ('Volibear', 2, 6),
    ('Warwick', 2, 9),
    ('Wukong', 2, 8),
    ('Saturn', 2, 7),     -- Hành tinh Saturn (Sao Thổ)

    -- CinemaID 3
    ('Xerath', 3, 7),
    ('Xin Zhao', 3, 8),
    ('Yone', 3, 6),
    ('Zac', 3, 9),
    ('Uranus', 3, 8),     -- Hành tinh Uranus (Sao Thiên Vương)
    ('Ziggs', 3, 7),
    ('Zilean', 3, 6),
    ('Zoe', 3, 9),
    ('Neptune', 3, 7),    -- Hành tinh Neptune (Sao Hải Vương)
    ('Ceres', 3, 8),      -- Hành tinh Ceres (hành tinh lùn)

    -- CinemaID 4
    ('Kled', 4, 7),
    ('KogMaw', 4, 8),
    ('Anubis', 4, 6),     -- Vị thần Anubis của Ai Cập
    ('Lee Sin', 4, 9),
    ('Leona', 4, 8),
    ('Lissandra', 4, 7),
    ('Lucian', 4, 6),
    ('Lulu', 4, 8),
    ('Lux', 4, 9),
    ('Osiris', 4, 7),     -- Vị thần Osiris của Ai Cập

    -- CinemaID 5
    ('Malzahar', 5, 7),
    ('Maokai', 5, 8),
    ('Mercury', 5, 6),    -- Hành tinh Mercury (Sao Thủy)
    ('Miss Fortune', 5, 9),
    ('Mordekaiser', 5, 8),
    ('Morgana', 5, 7),
    ('Nami', 5, 7),
    ('Nasus', 5, 6),
    ('Nautilus', 5, 8),
    ('Neeko', 5, 9),

    -- CinemaID 6
    ('Nidalee', 6, 7),
    ('Nocturne', 6, 8),
    ('Seth', 6, 6),       -- Vị thần Seth của Ai Cập
    ('Olaf', 6, 9),
    ('Orianna', 6, 8),
    ('Ornn', 6, 7),
    ('Pantheon', 6, 6),
    ('Poppy', 6, 8),
    ('Pyke', 6, 9),
    ('Pluto', 6, 7),      -- Hành tinh Pluto (Sao Diêm Vương)

    -- CinemaID 7
    ('Quinn', 7, 7),
    ('Rakan', 7, 8),
    ('Rammus', 7, 6),
    ('RekSai', 7, 9),
    ('Rell', 7, 8),
    ('Renekton', 7, 7),
    ('Rengar', 7, 6),
    ('Riven', 7, 8),
    ('Rumble', 7, 9),
    ('Ra', 7, 7),         -- Vị thần Ra của Ai Cập

    -- CinemaID 8
    ('Samira', 8, 8),
    ('Sejuani', 8, 7),
    ('Senna', 8, 6),
    ('Seraphine', 8, 9),
    ('Saturn', 8, 8),     -- Hành tinh Saturn (Sao Thổ)
    ('Shaco', 8, 7),
    ('Shen', 8, 6),
    ('Shyvana', 8, 8),
    ('Singed', 8, 9),
    ('Sion', 8, 7),

    -- CinemaID 9
    ('Sivir', 9, 7),
    ('Skarner', 9, 8),
    ('Sona', 9, 6),
    ('Soraka', 9, 9),
    ('Sylas', 9, 8),
    ('Syndra', 9, 7),
    ('Tahm Kench', 9, 6),
    ('Taliyah', 9, 9),
    ('Taric', 9, 8),
    ('Tristana', 9, 7),

    -- CinemaID 10
    ('Trundle', 10, 8),
    ('Tryndamere', 10, 7),
    ('Twitch', 10, 6),
    ('Twisted Fate', 10, 9),
    ('Udyr', 10, 8),
    ('Urgot', 10, 7),
    ('Varus', 10, 6),
    ('Veigar', 10, 8),
    ('VelKoz', 10, 9),
    ('Vi', 10, 7),

    -- CinemaID 11
    ('Viktor', 11, 8),
    ('Vladimir', 11, 7),
    ('Volibear', 11, 6),
    ('Warwick', 11, 9),
    ('Wukong', 11, 8),
    ('Xayah', 11, 7),
    ('Xerath', 11, 6),
    ('Xin Zhao', 11, 9),
    ('Yone', 11, 8),
    ('Zac', 11, 7),

    -- CinemaID 12
    ('Ziggs', 12, 8),
    ('Zilean', 12, 7),
    ('Zoe', 12, 6),
    ('Yuumi', 12, 9),
    ('Aatrox', 12, 7),
    ('Ahri', 12, 8),
    ('Akali', 12, 6),
    ('Alistar', 12, 9),
    ('Amumu', 12, 8),
    ('Anivia', 12, 7),

    -- CinemaID 13
    ('Annie', 13, 7),
    ('Ashe', 13, 8),
    ('Azir', 13, 6),
    ('Bard', 13, 9),
    ('Blitzcrank', 13, 7),
    ('Brand', 13, 8),
    ('Braum', 13, 6),
    ('Caitlyn', 13, 9),
    ('Camille', 13, 8),
    ('Cassiopeia', 13, 7),

    -- CinemaID 14
    ('Sivir', 14, 7),
    ('Skarner', 14, 8),
    ('Sona', 14, 6),
    ('Soraka', 14, 9),
    ('Sylas', 14, 8),
    ('Syndra', 14, 7),
    ('Tahm Kench', 14, 6),
    ('Taliyah', 14, 9),
    ('Taric', 14, 8),
    ('Tristana', 14, 7),
    
    -- CinemaID 15
    ('Trundle', 15, 8),
    ('Tryndamere', 15, 7),
    ('Twitch', 15, 6),
    ('Twisted Fate', 15, 9),
    ('Udyr', 15, 8),
    ('Urgot', 15, 7),
    ('Varus', 15, 6),
    ('Veigar', 15, 8),
    ('VelKoz', 15, 9),
    ('Vi', 15, 7),
    
    -- CinemaID 16
    ('Viktor', 16, 8),
    ('Vladimir', 16, 7),
    ('Volibear', 16, 6),
    ('Warwick', 16, 9),
    ('Wukong', 16, 8),
    ('Xayah', 16, 7),
    ('Xerath', 16, 6),
    ('Xin Zhao', 16, 9),
    ('Yone', 16, 8),
    ('Zac', 16, 7),

    -- CinemaID 17
    ('Ziggs', 17, 8),
    ('Zilean', 17, 7),
    ('Zoe', 17, 6),
    ('Yuumi', 17, 9),
    ('Aatrox', 17, 7),
    ('Ahri', 17, 8),
    ('Akali', 17, 6),
    ('Alistar', 17, 9),
    ('Amumu', 17, 8),
    ('Anivia', 17, 7),

    -- CinemaID 18
    ('Annie', 18, 7),
    ('Ashe', 18, 8),
    ('Azir', 18, 6),
    ('Bard', 18, 9),
    ('Blitzcrank', 18, 7),
    ('Brand', 18, 8),
    ('Braum', 18, 6),
    ('Caitlyn', 18, 9),
    ('Camille', 18, 8),
    ('Cassiopeia', 18, 7),

    -- CinemaID 19
    ('Cassiopeia', 19, 8),
    ('Cho"Gath', 19, 7),
    ('Corki', 19, 6),
    ('Darius', 19, 9),
    ('Diana', 19, 8),
    ('Draven', 19, 7),
    ('Ekko', 19, 6),
    ('Elise', 19, 9),
    ('Evelynn', 19, 8),
    ('Ezreal', 19, 7),

    -- CinemaID 20
    ('Fiora', 20, 8),
    ('Fizz', 20, 7),
    ('Galio', 20, 6),
    ('Gangplank', 20, 9),
    ('Garen', 20, 8),
    ('Gragas', 20, 7),
    ('Graves', 20, 6),
    ('Hecarim', 20, 9),
    ('Heimerdinger', 20, 8),
    ('Illaoi', 20, 7),

    -- CinemaID 21
    ('Irelia', 21, 8),
    ('Janna', 21, 7),
    ('Jarvan IV', 21, 6),
    ('Jhin', 21, 9),
    ('Jinx', 21, 8),
    ('Kaisa', 21, 7),
    ('Karthus', 21, 6),
    ('Kassadin', 21, 9),
    ('Katarina', 21, 8),
    ('Kayle', 21, 7),

    -- CinemaID 22
    ('Kennen', 22, 8),
    ('Kha"Zix', 22, 7),
    ('Kindred', 22, 6),
    ('Kled', 22, 9),
    ('Kog"Maw', 22, 8),
    ('LeBlanc', 22, 7),
    ('Lee Sin', 22, 6),
    ('Leona', 22, 9),
    ('Lissandra', 22, 8),
    ('Lucian', 22, 7);

	
INSERT INTO [dbo].[Rows] ([RowName], [RoomID], [NumberOfColumns], [Type]) VALUES
    -- RoomID 1 (CGV Aeon Hà Đông)
    ('A', 1, 14, 'Regular'), ('B', 1, 15, 'Regular'), ('C', 1, 15, 'Regular'),
    ('D', 1, 15, 'VIP'), ('E', 1, 15, 'VIP'), ('F', 1, 15, 'VIP'),
    ('G', 1, 15, 'VIP'), ('H', 1, 15, 'VIP'), ('J', 1, 15, 'VIP'),

    -- RoomID 2 (CGV Vincom Ocean Park)
    ('A', 2, 13, 'Regular'), ('B', 2, 14, 'Regular'), ('C', 2, 14, 'Regular'),
    ('D', 2, 14, 'VIP'), ('E', 2, 14, 'VIP'), ('F', 2, 14, 'VIP'),
    ('G', 2, 14, 'VIP'), ('H', 2, 14, 'VIP'), ('J', 2, 14, 'VIP'),

    -- RoomID 3 (Starium - CGV Aeon Hà Đông)
    ('A', 3, 16, 'Regular'), ('B', 3, 16, 'Regular'), ('C', 3, 16, 'Regular'),
    ('D', 3, 16, 'VIP'), ('E', 3, 16, 'VIP'), ('F', 3, 16, 'VIP'),
    ('G', 3, 16, 'VIP'), ('H', 3, 16, 'VIP'), ('J', 3, 16, 'VIP'),

    -- RoomID 4 (Aquarius - CGV Aeon Hà Đông)
    ('A', 4, 14, 'Regular'), ('B', 4, 14, 'Regular'), ('C', 4, 14, 'Regular'),
    ('D', 4, 14, 'VIP'), ('E', 4, 14, 'VIP'), ('F', 4, 14, 'VIP'),
    ('G', 4, 14, 'VIP'), ('H', 4, 14, 'VIP'), ('J', 4, 14, 'VIP'),

    -- RoomID 5 (Orion - CGV Vincom Ocean Park)
    ('A', 5, 12, 'Regular'), ('B', 5, 13, 'Regular'), ('C', 5, 13, 'Regular'),
    ('D', 5, 13, 'VIP'), ('E', 5, 13, 'VIP'), ('F', 5, 13, 'VIP'),
    ('G', 5, 13, 'VIP'), ('H', 5, 13, 'VIP'), ('J', 5, 13, 'VIP'),

    -- RoomID 6 (Hercules - CGV Vincom Ocean Park)
    ('A', 6, 13, 'Regular'), ('B', 6, 13, 'Regular'), ('C', 6, 13, 'Regular'),
    ('D', 6, 13, 'VIP'), ('E', 6, 13, 'VIP'), ('F', 6, 13, 'VIP'),
    ('G', 6, 13, 'VIP'), ('H', 6, 13, 'VIP'), ('J', 6, 13, 'VIP'),

    -- RoomID 7 đến RoomID 22 (Các phòng chiếu còn lại)
    ('A', 7, 12, 'Regular'), ('B', 7, 13, 'Regular'), ('C', 7, 13, 'Regular'),
    ('D', 7, 13, 'VIP'), ('E', 7, 13, 'VIP'), ('F', 7, 13, 'VIP'),
    ('G', 7, 13, 'VIP'), ('H', 7, 13, 'VIP'), ('J', 7, 13, 'VIP'),

    ('A', 8, 14, 'Regular'), ('B', 8, 14, 'Regular'), ('C', 8, 14, 'Regular'),
    ('D', 8, 14, 'VIP'), ('E', 8, 14, 'VIP'), ('F', 8, 14, 'VIP'),
    ('G', 8, 14, 'VIP'), ('H', 8, 14, 'VIP'), ('J', 8, 14, 'VIP'),

    ('A', 9, 15, 'Regular'), ('B', 9, 15, 'Regular'), ('C', 9, 15, 'Regular'),
    ('D', 9, 15, 'VIP'), ('E', 9, 15, 'VIP'), ('F', 9, 15, 'VIP'),
    ('G', 9, 15, 'VIP'), ('H', 9, 15, 'VIP'), ('J', 9, 15, 'VIP'),

    ('A', 10, 13, 'Regular'), ('B', 10, 13, 'Regular'), ('C', 10, 13, 'Regular'),
    ('D', 10, 13, 'VIP'), ('E', 10, 13, 'VIP'), ('F', 10, 13, 'VIP'),
    ('G', 10, 13, 'VIP'), ('H', 10, 13, 'VIP'), ('J', 10, 13, 'VIP'),

    ('A', 11, 14, 'Regular'), ('B', 11, 14, 'Regular'), ('C', 11, 14, 'Regular'),
    ('D', 11, 14, 'VIP'), ('E', 11, 14, 'VIP'), ('F', 11, 14, 'VIP'),
    ('G', 11, 14, 'VIP'), ('H', 11, 14, 'VIP'), ('J', 11, 14, 'VIP'),

    ('A', 12, 12, 'Regular'), ('B', 12, 12, 'Regular'), ('C', 12, 12, 'Regular'),
    ('D', 12, 12, 'VIP'), ('E', 12, 12, 'VIP'), ('F', 12, 12, 'VIP'),
    ('G', 12, 12, 'VIP'), ('H', 12, 12, 'VIP'), ('J', 12, 12, 'VIP'),

    ('A', 13, 14, 'Regular'), ('B', 13, 14, 'Regular'), ('C', 13, 14, 'Regular'),
    ('D', 13, 14, 'VIP'), ('E', 13, 14, 'VIP'), ('F', 13, 14, 'VIP'),
    ('G', 13, 14, 'VIP'), ('H', 13, 14, 'VIP'), ('J', 13, 14, 'VIP'),

    ('A', 14, 13, 'Regular'), ('B', 14, 13, 'Regular'), ('C', 14, 13, 'Regular'),
    ('D', 14, 13, 'VIP'), ('E', 14, 13, 'VIP'), ('F', 14, 13, 'VIP'),
    ('G', 14, 13, 'VIP'), ('H', 14, 13, 'VIP'), ('J', 14, 13, 'VIP'),

    ('A', 15, 12, 'Regular'), ('B', 15, 12, 'Regular'), ('C', 15, 12, 'Regular'),
    ('D', 15, 12, 'VIP'), ('E', 15, 12, 'VIP'), ('F', 15, 12, 'VIP'),
    ('G', 15, 12, 'VIP'), ('H', 15, 12, 'VIP'), ('J', 15, 12, 'VIP'),

    ('A', 16, 14, 'Regular'), ('B', 16, 14, 'Regular'), ('C', 16, 14, 'Regular'),
    ('D', 16, 14, 'VIP'), ('E', 16, 14, 'VIP'), ('F', 16, 14, 'VIP'),
    ('G', 16, 14, 'VIP'), ('H', 16, 14, 'VIP'), ('J', 16, 14, 'VIP'),

    ('A', 17, 12, 'Regular'), ('B', 17, 12, 'Regular'), ('C', 17, 12, 'Regular'),
    ('D', 17, 12, 'VIP'), ('E', 17, 12, 'VIP'), ('F', 17, 12, 'VIP'),
    ('G', 17, 12, 'VIP'), ('H', 17, 12, 'VIP'), ('J', 17, 12, 'VIP'),

    ('A', 18, 13, 'Regular'), ('B', 18, 13, 'Regular'), ('C', 18, 13, 'Regular'),
    ('D', 18, 13, 'VIP'), ('E', 18, 13, 'VIP'), ('F', 18, 13, 'VIP'),
    ('G', 18, 13, 'VIP'), ('H', 18, 13, 'VIP'), ('J', 18, 13, 'VIP'),
    
    ('A', 19, 15, 'Regular'), ('B', 19, 15, 'Regular'), ('C', 19, 15, 'Regular'),
    ('D', 19, 15, 'VIP'), ('E', 19, 15, 'VIP'), ('F', 19, 15, 'VIP'),
    ('G', 19, 15, 'VIP'), ('H', 19, 15, 'VIP'), ('J', 19, 15, 'VIP'),

    ('A', 20, 13, 'Regular'), ('B', 20, 13, 'Regular'), ('C', 20, 13, 'Regular'),
    ('D', 20, 13, 'VIP'), ('E', 20, 13, 'VIP'), ('F', 20, 13, 'VIP'),
    ('G', 20, 13, 'VIP'), ('H', 20, 13, 'VIP'), ('J', 20, 13, 'VIP'),

    ('A', 21, 15, 'Regular'), ('B', 21, 15, 'Regular'), ('C', 21, 15, 'Regular'),
    ('D', 21, 15, 'VIP'), ('E', 21, 15, 'VIP'), ('F', 21, 15, 'VIP'),
    ('G', 21, 15, 'VIP'), ('H', 21, 15, 'VIP'), ('J', 21, 15, 'VIP'),

    ('A', 22, 12, 'Regular'), ('B', 22, 12, 'Regular'), ('C', 22, 12, 'Regular'),
    ('D', 22, 12, 'VIP'), ('E', 22, 12, 'VIP'), ('F', 22, 12, 'VIP'),
    ('G', 22, 12, 'VIP'), ('H', 22, 12, 'VIP'), ('J', 22, 12, 'VIP');
/*Insert Seat*/
DECLARE @RowName VARCHAR(15), @RowID INT, @NumberOfColumns INT;
DECLARE @i INT;

-- Lấy thông tin từ bảng Rows
DECLARE row_cursor CURSOR FOR
SELECT RowName, ID, NumberOfColumns FROM [Rows];

OPEN row_cursor;
FETCH NEXT FROM row_cursor INTO @RowName, @RowID, @NumberOfColumns;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Vòng lặp để tạo ghế cho mỗi hàng
    SET @i = 1;
    WHILE @i <= @NumberOfColumns
    BEGIN
        INSERT INTO Seat (SeatName, RowID, Status)
        VALUES (@RowName + CAST(@i AS VARCHAR(5)), @RowID, 'Available');
        SET @i = @i + 1;
    END

    FETCH NEXT FROM row_cursor INTO @RowName, @RowID, @NumberOfColumns;
END;

CLOSE row_cursor;
DEALLOCATE row_cursor;
