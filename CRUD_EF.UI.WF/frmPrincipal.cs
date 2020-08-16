﻿using System;
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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void LLenarGrid()
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            dgvPersona.DataSource = context.laListaPersonas();
            PropiedadesGrid();


        }
        public void PropiedadesGrid()
        {
            dgvPersona.Columns[0].Visible = false;
            dgvPersona.Columns[1].HeaderText = "Nombre completo";
            dgvPersona.Columns[2].HeaderText = "Cedula";
            dgvPersona.Columns[3].HeaderText = "Fecha nacimiento";


        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            LLenarGrid();

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            frmInsertar frmInsertar = new frmInsertar();
            frmInsertar.ShowDialog();
            LLenarGrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            AccesoADatos.Context context = new AccesoADatos.Context();
            string id = dgvPersona.CurrentRow.Cells[0].Value.ToString();
            int idPersona = Int16.Parse(id);
            context.eliminarPersona(idPersona);
            MessageBox.Show("Transaccion exitosa");
            LLenarGrid();





        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string id = dgvPersona.CurrentRow.Cells[0].Value.ToString();
            int idPersona = Int16.Parse(id);
            frmEditar frmEditar = new frmEditar(idPersona);
            frmEditar.ShowDialog();
            LLenarGrid();
        }
    }
}
