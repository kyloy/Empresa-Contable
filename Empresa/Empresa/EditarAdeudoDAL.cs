﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Empresa
{
    class EditarAdeudoDAL
    {
        public static List<EditarAdeudo> LLenar(string inicio, string final, string doctor, string Empresa)
        {
            List<EditarAdeudo> _lista = new List<EditarAdeudo>();
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format("call empresa.Editar_Adeudo('{0}', '{1}', '{2}', '{3}');", inicio, final, doctor, Empresa), conexion);
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    EditarAdeudo pEditarAdeudo = new EditarAdeudo();
                    pEditarAdeudo.Fecha = _reader.GetString(0);
                    pEditarAdeudo.Nombre_Doctor = _reader.GetString(1);
                    pEditarAdeudo.Direccion = _reader.GetString(2);
                    pEditarAdeudo.Telefono = _reader.GetString(3);
                    pEditarAdeudo.idDoctor = _reader.GetString(4);
                    pEditarAdeudo.Celular = _reader.GetString(5);
                    pEditarAdeudo.Colonia = _reader.GetString(6);
                    pEditarAdeudo.Zona = _reader.GetString(7);
                    pEditarAdeudo.Nombre_Paciente = _reader.GetString(8);
                    pEditarAdeudo.Descripcion = _reader.GetString(9);
                    pEditarAdeudo.Adeudo = _reader.GetInt32(10);
                    pEditarAdeudo.Empresa = _reader.GetString(11);
                    pEditarAdeudo.idIngreso = _reader.GetString(14);
                    pEditarAdeudo.Precio_Pesos = _reader.GetInt32(12);
                    pEditarAdeudo.Precio_Dolar = _reader.GetInt32(13);

                    _lista.Add(pEditarAdeudo);
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

        public static int Actualizar(int dolar, int pesos, int adeudo, string paciente, int idIngreso_estudio)
        {
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(" UPDATE ingreso_estudios SET Precio_Dolar = '{0}', Precio_Dolar = '{1}', Adeudo = '{2}', Nombre_Paciente = '{3}' WHERE idingreso_estudios = '{4}';",dolar, pesos, adeudo, paciente, idIngreso_estudio  ), conexion);

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
