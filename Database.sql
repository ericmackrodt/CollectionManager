CREATE DATABASE CollectionManager;

USE CollectionManager;

CREATE TABLE Collection (
	CollectionID int(11) NOT NULL AUTO_INCREMENT,
    Name varchar(256) NOT NULL,
    Description varchar(1000),
    PRIMARY key (CollectionID)
);

CREATE TABLE Category (
	CategoryID int(11) NOT NULL auto_increment,
    Name varchar(256) NOT NULL,
    Description varchar(1000),
    CollectionID int(11) NOT NULL,
    primary key (CategoryID),
    foreign key (CollectionID) references Collection(CollectionID)
);

CREATE TABLE Item (
	ItemID int(11) unsigned not null auto_increment,
    Name varchar(500) not null,
    Year int(4),
    Developer varchar(100),
    Publisher varchar(100),
    Manufacturer varchar(100),
    DateAcquired date,
    YoutubeVideo varchar(500),
    primary key (ItemID)
);

CREATE TABLE ItemCategory (
	ItemID int(11) unsigned not null,
    CategoryID int(11) not null,
    primary key (ItemID,CategoryID),
    foreign key (ItemID) references Item(ItemID),
    foreign key (CategoryID) references Category(CategoryID)
);

CREATE TABLE ItemImageType (
	ItemImageTypeID int(11) not null auto_increment,
    Name varchar(100) not null,
    primary key (ItemImageTypeID)
);

CREATE TABLE ItemImage (
	ItemImageID int(11) not null auto_increment,
    Path varchar(500) not null,
    ItemImageTypeID int(11) not null,
    ItemID int(11) unsigned not null,
    primary key (ItemImageID),
    foreign key (ItemImageTypeID) references ItemImageType(ItemImageTypeID),
    foreign key (ItemID) references Item(ItemID)
);

CREATE TABLE ItemDescription (
	ItemID int(11) unsigned not null auto_increment,
    Content varchar(2000) not null,
    Source varchar(100),
    SourceUrl varchar(1000),
    primary key (ItemID),
    foreign key (ItemID) references Item(ItemID)
);

CREATE TABLE ItemCharacteristic (
	ItemCharacteristicID int(11) not null auto_increment,
    Name varchar(150) not null,
    primary key (ItemCharacteristicID)
);

CREATE TABLE ItemCharacteristicItem (
	ItemID int(11) not null,
    ItemCharacteristicID int(11) not null,
    primary key (ItemID,ItemCharacteristicID),
    foreign key (ItemID) references Item(ItemID),
    foreign key (ItemCharacteristicID) references ItemCharacteristic(ItemCharacteristicID)
);