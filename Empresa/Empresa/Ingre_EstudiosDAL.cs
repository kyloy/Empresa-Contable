using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Empresa
{
    class Ingre_EstudiosDAL
    {
        //Este es el metodo para agregar datos a la base de datos
        public static int Agregar(Ingre_Estudios pIngreso_estu)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into ingreso_estudios (Nombre_Paciente, id_Doctor, id_Estudio, Descripcion, Fecha, Precio_Pesos, Precio_Dolar, Adeudo, Empresa ) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');",
                   pIngreso_estu.Nombre_Paciente, pIngreso_estu.idDoctor, pIngreso_estu.idEstudio, pIngreso_estu.Nombre_Estudio, pIngreso_estu.Fecha, pIngreso_estu.Precio_Pesos, pIngreso_estu.Precio_Dolar, pIngreso_estu.Adeudo, pIngreso_estu.Empresa), conexion);
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Con este metodo llenamos nuestro datagrindview con la base de datos
        public static List<Ingre_Estudios> LLenar(string Empresa)
        {
            List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
               "SELECT  ingreso_estudios.idingreso_estudios, ingreso_estudios.Nombre_Paciente, ingreso_estudios.id_Doctor, ingreso_estudios.id_Estudio, ingreso_estudios.Fecha, ingreso_estudios.Precio_Pesos, ingreso_estudios.Precio_Dolar, concat_ws(' ', doctores.Nombre, doctores.Apellido_paterno, doctores.Apellido_materno) as Nombre_Doctor, ingreso_estudios.Descripcion, ingreso_estudios.Adeudo, ingreso_estudios.Empresa FROM ingreso_estudios LEFT JOIN doctores ON ingreso_estudios.id_Doctor = doctores.idDoctor LEFT JOIN estudios on ingreso_estudios.id_Estudio = estudios.idEstudios WHERE ingreso_estudios.Empresa ='{0}' ORDER BY Fecha", Empresa), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    Ingre_Estudios pIngreso_Estu = new Ingre_Estudios();                    
                    pIngreso_Estu.idIngreso_Estudio = _reader.GetInt32(0);
                    pIngreso_Estu.Nombre_Paciente = _reader.GetString(1);                    
                    pIngreso_Estu.idDoctor = _reader.GetString(2);
                    pIngreso_Estu.idEstudio = _reader.GetString(3);
                    pIngreso_Estu.Fecha = _reader.GetString(4);
                    pIngreso_Estu.Precio_Pesos = _reader.GetInt32(5);
                    pIngreso_Estu.Precio_Dolar = _reader.GetInt32(6);
                    pIngreso_Estu.Nombre_Doctor = _reader.GetString(7);
                    pIngreso_Estu.Nombre_Estudio = _reader.GetString(8);
                    pIngreso_Estu.Adeudo = _reader.GetInt32(9);
                    pIngreso_Estu.Empresa = _reader.GetString(10);

                    _lista.Add(pIngreso_Estu);
                }
                conexion.Close();
                return _lista;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();
                return _lista;
            }
        }

        //Con este metodo buscaremos datos en nuestra base de datos
        public static List<Ingre_Estudios> Buscar(string Dato)
        {
            List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
            MySqlConnection conexion = BdComun.ObtenerConexion();
            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT Nombre_Paciente, id_Doctor, id_Estudio, Fecha, Precio_Pesos, Precio_Dolar FROM ingreso_estudios  where Nombre ='{0}' or Apellido_paterno='{1}' or Apellido_materno='{2}' or idDoctor='{3}'", Dato, Dato, Dato, Dato), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Ingre_Estudios pIngreso_Estu = new Ingre_Estudios();
                pIngreso_Estu.Nombre_Paciente = _reader.GetString(0);
                pIngreso_Estu.idDoctor = _reader.GetString(1);
                pIngreso_Estu.idEstudio = _reader.GetString(2);
                pIngreso_Estu.Fecha = _reader.GetString(3);
                pIngreso_Estu.Precio_Pesos = _reader.GetInt32(4);
                pIngreso_Estu.Precio_Dolar = _reader.GetInt32(5);

                _lista.Add(pIngreso_Estu);
            }
            conexion.Close();
            return _lista;
        }

        //Con este metodo seleccionamos la empresa que estamos buscando
        public static Ingre_Estudios ObtenerIngreso(int pId)
        {
            Ingre_Estudios pIngreso_Estu = new Ingre_Estudios();
            MySqlConnection conexion = BdComun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format(
            "SELECT Nombre_Paciente, id_Doctor, id_Estudio, Fecha, Precio_Pesos, Precio_Dolar FROM ingreso_estudios  where idingreso_estudios ='{0}'", pId), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pIngreso_Estu.Nombre_Paciente = _reader.GetString(0);
                pIngreso_Estu.idDoctor = _reader.GetString(1);
                pIngreso_Estu.idEstudio = _reader.GetString(2);
                pIngreso_Estu.Fecha = _reader.GetString(3);
                pIngreso_Estu.Precio_Pesos = _reader.GetInt32(4);
                pIngreso_Estu.Precio_Dolar = _reader.GetInt32(5);
            }

            conexion.Close();
            return pIngreso_Estu;
        }

        public static int Actualizar(Ingre_Estudios pIngreso_Estu)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Update ingreso_estudios set Nombre_Paciente='{0}', id_Doctor='{1}', id_Estudio='{2}', Descripcion='{3}', Fecha='{4}', Precio_Pesos='{5}', Precio_Dolar='{6}', Adeudo='{7}', Empresa='{8}' where idingreso_estudios='{9}';",
                     pIngreso_Estu.Nombre_Paciente, pIngreso_Estu.idDoctor, pIngreso_Estu.idEstudio, pIngreso_Estu.Nombre_Estudio, pIngreso_Estu.Fecha, pIngreso_Estu.Precio_Pesos, pIngreso_Estu.Precio_Dolar, pIngreso_Estu.Adeudo, pIngreso_Estu.Empresa, pIngreso_Estu.idIngreso_Estudio), conexion);

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

        public static int Eliminar(int pId)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Delete From ingreso_estudios where idingreso_estudios='{0}';", pId), conexion);

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

        public static int LimpiarIngresos(string inicio, string final, string empresa)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("SET SQL_SAFE_UPDATES = 0; DELETE FROM ingreso_estudios WHERE Fecha BETWEEN '{0}' AND '{1}' AND Empresa = '{2};", inicio, final, empresa), conexion);

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

        public static List<Ingre_Estudios> LLenarFiltro(string Empresa, string year, string month)
        {
            List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
               "SELECT  ingreso_estudios.idingreso_estudios, ingreso_estudios.Nombre_Paciente, ingreso_estudios.id_Doctor, ingreso_estudios.id_Estudio, ingreso_estudios.Fecha, ingreso_estudios.Precio_Pesos, ingreso_estudios.Precio_Dolar, concat_ws(' ', doctores.Nombre, doctores.Apellido_paterno, doctores.Apellido_materno) as Nombre_Doctor, ingreso_estudios.Descripcion, ingreso_estudios.Adeudo, ingreso_estudios.Empresa FROM ingreso_estudios LEFT JOIN doctores ON ingreso_estudios.id_Doctor = doctores.idDoctor LEFT JOIN estudios on ingreso_estudios.id_Estudio = estudios.idEstudios WHERE ingreso_estudios.Empresa ='{0}' AND Fecha >= '{1}-{2}'  ORDER BY ingreso_estudios.Fecha", Empresa, year, month), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    Ingre_Estudios pIngreso_Estu = new Ingre_Estudios();
                    pIngreso_Estu.idIngreso_Estudio = _reader.GetInt32(0);
                    pIngreso_Estu.Nombre_Paciente = _reader.GetString(1);
                    pIngreso_Estu.idDoctor = _reader.GetString(2);
                    pIngreso_Estu.idEstudio = _reader.GetString(3);
                    pIngreso_Estu.Fecha = _reader.GetString(4);
                    pIngreso_Estu.Precio_Pesos = _reader.GetInt32(5);
                    pIngreso_Estu.Precio_Dolar = _reader.GetInt32(6);
                    pIngreso_Estu.Nombre_Doctor = _reader.GetString(7);
                    pIngreso_Estu.Nombre_Estudio = _reader.GetString(8);
                    pIngreso_Estu.Adeudo = _reader.GetInt32(9);
                    pIngreso_Estu.Empresa = _reader.GetString(10);

                    _lista.Add(pIngreso_Estu);
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

        public static List<Ingre_Estudios> LLenarID(string Empresa, string id)
        {
            List<Ingre_Estudios> _lista = new List<Ingre_Estudios>();
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
               "SELECT  ingreso_estudios.idingreso_estudios, ingreso_estudios.Nombre_Paciente, ingreso_estudios.id_Doctor, ingreso_estudios.id_Estudio, ingreso_estudios.Fecha, ingreso_estudios.Precio_Pesos, ingreso_estudios.Precio_Dolar, concat_ws(' ', doctores.Nombre, doctores.Apellido_paterno, doctores.Apellido_materno) as Nombre_Doctor, ingreso_estudios.Descripcion, ingreso_estudios.Adeudo, ingreso_estudios.Empresa FROM ingreso_estudios LEFT JOIN doctores ON ingreso_estudios.id_Doctor = doctores.idDoctor LEFT JOIN estudios on ingreso_estudios.id_Estudio = estudios.idEstudios WHERE ingreso_estudios.Empresa ='{0}' AND ingreso_estudios.id_Doctor= '{1}' ORDER BY ingreso_estudios.Fecha", Empresa, id), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    Ingre_Estudios pIngreso_Estu = new Ingre_Estudios();
                    pIngreso_Estu.idIngreso_Estudio = _reader.GetInt32(0);
                    pIngreso_Estu.Nombre_Paciente = _reader.GetString(1);
                    pIngreso_Estu.idDoctor = _reader.GetString(2);
                    pIngreso_Estu.idEstudio = _reader.GetString(3);
                    pIngreso_Estu.Fecha = _reader.GetString(4);
                    pIngreso_Estu.Precio_Pesos = _reader.GetInt32(5);
                    pIngreso_Estu.Precio_Dolar = _reader.GetInt32(6);
                    pIngreso_Estu.Nombre_Doctor = _reader.GetString(7);
                    pIngreso_Estu.Nombre_Estudio = _reader.GetString(8);
                    pIngreso_Estu.Adeudo = _reader.GetInt32(9);
                    pIngreso_Estu.Empresa = _reader.GetString(10);

                    _lista.Add(pIngreso_Estu);
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
    }
}
