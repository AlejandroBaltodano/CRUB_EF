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
    public partial class frmTelefonos : Form
    {
        int idPersona = 0;
        public frmTelefonos(int id)
        {
            InitializeComponent();
            idPersona = id;
        }
        public void PropiedadesGrid()
        {
            dgvTelefono.Columns[0].Visible = false;
            dgvTelefono.Columns[1].Visible = false;
            dgvTelefono.Columns[2].HeaderText = "Nombre";
            dgvTelefono.Columns[3].HeaderText = "Cedula";
            dgvTelefono.Columns[4].HeaderText = "Telefono";

        }
        public void LlenarGrid()
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            dgvTelefono.DataSource = context.laListaTelefenosPorPersona(idPersona);
            PropiedadesGrid();



        }

        private void frmTelefonos_Load(object sender, EventArgs e)
        {
            LlenarGrid();

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            
                frmInsertarTelefono frmInsertarTelefono = new frmInsertarTelefono(idPersona);
                frmInsertarTelefono.ShowDialog();
                LlenarGrid();
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTelefono.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro");

            }
            else
            {
                string id = dgvTelefono.CurrentRow.Cells[0].Value.ToString();
                int idTelefono = Int16.Parse(id);
                AccesoADatos.Context context = new AccesoADatos.Context();
                context.eliminarTelefonoPersona(idTelefono);
                MessageBox.Show("se elimino bien");
                LlenarGrid();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTelefono.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un registro");

            }
            else
            {
                string id = dgvTelefono.CurrentRow.Cells[0].Value.ToString();
                int idTelefono = Int16.Parse(id);
                frmEditarTelefono frmEditarTelefono = new frmEditarTelefono(idPersona, idTelefono);
                frmEditarTelefono.ShowDialog();
                LlenarGrid();
            }

        }
    }
}
