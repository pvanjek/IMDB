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
using System.Net;
using System.IO;
using System.Diagnostics;

namespace RESTapi
{
    public partial class Form1 : Form
    {
        StringBuilder builder;

        public string obrisi_naziv;

        public static Image GetImageFromUrl(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            // if you have proxy server, you may need to set proxy details like below 
            //httpWebRequest.Proxy = new WebProxy("proxyserver",port){ Credentials = new NetworkCredential(){ UserName ="uname", Password = "pw"}};

            using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream stream = httpWebReponse.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            dataGridView2.Columns["Poster"].DefaultCellStyle.NullValue = null;
            DataGridViewImageColumn oDeleteButton = new DataGridViewImageColumn();
            oDeleteButton.Image = Image.FromFile("C:/Delete.png");
            oDeleteButton.Name = "Obrisi";
            oDeleteButton.Width = 100;
            oDeleteButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView2.Columns.Add(oDeleteButton);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dotNetDataSet.imdb_movie_godina' table. You can move, or remove it, as needed.
            this.imdb_movie_godinaTableAdapter.Fill(this.dotNetDataSet.imdb_movie_godina);
            // TODO: This line of code loads data into the 'dotNetDataSet.imdb_movie' table. You can move, or remove it, as needed.
            this.imdb_movieTableAdapter.Fill(this.dotNetDataSet.imdb_movie);
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

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
            button2.Show();
            comboBox3.Show();
            label8.Show();
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
                textBox2.Visible = true;
            pictureBox1.ImageLocation = dataGridView1[11, 0].Value.ToString();
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                button2.Focus();
            }
      else
            {
                textBox1.Focus();
                textBox1.Text = "";
            }
            comboBox3.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sSqlConnectionString = "Data Source=193.198.57.183; Initial Catalog = DotNet; User ID = vjezbe; Password = vjezbe";
            using (DbConnection oConnection = new SqlConnection(sSqlConnectionString))

            using (DbCommand oCommand = oConnection.CreateCommand())
             {
                bool nasao = true;
                for (int i = 0; i < dataGridView2.RowCount -1 ; i++)
                {
                    if (dataGridView2[1, i].Value.ToString() == dataGridView1[0, 0].Value.ToString())
                    {
                        MessageBox.Show("Film : " + dataGridView1[0, 0].Value.ToString() + " je već dodan u bazu");
                        nasao = false;
                        i = dataGridView2.RowCount;
                    }
                }

                if (comboBox3.Text.ToString() == "")
                {
                    MessageBox.Show("Unesi ocjenu filma");
                    nasao = false;
                    comboBox3.Focus();
                }
                if (nasao == true)
                {
                    string tekst1 = "INSERT INTO imdb_movie (   Title, Year, Released , Runtime , Genre , Director,  Actors , Plot , Awards , ImdbRating, BoxOffice, Poster, Ocijena) VALUES ('" + dataGridView1[0, 0].Value.ToString() + "', '" + dataGridView1[1, 0].Value.ToString() + "', '" + dataGridView1[2, 0].Value.ToString() + "', '" + dataGridView1[3, 0].Value.ToString() + "', '" + dataGridView1[4, 0].Value.ToString() + "', '" + dataGridView1[5, 0].Value.ToString() + "', '" + dataGridView1[6, 0].Value.ToString() + "', '" + dataGridView1[7, 0].Value.ToString() + "', '" + dataGridView1[8, 0].Value.ToString() + "', '" + dataGridView1[9, 0].Value.ToString() + "', '" + dataGridView1[10, 0].Value.ToString() + "', '" + dataGridView1[11, 0].Value.ToString() + "', '" + comboBox3.Text.ToString() + "');";
                    oCommand.CommandText = tekst1; 
                oConnection.Open();
                using (DbDataReader oReader = oCommand.ExecuteReader())
               {
            //nema povratne vrijednosti
              }
                    this.imdb_movieTableAdapter.Fill(this.dotNetDataSet.imdb_movie);
            this.imdb_movie_godinaTableAdapter.Fill(this.dotNetDataSet.imdb_movie_godina);
            MessageBox.Show("Film: " + label1.Text.ToString() + " je dodan u bazu");
            textBox1.Text = "";
            textBox1.Focus();
                    }
            }
          
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Poster")
            {
                int redak = e.RowIndex;
                if (redak < (dataGridView2.RowCount - 1))
                { 
                string url_poster = dataGridView2[12, redak].Value.ToString();
                e.Value = GetImageFromUrl(url_poster.ToString());
                }
                else
                {
                    e.Value = null;
                }
            }
        }  

