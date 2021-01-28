SET IDENTITY_INSERT [dbo].[Airline] ON
INSERT INTO [dbo].[Airline] ([AirlineID], [AirlineName], [DepatureDate]) VALUES (1, N'China', N'2021-01-29 00:00:00')
INSERT INTO [dbo].[Airline] ([AirlineID], [AirlineName], [DepatureDate]) VALUES (2, N'New zealand', N'2021-02-05 00:00:00')
INSERT INTO [dbo].[Airline] ([AirlineID], [AirlineName], [DepatureDate]) VALUES (3, N'Singapore', N'2021-01-28 00:00:00')
INSERT INTO [dbo].[Airline] ([AirlineID], [AirlineName], [DepatureDate]) VALUES (4, N'United', N'2021-02-05 00:00:00')
INSERT INTO [dbo].[Airline] ([AirlineID], [AirlineName], [DepatureDate]) VALUES (5, N'Austrailan', N'2021-02-07 00:00:00')
SET IDENTITY_INSERT [dbo].[Airline] OFF
SET IDENTITY_INSERT [dbo].[StaffMember] ON
INSERT INTO [dbo].[StaffMember] ([StaffMemberID], [StaffMemberName], [ContactNumber], [EmailId], [AirlineID]) VALUES (3, N'Aisa', 226567888, N'Aisa@gmail.com', 1)
INSERT INTO [dbo].[StaffMember] ([StaffMemberID], [StaffMemberName], [ContactNumber], [EmailId], [AirlineID]) VALUES (4, N'Bit', 22787894, N'Bit@gmail.com', 2)
INSERT INTO [dbo].[StaffMember] ([StaffMemberID], [StaffMemberName], [ContactNumber], [EmailId], [AirlineID]) VALUES (5, N'Minu', 22687999, N'Minu@gmail.com', 3)
INSERT INTO [dbo].[StaffMember] ([StaffMemberID], [StaffMemberName], [ContactNumber], [EmailId], [AirlineID]) VALUES (6, N'Sit', 22568789, N'Sit@gmail.com', 4)
INSERT INTO [dbo].[StaffMember] ([StaffMemberID], [StaffMemberName], [ContactNumber], [EmailId], [AirlineID]) VALUES (7, N'Mem', 22677889, N'Mem@gmail.com', 5)
SET IDENTITY_INSERT [dbo].[StaffMember] OFF
SET IDENTITY_INSERT [dbo].[Traveller] ON
INSERT INTO [dbo].[Traveller] ([TravellerID], [TravellerName], [ContactNumber], [StaffMemberID]) VALUES (6, N'Ash', 22657687, 3)
INSERT INTO [dbo].[Traveller] ([TravellerID], [TravellerName], [ContactNumber], [StaffMemberID]) VALUES (7, N'Benny', 22566789, 4)
INSERT INTO [dbo].[Traveller] ([TravellerID], [TravellerName], [ContactNumber], [StaffMemberID]) VALUES (8, N'Tin', 22657689, 5)
INSERT INTO [dbo].[Traveller] ([TravellerID], [TravellerName], [ContactNumber], [StaffMemberID]) VALUES (9, N'Den', 22657887, 3)
INSERT INTO [dbo].[Traveller] ([TravellerID], [TravellerName], [ContactNumber], [StaffMemberID]) VALUES (10, N'Antt', 22657699, 4)
SET IDENTITY_INSERT [dbo].[Traveller] OFF
SET IDENTITY_INSERT [dbo].[TicketPrice] ON
INSERT INTO [dbo].[TicketPrice] ([TicketID], [TicketName], [Price], [AirlineID]) VALUES (2, N'First Class', 120, 1)
INSERT INTO [dbo].[TicketPrice] ([TicketID], [TicketName], [Price], [AirlineID]) VALUES (3, N'Second Class', 1100, 2)
INSERT INTO [dbo].[TicketPrice] ([TicketID], [TicketName], [Price], [AirlineID]) VALUES (4, N'Business Class', 1700, 3)
INSERT INTO [dbo].[TicketPrice] ([TicketID], [TicketName], [Price], [AirlineID]) VALUES (5, N'First Class', 1100, 4)
INSERT INTO [dbo].[TicketPrice] ([TicketID], [TicketName], [Price], [AirlineID]) VALUES (6, N'Business Class', 1700, 5)
SET IDENTITY_INSERT [dbo].[TicketPrice] OFF
