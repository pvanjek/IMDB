using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RESTapi
{
    public partial class Form1 : Form
    {
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
            StringBuilder builder = new StringBuilder();
            builder.Append(endpoint).Append("?apikey =").Append(apikey).Append("&t=").Append(textBox1.Text.ToString());
            //builder.Append(endpoint).Append("?apikey =").Append(apikey).Append("&t=").Append(textBox1.Text.ToString().Replace(" ", "&"));
            MessageBox.Show(builder.ToString());
            dataGridView1.DataSource = RESTapi.REST.GetMovies(builder.ToString());
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
}
