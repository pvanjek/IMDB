using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMDB
{
    public partial class Delete_movie : Form
    {
        public string naziv;
        public Delete_movie(string Title)
        {
            naziv = Title;
            InitializeComponent();
            button1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        RESTapi.REST.DeleteMovie(naziv);
            this.Close();
        }
    }
}
