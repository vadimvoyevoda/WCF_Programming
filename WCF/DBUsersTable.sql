Drop  DATABASE USERS_3V

CREATE DATABASE USERS_3V
GO

USE USERS_3V
GO

CREATE TABLE MyUsers
(
	idUser int identity primary key
	, UName nvarchar(20) not null
	, ULastName nvarchar(20) not null
	, ULogin nvarchar(20) not null
	, Pass nvarchar(20) not null
	, Salt nvarchar(20) not null
	, Token nvarchar(16)
	, ExpDate datetime
)

insert into MyUsers values
  ('vadim', 'voyevoda', 'vvv', '11111', null, null)
, ('serg', 'dyadenchuk', 'ddd', '22222', null, null)
, ('alex', 'trim',       'trim', '33333', null, null)
, ('frank', 'sinatra',    'franc', '44444', null, null)

select *
from MyUsers