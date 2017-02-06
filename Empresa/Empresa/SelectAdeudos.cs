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
    public partial class SelectAdeudos : Form
    {
        public string Titulo;
        public SelectAdeudos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Reporte1 rep = new Reporte1();
                rep.fecha1 = dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year;
                rep.fecha2 = dateTimePicker2.Value.Month + "/" + dateTimePicker2.Value.Day + "/" + dateTimePicker2.Value.Year;
                rep.Titulo = Titulo;
                this.Hide();
                rep.ShowDialog();
                this.Show();
            }
            else if(radioButton2.Checked==true)
            {
                AdeudoDoctor rep = new AdeudoDoctor();
                rep.fecha1 = dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year;
                rep.fecha2 = dateTimePicker2.Value.Month + "/" + dateTimePicker2.Value.Day + "/" + dateTimePicker2.Value.Year;
                rep.Titulo = Titulo;
                rep.DoctorSel = txtIdDoctor.Text;
                this.Hide();
                rep.ShowDialog();
                this.Show();
            }
            else if(radioButton3.Checked == true)
            {
                AdeudosRango rep = new AdeudosRango();
                rep.fecha1 = dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year;
                rep.fecha2 = dateTimePicker2.Value.Month + "/" + dateTimePicker2.Value.Day + "/" + dateTimePicker2.Value.Year;
                rep.Titulo = Titulo;
                rep.contador = Convert.ToInt32(txtIdDoctor.Text);
                this.Hide();
                rep.ShowDialog();
                this.Show();
            }
        }

        private void SelectAdeudos_Load(object sender, EventArgs e)
        {

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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btnBuscar.Visible = true;
            label3.Visible = true;
            label3.Text = "ID DOCTOR:";
            txtIdDoctor.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btnBuscar.Visible = false;
            label3.Visible = false;
            txtIdDoctor.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar_catalogo buscar = new buscar_catalogo();
            this.Hide();
            buscar.ShowDialog();
            this.Show();
            txtIdDoctor.Text = buscar.SeleccionDoc.IdDoctor;            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            btnBuscar.Visible = true;
            label3.Visible = true;
            label3.Text = "LIMITE:";
            txtIdDoctor.Visible = true;
        }
    }
}
