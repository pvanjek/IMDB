using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTapi
{
    class Movie
    {
        public string sTitle { get; set; }
        public string sYear { get; set; }
        public string sReleased { get; set; }
        public int nRuntime { get; set; }
        public string sGenre { get; set; }
        public string sDirector { get; set; }
        public string sActors { get; set; }
        public string sPlot { get; set; }
        public string sAwards { get; set; }
        public float fImdbRating { get; set; }
        public string sBoxOffice { get; set; }
    }
}
