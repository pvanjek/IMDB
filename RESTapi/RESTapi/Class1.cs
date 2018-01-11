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
            MessageBox.Show(sJson);
            JObject oJson = JObject.Parse(sJson);
            string sTitle1 = oJson["Title"].ToString();
            string sYear1 = oJson["Year"].ToString();
            string sReleased1 = oJson["Released"].ToString();
            string sRuntime1 = oJson["Runtime"].ToString();
            string sGenre1 = oJson["Genre"].ToString();
            string sDirector1 = oJson["Director"].ToString();
            string sActors1 = oJson["Actors"].ToString();
            string sPlot1 = oJson["Plot"].ToString();
            string sAwards1 = oJson["Awards"].ToString();
            string sImdbRating1 = oJson["imdbRating"].ToString();
            string sBoxOffice1 = oJson["BoxOffice"].ToString();
            string sSlika1 = oJson["Poster"].ToString();
            //            JArray json = JArray.Parse(sJson); // parsiramo podatke
            //          foreach (JObject item in json)  
            //koristimo za button
            //           MessageBox.Show(oMovie.ToString());
            //for (int i = 0; i < oMovie.Count; i++)
            // {

            // ČITANJE VRIJEDNOSTI IZ JSON-a
            //       string Title = (string)oMovie[i]["Title"];
            //string Year = (string)item.GetValue("Year");
            //string Released = (string)item.GetValue("Released");
            //int Runtime = (int)item.GetValue("Runtime");
            //string Genre = (string)item.GetValue("Genre"); 
            //string Director = (string)item.GetValue("Director");
            //string Actors = (string)item.GetValue("Actors");
            //string Plot = (string)item.GetValue("Plot");
            //string Awards = (string)item.GetValue("Awards");
            //float ImdbRating = (float)item.GetValue("imdbRating");
            //string BoxOffice = (string)item.GetValue("BoxOffice");
            //DODAVANJE OBJEKTA U LISTU
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



        //    string sSqlConnectionString = "Data Source=193.198.57.183; Initial Catalog = DotNet; User ID = vjezbe; Password = vjezbe";
            //using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))

            //using (DbCommand oCommand = oConnection.CreateCommand())
           // {
                // oCommand.CommandText = "INSERT INTO imdb_movies (Id_filma, Title, Year, Released, Runtime, Genre, Director, Actors, Plot, Awards, ImdbRating, BoxOffice) VALUES ('" + List["Title"] + "', '" + oUser.sUserPassword + "', '" + oUser.sUserFirstName + "', '" + oUser.sUserLastName + "');";
            //    oConnection.Open();
            //    using (DbDataReader oReader = oCommand.ExecuteReader())
             //   {
                    //nema povratne vrijednosti
              //  }
         //   }
        }
    }
}
