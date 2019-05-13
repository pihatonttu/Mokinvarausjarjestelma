using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Käyttöliittymäluonnoksia {
    public partial class Muokkaa_mokkivaraus : Form {

        int lkm;
        DateTime alku;
        DateTime loppu;

        public Muokkaa_mokkivaraus(int lkm, DateTime alku, DateTime loppu)
        {
            InitializeComponent();
            this.lkm = lkm;
            this.alku = alku;
            this.loppu = loppu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Muokkaa_mokkivaraus_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = lkm;
            dateTimePicker1.Value = alku;
            dateTimePicker2.Value = loppu;
        }
    }
}
