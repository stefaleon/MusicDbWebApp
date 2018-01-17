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
    // GET: Bands/SelectBand/42
    public ActionResult SelectBand(int? id)
    {

        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        var selectedBand = db.Bands.Find(id);

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

        return View("Band", viewModel);
    }
```

* Create the *Band* view.

*Views/Bands/Band.cshtml*
```
@model MusicDbMVCWebApp.ViewModels.BandViewModel

@{
    ViewBag.Title = "Band";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h3>@Model.mBand.Name</h3>

@foreach (var m in Model.mMembers)
{
    <li>@m.Name</li>
}
```

* Edit the *tr* tag in the bands' list view.

*Views/Bands/Bands*
```
//...
<tr style="cursor:pointer;"
            onclick="location.href =
            '@(Url.Action("SelectBand", "Bands", new { id = item.Id }))'">
```



&nbsp;
## 05 People controller and view, PersonViewModel, SelectPerson

* Right click on Controllers, add Controller.
* Empty MVC5 Controller -> PeopleController

*Controllers/PeopleController.cs*
```
namespace MusicDbMVCWebApp.Controllers
{    
    public class PeopleController : Controller
    {
        private MusicDbEntities db = new MusicDbEntities();

        // GET: People
        public ActionResult Index()
        {
            var people = db.People.ToList();

            return View("People", people);
        }
    }
}
```


* In */Views/People* add a new view *People*.

*/Views/People/People.cshtml*
```
@model IEnumerable<MusicDbMVCWebApp.Person>

@{
    ViewBag.Title = "People";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>People</h2>


<table class="table">
    <tr>
        <th>
            Person
        </th>
    </tr>
    @foreach (var item in Model)
    {
        <tr style="cursor:pointer;"
            onclick="location.href =
            '@(Url.Action("SelectPerson", "People", new { id = item.Id }))'">
            <td>
                @Html.DisplayFor(modelItem => item.Name)
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
           <li>@Html.ActionLink("People", "Index", "People")</li>
           <li>@Html.ActionLink("Bands", "Index", "Bands")</li>
       </ul>       
    </div>
```



* In the *ViewModels* folder create the *PersonViewModel* class.

```
namespace MusicDbMVCWebApp.ViewModels
{
    public class PersonViewModel
    {
        public Person mPerson { get; set; }

        public List<Band> mBands { get; set; }
    }
}
```




* In *PeopleController*

```
// GET: People/SelectPerson/69
public ActionResult SelectPerson(int? id)
{

    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }

    var selectedPerson = db.People.Find(id);

    if (selectedPerson == null)
    {
        return HttpNotFound();
    }

    var bands = selectedPerson.Bands.ToList();

    var viewModel = new PersonViewModel
    {
        mPerson = selectedPerson,
        mBands = bands
    };

    return View("Person", viewModel);
}
```

* Create the *Person* view.

*Views/People/Person.cshtml*
```
@model MusicDbMVCWebApp.ViewModels.PersonViewModel

@{
    ViewBag.Title = "Person";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h3>@Model.mPerson.Name</h3>

@foreach (var m in Model.mBands)
{
    <li>@m.Name</li>
}
```
