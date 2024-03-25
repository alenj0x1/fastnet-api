CREATE DATABASE fastnetdb;
GO

USE fastnetdb;
GO

CREATE TABLE methodpayment (
	methodpaymentid INT IDENTITY PRIMARY KEY,
	description VARCHAR(50) NOT NULL 
)
GO

CREATE TABLE statuscontract (
	statusid INT IDENTITY PRIMARY KEY,
	description VARCHAR(50) NOT NULL
)
GO

CREATE TABLE attentiontype (
	attentiontypeid INT IDENTITY PRIMARY KEY,
	description VARCHAR(100) NOT NULL
)
GO

CREATE TABLE attentionstatus (
	statusid INT IDENTITY PRIMARY KEY,
	description VARCHAR(30) NOT NULL
)
GO

CREATE TABLE rol (
	rolid INT IDENTITY PRIMARY KEY,
	rolname VARCHAR(50) NOT NULL
)
GO

CREATE TABLE cash (
	cashid INT IDENTITY PRIMARY KEY,
	cashdescription VARCHAR(50) DEFAULT 'without description',
	active BIT DEFAULT 1
)
GO

CREATE TABLE userstatus (
	statusid INT IDENTITY PRIMARY KEY,
	description VARCHAR(50) NOT NULL
)
GO

CREATE TABLE service (
	serviceid INT IDENTITY PRIMARY KEY,
	servicename VARCHAR(100) NOT NULL,
	servicedescription varchar(150) NOT NULL,
	price VARCHAR(10) NOT NULL
)
GO

CREATE TABLE device (
	deviceid INT IDENTITY PRIMARY KEY,
	devicename VARCHAR(50) NOT NULL,
	serviceid INT NOT NULL,
	FOREIGN KEY (serviceid) REFERENCES service(serviceid)
)
GO

CREATE TABLE client (
	clientid INT IDENTITY PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	lastname VARCHAR(50) NOT NULL,
	identification VARCHAR(13) NOT NULL,
	email VARCHAR(120),
	phonenumber VARCHAR(10),
	address VARCHAR(100) NOT NULL,
	referenceaddress VARCHAR(100) NOT NULL
)
GO

CREATE TABLE payments (
	paymentid INT IDENTITY PRIMARY KEY,
	paymentdate DATETIME NOT NULL,
	clientid INT NOT NULL,
	FOREIGN KEY (clientid) REFERENCES client(clientid)
)
GO

CREATE TABLE turn (
	turnid INT IDENTITY PRIMARY KEY,
	description VARCHAR(50) DEFAULT 'without description.',
	date DATETIME DEFAULT CURRENT_TIMESTAMP,
	cash_cashid INT NOT NULL,
	FOREIGN KEY (cash_cashid) REFERENCES cash(cashid),
	usergestorid INT NOT NULL
)
GO	

CREATE TABLE attention (
	attentionid INT IDENTITY PRIMARY KEY,
	turn_turnid INT NOT NULL,
	FOREIGN KEY (turn_turnid) REFERENCES turn(turnid),
	client_clientid INT,
	attentiontype_attentiontypeid INT NOT NULL,
	FOREIGN KEY (attentiontype_attentiontypeid) REFERENCES attentiontype(attentiontypeid),
	attentionstatus_statusid INT NOT NULL,
	FOREIGN KEY (attentionstatus_statusid) REFERENCES attentionstatus(statusid)
)
GO

CREATE TABLE users (
	userid INT IDENTITY PRIMARY KEY,
	username VARCHAR(50) NOT NULL,
	email VARCHAR(100) NOT NULL,
	password VARCHAR(100) NOT NULL,
	rol_rolid INT NOT NULL,
	FOREIGN KEY (rol_rolid) REFERENCES rol(rolid),
	creationdate DATETIME DEFAULT CURRENT_TIMESTAMP,
	userstatus_statusid INT,
	FOREIGN KEY (userstatus_statusid) REFERENCES userstatus(statusid)
)
GO

CREATE TABLE usercash (
	user_userid INT NOT NULL UNIQUE,
	FOREIGN KEY (user_userid) REFERENCES users(userid),
	cash_cashid INT NOT NULL,
	FOREIGN KEY (cash_cashid) REFERENCES cash(cashid)
)
GO

CREATE TABLE contract (
	contracid INT IDENTITY PRIMARY KEY,
	startdate DATETIME DEFAULT CURRENT_TIMESTAMP,
	enddate DATETIME DEFAULT CURRENT_TIMESTAMP,
	service_serviceid INT NOT NULL,
	FOREIGN KEY (service_serviceid) REFERENCES service(serviceid),
	statuscontract_statusid INT NOT NULL,
	FOREIGN KEY (statuscontract_statusid) REFERENCES statuscontract(statusid),
	client_clientid INT NOT NULL,
	FOREIGN KEY (client_clientid) REFERENCES client(clientid),
	methodpayment_methodpaymentid INT NOT NULL,
	FOREIGN KEY (methodpayment_methodpaymentid) REFERENCES methodpayment(methodpaymentid)
)
GO

-- Roles
INSERT INTO rol (rolname)
VALUES ('manager')
GO

INSERT INTO rol (rolname)
VALUES ('cashier')
GO

-- Services
INSERT INTO service (servicename, servicedescription, price)
VALUES ('100MB', 'Default', 25.99)
GO

INSERT INTO service (servicename, servicedescription, price)
VALUES ('500MB', 'Default', 37.99)
GO

INSERT INTO service (servicename, servicedescription, price)
VALUES ('1GB', 'Default', 52.99)
GO

-- Devices
INSERT INTO device (devicename, serviceid)
VALUES ('basic router', 1)
GO

INSERT INTO device (devicename, serviceid)
VALUES ('advanced router', 2)
GO

INSERT INTO device (devicename, serviceid)
VALUES ('X router', 3)
GO

-- Method payments
INSERT INTO methodpayment (description)
VALUES ('cash')
GO

INSERT INTO methodpayment (description)
VALUES ('card')
GO

-- Status contract
INSERT INTO statuscontract (description)
VALUES ('active')
GO

INSERT INTO statuscontract (description)
VALUES ('ended')
GO

-- Attention type
INSERT INTO attentiontype (description)
VALUES ('newservice')
GO

INSERT INTO attentiontype (description)
VALUES ('payments')
GO

INSERT INTO attentiontype (description)
VALUES ('changeservice')
GO

INSERT INTO attentiontype (description)
VALUES ('changemethodpayment')
GO

INSERT INTO attentiontype (description)
VALUES ('cancelservice')
GO

-- Attention status
INSERT INTO attentionstatus (description)
VALUES ('waiting')
GO

INSERT INTO attentionstatus (description)
VALUES ('taked')
GO

INSERT INTO attentionstatus (description)
VALUES ('ended')
GO

-- Users
INSERT INTO users (username, email, password, rol_rolid)
VALUES ('sa', 'sa@fasnet.com', 'sa', 1)
GO

SELECT * FROM users
SELECT * FROM rol
SELECT * FROM device
SELECT * FROM service