/*Criar query de criação das tabelas do diagrama DER*/
CREATE DATABASE db_projetoCSharp
USE db_projetoCSharp
CREATE TABLE tbl_Address(
	id_address INT IDENTITY(1,1) PRIMARY KEY,
	street VARCHAR(100),
	city VARCHAR(58),
	state VARCHAR(50),
	country VARCHAR(50),
	posteCode VARCHAR(50)
);
CREATE TABLE tbl_Person (
	 id_person INT IDENTITY(1,1) PRIMARY KEY,
	 name VARCHAR(40) NOT NULL,
	 age VARCHAR(3) NOT NULL,
	 document VARCHAR(20) NOT NULL,
	 email VARCHAR(256) NOT NULL,
	 phone VARCHAR(20) NOT NULL,
	 login VARCHAR(50)NOT NULL,
	 fk_address INT NOT NULL
	 CONSTRAINT fk_id_address FOREIGN KEY (fk_address) REFERENCES tbl_Address (id_address)
);

CREATE TABLE tbl_Owner(
	id_owner INT PRIMARY KEY,
	CONSTRAINT fk_owner_person FOREIGN KEY (id_owner) REFERENCES tbl_Person (id_person)
);
CREATE TABLE tbl_Client(
	id_client INT PRIMARY KEY,
	CONSTRAINT fk_client_person FOREIGN KEY (id_client) REFERENCES tbl_Person (id_person)
);

CREATE TABLE tbl_Product(
	id_product int IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(50),
	unit_Price FLOAT,
	barCode VARCHAR(50),
);

CREATE TABLE tbl_Store(
	id_store int IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(50),
	CNPJ VARCHAR(20),
	fk_owner INT NOT NULL
	CONSTRAINT fk_id_owner FOREIGN KEY (fk_owner) REFERENCES tbl_Owner (id_owner)
);

CREATE TABLE tbl_Stocks(
	id_stocks INT IDENTITY(1,1) PRIMARY KEY,
	quantity INT NOT NULL,
	fk_product int NOT NULL,
	fk_store int NOT NULL
	CONSTRAINT fk_id_product FOREIGN KEY (fk_product) REFERENCES tbl_Product (id_product),
	CONSTRAINT fk_id_store FOREIGN KEY (fk_store) REFERENCES tbl_Store (id_store)
);

CREATE TABLE tbl_Wishlist(
	id_wishlist INT IDENTITY(1,1) PRIMARY KEY,
	fk_client INT NOT NULL,
	CONSTRAINT fk_id_client FOREIGN KEY (fk_client) REFERENCES tbl_Client (id_client)
);

CREATE TABLE tbl_wishlistProduct(
	id_wishlistProduct INT IDENTITY(1,1) PRIMARY KEY,
	fk_wishlist INT NOT NULL,
	fk_product INT NOT NULL
	CONSTRAINT fk_id_wishlist FOREIGN KEY (fk_wishlist) REFERENCES tbl_Wishlist (id_wishlist),
	CONSTRAINT fkk_id_product FOREIGN KEY(fk_product) REFERENCES tbl_Product (id_product)
);

CREATE TABLE tbl_Purchase(
	id_purchase INT IDENTITY(1,1) PRIMARY KEY,
	payment VARCHAR(50),
	datePurchase DATE,
	numberConfirmation VARCHAR(50),
	numberNf VARCHAR(50),
	fk_store INT NOT NULL,
	fk_client INT NOT NULL
	CONSTRAINT fkk_id_store FOREIGN KEY (fk_store) REFERENCES tbl_Store (id_store),
	CONSTRAINT fkk_id_client FOREIGN KEY (fk_client) REFERENCES tbl_Client (id_client)
);

CREATE TABLE tbl_purchaseProduct(
	id_purchaseProduct INT IDENTITY(1,1) PRIMARY KEY,
	fk_purchase INT NOT NULL,
	fk_product INT NOT NULL
	CONSTRAINT fk_id_purchase FOREIGN KEY (fk_purchase) REFERENCES tbl_Purchase (id_purchase),
	CONSTRAINT fkkk_id_product FOREIGN KEY (fk_product) REFERENCES tbl_PRoduct (id_product)
);




/*Inserir endereços diferentes apra todos os clientes e donos de lojas*/
INSERT INTO tbl_Address (street,city,state,country,posteCode)
VALUES
  ('P.O. Box 143, 2405 Duis Street','Shimla','Vlaams-Brabant','Algeria','6508'),
  ('Ap #759-4447 Nunc St.','San Francisco','Bauchi','Christmas Island','855682'),
  ('P.O. Box 752, 2698 Tempor Ave','Turriff','North Island','Vanuatu','0274'),
  ('Ap #644-1118 Non, Avenue','Vadsø','Northumberland','Swaziland','F4 2YP'),
  ('566-8264 Sed, Road','Musina','Mazowieckie','Nicaragua','61-445'),
  ('P.O. Box 295, 4469 A, St.','Los Lagos','Los Ríos','Pitcairn Islands','765853'),
  ('2060 Ipsum. Road','Picton','South Island','Cocos (Keeling) Islands','0537'),
  ('217-9137 Sodales Road','Linköping','Östergötlands län','Gambia','06047'),
  ('519-9057 Odio. Avenue','Kessel','Antwerpen','Christmas Island','6715'),
  ('P.O. Box 511, 255 Pharetra Street','Zwettl-Niederösterreich','Lower Austria','Latvia','4612');


