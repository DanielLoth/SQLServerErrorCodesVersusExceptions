create procedure dbo.InsertDummyData
as

set nocount, xact_abort on;

truncate table IntWithFiller;

insert into IntWithFiller (Id)
select top 100 Number from Number;

go
