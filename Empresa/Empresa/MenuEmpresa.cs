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

namespace Empresa
{
    public partial class MenuEmpresa : Form
    {
        public MenuEmpresa()
        {
            InitializeComponent();
            BdComun.ObtenerConexion();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            NuevaEmpresa nueva = new NuevaEmpresa();
            nueva.ShowDialog();
            dgvEmpresa.DataSource = EmpresaDAL.LLenar();
            dgvEmpresa.Columns[2].Visible = false;
            dgvEmpresa.Columns[3].Visible = false;
            dgvEmpresa.Columns[4].Visible = false;
            dgvEmpresa.Columns[5].Visible = false;
            dgvEmpresa.Columns[6].Visible = false;
            dgvEmpresa.Columns[7].Visible = false;
            dgvEmpresa.Columns[8].Visible = false;
            dgvEmpresa.Columns[9].Visible = false;
            dgvEmpresa.Columns[10].Visible = false;
            dgvEmpresa.Columns[11].Visible = false;
            dgvEmpresa.Columns[12].Visible = false; 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar la Empresa Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (EmpresaDAL.Eliminar(Convert.ToInt32(dgvEmpresa.CurrentRow.Cells[0].Value)) > 0)
                {
                    MessageBox.Show("Empresa Eliminado Correctamente!", "Estudio Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvEmpresa.DataSource = EmpresaDAL.LLenar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Estudio", "Empresa No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuEmpresa_Load(object sender, EventArgs e)
        {
            dgvEmpresa.DataSource = EmpresaDAL.LLenar();
            dgvEmpresa.Columns[2].Visible = false;
            dgvEmpresa.Columns[3].Visible = false;
            dgvEmpresa.Columns[4].Visible = false;
            dgvEmpresa.Columns[5].Visible = false;
            dgvEmpresa.Columns[6].Visible = false;
            dgvEmpresa.Columns[7].Visible = false;
            dgvEmpresa.Columns[8].Visible = false;
            dgvEmpresa.Columns[9].Visible = false;
            dgvEmpresa.Columns[10].Visible = false;
            dgvEmpresa.Columns[11].Visible = false;
            dgvEmpresa.Columns[12].Visible = false;

            dgvEmpresa.Columns[0].Width = 80;
            dgvEmpresa.Columns[0].HeaderText = "ID";
            //int n=0;
            //try
            //{
            //    while (n != 1000)
            //    {
            //        MySqlConnection conexion = BdComun.ObtenerConexion();
            //        n++;                   
            //    }
            //}
            //catch (Exception s) { MessageBox.Show(s.Message + "CONECCIONES:" + n.ToString()); }; 
        }

        private void dgvEmpresa_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Form1 menu = new Form1();
            //this.Hide();
            //menu.ShowDialog();
            //this.Show();
            //dgvEmpresa.DataSource = EmpresaDAL.LLenar();
        }

        private void dgvEmpresa_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form1 menu = new Form1();
            this.Hide();
            menu.TITULO = dgvEmpresa.Rows[e.RowIndex].Cells[1].Value.ToString();
            menu.ShowDialog();
            this.Show();
            dgvEmpresa.DataSource = EmpresaDAL.LLenar();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            BackUp back = new BackUp();
            this.Hide();
            back.ShowDialog();
            this.Show();
        }
    }
}
