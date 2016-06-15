﻿using System;
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
    public partial class BackUp : Form
    {
        public BackUp()
        {
            InitializeComponent();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string fileName = "EmpresaBackup.txt";
            string sourcePath = @"C:\Backup";
            string targetPath;
            switch (comboBox1.Text)
            {
                case "D:":
                    targetPath = @"D:\Backup";
                    break;
                case "E:":
                    targetPath = @"E:\Backup";
                    break;
                case "F:":
                    targetPath = @"F:\Backup";
                    break;
                case "G:":
                    targetPath = @"G:\Backup";
                    break;
                case "H:":
                    targetPath = @"H:\Backup";
                    break;
                default:
                    MessageBox.Show("Selecione una opcion correcta");
                    targetPath = @"D:\Backup";
                    break;
            }
            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);
            MessageBox.Show("BASE DE DATOS GUARDADA");
            System.IO.File.WriteAllText(@"C:\Backup\EmpresaBackup.txt", "USE empresa;\n\r");
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            string Backup;
            switch (comboBox1.Text)
            {
                case "D:":
                    Backup = System.IO.File.ReadAllText(@"D:\Backup\EmpresaBackup.txt");
                    break;
                case "E:":
                    Backup = System.IO.File.ReadAllText(@"E:\Backup\EmpresaBackup.txt");
                    break;
                case "F:":
                   Backup = System.IO.File.ReadAllText(@"F:\Backup\EmpresaBackup.txt");
                    break;
                case "G:":
                   Backup = System.IO.File.ReadAllText(@"G:\Backup\EmpresaBackup.txt");
                    break;
                case "H:":
                    Backup = System.IO.File.ReadAllText(@"H:\Backup\EmpresaBackup.txt");
                    break;
                default:
                    MessageBox.Show("Selecione una opcion correcta");
                    Backup = System.IO.File.ReadAllText(@"D:\Backup\EmpresaBackup.txt");
                    break;
            }            
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(Backup,conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();                
            }
            if (retorno > 0)
                MessageBox.Show("BASE DE DATOS ACTUALIZADA");
            else
                MessageBox.Show("ERROR AL IMPORTAR BASE DE DATOS");
        }
    }
}
