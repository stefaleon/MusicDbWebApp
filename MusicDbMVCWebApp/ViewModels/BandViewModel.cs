using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicDbMVCWebApp.ViewModels
{
    public class BandViewModel
    {
        public Band mBand { get; set; }

        public List<Person> mMembers { get; set; }
    }
}