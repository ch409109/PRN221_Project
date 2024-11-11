USE PRN221_FinalProject

/*MovieCategory*/
INSERT INTO MovieCategory (Name) VALUES 
('Action'),
('Horror'),
('Romance'),
('Animation'),
('Science Fiction'),
('Comedy');
/*Role*/
INSERT INTO Role (RoleName) VALUES 
('Admin'),('Customer'),('Movie Theater Owner'),('Staff');

/*Movies*/
INSERT INTO Movies (Title, Description, CategoryID, ReleaseDate, Duration, TrailerURL, Actor, Director, Poster, Status) VALUES
('Spider-Man: No Way Home', 'Spider-Man, comic-book character who was the original everyman superhero. In Spider-Man’s first story, in Marvel Comics’ Amazing Fantasy, no. 15 (1962), American teenager Peter Parker, a poor sickly orphan, is bitten by a radioactive spider. As a result of the bite, he gains superhuman strength, speed, and agility along with the ability to cling to walls. Writer Stan Lee and illustrator Steve Ditko created Spider-Man as a filler story for a canceled anthology series. At the time, a teenage lead hero was unheard of in comic books. However, young readers responded powerfully to Peter Parker, prompting an ongoing title and, ultimately, a media empire, including video games, several animated and one live-action television series, a live-action film franchise, and a Broadway musical.', 1, '2021-12-17', '02:28:00', 'https://www.youtube.com/watch?v=JfVOs4VSpmA', 'Tom Holland, Zendaya', 'Jon Watts', 'spiderman.jpg', 'Active'),
('Frozen 2', 'Frozen is a 2013 American animated musical fantasy film produced by Walt Disney Animation Studios and released by Walt Disney Pictures.[8] Inspired by Hans Christian Andersens 1844 fairy tale "The Snow Queen",[1] it was directed by Chris Buck and Jennifer Lee (in her feature directorial debut) and produced by Peter Del Vecho, from a screenplay by Lee, who also conceived the films story with Buck and Shane Morris. The film stars the voices of Kristen Bell, Idina Menzel, Jonathan Groff, Josh Gad, and Santino Fontana. It follows Anna, the princess of Arendelle, who sets off on a journey with the iceman Kristoff, his reindeer Sven, and the snowman Olaf, to find her estranged sister Elsa after she accidentally traps their kingdom in eternal winter with her icy powers.', 4, '2019-11-22', '01:43:00',  'https://www.youtube.com/watch?v=Zi4LMpSDccc', 'Kristen Bell, Idina Menzel', 'Chris Buck', 'frozen2.jpg', 'Active'),
('Inception', 'Inception centres on brooding “extractor” Dom Cobb (played by Leonardo DiCaprio)—a thief who invades targets’ dreams through a chemical-induced shared dream state in order to steal valuable information. Having a reputation for being the best in his business, Cobb is commissioned by wealthy businessman Mr. Saito (Ken Watanabe) to take on the exceptional feat of reverse extraction—planting an idea in a target’s mind, otherwise known as inception—in order to eliminate a business competitor. Cobb assembles a crew to attempt the purportedly impossible task: longtime associate Arthur (Joseph Gordon-Levitt), master manipulator Eames (Tom Hardy), chemist Yusuf (Dileep Rao), and “architect” Ariadne (Ellen Page), who is in charge of creating the dreamscapes the team will occupy. In order to plant the idea, Cobb and his crew must descend through several layers of dreaming to penetrate the target’s subconscious. In the process, however, Cobb’s own subconscious starts to surface—to disastrous effect. The team is repeatedly hindered by a subconscious projection of Cobb’s dead wife, Mal (Marion Cotillard), and Cobb himself is forced to question whether his reality is as real as it seems.', 5, '2010-07-16', '02:28:00', 'https://www.youtube.com/watch?v=YoHD9XEInc0', 'Leonardo DiCaprio, Ellen Page', 'Christopher Nolan', 'inception.jpg', 'Active'),
('The Conjuring', 'The Conjuring is a 2013 American supernatural horror film directed by James Wan and written by Chad Hayes and Carey W. Hayes. It is the inaugural film in The Conjuring Universe franchise.[4] Patrick Wilson and Vera Farmiga star as Ed and Lorraine Warren, paranormal investigators and authors associated with prominent cases of haunting. Their purportedly real-life reports inspired The Amityville Horror story and the associated film franchise.[5] The Warrens come to the assistance of the Perron family, who experienced increasingly disturbing events in their newly occupied farmhouse in Rhode Island in 1971.', 2, '2013-07-19', '01:52:00', 'https://www.youtube.com/watch?v=k10ETZ41q5o', 'Vera Farmiga, Patrick Wilson', 'James Wan', 'conjuring.jpg', 'Active'),
('La La Land', 'La La Land is a 2016 American musical romantic comedy-drama film written and directed by Damien Chazelle. It stars Ryan Gosling and Emma Stone as a struggling jazz pianist and an aspiring actress who meet and fall in love while pursuing their dreams in Los Angeles. The supporting cast includes John Legend, Rosemarie DeWitt, Finn Wittrock, and J. K. Simmons.Having been fond of musicals during his time as a drummer, Chazelle first conceptualized the film alongside Justin Hurwitz while attending Harvard University together. After moving to Los Angeles in 2010, Chazelle penned the script but did not find a studio willing to finance the production without changes to his design. After the success of his film Whiplash (2014), the project was picked up by Summit Entertainment. Miles Teller and Emma Watson were originally in talks to star, but after both dropped out, Gosling and Stone were cast. Filming took place in Los Angeles between August and September 2015, with the film score composed by Hurwitz, who also wrote the film songs with lyricists Benj Pasek and Justin Paul and the dance choreography by Mandy Moore.', 3, '2016-12-09', '02:08:00', 'https://www.youtube.com/watch?v=0pdqf4P9MB8', 'Ryan Gosling, Emma Stone', 'Damien Chazelle', 'lalaland.jpg', 'Active'),
('The Hangover', 'The Hangover is a 2009 American comedy film directed by Todd Phillips, and written by Jon Lucas and Scott Moore. It is the first installment in The Hangover trilogy. The film stars Bradley Cooper, Ed Helms, Zach Galifianakis, Heather Graham, Justin Bartha, and Jeffrey Tambor. It tells the story of Phil Wenneck (Cooper), Stu Price (Helms), Alan Garner (Galifianakis), and Doug Billings (Bartha), who travel to Las Vegas for a bachelor party to celebrate Dougs impending marriage. However, Phil, Stu, and Alan wake up with Doug missing and no memory of the previous nights events, and must find Doug before the wedding can take place.Lucas and Moore wrote the script after executive producer Chris Benders friend disappeared and had a large bill after being sent to a strip club. After Lucas and Moore sold it to the studio for $2 million, Phillips and Jeremy Garelick rewrote the script to include a tiger as well as a subplot involving a baby and a police cruiser, and also including boxer Mike Tyson. Filming took place in Nevada for 15 days, and during filming, the three main actors (Cooper, Helms, and Galifianakis) formed a real friendship.', 6, '2009-06-05', '01:40:00', 'https://www.youtube.com/watch?v=tlize92ffnY', 'Bradley Cooper, Ed Helms', 'Todd Phillips', 'hangover.jpg', 'Active'),
('Interstellar', 'Set in a future where Earth is becoming uninhabitable, a team of astronauts, led by Cooper, embarks on a mission through a wormhole to find a new home for humanity. Their journey tests the boundaries of space and time, revealing mysteries of the universe and the deep bonds of love and sacrifice to secure the future of humankind.', 5, '2014-11-07', '02:49:00', 'https://www.youtube.com/watch?v=zSWdZVtXT7E', 'Matthew McConaughey, Anne Hathaway', 'Christopher Nolan', 'interstellar_poster.jpg', 'Poster'),
('The Dark Knight', 'Based on true events, paranormal investigators Ed and Lorraine Warren are called to help a family plagued by supernatural forces in their new home. As they delve deeper, they uncover terrifying secrets and an evil presence, challenging their courage and faith in the face of malevolent forces.', 1, '2008-07-18', '02:32:00', 'https://www.youtube.com/watch?v=EXeTwQWrcwY', 'Christian Bale, Heath Ledger', 'Christopher Nolan', 'dark_knight_poster.jpg', 'Poster'),
('Titanic', 'Elsa, Anna, Kristoff, and Olaf set off on a journey to uncover the source of Elsas powers and the true history of their kingdom. Facing past mysteries and navigating the enchanted forest and distant lands, they discover the deeper meaning of love and courage in the face of unknown challenges.', 3, '1997-12-19', '03:14:00', 'https://www.youtube.com/watch?v=2e-eXJ6HgkQ', 'Leonardo DiCaprio, Kate Winslet', 'James Cameron', 'titanic_poster.jpg', 'Poster'),
('Avatar 3', 'Peter Parker life is turned upside down when his identity as Spider-Man is exposed. Seeking help from Doctor Strange, he inadvertently opens up the multiverse, bringing in dangerous enemies from other dimensions. Peter must fight to protect those he loves and learn what it truly means to be Spider-Man.', 5, '2025-12-19', '02:56:00', 'https://www.youtube.com/watch?v=YXtWPVFk5TQ', 'Sam Worthington, Zoe Saldana', 'James Cameron', 'avatar3_poster.jpg', 'Poster'),
('Frozen 3', 'Dom Cobb returns for a new mission, diving deeper into the subconscious to extract secrets buried in the dream world. This time, he faces an adversary who knows and manipulates the art of dream extraction, sending him on a thrilling journey where the lines between dream and reality blur even further.', 4, '2027-07-21', '01:45:00', 'https://www.youtube.com/watch?v=xJgAypHXCZo', 'Kristen Bell, Idina Menzel', 'Chris Buck', 'frozen3_poster.jpg', 'Poster'),
('Interstellar', 'Elsa and Anna embark on yet another adventure, this time to uncover hidden truths about their kingdom and discover forces beyond Elsas powers. Exploring a mysterious new land, they face enormous challenges, where once again, the strength of sisterhood helps them overcome all obstacles.', 5, '2014-11-07', '02:49:00', 'https://www.youtube.com/watch?v=zSWdZVtXT7E', 'Matthew McConaughey, Anne Hathaway', 'Christopher Nolan', 'interstellar.jpg', 'Active'),
('The Dark Knight', 'When Earth is threatened by a powerful alien force, heroes like Batman, Wonder Woman, and Superman must unite with other Justice League members once again. This time, their mission goes beyond saving the world—they fight to protect unity and peace among themselves and the planet.', 1, '2008-07-18', '02:32:00', 'https://www.youtube.com/watch?v=EXeTwQWrcwY', 'Christian Bale, Heath Ledger', 'Christopher Nolan', 'dark_knight.jpg', 'Active'),
('Toy Story 3', 'Woody, Buzz, and their friends return for a new adventure in the world of toys. They face new friends, challenging foes, and fresh discoveries, reminding them of the importance of loyalty, friendship, and embracing change in the journey of a lifetime.', 4, '2010-06-18', '01:43:00', 'https://www.youtube.com/watch?v=JcpWXaA2qeg', 'Tom Hanks, Tim Allen', 'Lee Unkrich', 'toy_story3.jpg', 'Active'),
('Titanic', 'Returning to Pandora, Jake Sully and Neytiri confront a new threat to their world as they uncover deeper secrets of Pandora’s ecosystems and spiritual connections. With greater stakes than ever, they must unite the clans to protect their home and preserve the planet’s balance for future generations.', 3, '1997-12-19', '03:14:00', 'https://www.youtube.com/watch?v=2e-eXJ6HgkQ', 'Leonardo DiCaprio, Kate Winslet', 'James Cameron', 'titanic.jpg', 'Active'),
('The Matrix', 'A hacker discovers a shocking truth about reality.', 5, '1999-03-31', '02:16:00', 'https://www.youtube.com/watch?v=m8e-FF8MsqU', 'Keanu Reeves, Laurence Fishburne', 'The Wachowskis', 'matrix.jpg', 'Active'),
('Forrest Gump', 'The life journey of a simple man with a big heart.', 3, '1994-07-06', '02:22:00', 'https://www.youtube.com/watch?v=bLvqoHBptjg', 'Tom Hanks, Robin Wright', 'Robert Zemeckis', 'forrest_gump.jpg', 'Active'),
('Avatar 3', 'Returning to Pandora, Jake Sully and Neytiri confront a new threat to their world as they uncover deeper secrets of Pandora’s ecosystems and spiritual connections. With greater stakes than ever, they must unite the clans to protect their home and preserve the planet’s balance for future generations.', 5, '2025-12-19', '02:56:00', 'https://www.youtube.com/watch?v=YXtWPVFk5TQ', 'Sam Worthington, Zoe Saldana', 'James Cameron', 'avatar3.jpg', 'Active'),
('Toy Story 5', 'Woody and friends face new adventures.', 4, '2026-06-15', '01:30:00', 'https://www.youtube.com/watch?v=F8N0-ViM254', 'Tom Hanks, Tim Allen', 'Pixar Studios', 'toy_story5.jpg', 'Active'),
('Justice League: Reborn', 'The heroes regroup for a new threat.', 1, '2026-11-10', '02:00:00', 'https://www.youtube.com/watch?v=sztA63kSY5o', 'Gal Gadot, Ben Affleck', 'Zack Snyder', 'justice_league_reborn.jpg', 'Active'),
('Frozen 3', 'Returning to Pandora, Jake Sully and Neytiri confront a new threat to their world as they uncover deeper secrets of Pandora’s ecosystems and spiritual connections. With greater stakes than ever, they must unite the clans to protect their home and preserve the planet’s balance for future generations.', 4, '2027-07-21', '01:45:00', 'https://www.youtube.com/watch?v=xJgAypHXCZo', 'Kristen Bell, Idina Menzel', 'Chris Buck', 'frozen3.jpg', 'Active'),
('Inception 2', 'A new mind-bending heist.', 5, '2028-05-18', '02:28:00', 'https://www.youtube.com/watch?v=JOmD4JJ98_8', 'Joseph Gordon-Levitt, Leonardo DiCaprio', 'Christopher Nolan', 'inception2.jpg', 'Active'),
('Spider-Man: No Way Home', 'Returning to Pandora, Jake Sully and Neytiri confront a new threat to their world as they uncover deeper secrets of Pandora’s ecosystems and spiritual connections. With greater stakes than ever, they must unite the clans to protect their home and preserve the planet’s balance for future generations.', 1, '2021-12-17', '02:28:00', 'https://www.youtube.com/watch?v=JfVOs4VSpmA', 'Tom Holland, Zendaya', 'Jon Watts', 'SpidermanNoWayHome_Poster.png', 'Poster'),
('Frozen 2', 'The adventure of Elsa and Anna.', 4, '2019-11-22', '01:43:00', 'https://www.youtube.com/watch?v=Zi4LMpSDccc', 'Kristen Bell, Idina Menzel', 'Chris Buck', 'Frozen2_Poster.jpg', 'Poster'),
('The Conjuring', 'Returning to Pandora, Jake Sully and Neytiri confront a new threat to their world as they uncover deeper secrets of Pandora’s ecosystems and spiritual connections. With greater stakes than ever, they must unite the clans to protect their home and preserve the planet’s balance for future generations.', 2, '2025-07-19', '01:52:00', 'https://www.youtube.com/watch?v=k10ETZ41q5o', 'Vera Farmiga, Patrick Wilson', 'James Wan', 'TheConjuring_Poster.webp', 'Poster');

