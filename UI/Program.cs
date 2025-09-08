using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using Infraestructura;
using UI.Views;

namespace UI
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // TestearConexionBaseDeDatos();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }

        private static void TestearConexionBaseDeDatos()
        {
            try
            {
                BaseDeDatos.ObtenerConexion().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error de conexión a la base: " + ex.Message);
            }
        }
    }
}