        private void button3_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView2.DataSource;
            //  bs.Filter = dataGridView1.Columns[2].HeaderText.ToString() + " LIKE '%" + comboBox1.Text.ToString() + "%'";
            bs.Filter = "";
            dataGridView2.DataSource = bs;
            this.imdb_movieTableAdapter.Fill(this.dotNetDataSet.imdb_movie);

            BindingSource bs1 = new BindingSource();
            bs1.DataSource = comboBox1.DataSource;
            comboBox1.DataSource = bs1;
            this.imdb_movieTableAdapter.Fill(this.dotNetDataSet.imdb_movie);
            this.imdb_movie_godinaTableAdapter.Fill(this.dotNetDataSet.imdb_movie_godina);

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            Sortiranje();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Sortiranje();
        }

        public void Sortiranje()
        {
            int Kolona = 0;
            string Vrijednost = comboBox2.Text.ToString();
            switch (Vrijednost)
            {
                case "Title":
                    Kolona = 1;
                    break;
                case "Year":
                    Kolona = 2;
                    break;
                case "Released":
                    Kolona = 2;
                    break;
                case "Runtime":
                    Kolona = 4;
                    break;
                case "Genre":
                    Kolona = 5;
                    break;
                case "Director":
                    Kolona = 6;
                    break;
                case "Actors":
                    Kolona = 7;
                    break;
                case "Plot":
                    Kolona = 8;
                    break;
                case "Awards":
                    Kolona = 9;
                    break;
                case "ImdbRating":
                    Kolona = 10;
                    break;
                case "BoxOffice":
                    Kolona = 13;
                    break;
                case "Ocijena":
                    Kolona = 14;
                    break;
                default:
                    break;
            }

            if (checkBox1.Checked)
            {
                dataGridView2.Sort(dataGridView2.Columns[Kolona], ListSortDirection.Descending);
            }
            else
            {
                dataGridView2.Sort(dataGridView2.Columns[Kolona], ListSortDirection.Ascending);
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView2.DataSource;
            bs.Filter = "Year" + " LIKE '%" + comboBox1.Text.ToString() + "%'";
            dataGridView1.DataSource = bs;
        }
        
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.Rows[e.RowIndex].Selected = true;
                if (dataGridView2.CurrentCell.ColumnIndex.Equals(15) && e.RowIndex != -1) // ako mi je moja trenuta celija ( index =5--broj kolone ) i ako index retka nije -1(mora biti index) nesto napravi
            {
                obrisi_naziv = dataGridView2[1, e.RowIndex].Value.ToString();
                IMDB.Delete_movie Obrisi = new IMDB.Delete_movie(obrisi_naziv);
                Obrisi.Show();
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView2.DataSource;
                dataGridView2.DataSource = bs;
                BindingSource bs1 = new BindingSource();
                bs1.DataSource = comboBox1.DataSource;
                comboBox1.DataSource = bs1;
                this.imdb_movieTableAdapter.Fill(this.dotNetDataSet.imdb_movie);
                this.imdb_movie_godinaTableAdapter.Fill(this.dotNetDataSet.imdb_movie_godina);
            }
    }
        private void tabPage2_Click(object sender, EventArgs e)
        {

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