INSERT INTO tbl_Person (name,age,document,email,phone,login,fk_address)
VALUES
  ('Shea Mccoy','15','374.608.340-07','sheamccoy7377@google.com','(53) 45954-6474','Xena',1),
  ('Quon Ayers','08','439.044.081-11','quonayers7368@hotmail.com','(14) 07653-1239','Arsenio',2),
  ('Logan Barrera','61','376.894.637-17','loganbarrera@hotmail.com','(24) 87451-2019','Hyatt',3),
  ('Kessie Ware','25','183.036.866-61','kessieware@google.com','(73) 84153-7896','India',4),
  ('Jameson Crawford','86','558.521.444-80','jamesoncrawford@google.com','(11) 88288-5007','Jolie',5),
  ('Britanney Zimmerman','75','481.669.397-85','britanneyzimmerman2947@google.com','(22) 72598-7295','Joseph',6),
  ('Shaine Hoover','06','178.493.696-79','shainehoover@google.com','(49) 13825-5210','Suki',7),
  ('Xanthus Mcfarland','35','621.248.395-33','xanthusmcfarland@google.com','(75) 94936-2421','Kiayada',8),
  ('Quin Fulton','71','828.379.156-30','quinfulton@hotmail.com','(14) 27795-6880','Gage',9),
  ('Eric Dillon','14','124.284.146-36','ericdillon@google.com','(62) 90474-1337','Fritz',10);

INSERT INTO tbl_Owner VALUES (1);
INSERT INTO tbl_Owner VALUES (2);
INSERT INTO tbl_Owner VALUES (3);
INSERT INTO tbl_Owner VALUES (4);
INSERT INTO tbl_Owner VALUES (5);
/*Inserir pelo menos 5 clientes na base de dados*/
INSERT INTO tbl_Client VALUES (6);
INSERT INTO tbl_Client VALUES (7);
INSERT INTO tbl_Client VALUES (8);
INSERT INTO tbl_Client VALUES (9);
INSERT INTO tbl_Client VALUES (10);

/*Inserir pelo menos 5 lojas na base de dados*/
INSERT INTO tbl_Store (name,CNPJ,fk_owner)
VALUES
  ('Aliquam PC','48.228.859/0001-28',1),
  ('Sit Corporation','44.716.523/0001-72',2),
  ('Neque Vitae Limited','23.358.595/0001-49',3),
  ('Magna Ltd','87.428.378/0001-48',4),
  ('Nullam Vitae Company','75.357.535/0001-46',5);

INSERT INTO tbl_Product (name,unit_Price,barCode)
VALUES
  ('bubble',127,'6506362767888'),
  ('flower',89,'6683753872735'),
  ('office desk.',135,'7303373674875'),
  ('tent',116,'1749553804723'),
  ('octapus plushie',31,'2422378568219'),
  ('young dino toy',107,'9366393741119'),
  ('brick',143,'4975299388572'),
  ('twenty plates',147,'0546034430246'),
  ('lever',63,'3489449421134'),
  ('black phone case',45,'4192241121192'),
  ('acacia wood,',102,'8535238048248'),
  ('congratulations sign',155,'7849091317626'),
  ('spider man web',81,'1923245531802'),
  ('ikea table',151,'5169183420845'),
  ('witch hat',93,'4007513974790'),
  ('lamp',34,'1199640258165'),
  ('hand sanitizer',131,'9762354092472'),
  ('anti stress',139,'3630677410501'),
  ('lie detector,',63,'2025149415977'),
  ('nestle milk',135,'1156155854924'),
  ('astros puzzle',143,'6498059335658'),
  ('barry allen toy',157,'3148931693411'),
  ('litio battery',7,'9120464472663'),
  ('astronaut toy',147,'3906615196829'),
  ('bee honey',99,'4765776405735');

/*Inserir uma wishlist para cada cliente com pelo menos 5 produtos em cada uma delas*/
INSERT INTO tbl_WishList (fk_client)
VALUES
  (6),
  (6),
  (6),
  (6),
  (6),
  (7),
  (7),
  (7),
  (7),
  (7),
  (8),
  (8),
  (8),
  (8),
  (8),
  (9),
  (9),
  (9),
  (9),
  (9),
  (10),
  (10),
  (10),
  (10),
  (10);

