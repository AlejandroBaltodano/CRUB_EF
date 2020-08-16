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
    public partial class frmInsertar : Form
    {
        public frmInsertar()
        {
            InitializeComponent();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                AccesoADatos.Context context = new AccesoADatos.Context();
                Model.PersonaModel personaModel = new Model.PersonaModel();

                personaModel.Nombre = txtNombre.Text;
                personaModel.Cedula = txtCedula.Text;
                personaModel.FechaNacimiento = (DateTime) dtpFecha.Value.Date;

                context.insertarPersona(personaModel);
                MessageBox.Show("Transaccion exiotsa");
                this.Close();


            }
        }

        private void frmInsertar_Load(object sender, EventArgs e)
        {

        }
    }
}
