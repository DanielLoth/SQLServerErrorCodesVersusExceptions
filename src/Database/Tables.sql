create table IntWithFiller (
	Id int primary key clustered,
	Filler char(8000) not null default ''
);

go
