using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicDbMVCWebApp.ViewModels
{
    public class PersonViewModel
    {
        public Person mPerson { get; set; }

        public List<Band> mBands { get; set; }
    }
}