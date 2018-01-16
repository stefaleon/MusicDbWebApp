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



&nbsp;
## 02 Edit auto generated views

* Edit *Views/Shared/_Layout.cshtml*

```
    <div class="navbar-header">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        @Html.ActionLink("Ambro Web Page", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" })
    </div>
    <div class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            @*<li>@Html.ActionLink("Home", "Index", "Home")</li>
            <li>@Html.ActionLink("About", "About", "Home")</li>
            <li>@Html.ActionLink("Contact", "Contact", "Home")</li>*@
        </ul>        
    </div>

```
```
       <footer>
           <p>&copy; @DateTime.Now.Year - Music Database Web Application</p>
       </footer>
```


* Edit *Views/Home/Index.cshtml*

```
<div class="">
    <h1>Music Database Web Application</h1>    
</div>
```
