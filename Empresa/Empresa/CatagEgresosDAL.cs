using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Empresa
{
    class CatagEgresosDAL
    {
        //Este es el metodo para agregar datos a la base de datos
        public static int Agregar(CatagEgresos pEgresos)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into catalogo_egresos (Clave, Descripcion) values ('{0}','{1}')",
                  pEgresos.Clave, pEgresos.Descripcion), conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
                return retorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();
                return retorno;
            }           
        }

        public void Pasarcampo(DataGridView midgv, TextBox txb, string columna)
        {
            // especifico que campo de la fila que este seleccionada vamos a pasar al textbox
            try
            {
                txb.Text = midgv.Rows[midgv.CurrentRow.Index].Cells[columna].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Con este metodo llenamos nuestro datagrindview con la base de datos
        public static List<CatagEgresos> LLenar()
        {
            List<CatagEgresos> _lista = new List<CatagEgresos>();
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
               "SELECT idcatalogo_egresos, Clave, Descripcion FROM catalogo_egresos "), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    CatagEgresos pEgresos = new CatagEgresos();
                    pEgresos.idCatalogo_Egresos = _reader.GetInt32(0);
                    pEgresos.Clave = _reader.GetString(1);
                    pEgresos.Descripcion = _reader.GetString(2);                    
                    _lista.Add(pEgresos);
                }
                conexion.Close();
                return _lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();
                return _lista;
            }
        }
         //Con este metodo se actualiza los datos de algun registro
        public static int Actualizar(CatagEgresos pEgresos)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Update catalogo_egresos set Clave='{0}', Descripcion='{1}' where idcatalogo_egresos='{2}'",
                    pEgresos.Clave, pEgresos.Descripcion, pEgresos.idCatalogo_Egresos), conexion);

                retorno = comando.ExecuteNonQuery();
                conexion.Close();
                return retorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();
                return retorno;
            }
        }
        public static string Buscar(string Dato)
        {
            string Concepto = "";
            MySqlConnection conexion = BdComun.ObtenerConexion();
            //IDDOCTOR
            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT Descripcion FROM catalogo_egresos Where Clave = '{0}'", Dato), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Concepto = _reader.GetString(0);
            }
            conexion.Close();
            return Concepto;
        }

        //Con este metodo eliminamos registros
        public static int Eliminar(int pId)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Delete From catalogo_egresos where idcatalogo_egresos='{0}'", pId), conexion);

                retorno = comando.ExecuteNonQuery();
                conexion.Close();
                return retorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();
                return retorno;
            }
        }
    }
}
