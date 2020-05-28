using System;
using System.Windows.Forms;
using com.DABM.x00023319.Models;

namespace com.DABM.x00023319
{
    public partial class Negocios : UserControl
    {
        private int  idBusiness;
        Business negocio = new Business();
        public Negocios(int id)
        {
            InitializeComponent();
            CargarDatos();
        }
        public void refrescarDatos()
        {
            negocio.IdBusiness = idBusiness;
            negocio.Name = txtnegocio.Text;
            negocio.Description = txtDescription.Text;
        }
        public bool Vacio(String txt)
        {
            bool vacio = (txt.Length == 0);
            return vacio;
            
        }
        
        public void CargarDatos()
        {
            dgvDatos.DataSource=null;
            dgvDatos.DataSource = negocio.selectBusiness();
            dgvDatos.Columns[0].Visible = false;
            //   txtnombre.Clear();
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!Vacio(txtnegocio.Text) && !Vacio(txtDescription.Text))
            {
                refrescarDatos();
                if (negocio.InsertBusiness())
                {
                    CargarDatos();
                    txtnegocio.Clear();
                    txtDescription.Clear();
                    idBusiness = 0;
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!Vacio(txtnegocio.Text) && !Vacio(txtDescription.Text))
            {
                refrescarDatos();
                if (negocio.updateBusiness())
                {
                    CargarDatos();
                    txtnegocio.Clear();
                    txtDescription.Clear();
                    idBusiness = 0;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idBusiness !=0)
            {
                refrescarDatos();
                if (negocio.deleteBusiness())
                {
                    CargarDatos();
                    txtnegocio.Clear();
                    txtDescription.Clear();
                    idBusiness = 0;
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

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
            {
                idBusiness = Convert.ToInt32(dgvDatos[0, e.RowIndex].Value.ToString());
                txtnegocio.Text= dgvDatos[1, e.RowIndex].Value.ToString();
                txtDescription.Text= dgvDatos[2, e.RowIndex].Value.ToString();
            }
        }
    }
}