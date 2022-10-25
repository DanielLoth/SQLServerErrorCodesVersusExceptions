create procedure dbo.Insert_TryCatchThrow_50Percent
as

set nocount, xact_abort on;

begin try
	declare @Value int = rand()*200;

	begin transaction;
	insert into IntWithFiller (Id) values (@Value);
	rollback;
end try
begin catch
	if @@trancount != 0 rollback;
	throw;
end catch

return 0;

go


create procedure dbo.Insert_TryCatchReturn_50Percent
as

set nocount, xact_abort on;

begin try
	declare @Value int = rand()*200;

	begin transaction;
	insert into IntWithFiller (Id) values (@Value);
	rollback;
end try
begin catch
	if @@trancount != 0 rollback;
	return 1;
end catch

return 0;

go


create procedure dbo.Insert_CheckReturn_50Percent
as

set nocount, xact_abort on;

declare @Value int = rand()*200;

if not exists (select 1 from IntWithFiller where Id = @Value)
begin
	begin transaction;
	insert into IntWithFiller (Id) values (@Value);
	rollback;
end

return 0;

go



create procedure dbo.Insert_TryCatchThrow_100Percent
as

set nocount, xact_abort on;

begin try
	begin transaction;
	insert into IntWithFiller (Id) values (1);
	rollback;
end try
begin catch
	if @@trancount != 0 rollback;
	throw;
end catch

return 0;

go


create procedure dbo.Insert_TryCatchReturn_100Percent
as

set nocount, xact_abort on;

begin try
	begin transaction;
	insert into IntWithFiller (Id) values (1);
	rollback;
end try
begin catch
	if @@trancount != 0 rollback;
	return 1;
end catch

return 0;

go


create procedure dbo.Insert_CheckReturn_100Percent
as

set nocount, xact_abort on;

if not exists (select 1 from IntWithFiller where Id = 1)
begin
	begin transaction;
	insert into IntWithFiller (Id) values (1);
	rollback;
end

return 0;

go


create procedure dbo.Insert_TryCheckReturn_100Percent
as

set nocount, xact_abort on;

begin try
	if not exists (select 1 from IntWithFiller where Id = 1)
	begin
		begin transaction;
		insert into IntWithFiller (Id) values (1);
		rollback;
	end
end try
begin catch
	if @@trancount != 0 rollback;
	return 1;
end catch

return 0;

go
