using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_EF.UI.WF
{
    public partial class frmInsertarTelefono : Form
    {
        int idPersona = 0;
        public frmInsertarTelefono(int id)
        {
            InitializeComponent();
            idPersona = id;
        }
        
        public void llenarCampos()
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            var persona = context.obtenerPersonaPorid(idPersona);
            lblPersona.Text = persona.Nombre;


        }

        public Boolean ValidarCampos()
        {
            Boolean resultado = true;
            string msj = "Debe llenar los campos: ";

            if (textBox1.Text.Trim() == string.Empty)
            {
                resultado = false;
                msj += " Campo telefono";

            }

            if (resultado == false)
            {
                MessageBox.Show(msj);

            }

            return resultado;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInsertarTelefono_Load(object sender, EventArgs e)
        {
            llenarCampos();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                AccesoADatos.Context context = new AccesoADatos.Context();
                Model.TelefonoModel telefonoModel = new Model.TelefonoModel();
                telefonoModel.idPersona = idPersona;
                telefonoModel.Telefono = textBox1.Text;

                context.insertarTelefonoPersona(telefonoModel);

                MessageBox.Show("se inserto bien");
                this.Close();

            }
        }
    }
}
