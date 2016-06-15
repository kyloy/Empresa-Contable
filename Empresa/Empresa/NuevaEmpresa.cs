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
    public partial class NuevaEmpresa : Form
    {
        public NuevaEmpresa()
        {
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            Empresas pEmpresa = new Empresas();
            pEmpresa.IdEmpresa = Convert.ToInt32(txtIdEmpresa.Text.Trim());
            pEmpresa.Razon_Social = txtRazon_social.Text.Trim();
            pEmpresa.Giro = txtGiro.Text.Trim();
            pEmpresa.Domicilio = txtDomicilio.Text.Trim();
            pEmpresa.Ciudad = txtCiudad.Text.Trim();
            pEmpresa.Municipio = txtMunicipio.Text.Trim();
            pEmpresa.Estado = txtEstado.Text.Trim();
            pEmpresa.RFC = txtRFC.Text.Trim();
            pEmpresa.CURP = txtCURP.Text.Trim();
            pEmpresa.Reg_imss = txtReg_Patronal.Text.Trim();
            pEmpresa.Nombre_Gerente = txtNombre_Gerente.Text.Trim();
            pEmpresa.Nombre_Contador = txtNombre_Contador.Text.Trim();
            pEmpresa.Representante_Legal = txtRepresentante_Legal.Text.Trim();

            int resultado = EmpresaDAL.Agregar(pEmpresa);
            if (resultado > 0)
            {
                MessageBox.Show("Empresa Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar La Empresa", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
