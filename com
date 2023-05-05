Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools
Pomelo.EntityFrameworkCore.MySql

cd ./WpfApp6
dotnet ef dbcontext scaffold "server=localhost;user=root;password=2580;database=trade" "Pomelo.EntityFrameworkCore.MySql" —output-dir Models

create database trade4;
use trade4;
create table Roles
(
  RoleID int primary key auto_increment,
  RoleName varchar(100) not null
);
create table Users
(
  UserID int primary key auto_increment,
  UserSurname varchar(100) not null,
  UserName varchar(100) not null,
  UserPatronymic varchar(100) not null,
  UserLogin text not null,
  UserPassword text not null,
  UserRole int not null,
  foreign key (UserRole) references Roles(RoleID) 
);
create table Category
(
 CategoryID int primary key auto_increment,
    CategoryName text not null
);
create table Manufacturers
(
 ManufacturerID int primary key auto_increment,
    ManufacturerName text not null
);
create table Units
(
 UnitID int primary key auto_increment,
    UnitName text not null
);
create table Suppliers
(
 SupplierID int primary key auto_increment,
    SupplierName text not null
);
create table Products
(
  ProductArticleNumber nvarchar(100) primary key,
  ProductName text not null,
  ProductDescription text not null,
  CategoryID int not null,
  foreign key (CategoryID) references Category(CategoryID),
  ProductPhoto longblob,
  ManufacturerID int not null,
  ProductCost decimal(19,4) not null,
  ProductDiscountAmount tinyint null,
  ProductQuantityInStock int not null,
  ProductStatus text,
  UnitID int not null,
  MaxDiscountAmount int not null,
  SupplierID int not null,
  foreign key (ManufacturerID) references Manufacturers(ManufacturerID),
  foreign key (SupplierID) references Suppliers(SupplierID),
  foreign key (UnitID) references Units(UnitID)
);
create table PickUpPoints
(
 PickUpPointID int primary key auto_increment,
    PickUpPointIndex text not null,
    PickUpPointName text not null
);
create table Orders
(
  OrderID int primary key auto_increment,
  OrderStatus text not null,
  OrderDeliveryDate datetime not null,
  OrderPickupPointID int not null,
  foreign key (OrderPickupPointID) references PickUpPoints(PickUpPointID),
  OrderDate datetime not null,
  UserID int not null,
  foreign key (UserID) references Users(UserID),
  OrderCode int not null
);
create table OrderProducts
(
  OrderID int not null,
  ProductArticleNumber nvarchar(100)  not null,
  OrderProductCount int not null,
  Primary key (OrderID,ProductArticleNumber),
  foreign key (OrderID) references Orders(OrderID),
  foreign key (ProductArticleNumber) references Products(ProductArticleNumber)
);
