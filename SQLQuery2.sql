﻿CREATE TABLE EventTable(
Id INT NOT NULL PRIMARY KEY,
Name NVARCHAR(50) NOT NULL,
Description NVARCHAR(100) NOT NULL,
Place NVARCHAR(30) NOT NULL,
DateTime DateTime NOT NULL
);