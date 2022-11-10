use master
go
  
create database JoyeriaDB;
go

use JoyeriaDB;
go

create table Categories
(
	Id		int identity primary key not null,
	Name	varchar(100)  not null
)
go

insert into Categories(Name) values ('Baby Lover');
insert into Categories(Name) values ('Peru Lover');
insert into Categories(Name) values ('Animal Lover');

select * from Categories;

create table Products
(
	Id			UNIQUEIDENTIFIER primary key not null,
	Name		varchar(100) not null,
	Description varchar(500) not null,
	Stock		int not null,
	Price		decimal(18, 2) not null, -- SOLES
	Image       varchar(100) default('https://m.media-amazon.com/images/I/61cW7jqHKrL._AC_SY500._SX._UX._SY._UY_.jpg') null,
	Category_id int

	foreign key (Category_id) references Categories(Id)
)
go

-- Initial data for 'Para ellos' category => Category Id = 1
insert into Products(Id, Name, Description, Stock, Price, Category_id,Image) 
values (NEWID(), 'Llavero San Judas', 'Presentativo para religiosos', 10, 159.99, 1,'https://cdn.myka.com/es/images/Products/m_big_101-01-832-04.jpg');
insert into Products(Id, Name, Description, Stock, Price, Category_id,Image) 
values (NEWID(), 'Llavero Señor de los Milagros', 'Presentativo para religiosos', 20, 189.99, 1,'https://s.alicdn.com/@sc01/kf/Hcb2758bdb83943ea91dacd8573166fadZ.jpg');
insert into Products(Id, Name, Description, Stock, Price, Category_id,Image) 
values (NEWID(), 'Llavero Escudo Nacional', 'Presentativo para patriotas', 50, 119.99, 1,'https://wikirock.net/tienda/wp-content/uploads/2020/06/71ZzMNHI0DL._AC_UY575_.jpg');
insert into Products(Id, Name, Description, Stock, Price, Category_id,Image) 
values (NEWID(), 'Collar Firmeza Hombre', 'Presentativo para varones firmes', 5, 465.99, 1,'https://m.media-amazon.com/images/I/61cW7jqHKrL._AC_SY500._SX._UX._SY._UY_.jpg');
insert into Products(Id, Name, Description, Stock, Price, Category_id,Image) 
values (NEWID(), 'Pulsera Confianza Hombre', 'Presentativo para varones confiados', 20, 380.00, 1,'https://axosac.com/wp-content/uploads/2018/05/EscudoMarinadeGuerradelPer%C3%BA.jpg');
insert into Products(Id, Name, Description, Stock, Price, Category_id,Image) 
values (NEWID(), 'Anillo Equilibrio Hombre', 'Presentativo para varones equilibrados', 30, 340.00, 1,'https://www.argentariaperu.com/wp-content/uploads/2018/10/llavero-milagros.jpeg');
insert into Products(Id, Name, Description, Stock, Price, Category_id,Image) 
values (NEWID(), 'Anillo Fe Hombre', 'Presentativo para varones con fe', 15, 360.00, 1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTlpJZjBrURvSab6GUbWKrSsITaDbu5oR3lNg&usqp=CAU');
insert into Products(Id, Name, Description, Stock, Price, Category_id,Image) 
values (NEWID(), 'Collar Equilibrio Hombre', 'Presentativo para varones equilibrados', 10, 695.00, 1,'https://i.pinimg.com/originals/cf/2a/86/cf2a8640321383f6e750f0fb7d6dad02.jpg');
insert into Products(Id, Name, Description, Stock, Price, Category_id,Image) 
values (NEWID(), 'Pulsera Libertad Hombre', 'Presentativo para varones libres', 20, 210.00, 1,'https://http2.mlstatic.com/D_799529-MLM43534825042_092020-O.jpg');
insert into Products(Id, Name, Description, Stock, Price, Category_id,Image) 
values (NEWID(), 'Collar Infinito Hombre', 'Presentativo para varones infinitos', 5, 885.00, 1,'https://m.media-amazon.com/images/I/313ZY45uNRL._SL500_.jpg');

select * from Products;
create table ImageProduct(
Id			int identity primary key not null,
Name		varchar(300) not null,
Link		varchar (500) not null,
Product_id	UNIQUEIDENTIFIER
foreign key (Product_id) references Products(Id)
)
create proc usp_listar_products
as
select* from Products;
go


create table UserTypes
(
	Id			int identity primary key not null,
	Name		varchar(100) not null
)
go

insert into UserTypes(Name) values ('Administrador');
insert into UserTypes(Name) values ('Cliente');

select * from UserTypes;

create table DocumentTypes
(
	Id			int identity primary key not null,
	Name		varchar(100) not null,
)
go

insert into DocumentTypes(Name) values ('DNI');
insert into DocumentTypes(Name) values ('RUC');
insert into DocumentTypes(Name) values ('Carnet de Extranjeria');
insert into DocumentTypes(Name) values ('Pasaporte');

select * from DocumentTypes;


create table Users
(
	Id				int identity primary key not null,
	Name			varchar(100) not null,
	LastName		varchar(100) not null,
	DocumentNumber	varchar(13) not null,
	Email			varchar(256) not null,
	Password		varchar(20) not null,
	Address			varchar(150),
	Cellphone		varchar(15),
	UserTypeId		int not null,
	DocumentTypeId	int not null,

	foreign key (UserTypeId) references UserTypes(Id),
	foreign key (DocumentTypeId) references DocumentTypes(Id)
)
go
select * from Users;
create proc usp_user_login
@email varchar(256),@pass varchar(20)
as
select Id, Name,LastName,DocumentNumber,Email,Password,Address,Cellphone,UserTypeId,DocumentTypeId
 from Users where Email =@email and Password=@pass
go

insert into Users(Name,LastName,DocumentNumber,Email,Password,Address,Cellphone,UserTypeId,DocumentTypeId) values ('Jorge','Perez','12345678','jperez@gmail.com','123456','Av.Peru 123','991458310',1,1);

insert into Users(Name,LastName,DocumentNumber,Email,Password,Address,Cellphone,UserTypeId,DocumentTypeId) values ('Pedro','Perez','12345678','pperez@gmail.com','654321','Av.Peru 123','991458310',1,1);

select * from Users;





create table OrderStatus
(
	Id		int identity primary key not null,
	Name	varchar(150),	
);

insert into OrderStatus(Name) values ('Ordernado');
insert into OrderStatus(Name) values ('En Despacho');
insert into OrderStatus(Name) values ('Enviado');
insert into OrderStatus(Name) values ('Entregado');
insert into OrderStatus(Name) values ('Anulado');

create table Orders
(
	Id			UNIQUEIDENTIFIER primary key not null,
	Date		datetime not null,
	UserId		int not null,
	StatusId	int not null,
	Total		decimal(18, 2) not null,

	foreign key (UserId) references Users(Id),
	foreign key (StatusId) references OrderStatus(Id),
);

select * from Orders;

create table OrderItems
(
	Id			UNIQUEIDENTIFIER primary key not null,
	Amount		int,
	Price		decimal(18, 2) not null,
	TotalAmount	decimal(18, 2) not null, -- Amount * Price
	ProductId	UNIQUEIDENTIFIER not null,
	OrderId		UNIQUEIDENTIFIER not null,	

	foreign key (ProductId) references Products(Id),
	foreign key (OrderId) references Orders(Id),
);

select * from OrderItems;
create table Complaint(
	Id	int identity primary key not null,
	Datec datetime  not null,
	Name varchar(150) not null,
	Address varchar(150) not null,
	Ndoc varchar(13) not null,
	Email	varchar(256) not null,
	Cellphone varchar(15) not null,
	Repre varchar(100) default('No parent'),
	Typep varchar(20) not null,
	Price varchar(300) default('1'),
	Descp varchar(520) not null,
	Typc varchar(20) not null,
	Descc varchar(520) not null,
	Pedic varchar(520) not null,
	StatusC int default(1) 
)
drop table Complaint;
insert into Complaint(Datec,Name,Address,Ndoc,Email,Cellphone,Typep,Price,Descp,Typc,Descc,Pedic)
values (GETDATE(),'Alfonso Reyes','Los yupanqui 214','12345678','alfreyh@gmail.com','992563710','1','200','Descripcion1','1','Descripcion2','Pedido');
select * from Complaint
select * from Users