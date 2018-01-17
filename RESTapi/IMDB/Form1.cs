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
            // TODO: This line of code loads data into the 'dotNetDataSet.imdb_movie' table. You can move, or remove it, as needed.
            this.imdb_movieTableAdapter.Fill(this.dotNetDataSet.imdb_movie);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
     
            string endpoint = "http://www.omdbapi.com/";
            string apikey = "7576c256";
            builder = new StringBuilder();
            builder.Append(endpoint).Append("?apikey=").Append(apikey).Append("&t=").Append(textBox1.Text.ToString());
            //builder.Append(endpoint).Append("?apikey =").Append(apikey).Append("&t=").Append(textBox1.Text.ToString().Replace(" ", "&"));
            dataGridView1.DataSource = RESTapi.REST.GetMovies(builder.ToString());
            if (dataGridView1[0, 0].Value.ToString() != "0")
            {
            label13.Show();
            label14.Show();
            label15.Show();
            label16.Show();
            label17.Show();
            label18.Show();
            label19.Show();
            label20.Show();
            label21.Show();
            label22.Show();
            label23.Show();
                label1.Text = dataGridView1[0, 0].Value.ToString();
            label2.Text = dataGridView1[1, 0].Value.ToString();
            label3.Text = dataGridView1[2, 0].Value.ToString();
            label4.Text = dataGridView1[3, 0].Value.ToString();
            label5.Text = dataGridView1[4, 0].Value.ToString();
            label6.Text = dataGridView1[5, 0].Value.ToString();
            label7.Text = dataGridView1[6, 0].Value.ToString();
            textBox2.Text = dataGridView1[7, 0].Value.ToString();
            label9.Text = dataGridView1[8, 0].Value.ToString();
            label10.Text = dataGridView1[9, 0].Value.ToString();
            label11.Text = dataGridView1[10, 0].Value.ToString();
  
            pictureBox1.ImageLocation = dataGridView1[11, 0].Value.ToString();
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                button2.Focus();
            }
      else
            {
                textBox1.Focus();
                textBox1.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sSqlConnectionString = "Data Source=193.198.57.183; Initial Catalog = DotNet; User ID = vjezbe; Password = vjezbe";
            using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))

            using (DbCommand oCommand = oConnection.CreateCommand())
             {
                //  string tekst1 = "INSERT INTO imdb_movies ( Title, Year, Released, Runtime, Genre, Director, Actors, Plot, Awards, ImdbRating, BoxOffice) VALUES ('" + dataGridView1[0, 0].Value.ToString() + "', '" + dataGridView1[1, 0].Value.ToString() + "', '" + dataGridView1[2, 0].Value.ToString() + "', '" + dataGridView1[3, 0].Value.ToString() + "', '" + dataGridView1[4, 0].Value.ToString() + "', '" + dataGridView1[5, 0].Value.ToString() + "', '" + dataGridView1[6, 0].Value.ToString() + "', '" + dataGridView1[7, 0].Value.ToString() + "', '" + dataGridView1[8, 0].Value.ToString() + "', '" + dataGridView1[9, 0].Value.ToString() + "', '" + dataGridView1[10, 0].Value.ToString() +  "') ";
                //string tekst1 = "INSERT INTO imdb_movies ( Id_filma,  Title, Year, Released, Runtime, Genre, Director, Actors, Plot, Awards, ImdbRating, BoxOffice) VALUES ('" + 1 + "', '" + dataGridView1[0, 0].Value.ToString() + "', '" + dataGridView1[1, 0].Value.ToString() + "', '" + dataGridView1[2, 0].Value.ToString() + "', '" + dataGridView1[3, 0].Value.ToString() + "', '" + dataGridView1[4, 0].Value.ToString() + "', '" + dataGridView1[5, 0].Value.ToString() + "', '" + dataGridView1[6, 0].Value.ToString() + "', '" + dataGridView1[7, 0].Value.ToString() + "', '" + dataGridView1[8, 0].Value.ToString() + "', '" + dataGridView1[9, 0].Value.ToString() + "', '" + dataGridView1[10, 0].Value.ToString() + "');";
                // string tekst1 = "INSERT INTO imdb_movie (   Title, Year, Released , Runtime , Genre , Director,  Actors , Plot , Awards , ImdbRating, BoxOffice) VALUES ('"  + dataGridView1[0, 0].Value.ToString().Replace(":", " ") + "', '" + dataGridView1[1, 0].Value.ToString() + "', '" + dataGridView1[2, 0].Value.ToString() + "', '" + dataGridView1[3, 0].Value.ToString() + "', '" + dataGridView1[4, 0].Value.ToString() + "', '" + dataGridView1[5, 0].Value.ToString() + "', '" + dataGridView1[6, 0].Value.ToString() + "', '" + dataGridView1[7, 0].Value.ToString() + "', '" + dataGridView1[8, 0].Value.ToString() + "', '" + dataGridView1[9, 0].Value.ToString() + "', '" + dataGridView1[10, 0].Value.ToString() +  "');";
                bool nasao = false;
                for (int i = 0; i < dataGridView2.RowCount -1 ; i++)
                {
                    if (dataGridView2[0, i].Value.ToString() == dataGridView1[0, 0].Value.ToString())
                    {
                        MessageBox.Show("Film : " + dataGridView1[0, 0].Value.ToString() + " je već dodan u bazu");
                        nasao = true;
                        i = dataGridView2.RowCount;
                    }
                }

                if (nasao == false)
                { 
                //string tekst1 = "INSERT INTO imdb_movie (   Title, Year, Released , Runtime , Genre , Director,  Actors , Plot , Awards , ImdbRating, BoxOffice) VALUES ('" + dataGridView1[0, 0].Value.ToString() + "', '" + dataGridView1[1, 0].Value.ToString() + "', '" + dataGridView1[2, 0].Value.ToString() + "', '" + dataGridView1[3, 0].Value.ToString() + "', '" + dataGridView1[4, 0].Value.ToString() + "', '" + dataGridView1[5, 0].Value.ToString() + "', '" + dataGridView1[6, 0].Value.ToString() + "', '" + dataGridView1[7, 0].Value.ToString() + "', '" + dataGridView1[8, 0].Value.ToString() + "', '" + dataGridView1[9, 0].Value.ToString() + "', '" + dataGridView1[10, 0].Value.ToString() + "');";
                    string tekst1 = "INSERT INTO imdb_movie (   Title, Year, Released , Runtime , Genre , Director,  Actors , Plot , Awards , ImdbRating, BoxOffice) VALUES ('" + dataGridView1[0, 0].Value.ToString() + "', '" + dataGridView1[1, 0].Value.ToString() + "', '" + dataGridView1[2, 0].Value.ToString() + "', '" + dataGridView1[3, 0].Value.ToString() + "', '" + dataGridView1[4, 0].Value.ToString() + "', '" + dataGridView1[5, 0].Value.ToString() + "', '" + dataGridView1[6, 0].Value.ToString() + "', '" + dataGridView1[7, 0].Value.ToString() + "', '" + dataGridView1[8, 0].Value.ToString() + "', '" + dataGridView1[9, 0].Value.ToString() + "', '" + dataGridView1[10, 0].Value.ToString() + "');";
                    oCommand.CommandText = tekst1; 
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
               {
            //nema povratne vrijednosti
              }
                    }
            }
            this.imdb_movieTableAdapter.Fill(this.dotNetDataSet.imdb_movie);
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

