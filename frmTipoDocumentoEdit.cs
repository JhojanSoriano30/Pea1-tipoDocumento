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
    public partial class frmTipoDocumentoEdit : Form
    {


        private int? Id;

        public frmTipoDocumentoEdit(int? id = null)
        {
            InitializeComponent();

            this.Id = id;
        }

        private void btnGuard_Click(object sender, EventArgs e)
        {

            var estado = chkEstado.Checked ? 1 : 0;

            string nombre = txtNombre.Text;
            var adaptador = new DstTableAdapters.TipoDocumentoTableAdapter();
            if (this.Id == null)
            {

                adaptador.Add(nombre, (byte)estado);

            }
            else
            {

                adaptador.Edita(nombre, (byte)estado, (int)this.Id);

            }
            this.Close();

        }

        private void frmTipoDocumentoEdit_Load(object sender, EventArgs e)
        {

            if (this.Id != null)
            {
                this.Text = "Editar";
                var adaptor = new DstTableAdapters.TipoDocumentoTableAdapter();
                var tabla = adaptor.GetDataBySel((int)this.Id);
                var fila = (Dst.TipoDocumentoRow)tabla.Rows[0];
                txtNombre.Text = fila.Nombre;
             

                chkEstado.Checked = fila.Estado == 1 ? true : false;

            }
            else
            {
                this.Text = "Nuevo";

            }


        }
    }
}
