USE [ConnectFSS]
GO

INSERT INTO [dbo].[User]
           ([username], [password], [first_name], [last_name], [is_admin])
     VALUES
		('admin', 'UYFpyJb2xVlHM7kR21Zt7w==', 'Supreme', 'Commander', 1)	/*password 'admin'*/
GO

INSERT INTO [dbo].[User]
           ([username], [password], [first_name], [last_name])
     VALUES
		('jdoe', 'qUvJMLQmI/uVsPpBWWdaZg==', 'John', 'Doe'),				/*password 'test'*/
		('AbeTheBabe', 'iIMOYU/KlBaGwUtWHXBPcQ==', 'Abraham', 'Lincoln'),	/*password '1234'*/
		('doorz', 'qUvJMLQmI/uVsPpBWWdaZg==', 'Dorothy', 'Ozz')				/*password 'test'*/
GO

INSERT INTO [dbo].[AccountType]
           ([name])
     VALUES
           ('Checking'),
		   ('Savings'),
		   ('Money Market'),
		   ('CD'),
		   ('IRA'),
		   ('Brokerage')
GO

INSERT INTO [dbo].[Account]
           ([userId], [typeId], [name], [balance])
     VALUES
           (1, 1, 'Test account number one.', 999.99),
		   (2, 1, 'John''s first account', 123.45),
		   (3, 2, 'Saving for a boat.', 1785.29),
		   (1, 2, 'The ultimate savings account', 98765.43),
		   (4, 5, 'Gonna retire someday', 41567.23),
		   (4, 1, 'For day to day living', 2145.65)
GO