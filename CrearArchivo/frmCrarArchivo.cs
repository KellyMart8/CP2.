using Biblioteca_Banco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrearArchivo
{
    public partial class frmCrarArchivo : frmBancoUI
    {
        private StreamWriter archivoWrite; //escribe datos en el archivo de texto
        private FileStream salida; //mantiene la conexion con el archivo

        public frmCrarArchivo()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //crar un cuadro de dialogo que permite al usuario guardar el archivop
            SaveFileDialog selectorAchivo = new SaveFileDialog();
            DialogResult resultado = selectorAchivo.ShowDialog();
            string nombreArchivo; //nombre del archivo en el que se va a guardar los datos

            selectorAchivo.CheckFileExists = false; //permite al usuario crear el archivo

            //sale el manejador de eventos
            if (resultado == DialogResult.Cancel)
                return;
            nombreArchivo = selectorAchivo.FileName; // obtiene el nombre del earchivo especificado

            //muestra el error si el usuario especifica un archivo invalido
            if (nombreArchivo == " " || nombreArchivo == null)
            {
                MessageBox.Show("Nombre de archivo invalido", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
