using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Empresa
{
   public class EmpresaDAL
    {
       //Este es el metodo para agregar datos a la base de datos
        public static int Agregar(Empresas pEmpresa)
        {
            int retorno = 0;

            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format("Insert into empresas (idEmpresa, Razon_Social, Giro, Domicilio, Ciudad, Municipio, Estado, RFC, CURP, Reg_Patronal_imss, Nombre_Gerente, Nombre_Contador, Representante_Legal) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
                    pEmpresa.IdEmpresa, pEmpresa.Razon_Social, pEmpresa.Giro, pEmpresa.Domicilio, pEmpresa.Ciudad, pEmpresa.Municipio, pEmpresa.Estado, pEmpresa.RFC, pEmpresa.CURP, pEmpresa.Reg_imss, pEmpresa.Nombre_Gerente, pEmpresa.Nombre_Contador, pEmpresa.Representante_Legal), BdComun.ObtenerConexion());
                retorno = comando.ExecuteNonQuery();
                return retorno;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return retorno;                
            }
        }

       //Con este metodo llenamos nuestro datagrindview con la base de datos
        public static List<Empresas> LLenar()
        {
            List<Empresas> _lista = new List<Empresas>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT idEmpresa, Razon_Social, Giro, Domicilio, Ciudad, Municipio, Estado, RFC, CURP, Reg_Patronal_imss, Nombre_Gerente, Nombre_Contador, Representante_Legal FROM empresas"), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Empresas pEmpresa = new Empresas();
                pEmpresa.IdEmpresa = _reader.GetInt32(0);               
                pEmpresa.Razon_Social = _reader.GetString(1);
                pEmpresa.Giro = _reader.GetString(2);
                pEmpresa.Domicilio = _reader.GetString(3);
                pEmpresa.Ciudad = _reader.GetString(4);
                pEmpresa.Municipio = _reader.GetString(5);
                pEmpresa.Estado = _reader.GetString(6);
                pEmpresa.RFC = _reader.GetString(7);
                pEmpresa.CURP = _reader.GetString(8);
                pEmpresa.Reg_imss = _reader.GetString(9);
                pEmpresa.Nombre_Gerente = _reader.GetString(1);
                pEmpresa.Nombre_Contador = _reader.GetString(11);
                pEmpresa.Representante_Legal = _reader.GetString(12);


                _lista.Add(pEmpresa);
            }

            return _lista;
        }

        //Con este metodo buscaremos datos en nuestra base de datos
        public static List<Empresas> Buscar(string pNombre, string pApellido)
        {
            List<Empresas> _lista = new List<Empresas>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT idEmpresa, Razon_Social, Giro, Domicilio, Ciudad, Municipio, Estado, RFC, CURP, Reg_Patronal_imss, Nombre_Gerente, Nombre_Contador, Representante_Legal FROM empresas  where Nombre ='{0}' or Apellido='{1}'", pNombre, pApellido), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Empresas pEmpresa = new Empresas();
                pEmpresa.IdEmpresa = _reader.GetInt32(0);
                pEmpresa.Razon_Social = _reader.GetString(1);
                pEmpresa.Giro = _reader.GetString(2);
                pEmpresa.Domicilio = _reader.GetString(3);
                pEmpresa.Ciudad = _reader.GetString(4);
                pEmpresa.Municipio = _reader.GetString(5);
                pEmpresa.Estado = _reader.GetString(6);
                pEmpresa.RFC = _reader.GetString(7);
                pEmpresa.CURP = _reader.GetString(8);
                pEmpresa.Reg_imss = _reader.GetString(9);
                pEmpresa.Nombre_Gerente = _reader.GetString(1);
                pEmpresa.Nombre_Contador = _reader.GetString(11);
                pEmpresa.Representante_Legal = _reader.GetString(12);


                _lista.Add(pEmpresa);
            }

            return _lista;
        }

       //Con este metodo seleccionamos la empresa que estamos buscando
        public static Empresas ObtenerEmpresa(int pId)
        {
            Empresas pEmpresa = new Empresas();
            MySqlConnection conexion = BdComun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format(
            "SELECT idEmpresa, Razon_Social, Giro, Domicilio, Ciudad, Municipio, Estado, RFC, CURP, Reg_Patronal_imss, Nombre_Gerente, Nombre_Contador, Representante_Legal FROM empresas  where idEmpresa ='{0}'", pId), BdComun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pEmpresa.IdEmpresa = _reader.GetInt32(0);
                pEmpresa.Razon_Social = _reader.GetString(1);
                pEmpresa.Giro = _reader.GetString(2);
                pEmpresa.Domicilio = _reader.GetString(3);
                pEmpresa.Ciudad = _reader.GetString(4);
                pEmpresa.Municipio = _reader.GetString(5);
                pEmpresa.Estado = _reader.GetString(6);
                pEmpresa.RFC = _reader.GetString(7);
                pEmpresa.CURP = _reader.GetString(8);
                pEmpresa.Reg_imss = _reader.GetString(9);
                pEmpresa.Nombre_Gerente = _reader.GetString(1);
                pEmpresa.Nombre_Contador = _reader.GetString(11);
                pEmpresa.Representante_Legal = _reader.GetString(12);

            }

            conexion.Close();
            return pEmpresa;

        }

        public static int Actualizar(Empresas pEmpresa)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into empresas (idEmpresa, Razon_Social, Giro, Domicilio, Ciudad, Municipio, Estado, RFC, CURP, Reg_Patronal_imss, Nombre_Gerente, Nombre_Contador, Representante_Legal) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
                pEmpresa.IdEmpresa, pEmpresa.Razon_Social, pEmpresa.Giro, pEmpresa.Domicilio, pEmpresa.Ciudad, pEmpresa.Municipio, pEmpresa.Estado, pEmpresa.RFC, pEmpresa.CURP, pEmpresa.Reg_imss, pEmpresa.Nombre_Gerente, pEmpresa.Nombre_Contador, pEmpresa.Representante_Legal), BdComun.ObtenerConexion());

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }

        public static int Eliminar(int pId)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Delete From empresas where idEmpresa={0}", pId), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }
    }
}
