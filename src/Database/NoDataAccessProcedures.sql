create procedure dbo.NoDataAccess_TryCatchThrow_50Percent
as

set nocount, xact_abort on;

begin try
	declare @Value int = cast((rand()*100) as int) % 2;
	select 1 / @Value;
end try
begin catch
	throw;
end catch

return 0;

go


create procedure dbo.NoDataAccess_TryCatchReturnError_50Percent
as

set nocount, xact_abort on;

begin try
	declare @Value int = cast((rand()*100) as int) % 2;
	select 1 / @Value;
end try
begin catch
	return 1;
end catch

return 0;

go


create procedure dbo.NoDataAccess_CheckReturnError_50Percent
as

set nocount, xact_abort on;

declare @Value int = cast((rand()*100) as int) % 2;

if @Value = 0 return 1;

select 1 / @Value;

return 0;

go
