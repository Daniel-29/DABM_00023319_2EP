using System;
using System.Windows.Forms;
using com.DABM.x00023319.Models;

namespace com.DABM.x00023319
{
    public partial class Producto : UserControl
    {
        Business empresa = new Business();
        Product producto =new Product();
        private int idBusiness=0;
        private int idProduct;
        public Producto()
        {
            InitializeComponent();
            CargarDatos();
        }
        public void refrescarDatos()
        {
            producto.IdBusiness = idBusiness;
            producto.Name = txtNombre.Text;
            producto.IdProduct = idProduct;
        }
        public bool Vacio(String txt)
        {
            bool vacio = (txt.Length == 0);
            return vacio;
            
        }
        
        public void CargarDatos()
        {
            dgvDatos.DataSource=null;
            dgvDatos.DataSource = producto.selectProduct();
            dgvDatos.Columns[0].Visible = false;
            dataGridView1.DataSource=null;
            dataGridView1.DataSource = empresa.selectBusiness();
            dataGridView1.Columns[0].Visible = false;
        }
        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
            {
                idProduct = Convert.ToInt32(dgvDatos[0, e.RowIndex].Value.ToString());
                txtNombre.Text= dgvDatos[1, e.RowIndex].Value.ToString();
            }
            else
            {
                idProduct = 0;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
            {
                idBusiness = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value.ToString());
                Nombre.Text = "Negocio seleccionado:" + dataGridView1[1, e.RowIndex].Value.ToString();
            }
            else
            {
                idBusiness = 0;
                Nombre.Text = "Seleccione un direccion:";
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!Vacio(txtNombre.Text) && idBusiness!=0)
            {
                refrescarDatos();
                if (producto.InsertProduct())
                {
                    CargarDatos();
                    idBusiness = 0;
                    Nombre.Text = "Seleccione un direccion:";
                    txtNombre.Clear();
                    MessageBox.Show("Se agrego corectamente ");
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
                lberror.Text = "Ningun campo puede estar vacio";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProduct !=0)
            {
                refrescarDatos();
                if (producto.deleteProduct())
                {
                    CargarDatos();
                    Nombre.Text = "Seleccione un direccion:";
                    txtNombre.Text="";
                    idProduct = 0;
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