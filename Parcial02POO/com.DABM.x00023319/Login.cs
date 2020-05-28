using System;
using System.Data;
using System.Windows.Forms;

namespace com.DABM.x00023319
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if ( !Vacio(txtUsuario.Text.Trim()))
            {
                lbEusuario.Visible = false;
                if (!Vacio(txtClave.Text.Trim()))
                {
                    AppUser login = new  AppUser ();
                    login.Username = txtUsuario.Text;
                    login.Password = txtClave.Text;
                    DataTable dato = login.login();
                    if (dato!= null)
                    {
                        int idUser = Convert.ToInt32(dato.Rows[0][0].ToString());
                        string Username = dato.Rows[0][1].ToString();
                        bool userType = Convert.ToBoolean(dato.Rows[0][2].ToString());
                        if (login.Username ==login.Password)
                        {
                            UpdatePassword menu = new UpdatePassword(idUser,Username,Username,userType);
                            menu.Show();
                            this.Hide();
                        }
                        else
                        {
                            Main menu = new Main(idUser,Username,userType);
                            menu.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        lbEclave.Visible = true;
                        lbEusuario.Visible = true;
                        lbEclave.Text = "Dato incorecto.";
                        lbEusuario.Text = "Dato incorecto o no existe ";
                    }
                }
                else
                {
                    lbEclave.Visible = true;
                    lbEclave.Text = "Esta campo no debe estar vacio.";
                }
            }
            else
            {
                lbEusuario.Visible = true;
                lbEusuario.Text = "Esta campo no debe estar vacio.";
            }
            
        }

        public bool Vacio(String txt)
        {
            bool vacio = (txt.Length == 0);
            //lbEusuario.Text = ""+""+vacio;
            return vacio;
            
        }
    }
}