/*[User]*/
INSERT INTO [User] (RoleID, Username, Password, Email, PhoneNumber, Dob, FullName, Status) VALUES 
(1, 'TungAdmin', '$2a$10$737LB5CDYczpbBp4Es/BRuxmTxzhU7ith0lHbWyd748eOKfIUzhEW', 'admin@example.com', '0972635172', '1990-01-01', N'Lê Văn Tùng', 'Active'),
(2, 'TuanHai', '$2a$10$737LB5CDYczpbBp4Es/BRuxmTxzhU7ith0lHbWyd748eOKfIUzhEW', 'TuanHai@example.com', '0971255322', '1995-05-20', N'Nguyễn Việt Tùng', 'Active'),
(3, 'TuanStaff', '$2a$10$737LB5CDYczpbBp4Es/BRuxmTxzhU7ith0lHbWyd748eOKfIUzhEW', 'TuanStaff@example.com', '0915262634', '1995-05-20', N'Trình Ngọc Tuân', 'Active'),
(4, 'ThanhCong', '$2a$10$737LB5CDYczpbBp4Es/BRuxmTxzhU7ith0lHbWyd748eOKfIUzhEW', 'ThanhCong@example.com', '0917257721', '1992-03-15', N'Hoàng Thành Công', 'Active'),
(2, 'LeNhat', '$2a$10$737LB5CDYczpbBp4Es/BRuxmTxzhU7ith0lHbWyd748eOKfIUzhEW', 'LeNhat@example.com', '01826371821', '1995-05-20', N'Lê Việt Nhật', 'Active'),
(2, 'KhachHang', '$2a$10$737LB5CDYczpbBp4Es/BRuxmTxzhU7ith0lHbWyd748eOKfIUzhEW', 'KhachHang@example.com', '09817264526', '1995-05-20', N'Lê Hàng Quang', 'Active'),
(2, 'HoangGia', '$2a$10$737LB5CDYczpbBp4Es/BRuxmTxzhU7ith0lHbWyd748eOKfIUzhEW', 'HoangGia@example.com', '082716331', '1995-05-20', N'Hoàng Tấn Sơn', 'Active'),
(2, 'SonHTX', '$2a$10$737LB5CDYczpbBp4Es/BRuxmTxzhU7ith0lHbWyd748eOKfIUzhEW', 'SonHTX@example.com', '0971632127', '1995-05-20', N'Hoàng Văn Sơn ', 'Active'),
(2, 'TuanTn', '$2a$10$737LB5CDYczpbBp4Es/BRuxmTxzhU7ith0lHbWyd748eOKfIUzhEW', 'TuanTn@example.com', '09172631263', '1995-05-20', N'Nguyễn Ngọc Tuân', 'Active'),
(2, 'CongLV', '$2a$10$737LB5CDYczpbBp4Es/BRuxmTxzhU7ith0lHbWyd748eOKfIUzhEW', 'CongLV@example.com', '012736123612', '1995-05-20', N'Lên Văn Công', 'Active'),
(2, 'HaiLT', '$2a$10$737LB5CDYczpbBp4Es/BRuxmTxzhU7ith0lHbWyd748eOKfIUzhEW', 'HaiLT@example.com', '09127361222', '1995-05-20', N'Trần Hai', 'Active'),
(2, 'QuangMinh', '$2a$10$737LB5CDYczpbBp4Es/BRuxmTxzhU7ith0lHbWyd748eOKfIUzhEW', 'QuangMinh@example.com', '0812731623', '1995-05-20', N'Quang Nguyễn', 'Active'),
(2, 'BinhNguyen', '$2a$10$737LB5CDYczpbBp4Es/BRuxmTxzhU7ith0lHbWyd748eOKfIUzhEW', 'BinhNguyen@example.com', '0812736123', '1995-05-20', N'Bình Nguyễn', 'Active');

