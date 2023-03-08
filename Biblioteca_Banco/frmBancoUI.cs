using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca_Banco
{
    public partial class frmBancoUI : Form
    {
        //numero de controles textBox en el formulario
        protected int CuentaTextbox = 4;

        //Las contantes de enumeracion espeifican los indioces de los controles tetBox
        public enum IndicesTextBox
        {
            CUENTA,
            NOMBRE,
            APELLIDO,
            SALDO
        }
        public frmBancoUI()
        {
            InitializeComponent();
        }

        //limpia todos los controles textBox
        public void LimpiarcontrolesTextBox()
        {
            //itera a taves de cada control en el formulario
            for (int i = 0; i < Controls.Count; i++)
            {
                Control c = Controls[i];

                //Determinamos si es textbox
                if (c is TextBox)
                {
                    //Limpia la propiedad Text(la estableece en cadena vacia)
                    c.Text = "";
                }
            }
        }

        //Establece los valores de los controles TextBox con el arreglo string  valores
        public void EstablecerValores(string[] valores)
        {
            //determina si el arreglos strijng tiene la longitud correcta
            if (valores.Length != CuentaTextbox)
            {
                //lanza excepcion si no tiene la longitud correcta
                throw (new ArgumentException("De haber " +
                   (CuentaTextbox + 1) + " objetos nstring en el arreglos"));
            }
            else      //etsablece valores si el aarreglo tiene la longitud correcta
            {
                txtCuenta.Text = valores[(int)IndicesTextBox.CUENTA];
                txtPrimerName.Text = valores[(int)IndicesTextBox.NOMBRE];
                txtApellidoPat.Text = valores[(int)IndicesTextBox.APELLIDO];
                txtSaldo.Text = valores[(int)IndicesTextBox.SALDO];  

            }
        }

        //decuelve los valores de los controles txt
        public string[] getValoresControles()
        {
            string[] valores = new string[CuentaTextbox];

            //Copia los campos de los controlres textBox al arreglo strig
            valores[(int)IndicesTextBox.CUENTA] = txtCuenta.Text;
            valores[(int)IndicesTextBox.NOMBRE] = txtPrimerName.Text;
            valores[(int)IndicesTextBox.APELLIDO] = txtApellidoPat.Text;
            valores[(int)IndicesTextBox.SALDO] = txtSaldo.Text;

            return valores;
        }
        private void frmBancoUI_Load(object sender, EventArgs e)
        {

        }
    }
}
