using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Empresa
{
    class EstudiosDAL
    {
        //Este es el metodo para agregar datos a la base de datos
        public static int Agregar(Estudios pEstudios)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into estudios (idEstudios, Descripcion, Precio_pesos, Precio_dolar, Adeudo) values ('{0}','{1}','{2}','{3}','{4}');",
                    pEstudios.IdEstudios, pEstudios.Descripcion, pEstudios.Precio_Pesos, pEstudios.Precio_Dolar, pEstudios.Adeudo), conexion);
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

        //Con este metodo llenamos nuestro datagrindview con la base de datos
        public static List<Estudios> LLenar()
        {
            List<Estudios> _lista = new List<Estudios>();
            MySqlConnection conexion = BdComun.ObtenerConexion();
            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT idEstudios, Descripcion, Precio_pesos, Precio_dolar, Adeudo FROM estudios"), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Estudios pEstudios = new Estudios();
                pEstudios.IdEstudios = _reader.GetInt32(0);
                pEstudios.Descripcion = _reader.GetString(1);
                pEstudios.Precio_Pesos = _reader.GetInt32(2);
                pEstudios.Precio_Dolar = _reader.GetInt32(3);
                pEstudios.Adeudo = _reader.GetInt32(4);

                _lista.Add(pEstudios);
            }
            conexion.Close();
            return _lista;
        }

        //Con este metodo buscaremos datos en nuestra base de datos
        public static List<Estudios> Buscar(string dato, int opcion)
        {
            List<Estudios> _lista = new List<Estudios>();
            MySqlConnection conexion = BdComun.ObtenerConexion();
            if (opcion == 1)
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
               "SELECT idEstudios, Descripcion, Precio_pesos, Precio_dolar, Adeudo FROM estudios ORDER BY idEstudios"), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    Estudios pEstudios = new Estudios();
                    pEstudios.IdEstudios = _reader.GetInt32(0);
                    pEstudios.Descripcion = _reader.GetString(1);
                    pEstudios.Precio_Pesos = _reader.GetInt32(2);
                    pEstudios.Precio_Dolar = _reader.GetInt32(3);
                    pEstudios.Adeudo = _reader.GetInt32(4);

                    _lista.Add(pEstudios);
                }
                conexion.Close();
            }
            else if (opcion == 2)
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
               "SELECT idEstudios, Descripcion, Precio_pesos, Precio_dolar, Adeudo FROM estudios ORDER BY Descripcion"), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    Estudios pEstudios = new Estudios();
                    pEstudios.IdEstudios = _reader.GetInt32(0);
                    pEstudios.Descripcion = _reader.GetString(1);
                    pEstudios.Precio_Pesos = _reader.GetInt32(2);
                    pEstudios.Precio_Dolar = _reader.GetInt32(3);
                    pEstudios.Adeudo = _reader.GetInt32(4);

                    _lista.Add(pEstudios);
                }
                conexion.Close();
            }
            conexion.Close();
            return _lista;
        }

        public static Estudios BuscarEstudio(string Dato, int opcion)
        {
            //string Nombre = " ";
            //string ID = " ";
            Estudios pEstudios = new Estudios();
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                if (opcion == 1)
                {
                    //IDEstudio
                    MySqlCommand _comando = new MySqlCommand(String.Format(
                   "SELECT Descripcion, Precio_pesos, Precio_dolar, Adeudo FROM estudios Where idEstudios = '{0}'", Dato), conexion);
                    MySqlDataReader _reader = _comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        pEstudios.Descripcion = _reader.GetString(0);
                        pEstudios.Precio_Pesos = Convert.ToInt32(_reader.GetString(1));
                        pEstudios.Precio_Dolar = Convert.ToInt32(_reader.GetString(2));
                        pEstudios.Adeudo = Convert.ToInt32(_reader.GetString(3));
                    }
                    conexion.Close();                    
                }
                return pEstudios;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); conexion.Close(); return pEstudios; }
        }

        //Con este metodo seleccionamos la empresa que estamos buscando
        public static Estudios ObtenerEstudio(int pId)
        {
            Estudios pEstudios = new Estudios();
            MySqlConnection conexion = BdComun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format(
            "SELECT idEstudios, Descripcion, Precio_pesos, Precio_dolar, Adeudo FROM estudios where idEstudios ='{0}'", pId), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pEstudios.IdEstudios = _reader.GetInt32(0);
                pEstudios.Descripcion = _reader.GetString(1);
                pEstudios.Precio_Pesos = _reader.GetInt32(2);
                pEstudios.Precio_Dolar = _reader.GetInt32(3);
                pEstudios.Adeudo = _reader.GetInt32(4);
            }
            conexion.Close();
            return pEstudios;

        }

        public static int Actualizar(Estudios pEstudios)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update estudios set Descripcion='{0}', Precio_pesos='{1}', Precio_dolar='{2}', Adeudo='{3}' where idEstudios={4};",
                 pEstudios.Descripcion, pEstudios.Precio_Pesos, pEstudios.Precio_Dolar, pEstudios.Adeudo, pEstudios.IdEstudios), conexion);

            retorno = comando.ExecuteNonQuery();
            #region Guardar datos en backup
            using (System.IO.StreamWriter file =
       new System.IO.StreamWriter(@"C:\Backup\EmpresaBackup.txt", true))
            {
                file.WriteLine(comando.CommandText);
            }
            #endregion
            conexion.Close();

            return retorno;

        }

        public static int Eliminar(int pId)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Delete From estudios where idEstudios={0};", pId), conexion);

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

        public void Pasarcampo(DataGridView midgv, TextBox txt, string columna)
        {
            // especifico que campo de la fila que este seleccionada vamos a pasar al textbox

            txt.Text = midgv.Rows[midgv.CurrentRow.Index].Cells[columna].Value.ToString();

        }
    }
}