/*Feedback*/
INSERT INTO Feedback (UserID, MovieID, Comments, CreateAt, Rate) VALUES
(2, 1, N'Phim rất tuyệt', '2024-09-11 10:00:00', 5),
(2, 3, N'Phim rất tệ', '2024-10-09 11:00:00', 2),
(3, 3, N'Phim rất tuyệt', '2024-10-11 11:00:00', 4),
(3, 4, N'Phim rất tệ', '2024-10-11 11:00:00', 1),
(4, 4, N'Phim rất tuyệt', '2024-09-11 11:00:00', 5),
(4, 5, N'Phim rất tệ', '2024-10-11 11:00:00', 3),
(5, 5, N'Phim rất tuyệt', '2024-10-11 11:00:00', 5),
(5, 6, N'Phim rất tệ', '2024-10-09 11:00:00', 3),
(6, 6, N'Phim rất tuyệt', '2024-10-11 11:00:00', 4),
(6, 7, N'Phim rất tệ', '2024-10-11 11:00:00', 4),
(7, 7, N'Phim rất tuyệt', '2024-09-11 11:00:00', 5),
(7, 8, N'Phim rất tệ', '2024-10-11 11:00:00', 2),
(8, 8, N'Phim rất tuyệt', '2024-10-11 11:00:00', 5),
(8, 9, N'Phim rất tệ', '2024-10-09 11:00:00', 2),
(9, 9, N'Phim rất tuyệt', '2024-10-11 11:00:00', 5),
(9, 1, N'Phim rất tệ', '2024-10-09 11:00:00', 3);

