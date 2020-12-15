create table mon_camp (
	campno number(2),
	nom varchar2(20) NOT NULL,
	nbtente number(3),
	nblegio number(4),
	constraint pk_mon_camp primary key (campno)
);

create table ma_bataille (
	batno number(3),
	nom varchar2(20),
	vilno number(2) NOT NULL,
	campno number(2) NOT NULL,
	datebat date,
	duree number(3),
	constraint pk_ma_bataille primary key (batno),
	constraint fk_bataille_vilno foreign key (vilno) references village,
	constraint fk_bataille_campno foreign key (campno) references mon_camp
);

insert into mon_camp values (5, 'Nanciorum', 70, 400);
insert into ma_bataille values (12, 'Vosgia', 14, 5, to_date('02/09/0090', 'dd/mm/yyyy'), 20);
insert into mon_camp select * from agnes_braud.camp;
insert into ma_bataille select * from agnes_braud.bataille;