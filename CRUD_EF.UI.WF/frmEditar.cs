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
    public partial class frmEditar : Form
    {
        int idPersona = 0;
        public frmEditar(int id)
        {
            InitializeComponent();
            idPersona = id;
        }
        public Boolean ValidarCampos()
        {
            Boolean resultado = true;
            string msj = "Debe de llenar los campos: ";

            if (txtNombre.Text.Trim() == string.Empty)
            {
                resultado = false;
                msj += " Campo Nombre";

            }
            if (txtCedula.Text.Trim() == string.Empty)
            {
                resultado = false;
                msj += " Campo Cedula";

            }

            if (resultado == false)
            {
                MessageBox.Show(msj, "Error");

            }


            return resultado;




        }

        public void llenarCampos()
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            var persona = context.obtenerPersonaPorid(idPersona);
            txtNombre.Text = persona.Nombre;
            txtCedula.Text = persona.Cedula;
            dtpFecha.Value = persona.FechaNacimiento.Value.Date;
            lblId.Text = idPersona.ToString();



        }

        private void frmEditar_Load(object sender, EventArgs e)
        {
            llenarCampos();

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
                Model.PersonaModel personaModel = new Model.PersonaModel();
                personaModel.Nombre = txtNombre.Text;
                personaModel.Cedula = txtCedula.Text;
                personaModel.FechaNacimiento = dtpFecha.Value.Date;

                context.editarPersona(idPersona, personaModel);
                MessageBox.Show("Transaccion exitosa");
                this.Close();

            }

        }
    }
}