/*News*/
INSERT INTO News (Title, Content, Image, CreateAt, UpdateAt, CreateBy) VALUES
(N'Top phim Lee Seung Gi hay làm nổi bật sự nghiệp', N'Lee Seung Gi không chỉ được biết đến qua giọng hát trầm ấm mà còn là một diễn viên tài năng với nhiều vai diễn ấn tượng trên màn ảnh. Nếu bạn là người yêu mến chàng nghệ sĩ đa tài này, hãy cùng khám phá những bộ phim nổi bật trong sự nghiệp diễn xuất của anh, và cảm nhận thêm chiều sâu trong khả năng diễn xuất mà Lee Seung Gi mang lại qua từng vai diễn.', 'News3.png', '2024-10-10 12:00:00', '2024-10-11 09:00:00', 1),
(N'19 phim chiếu rạp 2025 đáng mong đợi dành cho fan cine', N'Chú gấu Paddington đáng yêu và nổi tiếng (lồng tiếng bởi Ben Whishaw) sẽ trở lại màn ảnh lớn với cuộc phiêu lưu hoàn toàn mới. Đây là phần thứ ba trong loạt phim đình đám, được đạo diễn bởi Dougal Wilson. Lần này, hành trình của Paddington đưa cậu đến sâu thẳm khu rừng nhiệt đới Amazon, sau khi một thế lực bí ẩn bất ngờ kéo cậu vào cuộc phiêu lưu kỳ lạ. Bộ phim dự kiến ra mắt tại Vương quốc Anh vào ngày 8 tháng 11 năm 2024 và sẽ chính thức được công chiếu rộng rãi tại Mỹ vào đầu tháng 1 năm 2025.', 'News1.png', '2024-10-10 12:00:00', '2024-10-11 09:00:00', 1),
(N'Squid Game 2 sẽ có gì và được phát sóng khi nào?', N'Squid Game 2 là phần tiếp theo đầy kịch tính của bộ phim Hàn Quốc đình đám Trò chơi con mực, tác phẩm đã gây bão toàn cầu sau khi ra mắt trên Netflix năm 2021. Câu chuyện xoay quanh những con người cùng quẫn, phải đối mặt với thử thách sinh tử trong một cuộc thi đầy tàn nhẫn, với hy vọng giành giải thưởng khổng lồ lên tới 45,6 tỷ won. 

Để chạm đến mục tiêu này, họ phải tham gia những trò chơi dân gian Hàn Quốc, nhưng giờ đây đã biến thành những thử thách đẫm máu. Luật chơi đơn giản nhưng tàn nhẫn: chiến thắng để tiếp tục, thất bại đồng nghĩa với cái chết. Phần đầu của bộ phim kết thúc, để lại nhiều bí ẩn chưa được giải đáp.

Gần đây, đoàn làm phim đã xác nhận sự trở lại của Squid Game với phần 2, dự kiến bấm máy vào tháng 7 năm nay, hứa hẹn một hành trình ly kỳ hơn bao giờ hết.', 'News3.png', '2024-10-10 12:00:00', '2024-10-11 09:00:00', 1),
(N'Giới thiệu về Bộ Huy hiệu Đánh giá Phim: Điểm càng cao, phim càng đỉnh!', N'Câu chuyện lấy bối cảnh thời kỳ mạt thế, nơi nguy hiểm luôn rình rập. Bộ phim xoay quanh Lâm Thất Dạ, một thiếu niên được chọn làm đại diện của thần minh. Thông qua sự nỗ lực và giác ngộ của bản thân, Lâm Thất Dạ dần trở thành người gác đêm cho đô thị, với nhiệm vụ bảo vệ quê hương và đất nước khỏi những hiểm nguy. Phim không chỉ mang đến những trận chiến kịch tính mà còn khắc họa hành trình trưởng thành của một người anh hùng giữa thời đại đầy biến động.', 'News2.png', '2024-10-10 12:00:00', '2024-10-11 09:00:00', 1),
(N'Danh sách phim hay Netflix tháng 8/2024', N'Sau 3 năm, Tiêu Viêm gặp lại Huân Nhi tại học viện Già Nam. Tại đây, hắn kết bạn với nhiều người, bao gồm Nạp Lan Hoa Viên, người sau này trở thành vợ hắn. Sau khi tốt nghiệp, Tiêu Viêm thành lập Bàn Môn và cùng bạn bè tu luyện. Để nâng cao thực lực và báo thù, Tiêu Viêm mạo hiểm vào Thiên Phần luyện Khí Tháp, thôn phệ Vẫn Lạc Tâm Viêm, và đột phá thành cường giả Đấu Khí Siêu Phẩm. Trên hành trình trở thành cao thủ và Luyện Dược Sư đỉnh cao, Tiêu Viêm được một tôn sư bí mật hướng dẫn.', 'News1.png', '2024-10-10 12:00:00', '2024-10-11 09:00:00', 1);

/*Discount*/
INSERT INTO Discount (Code, DiscountValue, StartDate, EndDate) VALUES
('DISCOUNT10', 10, '2024-10-01', '2024-10-31'),
('HALFOFF', 50, '2024-11-01', '2024-11-30');

INSERT INTO Cinema (Location, City, Name, Status) VALUES 
(N'Tầng 3 & 4 – TTTM AEON MALL HÀ ĐÔNG, P. Dương Nội, Q. Hà Đông', N'Hà Nội', N'CGV Aeon Hà Đông', 'Active'),
(N'Tầng 4, Trung Tâm Thương Mại Vincom Ocean Park, Huyện Gia Lâm', N'Hà Nội', N'CGV Vincom Ocean Park', 'Inactive'),
(N'Tầng 3, Trung Tâm Thương Mại Vincom Times City, P. Vĩnh Tuy, Q. Hai Bà Trưng', N'Hà Nội', N'CGV Vincom Times City', 'Active'),
(N'Tầng 6, TTTM Lotte Center, 54 Liễu Giai, Q. Ba Đình', N'Hà Nội', N'CGV Lotte Center Hà Nội', 'Active'),
(N'Tầng 5, TTTM Mipec Tower, 229 Tây Sơn, Q. Đống Đa', N'Hà Nội', N'CGV Mipec Tower', 'Inactive'),
(N'Tầng 5, TTTM Vincom Center Đồng Khởi, Q.1', N'Hồ Chí Minh', N'CGV Vincom Center Đồng Khởi', 'Active'),
(N'Tầng 3, TTTM Aeon Mall Tân Phú Celadon, Q. Tân Phú', N'Hồ Chí Minh', N'CGV Aeon Tân Phú', 'Inactive'),
(N'Tầng 4, TTTM Crescent Mall, Q.7', N'Hồ Chí Minh', N'CGV Crescent Mall', 'Active'),
(N'Tầng 6, TTTM Pearl Plaza, Q. Bình Thạnh', N'Hồ Chí Minh', N'CGV Pearl Plaza', 'Active'),
(N'Tầng 4, TTTM Vincom Landmark 81, Q. Bình Thạnh', N'Hồ Chí Minh', N'CGV Landmark 81', 'Inactive');
/*Room*/
/* Thêm phòng chiếu cho CinemaID từ 1 đến 22 */
INSERT INTO [dbo].[Room] ([Name], [CinemaID], [NumberOfRows]) VALUES
    -- CinemaID 1
    ('Starium', 1, 9),         -- Phòng chiếu "Starium" thuộc rạp "CGV Aeon Hà Đông"
    ('Aquarius', 1, 9), 
    ('Pluto', 1, 7),      -- Hành tinh Pluto (Sao Diêm Vương)
    ('Jupiter', 1, 7),    -- Hành tinh Jupiter (Sao Mộc)
    
    -- CinemaID 2
    ('Osiris', 2, 7),     -- Vị thần Osiris của Ai Cập
    ('Anubis', 2, 6),     -- Vị thần Anubis của Ai Cập
    ('Amun', 2, 6),       -- Vị thần Amun của Ai Cập
    ('Seth', 2, 6),       -- Vị thần Seth của Ai Cập

    -- CinemaID 3
    ('Xerath', 3, 7),
    ('Yone', 3, 6),
    ('Zac', 3, 9),
    ('Ziggs', 3, 7),

    -- CinemaID 4
    ('Lissandra', 4, 7),
    ('Lucian', 4, 6),
    ('Lulu', 4, 8),
    ('Lux', 4, 9),

    -- CinemaID 5
    ('Maokai', 5, 8),
    ('Mordekaiser', 5, 8),
    ('Nasus', 5, 6),
    ('Nautilus', 5, 8),

    -- CinemaID 6
    ('Ornn', 6, 7),
    ('Pantheon', 6, 6),
    ('Poppy', 6, 8),
    ('Pyke', 6, 9),

    -- CinemaID 7
    ('Renekton', 7, 7),
    ('Rengar', 7, 6),
    ('Riven', 7, 8),
    ('Rumble', 7, 9),

    -- CinemaID 8
    ('Samira', 8, 8),
    ('Sejuani', 8, 7),
    ('Senna', 8, 6),
    ('Seraphine', 8, 9),

    -- CinemaID 9
    ('Sivir', 9, 7),
    ('Skarner', 9, 8),
    ('Sona', 9, 6),
    ('Soraka', 9, 9),

    -- CinemaID 10
    ('Varus', 10, 6),
    ('Veigar', 10, 8),
    ('VelKoz', 10, 9),
    ('Vi', 10, 7);

	
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
    ('G', 22, 12, 'VIP'), ('H', 22, 12, 'VIP'), ('J', 22, 12, 'VIP'),

	('A', 23, 12, 'Regular'), ('B', 23, 12, 'Regular'), ('C', 23, 12, 'Regular'),
    ('D', 23, 12, 'VIP'), ('E', 23, 12, 'VIP'), ('F', 23, 12, 'VIP'),
    ('G', 23, 12, 'VIP'), ('H', 23, 12, 'VIP'), ('J', 23, 12, 'VIP'),

	('A', 24, 12, 'Regular'), ('B', 24, 12, 'Regular'), ('C', 24, 12, 'Regular'),
    ('D', 24, 12, 'VIP'), ('E', 24, 12, 'VIP'), ('F', 24, 12, 'VIP'),
    ('G', 24, 12, 'VIP'), ('H', 24, 12, 'VIP'), ('J', 24, 12, 'VIP'),

	('A', 25, 12, 'Regular'), ('B', 25, 12, 'Regular'), ('C', 25, 12, 'Regular'),
    ('D', 25, 12, 'VIP'), ('E', 25, 12, 'VIP'), ('F', 25, 12, 'VIP'),
    ('G', 25, 12, 'VIP'), ('H', 25, 12, 'VIP'), ('J', 25, 12, 'VIP');

	INSERT INTO [dbo].[Rows] ([RowName], [RoomID], [NumberOfColumns], [Type]) VALUES
    -- RoomID 26
    ('A', 26, 10, 'Regular'), ('B', 26, 11, 'Regular'), ('C', 26, 12, 'Regular'),
    ('D', 26, 11, 'VIP'), ('E', 26, 10, 'VIP'), ('F', 26, 12, 'VIP'),
    ('G', 26, 11, 'VIP'), ('H', 26, 10, 'VIP'), ('J', 26, 12, 'VIP'),

    -- RoomID 27
    ('A', 27, 12, 'Regular'), ('B', 27, 10, 'Regular'), ('C', 27, 11, 'Regular'),
    ('D', 27, 12, 'VIP'), ('E', 27, 11, 'VIP'), ('F', 27, 10, 'VIP'),
    ('G', 27, 12, 'VIP'), ('H', 27, 10, 'VIP'), ('J', 27, 11, 'VIP'),

    -- RoomID 28
    ('A', 28, 11, 'Regular'), ('B', 28, 10, 'Regular'), ('C', 28, 12, 'Regular'),
    ('D', 28, 10, 'VIP'), ('E', 28, 11, 'VIP'), ('F', 28, 12, 'VIP'),
    ('G', 28, 10, 'VIP'), ('H', 28, 12, 'VIP'), ('J', 28, 11, 'VIP'),

    -- RoomID 29
    ('A', 29, 10, 'Regular'), ('B', 29, 12, 'Regular'), ('C', 29, 11, 'Regular'),
    ('D', 29, 11, 'VIP'), ('E', 29, 10, 'VIP'), ('F', 29, 12, 'VIP'),
    ('G', 29, 12, 'VIP'), ('H', 29, 10, 'VIP'), ('J', 29, 11, 'VIP'),

    -- RoomID 30
    ('A', 30, 12, 'Regular'), ('B', 30, 11, 'Regular'), ('C', 30, 10, 'Regular'),
    ('D', 30, 10, 'VIP'), ('E', 30, 12, 'VIP'), ('F', 30, 11, 'VIP'),
    ('G', 30, 12, 'VIP'), ('H', 30, 10, 'VIP'), ('J', 30, 11, 'VIP'),

    -- RoomID 31
    ('A', 31, 11, 'Regular'), ('B', 31, 10, 'Regular'), ('C', 31, 12, 'Regular'),
    ('D', 31, 11, 'VIP'), ('E', 31, 10, 'VIP'), ('F', 31, 12, 'VIP'),
    ('G', 31, 11, 'VIP'), ('H', 31, 12, 'VIP'), ('J', 31, 10, 'VIP'),

    -- RoomID 32
    ('A', 32, 10, 'Regular'), ('B', 32, 12, 'Regular'), ('C', 32, 11, 'Regular'),
    ('D', 32, 12, 'VIP'), ('E', 32, 11, 'VIP'), ('F', 32, 10, 'VIP'),
    ('G', 32, 10, 'VIP'), ('H', 32, 12, 'VIP'), ('J', 32, 11, 'VIP'),

    -- RoomID 33
    ('A', 33, 12, 'Regular'), ('B', 33, 11, 'Regular'), ('C', 33, 10, 'Regular'),
    ('D', 33, 12, 'VIP'), ('E', 33, 10, 'VIP'), ('F', 33, 11, 'VIP'),
    ('G', 33, 12, 'VIP'), ('H', 33, 10, 'VIP'), ('J', 33, 11, 'VIP'),

    -- RoomID 34
    ('A', 34, 10, 'Regular'), ('B', 34, 12, 'Regular'), ('C', 34, 11, 'Regular'),
    ('D', 34, 11, 'VIP'), ('E', 34, 12, 'VIP'), ('F', 34, 10, 'VIP'),
    ('G', 34, 11, 'VIP'), ('H', 34, 12, 'VIP'), ('J', 34, 10, 'VIP'),

    -- RoomID 35
    ('A', 35, 11, 'Regular'), ('B', 35, 10, 'Regular'), ('C', 35, 12, 'Regular'),
    ('D', 35, 11, 'VIP'), ('E', 35, 12, 'VIP'), ('F', 35, 10, 'VIP'),
    ('G', 35, 11, 'VIP'), ('H', 35, 10, 'VIP'), ('J', 35, 12, 'VIP'),

    -- RoomID 36
    ('A', 36, 12, 'Regular'), ('B', 36, 10, 'Regular'), ('C', 36, 11, 'Regular'),
    ('D', 36, 10, 'VIP'), ('E', 36, 11, 'VIP'), ('F', 36, 12, 'VIP'),
    ('G', 36, 10, 'VIP'), ('H', 36, 12, 'VIP'), ('J', 36, 11, 'VIP'),

    -- RoomID 37
    ('A', 37, 10, 'Regular'), ('B', 37, 11, 'Regular'), ('C', 37, 12, 'Regular'),
    ('D', 37, 12, 'VIP'), ('E', 37, 10, 'VIP'), ('F', 37, 11, 'VIP'),
    ('G', 37, 12, 'VIP'), ('H', 37, 10, 'VIP'), ('J', 37, 11, 'VIP'),

    -- RoomID 38
    ('A', 38, 11, 'Regular'), ('B', 38, 12, 'Regular'), ('C', 38, 10, 'Regular'),
    ('D', 38, 11, 'VIP'), ('E', 38, 12, 'VIP'), ('F', 38, 10, 'VIP'),
    ('G', 38, 11, 'VIP'), ('H', 38, 10, 'VIP'), ('J', 38, 12, 'VIP'),

    -- RoomID 39
    ('A', 39, 12, 'Regular'), ('B', 39, 10, 'Regular'), ('C', 39, 11, 'Regular'),
    ('D', 39, 12, 'VIP'), ('E', 39, 11, 'VIP'), ('F', 39, 10, 'VIP'),
    ('G', 39, 12, 'VIP'), ('H', 39, 11, 'VIP'), ('J', 39, 10, 'VIP'),

    -- RoomID 40
    ('A', 40, 11, 'Regular'), ('B', 40, 10, 'Regular'), ('C', 40, 12, 'Regular'),
    ('D', 40, 12, 'VIP'), ('E', 40, 10, 'VIP'), ('F', 40, 11, 'VIP'),
    ('G', 40, 12, 'VIP'), ('H', 40, 10, 'VIP'), ('J', 40, 11, 'VIP');

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



/*Revenue*/
INSERT INTO Revenue (CinemaID, [Quarter], [Year], TotalRevenue) VALUES
(1, 3, 2024, 1000000),
(2, 3, 2024, 2000000);

/*FoodAndDrinks*/
INSERT INTO FoodAndDrinks (Name, Price, Quantity, [Image], Status) VALUES
('Tacos', 30000, 100, 'tacos.jpg', 'Active'),
('Coca Cola', 13000, 200, 'coke.jpg', 'Active'),
('Popcorn', 15000, 150, 'popcorn.jpg', 'Active'),
('French Fries', 25000, 80, 'fries.jpg', 'Active'),
('Cheese Nachos', 50000, 70, 'nachos.jpg', 'Active'),
('Classic Hotdog', 30000, 90, 'hotdog.jpg', 'Active');


/*Showtime*/
DECLARE @RoomCount INT = 40; -- Total number of rooms
DECLARE @MovieCount INT = (SELECT COUNT(ID) FROM Movies); -- Total number of movies in the Movies table
DECLARE @Days INT = 3; -- Number of different dates for showtimes
DECLARE @DateStart DATE = DATEADD(DAY, 1, GETDATE()); -- Starting date for the showtimes (tomorrow)
DECLARE @TimeGap TIME = '00:15:00'; -- 15 minutes gap between end time of one movie and start time of the next

DECLARE @MovieID INT;
DECLARE @RoomID INT;
DECLARE @ShowDate DATE;
DECLARE @StartTime TIME;
DECLARE @EndTime TIME;
DECLARE @Duration TIME;

DECLARE @RoomCounter INT = 1;

-- Loop through each movie
WHILE @RoomCounter <= @RoomCount
BEGIN
    SET @MovieID = @RoomCounter % @MovieCount + 1; -- Get a movie ID for each room, cycling through movies
    SET @RoomID = @RoomCounter;

    -- Loop through each day
    DECLARE @DayCounter INT = 0;
    WHILE @DayCounter < @Days
    BEGIN
        SET @ShowDate = DATEADD(DAY, @DayCounter, @DateStart);

        -- Define a start time for each movie on a given day
        SET @StartTime = '09:00:00';

        -- Fetch the duration of the current movie
        SET @Duration = (SELECT Duration FROM Movies WHERE ID = @MovieID);
        SET @EndTime = DATEADD(MINUTE, DATEPART(HOUR, @Duration) * 60 + DATEPART(MINUTE, @Duration), @StartTime);

        -- Check that end time is before the end of the day (say 10 PM limit for example)
        WHILE (CAST(@EndTime AS TIME) < '22:00:00')
        BEGIN
            -- Insert showtime entry
            INSERT INTO Showtime (MovieID, RoomID, StartTime, EndTime, [Date])
            VALUES (@MovieID, @RoomID, @StartTime, @EndTime, @ShowDate);

            -- Set up start time for the next movie in the same room
            SET @StartTime = DATEADD(MINUTE, DATEPART(HOUR, @Duration) * 60 + DATEPART(MINUTE, @Duration), @EndTime);
            SET @StartTime = DATEADD(MINUTE, 15, @EndTime); -- Add 15 minutes as a break time
            SET @EndTime = DATEADD(MINUTE, DATEPART(HOUR, @Duration) * 60 + DATEPART(MINUTE, @Duration), @StartTime);
        END;

        SET @DayCounter += 1;
    END;

    SET @RoomCounter += 1;
END;


/*Booking*/
-- TungNVHE170677 (UserID = 2)
INSERT INTO Booking (UserID, ShowtimeID, BookingDate, Status, TotalPrice, TicketCode) VALUES
(2, 1, '2024-11-05 09:00:00', 'Confirmed', 120000, 'TK001TUNG'), -- Xác nhận và sử dụng
(2, 2, '2024-11-06 13:00:00', 'Pending', 100000, 'TK002TUNG'),   -- Đặt nhưng chưa sử dụng
(2, 3, '2024-11-07 10:00:00', 'Expired', 150000, 'TK003TUNG'),  -- Vé đã hết hạn
(2, 4, '2024-11-08 17:30:00', 'Pending', 200000, 'TK004TUNG'), -- Vé đã bị hủy
(2, 5, '2024-11-09 20:30:00', 'Confirmed', 180000, 'TK005TUNG'); -- Xác nhận và sử dụng

-- NhatLVHE176909 (UserID = 5)
INSERT INTO Booking (UserID, ShowtimeID, BookingDate, Status, TotalPrice, TicketCode) VALUES
(5, 1, '2024-07-05 09:00:00', 'Confirmed', 120000, 'TK001NHAT'), -- Xác nhận và sử dụng
(5, 2, '2024-07-06 13:00:00', 'Pending', 100000, 'TK002NHAT'),   -- Đặt nhưng chưa sử dụng
(5, 3, '2024-07-07 10:00:00', 'Expired', 150000, 'TK003NHAT'),  -- Vé đã hết hạn
(5, 4, '2024-07-08 17:30:00', 'Canceled', 200000, 'TK004NHAT'), -- Vé đã bị hủy
(5, 5, '2024-07-09 20:30:00', 'Confirmed', 180000, 'TK005NHAT'); -- Xác nhận và sử dụng

INSERT INTO Booking (UserID, ShowtimeID, BookingDate, Status, TotalPrice, TicketCode) VALUES
(4, 1, '2024-09-05 09:00:00', 'Confirmed', 125000, 'IO192341'), 
(4, 2, '2024-09-06 13:00:00', 'Confirmed', 100000, 'IO192342'),  
(4, 3, '2024-09-07 10:00:00', 'Confirmed', 150000, 'IO192343'),  
(4, 4, '2024-09-08 17:30:00', 'Confirmed', 179000, 'IO192344'), 
(4, 5, '2024-09-09 20:30:00', 'Confirmed', 500000, 'IO192345');
INSERT INTO Booking (UserID, ShowtimeID, BookingDate, Status, TotalPrice, TicketCode) VALUES
(3, 6, '2024-05-05 09:00:00', 'Confirmed', 125000, 'AB182965'),
(3, 7, '2024-05-06 13:00:00', 'Confirmed', 100000, 'AC182965'),   
(3, 8, '2024-05-07 10:00:00', 'Confirmed', 150000, 'AD182965'),  
(3, 9, '2024-05-08 17:30:00', 'Confirmed', 179000, 'AE182965'), 
(3, 10, '2024-05-09 20:30:00', 'Confirmed', 500000, 'AF182965');
INSERT INTO Booking (UserID, ShowtimeID, BookingDate, Status, TotalPrice, TicketCode) VALUES
(1, 11, '2024-02-05 09:00:00', 'Confirmed', 125000, 'MN123012'), 
(1, 12, '2024-02-06 13:00:00', 'Confirmed', 100000, 'MS122093'),  
(1, 13, '2024-02-07 10:00:00', 'Confirmed', 150000, 'MM125095'),  
(1, 14, '2024-02-08 17:30:00', 'Confirmed', 179000, 'MQ129097'), 
(1, 15, '2024-02-09 20:30:00', 'Confirmed', 500000, 'MZ120098');


/*Payment*/
INSERT INTO Payment (BookingID, Amount, DiscountID) VALUES
(1, 120000, 1),  -- Thanh toán cho BookingID 1 với giảm giá 10%
(2, 100000, 1),  -- Thanh toán cho BookingID 2 không có giảm giá
(3, 150000, 2),  -- Thanh toán cho BookingID 3 với giảm giá 5%
(4, 200000, 2),  -- Thanh toán cho BookingID 4 không có giảm giá
(5, 180000, 1);  -- Thanh toán cho BookingID 5 với giảm giá 15%

/*BookingSeatDetails*/
INSERT INTO BookingSeatsDetail (SeatID, Price, BookingID)
VALUES
(1, 120000, 1),  -- A1 (Regular)
(2, 120000, 1),  -- A2 (Regular)
(16, 125000, 1), -- D1 (VIP)

-- Chèn dữ liệu cho BookingID 2 (ghế B1, B2, E1)
(17, 120000, 2),  -- B1 (Regular)
(18, 120000, 2),  -- B2 (Regular)
(31, 125000, 2),  -- E1 (VIP)
(15, 125000, 25),  
(16, 125000, 24),  
(20, 125000, 23), 
(21, 150000, 22),  
(22, 150000, 21),  
(30, 150000, 20),
(35, 125000, 19),  
(32, 125000, 18),  
(33, 125000, 17), 
(34, 150000, 25);

INSERT INTO BookingItem (FoodAndDrinksID, Quantity, Price, BookingID)
VALUES
(5, 2, 150000, 24),  
(6, 3, 190000, 23),
(1, 2, 210000, 17),  
(5, 3, 145000, 20),  
(4, 2, 100000, 25),  
(4, 3, 70000, 21); 

/*BookingItem*/
-- Chèn dữ liệu cho BookingID 1 (2 phần Tacos và 3 phần Popcorn)
INSERT INTO BookingItem (FoodAndDrinksID, Quantity, Price, BookingID)
VALUES
(1, 2, 30000, 1),  -- Tacos (2 phần)
(3, 3, 15000, 1);  -- Popcorn (3 phần)

-- Chèn dữ liệu cho BookingID 2 (1 phần Coca Cola và 2 phần French Fries)
INSERT INTO BookingItem (FoodAndDrinksID, Quantity, Price, BookingID)
VALUES
(2, 1, 13000, 2),  -- Coca Cola (1 phần)
(4, 2, 25000, 2);  -- French Fries (2 phần)


INSERT INTO Payment (BookingID, Amount, DiscountID) VALUES
(24, 350000, 1),  
(23, 120000, 2), 
(21, 321000, 2),  
(20, 550000, 1), 
(16, 430000, 2); 
