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
    public partial class SelectConMensual : Form
    {
        public string Empresa;
        public SelectConMensual()
        {
            InitializeComponent();
        }
        public void Generar(string Mes, string year)
        {
            int retorno = 0;
            int n = 0;            
            if (Mes == "01" || Mes == "03" || Mes == "05" || Mes == "07" || Mes == "08" || Mes == "10" || Mes == "12")
            {
                n = 31;
            }
            else if(Mes=="02")
            {
                if (year == "2016" || year == "2020")
                    n = 29;
                else
                    n = 28;
            }
            else
            {
                n = 30;
            }
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                for(int i=1; i<=n; i++)
                {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into fechas_temp values ('{0}', '{1}-{2}-{3}')",
                    i,year,Mes,i), conexion);
                retorno = comando.ExecuteNonQuery();                  
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();                
            }
            conexion.Close();
        }
        //DELETE FROM `empresa`.`fechas_temp` WHERE `idFechas_temp`='1';
        public void Vaciar()
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                for(int i=1; i<=31; i++)
                {
                MySqlCommand comando = new MySqlCommand(string.Format("DELETE FROM fechas_temp WHERE idFechas_temp='{0}'",
                    i), conexion);
                retorno = comando.ExecuteNonQuery();                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();                
            }
            conexion.Close();
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            #region Llamar al metodo Generar
            switch (comboBox1.Text)
            {
                case "ENERO":
                    Generar("01", comboBox2.Text);
                    break;
                case "FEBRERO":
                    Generar("02", comboBox2.Text);
                    break;
                case "MARZO":
                    Generar("03", comboBox2.Text);
                    break;
                case "ABRIL":
                    Generar("04", comboBox2.Text);
                    break;
                case "MAYO":
                    Generar("05", comboBox2.Text);
                    break;
                case "JUNIO":
                    Generar("06", comboBox2.Text);
                    break;
                case "JULIO":
                    Generar("07", comboBox2.Text);
                    break;
                case "AGOSTO":
                    Generar("08", comboBox2.Text);
                    break;
                case "SEPTIEMBRE":
                    Generar("09", comboBox2.Text);
                    break;
                case "OCTUBRE":
                    Generar("10", comboBox2.Text);
                    break;
                case "NOVIEMBRE":
                    Generar("11", comboBox2.Text);
                    break;
                case "DICIEMBRE":
                    Generar("12", comboBox2.Text);
                    break;
            }
            #endregion
            if (Empresa == "ORTOIMAGEN")
            {
                ReporteConMensual rep = new ReporteConMensual();
                this.Hide();
                rep.Empresa = Empresa;
                rep.ShowDialog();
                this.Show();
                Vaciar();
            }
            else
            {
                diagnosticoConMensual rep = new diagnosticoConMensual();
                this.Hide();
                rep.Empresa = Empresa;
                rep.ShowDialog();
                this.Show();
                Vaciar();
            }
        }
    }
}
