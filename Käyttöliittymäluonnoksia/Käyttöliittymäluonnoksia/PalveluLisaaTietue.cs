using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Käyttöliittymäluonnoksia
{
    public partial class PalveluLisaaTietue : Form
    {
        bool muokataan = false; //Tällä tarkastetaan muokataanko tietoa vai lisätäänkö

        string palveluid;

        //Kun tehdään uusi tietue
        public PalveluLisaaTietue()
        {
            InitializeComponent();
        }

        //Kun muokataan tietuetta niin tuodan kenttiin vanhat tiedot
        public PalveluLisaaTietue(string palveluid, string toimipiste_id, string nimi, string kuvaus, string hinta, string alv)
        {
            InitializeComponent();

            this.palveluid = palveluid;
            comboBox1.Text = toimipiste_id;
            nimitxt.Text = nimi;
            kuvaustxt.Text = kuvaus;
            hintatxt.Text = hinta;
            alvtxt.Text = alv;

            //Koska tietoa muokataan muutetaan arvo todeksi
            muokataan = true;
        }

        //Lisätään tai muokataan tietoja tällä samalla funktiolla
        private void LisaaMuokkaaTietoja()
        {
            //Yhteysteksti tietokantaan
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";
      
            string toimipisteid = comboBox1.SelectedValue.ToString();
            string nimi = nimitxt.Text;
            string kuvaus = kuvaustxt.Text;
            string hinta = hintatxt.Text;
            string alv = alvtxt.Text;

            //Tarkistetaan että tyhjiä kenttiä on
            if (nimi != "" && kuvaus != "" && hinta != "" && alv != "")
            {
                string kysely = "";

                if (muokataan)
                {
                    kysely = @" UPDATE palvelu
                                SET toimipiste_id = '" + toimipisteid + "', nimi= '" + nimi + "', kuvaus= '" + kuvaus + "', hinta= '" + hinta + "', alv= '" + toimipisteid + "' " +
                                "WHERE palvelu_id = " + palveluid;
                }
                else
                {
                    //Tällä kyselyllä haetaan tieto mysql tietokannasta
                    kysely = @"INSERT INTO palvelu (toimipiste_id,nimi,kuvaus,hinta,alv)
                            VALUES('" + toimipisteid + "', '" + nimi + "', '" + kuvaus + "', '" + hinta + "', '" + alv + "'); ";
                }

                //Ajetaan kysely
                    using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
                    {
                        MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                        yhteys.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();
                        yhteys.Close();
                    }
                    this.Close(); //Suljetaan yhteys
            }
            else
            {
                //Näytetään virheilmoitus
                MessageBox.Show("Et voi tallentaa tyhjiä kenttiä.","Virheilmoitus");
            }
        }

        private void TallennaBtn_Click(object sender, EventArgs e)
        {
            LisaaMuokkaaTietoja();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private DataTable LinkitaTietokanta()
        {
            DataTable dt = new DataTable();

            //Mysql serverin tiedot
            string yhteysteksti = @"server=85.23.149.196;port=3306;userid=admin;password=admin123;database=mokkitietokanta";

            //Tällä kyselyllä haetaan tieto mysql tietokannasta
            string kysely = @"SELECT * FROM toimipiste";


            using (MySqlConnection yhteys = new MySqlConnection(yhteysteksti))
            {
                MySqlCommand cmd = new MySqlCommand(kysely, yhteys);
                yhteys.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                yhteys.Close();

            }
            return dt;
        }

        private void PalveluLisaaTietue_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new BindingSource(LinkitaTietokanta(), null);
            comboBox1.DisplayMember = "nimi";
            comboBox1.ValueMember = "toimipiste_id";
        }
    }
}
