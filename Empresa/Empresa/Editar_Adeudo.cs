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
    public partial class Editar_Adeudo : Form
    {
        public string Titulo;
        public string Fecha_incio;
        public string Fecha_final;
        public string Doctor;
        public Editar_Adeudo()
        {
            InitializeComponent();
        }

        private void Editar_Adeudo_Load(object sender, EventArgs e)
        {
            dgvEditar_Adeudo.DataSource = EditarAdeudoDAL.LLenar(Fecha_incio, Fecha_final, Doctor, Titulo);
        }
    }
}
