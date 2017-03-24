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
    public partial class LimpiarIngresos : Form
    {
        public  string Empresa;
        public LimpiarIngresos()
        {
            InitializeComponent();
        }

        private void btnLimpiarIngre_Click(object sender, EventArgs e)
        {
            string fecha_inicio = dateTimePicker1.Value.Year + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day;
            string fecha_final = dateTimePicker2.Value.Year + "/" + dateTimePicker2.Value.Month + "/" + dateTimePicker2.Value.Day;
            if (MessageBox.Show("Esta Seguro que desea eliminar el INGRESO Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ingre_EstudiosDAL.LimpiarIngresos(fecha_inicio, fecha_final, Empresa) > 0)
                {
                    MessageBox.Show("INGRESO Eliminado Correctamente!", "INGRESO Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);       
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el INGRESO", "INGRESO No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
