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
    public partial class SelectDirecciones : Form
    {
        public string Titulo;
        public SelectDirecciones()
        {
            InitializeComponent();
        }

        private void SelectDirecciones_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteDirecciones rep = new ReporteDirecciones();
            rep.fecha1 = dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year;
            rep.fecha2 = dateTimePicker2.Value.Day + "/" + dateTimePicker2.Value.Month + "/" + dateTimePicker2.Value.Year;
            rep.Titulo = Titulo;
            this.Hide();
            rep.ShowDialog();
            this.Show();
        }
    }
}
