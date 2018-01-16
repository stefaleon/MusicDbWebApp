# Music Db Web App
﻿## A .NET MVC Web App, Database First



&nbsp;
## 00 Start project

* New ASP.NET Web Application.
* MVC, No Authentication



&nbsp;
## 01 Entity database first MusicDbModel

* Right click on project, add New Item.
* Data, ADO.NET Entity Data Model -> Name: MusicDbModel.
* EF Designer from database.
* New Connection -> (localdb)\MSSQLLOCALDB, database: MusicDb
* Save connection settings in Web.Config as: MusicDbEntities
* Select all tables
* Pluralize or singularize generated object names
* Include foreign key columns in the model.
* Model Namespace: MusicDbModel
