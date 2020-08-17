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
    public partial class frmEditarTelefono : Form
    {
        int idPersona = 0;
        int idtelefono = 0;
        public frmEditarTelefono(int idp, int idt)
        {
            InitializeComponent();
            idPersona = idp;
            idtelefono = idt;
        }
        public void LlenarCampos()
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            var persona = context.obtenerPersonaPorid(idPersona);
            var telefono = context.obtenerTelefonoporIdTelefono(idtelefono);

            lblPersona.Text = persona.Nombre;
            textBox1.Text = telefono.Telefono1;


        }
        public Boolean ValidarCampos()
        {

            Boolean resultado = true;
            string msj = "Debe de llenar los campos: ";

            if (textBox1.Text.Trim() == string.Empty)
            {
                resultado = false;
                msj += "Campo telefono";

            }

            if (resultado == false)
            {
                MessageBox.Show(msj);
            }

            return resultado;

        }

        private void frmEditarTelefono_Load(object sender, EventArgs e)
        {
            LlenarCampos();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {

                AccesoADatos.Context context = new AccesoADatos.Context();
                Model.TelefonoModel telefonoModel = new Model.TelefonoModel();

                telefonoModel.idPersona = idPersona;
                telefonoModel.Telefono = textBox1.Text;

                context.editarTelefonoPersona(idtelefono, telefonoModel);
                MessageBox.Show("Se edito bien");
                this.Close();

            }
        }
    }
}
