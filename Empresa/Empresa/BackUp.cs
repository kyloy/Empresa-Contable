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

        public void Historial(string historia)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Backup\Historial.txt", true))
            {
                file.WriteLine(DateTime.Now.ToString());
                file.WriteLine(historia);
            }
        }
        /*
        public void HistorialImport(string historia)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Backup\importBackup.txt", true))
            {
                file.WriteLine(DateTime.Now.ToString());
                file.WriteLine(historia);
            }
        }
        */

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
            string historial = System.IO.File.ReadAllText(@"C:\Backup\EmpresaBackup.txt");
            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);
            MessageBox.Show("BASE DE DATOS GUARDADA");
            Historial(historial);
            System.IO.File.WriteAllText(@"C:\Backup\EmpresaBackup.txt", "USE empresa;\n\r");
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            string[] Backup;
            string ruta;
            switch (comboBox1.Text)
            {
                case "D:":
                    Backup = System.IO.File.ReadAllLines(@"D:\Backup\EmpresaBackup.txt");
                    ruta = @"D:\Backup\EmpresaBackup.txt";
                    break;
                case "E:":
                    Backup = System.IO.File.ReadAllLines(@"E:\Backup\EmpresaBackup.txt");
                    ruta = @"E:\Backup\EmpresaBackup.txt";
                    break;
                case "F:":
                    Backup = System.IO.File.ReadAllLines(@"F:\Backup\EmpresaBackup.txt");
                    ruta = @"F:\Backup\EmpresaBackup.txt";
                    break;
                case "G:":
                    Backup = System.IO.File.ReadAllLines(@"G:\Backup\EmpresaBackup.txt");
                    ruta = @"G:\Backup\EmpresaBackup.txt";
                    break;
                case "H:":
                    Backup = System.IO.File.ReadAllLines(@"H:\Backup\EmpresaBackup.txt");
                    ruta = @"H:\Backup\EmpresaBackup.txt";
                    break;
                default:
                    MessageBox.Show("Selecione una opcion correcta");
                    Backup = System.IO.File.ReadAllLines(@"D:\Backup\EmpresaBackup.txt");
                    ruta = @"D:\Backup\EmpresaBackup.txt";
                    break;
            }            
            int retorno = 0;
            int contador = -1;
            try
            {
               foreach (string line in Backup)
                {
                    contador++;
                    if (line != "")
                    {
                        
                        // Set cursor as hourglass
                        Cursor.Current = Cursors.WaitCursor;
                        MySqlConnection conexion = BdComun.ObtenerConexion();
                        MySqlCommand comando = new MySqlCommand(line, conexion);
                        retorno = comando.ExecuteNonQuery();
                        conexion.Close();
                    }    
                }
               //MessageBox.Show(contador.ToString());
                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);               
            }
            finally
            {
              /*#region Guardar datos en backup
                System.IO.File.WriteAllText(ruta, "USE empresa;\n\r");
                for (int i = contador; i <= Backup.Length-1; i++)
                {
                    using (System.IO.StreamWriter file =
               new System.IO.StreamWriter(ruta, true))
                    {
                        file.WriteLine(Backup[i]);
                    }
                }
                #endregion*/
            }
            if (retorno > 0)
                MessageBox.Show("BASE DE DATOS ACTUALIZADA");
            else
                MessageBox.Show("ERROR AL IMPORTAR BASE DE DATOS");
        }
    }
}
