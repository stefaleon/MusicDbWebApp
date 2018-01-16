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





&nbsp;
## 03 Bands controller and view

* Right click on Controllers, add Controller.
* Empty MVC5 Controller -> BandsController

*Controllers/BandsController.cs*
```
using System.Data.Entity;
```
```
public class BandsController : Controller
{
    private MusicDbEntities db = new MusicDbEntities();

    // GET: Bands
    public ActionResult Index()
    {
        var bands = db.Bands.ToList();

        return View("Bands", bands);
    }
}
```


* In */Views/Bands* add a new view *Bands*.

*/Views/Bands/Bands.cshtml*
```
@model IEnumerable<MusicDbMVCWebApp.Band>

@{
    ViewBag.Title = "Bands";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Bands</h2>


<table class="table">
    <tr>
        <th>
            Band
        </th>
    </tr>
    @foreach (var item in Model)
    {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.Name )
            </td>
        </tr>
    }
</table>
```

* Add a link on the navigation bar

*Views/Shared/_Layout.cshtml*
```
    <div class="navbar-collapse collapse">
       <ul class="nav navbar-nav">
           <li>@Html.ActionLink("Bands", "Index", "Bands")</li>
       </ul>       
    </div>
```

&nbsp;
## 04 BandViewModel, SelectBand

* Create the *ViewModels* folder and the *BandViewModel* class.

```
namespace MusicDbMVCWebApp.ViewModels
{
    public class BandViewModel
    {
        public Band mBand { get; set; }

        public List<Person> mMembers { get; set; }
    }
}
```


* In *BandsController*

```
    // GET: Bands/42
    public ActionResult SelectBand(int? id)
    {

        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        Band selectedBand = db.Bands.Find(id);

        if (selectedBand == null)
        {
            return HttpNotFound();
        }

        var members = selectedBand.People.ToList();

        var viewModel = new BandViewModel
        {
            mBand = selectedBand,
            mMembers = members                
        };

        return View("Bands", viewModel);
    }
```
