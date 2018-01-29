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
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data.Common;


namespace RESTapi
{
     
    public class REST
    {
        public List<Movie> lRestMovies1;
      
        
        public static List<Movie> GetMovies(string sUrl)
        {
             List<Movie> lRestMovies = new List<Movie>();
            //string sUrl1 = System.Configuration.ConfigurationManager.AppSettings["RestApiUrl"];
            string sJson = CallRestMethod(sUrl); // iz URL-a spremamo podatke (Url)
            if (sJson.Substring(2,8) != "Response")
            {
               JObject oJson = JObject.Parse(sJson);
            string sTitle1 = oJson["Title"].ToString().Replace("'", " ");
            string sYear1 = oJson["Year"].ToString().Replace("'", " ");
            string sReleased1 = oJson["Released"].ToString().Replace("'", " ");
            string sRuntime1 = oJson["Runtime"].ToString().Replace("'", " ");
            string sGenre1 = oJson["Genre"].ToString().Replace("'", " ");
            string sDirector1 = oJson["Director"].ToString().Replace("'", " ");
            string sActors1 = oJson["Actors"].ToString().Replace("'", " ");
            string sPlot1 = oJson["Plot"].ToString().Replace("'", " ");
            string sAwards1 = oJson["Awards"].ToString().Replace("'", " ");
            string sImdbRating1 = oJson["imdbRating"].ToString();
            string sBoxOffice1 = oJson["BoxOffice"].ToString();
            string sSlika1 = oJson["Poster"].ToString();
            
                lRestMovies.Add(new Movie
                   {
                        sTitle = sTitle1,
                       sYear = sYear1,
                        sReleased = sReleased1,
                        sRuntime = sRuntime1,
                        sGenre = sGenre1,
                       sDirector = sDirector1,
                        sActors = sActors1,
                        sPlot = sPlot1,
                        sAwards = sAwards1,
                        sImdbRating = sImdbRating1,
                        sBoxOffice = sBoxOffice1,
                        sSlika = sSlika1,
                    });
            }
            else
            {
                MessageBox.Show("Krivi naziv filma ");
                lRestMovies.Add(new Movie
                {
                    sTitle = "0",
                    sYear = "0",
                    sReleased = "0",
                    sRuntime = "0",
                    sGenre = "0",
                    sDirector = "0",
                    sActors = "0",
                    sPlot = "0",
                    sAwards = "0",
                    sImdbRating = "0",
                    sBoxOffice = "0",
                    sSlika = "0",
                });
            }
            //}
            List<Movie> lRestMovies1 = lRestMovies;
            return lRestMovies;
        }

        public static string SearchMovies(string url1)
        {
             
            List<Movie> lRestMovies1 = GetMovies(url1);
            return url1;
        }
        public static string CallRestMethod(string url)
        {
           
            // url = "http://www.omdbapi.com/?i=tt3896198&apikey=7576c256";
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(),
            enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
            
        }

        public void insert1()
        {

            MessageBox.Show(lRestMovies1[0].sTitle.ToString());
        }
        public static string DeleteMovie(string Title)
        {
            string sSqlConnectionString = "Data Source=193.198.57.183; Initial Catalog = DotNet; User ID = vjezbe; Password = vjezbe";
            using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))

            using (DbCommand oCommand = oConnection.CreateCommand())

            {
                Debug.WriteLine("DELETE FROM imdb_movie WHERE Title = '" + Title + "'");
                oCommand.CommandText = "DELETE FROM imdb_movie WHERE Title = '" + Title + "'";
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
                {
                    //nema povratne vrijednosti
                }
                return "obrisi";
            }
        }
    }
}
