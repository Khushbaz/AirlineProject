SET IDENTITY_INSERT [dbo].[TicketPrice] ON
INSERT INTO [dbo].[TicketPrice] ([TicketID], [TicketName], [Price], [AirlineID]) VALUES (2, N'First Class', 120, 1)
INSERT INTO [dbo].[TicketPrice] ([TicketID], [TicketName], [Price], [AirlineID]) VALUES (3, N'Second Class', 1100, 2)
INSERT INTO [dbo].[TicketPrice] ([TicketID], [TicketName], [Price], [AirlineID]) VALUES (4, N'Business Class', 1700, 3)
INSERT INTO [dbo].[TicketPrice] ([TicketID], [TicketName], [Price], [AirlineID]) VALUES (5, N'First Class', 1100, 4)
INSERT INTO [dbo].[TicketPrice] ([TicketID], [TicketName], [Price], [AirlineID]) VALUES (6, N'Business Class', 1700, 5)
SET IDENTITY_INSERT [dbo].[TicketPrice] OFF
