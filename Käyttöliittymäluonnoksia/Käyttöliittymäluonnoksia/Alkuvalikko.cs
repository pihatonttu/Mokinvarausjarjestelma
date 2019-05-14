using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;

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

        private void Avaa_yhteys()
        {
            string yhteysteksti = @"server= 85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            //Avataan yhteys valmiiksi ja Close()-metodia käyttämällä lisätään se connection pooliin
            using (MySqlConnection connection = new MySqlConnection(yhteysteksti)) {
                MySqlCommand command = new MySqlCommand(null, connection);
                command.Connection.Open();
                command.Connection.Close();
            }
        }

        // Muokkaa tekstiä ja progressbaria, kun yhteys valmis
        private void Yhteys_valmis()
        {
            if (label3.InvokeRequired) {
                label3.Invoke(new MethodInvoker(delegate { label3.Text = "Yhteys muodostettu"; }));
            }
            else {
                label3.Text = "Yhteys muodostettu";
            }

            if (progressBar1.InvokeRequired) {
                progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.MarqueeAnimationSpeed = 0; panel1.Enabled = true; }));
            }
            else {
                progressBar1.MarqueeAnimationSpeed = 0;
                panel1.Enabled = false;
            }
        }

        private void Alkuvalikko_Load_1(object sender, EventArgs e)
        {
            // Käynnistetään Avaa_yhteys säikeessä. Kun säie valmis, kutsutaan Yhteys_valmis
            ThreadStart starter = Avaa_yhteys;
            starter += () => {
                Yhteys_valmis();
            };
            Thread thread = new Thread(starter) { IsBackground = true };
            thread.Start();
        }

        private void lisavarausbtn_Click(object sender, EventArgs e)
        {
            new Uusi_varaus().Show();
        }

        private void asiakasbtn_Click(object sender, EventArgs e)
        {
            new Asiakashallinta().Show();
        }
    }
}
