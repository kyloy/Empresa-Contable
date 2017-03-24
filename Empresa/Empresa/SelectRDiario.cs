using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empresa
{
    public partial class SelectRDiario : Form
    {
        public string Titulo;
        public SelectRDiario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteDiario rep = new ReporteDiario();
            rep.fecha1 = dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year;
            rep.fecha2 = dateTimePicker2.Value.Day + "/" + dateTimePicker2.Value.Month + "/" + dateTimePicker2.Value.Year;
            rep.Titulo = Titulo;
            this.Hide();
            rep.ShowDialog();
            this.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
