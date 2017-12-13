using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RESTapi
{
    public class REST
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


        public List<REST> lRest;

      
        public List<REST> GetMovies()
        {
            List<REST> lRestMovies = new List<REST>();
           
            string sUrl = System.Configuration.ConfigurationManager.AppSettings["RestApiUrl"];
            string sJson = CallRestMethod(sUrl); // iz URL-a spremamo podatke (Url)
            JArray json = JArray.Parse(sJson); // parsiramo podatke
            foreach (JObject item in json)                             //koristimo za button
                                                                       //datagridsorce..
            {
                {
                    // ČITANJE VRIJEDNOSTI IZ JSON-a
                    string Title = (string)item.GetValue("Title");
                    string Year = (string)item.GetValue("Year");
                    string Released = (string)item.GetValue("Released");
                    int Runtime = (int)item.GetValue("Runtime");
                    string Genre = (string)item.GetValue("Genre");
                    string Director = (string)item.GetValue("Director");
                    string Actors = (string)item.GetValue("Actors");
                    string Plot = (string)item.GetValue("Plot");
                    string Awards = (string)item.GetValue("Awards");
                    float ImdbRating = (float)item.GetValue("imdbRating");
                    string BoxOffice = (string)item.GetValue("BoxOffice");



                    float area = -1;
                    if (item.GetValue("area").Type == JTokenType.Null)
                    {
                        area = 0;
                    }
                    else
                    {
                        area = (float)item.GetValue("area");
                    }
                    string region = (string)item.GetValue("region");

                    //DODAVANJE OBJEKTA U LISTU
                    lRestMovies.Add(new REST
                    {
                        sTitle = Title,
                        sYear = Year,
                        sReleased = Released,
                        nRuntime = Runtime,
                        sGenre = Genre,
                        sDirector = Director,
                        sActors = Actors,
                        sPlot = Plot,
                        sAwards = Awards,
                        fImdbRating = ImdbRating,
                        sBoxOffice = BoxOffice,
                    });
                }
            }
            return lRestMovies;
        }
        public static string CallRestMethod(string url)
        {
            // uključiti, System.IO i System.Net
            url = "http://www.omdbapi.com/?i=tt3896198&apikey=7576c256";
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            //webrequest.Headers.Add("Username", "xyz");
            //webrequest.Headers.Add("Password", "abc");
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(),
            enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        }



    }
}
