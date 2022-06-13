SQL Test

1-
select p.idstatus, s.dsstatus
from tb_processo p
inner join tb_status s on (s.idstatus = p.idstatus)

2-
select max(a.dtandamento)
from tb_processo p
inner join tb_andamento a on (a.idprocesso = p.idprocesso)
where a.dtandamento between "01/01/2013" and "31/12/2013"

3-
select p.dtencerramento, count(p.dtencerramento)
from tb_processo p
group by p.dtencerramento
having count(p.dtencerramento) > 5

4-
select right(replicate('0',12 - Len(p.nroprocesso)) + convert(VARCHAR,p.nroprocesso),12) as nroprocesso
from tb_processo p
