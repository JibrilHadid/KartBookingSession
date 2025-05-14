CREATE SCHEMA booking;
GO
CREATE SCHEMA location;
GO

CREATE TABLE booking.tblKarts (
	kartID  INT IDENTITY (1,1) PRIMARY KEY,
	kartType VARCHAR(100) NOT NULL,
	kartName VARCHAR (100) NOT NULL,
	productionDate DATE NOT NULL,
	kartPrice DECIMAl NOT NULL
);

CREATE TABLE location.tblCity (
	cityID INT IDENTITY (1,1) PRIMARY KEY,
	cityName VARCHAR (100) NOT NULL,
	country VARCHAR (100) NOT NULL
);

CREATE TABLE location.tblSuburb (
	suburbID INT IDENTITY (1,1) PRIMARY KEY,
	suburbName VARCHAR (100) NOT NULL,
	cityID INT NOT NULL,
	FOREIGN KEY (cityID) REFERENCES location.tblCity (cityID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE booking.tblKartManufacturer (
	manufacturerID INT IDENTITY (1,1) PRIMARY KEY,
	kartID INT NOT NULL,
	manufacturerName VARCHAR(255) NOT NULL,
	FOREIGN KEY (kartID) REFERENCES booking.tblKarts (kartID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE location.tblTracks (
	trackID INT IDENTITY (1,1) PRIMARY KEY,
	trackName VARCHAR (100) NOT NULL, 
	trackType VARCHAR (255) NOT NULL,  
	suburbID INT NOT NULL, 
	FOREIGN KEY (suburbID) REFERENCES location.tblSuburb (suburbID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE booking.tblCoach (
	coachID INT IDENTITY (1,1) PRIMARY KEY,
	firstName VARCHAR (100) NOT NULL,
	lastName VARCHAR (100) NOT NULL,
	age INT NOT NULL,
	gender VARCHAR (100) NOT NULL
);

CREATE TABLE location.tblCoachLocation (
	coachID INT NOT NULL,
	trackID INT NOT NULL,
	FOREIGN KEY (coachID) REFERENCES booking.tblCoach (coachID) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (trackID) REFERENCES location.tblTracks (trackID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE booking.tblCoachInfo (
	coachInfoID INT IDENTITY (1,1),
	coachID INT NOT NULL,
	email VARCHAR (100) NOT NULL,
	phoneNumber VARCHAR (10) NOT NULL,
	experienceLvl VARCHAR (100) NOT NULL,
	FOREIGN KEY (coachID) REFERENCES booking.tblCoach (coachID) ON DELETE CASCADE ON UPDATE CASCADE
);














