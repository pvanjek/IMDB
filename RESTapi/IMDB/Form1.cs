using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

namespace RESTapi
{
    public partial class Form1 : Form
    {
        StringBuilder builder;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string endpoint = "http://www.omdbapi.com/";
            string apikey = "7576c256";
            builder = new StringBuilder();
            builder.Append(endpoint).Append("?apikey=").Append(apikey).Append("&t=").Append(textBox1.Text.ToString());
            //builder.Append(endpoint).Append("?apikey =").Append(apikey).Append("&t=").Append(textBox1.Text.ToString().Replace(" ", "&"));
            dataGridView1.DataSource = RESTapi.REST.GetMovies(builder.ToString());
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string vrijednost = dataGridView1[0, 0].Value.ToString();
            MessageBox.Show(vrijednost.ToString());
            string vrijednost1 = dataGridView1[1, 0].Value.ToString();
            MessageBox.Show(vrijednost1.ToString());
            string sSqlConnectionString = "Data Source=193.198.57.183; Initial Catalog = DotNet; User ID = vjezbe; Password = vjezbe";
            using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))

            using (DbCommand oCommand = oConnection.CreateCommand())
             {
                string tekst1 = "INSERT INTO imdb_movies (Title, Year, Released, Runtime, Genre, Director, Actors, Plot, Awards, ImdbRating, BoxOffice) VALUES ('" + dataGridView1[0, 0].Value.ToString() + "', '" + dataGridView1[1, 0].Value.ToString() + "', '" + dataGridView1[2, 0].Value.ToString() + "', '" + dataGridView1[3, 0].Value.ToString() + "', '" + dataGridView1[4, 0].Value.ToString() + "', '" + dataGridView1[5, 0].Value.ToString() + "', '" + dataGridView1[6, 0].Value.ToString() + "', '" + dataGridView1[7, 0].Value.ToString() + "', '" + dataGridView1[8, 0].Value.ToString() + "', '" + dataGridView1[9, 0].Value.ToString() + "', '" + dataGridView1[10, 0].Value.ToString() +  "', '";
                MessageBox.Show(tekst1);
                oCommand.CommandText = "INSERT INTO imdb_movies ( Title, Year, Released, Runtime, Genre, Director, Actors, Plot, Awards, ImdbRating, BoxOffice) VALUES ('" + dataGridView1[0, 0].Value.ToString() + "', '" + dataGridView1[1, 0].Value.ToString() + "', '" + dataGridView1[2, 0].Value.ToString() + "', '" + dataGridView1[3, 0].Value.ToString() + "', '" + dataGridView1[4, 0].Value.ToString() + "', '" + dataGridView1[5, 0].Value.ToString() + "', '" + dataGridView1[6, 0].Value.ToString() + "', '" + dataGridView1[7, 0].Value.ToString() + "', '" + dataGridView1[8, 0].Value.ToString() + "', '" + dataGridView1[9, 0].Value.ToString() + "', '" + dataGridView1[10, 0].Value.ToString()  + "');";
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
               {
            //nema povratne vrijednosti
              }
               }
        }


    }
    /* 
funkciju search movies unutar klase 
pozvati funkciju getMovies koja ima za parametar url
rezultat funkcije prikazati ispod textboxa i gumbica
uz prikazane rezultate spremiti film u bazu (dodati gumbic spremi)
kreirati servis Crud koji ima metodu save movie
savemovie sprema film iz pretrage u bazu
*/
}

