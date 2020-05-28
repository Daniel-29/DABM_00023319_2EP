using System;
using System.Windows.Forms;
using com.DABM.x00023319.Models;

namespace com.DABM.x00023319
{
    public partial class Direcciones : UserControl
    {
        Address direeciones =new Address();
        private int idUser;
        private int idAddress=0;
        public Direcciones(int id)
        {
            InitializeComponent();
            idUser = id;
            direeciones.IdUser = idUser;
            CargarDatos();
        }
        public void refrescarDatos()
        {
            direeciones.IdAddress = idAddress;
            direeciones.IdUser = idUser;
            direeciones.Address1 = txtDireccion.Text;
        }
        public bool Vacio(String txt)
        {
            bool vacio = (txt.Length == 0);
            return vacio;
            
        }
        
        public void CargarDatos()
        {
            dgvDatos.DataSource=null;
            dgvDatos.DataSource = direeciones.selectAddress();
            dgvDatos.Columns[0].Visible = false;
            //   txtnombre.Clear();
        }
        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
            {
                idAddress = Convert.ToInt32(dgvDatos[0, e.RowIndex].Value.ToString());
                txtDireccion.Text= dgvDatos[1, e.RowIndex].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ( idAddress!=0 )
            {
                refrescarDatos();
                if (direeciones.deleteAddress())
                {
                    CargarDatos();
                    idAddress = 0;
                    txtDireccion.Clear();
                    MessageBox.Show("Se elimino corectamente ");
                    lberror.Visible = false;
                }
                else
                {
                    MessageBox.Show("No elimino corectamente ");
                }
              
            }
            else
            {
                lberror.Visible = true;
                lberror.Text = "Debe seleccionar una direccio para eliminar";
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!Vacio(txtDireccion.Text))
            {
                refrescarDatos();
                if (direeciones.InsertAddress())
                {
                    CargarDatos();
                    idAddress = 0;
                    txtDireccion.Clear();
                    MessageBox.Show("Se agrego corectamente ");
                    
                    lberror.Visible = false;
                }
                else
                {
                    lberror.Visible = true;
                    lberror.Text = "Esta direccion no puedo guardar";
                }
            }
            else
            {
                lberror.Visible = true;
                lberror.Text = "Ningun campo puede estar vacio";
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!Vacio(txtDireccion.Text) && idAddress !=0)
            {
                refrescarDatos();
                if (direeciones.updateAddress())
                {
                    CargarDatos();
                    idAddress = 0;
                    txtDireccion.Clear();
                    MessageBox.Show("Se actualizo corectamente ");
                    lberror.Visible = false;
                }
                else
                {
                    lberror.Visible = true;
                    lberror.Text = "Esta direccion no puedo guardar";
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