create procedure dbo.TryCatchThrow
	@ShouldFail bit
as

set nocount, xact_abort on;

create table #T1 (Id uniqueidentifier primary key);

declare @Id uniqueidentifier = cast(0x0 as uniqueidentifier);
insert into #T1 (Id) values (@Id);

select @Id = newid() where @ShouldFail = 0;

begin try
	begin transaction;
	insert into #T1 (Id) values (@Id);
	commit;
end try
begin catch
	if @@trancount != 0 rollback;
	throw; /* Re-throw */
end catch

return 0;

go

create procedure dbo.TryCatchReturn
	@ShouldFail bit
as

set nocount, xact_abort on;

create table #T1 (Id uniqueidentifier primary key);

declare @Id uniqueidentifier = cast(0x0 as uniqueidentifier);
insert into #T1 (Id) values (@Id);

select @Id = newid() where @ShouldFail = 0;

begin try
	begin transaction;
	insert into #T1 (Id) values (@Id);
	commit;
end try
begin catch
	if @@trancount != 0 rollback;
	return 1; /* Return error */
end catch

return 0;

go

create procedure dbo.TryCheckReturn
	@ShouldFail bit
as

set nocount, xact_abort on;

create table #T1 (Id uniqueidentifier primary key);

declare @Id uniqueidentifier = cast(0x0 as uniqueidentifier);
insert into #T1 (Id) values (@Id);

select @Id = newid() where @ShouldFail = 0;

begin try
	if not exists (select 1 from #T1 where Id = @Id)
	begin
		begin transaction;
		insert into #T1 (Id) values (@Id);
		commit;
	end
end try
begin catch
	if @@trancount != 0 rollback;
	throw; /* Re-throw */
end catch

return 0;

go

create procedure dbo.CheckReturn
	@ShouldFail bit
as

set nocount, xact_abort on;

create table #T1 (Id uniqueidentifier primary key);

declare @Id uniqueidentifier = cast(0x0 as uniqueidentifier);
insert into #T1 (Id) values (@Id);

select @Id = newid() where @ShouldFail = 0;

if not exists (select 1 from #T1 where Id = @Id)
begin
	begin transaction;
	insert into #T1 (Id) values (@Id);
	commit;
end

return 0;

go
