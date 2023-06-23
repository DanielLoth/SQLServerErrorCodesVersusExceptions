create view Number
as
with
    L1 as (select 1 as A union all select 1),
    L2 as (select 1 as A from L1 a cross join L1 b),
    L3 as (select 1 as A from L2 a cross join L2 b),
    L4 as (select 1 as A from L3 a cross join L3 b),
    L5 as (select 1 as A from L4 a cross join L4 b),
    Numbers (Number) as (select row_number() over (order by (select 1)) - 1 from L5)
select Number
from Numbers;

go
