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
    public partial class Ingreso_Estudios : Form
    {
        public string NombreEmpresa;
        public Ingreso_Estudios()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdDoctor.Clear();
            txtNombreDoctor.Clear();
            txtPaciente.Clear();
            txtIdEstudio.Clear();
            txtNombreEstudio.Clear();
            //txtPesos.Clear();
            //txtDolar.Clear();
            //txtAdeudo.Clear();
            txtPesos.Text = "0";
            txtDolar.Text = "0";
            txtAdeudo.Text = "0";

            txtIdDoctor.ReadOnly = false;
            txtNombreDoctor.ReadOnly = false;
            txtPaciente.ReadOnly = false;
            txtIdEstudio.ReadOnly = false;
            txtNombreEstudio.ReadOnly = false;
            txtPesos.ReadOnly = false;
            txtDolar.ReadOnly = false;
            txtAdeudo.ReadOnly = false;
            txtIdDoctor.Focus();

            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            btnBuscar.Visible = true;
        }

        private void Ingreso_Estudios_Load(object sender, EventArgs e)
        {
            dgvIngreso_Paciente.DataSource = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
            dgvIngreso_Paciente.Columns[0].Width = 75;
            dgvIngreso_Paciente.Columns[1].Width = 60;
            dgvIngreso_Paciente.Columns[2].Width = 200;
            dgvIngreso_Paciente.Columns[3].Width = 150;
            dgvIngreso_Paciente.Columns[4].Width = 150;
            dgvIngreso_Paciente.Columns[6].Width = 50;
            dgvIngreso_Paciente.Columns[7].Width = 50;
            dgvIngreso_Paciente.Columns[8].Width = 60;
            dgvIngreso_Paciente.Columns[0].HeaderText = "Fecha";
            dgvIngreso_Paciente.Columns[2].HeaderText = "Doctor";
            dgvIngreso_Paciente.Columns[3].HeaderText = "Estudio";
            dgvIngreso_Paciente.Columns[4].HeaderText = "Paciente";
            dgvIngreso_Paciente.Columns[6].HeaderText = "PESOS";
            dgvIngreso_Paciente.Columns[7].HeaderText = "DOLAR";
            dgvIngreso_Paciente.Columns[8].HeaderText = "ADEUDO";
            dgvIngreso_Paciente.Columns[9].Visible = false;
            dgvIngreso_Paciente.Columns[5].Visible = false;
            dgvIngreso_Paciente.Columns[10].Visible = false;
            //dtpFecha.Value = DateTime.Now;
            this.Text = ("INGRESO ESTUDIOS: " + NombreEmpresa);
            //txtPesos.Text = string.Format("{0:#,##0.##}");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtIdDoctor.Clear();
            txtNombreDoctor.Clear();
            txtPaciente.Clear();
            txtIdEstudio.Clear();
            txtNombreEstudio.Clear();
            txtPesos.Text = "0";
            txtDolar.Text = "0";
            txtAdeudo.Text = "0";          

            txtIdDoctor.ReadOnly = true;
            txtNombreDoctor.ReadOnly = true;
            txtPaciente.ReadOnly = true;
            txtIdEstudio.ReadOnly = true;
            txtNombreEstudio.ReadOnly = true;
            txtPesos.ReadOnly = true;
            txtDolar.ReadOnly = true;
            txtAdeudo.ReadOnly = true;

            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            btnBuscar.Visible = false;
            ingre.idDoctor = txtIdDoctor.Text;
            ingre.idEstudio = txtIdEstudio.Text;
            ingre.Nombre_Doctor = txtNombreDoctor.Text;
            ingre.Nombre_Paciente = txtPaciente.Text;
            ingre.Nombre_Estudio = txtNombreEstudio.Text;
            List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
            _lista = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
            ingre.idDoctor = txtIdDoctor.Text;
            _lista.Insert(0, ingre);
            dgvIngreso_Paciente.DataSource = _lista;
            Modificar = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIdEstudio.Text == "")
            {
                txtIdEstudio.Text = "0";
            }
            if (txtAdeudo.Text == "")
                txtAdeudo.Text = "0";
            if (txtPesos.Text == "")
                txtPesos.Text = "0";
            if (txtDolar.Text == "")
                txtDolar.Text = "0";
            if (Modificar == false)
            {
                Ingre_Estudios pingre = new Ingre_Estudios();
                try
                {
                    pingre.idDoctor = txtIdDoctor.Text.Trim();
                    pingre.idEstudio = txtIdEstudio.Text.Trim();
                    pingre.Nombre_Estudio = txtNombreEstudio.Text.Trim();
                    pingre.Nombre_Paciente = txtPaciente.Text.Trim();
                    pingre.Precio_Pesos = Convert.ToInt32(txtPesos.Text.Trim());
                    pingre.Precio_Dolar = Convert.ToInt32(txtDolar.Text.Trim());
                    pingre.Adeudo = Convert.ToInt32(txtAdeudo.Text.Trim());
                    pingre.Empresa = NombreEmpresa;
                    pingre.Fecha = dtpFecha.Value.Year + "-" + dtpFecha.Value.Month + "-" + dtpFecha.Value.Day;


                    int resultado = Ingre_EstudiosDAL.Agregar(pingre);
                    if (resultado > 0)
                    {
                        //MessageBox.Show("Ingreso Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //txtIdDoctor.ReadOnly = true;
                        //txtNombreDoctor.ReadOnly = true;
                        //txtPaciente.ReadOnly = true;
                        //txtIdEstudio.ReadOnly = true;
                        //txtNombreEstudio.ReadOnly = true;
                        //txtPesos.ReadOnly = true;
                        //txtDolar.ReadOnly = true;
                        //txtAdeudo.ReadOnly = true;

                        //btnGuardar.Visible = false;
                        //btnCancelar.Visible = false;
                        dgvIngreso_Paciente.DataSource = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
                        dgvIngreso_Paciente.Columns[0].Width = 75;
                        dgvIngreso_Paciente.Columns[1].Width = 60;
                        dgvIngreso_Paciente.Columns[2].Width = 200;
                        dgvIngreso_Paciente.Columns[3].Width = 150;
                        dgvIngreso_Paciente.Columns[4].Width = 150;
                        dgvIngreso_Paciente.Columns[6].Width = 50;
                        dgvIngreso_Paciente.Columns[7].Width = 50;
                        dgvIngreso_Paciente.Columns[8].Width = 60;
                        dgvIngreso_Paciente.Columns[0].HeaderText = "Fecha";
                        dgvIngreso_Paciente.Columns[2].HeaderText = "Doctor";
                        dgvIngreso_Paciente.Columns[3].HeaderText = "Estudio";
                        dgvIngreso_Paciente.Columns[4].HeaderText = "Paciente";
                        dgvIngreso_Paciente.Columns[6].HeaderText = "PESOS";
                        dgvIngreso_Paciente.Columns[7].HeaderText = "DOLAR";
                        dgvIngreso_Paciente.Columns[8].HeaderText = "ADEUDO";
                        dgvIngreso_Paciente.Columns[9].Visible = false;
                        dgvIngreso_Paciente.Columns[5].Visible = false;
                        //btnBuscar.Visible = false;
                        //txtIdDoctor.Clear();
                        //txtNombreDoctor.Clear();
                        txtPaciente.Clear();
                        //txtIdEstudio.Clear();
                        //txtNombreEstudio.Clear();
                        //txtPesos.Clear();
                        //txtDolar.Clear();
                        //txtAdeudo.Clear();
                        //txtPesos.Text = "0";
                        //txtDolar.Text = "0";
                        //txtAdeudo.Text = "0";
                        txtIdDoctor.Focus();
                        ingre.idDoctor = txtIdDoctor.Text;
                        ingre.idEstudio = txtIdEstudio.Text;
                        ingre.Nombre_Doctor = txtNombreDoctor.Text;
                        ingre.Nombre_Paciente = txtPaciente.Text;
                        ingre.Nombre_Estudio = txtNombreEstudio.Text;
                        //dtpFecha.Value = DateTime.Now;
                    }
                    dgvIngreso_Paciente.CurrentCell = dgvIngreso_Paciente.Rows[dgvIngreso_Paciente.RowCount - 1].Cells[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar El Ingreso", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show(ex.Message);
                }
            }
            #region ACTUALIZAR
            else
            {
                Ingre_Estudios pIngreso = new Ingre_Estudios();

                pIngreso.idIngreso_Estudio = Convert.ToInt32(dgvIngreso_Paciente.CurrentRow.Cells[9].Value);
                pIngreso.idDoctor = txtIdDoctor.Text;
                pIngreso.Nombre_Doctor = txtNombreDoctor.Text;
                pIngreso.idEstudio = txtIdEstudio.Text;
                pIngreso.Nombre_Estudio = txtNombreEstudio.Text;
                pIngreso.Precio_Dolar = Convert.ToInt32(txtDolar.Text);
                pIngreso.Precio_Pesos = Convert.ToInt32(txtPesos.Text);
                pIngreso.Adeudo = Convert.ToInt32(txtAdeudo.Text);
                pIngreso.Fecha = dtpFecha.Value.Year + "-" + dtpFecha.Value.Month + "-" + dtpFecha.Value.Day;
                pIngreso.Empresa = dgvIngreso_Paciente.CurrentRow.Cells[10].Value.ToString();
                pIngreso.Nombre_Paciente = txtPaciente.Text;

                if (Ingre_EstudiosDAL.Actualizar(pIngreso) > 0)
                {
                    MessageBox.Show("Los datos del INGRESO se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvIngreso_Paciente.DataSource = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                txtIdDoctor.ReadOnly = true;
                txtNombreDoctor.ReadOnly = true;
                txtPaciente.ReadOnly = true;
                txtIdEstudio.ReadOnly = true;
                txtNombreEstudio.ReadOnly = true;
                txtPesos.ReadOnly = true;
                txtDolar.ReadOnly = true;
                txtAdeudo.ReadOnly = true;

                btnGuardar.Visible = false;
                btnCancelar.Visible = false;
                btnBuscar.Visible = false;
                Modificar = false;
            }
            #endregion
        }
        //buscar_catalogo buscar = new buscar_catalogo();
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar_catalogo buscar = new buscar_catalogo();
            this.Hide();
            
            buscar.ShowDialog();
            this.Show();
            if (buscar.doctor == true)
            {
                if (buscar.SeleccionDoc != null)
                {
                    txtIdDoctor.Text = buscar.SeleccionDoc.IdDoctor;
                    txtNombreDoctor.Text = buscar.SeleccionDoc.NombreComplet;
                }
            }
            else
            {
                if (buscar.SeleccionEst != null)
                {
                    txtIdEstudio.Text = buscar.SeleccionEst.IdEstudios.ToString();
                    txtNombreEstudio.Text = buscar.SeleccionEst.Descripcion;
                    txtPesos.Text = buscar.SeleccionEst.Precio_Pesos.ToString();
                    txtDolar.Text = buscar.SeleccionEst.Precio_Dolar.ToString();
                    txtAdeudo.Text = buscar.SeleccionEst.Adeudo.ToString();
                }
            }
            txtPaciente.Focus();
        }

        private void dgvIngreso_Paciente_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Modificar == true)
            {
                Ingre_EstudiosDAL ingre = new Ingre_EstudiosDAL();
                ingre.Pasarcampo(dgvIngreso_Paciente, txtIdDoctor, "idDoctor");
                ingre.Pasarcampo(dgvIngreso_Paciente, txtNombreDoctor, "Nombre_Doctor");
                ingre.Pasarcampo(dgvIngreso_Paciente, txtPaciente, "Nombre_Paciente");
                ingre.Pasarcampo(dgvIngreso_Paciente, txtIdEstudio, "idEstudio");
                ingre.Pasarcampo(dgvIngreso_Paciente, txtNombreEstudio, "Nombre_Estudio");
                ingre.Pasarcampo(dgvIngreso_Paciente, txtPesos, "Precio_Pesos");
                ingre.Pasarcampo(dgvIngreso_Paciente, txtDolar, "Precio_Dolar");
                ingre.Pasarcampo(dgvIngreso_Paciente, txtAdeudo, "Adeudo");
                dtpFecha.Value = Convert.ToDateTime(dgvIngreso_Paciente.Rows[dgvIngreso_Paciente.CurrentRow.Index].Cells[0].Value.ToString());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Ingre_Estudios ingre = new Ingre_Estudios();
        private void txtIdDoctor_TextChanged(object sender, EventArgs e)
        {
            if (Modificar == false)
            {
                if (txtIdDoctor.Text.Trim().Length == 7)
                {
                    if (DoctoresDAL.BuscarDoctor(txtIdDoctor.Text.Trim(), 1) != " ")
                        txtNombreDoctor.Text = DoctoresDAL.BuscarDoctor(txtIdDoctor.Text.Trim(), 1);
                }
                if (txtIdDoctor.Text != "" && btnGuardar.Visible == true)
                {
                    List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
                    _lista = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
                    ingre.idDoctor = txtIdDoctor.Text;
                    _lista.Insert(_lista.Count, ingre);
                    dgvIngreso_Paciente.DataSource = _lista;
                    dgvIngreso_Paciente.CurrentCell = dgvIngreso_Paciente.Rows[_lista.Count - 1].Cells[0];
                }
            }
        }

        private void txtIdEstudio_TextChanged(object sender, EventArgs e)
        {
            if (Modificar == false)
            {
                if (txtIdEstudio.Text == "")
                {
                    txtNombreEstudio.Text = "";
                    txtPesos.Text = "0";
                    txtDolar.Text = "0";
                    txtAdeudo.Text = "0";
                }
                Estudios pEstudio = EstudiosDAL.BuscarEstudio(txtIdEstudio.Text.Trim(), 1);
                if (pEstudio.Descripcion != null)
                {
                    txtNombreEstudio.Text = pEstudio.Descripcion;
                    txtPesos.Text = pEstudio.Precio_Pesos.ToString();
                    txtDolar.Text = pEstudio.Precio_Dolar.ToString();
                    txtAdeudo.Text = pEstudio.Adeudo.ToString();
                }
                if (txtIdEstudio.Text != "" && btnGuardar.Visible == true)
                {
                    List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
                    _lista = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
                    ingre.idEstudio = txtIdEstudio.Text;
                    _lista.Insert(_lista.Count, ingre);
                    dgvIngreso_Paciente.DataSource = _lista;
                    dgvIngreso_Paciente.CurrentCell = dgvIngreso_Paciente.Rows[_lista.Count - 1].Cells[0];
                }
            }
        }

        #region KEYDOWN

        private void Ingreso_Estudios_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            { btnBuscar.PerformClick(); }
            else if (e.KeyData == Keys.F5)
            {
                Catalogo_Doctores cat = new Catalogo_Doctores();
                cat.IngresoEst = true;
                cat.ShowDialog();
                this.txtIdDoctor.Text = cat.idDic;
            }
        }

        private void txtAdeudo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            { btnBuscar.PerformClick(); }
            else if (e.KeyData == Keys.F5)
            {
                Catalogo_Doctores cat = new Catalogo_Doctores();
                cat.IngresoEst = true;
                cat.ShowDialog();
                this.txtIdDoctor.Text = cat.idDic;
            }
            else if (e.KeyData==Keys.Enter)
            {
                txtIdDoctor.Focus();
            }
        }

        private void dgvIngreso_Paciente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            { btnBuscar.PerformClick(); }
            else if (e.KeyData == Keys.F5)
            {
                Catalogo_Doctores cat = new Catalogo_Doctores();
                cat.IngresoEst = true;
                cat.ShowDialog();
                this.txtIdDoctor.Text = cat.idDic;
            }
        }

        private void btnNuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            { btnBuscar.PerformClick(); }
            else if (e.KeyData == Keys.F5)
            {
                Catalogo_Doctores cat = new Catalogo_Doctores();
                cat.IngresoEst = true;
                cat.ShowDialog();
                this.txtIdDoctor.Text = cat.idDic;
            }
        }

        private void dtpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            { btnBuscar.PerformClick(); }
            else if (e.KeyData == Keys.F5)
            {
                Catalogo_Doctores cat = new Catalogo_Doctores();
                cat.IngresoEst = true;
                cat.ShowDialog();
                this.txtIdDoctor.Text = cat.idDic;
            }
        }

        private void txtIdDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            { btnBuscar.PerformClick(); }
            else if (e.KeyData == Keys.F5)
            {
                Catalogo_Doctores cat = new Catalogo_Doctores();
                cat.IngresoEst = true;
                cat.ShowDialog();
                this.txtIdDoctor.Text = cat.idDic;
            }
            else if (e.KeyData == Keys.Enter)
            {
                if (txtNombreDoctor.Text != "")
                    txtPaciente.Focus();
                else
                    txtNombreDoctor.Focus();
            }
        }

        private void txtIdEstudio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            { btnBuscar.PerformClick(); }
            else if (e.KeyData == Keys.F5)
            {
                Catalogo_Doctores cat = new Catalogo_Doctores();
                cat.IngresoEst = true;
                cat.ShowDialog();
                this.txtIdDoctor.Text = cat.idDic;
            }
            else if (e.KeyData == Keys.Enter)
            {
                txtNombreEstudio.Focus();
            }
        }

        private void txtDolar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            { btnBuscar.PerformClick(); }
            else if (e.KeyData == Keys.F5)
            {
                Catalogo_Doctores cat = new Catalogo_Doctores();
                cat.IngresoEst = true;
                cat.ShowDialog();
                this.txtIdDoctor.Text = cat.idDic;
            }
            else if (e.KeyData == Keys.Enter)
            {
                txtAdeudo.Focus();
            }
        }

        private void txtPesos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            { btnBuscar.PerformClick(); }
            else if (e.KeyData == Keys.F5)
            {
                Catalogo_Doctores cat = new Catalogo_Doctores();
                cat.IngresoEst = true;
                cat.ShowDialog();
                this.txtIdDoctor.Text = cat.idDic;
            }
            else if (e.KeyData == Keys.Enter)
            {
                txtDolar.Focus();
            }
        }
        private void txtNombreDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            { btnBuscar.PerformClick(); }
            else if (e.KeyData == Keys.F5)
            {
                Catalogo_Doctores cat = new Catalogo_Doctores();
                cat.IngresoEst = true;
                cat.ShowDialog();
                this.txtIdDoctor.Text = cat.idDic;
            }
            else if (e.KeyData == Keys.Enter)
            {
                txtPaciente.Focus();
            }
        }

        private void txtPaciente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            { btnBuscar.PerformClick(); }
            else if (e.KeyData == Keys.F5)
            {
                Catalogo_Doctores cat = new Catalogo_Doctores();
                cat.IngresoEst = true;
                cat.ShowDialog();
                this.txtIdDoctor.Text = cat.idDic;
            }
            else if (e.KeyData == Keys.Enter)
            {
                txtIdEstudio.Focus();
            }
        }

        private void txtNombreEstudio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 && btnGuardar.Visible == true)
            { btnGuardar.PerformClick(); }
            else if (e.KeyData == Keys.F4 && btnBuscar.Visible == true)
            { btnBuscar.PerformClick(); }
            else if (e.KeyData == Keys.F5)
            {
                Catalogo_Doctores cat = new Catalogo_Doctores();
                cat.IngresoEst = true;
                cat.ShowDialog();
                this.txtIdDoctor.Text = cat.idDic;
            }
            else if (e.KeyData == Keys.Enter)
            {
                txtPesos.Focus();
            }
        }

        #endregion

        private void txtNombreDoctor_TextChanged(object sender, EventArgs e)
        {
            if (Modificar == false)
            {
                if (txtNombreDoctor.Text != "" && btnGuardar.Visible == true)
                {
                    List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
                    _lista = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
                    ingre.Nombre_Doctor = txtNombreDoctor.Text;
                    _lista.Insert(_lista.Count, ingre);
                    dgvIngreso_Paciente.DataSource = _lista;
                    dgvIngreso_Paciente.CurrentCell = dgvIngreso_Paciente.Rows[_lista.Count - 1].Cells[0];
                }
            }
        }

        private void txtNombreEstudio_TextChanged(object sender, EventArgs e)
        {
            if (Modificar == false)
            {
                if (txtNombreEstudio.Text != "" && btnGuardar.Visible == true)
                {
                    List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
                    _lista = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
                    ingre.Nombre_Estudio = txtNombreEstudio.Text;
                    _lista.Insert(_lista.Count, ingre);
                    dgvIngreso_Paciente.DataSource = _lista;
                    dgvIngreso_Paciente.CurrentCell = dgvIngreso_Paciente.Rows[_lista.Count - 1].Cells[0];
                }
            }
        }

        private void dtpFecha_Validating(object sender, CancelEventArgs e)
        {
            //if (dtpFecha.Value >= DateTime.Today)
            //{
            //    MessageBox.Show("NO PUEDES SELECCIONAR FECHAS FUTURAS");
            //}
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (Modificar == false)
            {
                if (dtpFecha.Value > DateTime.Today)
                {
                    MessageBox.Show("NO PUEDES SELECCIONAR FECHAS FUTURAS");
                    dtpFecha.Value = DateTime.Today;
                }
                List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
                _lista = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
                ingre.Fecha = dtpFecha.Value.Year + "-" + dtpFecha.Value.Month + "-" + dtpFecha.Value.Day;
                _lista.Insert(_lista.Count, ingre);
                dgvIngreso_Paciente.DataSource = _lista;
                dgvIngreso_Paciente.CurrentCell = dgvIngreso_Paciente.Rows[_lista.Count - 1].Cells[0];
            }
        }

       
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el INGRESO Actual", "Estas Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ingre_EstudiosDAL.Eliminar(Convert.ToInt32(dgvIngreso_Paciente.CurrentRow.Cells[9].Value)) > 0)
                {
                    MessageBox.Show("INGRESO Eliminado Correctamente!", "INGRESO Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvIngreso_Paciente.DataSource = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
                    dgvIngreso_Paciente.Columns[0].Width = 75;
                    dgvIngreso_Paciente.Columns[1].Width = 60;
                    dgvIngreso_Paciente.Columns[2].Width = 200;
                    dgvIngreso_Paciente.Columns[3].Width = 150;
                    dgvIngreso_Paciente.Columns[4].Width = 150;
                    dgvIngreso_Paciente.Columns[6].Width = 50;
                    dgvIngreso_Paciente.Columns[7].Width = 50;
                    dgvIngreso_Paciente.Columns[8].Width = 60;
                    dgvIngreso_Paciente.Columns[0].HeaderText = "Fecha";
                    dgvIngreso_Paciente.Columns[2].HeaderText = "Doctor";
                    dgvIngreso_Paciente.Columns[3].HeaderText = "Estudio";
                    dgvIngreso_Paciente.Columns[4].HeaderText = "Paciente";
                    dgvIngreso_Paciente.Columns[6].HeaderText = "PESOS";
                    dgvIngreso_Paciente.Columns[7].HeaderText = "DOLAR";
                    dgvIngreso_Paciente.Columns[8].HeaderText = "ADEUDO";
                    dgvIngreso_Paciente.Columns[9].Visible = false;
                    dgvIngreso_Paciente.Columns[5].Visible = false;
                  
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el INGRESO", "INGRESO No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txtIdDoctor.Clear();
            txtNombreDoctor.Clear();
            txtPaciente.Clear();
            txtIdEstudio.Clear();
            txtNombreEstudio.Clear();
            txtPesos.Text = "0";
            txtDolar.Text = "0";
            txtAdeudo.Text = "0";   
            ingre.idDoctor = txtIdDoctor.Text;
            ingre.idEstudio = txtIdEstudio.Text;
            ingre.Nombre_Doctor = txtNombreDoctor.Text;
            ingre.Nombre_Paciente = txtPaciente.Text;
            ingre.Nombre_Estudio = txtNombreEstudio.Text;
            List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
            _lista = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
            ingre.idDoctor = txtIdDoctor.Text;
            _lista.Insert(0, ingre);
            dgvIngreso_Paciente.DataSource = _lista;
            dgvIngreso_Paciente.CurrentCell = dgvIngreso_Paciente.Rows[_lista.Count - 1].Cells[0];
        }

        private void txtPaciente_TextChanged(object sender, EventArgs e)
        {
            if (Modificar == false)
            {
                if (txtPaciente.Text != "" && btnGuardar.Visible == true)
                {
                    List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
                    _lista = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
                    ingre.Nombre_Paciente = txtPaciente.Text;
                    _lista.Insert(_lista.Count, ingre);
                    dgvIngreso_Paciente.DataSource = _lista;
                    dgvIngreso_Paciente.CurrentCell = dgvIngreso_Paciente.Rows[_lista.Count - 1].Cells[0];
                }
            }
        }

        private void txtPesos_TextChanged(object sender, EventArgs e)
        {        
            if (Modificar == false)
            {
                if (txtPesos.Text != "")
                {
                    //float myvariable = Convert.ToSingle(txtPesos.Text);
                    //txtPesos.Text = myvariable.ToString("###,###,##0.#0");
                    if (btnGuardar.Visible == true)
                    {
                        List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
                        _lista = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
                        ingre.Precio_Pesos = Convert.ToInt32(txtPesos.Text);
                        _lista.Insert(_lista.Count, ingre);
                        dgvIngreso_Paciente.DataSource = _lista;
                        dgvIngreso_Paciente.CurrentCell = dgvIngreso_Paciente.Rows[_lista.Count - 1].Cells[0];
                    }
                }
            }
        }

        private void txtDolar_TextChanged(object sender, EventArgs e)
        {
            if (Modificar == false)
            {
                if (txtDolar.Text != "")
                {
                    if (btnGuardar.Visible == true)
                    {
                        List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
                        _lista = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
                        ingre.Precio_Dolar = Convert.ToInt32(txtDolar.Text);
                        _lista.Insert(_lista.Count, ingre);
                        dgvIngreso_Paciente.DataSource = _lista;
                        dgvIngreso_Paciente.CurrentCell = dgvIngreso_Paciente.Rows[_lista.Count - 1].Cells[0];
                    }
                }
            }
        }

        private void txtAdeudo_TextChanged(object sender, EventArgs e)
        {
            if (Modificar == false)
            {
                if (txtAdeudo.Text != "")
                {
                    if (btnGuardar.Visible == true)
                    {
                        List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
                        _lista = Ingre_EstudiosDAL.LLenar(NombreEmpresa);
                        ingre.Adeudo = Convert.ToInt32(txtAdeudo.Text);
                        _lista.Insert(_lista.Count, ingre);
                        dgvIngreso_Paciente.DataSource = _lista;
                        dgvIngreso_Paciente.CurrentCell = dgvIngreso_Paciente.Rows[_lista.Count - 1].Cells[0];
                    }
                }
            }
        }

        private void txtPesos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDolar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtAdeudo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        bool Modificar = false;
        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtIdDoctor.ReadOnly = false;
            txtNombreDoctor.ReadOnly = false;
            txtPaciente.ReadOnly = false;
            txtIdEstudio.ReadOnly = false;
            txtNombreEstudio.ReadOnly = false;
            txtPesos.ReadOnly = false;
            txtDolar.ReadOnly = false;
            txtAdeudo.ReadOnly = false;
            txtIdDoctor.Focus();
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            Modificar = true;
        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            Catalogo_Doctores cat = new Catalogo_Doctores();
            cat.IngresoEst = true;
            cat.ShowDialog();
            this.txtIdDoctor.Text = cat.idDic;
        }

        private void txtIdEstudio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                //MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFiltro1.Value.Month > 9)
                {
                    if (dtpFiltro1.Value.Day > 9)
                    {
                        dgvIngreso_Paciente.DataSource = Ingre_EstudiosDAL.LLenarFiltro(NombreEmpresa, dtpFiltro1.Value.Year.ToString(), dtpFiltro1.Value.Month.ToString() + "/" + dtpFiltro1.Value.Day.ToString());
                    }
                    else
                    {
                        dgvIngreso_Paciente.DataSource = Ingre_EstudiosDAL.LLenarFiltro(NombreEmpresa, dtpFiltro1.Value.Year.ToString(), dtpFiltro1.Value.Month.ToString() + "/" + "0" + dtpFiltro1.Value.Day.ToString());
                    }
                }
                else
                {
                    if (dtpFiltro1.Value.Day > 9)
                    {
                        dgvIngreso_Paciente.DataSource = Ingre_EstudiosDAL.LLenarFiltro(NombreEmpresa, dtpFiltro1.Value.Year.ToString(), "0" + dtpFiltro1.Value.Month.ToString() + "/" + dtpFiltro1.Value.Day.ToString());
                    }
                    else
                    {
                        dgvIngreso_Paciente.DataSource = Ingre_EstudiosDAL.LLenarFiltro(NombreEmpresa, dtpFiltro1.Value.Year.ToString(), "0" + dtpFiltro1.Value.Month.ToString() + "/" + "0" + dtpFiltro1.Value.Day.ToString());
                    }
                }
                dgvIngreso_Paciente.CurrentCell = dgvIngreso_Paciente.Rows[0].Cells[0];
            }
            catch { }
                BuscarID();
        }

        private void txtCancelFiltro_Click(object sender, EventArgs e)
        {
            dgvIngreso_Paciente.DataSource = Ingre_EstudiosDAL.LLenar(NombreEmpresa);            
            txtNombreBuscar.Clear();            
        }

        int rowIndex;
        public void BuscarID()
        {
            try
            {
                dgvIngreso_Paciente.Rows[rowIndex].Selected = false;
                dgvIngreso_Paciente.CurrentCell = dgvIngreso_Paciente.Rows[rowIndex].Cells[1];
                if (txtNombreBuscar.Text != "")
                {
                    //dgvIngreso_Paciente.DataSource = DoctoresDAL.Buscar(txtBuscar.Text, 1);
                    foreach (DataGridViewRow row in dgvIngreso_Paciente.Rows)
                    {
                        if (row.Cells[1].Value.ToString().Length >= txtNombreBuscar.Text.Length)
                        {
                            if (row.Cells[1].Value.ToString().Substring(0, txtNombreBuscar.Text.Length).Equals(txtNombreBuscar.Text))
                            {
                                rowIndex = row.Index;
                                dgvIngreso_Paciente.Rows[rowIndex].Selected = true;
                                dgvIngreso_Paciente.CurrentCell = dgvIngreso_Paciente.Rows[rowIndex].Cells[1];
                                rowIndex = 0;
                                break;
                            }
                        }
                    }
                }                
            }
            catch { rowIndex = 0; }
        }

        private void btnLimpiarIngreso_Click(object sender, EventArgs e)
        {
            LimpiarIngresos limp = new LimpiarIngresos();
            this.Hide();
            limp.Empresa = NombreEmpresa;
            limp.ShowDialog();
            this.Show();
        }
        
    }
}
