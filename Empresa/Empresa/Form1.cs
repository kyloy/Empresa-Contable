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
    public partial class Form1 : Form
    {
        public string TITULO;
        public Form1()
        {
            InitializeComponent();
        }

        private void doctoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogo_Doctores doctor = new Catalogo_Doctores();
            this.Hide();
            doctor.ShowDialog();
            this.Show();
        }

        private void estudiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogo_de_Estudios estudio = new Catalogo_de_Estudios();
            this.Hide();
            estudio.ShowDialog();
            this.Show();
        }

        private void IngresoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ingreso_Estudios ingre = new Ingreso_Estudios();
            ingre.NombreEmpresa = TITULO;
            this.Hide();
            ingre.ShowDialog();
            this.Show();
        }

        private void reporte1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAdeudos r = new SelectAdeudos();
            this.Hide();
            r.Titulo = TITULO;
            r.ShowDialog();
            this.Show();
        }

        private void reporte2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectReporte2 r2 = new SelectReporte2();
            this.Hide();
            r2.Titulo = TITULO;
            r2.ShowDialog();
            this.Show();
        }

        private void reporteDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectRDiario r3 = new SelectRDiario();
            this.Hide();
            r3.Titulo = TITULO;
            r3.ShowDialog();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = TITULO;
        }

        private void eGRESOSToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EgresosForm egresos = new EgresosForm();
            this.Hide();
            egresos.Titulo = TITULO;
            egresos.ShowDialog();
            this.Show();
        }

        private void egresosToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Catalogo_de_Egresos catagEgresos = new Catalogo_de_Egresos();
            this.Hide();
            catagEgresos.ShowDialog();
            this.Show();
        }

        private void cONCENTRADOMENSUALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectConMensual rep = new SelectConMensual();
            this.Hide();
            rep.Empresa = TITULO;
            rep.ShowDialog();
            this.Show();
        }

        private void otrosIngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogo_Otros_Ingresos catagotros = new Catalogo_Otros_Ingresos();
            this.Hide();
            catagotros.ShowDialog();
            this.Show();
        }

        private void oTROSINGRESOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OtrosIngreForm OtrosIngre = new OtrosIngreForm();
            this.Hide();
            OtrosIngre.Titulo = TITULO;
            OtrosIngre.ShowDialog();
            this.Show();
        }

        private void cONCENTRADODEDIRECCIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectDirecciones r2 = new SelectDirecciones();
            this.Hide();
            r2.Titulo = TITULO;
            r2.ShowDialog();
            this.Show();
        }
    }
}
