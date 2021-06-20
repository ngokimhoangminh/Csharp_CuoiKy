create database HoangMinhDB

create table UserAccount(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserName VARCHAR(50) NOT NULL,
    PassWord VARCHAR(50) NOT NULL,
    Status VARCHAR(50) NOT NULL,
)

insert into UserAccount(UserName,PassWord,Status)
values('hoangminh','e10adc3949ba59abbe56e057f20f883e','Active')


create table CategoryProduct(
	category_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	category_name NVARCHAR(255) not null,
	category_des NVARCHAR (255) NOT NULL,
	category_status int not null
)

insert into CategoryProduct(category_name,category_des,category_status)
values(N'Fashion & Beauty',N'Thời trang hiện đại',1),
	(N'Kids & Babies CLothes',N'Thời trang cho bé',1),
	(N'Men & Women',N'Thời trang hiện đại',1),
	(N'Gadgets & Accessories',N'Chất lượng tuyệt vời',1),
	(N'Eclectonics',N'Thương mại điện tử',1)
--FOREIGN KEY (Order_ID) REFERENCES OrderInfo (Order_ID) );

select * from CategoryProduct

create table Product(
	product_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	category_id INT FOREIGN KEY (category_id) REFERENCES CategoryProduct (category_id),
	product_name Nvarchar(255) not null,
	product_unicost decimal(10,2) not null,
	product_quantity int not null,
	product_size varchar(255),
	product_image Nvarchar(255),
	product_des Nvarchar(255) not null,
	product_status int not null
)


insert into Product(category_id,product_name,product_unicost,product_quantity,product_size,product_image,product_des,product_status)
values(1,N'Đầm Thời Trang',50000,5,'XL',N'sp1.jpg',N'Chất liệu vải ngoại nhập, mát vẻ',1)


create table Customer(
	customer_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	customer_name Nvarchar(255) not null,
	customer_email Nvarchar(255) not null,
	customer_address Nvarchar(255) not null,
	customer_password varchar(50) not null,
	customer_phone varchar(255)
)

insert into Customer(customer_name,customer_email,customer_address,customer_password,customer_phone)
values(N'Ngô Kim Hoàng Minh',N'hoangminhcp10@gmail.com',N'162 Đống Đa','e10adc3949ba59abbe56e057f20f883e','0941314137'),
	(N'Phạm Thanh Bình',N'thanhbinh@gmail.com',N'52 Đinh Tiên Hoàng','e10adc3949ba59abbe56e057f20f883e','0945362178'),
	(N'Trương Xuân Tân',N'xuantan@gmail.com',N'DakLak','e10adc3949ba59abbe56e057f20f883e','08963541258'),
	(N'Huỳnh Uyển Nhi',N'uyennhi@gmail.com',N'Thanh Sơn, Hà Nội','e10adc3949ba59abbe56e057f20f883e','0512369784'),
	(N'Diệp Trúc Mai',N'trucmai@gmail.com',N'Tân Bình, HCM','e10adc3949ba59abbe56e057f20f883e','0954638781'),
	(N'Hoàng Thu Uyên',N'thuuyen@gmail.com',N'Hải Châu, Đà Nẵng','e10adc3949ba59abbe56e057f20f883e','05698714')
	




	

		