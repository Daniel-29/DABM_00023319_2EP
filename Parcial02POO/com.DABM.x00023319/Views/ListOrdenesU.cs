using System;
using System.Windows.Forms;
using com.DABM.x00023319.Models;

namespace com.DABM.x00023319
{
    public partial class ListOrdenesU : UserControl
    {
        private AppOrdera ordenes = new AppOrdera();
        private int IdOrder = 0;
        public ListOrdenesU(int id)
        {
            InitializeComponent();
            ordenes.Iduser = id;
            CargarDatos();
        }
        public void refrescarDatos()
        {
            ordenes.IdOrder = IdOrder;
        }
        public void CargarDatos()
        {
            dgvDatos1.DataSource=null;
            dgvDatos1.DataSource = ordenes.selectAppOrdera();
           // dgvDatos1.Columns[0].Visible = false;
        }
        private void dgvDatos1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
            {
                IdOrder = Convert.ToInt32(dgvDatos1[0, e.RowIndex].Value.ToString());
                lbMensaje.Text = "Numero de orden seleccionada: " + dgvDatos1[0, e.RowIndex].Value.ToString();
            }
            else
            {
                IdOrder = 0;
                lbMensaje.Text = "Seleccione un producto:";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IdOrder !=0)
            {
                refrescarDatos();
                if (ordenes.deleteAppOrdera())
                {
                    CargarDatos();
                    MessageBox.Show("Se elimino corectamente ");
                    lberror.Visible = false;
                }
                else
                {
                    lberror.Visible = true;
                    lberror.Text = "No se puedo eleiminar";
                }
            }
            else
            {
                lberror.Visible = true;
                lberror.Text = "Ningun campo puede estar vacio";
            }
        }
    }
}