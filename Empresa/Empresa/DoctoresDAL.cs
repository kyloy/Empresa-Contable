using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Empresa
{
    public class DoctoresDAL
    {
        //Este es el metodo para agregar datos a la base de datos
        public static int Agregar(Doctores pDoctores)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into doctores (idDoctor, Nombre, Apellido_paterno, Apellido_materno, Direccion, Colonia, Ciudad, Estado, Pais, Zona, Telefono, Celular, Aseguranza) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
                    pDoctores.IdDoctor, pDoctores.Nombre, pDoctores.Apellido_Paterno, pDoctores.Apellido_Materno, pDoctores.Direccion, pDoctores.Colonia, pDoctores.Ciudad, pDoctores.Estado, pDoctores.Pais, pDoctores.Zona, pDoctores.Telefono, pDoctores.Celular, pDoctores.Aseguranza), conexion);
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

            txb.Text = midgv.Rows[midgv.CurrentRow.Index].Cells[columna].Value.ToString();

        }

        //Con este metodo llenamos nuestro datagrindview con la base de datos
        public static List<Doctores> LLenar()
        {
            List<Doctores> _lista = new List<Doctores>();
            MySqlConnection conexion = BdComun.ObtenerConexion();
            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT idDoctor, concat_ws(' ', Nombre, Apellido_paterno, Apellido_materno) as Nombre, Nombre, Apellido_paterno, Apellido_materno, Direccion, Colonia, Ciudad, Estado, Pais, Zona, Telefono, Celular, Aseguranza FROM doctores"), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Doctores pDoctores = new Doctores();
                pDoctores.IdDoctor = _reader.GetString(0);
                pDoctores.NombreComplet = _reader.GetString(1);
                pDoctores.Nombre = _reader.GetString(2);
                pDoctores.Apellido_Paterno = _reader.GetString(3);
                pDoctores.Apellido_Materno = _reader.GetString(4);
                pDoctores.Direccion = _reader.GetString(5);
                pDoctores.Colonia = _reader.GetString(6);
                pDoctores.Ciudad = _reader.GetString(7);
                pDoctores.Estado = _reader.GetString(8);
                pDoctores.Pais = _reader.GetString(9);
                pDoctores.Zona = _reader.GetString(10);
                pDoctores.Telefono = _reader.GetString(11);
                pDoctores.Celular = _reader.GetString(12);
                pDoctores.Aseguranza = _reader.GetString(13);                

                _lista.Add(pDoctores);
            }
            conexion.Close();
            return _lista;
        }

        //Con este metodo buscaremos datos en nuestra base de datos
        public static List<Doctores> Buscar(string Dato, int opcion)
        {
            List<Doctores> _lista = new List<Doctores>();
            MySqlConnection conexion = BdComun.ObtenerConexion();
            if (opcion == 1)
            {
                //IDDOCTOR
                MySqlCommand _comando = new MySqlCommand(String.Format(
               "SELECT idDoctor, concat_ws(' ', Nombre, Apellido_paterno, Apellido_materno) as Nombre, Nombre, Apellido_paterno, Apellido_materno, Direccion, Colonia, Ciudad, Estado, Pais, Zona, Telefono, Celular, Aseguranza FROM doctores ORDER BY idDoctor"), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    Doctores pDoctores = new Doctores();
                    pDoctores.IdDoctor = _reader.GetString(0);
                    pDoctores.NombreComplet = _reader.GetString(1);
                    pDoctores.Nombre = _reader.GetString(2);
                    pDoctores.Apellido_Paterno = _reader.GetString(3);
                    pDoctores.Apellido_Materno = _reader.GetString(4);
                    pDoctores.Direccion = _reader.GetString(5);
                    pDoctores.Colonia = _reader.GetString(6);
                    pDoctores.Ciudad = _reader.GetString(7);
                    pDoctores.Estado = _reader.GetString(8);
                    pDoctores.Pais = _reader.GetString(9);
                    pDoctores.Zona = _reader.GetString(10);
                    pDoctores.Telefono = _reader.GetString(11);
                    pDoctores.Celular = _reader.GetString(12);
                    pDoctores.Aseguranza = _reader.GetString(13);    


                    _lista.Add(pDoctores);
                }
            }
            else if (opcion == 2)
            {
                //NOMBRE
                MySqlCommand _comando = new MySqlCommand(String.Format(
              "SELECT idDoctor, concat_ws(' ', Nombre, Apellido_paterno, Apellido_materno) as Nombre, Nombre, Apellido_paterno, Apellido_materno, Direccion, Colonia, Ciudad, Estado, Pais, Zona, Telefono, Celular, Aseguranza FROM doctores ORDER BY Nombre"), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    Doctores pDoctores = new Doctores();
                    pDoctores.IdDoctor = _reader.GetString(0);
                    pDoctores.NombreComplet = _reader.GetString(1);
                    pDoctores.Nombre = _reader.GetString(2);
                    pDoctores.Apellido_Paterno = _reader.GetString(3);
                    pDoctores.Apellido_Materno = _reader.GetString(4);
                    pDoctores.Direccion = _reader.GetString(5);
                    pDoctores.Colonia = _reader.GetString(6);
                    pDoctores.Ciudad = _reader.GetString(7);
                    pDoctores.Estado = _reader.GetString(8);
                    pDoctores.Pais = _reader.GetString(9);
                    pDoctores.Zona = _reader.GetString(10);
                    pDoctores.Telefono = _reader.GetString(11);
                    pDoctores.Celular = _reader.GetString(12);
                    pDoctores.Aseguranza = _reader.GetString(13);


                    _lista.Add(pDoctores);
                }
            }
            else if (opcion == 3)
            {
                //APELLIDO PATERNO
                MySqlCommand _comando = new MySqlCommand(String.Format(
              "SELECT idDoctor, concat_ws(' ', Nombre, Apellido_paterno, Apellido_materno) as Nombre, Nombre, Apellido_paterno, Apellido_materno, Direccion, Colonia, Ciudad, Estado, Pais, Zona, Telefono, Celular, Aseguranza FROM doctores ORDER BY Apellido_paterno"), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    Doctores pDoctores = new Doctores();
                    pDoctores.IdDoctor = _reader.GetString(0);
                    pDoctores.NombreComplet = _reader.GetString(1);
                    pDoctores.Nombre = _reader.GetString(2);
                    pDoctores.Apellido_Paterno = _reader.GetString(3);
                    pDoctores.Apellido_Materno = _reader.GetString(4);
                    pDoctores.Direccion = _reader.GetString(5);
                    pDoctores.Colonia = _reader.GetString(6);
                    pDoctores.Ciudad = _reader.GetString(7);
                    pDoctores.Estado = _reader.GetString(8);
                    pDoctores.Pais = _reader.GetString(9);
                    pDoctores.Zona = _reader.GetString(10);
                    pDoctores.Telefono = _reader.GetString(11);
                    pDoctores.Celular = _reader.GetString(12);
                    pDoctores.Aseguranza = _reader.GetString(13);


                    _lista.Add(pDoctores);
                }
            }
            else if (opcion == 4)
            {
                //APELLIDO MATENRO
                MySqlCommand _comando = new MySqlCommand(String.Format(
              "SELECT idDoctor, concat_ws(' ', Nombre, Apellido_paterno, Apellido_materno) as Nombre, Nombre, Apellido_paterno, Apellido_materno, Direccion, Colonia, Ciudad, Estado, Pais, Zona, Telefono, Celular, Aseguranza FROM doctores ORDER BY Apellido_materno"), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    Doctores pDoctores = new Doctores();
                    pDoctores.IdDoctor = _reader.GetString(0);
                    pDoctores.NombreComplet = _reader.GetString(1);
                    pDoctores.Nombre = _reader.GetString(2);
                    pDoctores.Apellido_Paterno = _reader.GetString(3);
                    pDoctores.Apellido_Materno = _reader.GetString(4);
                    pDoctores.Direccion = _reader.GetString(5);
                    pDoctores.Colonia = _reader.GetString(6);
                    pDoctores.Ciudad = _reader.GetString(7);
                    pDoctores.Estado = _reader.GetString(8);
                    pDoctores.Pais = _reader.GetString(9);
                    pDoctores.Zona = _reader.GetString(10);
                    pDoctores.Telefono = _reader.GetString(11);
                    pDoctores.Celular = _reader.GetString(12);
                    pDoctores.Aseguranza = _reader.GetString(13);


                    _lista.Add(pDoctores);
                }
            }
            else if (opcion == 5)
            {
                //TELEFONO
                MySqlCommand _comando = new MySqlCommand(String.Format(
              "SELECT idDoctor, concat_ws(' ', Nombre, Apellido_paterno, Apellido_materno) as Nombre, Nombre, Apellido_paterno, Apellido_materno, Direccion, Colonia, Ciudad, Estado, Pais, Zona, Telefono, Celular, Aseguranza FROM doctores ORDER BY Telefono"), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    Doctores pDoctores = new Doctores();
                    pDoctores.IdDoctor = _reader.GetString(0);
                    pDoctores.NombreComplet = _reader.GetString(1);
                    pDoctores.Nombre = _reader.GetString(2);
                    pDoctores.Apellido_Paterno = _reader.GetString(3);
                    pDoctores.Apellido_Materno = _reader.GetString(4);
                    pDoctores.Direccion = _reader.GetString(5);
                    pDoctores.Colonia = _reader.GetString(6);
                    pDoctores.Ciudad = _reader.GetString(7);
                    pDoctores.Estado = _reader.GetString(8);
                    pDoctores.Pais = _reader.GetString(9);
                    pDoctores.Zona = _reader.GetString(10);
                    pDoctores.Telefono = _reader.GetString(11);
                    pDoctores.Celular = _reader.GetString(12);
                    pDoctores.Aseguranza = _reader.GetString(13);


                    _lista.Add(pDoctores);
                }
            }
            conexion.Close();
            return _lista;
        }

       
        public static string BuscarDoctor(string Dato, int op)
        {       
            string Nombre = " ";
            string ID = " ";
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {                
                if (op == 1)
                {
                    //IDDOCTOR
                    MySqlCommand _comando = new MySqlCommand(String.Format(
                   "SELECT concat_ws(' ', Nombre, Apellido_paterno, Apellido_materno) as Nombre FROM doctores Where idDoctor = '{0}'", Dato), conexion);
                    MySqlDataReader _reader = _comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Nombre = _reader.GetString(0);
                    }
                    conexion.Close();
                    return Nombre;
                }
                else
                {
                    MySqlCommand _comando = new MySqlCommand(String.Format(
                  "SELECT idDoctor, concat_ws(' ', Nombre, Apellido_paterno, Apellido_materno) as Nombre FROM doctores Where concat_ws(' ', Nombre, Apellido_paterno, Apellido_materno) like '%{0}%'", Dato), conexion);
                    MySqlDataReader _reader = _comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        ID = _reader.GetString(0);
                    }
                    conexion.Close();
                    return ID;
                }               
            }            
            catch(Exception ex)
            { MessageBox.Show(ex.Message); conexion.Close(); return Nombre; }
        }

        //Con este metodo seleccionamos la empresa que estamos buscando
        public static Doctores ObtenerDoctor(string pId)
        {
            Doctores pDoctores = new Doctores();
            MySqlConnection conexion = BdComun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format(
            "SELECT idDoctor, concat_ws(' ', Nombre, Apellido_paterno, Apellido_materno) as Nombre, Nombre, Apellido_paterno, Apellido_materno, Direccion, Colonia, Ciudad, Estado, Pais, Zona, Telefono, Celular, Aseguranza FROM doctores  where idDoctor ='{0}'", pId), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pDoctores.IdDoctor = _reader.GetString(0);
                pDoctores.NombreComplet = _reader.GetString(1);
                pDoctores.Nombre = _reader.GetString(2);
                pDoctores.Apellido_Paterno = _reader.GetString(3);
                pDoctores.Apellido_Materno = _reader.GetString(4);
                pDoctores.Direccion = _reader.GetString(5);
                pDoctores.Colonia = _reader.GetString(6);
                pDoctores.Ciudad = _reader.GetString(7);
                pDoctores.Estado = _reader.GetString(8);
                pDoctores.Pais = _reader.GetString(9);
                pDoctores.Zona = _reader.GetString(10);
                pDoctores.Telefono = _reader.GetString(11);
                pDoctores.Celular = _reader.GetString(12);
                pDoctores.Aseguranza = _reader.GetString(13);               

            }
            conexion.Close();
            return pDoctores;
        }

        public static int Actualizar(Doctores pDoctores)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Update doctores set Nombre='{0}', Apellido_paterno='{1}', Apellido_materno='{2}', Direccion='{3}', Colonia='{4}', Ciudad='{5}', Estado='{6}', Pais='{7}', Zona='{8}', Telefono='{9}', Celular='{10}', Aseguranza='{11}' where idDoctor='{12}'",
                     pDoctores.Nombre, pDoctores.Apellido_Paterno, pDoctores.Apellido_Materno, pDoctores.Direccion, pDoctores.Colonia, pDoctores.Ciudad, pDoctores.Estado, pDoctores.Pais, pDoctores.Zona, pDoctores.Telefono, pDoctores.Celular, pDoctores.Aseguranza, pDoctores.IdDoctor), conexion);

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

        public static int Eliminar(string pId)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {   
                MySqlCommand comando = new MySqlCommand(string.Format("Delete From doctores where IdDoctor='{0}'", pId), conexion);

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
        ~DoctoresDAL() { /*MessageBox.Show("LIMPIANDO");*/ }
        void Dispose() { /*MessageBox.Show("LIMPIANDO2"); */}
    }
}
