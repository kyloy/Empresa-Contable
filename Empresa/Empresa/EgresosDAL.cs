using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Empresa
{
    class EgresosDAL
    {
        //Este es el metodo para agregar datos a la base de datos
        public static int Agregar(ClassEgresos pEgresos)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into egresos (Concepto, Pesos, Dolares, Fecha, Clave, empresa, Cheque) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                  pEgresos.Concepto, pEgresos.Pesos, pEgresos.Dolar, pEgresos.Fecha, pEgresos.Clave,pEgresos.Empresa, pEgresos.Cheque), conexion);
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
        public static List<ClassEgresos> LLenar( string Empresa)
        {
            List<ClassEgresos> _lista = new List<ClassEgresos>();
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
               "SELECT idEgresos, Concepto, Pesos, Dolares, Fecha, Clave, Cheque FROM egresos where empresa='{0}'", Empresa), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    ClassEgresos pEgresos = new ClassEgresos();
                    pEgresos.IdEgresos = _reader.GetInt32(0);
                    pEgresos.Concepto = _reader.GetString(1);                    
                    pEgresos.Pesos = _reader.GetInt32(2);
                    pEgresos.Dolar = _reader.GetInt32(3);
                    pEgresos.Fecha = _reader.GetString(4);
                    pEgresos.Clave = _reader.GetString(5);
                    pEgresos.Cheque = _reader.GetString(6);
                    _lista.Add(pEgresos);
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
           "SELECT Concepto FROM egresos Where idEgresos = '{0}'", Dato), conexion);
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
            "SELECT Concepto, Pesos, Dolares, Fecha, Clave, Cheque FROM egresos  where idEgresos ='{0}'", pId), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pEgresos.Concepto = _reader.GetString(0);
                pEgresos.Pesos = _reader.GetInt32(1);
                pEgresos.Dolar = _reader.GetInt32(2);
                pEgresos.Fecha = _reader.GetString(3);
                pEgresos.Clave = _reader.GetString(4);
                pEgresos.Cheque = _reader.GetString(5);            
            }

            conexion.Close();
            return pEgresos;

        }

        public static int Actualizar(ClassEgresos pEgresos)
        {
            int retorno = 0;
            try
            {
                MySqlConnection conexion = BdComun.ObtenerConexion();

                MySqlCommand comando = new MySqlCommand(string.Format("Update egresos set Concepto='{0}', Pesos='{1}', Dolares='{2}', Fecha='{3}', Clave='{4}', Cheque='{6}' where idEgresos='{5}'",
                    pEgresos.Concepto, pEgresos.Pesos, pEgresos.Dolar, pEgresos.Fecha, pEgresos.Clave, pEgresos.IdEgresos, pEgresos.Cheque), conexion);

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
                MySqlCommand comando = new MySqlCommand(string.Format("Delete From Egresos where idEgresos='{0}'", pId), conexion);

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
