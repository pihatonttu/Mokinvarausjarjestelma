using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Käyttöliittymäluonnoksia
{
    public partial class Alkuvalikko : Form
    {
        public Alkuvalikko()
        {
            InitializeComponent();
        }

        private void toimipistebtn_Click(object sender, EventArgs e)
        {
            new Toimipisteidenhallinta().Show();
        }

        private void palvelubtn_Click(object sender, EventArgs e)
        {
            new Palveluhallinta().Show();
        }

        private void mökkibtn_Click(object sender, EventArgs e)
        {
            new Mokinhallinta().Show();
        }

        private void varausbtn_Click(object sender, EventArgs e)
        {
            new Mokkivaraustenhallinta().Show();
        }

        private void Alkuvalikko_Load(object sender, EventArgs e)
        {
            string yhteysteksti = @"server= 85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";
        }
    }
}