INSERT INTO tbl_wishlistProduct (fk_wishlist, fk_product)
VALUES
(1,7),
(2,13),
(3,9),
(4,8),
(5,4),
(6,1),
(7,12),
(8,3),
(9,19),
(10,10),
(11,2),
(12,23),
(13,16),
(14,14),
(15,17),
(16,3),
(17,5),
(18,25),
(19,18),
(20,22),
(21,15),
(22,6),
(23,21),
(24,11),
(25,20);
/*Inserir estoques para todas as lojas*/
INSERT INTO tbl_Stocks (quantity,fk_store,fk_product)
VALUES
  (104,1,1),
  (42,1,3),
  (172,1,5),
  (11,1,7),
  (51,1,9),
  (70,2,11),
  (10,2,13),
  (141,2,15),
  (105,2,17),
  (125,2,19),
  (166,3,21),
  (137,3,23),
  (168,3,25),
  (148,3,2),
  (198,3,4),
  (63,4,6),
  (156,4,8),
  (194,4,10),
  (56,4,12),
  (114,4,14),
  (63,5,16),
  (156,5,18),
  (194,5,20),
  (56,5,22),
  (114,5,24);

/*Criar compras para cada cliente com quantidades diferentes de produtos*/
INSERT INTO tbl_Purchase (payment,datePurchase,numberConfirmation,numberNf,fk_store,fk_client)
VALUES
  ('credito','Dec 26, 2021','416443','2157502485482',1,6),
  ('debito','Dec 26, 2021','126683','1624732480264',2,6),
  ('credito','Feb 16, 2023','668416','0122316614577',2,6),
  ('debito','Mar 27, 2022','587443','7291468685738',5,6),
  ('debito','Jan 7, 2023','161819','2269724571457',3,6),
  ('dinheiro','Jun 8, 2021','657254','8293894652801',4,7),
  ('dinheiro','Nov 16, 2021','717232','4661185771585',4,7),
  ('debito','Apr 6, 2022','588836','2287126568696',1,7),
  ('debito','Jun 6, 2021','382977','7874155423825',5,8),
  ('debito','Dec 10, 2021','308237','9558874564062',5,9),
  ('debito','Feb 5, 2022','156226','2667577021276',4,9),
  ('credito','Mar 27, 2022','826017','5860588937302',1,9),
  ('credito','Jul 22, 2021','784080','9255340451371',1,9),
  ('dinheiro','Sep 9, 2021','886521','1657424607772',4,10),
  ('dinheiro','Jul 31, 2022','074593','2277632772584',3,10),
  ('debito','Jul 26, 2021','650013','1737828776251',3,10),
  ('credito','Sep 6, 2021','478681','5447362630874',4,10),
  ('debito','Jul 26, 2022','203244','1355265487068',3,10);

INSERT INTO tbl_purchaseProduct (fk_purchase,fk_product)
VALUES
(1,1),
(2,8),
(3,7),
(4,25),
(5,11),
(6,20),
(7,20),
(8,1),
(9,21),
(10,24),
(11,23),
(12,5),
(13,16),
(14,19),
(15,13),
(16,18),
(17,7),
(18,3);
/*Selecionar as compras de uma loja*/
select * from tbl_Purchase as pc inner join tbl_Store as st on st.id_store = pc.fk_store where pc.fk_store = 5

/*Selecionar as compras de um determinado produto*/
select * from tbl_Purchase as pc 
inner join tbl_purchaseProduct as pp on pp.fk_purchase = pc.id_purchase
inner join tbl_Product as pd on pd.id_product = pp.fk_product
where pd.id_product = 20

/*Selecionar as compras de um determinado cliente*/
select * from tbl_Purchase as pc inner join tbl_Client as cl on cl.id_client = pc.fk_client where pc.fk_client = 9

/*Selecionar as compras de um determinado cliente pelo CPF*/
select * from tbl_Purchase as pc 
inner join tbl_Client as cl on cl.id_client = pc.fk_client 
inner join tbl_Person as ps on ps.id_person = cl.id_client
where ps.document = '124.284.146-36'

/*Selecionar as vendas de um determinado dono de loja*/
select * from tbl_Purchase as pc
inner join tbl_Store as st on st.id_store = pc.fk_store
inner join tbl_Owner as ow on ow.id_owner = st.fk_owner
where ow.id_owner = 2

/*Selecionar a quantidade de determinado produto dos estoques de todas as lojas*/
select sum(quantity) as 'Quantity' from tbl_Stocks as st
inner join tbl_Product as pd on pd.id_product = st.fk_product
where pd.id_product = 20

/*Selecionar quais clientes têm em suas WishList um determinado produto pelo nome do produto*/
Select * from tbl_Person as ps
inner join tbl_Client as cl on cl.id_client = ps.id_person
inner join tbl_Wishlist as wl on wl.fk_client = cl.id_client
inner join tbl_wishlistProduct as wlp on wlp.fk_product = wl.id_wishlist
inner join tbl_Product as pd on pd.id_product = fk_product
where pd.name = 'bee honey'