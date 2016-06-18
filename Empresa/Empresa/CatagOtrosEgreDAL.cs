using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Empresa
{
    class CatagOtrosEgreDAL
    {
        //Este es el metodo para agregar datos a la base de datos
        public static int Agregar(CatagOtrosEgre pOtros)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into catalogo_otros (Clave, Descripcion) values ('{0}','{1}');",
                  pOtros.Clave, pOtros.Descripcion), conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
                #region Guardar datos en backup
                using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"C:\Backup\EmpresaBackup.txt", true))
                {
                    file.WriteLine(comando.CommandText);
                }
                #endregion
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
        public static List<CatagOtrosEgre> LLenar()
        {
            List<CatagOtrosEgre> _lista = new List<CatagOtrosEgre>();
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
               "SELECT idcatalogo_otros, Clave, Descripcion FROM catalogo_otros "), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    CatagOtrosEgre pOtros = new CatagOtrosEgre();
                    pOtros.idCatalogo_OtrosEgresos = _reader.GetInt32(0);
                    pOtros.Clave = _reader.GetString(1);
                    pOtros.Descripcion = _reader.GetString(2);
                    _lista.Add(pOtros);
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
        public static int Actualizar(CatagOtrosEgre pOtros)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Update catalogo_otros set Clave='{0}', Descripcion='{1}' where idcatalogo_otros='{2}';",
                    pOtros.Clave, pOtros.Descripcion, pOtros.idCatalogo_OtrosEgresos), conexion);

                retorno = comando.ExecuteNonQuery();
                conexion.Close();
                #region Guardar datos en backup
                using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"C:\Backup\EmpresaBackup.txt", true))
                {
                    file.WriteLine(comando.CommandText);
                }
                #endregion
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
           "SELECT Descripcion FROM catalogo_otros Where Clave = '{0}'", Dato), conexion);
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
                MySqlCommand comando = new MySqlCommand(string.Format("Delete From catalogo_otros where idcatalogo_otros='{0}';", pId), conexion);

                retorno = comando.ExecuteNonQuery();
                conexion.Close();
                #region Guardar datos en backup
                using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"C:\Backup\EmpresaBackup.txt", true))
                {
                    file.WriteLine(comando.CommandText);
                }
                #endregion
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
