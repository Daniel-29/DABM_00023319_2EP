using System;
using System.Windows.Forms;

namespace com.DABM.x00023319
{
    public partial class UpdatePassword : Form
    {
        AppUser usuario = new AppUser();
        private int id;
        private string user;
        private bool type;
        public UpdatePassword(int id , string user,string pass, bool type)
        {
            InitializeComponent();
            this.id = id;
            this.user = user;
            this.type = type;
            usuario.IdUser = id;
            if (user != pass)
            {
                label1.Text = "Cambio de clave";
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (!Vacio(txtClave.Text.Trim()))
            {
                usuario.Password = txtClave.Text;
                if (usuario.updateUser())
                {
                    Main menu = new Main(id,user,type);
                    menu.Show();
                    this.Hide();
                }
            }
            else
            {
                lbEclave.Visible = true;
                lbEclave.Text = "La contraseña no debe estar vacio.";
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