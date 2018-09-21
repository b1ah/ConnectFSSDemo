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
