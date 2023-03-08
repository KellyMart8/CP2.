namespace Prectica1_EjemploArchivo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Se invoca cuando el ususario oprime una tecla
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //Determina si el ususario oprimió´la tecla Intro

            if (e.KeyCode == Keys.Enter)
            {
                string nombreArchivo; //nombre del archivo o directorio

                //obtiene el directorio o archivo especificado por el ususario
                nombreArchivo = txtEntrada.Text;

                //determinar si nombreArchivo es un archivo
                if (File.Exists(nombreArchivo))
                {
                    //obtener (ejemplo) la fecha de creacion, su fecha de modificacion, etc 
                    txtMostrar.Text = getInfo(nombreArchivo);

                    //Muestra el contenido del archivo a traves de StreamReader
                    try
                    {
                        StreamReader sr = new StreamReader(nombreArchivo);
                        txtMostrar.Text += sr.ReadToEnd();
                    }
                    catch (IOException)     //maneja excepcion si el streamreader no esta disponible
                    {
                        MessageBox.Show("Error al leer del archivo", "Erro de archivo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (Directory.Exists(nombreArchivo))
                {
                    string[] listaDirectorios;  //arreglo pra los directorios

                    txtMostrar.Text = getInfo(nombreArchivo);
                    listaDirectorios = Directory.GetFiles(nombreArchivo);      //obtiene la lista de archivos/Directorios

                    //obtiene la fecha de creacion del artchivo, su fecha de modificc aacion, etc
                    txtMostrar.Text = getInfo(nombreArchivo);

                    //obtiene la lista de directorios/archivops del directorio especififcado
                    listaDirectorios = Directory.GetDirectories(nombreArchivo);
                    txtMostrar.Text += "r\n\r\nContenido del directorio: \r\n";

                    //imprime en pantalla
                    for (int i = 0; i < listaDirectorios.Length; i++)
                    {
                        txtMostrar.Text += listaDirectorios[i] + "\r\n";
                    }
                }
                else
                {
                    MessageBox.Show(txtEntrada.Text + "No existe", "Error de archivo",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Obtener inf sobre el archivo
        private string getInfo(string nombreArchivo)
        {
            string informacion;

            //imprime mensaje indicando que existe el archivo o directorio
            informacion = nombreArchivo + " Existe\r\n\r\n";

            //imprime en pantalla la fecha y hora de creacion del archivo o directorio
            informacion += "Creacion: " + File.GetCreationTime(nombreArchivo) + "\r\n";

            //imprime en pantalla la fecha y hora de la ultima modificacion del archivo o directorio
            informacion += "Ultima modificacion:  " + File.GetLastWriteTime(nombreArchivo) + "\r\n";

            //imprime en pantalla la fecha y hora del ultimo acceso del archivo o directorio
            informacion += "Ultimo acceso: " + File.GetLastAccessTime(nombreArchivo) + "\r\n" + "\r\n";

            return informacion;
        }
    }
}