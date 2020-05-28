using System;
using System.Windows.Forms;

namespace com.DABM.x00023319
{
    public partial class Users : UserControl
    {
        AppUser users =new AppUser();
        private int idUser=0;
        private int AdminUser;
        private bool userType;
        public Users(int id)
        {
            InitializeComponent();
            AdminUser = id;
            cmbtipo.Items.Add("admin");
            cmbtipo.Items.Add("client");
            cmbtipo.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarDatos();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
            {
                idUser = Convert.ToInt32(dgvDatos[0, e.RowIndex].Value.ToString());
                txtUsuario.Text= dgvDatos[1, e.RowIndex].Value.ToString();
                txtNombre.Text= dgvDatos[2, e.RowIndex].Value.ToString();
                userType= Convert.ToBoolean(dgvDatos[3, e.RowIndex].Value.ToString());
                if (userType)
                {
                    cmbtipo.SelectedIndex = 0;
                }
                else
                {
                    cmbtipo.SelectedIndex = 1;
                }
            }
        }
        public void refrescarDatos()
        {
            users.IdUser = idUser;
            users.Username = txtUsuario.Text;
            users.Fullname1 = txtNombre.Text;
            users.Password =  txtUsuario.Text;
            users.UserType = cmbtipo.SelectedIndex == 0 ? true : false;
        }
        public bool Vacio(String txt)
        {
            bool vacio = (txt.Length == 0);
            return vacio;
            
        }
        
        public void CargarDatos()
        {
            dgvDatos.DataSource=null;
            cmbtipo.SelectedIndex = 0;
            dgvDatos.DataSource = users.selectUser();
            dgvDatos.Columns[0].Visible = false;
            dgvDatos.Columns[3].Visible = false;
         //   txtnombre.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ( idUser!=0 && idUser!=AdminUser )
            {
                refrescarDatos();
                if ( users.deleteUser())
                {
                    CargarDatos();
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
                lberror.Text = "Debe seleccionar un usuario para eliminar y no se puede eliminar usted mismo";
            }
        }

        public void limpiar()
        {
            txtNombre.Clear();
            txtUsuario.Clear();
            idUser = 0;
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!Vacio(txtNombre.Text) && !Vacio(txtUsuario.Text) && !Vacio(cmbtipo.SelectedItem.ToString()))
            {
                refrescarDatos();
                if (!users.Verificarusername())
                {
                    users.InsertUser();
                    CargarDatos();
                    MessageBox.Show("Se agrego corectamente ");
                    lberror.Visible = false;
                }
                else
                {
                    lberror.Visible = true;
                    lberror.Text = "Este usuario ya esta en uso";
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