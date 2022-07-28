using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pea1_TipoDocumento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmTipoDocumentoEdit();
            frm.ShowDialog();

            cargarDatos();
        }


        private void cargarDatos()
        {
         
            var adaptador = new DstTableAdapters.TipoDocumentoTableAdapter();
        
            var tabla = adaptador.GetData();
         
            dgvDatos.DataSource = tabla;


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {


                var frm = new frmTipoDocumentoEdit(id);
                frm.ShowDialog();
                cargarDatos();

            }
            else
            {

                MessageBox.Show("Seleccione un ID válido", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private int getId()

        {
            try
            {
                DataGridViewRow filaActual = dgvDatos.CurrentRow;

                if (filaActual == null)
                {
                    return 0;
                }
                return int.Parse(dgvDatos.Rows[filaActual.Index].Cells[0].Value.ToString());
            }
            catch (Exception)
            {

                return 0;

            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {


            int id = getId();

            if (id > 0)
            {
                var respuesta = MessageBox.Show("¿Realmente desea eliminar el registro?", "Sistemas",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {

                    var adaptador = new DstTableAdapters.TipoDocumentoTableAdapter();
                    adaptador.Deletet(id);

                    MessageBox.Show("Registro eliminado", "Sistemas", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    cargarDatos();

                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un ID válido", "Sistemas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
