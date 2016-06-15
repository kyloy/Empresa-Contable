using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Empresa
{
    class OtrosEgresosDAL
    {
        //Este es el metodo para agregar datos a la base de datos
        public static int Agregar(ClassOtrosEgre pOtros)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into otros_ingresos (Concepto, Pesos, Dolares, Fecha, Clave, empresa) values ('{0}','{1}','{2}','{3}','{4}','{5}')",
                  pOtros.Concepto, pOtros.Pesos, pOtros.Dolar, pOtros.Fecha, pOtros.Clave, pOtros.Empresa), conexion);
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
        public static List<ClassOtrosEgre> LLenar(string Empresa)
        {
            List<ClassOtrosEgre> _lista = new List<ClassOtrosEgre>();
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
               "SELECT idotros_ingresos, Concepto, Pesos, Dolares, Fecha, Clave FROM otros_ingresos where empresa='{0}'", Empresa), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    ClassOtrosEgre pOtros = new ClassOtrosEgre();
                    pOtros.idOtros = _reader.GetInt32(0);
                    pOtros.Concepto = _reader.GetString(1);
                    pOtros.Pesos = _reader.GetInt32(2);
                    pOtros.Dolar = _reader.GetInt32(3);
                    pOtros.Fecha = _reader.GetString(4);
                    pOtros.Clave = _reader.GetString(5);                    
                    _lista.Add(pOtros);
                }
                conexion.Close();
                return _lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return _lista;
            }
        }

        //Con este metodo buscaremos datos en nuestra base de datos
        public static string Buscar(string Dato)
        {
            string Concepto = "";
            MySqlConnection conexion = BdComun.ObtenerConexion();
            //IDDOCTOR
            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT Concepto FROM otros_ingresos Where idotros_ingresos = '{0}'", Dato), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Concepto = _reader.GetString(0);
            }
            conexion.Close();
            return Concepto;
        }

        //Con este metodo seleccionamos la empresa que estamos buscando
        public static ClassEgresos ObtenerEgreso(int pId)
        {
            ClassEgresos pEgresos = new ClassEgresos();
            MySqlConnection conexion = BdComun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format(
            "SELECT Concepto, Pesos, Dolares, Fecha, Clave FROM otros_ingresos  where idotros_ingresos ='{0}'", pId), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pEgresos.Concepto = _reader.GetString(0);
                pEgresos.Pesos = _reader.GetInt32(1);
                pEgresos.Dolar = _reader.GetInt32(2);
                pEgresos.Fecha = _reader.GetString(3);
                pEgresos.Clave = _reader.GetString(4);                
            }

            conexion.Close();
            return pEgresos;

        }

        public static int Actualizar(ClassOtrosEgre pOtros)
        {
            int retorno = 0;
            try
            {
                MySqlConnection conexion = BdComun.ObtenerConexion();

                MySqlCommand comando = new MySqlCommand(string.Format("Update otros_ingresos set Concepto='{0}', Pesos='{1}', Dolares='{2}', Fecha='{3}', Clave='{4}' where idotros_ingresos='{5}'",
                    pOtros.Concepto, pOtros.Pesos, pOtros.Dolar, pOtros.Fecha, pOtros.Clave, pOtros.idOtros), conexion);

                retorno = comando.ExecuteNonQuery();
                conexion.Close();
                return retorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return retorno;
            }
        }

        public static int Eliminar(int pId)
        {
            int retorno = 0;
            try
            {
                MySqlConnection conexion = BdComun.ObtenerConexion();
                MySqlCommand comando = new MySqlCommand(string.Format("Delete From otros_ingresos where idotros_ingresos='{0}'", pId), conexion);

                retorno = comando.ExecuteNonQuery();
                conexion.Close();
                return retorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return retorno;
            }
        }
    }
}
