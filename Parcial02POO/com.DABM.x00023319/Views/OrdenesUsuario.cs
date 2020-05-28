using System;
using System.Windows.Forms;
using com.DABM.x00023319.Models;

namespace com.DABM.x00023319
{
    public partial class OrdenesUsuario : UserControl
    {
        Address direcciones = new Address();
        Product productos = new Product();
        AppOrdera ordenar = new AppOrdera();
        private int idAddress=0;
        private int idProduct=0;
        public OrdenesUsuario(int idUser)
        {
            InitializeComponent();
            direcciones.IdUser = idUser;
            CargarDatos();
            dtpFecha.MinDate= DateTime.Today;
        }
        public void refrescarDatos()
        {
            ordenar.IdAddress = idAddress;
            ordenar.IdProduct = idProduct;
            ordenar.Fecha = dtpFecha.Value;
        }
        public void CargarDatos()
        {
            dgvDatos1.DataSource=null;
            dgvDatos1.DataSource = direcciones.selectAddress();
            dgvDatos1.Columns[0].Visible = false;
            dgvDatos2.DataSource=null;
            dgvDatos1.Columns[1].Name = "Direccion";
            dgvDatos2.DataSource = productos.selectProduct();
            dgvDatos2.Columns[0].Visible = false;
            dgvDatos2.Columns[1].Name = "Producto";
            dgvDatos2.Columns[2].Name = "Proveedor";
        }

        private void dgvDatos1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
            {
                idAddress = Convert.ToInt32(dgvDatos1[0, e.RowIndex].Value.ToString());
                lbs1.Text = "Direccion seleccionada: " + dgvDatos1[1, e.RowIndex].Value.ToString();
            }
            else
            {
                idAddress = 0;
                lbs1.Text = "Seleccione un direccion:";
            }
        }

        private void dgvDatos2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
            {
                idProduct = Convert.ToInt32(dgvDatos2[0, e.RowIndex].Value.ToString());
                lbs2.Text = "Producto seleccionado: " + dgvDatos2[1, e.RowIndex].Value.ToString();
            }
            else
            {
                idProduct = 0;
                lbs2.Text = "Seleccione un producto:";
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (idProduct!=0 && idAddress!=0)
            {
                refrescarDatos();
                if (ordenar.InsertAppOrdera())
                {
                    CargarDatos();
                    MessageBox.Show("Se ordeno corectamente ");
                    lberror.Visible = false;
                }
                else
                {
                    lberror.Visible = true;
                    lberror.Text = "Este negocio no se puedo guardar";
                }
            }
            else
            {
                lberror.Visible = true;
                lberror.Text = "Debe seleccionar una direccion y un producto";
            }
        }
    }
}