using System;
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
            string fileName = "prueba.txt";
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
            //Solo un comentario de prueba para GitHub
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            string Backup = System.IO.File.ReadAllText(@"C:\Backup\prueba.txt");
            int retorno = 0;
            MySqlConnection conexion = BdComun.ObtenerConexion();
            try
            {
                MySqlCommand comando = new MySqlCommand(Backup,conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
                System.IO.File.WriteAllText(@"C:\Backup\prueba.txt", "USE empresa");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();                
            }
        }
    }
}
