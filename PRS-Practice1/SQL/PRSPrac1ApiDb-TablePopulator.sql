USE PRSPrac1ApiDb;

INSERT INTO Users(Username, Password, Fristname, Lastname, Phone, Email, IsReviewer, IsAdmin)
VALUES('JWitte', 'password', 'Jake', 'Witte', '1-451-7777', 'jw@spaceadmin.com', 'true', 'true'),
('DMatveev', 'password', 'Denis', 'Matveev', '7-111-1111', 'dm@SoyuzMS-21.com', 'false', 'false'),
('SKorsakov', 'password', 'Sergey', 'Korsakov', '7-211-1111', 'sk@SoyuzMS-21.com', 'false', 'false'),
('MAllen', 'password', 'Marty', 'Allen', '1-111-1111', 'ma@BlueOriginNS-20.com', 'false', 'false'),
('MHagle', 'password', 'Marc', 'Hagle', '1-211-1111', 'mh@BlueOriginNS-20.com', 'false', 'false'),
('SHagle', 'password', 'Sharon', 'Hagle', '1-311-1111', 'sh@BlueOriginNS-20.com', 'false', 'false'),
('JKitchen', 'password', 'Jim', 'Kitchen', '1-411-1111', 'jk@BlueOriginNS-20.com', 'false', 'false'),
('GNield', 'password', 'George', 'Nield', '1-511-1111', 'gn@BlueOriginNS-20.com', 'false', 'false'),
('GLai', 'password', 'Gary', 'Lai', '1-611-1111', 'gl@BlueOriginNS-20.com', 'false', 'false'),
('BNelson', 'password', 'Bill', 'Nelson', '1-218-5555', 'bn@spaceadmin.com', 'true', 'false');

--SELECT * FROM Users;

INSERT Vendors (Code, Name, Address, City, State, Zip, Phone, Email)
VALUES ('RC', 'Roscosmos', '42 Schepkina Street', 'Moscow', 'MK', '10799', '7-4956889063', 'roscosmos@blueorigin.com'),
('BO', 'Blue Origin', '21218 76th Avenue South', 'Kent', 'WA', '98032', '1-2534379300', 'orders@blueorigin.com'),
('NA', 'NASA', '300 E Street SW', 'Washington', 'DC', '20546', '1-2023580001', 'orders@nasa.com');

--SELECT * FROM Vendors;

INSERT Products (PartNbr, Name, Price, Unit, PhotoPath, VendorId)
VALUES('R-B001', 'Nickel-Cadmium Battery', '500.00', 'Electic Battery', NULL, 1),
('R-E001', 'Vibration-Iso Treadmill', '700.00', 'Tredmill', NULL, 1),
('B-C001', 'Polaroid Camera', '20.00', 'Camera', NULL, 1),
('B-F001', 'Blue Feather', '1.00', 'Feather', NULL, 1),
('N-A001', 'N-O System Tank', '100.00', 'Air Supply', NULL, 3),
('N-F001', 'Astro-Food', '10.00', 'Basic Food Supply', NULL, 3);

--SELECT * FROM Products;

INSERT Requests (Description, Justification, RejectionReason, DeliveryMode, Status, Total, UserId)
VALUES
('Air food power', 'Required for Soyuz MS21 mission', NULL , 'Delivery', 'NEW', 620, 2),
('Treadmill of ISS', 'Exercise required aboard ISS', NULL, 'Delivery' , 'NEW', 700, 3),
('More food for ISS', 'Food supply is running low', NULL, 'Delivery' , 'NEW', 50, 2),
('Camera and Zero-G indicator', 'No pictures it didn''t happen and need to know when in space', NULL, 'Pickup' , 'NEW', 21, 4),
('Cameras for ground support', 'No pictures it didn''t happen', NULL, 'Pickup' , 'NEW', 200, 1),
('Battery for NS20 flight', 'Need to power video iPhone', NULL , 'Pickup' , 'NEW', 500, 9);
--SELECT * FROM Requests;

INSERT RequestLines (Quantity, RequestId, ProductId)
VALUES
(2,1,6),
(1,1,5),
(1,1,1),
(1,2,2),
(5,3,6),
(1,4,3),
(1,4,4),
(10,5,3),
(1,6,1)


--SELECT * FROM RequestLines;